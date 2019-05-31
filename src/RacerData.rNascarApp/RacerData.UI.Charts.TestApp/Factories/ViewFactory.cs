using System;
using rNascarApp.UI.Models;
using rNascarApp.UI.Ports;
using rNascarApp.UI.Views;

namespace rNascarApp.UI.Factories
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

        internal ViewFactory()
        {
            _viewControlFactory = new ViewControlFactory();
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

            return view;
        }

        #endregion

        #region protected

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

        #endregion
    }
}
