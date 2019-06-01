using RacerData.WinForms.Controls;
using rNascarApp.UI.Controllers;
using rNascarApp.UI.Ports;

namespace rNascarApp.UI.Factories
{
    internal class ViewControllerFactory : IViewControllerFactory
    {
        public IViewController GetViewController<IViewControl, TModel>(IViewControl<TModel> viewControl, TModel model)
        {
            return new ViewController<IViewControl<TModel>, TModel>(viewControl, model);
        }
    }
}
