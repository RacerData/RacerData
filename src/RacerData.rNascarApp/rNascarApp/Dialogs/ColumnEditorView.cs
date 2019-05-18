using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using log4net;
using Newtonsoft.Json;
using RacerData.rNascarApp.Models;
using RacerData.rNascarApp.Themes;

namespace RacerData.rNascarApp.Dialogs
{
    public partial class ColumnEditorView : Form
    {
        #region fields

        private string _originalViewState = String.Empty;

        #endregion

        #region properties

        public bool ShowViewSettings { get; set; } = false;
        public ILog Log { get; set; }
        public IList<Theme> Themes { get; set; }
        public ViewState ViewState { get; set; } = null;

        #endregion

        #region ctor

        public ColumnEditorView()
        {
            InitializeComponent();
        }

        #endregion

        #region protected

        protected virtual void ExceptionHandler(string message, Exception ex)
        {
            Log?.Error(message, ex);

            MessageBox.Show(this, ex.Message, message, MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        #endregion

        #region private

        private void ListColumnEditor1_Load(object sender, EventArgs e)
        {
            try
            {
                _originalViewState = SerializeItem(ViewState);

                listColumnEditor1.ViewState = this.ViewState;
                listColumnEditor1.Themes = this.Themes;
                listColumnEditor1.ShowViewSettings = this.ShowViewSettings;

                listColumnEditor1.PropertyChanged += ListColumnEditor1_PropertyChanged;
            }
            catch (Exception ex)
            {
                ExceptionHandler("Error editing view columns", ex);
            }
        }

        private void ListColumnEditor1_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(listColumnEditor1.IsEditing))
            {
                pnlDialogButtons.Enabled = !listColumnEditor1.IsEditing;
                btnSave.Enabled = (!listColumnEditor1.IsEditing && listColumnEditor1.HasChanges);
            }
            else if (e.PropertyName == nameof(listColumnEditor1.HasChanges))
            {
                btnSave.Enabled = (pnlDialogButtons.Enabled && listColumnEditor1.HasChanges);
                Console.WriteLine($"Save Enabled: {btnSave.Enabled}");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ViewState = DeserializeItem(_originalViewState);
            DialogResult = DialogResult.Cancel;
        }

        #endregion
    }
}
