using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using log4net;
using Newtonsoft.Json;
using RacerData.rNascarApp.Models;
using RacerData.rNascarApp.Settings;

namespace RacerData.rNascarApp.Dialogs
{
    public partial class WorkspaceManagementDialog : Form, INotifyPropertyChanged
    {
        #region events

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            handler?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        #region fields

        private string _workspacesState = string.Empty;
        private string _workspaceState = string.Empty;

        #endregion

        #region properties

        public ILog Log { get; set; }
        public Workspace Workspace { get; set; }
        public IList<Workspace> Workspaces { get; set; }
        public IList<ViewState> Views { get; set; }
        public int GridRowCount { get; set; } = 8;
        public int GridColumnCount { get; set; } = 8;

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
                OnPropertyChanged(nameof(IsEditing));
            }
        }
        protected bool IsNew { get; set; }

        #endregion

        #region ctor/load

        public WorkspaceManagementDialog()
        {
            InitializeComponent();
        }

        private void WorkspaceManagementDialog_Load(object sender, EventArgs e)
        {
            _workspacesState = PersistWorkspacesState(Workspaces.ToList());

            DisplayWorkspaces(Workspace);

            PropertyChanged += WorkspaceManagementDialog_PropertyChanged;

            SetFormState();
        }

        #endregion

        #region protected

        protected virtual string PersistWorkspacesState(List<Workspace> workspaces)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All,
                NullValueHandling = NullValueHandling.Include
            };

            return JsonConvert.SerializeObject(
                    workspaces,
                    Formatting.Indented,
                    settings);
        }
        protected virtual List<Workspace> RestoreWorkspacesState(string json)
        {
            return JsonConvert.DeserializeObject<List<Workspace>>(json);
        }
        protected virtual string PersistWorkspaceState(Workspace workspace)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All,
                NullValueHandling = NullValueHandling.Include
            };

            return JsonConvert.SerializeObject(
                    workspace,
                    Formatting.Indented,
                    settings);
        }
        protected virtual Workspace RestoreWorkspaceState(string json)
        {
            return JsonConvert.DeserializeObject<Workspace>(json);
        }

        protected virtual void ExceptionHandler(string message, Exception ex)
        {
            Log?.Error(message, ex);
#if DEBUG
            Console.WriteLine(ex);
#endif
            MessageBox.Show(this, ex.Message, message, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        protected virtual void SetFormState()
        {
            btnEditSave.Enabled = HasSelection;
            btnEditSave.Text = IsEditing ? "Save" : "Edit";
            btnCancelSaveAndClose.Enabled = true;
            btnCancelSaveAndClose.Text = IsEditing ? "Cancel" : "Save && Close";

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

            _workspaceState = PersistWorkspaceState(Workspace);

            IsNew = false;
            IsEditing = true;
        }
        protected virtual void BeginCreate()
        {
            Workspace = new Workspace()
            {
                Name = "New Workspace",
                GridColumnCount = GridColumnCount,
                GridRowCount = GridRowCount
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
                Workspaces.Add(Workspace);
            }

            IsNew = false;
            IsEditing = false;

            DisplayWorkspaces(Workspace);
        }
        protected virtual void CancelEdit()
        {
            if (!IsNew && !String.IsNullOrEmpty(_workspaceState))
            {
                Workspace = RestoreWorkspaceState(_workspaceState);
                _workspaceState = String.Empty;
            }

            IsNew = false;
            IsEditing = false;

            DisplayWorkspaces(Workspace);
        }
        protected virtual void RevertAndCloseDialog()
        {
            Workspaces = RestoreWorkspacesState(_workspacesState);
            DialogResult = DialogResult.Cancel;
        }
        protected virtual void SaveAndCloseDialog()
        {
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

        #endregion

        #region private

        private void WorkspaceManagementDialog_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            SetFormState();
        }

        private void cboWorkspaces_SelectedIndexChanged(object sender, EventArgs e)
        {
            Workspace = (Workspace)cboWorkspaces.SelectedItem;

            DisplayWorkspaceDetails(Workspace);

            SetFormState();
        }

        // dialog buttons
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

        // add/remove views
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
