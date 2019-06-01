using System.Windows.Forms;
using RacerData.WinForms.Controls;
using rNascarApp.UI.Models;

namespace rNascarApp.UI.Ports
{
    public interface IViewControlFactory
    {
        IViewControl GetViewControl(ViewInfo viewInfo);
    }
}
