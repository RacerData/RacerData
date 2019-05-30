using System;
using System.Windows.Forms;
using rNascarApp.UI.Controllers;
using rNascarApp.UI.Ports;

namespace rNascarApp.UI.Factories
{
    internal class ViewControllerFactory : IViewControllerFactory
    {
        #region fields

        private readonly IViewFactory _viewFactory;

        #endregion

        #region ctor

        public ViewControllerFactory(IViewFactory viewFactory)
        {
            _viewFactory = viewFactory ?? throw new ArgumentNullException(nameof(viewFactory));
        }

        #endregion

        #region public

        public IViewController GetViewController(IViewFactory viewFactory, TableLayoutPanel gridTable)
        {
            return new ViewController(
                viewFactory,
                gridTable);
        }

        public IViewController GetViewController(TableLayoutPanel gridTable)
        {
            return new ViewController(
                _viewFactory,
                gridTable);
        }

        #endregion
    }
}
