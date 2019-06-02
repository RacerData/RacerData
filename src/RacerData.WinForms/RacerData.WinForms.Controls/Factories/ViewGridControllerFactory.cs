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

        #endregion

        #region ctor

        public ViewGridControllerFactory(IViewFactory viewFactory)
        {
            _viewFactory = viewFactory ?? throw new ArgumentNullException(nameof(viewFactory));
        }

        #endregion

        #region public

        public IViewGridController GetViewGridController(
            IViewFactory viewFactory,
            Form parentForm,
            TableLayoutPanel gridTable)
        {
            return new ViewGridController(
                viewFactory,
                parentForm,
                gridTable);
        }

        public IViewGridController GetViewGridController(
            Form parentForm,
            TableLayoutPanel gridTable)
        {
            return new ViewGridController(
                _viewFactory,
                parentForm,
                gridTable);
        }

        #endregion
    }
}
