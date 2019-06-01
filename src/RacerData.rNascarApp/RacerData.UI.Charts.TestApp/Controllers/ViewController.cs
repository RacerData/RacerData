using System;
using RacerData.WinForms.Controls;
using rNascarApp.UI.Ports;

namespace rNascarApp.UI.Controllers
{
    class ViewController<TView, TModel> : IViewController where TView : IViewControl<TModel>
    {
        #region fields

        private readonly IViewControl<TModel> _viewControl;

        #endregion

        #region public
        public TView ViewControl { get; set; }
        public TModel Model { get; set; }

        #endregion

        #region ctor

        public ViewController(
            IViewControl<TModel> viewControl,
            TModel model)
        {
            _viewControl = viewControl ?? throw new ArgumentNullException(nameof(viewControl));
        }

        #endregion
    }
}
