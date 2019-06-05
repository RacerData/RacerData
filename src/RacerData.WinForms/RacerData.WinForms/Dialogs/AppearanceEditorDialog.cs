using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using RacerData.Commmon.Results;
using RacerData.WinForms.Models;
using RacerData.WinForms.Ports;

namespace RacerData.WinForms.Dialogs
{
    public partial class AppearanceEditorDialog : Form
    {
        #region fields

        private readonly IAppAppearanceRepository _repository;
        private readonly IDialogService _dialogService;
        private IList<ApplicationAppearance> _items;
        private bool _isLoading = true;
        private bool _isEditing = false;
        private bool _isNew = false;

        #endregion

        #region properties

        protected virtual bool HasSelection
        {
            get
            {
                return cboAppearances.SelectedItem != null;
            }
        }

        public ApplicationAppearance AppAppearance
        {
            get
            {
                return appAppearanceEditor1.AppAppearance;
            }
            set
            {
                appAppearanceEditor1.AppAppearance = value;
            }
        }

        #endregion

        #region ctor

        public AppearanceEditorDialog(
            IAppAppearanceRepository repository,
            IDialogService dialogService)
            : this()
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _dialogService = dialogService ?? throw new ArgumentNullException(nameof(dialogService));
        }

        internal AppearanceEditorDialog()
        {
            InitializeComponent();
        }

        #endregion

        #region protected

        protected virtual void ExceptionHandler(Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }

        protected virtual void OnColorRequest(ref Color color)
        {
            var customColors = appAppearanceEditor1.AppAppearance.CustomColors;
            color = _dialogService.DisplayColorDialog(this, color, ref customColors);
            appAppearanceEditor1.AppAppearance.CustomColors = customColors;
        }

        protected virtual void OnFontRequest(ref Font font)
        {
            font = _dialogService.DisplayFontDialog(this, font);
        }

        protected virtual async Task ReloadItemsAsync(Guid? key)
        {
            _isLoading = true;

            _items = await LoadItemsAsync();

            DisplayItems(_items);

            _isLoading = false;

            if (key == null)
                cboAppearances.SelectedIndex = 0;
            else
                cboAppearances.SelectedValue = key.Value;
        }

        protected virtual async Task<IList<ApplicationAppearance>> LoadItemsAsync()
        {
            var result = await _repository.SelectListAsync();

            if (!result.IsSuccessful())
            {
                ExceptionHandler(result.Exception);

                return null;
            }

            return result.Value;
        }

        protected virtual void DisplayItems(IList<ApplicationAppearance> items)
        {
            cboAppearances.DataSource = null;

            if (items == null)
                return;

            cboAppearances.DisplayMember = "Name";
            cboAppearances.ValueMember = "Key";
            cboAppearances.DataSource = items.OrderBy(a => a.Name).ToList();

            cboAppearances.SelectedIndex = -1;
        }

        protected virtual void DisplaySelectedItem(ApplicationAppearance item)
        {
            appAppearanceEditor1.AppAppearance = item;
        }

        protected virtual void BeginCopy()
        {
            var newAppearance = new ApplicationAppearance();

            newAppearance.Name = $"Copy of {AppAppearance.Name}";

            _isEditing = true;
            _isNew = true;

            AppAppearance = newAppearance;

            UpdateFormState();
        }

        protected virtual void BeginEdit()
        {
            _isEditing = true;
            _isNew = false;

            UpdateFormState();
        }
        protected virtual void CancelEdit()
        {
            _isEditing = false;
            _isNew = false;

            UpdateFormState();

            DisplaySelectedItem(AppAppearance);
        }
        protected virtual async Task SaveEditAsync()
        {
            appAppearanceEditor1.ApplyChanges();

            var result = await _repository.PutAsync(AppAppearance);

            if (!result.IsSuccessful())
            {
                ExceptionHandler(result.Exception);
            }

            var key = result.Value.Key;

            _isEditing = false;
            _isNew = false;

            await ReloadItemsAsync(key);
        }

        protected virtual void BeginNew()
        {
            _isEditing = true;
            _isNew = true;

            AppAppearance = new ApplicationAppearance();

            UpdateFormState();
        }
        protected virtual void CancelNew()
        {
            _isEditing = false;
            _isNew = false;

            if (HasSelection)
                AppAppearance = (ApplicationAppearance)cboAppearances.SelectedItem;

            UpdateFormState();
        }
        protected virtual async Task SaveNewAsync()
        {
            AppAppearance.Key = Guid.NewGuid();

            appAppearanceEditor1.ApplyChanges();

            var result = await _repository.PutAsync(AppAppearance);

            if (!result.IsSuccessful())
            {
                ExceptionHandler(result.Exception);
            }

            var key = result.Value.Key;

            _isEditing = false;
            _isNew = false;

            await ReloadItemsAsync(key);
        }

        protected virtual async Task<bool> ConfirmAndDeleteAsync()
        {
            var dialogResult = MessageBox.Show(this, "OK?", "Delete", MessageBoxButtons.YesNo);

            if (dialogResult != DialogResult.Yes)
            {
                return false;
            }

            var result = await _repository.DeleteAsync(AppAppearance.Key);

            if (!result.IsSuccessful())
            {
                ExceptionHandler(result.Exception);
            }

            return result.IsSuccessful();
        }

        protected virtual void UpdateFormState()
        {
            if (_isEditing)
            {
                btnEditSave.Enabled = true;
                btnEditSave.Text = "Save";

                btnNew.Enabled = false;
                btnCopy.Enabled = false;
                btnDelete.Enabled = false;

                btnSaveAndClose.Visible = false;

                btnCloseCancel.Enabled = true;
                btnCloseCancel.Text = "Cancel";

                pnlSelection.Enabled = false;
                appAppearanceEditor1.AllowEdit = true;
            }
            else
            {
                btnEditSave.Enabled = HasSelection;
                btnEditSave.Text = "Edit";

                btnNew.Enabled = HasSelection;
                btnCopy.Enabled = HasSelection;
                btnDelete.Enabled = HasSelection;

                btnSaveAndClose.Visible = true;

                btnCloseCancel.Enabled = true;
                btnCloseCancel.Text = "Close";

                pnlSelection.Enabled = true;
                appAppearanceEditor1.AllowEdit = false;
            }
        }

        #endregion

        #region private

        private async void AppearanceEditorDialog_Load(object sender, EventArgs e)
        {
            try
            {
                appAppearanceEditor1.ColorRequest += this.OnColorRequest;
                appAppearanceEditor1.FontRequest += this.OnFontRequest;
                appAppearanceEditor1.AllowEdit = false;

                await ReloadItemsAsync(null);

            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }

        private void cboAppearances_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboAppearances == null || _isLoading)
                return;

            AppAppearance = (ApplicationAppearance)cboAppearances.SelectedItem;

            DisplaySelectedItem(AppAppearance);

            UpdateFormState();
        }

        private async void btnEditSave_Click(object sender, EventArgs e)
        {
            if (_isEditing)
            {
                if (_isNew)
                    await SaveNewAsync();
                else
                    await SaveEditAsync();
            }
            else
            {
                BeginEdit();
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            BeginNew();
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            BeginCopy();
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (await ConfirmAndDeleteAsync())
            {
                await ReloadItemsAsync(null);
            }
        }

        private void btnSaveAndClose_Click(object sender, EventArgs e)
        {
            _repository.SaveChanges();

            DialogResult = DialogResult.OK;
        }

        private void btnCloseCancel_Click(object sender, EventArgs e)
        {
            if (_isEditing)
            {
                if (_isNew)
                    CancelNew();
                else
                    CancelEdit();
            }
            else
            {
                _repository.RevertChanges();

                DialogResult = DialogResult.Cancel;
            }
        }

        #endregion
    }
}
