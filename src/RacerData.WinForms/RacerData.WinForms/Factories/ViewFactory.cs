using System;
using RacerData.WinForms.Controls;
using RacerData.WinForms.Models;
using RacerData.WinForms.Ports;

namespace RacerData.WinForms.Factories
{
    internal class ViewFactory : IViewFactory
    {
        #region fields

        private IViewControlFactory _viewControlFactory;

        #endregion

        #region ctor

        public ViewFactory(IViewControlFactory viewControlFactory)
        {
            _viewControlFactory = viewControlFactory ?? throw new ArgumentNullException(nameof(viewControlFactory));
        }

        #endregion

        #region public

        public View GetView(ViewInfo viewInfo)
        {
            View view = null;

            if (viewInfo is LeaderboardViewInfo)
            {
                view = BuildListView((LeaderboardViewInfo)viewInfo);
            }

            if (viewInfo is GraphViewInfo)
            {
                view = BuildGraphView((GraphViewInfo)viewInfo);
            }

            if (viewInfo is StaticViewInfo)
            {
                view = BuildStaticView((StaticViewInfo)viewInfo);
            }

            if (viewInfo is VideoViewInfo)
            {
                view = BuildVideoView((VideoViewInfo)viewInfo);
            }

            if (viewInfo is AudioViewInfo)
            {
                view = BuildAudioView((AudioViewInfo)viewInfo);
            }

            if (viewInfo is WeekendScheduleViewInfo)
            {
                view = BuildWeekendScheduleView((WeekendScheduleViewInfo)viewInfo);
            }

            return view;
        }

        #endregion

        #region protected
        protected virtual View BuildWeekendScheduleView(WeekendScheduleViewInfo viewInfo)
        {
            return new View()
            {
                Header = $"List View {viewInfo.Name} - [{viewInfo.CellPosition.ToString()}]"
            };
        }


        protected virtual View BuildListView(LeaderboardViewInfo viewInfo)
        {
            return new View()
            {
                Header = $"List View {viewInfo.Name} - [{viewInfo.CellPosition.ToString()}]"
            };
        }

        protected virtual View BuildGraphView(GraphViewInfo viewInfo)
        {
            return new View()
            {
                Header = $"List View {viewInfo.Name} - [{viewInfo.CellPosition.ToString()}]"
            };
        }

        protected virtual View BuildStaticView(StaticViewInfo viewInfo)
        {
            return new View()
            {
                Header = $"List View  {viewInfo.Name} - [{viewInfo.CellPosition.ToString()}]"
            };
        }

        protected virtual View BuildVideoView(VideoViewInfo viewInfo)
        {
            return new View()
            {
                Header = $"List View  {viewInfo.Name} - [{viewInfo.CellPosition.ToString()}]"
            };
        }

        protected virtual View BuildAudioView(AudioViewInfo viewInfo)
        {
            return new View()
            {
                Header = $"List View  {viewInfo.Name} - [{viewInfo.CellPosition.ToString()}]"
            };
        }

        #endregion
    }
}
