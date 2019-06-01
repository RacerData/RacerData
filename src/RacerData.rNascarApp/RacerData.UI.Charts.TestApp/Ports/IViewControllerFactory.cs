using RacerData.WinForms.Controls;

namespace rNascarApp.UI.Ports
{
    public interface IViewControllerFactory
    {
        IViewController GetViewController<IViewControl, TModel>(IViewControl<TModel> viewControl, TModel model);
    }
}
