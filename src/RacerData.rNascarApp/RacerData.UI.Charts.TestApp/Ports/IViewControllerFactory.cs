using System.Windows.Forms;

namespace rNascarApp.UI.Ports
{
    public interface IViewControllerFactory
    {
        IViewController GetViewController(IViewFactory viewFactory, Form parentForm, TableLayoutPanel gridTable);
        IViewController GetViewController(Form parentForm, TableLayoutPanel gridTable);
    }
}