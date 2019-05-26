using System;
using System.Windows.Forms;

namespace RacerData.Themes.UI.Views
{
    public partial class ColorTableEditorView : Form
    {
        internal ColorTableEditorView()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            colorTableEditor1.Reset();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
