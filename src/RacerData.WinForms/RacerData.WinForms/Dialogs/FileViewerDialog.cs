using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using RacerData.WinForms.Adapters;
using RacerData.WinForms.Ports;

namespace RacerData.WinForms.Dialogs
{
    public partial class FileViewerDialog : DialogBase
    {
        #region fields

        IDialogService _service = new DialogService();

        #endregion

        #region properties

        public string Title { get; set; }
        public string FilePath { get; set; }

        #endregion

        #region ctor

        public FileViewerDialog(string title, string filePath)
            : this()
        {
            Title = title;
            FilePath = filePath;
        }

        internal FileViewerDialog()
        {
            InitializeComponent();

            DialogType = Models.ButtonTypes.Ok;
        }

        #endregion

        #region protected

        protected virtual void ExceptionHandler(Exception ex)
        {
            _service.DisplayErrorMessage(this, ex.Message);
        }

        protected virtual void ReadFile()
        {
            try
            {
                using (FileStream file = new FileStream(FilePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    using (var fileStream = new StreamReader(file))
                    {
                        txtLog.Text = fileStream.ReadToEnd();
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }

        #endregion

        #region private

        private void LogFileDialog_Load(object sender, EventArgs e)
        {
           if( Appearance!=null)
            {
                this.BackColor = Appearance.DialogAppearance.BackColor;
                this.ForeColor = Appearance.DialogAppearance.ForeColor;

                foreach (Button button in Controls.OfType<Button>())
                {
                    button.BackColor = Appearance.DialogAppearance.ButtonAppearance.BackColor;
                    button.ForeColor = Appearance.DialogAppearance.ButtonAppearance.ForeColor;
                    button.Font = Appearance.DialogAppearance.ButtonAppearance.Font;
                    button.FlatStyle = Appearance.DialogAppearance.ButtonAppearance.FlatStyle; ;
                    button.FlatAppearance.BorderColor = Appearance.DialogAppearance.ButtonAppearance.FlatAppearance.BorderColor;
                    button.FlatAppearance.BorderSize = Appearance.DialogAppearance.ButtonAppearance.FlatAppearance.BorderSize;
                    button.FlatAppearance.MouseDownBackColor = Appearance.DialogAppearance.ButtonAppearance.FlatAppearance.MouseDownBackColor;
                    button.FlatAppearance.MouseOverBackColor = Appearance.DialogAppearance.ButtonAppearance.FlatAppearance.MouseOverBackColor;
                }

                this.Font = Appearance.DialogAppearance.Font;
            }

            Text = Title;
            lblFile.Text = FilePath;
            ReadFile();
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            ReadFile();
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            txtLog.SelectAll();
            txtLog.Copy();
        }

        private void btnWrap_Click(object sender, EventArgs e)
        {
            txtLog.WordWrap = btnWrap.Checked;
        }

        #endregion
    }
}
