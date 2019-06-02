using RacerData.WinForms.Models;
using RacerData.WinForms.Views;

namespace RacerData.WinForms.Ports
{
    public interface IViewFactory
    {
        ViewBase GetView(ViewInfo viewInfo);
    }
}
