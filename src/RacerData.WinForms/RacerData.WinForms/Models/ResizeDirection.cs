using System;

namespace RacerData.WinForms.Models
{
    [Flags()]
    public enum ResizeDirection
    {
        Vertical = 1,
        Horizontal = 2,
        Both = Vertical | Horizontal
    }
}
