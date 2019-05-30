using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace rNascarApp.UI.Controls
{
    public partial class ViewGrid : UserControl
    {
        public TableLayoutPanel Grid
        {
            get
            {
                return this.GridTable;
            }
            set
            {
                this.GridTable = value;
            }
        }

        public ViewGrid()
        {
            InitializeComponent();
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;  // Turn on WS_EX_COMPOSITED
                return cp;
            }
        }

    }
}
