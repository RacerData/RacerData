using System;
using System.Collections.Generic;
using rNascarApp.UI.Models;

namespace rNascarApp.UI.Ports
{
    public interface IViewController
    {
        event EventHandler<ViewAddedEventArgs> ViewAdded;
        event EventHandler<ViewRemovedEventArgs> ViewRemoved;

        int MaxColumns { get; set; }
        int MaxRows { get; set; }

        void AddColumn();
        void AddRow();
        void AddRowColumn();

        void RemoveColumn();
        void RemoveRow();
        void RemoveRowColumn();

        void DecreaseCellSize();
        void IncreaseCellSize();

        void AddView(ViewInfo viewInfo);
        void AddViews(IList<ViewInfo> viewInfos);

        void RemoveViewAt(int index);

        void ParentResized();
    }
}