using System.Windows.Forms;

namespace RacerData.WinForms.Ports
{
    public interface IViewGridControllerFactory
    {
        IViewGridController GetViewGridController(
            IViewFactory viewFactory,
            IViewControlFactory viewControlFactory,
            Form parentForm,
            TableLayoutPanel gridTable);

        IViewGridController GetViewGridController(
            Form parentForm,
            TableLayoutPanel gridTable);
    }
}