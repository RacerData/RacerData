using System.Windows.Forms;
using rNascarApp.UI.Controllers;

namespace rNascarApp.UI.Ports
{
    public interface IViewControllerFactory
    {
        IViewController GetViewController(IViewFactory viewFactory, TableLayoutPanel gridTable);
        IViewController GetViewController(TableLayoutPanel gridTable);
    }
}