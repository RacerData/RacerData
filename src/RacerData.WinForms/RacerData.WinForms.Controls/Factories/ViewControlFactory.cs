using System;
using System.Windows.Forms;
using RacerData.WinForms.Controls;
using RacerData.WinForms.Controls.AudioView;
using RacerData.WinForms.Controls.VideoView;
using RacerData.WinForms.Controls.Models.VideoView;
using RacerData.WinForms.Controls.Models.AudioView;
using RacerData.WinForms.Controls.Models.WeekendScheduleView;
using RacerData.WinForms.Controls.Ports;
using RacerData.WinForms.Models;
using RacerData.WinForms.Ports;
using ListView = RacerData.WinForms.Controls.ListView;
using RacerData.WinForms.Controls.StaticView;
using RacerData.WinForms.Controls.Models.GraphView;

namespace RacerData.WinForms.Factories
{
    internal class ViewControlFactory : IViewControlFactory
    {
        #region fields

        private readonly IVideoChannelService _videoChannelService;
        private readonly IAudioChannelService _audioChannelService;
        private readonly ISeriesService _seriesService;
        private readonly IWeekendScheduleService _weekendScheduleService;
        private readonly IStaticDataService _staticDataService;
        private readonly IGraphDataService _graphDataService;

        #endregion

        #region ctor

        public ViewControlFactory(
            IVideoChannelService videoChannelService,
            IAudioChannelService audioChannelService,
            ISeriesService seriesService,
            IWeekendScheduleService weekendScheduleService,
            IStaticDataService staticDataService,
            IGraphDataService graphDataService)
        {
            _videoChannelService = videoChannelService ?? throw new ArgumentNullException(nameof(videoChannelService));
            _audioChannelService = audioChannelService ?? throw new ArgumentNullException(nameof(audioChannelService));
            _seriesService = seriesService ?? throw new ArgumentNullException(nameof(seriesService));
            _weekendScheduleService = weekendScheduleService ?? throw new ArgumentNullException(nameof(weekendScheduleService));
            _staticDataService = staticDataService ?? throw new ArgumentNullException(nameof(staticDataService));
            _graphDataService = graphDataService ?? throw new ArgumentNullException(nameof(graphDataService));
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
            var viewModel = new GraphViewModel(viewinfo, _graphDataService);
            return new GraphView(viewModel);
        }
        protected virtual VideoView GetVideoView(VideoViewInfo viewinfo)
        {
            var viewModel = new VideoViewModel(_videoChannelService);
            return new VideoView(viewModel);
        }
        protected virtual AudioView GetAudioView(AudioViewInfo viewinfo)
        {
            var viewModel = new AudioViewModel(_audioChannelService, _seriesService);
            return new AudioView(viewModel);
        }
        protected virtual StaticView GetStaticView(StaticViewInfo viewinfo)
        {
            var viewModel = new StaticViewModel(viewinfo, _staticDataService);
           return new StaticView(viewModel);
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
