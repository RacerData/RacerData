using System.Windows.Forms;
using rNascarApp.UI.Models;

namespace rNascarApp.UI.Ports
{
    public interface IViewControllerFactory
    {
        IViewController GetViewController(Form parentForm, Panel controlPanel, ViewType viewType);
    }
}
