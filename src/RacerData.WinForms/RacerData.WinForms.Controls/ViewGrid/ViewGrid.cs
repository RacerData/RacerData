﻿using System.Windows.Forms;

namespace RacerData.WinForms.Controls
{
    public partial class ViewGrid : UserControl
    {
        public TableLayoutPanel Grid
        {
            get
            {
                return this.tblGrid;
            }
            set
            {
                this.tblGrid = value;
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