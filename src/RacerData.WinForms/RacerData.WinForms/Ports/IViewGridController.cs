using System;
using System.Collections.Generic;
using RacerData.WinForms.Models;

namespace RacerData.WinForms.Ports
{
    public interface IViewGridController
    {
        event EventHandler<ViewAddedEventArgs> ViewAdded;
        event EventHandler<ViewRemovedEventArgs> ViewRemoved;

        ApplicationAppearance Appearance { get; set; }
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
    }
}