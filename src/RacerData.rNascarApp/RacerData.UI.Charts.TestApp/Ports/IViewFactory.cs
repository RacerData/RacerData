using rNascarApp.UI.Models;
using rNascarApp.UI.Views;

namespace rNascarApp.UI.Ports
{
    public interface IViewFactory
    {
        ViewBase GetView(ViewInfo viewInfo);
    }
}
