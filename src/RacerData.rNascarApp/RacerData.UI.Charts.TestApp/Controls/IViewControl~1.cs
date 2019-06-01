using System;
using System.Collections.Generic;
using System.Drawing;
using RacerData.WinForms.Models;

namespace RacerData.WinForms.Controls
{
    public interface IGraphView : IViewControl
    {

    }
    public interface IStaticView : IViewControl
    {

    }
    public interface IWeekendScheduleView: IViewControl
    {

    }
    public interface IAudioView : IViewControl
    {
    }
    public interface IVideoView : IViewControl
    {

    }
    public interface IListView : IViewControl
    {

    }

    public interface IViewControl
    {
        event EventHandler<string> SetViewHeaderRequest;
    }
}