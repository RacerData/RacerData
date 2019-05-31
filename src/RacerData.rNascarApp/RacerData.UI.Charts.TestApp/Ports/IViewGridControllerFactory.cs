using System.Windows.Forms;

namespace rNascarApp.UI.Ports
{
    public interface IViewGridControllerFactory
    {
        IViewGridController GetViewGridController(IViewFactory viewFactory, Form parentForm, TableLayoutPanel gridTable);
        IViewGridController GetViewGridController(Form parentForm, TableLayoutPanel gridTable);
    }
}