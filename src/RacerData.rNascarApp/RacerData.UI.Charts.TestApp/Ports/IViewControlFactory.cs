using System.Windows.Forms;
using rNascarApp.UI.Models;

namespace rNascarApp.UI.Ports
{
    public interface IViewControlFactory
    {
        Control GetViewControl(ViewType viewType);
    }
}
