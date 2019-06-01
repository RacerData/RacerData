using System;
using System.Drawing;
using RacerData.WinForms.Controls;
using rNascarApp.UI.Controls;
using rNascarApp.UI.Models;
using rNascarApp.UI.Ports;
using ListView = RacerData.WinForms.Controls.ListView;

namespace rNascarApp.UI.Factories
{
    internal class ViewControlFactory : IViewControlFactory
    {
        #region public

        public IViewControl GetViewControl(ViewInfo viewInfo)
        {
            IViewControl viewControl = null;

            switch (viewInfo.ViewType)
            {
                case ViewType.Graph:
                    {
                        viewControl = GetGraphView((GraphViewInfo)viewInfo);
                        break;
                    }
                case ViewType.List:
                    {
                        viewControl = GetListView((ListViewInfo)viewInfo);
                        break;
                    }
                case ViewType.Static:
                    {
                        viewControl = GetStaticView((StaticViewInfo)viewInfo);
                        break;
                    }
                case ViewType.Audio:
                    {
                        viewControl = GetAudioView((AudioViewInfo)viewInfo);
                        break;
                    }
                case ViewType.Video:
                    {
                        viewControl = GetVideoView((VideoViewInfo)viewInfo);
                        break;
                    }
                case ViewType.WeekendSchedule:
                    {
                        viewControl = GetWeekendScheduleView((WeekendScheduleViewInfo)viewInfo);
                        break;
                    }
                default:
                    throw new ArgumentException($"Unrecognized view type: {viewInfo.ViewType.ToString()}", nameof(viewInfo));
            }

            return viewControl;

        }

        #endregion

        #region protected

        protected virtual GraphView GetGraphView(GraphViewInfo viewinfo)
        {
            return new GraphView();
        }
        protected virtual VideoView GetVideoView(VideoViewInfo viewinfo)
        {
            return new VideoView();
        }
        protected virtual AudioView GetAudioView(AudioViewInfo viewinfo)
        {
            return new AudioView();
        }
        protected virtual StaticView GetStaticView(StaticViewInfo viewinfo)
        {
            return new StaticView();
        }
        protected virtual ListView GetListView(ListViewInfo viewinfo)
        {
            return new ListView();
        }
        protected virtual WeekendScheduleView GetWeekendScheduleView(WeekendScheduleViewInfo viewinfo)
        {
            var view = new WeekendScheduleView();
            view.BackColor = Color.White;
            return view;
        }

        #endregion
    }
}
