using System;
using System.Windows.Forms;
using rNascarApp.UI.Models;

namespace rNascarApp.UI.Views
{
    public partial class View : UserControl
    {
        public event EventHandler<RemoveViewRequestEventArgs> RemoveViewRequest;
        protected virtual void OnRemoveViewRequest()
        {
            var handler = RemoveViewRequest;
            handler?.Invoke(this, new RemoveViewRequestEventArgs(Index));
        }

        public int Index { get; set; }
        public string Header { get { return label1.Text; } set { label1.Text = value; } }

        public View()
        {
            InitializeComponent();
        }

        private void label1_DoubleClick(object sender, EventArgs e)
        {
            OnRemoveViewRequest();
        }

        private void label1_MouseDown(object sender, MouseEventArgs e)
        {
            this.OnMouseDown(e);
        }
    }
}
