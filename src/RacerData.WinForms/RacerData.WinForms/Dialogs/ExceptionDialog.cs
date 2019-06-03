using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RacerData.WinForms.Models;
using RacerData.WinForms.Ports;

namespace RacerData.WinForms.Dialogs
{
    public partial class ExceptionDialog : Form
    {
        #region fields

        private IDialogService _dialogService;

        #endregion

        #region properties

        public string Message { get; set; }
        public Exception Exception { get; set; }

        #endregion

        #region ctor
        public ExceptionDialog(IDialogService dialogService, Exception ex)
           : this(dialogService, String.Empty, ex)
        {
        }

        public ExceptionDialog(IDialogService dialogService, string message, Exception ex)
            : this(dialogService, message, ButtonTypes.Ok, ex)
        {

        }
        public ExceptionDialog(IDialogService dialogService, string message, ButtonTypes buttonTypes, Exception ex)
            : this()
        {
            _dialogService = dialogService ?? throw new ArgumentNullException(nameof(dialogService));
            Message = message;
            Exception = ex;
            dialogButtons1.ButtonTypes = buttonTypes;
        }

        internal ExceptionDialog()
        {
            InitializeComponent();

            dialogButtons1.ButtonTypes = ButtonTypes.Ok;
        }

        #endregion

        #region protected

        protected virtual void CopyToClipboard()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Message: {lblMessage.Text}");
            sb.AppendLine();
            sb.AppendLine($"Stack Trace:\r\n{txtStackTrace.Text}");
            sb.AppendLine();
            sb.AppendLine($"{DateTime.Now.ToString()} from {Environment.MachineName}");
            sb.AppendLine();

            Clipboard.SetText(sb.ToString());
        }

        #endregion

        #region private

        private void ExceptionDialog_Load(object sender, EventArgs e)
        {
            Text = "Exception";

            this.Icon = SystemIcons.Error;

            pictureBox1.Image = Bitmap.FromHicon(this.Icon.Handle);

            lblMessage.Text = String.IsNullOrEmpty(Message) ? Exception.Message : $"{Message}\r\n\r\n{Exception.Message}";

            txtStackTrace.Text = Exception.StackTrace;
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            _dialogService.DisplayMessageBox(
                this,
                "Exception Copied",
                "Exception details copied to clipboard",
                ButtonTypes.Ok,
                MsgIcon.Information);
        }

        private void dialogButtons1_DialogResultClicked(object sender, Events.DialogResultEventArgs e)
        {
            this.DialogResult = e.Result;
        }

        #endregion
    }
}
