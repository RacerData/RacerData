using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using log4net;
using Newtonsoft.Json;
using RacerData.rNascarApp.Controls.CreateViewWizard;
using RacerData.rNascarApp.Factories;
using RacerData.rNascarApp.Models;
using RacerData.rNascarApp.Settings;

namespace RacerData.rNascarApp.Dialogs
{
    public partial class ViewManagementDialog : Form, INotifyPropertyChanged
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

        private string _viewsState = string.Empty;
        private string _viewState = string.Empty;

        #endregion

        #region properties

        public ILog Log { get; set; }
        public ViewState View { get; set; }
        public IList<ViewState> Views { get; set; }
        public ChangeSet<ViewState> ChangeSet { get; protected set; }

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
                OnPropertyChanged(nameof(IsEditing));
            }
        }
        protected bool IsNew { get; set; }

        #endregion

        #region ctor/load

        public ViewManagementDialog()
        {
            InitializeComponent();
        }

        private void ViewManagementDialog_Load(object sender, EventArgs e)
        {
            ChangeSet = new ChangeSet<ViewState>();

            _viewsState = SerializeItemList(Views.ToList());

            DisplayViews(View?.Id);

            PropertyChanged += ViewManagementDialog_PropertyChanged;

            SetFormState();
        }

        #endregion

        #region protected

        protected virtual string SerializeItemList(List<ViewState> views)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All,
                NullValueHandling = NullValueHandling.Include
            };

            return JsonConvert.SerializeObject(
                    views,
                    Formatting.Indented,
                    settings);
        }
        protected virtual List<ViewState> DeserializeItemList(string json)
        {
            return JsonConvert.DeserializeObject<List<ViewState>>(json);
        }
        protected virtual string SerializeItem(ViewState view)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All,
                NullValueHandling = NullValueHandling.Include
            };

            return JsonConvert.SerializeObject(
                    view,
                    Formatting.Indented,
                    settings);
        }
        protected virtual ViewState DeserializeItem(string json)
        {
            return JsonConvert.DeserializeObject<ViewState>(json);
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

            UpdateViewsFields(view);
        }
        protected virtual void UpdateViewsFields(ViewState view)
        {
            lstFields.DisplayMember = "Caption";
            lstFields.ValueMember = "Index";
            lstFields.DataSource = view.ListSettings.OrderedColumns;
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
            _viewState = SerializeItem(View);

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
                Views.Add(View);
            }

            IsNew = false;
            IsEditing = false;

            DisplayViews(View?.Id);
        }
        protected virtual void CancelEdit()
        {
            if (!IsNew && !String.IsNullOrEmpty(_viewState))
            {
                View = DeserializeItem(_viewState);
                _viewState = String.Empty;
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
            Views = DeserializeItemList(_viewsState);
            DialogResult = DialogResult.Cancel;
        }
        protected virtual void SaveAndCloseDialog()
        {
            UpdateChangeSet();

            DialogResult = DialogResult.OK;
        }

        protected virtual void UpdateChangeSet()
        {
            var originalStates = DeserializeItemList(_viewsState);

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

        private void ViewManagementDialog_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            SetFormState();
        }

        private void cboViews_SelectedIndexChanged(object sender, EventArgs e)
        {
            View = (ViewState)cboViewStates.SelectedItem;

            DisplayViewDetails(View);

            SetFormState();
        }

        private void btnEditFields_Click(object sender, EventArgs e)
        {
            DisplayViewEditor(View);
        }

        private void removeFieldToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (View == null)
                return;

            ListColumn columnToRemove = (ListColumn)lstFields.SelectedItem;

            if (columnToRemove == null)
                return;

            View.ListSettings.Columns.Remove(columnToRemove);

            UpdateViewsFields(View);
        }

        private void ctxFields_Opening(object sender, CancelEventArgs e)
        {
            e.Cancel = (View == null || lstFields.SelectedItem == null);
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
                RevertAndCloseDialog();
        }
        private void btnCancelAndClose_Click(object sender, EventArgs e)
        {
            SaveAndCloseDialog();
        }

        #endregion
    }
}
