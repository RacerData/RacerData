using System;
using System.Collections.Generic;
using System.Drawing;

namespace RacerData.WinForms.Models
{
    public class RowResizedEventArgs : EventArgs
    {
        public int RowIndex { get; set; }
        public Size Size { get; set; }
    }
}