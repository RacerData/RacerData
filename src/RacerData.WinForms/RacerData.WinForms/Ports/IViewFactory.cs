using RacerData.WinForms.Controls;
using RacerData.WinForms.Models;

namespace RacerData.WinForms.Ports
{
    public interface IViewFactory
    {
        ViewBase GetView(ViewInfo viewInfo);
    }
}
