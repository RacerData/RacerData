using System;
using System.Drawing;

namespace RacerData.WinForms.Models
{
    public class ControlResizedEventArgs : EventArgs
    {
        public Rectangle[] NewPositions { get; set; }
    }
}