using System;
using System.Drawing;
using System.Linq;
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

        private ApplicationAppearance _appearance;
        public ApplicationAppearance Appearance
        {
            get
            {
                return _appearance;
            }
            set
            {
                _appearance = value;
                ApplyTheme(_appearance);
            }
        }
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

            sb.AppendLine($"Message: {txtMessage.Text}");
            sb.AppendLine();
            sb.AppendLine($"Stack Trace:\r\n{txtStackTrace.Text}");
            sb.AppendLine();
            sb.AppendLine($"{DateTime.Now.ToString()} from {Environment.MachineName}");
            sb.AppendLine();

            Clipboard.SetText(sb.ToString());
        }

        protected virtual void ApplyTheme(ApplicationAppearance appearance)
        {
            if (appearance != null)
            {
                this.BackColor = appearance.DialogAppearance.BackColor;
                this.ForeColor = appearance.DialogAppearance.ForeColor;
                this.Font = appearance.DialogAppearance.Font;


                this.dialogButtons1.Appearance = appearance;

                foreach (Button button in Controls.OfType<Button>())
                {
                    button.BackColor = appearance.DialogAppearance.ButtonAppearance.BackColor;
                    button.ForeColor = appearance.DialogAppearance.ButtonAppearance.ForeColor;
                    button.Font = appearance.DialogAppearance.ButtonAppearance.Font;
                    button.FlatStyle = appearance.DialogAppearance.ButtonAppearance.FlatStyle; ;
                    button.FlatAppearance.BorderColor = appearance.DialogAppearance.ButtonAppearance.FlatAppearance.BorderColor;
                    button.FlatAppearance.BorderSize = appearance.DialogAppearance.ButtonAppearance.FlatAppearance.BorderSize;
                    button.FlatAppearance.MouseDownBackColor = appearance.DialogAppearance.ButtonAppearance.FlatAppearance.MouseDownBackColor;
                    button.FlatAppearance.MouseOverBackColor = appearance.DialogAppearance.ButtonAppearance.FlatAppearance.MouseOverBackColor;
                }
            }
        }

        #endregion

        #region private

        private void ExceptionDialog_Load(object sender, EventArgs e)
        {
            Text = "Exception";

            this.Icon = SystemIcons.Error;

            txtMessage.Text = String.IsNullOrEmpty(Message) ? Exception.Message : $"{Message}\r\n\r\n{Exception.Message}";

            txtStackTrace.Text = Exception.StackTrace;

            ApplyTheme(Appearance);
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
