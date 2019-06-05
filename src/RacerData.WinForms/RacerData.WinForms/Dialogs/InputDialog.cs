using System;
using System.Windows.Forms;
using RacerData.WinForms.Ports;

namespace RacerData.WinForms.Dialogs
{
    public partial class InputDialog : DialogBase, IRacerDataInputDialog
    {
        #region fields

        public string Title { get; set; }
        public string Prompt { get; set; }
        public string Value { get; set; }

        #endregion

        #region ctor

        public InputDialog(string title, string prompt, string defaultResponse = "")
           : this()
        {
            Title = title;
            Prompt = prompt;
            Value = defaultResponse;
        }

        internal InputDialog()
        {
            DialogType = Models.ButtonTypes.OkCancel;

            InitializeComponent();
        }

        #endregion

        #region private

        private void InputDialog_Load(object sender, EventArgs e)
        {
            base.
            Text = Title;
            lblPrompt.Text = Prompt;
            txtResponse.Text = Value;

            txtResponse.Focus();
            txtResponse.SelectAll();
        }

        private void txtResponse_TextChanged(object sender, EventArgs e)
        {
            Value = txtResponse.Text;
        }

        private void InputDialog_Activated(object sender, EventArgs e)
        {
            txtResponse.Focus();
            txtResponse.SelectAll();
        }

        private void txtResponse_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DialogResult = DialogResult.OK;
            }
        }

        #endregion
    }
}
