using System;
using System.Collections.Generic;
using System.Drawing;
using RacerData.WinForms.Models;

namespace RacerData.WinForms.Controls
{
    public interface IGraphView<TModel> : IViewControl<TModel>
    {

    }
    public interface IStaticView<TModel> : IViewControl<TModel>
    {

    }
    public interface IWeekendScheduleView<TModel> : IViewControl<TModel>
    {

    }
    public interface IAudioView<TModel> : IViewControl<TModel>
    {
        IList<rNascarApp.UI.Controls.AudioView<TModel>.AudioFeed> AudioFeeds { get; set; }
    }
    public interface IVideoView<TModel> : IViewControl<TModel>
    {

    }
    public interface IListView<TModel> : IViewControl<TModel>
    {

    }

    public interface IViewControl<TModel>
    {
        event EventHandler<string> SetViewHeaderRequest;

        TModel Model { get; set; }
    }
}