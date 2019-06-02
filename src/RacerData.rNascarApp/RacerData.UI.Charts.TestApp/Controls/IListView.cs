using System;
using RacerData.WinForms.Models;
using rNascarApp.UI.Models;

namespace RacerData.WinForms.Controls
{
    public interface IListView : IViewControl
    {
        event EventHandler<ControlMovedEventArgs> RowMoved;
        event EventHandler<RowResizedEventArgs> RowResized;
        event EventHandler<RowResizedEventArgs> RowResizing;

        ListDefinition ListDefinition { get; set; }
    }
}