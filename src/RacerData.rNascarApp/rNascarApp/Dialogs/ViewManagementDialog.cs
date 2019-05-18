using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using log4net;
using RacerData.rNascarApp.Models;
using RacerData.rNascarApp.Services;

namespace RacerData.rNascarApp.Dialogs
{
    public partial class ViewManagementDialog : Form
    {
        #region fields

        private Guid? _revertItemKey = null;
        private Guid _revertListKey = Guid.Empty;
        private readonly IRevertableService _revertableService = null;
        private readonly ILog _log = null;
        private readonly IStateService _stateService = null;
        private readonly ISerializer _serializer = null;

        #endregion

        #region properties

        public ViewState View { get; set; }
        public IList<ViewState> Views { get; set; }
        public ChangeSet<ViewState> ChangeSet { get; protected set; } = new ChangeSet<ViewState>();

        protected bool IsNew { get; set; }
        protected bool HasSelection
        {
            get
            {
                return View != null;
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

        internal ViewManagementDialog()
        {
            InitializeComponent();
        }

        public ViewManagementDialog(
         ILog log,
         IStateService stateService,
         ISerializer serializer,
         IRevertableService revertableService)
         : this()
        {
            _log = log ?? throw new ArgumentNullException(nameof(log));
            _stateService = stateService ?? throw new ArgumentNullException(nameof(stateService));
            _serializer = serializer ?? throw new ArgumentNullException(nameof(serializer));
            _revertableService = revertableService ?? throw new ArgumentNullException(nameof(revertableService));

            Views = _serializer.DeepCopy(_stateService.State.ViewStates);
        }

        private void ViewManagementDialog_Load(object sender, EventArgs e)
        {
            _revertListKey = _revertableService.PersistState((BindingList<ViewState>)Views);

            DisplayViews(View?.Id);

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
            btnCancelOrCancelAndClose.Enabled = true;
            btnCancelOrCancelAndClose.Text = IsEditing ? "Cancel" : "Cancel && Close";

            viewManagementToolTip.SetToolTip(btnEditSave,
                (IsEditing ?
                "Save your changes and finish editing" :
                "Edit the selected View"));

            viewManagementToolTip.SetToolTip(btnCancelOrCancelAndClose,
               (IsEditing ?
               "Revert changes and finish editing" :
               "Revert all changes and close this form"));

            btnSaveAndClose.Visible = !IsEditing;
            btnSaveAndClose.Enabled = true;

            btnNew.Enabled = !IsEditing;
            btnCopy.Enabled = !IsEditing && HasSelection;
            btnDelete.Enabled = !IsEditing && HasSelection;

            pnlSelection.Enabled = !IsEditing;
            pnlDetails.Enabled = IsEditing;
        }

        protected virtual void DisplayViews(Guid? id = null)
        {
            cboViewStates.DataSource = null;
            cboViewStates.DisplayMember = "Name";
            cboViewStates.ValueMember = "Id";
            cboViewStates.DataSource = Views.OrderBy(v => v.Name).ToList();

            if (id.HasValue)
                cboViewStates.SelectedValue = id.Value;
            else
                cboViewStates.SelectedIndex = -1;
        }
        protected virtual void DisplayViewDetails(ViewState view)
        {
            ClearViewDetails();

            if (view == null)
                return;

            txtName.DataBindings.Add(new Binding("Text", view, "Name"));

            numMaxRows.Value = view.ListDefinition.MaxRows.HasValue ? view.ListDefinition.MaxRows.Value : 8;

            UpdateViewsFields(view);
        }
        protected virtual void UpdateViewsFields(ViewState view)
        {
            lstFields.DisplayMember = "Caption";
            lstFields.ValueMember = "Index";
            lstFields.DataSource = view.ListDefinition.OrderedColumns;
            lstFields.SelectedIndex = -1;
        }
        protected virtual void ClearViewDetails()
        {
            txtName.DataBindings.Clear();

            txtName.Clear();

            lstFields.DataSource = null;
        }

        protected virtual void BeginEdit()
        {
            _revertItemKey = _revertableService.PersistState(View);

            IsNew = false;
            IsEditing = true;
        }
        protected virtual void BeginCreate()
        {
            View = new ViewState()
            {
                Name = "New View"
            };

            DisplayViewDetails(View);

            IsNew = true;
            IsEditing = true;
        }
        protected virtual void BeginCopy()
        {
            View = View.Copy();

            DisplayViewDetails(View);

            IsNew = true;
            IsEditing = true;
        }
        protected virtual void BeginDelete()
        {
            IsNew = false;
            IsEditing = true;

            btnCancelOrCancelAndClose.Enabled = false;
            btnEditSave.Enabled = false;

            try
            {
                var confirmDeletePromptResult = MessageBox.Show(
                    this,
                    $"You are about to delete view '{View.Name}'. Are you sure?",
                    "Confirm Delete",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (confirmDeletePromptResult == DialogResult.Yes)
                {
                    Views.Remove(View);

                    View = null;

                    ClearViewDetails();

                    DisplayViews();
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler("Error deleting view", ex);
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
                if (Views.Any(v => v.Name == View.Name))
                {
                    MessageBox.Show(this,
                      "Duplicate name",
                      "View name must be unique",
                      MessageBoxButtons.OK,
                      MessageBoxIcon.Warning);

                    return;
                }

                Views.Add(View);
            }

            View.ListDefinition.MaxRows = (int)numMaxRows.Value;

            IsNew = false;
            IsEditing = false;

            _revertableService.ClearState(_revertItemKey.Value);
            _revertItemKey = null;

            DisplayViews(View?.Id);
        }
        protected virtual void CancelEdit()
        {
            if (!IsNew && _revertItemKey.HasValue)
            {
                View = _revertableService.RevertState<ViewState>(_revertItemKey.Value);
                _revertItemKey = null;
            }

            IsNew = false;
            IsEditing = false;

            DisplayViews(View?.Id);
        }

        protected virtual void DisplayViewEditor(ViewState view)
        {
            try
            {
                using (var dialog = new ColumnEditorView()
                {
                    ViewState = View,
                    ShowViewSettings = true
                })
                {
                    var result = dialog.ShowDialog(this);

                    if (result == DialogResult.OK)
                    {
                        View = dialog.ViewState;

                        DisplayViews(View?.Id);
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler("Error editing view fields", ex);
            }
        }

        protected virtual void RevertAndCloseDialog()
        {
            Views = _revertableService.RevertState<List<ViewState>>(_revertListKey);
            DialogResult = DialogResult.Cancel;
        }
        protected virtual void SaveAndCloseDialog()
        {
            UpdateChangeSet();

            _revertableService.ClearState(_revertListKey);

            DialogResult = DialogResult.OK;
        }

        protected virtual void UpdateChangeSet()
        {
            List<ViewState> originalStates = _revertableService.PeekState<List<ViewState>>(_revertListKey);

            foreach (ViewState originalState in originalStates)
            {
                var currentState = Views.FirstOrDefault(v => v.Id == originalState.Id);

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

            foreach (ViewState currentState in Views)
            {
                var originalState = originalStates.FirstOrDefault(v => v.Id == currentState.Id);

                if (originalState == null)
                {
                    ChangeSet.Added.Add(currentState);
                }
            }
        }

        #endregion

        #region private

        private void cboViews_SelectedIndexChanged(object sender, EventArgs e)
        {
            View = (ViewState)cboViewStates.SelectedItem;

            DisplayViewDetails(View);

            SetFormState();
        }

        private void removeFieldToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (View == null)
                return;

            ListColumn columnToRemove = (ListColumn)lstFields.SelectedItem;

            if (columnToRemove == null)
                return;

            View.ListDefinition.Columns.Remove(columnToRemove);

            UpdateViewsFields(View);
        }
        private void ctxFields_Opening(object sender, CancelEventArgs e)
        {
            e.Cancel = (View == null || lstFields.SelectedItem == null);
        }

        private void btnEditFields_Click(object sender, EventArgs e)
        {
            DisplayViewEditor(View);
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
                RevertAndCloseDialog();
        }
        private void btnCancelAndClose_Click(object sender, EventArgs e)
        {
            SaveAndCloseDialog();
        }

        #endregion
    }
}
