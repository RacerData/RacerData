using System;
using RacerData.WinForms.Models;

namespace RacerData.WinForms.Controls
{
    public interface ILeaderboardView : IViewControl
    {
        event EventHandler<ControlMovedEventArgs> RowMoved;
        event EventHandler<RowResizedEventArgs> RowResized;
        event EventHandler<RowResizedEventArgs> RowResizing;
    }
}