using System;
using RacerData.WinForms.Controls.Models.AudioView;
using RacerData.WinForms.Models;
using RacerData.WinForms.Ports;
using RacerData.WinForms.Views;

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

        public ViewBase GetView(ViewInfo viewInfo)
        {
            ViewBase view = null;

            if (viewInfo is ListViewInfo)
            {
                view = BuildListView((ListViewInfo)viewInfo);
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
        protected virtual ViewBase BuildWeekendScheduleView(WeekendScheduleViewInfo viewInfo)
        {
            return new ViewBase()
            {
                Header = $"List View {viewInfo.Name} - [{viewInfo.CellPosition.ToString()}]"
            };
        }


        protected virtual ViewBase BuildListView(ListViewInfo viewInfo)
        {
            return new ViewBase()
            {
                Header = $"List View {viewInfo.Name} - [{viewInfo.CellPosition.ToString()}]"
            };
        }

        protected virtual ViewBase BuildGraphView(GraphViewInfo viewInfo)
        {
            return new ViewBase()
            {
                Header = $"List View {viewInfo.Name} - [{viewInfo.CellPosition.ToString()}]"
            };
        }

        protected virtual ViewBase BuildStaticView(StaticViewInfo viewInfo)
        {
            return new ViewBase()
            {
                Header = $"List View  {viewInfo.Name} - [{viewInfo.CellPosition.ToString()}]"
            };
        }

        protected virtual ViewBase BuildVideoView(VideoViewInfo viewInfo)
        {
            return new ViewBase()
            {
                Header = $"List View  {viewInfo.Name} - [{viewInfo.CellPosition.ToString()}]"
            };
        }

        protected virtual ViewBase BuildAudioView(AudioViewInfo viewInfo)
        {
            return new ViewBase()
            {
                Header = $"List View  {viewInfo.Name} - [{viewInfo.CellPosition.ToString()}]"
            };
        }

        #endregion
    }
}
