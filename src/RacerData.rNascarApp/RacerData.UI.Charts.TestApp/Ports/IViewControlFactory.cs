using System.Windows.Forms;
using RacerData.WinForms.Controls;
using rNascarApp.UI.Models;

namespace rNascarApp.UI.Ports
{
    public interface IViewControlFactory
    {
        IViewControl<TModel> GetViewControl<TView, TModel>(ViewInfo viewInfo) where TView : IViewControl<TModel>;
    }
}
