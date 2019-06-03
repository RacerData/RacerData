using System;
using System.Drawing;
using System.Windows.Forms;
using RacerData.WinForms.Controls;
using RacerData.WinForms.Controls.AudioView;
using RacerData.WinForms.Controls.Models.AudioView;
using RacerData.WinForms.Controls.Models.WeekendScheduleView;
using RacerData.WinForms.Controls.Ports;
using RacerData.WinForms.Models;
using RacerData.WinForms.Ports;
using ListView = RacerData.WinForms.Controls.ListView;

namespace RacerData.WinForms.Factories
{
    internal class ViewControlFactory : IViewControlFactory
    {
        #region fields

        private readonly IAudioChannelService _channelService;
        private readonly ISeriesService _seriesService;
        private readonly IWeekendScheduleService _weekendScheduleService;

        #endregion

        #region ctor

        public ViewControlFactory(
            IAudioChannelService channelService,
            ISeriesService seriesService,
            IWeekendScheduleService weekendScheduleService)
        {
            _channelService = channelService ?? throw new ArgumentNullException(nameof(channelService));
            _seriesService = seriesService ?? throw new ArgumentNullException(nameof(seriesService));
            _weekendScheduleService = weekendScheduleService ?? throw new ArgumentNullException(nameof(weekendScheduleService));
        }

        #endregion

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

            ((Control)viewControl).Dock = DockStyle.Fill;

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
            var viewModel = new AudioViewModel(_channelService, _seriesService);
            return new AudioView(viewModel);
        }
        protected virtual StaticView GetStaticView(StaticViewInfo viewinfo)
        {
            var view = new StaticView();
            view.Fields = viewinfo.Fields;
            return view;
        }
        protected virtual ListView GetListView(ListViewInfo viewinfo)
        {
            var view = new ListView();
            view.ListDefinition = viewinfo.ListDefinition;
            return view;
        }
        protected virtual WeekendScheduleView GetWeekendScheduleView(WeekendScheduleViewInfo viewinfo)
        {
            var viewModel = new WeekendScheduleViewModel(_weekendScheduleService);
            return new WeekendScheduleView(viewModel);
        }

        #endregion
    }
}
