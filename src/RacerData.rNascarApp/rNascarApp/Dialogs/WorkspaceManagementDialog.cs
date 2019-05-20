using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using log4net;
using RacerData.Common.Ports;
using RacerData.rNascarApp.Models;
using RacerData.rNascarApp.Services;

namespace RacerData.rNascarApp.Dialogs
{
    public partial class WorkspaceManagementDialog : Form
    {
        #region fields

        private Guid? _revertItemKey = null;
        private Guid _revertListKey = Guid.Empty;
        private readonly IRevertableService _revertableService = null;
        private readonly ILog _log = null;
        private readonly IStateService _stateService = null;
        private readonly IWorkspaceService _workspaceService = null;
        private readonly ISerializer _serializer = null;

        #endregion

        #region properties

        public Workspace Workspace { get; set; }
        public IList<Workspace> Workspaces { get; set; }
        public IList<ViewState> Views { get; set; }

        public ChangeSet<Workspace> ChangeSet { get; protected set; } = new ChangeSet<Workspace>();

        protected bool IsNew { get; set; }
        protected bool HasSelection
        {
            get
            {
                return Workspace != null;
            }
        }
        private bool _isEditing;
        protected bool IsEditing
        {
            get
            {
                return _isEditing;
            }
            set
            {
                _isEditing = value;
                SetFormState();
            }
        }

        #endregion

        #region ctor/load

        internal WorkspaceManagementDialog()
        {
            InitializeComponent();
        }

        public WorkspaceManagementDialog(
            ILog log,
            IStateService stateService,
            IWorkspaceService workspaceService,
            ISerializer serializer,
            IRevertableService revertableService)
            : this()
        {
            _log = log ?? throw new ArgumentNullException(nameof(log));
            _stateService = stateService ?? throw new ArgumentNullException(nameof(stateService));
            _workspaceService = workspaceService ?? throw new ArgumentNullException(nameof(workspaceService));
            _serializer = serializer ?? throw new ArgumentNullException(nameof(serializer));
            _revertableService = revertableService ?? throw new ArgumentNullException(nameof(revertableService));

            Views = _stateService.State.ViewStates;

            Workspaces = _serializer.DeepCopy(_workspaceService.Workspaces);

            Workspace = Workspaces.FirstOrDefault(w => w.IsActive);
        }

        private void WorkspaceManagementDialog_Load(object sender, EventArgs e)
        {
            _revertListKey = _revertableService.PersistState((BindingList<Workspace>)Workspaces);

            DisplayWorkspaces(Workspace);

            SetFormState();
        }

        #endregion

        #region protected

        protected virtual void ExceptionHandler(string message, Exception ex)
        {
            _log?.Error(message, ex);

            MessageBox.Show(this, ex.Message, message, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        protected virtual void SetFormState()
        {
            btnEditSave.Enabled = HasSelection;
            btnEditSave.Text = IsEditing ? "Save" : "Edit";
            btnCancelSaveAndClose.Enabled = true;
            btnCancelSaveAndClose.Text = IsEditing ? "Cancel" : "Save && Close";

            toolTip1.SetToolTip(btnEditSave,
               (IsEditing ?
               "Save your changes and finish editing" :
               "Edit the selected View"));

            toolTip1.SetToolTip(btnCancelSaveAndClose,
               (IsEditing ?
               "Revert changes and finish editing" :
               "Save all changes and close this form"));

            btnCancelAndClose.Visible = !IsEditing;
            btnCancelAndClose.Enabled = true;

            btnNew.Enabled = !IsEditing;
            btnCopy.Enabled = !IsEditing && HasSelection;
            btnDelete.Enabled = !IsEditing && HasSelection;

            pnlSelection.Enabled = !IsEditing;
            pnlDetails.Enabled = IsEditing;
        }

        protected virtual void DisplayWorkspaces(Workspace workspace = null)
        {
            cboWorkspaces.DataSource = null;
            cboWorkspaces.DisplayMember = "Name";
            cboWorkspaces.DataSource = Workspaces.OrderBy(v => v.Name).ToList();

            if (workspace != null)
                cboWorkspaces.SelectedItem = workspace;
            else
                cboWorkspaces.SelectedIndex = -1;
        }
        protected virtual void DisplayWorkspaceDetails(Workspace workspace)
        {
            ClearWorkspaceDetails();

            if (workspace == null)
                return;

            txtName.DataBindings.Add(new Binding("Text", workspace, "Name"));

            chkPractice.DataBindings.Add(new Binding("Checked", workspace, "IsDefaultPracticeWorkspace"));
            chkQualifying.DataBindings.Add(new Binding("Checked", workspace, "IsDefaultQualifyingWorkspace"));
            chkRace.DataBindings.Add(new Binding("Checked", workspace, "IsDefaultRaceWorkspace"));
            numRows.DataBindings.Add(new Binding("Value", workspace, "GridRowCount"));
            numColumns.DataBindings.Add(new Binding("Value", workspace, "GridColumnCount"));

            UpdateViewsLists(workspace);
        }
        protected virtual void UpdateViewsLists(Workspace workspace)
        {
            lstViews.DisplayMember = "Name";
            lstViews.ValueMember = "Id";
            lstViews.DataSource = GetWorkspaceViews(workspace);
            lstViews.SelectedIndex = -1;

            lstAllViews.DisplayMember = "Name";
            lstAllViews.ValueMember = "Id";
            lstAllViews.DataSource = GetAvailableViews(workspace);
            lstAllViews.SelectedIndex = -1;
        }
        protected virtual void ClearWorkspaceDetails()
        {
            txtName.DataBindings.Clear();
            chkPractice.DataBindings.Clear();
            chkQualifying.DataBindings.Clear();
            chkRace.DataBindings.Clear();
            numColumns.DataBindings.Clear();
            numRows.DataBindings.Clear();

            txtName.Clear();
            chkPractice.Checked = false;
            chkQualifying.Checked = false;
            chkRace.Checked = false;
            numColumns.Value = numColumns.Minimum;
            numRows.Value = numRows.Minimum;

            lstViews.DataSource = null;
        }

        protected virtual void BeginEdit()
        {
            if (Workspace.Name == Workspace.DefaultWorkspaceName)
            {
                MessageBox.Show(this, "Can't edit default workspace", "Can't edit default", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _revertItemKey = _revertableService.PersistState(Workspace);

            IsNew = false;
            IsEditing = true;
        }
        protected virtual void BeginCreate()
        {
            Workspace = new Workspace()
            {
                Name = "New Workspace",
                GridColumnCount = _workspaceService.CurrentWorkspace.GridColumnCount,
                GridRowCount = _workspaceService.CurrentWorkspace.GridRowCount
            };

            DisplayWorkspaceDetails(Workspace);

            IsNew = true;
            IsEditing = true;
        }
        protected virtual void BeginCopy()
        {
            Workspace = Workspace.Copy($"Copy of {Workspace.Name}");

            DisplayWorkspaceDetails(Workspace);

            IsNew = true;
            IsEditing = true;
        }
        protected virtual void BeginDelete()
        {
            if (Workspace.Name == Workspace.DefaultWorkspaceName)
            {
                MessageBox.Show(this, "Can't delete default workspace", "Can't delete default", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            IsNew = false;
            IsEditing = true;

            btnCancelSaveAndClose.Enabled = false;
            btnEditSave.Enabled = false;

            try
            {
                var confirmDeletePromptResult = MessageBox.Show(
                    this,
                    $"You are about to delete workspace '{Workspace.Name}'. Are you sure?",
                    "Confirm Delete",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (confirmDeletePromptResult == DialogResult.Yes)
                {
                    Workspaces.Remove(Workspace);

                    Workspace = null;

                    ClearWorkspaceDetails();

                    DisplayWorkspaces();
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler("Error deleting workspace", ex);
            }
            finally
            {
                IsEditing = false;
            }
        }
        protected virtual void SaveChanges()
        {
            if (IsNew)
            {
                if (Workspaces.Any(v => v.Name == Workspace.Name))
                {
                    MessageBox.Show(this,
                      "Duplicate name",
                      "Workspace name must be unique",
                      MessageBoxButtons.OK,
                      MessageBoxIcon.Warning);

                    return;
                }

                Workspaces.Add(Workspace);
            }

            IsNew = false;
            IsEditing = false;

            if (_revertItemKey.HasValue)
            {
                _revertableService.ClearState(_revertItemKey.Value);
                _revertItemKey = null;
            }

            DisplayWorkspaces(Workspace);
        }
        protected virtual void CancelEdit()
        {
            if (!IsNew && _revertItemKey.HasValue)
            {
                Workspace = _revertableService.RevertState<Workspace>(_revertItemKey.Value);
                _revertItemKey = null;
            }

            IsNew = false;
            IsEditing = false;

            DisplayWorkspaces(Workspace);
        }

        protected virtual void RevertAndCloseDialog()
        {
            Workspaces = _revertableService.RevertState<List<Workspace>>(_revertListKey);
            DialogResult = DialogResult.Cancel;
        }
        protected virtual void SaveAndCloseDialog()
        {
            UpdateChangeSet();

            _revertableService.ClearState(_revertListKey);

            DialogResult = DialogResult.OK;
        }

        protected virtual List<ViewState> GetWorkspaceViews(Workspace workspace)
        {
            return Views.Where(v => workspace.ViewStates.Contains(v.Id)).OrderBy(v => v.Name).ToList();
        }
        protected virtual List<ViewState> GetAvailableViews(Workspace workspace)
        {
            return Views.Where(v => !workspace.ViewStates.Contains(v.Id)).OrderBy(v => v.Name).ToList();
        }

        protected virtual void AddViewToWorkspace(ViewState view)
        {
            Workspace.ViewStates.Add(view.Id);

            UpdateViewsLists(Workspace);
        }
        protected virtual void RemoveViewFromWorkspace(ViewState view)
        {
            Workspace.ViewStates.Remove(view.Id);

            UpdateViewsLists(Workspace);
        }

        protected virtual void UpdateChangeSet()
        {
            List<Workspace> originalStates = _revertableService.PeekState<List<Workspace>>(_revertListKey);

            foreach (Workspace originalState in originalStates)
            {
                var currentState = Workspaces.FirstOrDefault(v => v.Name == originalState.Name);

                if (currentState == null)
                {
                    ChangeSet.Deleted.Add(originalState);
                }
                else
                {
                    if (!currentState.Equals(originalState))
                    {
                        ChangeSet.Edited.Add(currentState);
                    }
                }
            }

            foreach (Workspace currentState in Workspaces)
            {
                var originalState = originalStates.FirstOrDefault(v => v.Name == currentState.Name);

                if (originalState == null)
                {
                    ChangeSet.Added.Add(currentState);
                }
            }
        }

        #endregion

        #region private

        private void cboWorkspaces_SelectedIndexChanged(object sender, EventArgs e)
        {
            Workspace = (Workspace)cboWorkspaces.SelectedItem;

            DisplayWorkspaceDetails(Workspace);

            SetFormState();
        }

        private void btnEditOrSave_Click(object sender, EventArgs e)
        {
            if (IsEditing)
                SaveChanges();
            else
                BeginEdit();
        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            BeginCreate();
        }
        private void btnCopy_Click(object sender, EventArgs e)
        {
            BeginCopy();
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            BeginDelete();
        }
        private void btnCancelOrSaveAndClose_Click(object sender, EventArgs e)
        {
            if (IsEditing)
                CancelEdit();
            else
                SaveAndCloseDialog();
        }
        private void btnCancelAndClose_Click(object sender, EventArgs e)
        {
            RevertAndCloseDialog();
        }

        private void lstViews_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnRemoveView.Enabled = (lstViews.SelectedItem != null);
        }
        private void lstViews_DoubleClick(object sender, EventArgs e)
        {
            if (lstViews.SelectedItem == null)
                return;

            RemoveViewFromWorkspace((ViewState)lstViews.SelectedItem);

            UpdateViewsLists(Workspace);
        }
        private void lstAllViews_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnAddView.Enabled = (lstAllViews.SelectedItem != null);
        }
        private void lstAllViews_DoubleClick(object sender, EventArgs e)
        {
            if (lstAllViews.SelectedItem == null)
                return;

            AddViewToWorkspace((ViewState)lstAllViews.SelectedItem);
        }
        private void btnAddView_Click(object sender, EventArgs e)
        {
            if (lstAllViews.SelectedItem == null)
                return;

            AddViewToWorkspace((ViewState)lstAllViews.SelectedItem);
        }
        private void btnRemoveView_Click(object sender, EventArgs e)
        {
            if (lstViews.SelectedItem == null)
                return;

            RemoveViewFromWorkspace((ViewState)lstViews.SelectedItem);
        }

        #endregion
    }
}
