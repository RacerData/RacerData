using System;
using System.Linq;
using System.Windows.Forms;

namespace RacerData.WinForms.Controls
{
    public partial class LeaderboardViewCell : UserControl
    {
        #region consts

        private const int VerticalResizeHitRange = 8;

        #endregion

        #region fields

        private LeaderboardViewRow _parentRow;
        protected LeaderboardViewRow ParentRow
        {
            get
            {
                if (_parentRow == null)
                    _parentRow = (LeaderboardViewRow)this.Parent;

                return _parentRow;
            }
        }

        #endregion

        #region ctor

        public LeaderboardViewCell()
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

        protected virtual void CellLabel_TextChanged(object sender, EventArgs e)
        {
            base.OnTextChanged(e);
        }

        #endregion

        #region private

        private void ListViewCell_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Y > (this.Height - VerticalResizeHitRange) && e.Y < this.Height)
            {
                this.Cursor = Cursors.SizeNS;
                ParentRow.ResizeHandle.BringToFront();
                ParentRow.ResizeHandle.Focus();
            }
            else
                this.OnMouseDown(e);
        }

        private void ListViewCell_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Y > (this.Height - VerticalResizeHitRange) && e.Y < this.Height)
            {
                Cursor = Cursors.SizeNS;
                ParentRow.ResizeHandle.BringToFront();
                ParentRow.ResizeHandle.Focus();

                this.OnMouseMove(e);
            }
            else
            {
                if (!ParentRow.IsResizing)
                    Cursor = Cursors.Default;

                this.OnMouseMove(e);
            }
        }

        #endregion
    }
}
