using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RacerData.WinForms.Controls
{
    public partial class ListViewCell : UserControl
    {
        public ListViewCell()
        {
            InitializeComponent();
        }

        protected override void OnControlAdded(ControlEventArgs e)
        {
            base.OnControlAdded(e);

            //var pictureBox = e.Control as PictureBox;

            //if (pictureBox == null)
            //{
            //    e.Control.MouseDown += ListViewCell_MouseDown;
            //    e.Control.MouseMove += ListViewCell_MouseMove;
            //    e.Control.MouseLeave += ListViewCell_MouseLeave;
            //}
        }

        protected override void OnControlRemoved(ControlEventArgs e)
        {
            //var pictureBox = e.Control as PictureBox;

            //if (pictureBox == null)
            //{
            //    e.Control.MouseDown -= ListViewCell_MouseDown;
            //    e.Control.MouseMove -= ListViewCell_MouseMove;
            //    e.Control.MouseLeave -= ListViewCell_MouseLeave;
            //}

            base.OnControlRemoved(e);
        }

        public override string ToString()
        {
            return CellLabel.Text;
        }

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
    }
}
