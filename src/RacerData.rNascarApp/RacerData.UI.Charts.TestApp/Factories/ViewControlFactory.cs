using System;
using System.Drawing;
using System.Windows.Forms;
using RacerData.WinForms.Controls;
using rNascarApp.UI.Controls;
using rNascarApp.UI.Data;
using rNascarApp.UI.Models;
using rNascarApp.UI.Ports;

namespace rNascarApp.UI.Factories
{
    internal class ViewControlFactory : IViewControlFactory
    {
        #region public

        public IViewControl<TModel> GetViewControl<TView, TModel>(ViewInfo viewInfo) where TView : IViewControl<TModel>
        {
            IViewControl<TModel> viewControl = default(TView);

            switch (viewInfo.ViewType)
            {
                case ViewType.Graph:
                    {
                        viewControl = GetGraphView<TModel>((GraphViewInfo)viewInfo);
                        break;
                    }
                case ViewType.List:
                    {
                        viewControl = GetListView<TModel>((ListViewInfo)viewInfo);
                        break;
                    }
                case ViewType.Static:
                    {
                        viewControl = GetStaticView<TModel>((StaticViewInfo)viewInfo);
                        break;
                    }
                case ViewType.Audio:
                    {
                        viewControl = GetAudioView<TModel>((AudioViewInfo)viewInfo);
                        break;
                    }
                case ViewType.Video:
                    {
                        viewControl = GetVideoView<TModel>((VideoViewInfo)viewInfo);
                        break;
                    }
                case ViewType.WeekendSchedule:
                    {
                        viewControl = GetWeekendScheduleView<TModel>((WeekendScheduleViewInfo)viewInfo);
                        break;
                    }
                default:
                    throw new ArgumentException($"Unrecognized view type: {viewInfo.ViewType.ToString()}", nameof(viewInfo));
            }

            return viewControl;
        }

        #endregion

        #region protected

        protected virtual GraphView<TModel> GetGraphView<TModel>(GraphViewInfo viewinfo)
        {
            return new GraphView<TModel>();
        }
        protected virtual VideoView<TModel> GetVideoView<TModel>(VideoViewInfo viewinfo)
        {
            return new VideoView<TModel>();
        }
        protected virtual AudioView<TModel> GetAudioView<TModel>(AudioViewInfo viewinfo)
        {
            return new AudioView<TModel>();
        }
        protected virtual StaticView<TModel> GetStaticView<TModel>(StaticViewInfo viewinfo)
        {
            return new StaticView<TModel>();
        }
        protected virtual ListView<TModel> GetListView<TModel>(ListViewInfo viewinfo)
        {
            return new ListView<TModel>();
        }
        protected virtual ScheduleView<TModel> GetWeekendScheduleView<TModel>(WeekendScheduleViewInfo viewinfo)
        {
            var view = new ScheduleView<TModel>();
            view.BackColor = Color.White;
            return view;
        }
        #endregion

    }
}
