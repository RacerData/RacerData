using rNascarApp.UI.Models;
using rNascarApp.UI.Ports;
using rNascarApp.UI.Views;

namespace rNascarApp.UI.Factories
{
    internal class ViewFactory : IViewFactory
    {
        #region public

        public View GetView(ViewInfo viewInfo)
        {
            View viewControl = null;

            if (viewInfo is ListViewInfo)
            {
                viewControl = BuildListView((ListViewInfo)viewInfo);
            }

            if (viewInfo is GraphViewInfo)
            {
                viewControl = BuildGraphView((GraphViewInfo)viewInfo);
            }

            if (viewInfo is StaticViewInfo)
            {
                viewControl = BuildStaticView((StaticViewInfo)viewInfo);
            }

            return viewControl;
        }

        #endregion

        #region protected

        protected virtual View BuildListView(ListViewInfo viewInfo)
        {
            return new ListView()
            {
                Header = $"List View {viewInfo.Name} - [{viewInfo.CellPosition.ToString()}]"
            };
        }

        protected virtual View BuildGraphView(GraphViewInfo viewInfo)
        {
            return new GraphView()
            {
                Header = $"List View {viewInfo.Name} - [{viewInfo.CellPosition.ToString()}]"
            };
        }

        protected virtual View BuildStaticView(StaticViewInfo viewInfo)
        {
            return new StaticView()
            {
                Header = $"List View  {viewInfo.Name} - [{viewInfo.CellPosition.ToString()}]"
            };
        }

        #endregion
    }
}
