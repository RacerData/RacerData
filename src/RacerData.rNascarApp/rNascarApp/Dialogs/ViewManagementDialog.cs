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
            _viewsState = PersistViewsState(Views.ToList());

            DisplayViews(View);

            PropertyChanged += ViewManagementDialog_PropertyChanged;

            SetFormState();
        }

        #endregion

        #region protected

        protected virtual string PersistViewsState(List<ViewState> views)
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
        protected virtual List<ViewState> RestoreViewsState(string json)
        {
            return JsonConvert.DeserializeObject<List<ViewState>>(json);
        }
        protected virtual string PersistViewState(ViewState view)
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
        protected virtual ViewState RestoreViewState(string json)
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

        protected virtual void DisplayViews(ViewState view = null)
        {
            cboViewStates.DataSource = null;
            cboViewStates.DisplayMember = "Name";
            cboViewStates.DataSource = Views.OrderBy(v => v.Name).ToList();

            if (view != null)
                cboViewStates.SelectedItem = view;
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
            lstFields.DisplayMember = "Name";
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
            _viewState = PersistViewState(View);

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

            btnCancelSaveAndClose.Enabled = false;
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

            DisplayViews(View);
        }
        protected virtual void CancelEdit()
        {
            if (!IsNew && !String.IsNullOrEmpty(_viewState))
            {
                View = RestoreViewState(_viewState);
                _viewState = String.Empty;
            }

            IsNew = false;
            IsEditing = false;

            DisplayViews(View);
        }
        protected virtual void DisplayViewEditor(ViewState view)
        {
            try
            {
                // TODO:
            }
            catch (Exception ex)
            {
                ExceptionHandler("Error editing view", ex);
            }
        }

        protected virtual void RevertAndCloseDialog()
        {
            Views = RestoreViewsState(_viewsState);
            DialogResult = DialogResult.Cancel;
        }
        protected virtual void SaveAndCloseDialog()
        {
            DialogResult = DialogResult.OK;
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

        #endregion
    }
}
