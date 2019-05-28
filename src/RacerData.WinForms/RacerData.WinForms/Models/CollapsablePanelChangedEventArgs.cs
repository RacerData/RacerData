using System;

namespace RacerData.WinForms.Models
{
    public class CollapsablePanelChangedEventArgs : EventArgs
    {
        public int NewHeight { get; set; }
        public int OldHeight { get; set; }
    }
}
