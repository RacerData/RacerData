using System;
using System.Windows.Forms;
using RacerData.WinForms.Controllers;
using RacerData.WinForms.Ports;

namespace RacerData.WinForms.Factories
{
    internal class ViewGridControllerFactory : IViewGridControllerFactory
    {
        #region fields

        private readonly IViewFactory _viewFactory;
        private readonly IViewControlFactory _viewControlFactory;
        #endregion

        #region ctor

        public ViewGridControllerFactory(
            IViewFactory viewFactory,
            IViewControlFactory viewControlFactory)
        {
            _viewFactory = viewFactory ?? throw new ArgumentNullException(nameof(viewFactory));
            _viewControlFactory = viewControlFactory ?? throw new ArgumentNullException(nameof(viewControlFactory));
        }

        #endregion

        #region public

        public IViewGridController GetViewGridController(
            IViewFactory viewFactory,
            IViewControlFactory viewControlFactory,
            Form parentForm,
            TableLayoutPanel gridTable)
        {
            return new ViewGridController(
                viewFactory,
                viewControlFactory,
                parentForm,
                gridTable);
        }

        public IViewGridController GetViewGridController(
            Form parentForm,
            TableLayoutPanel gridTable)
        {
            return new ViewGridController(
                _viewFactory,
                _viewControlFactory,
                parentForm,
                gridTable);
        }

        #endregion
    }
}
