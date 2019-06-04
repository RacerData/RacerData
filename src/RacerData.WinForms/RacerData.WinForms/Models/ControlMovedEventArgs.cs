using System;

namespace RacerData.WinForms.Models
{
    public class ControlMovedEventArgs : EventArgs
    {
        public int OldIndex { get; set; }
        public int NewIndex { get; set; }
    }
}
