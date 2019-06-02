using System;
using System.Drawing;
using System.Windows.Forms;

namespace RacerData.WinForms.Controls
{
    public partial class ListViewCell : UserControl
    {
        #region ctor

        public ListViewCell()
        {
            InitializeComponent();
        }

        #endregion

        #region public

        public override string ToString()
        {
            return CellLabel.Text;
        }

        #endregion

        #region protected

        protected override void OnControlAdded(ControlEventArgs e)
        {
            base.OnControlAdded(e);
        }

        protected override void OnControlRemoved(ControlEventArgs e)
        {
            base.OnControlRemoved(e);
        }

        #endregion

        #region private

        private void ListViewCell_MouseDown(object sender, MouseEventArgs e)
        {
            this.OnMouseDown(e);
        }

        private void ListViewCell_MouseMove(object sender, MouseEventArgs e)
        {
            this.OnMouseMove(e);
        }

        private void ListViewCell_MouseLeave(object sender, EventArgs e)
        {
            this.OnMouseLeave(e);
        }

        #endregion
    }
}
