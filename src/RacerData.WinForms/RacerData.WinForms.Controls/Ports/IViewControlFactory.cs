using RacerData.WinForms.Controls;
using RacerData.WinForms.Models;

namespace RacerData.WinForms.Ports
{
    public interface IViewControlFactory
    {
        IViewControl GetViewControl(ViewInfo viewInfo);
    }
}
