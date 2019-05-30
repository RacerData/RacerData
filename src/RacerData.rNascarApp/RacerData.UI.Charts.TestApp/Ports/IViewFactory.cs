using rNascarApp.UI.Models;
using rNascarApp.UI.Views;

namespace rNascarApp.UI.Ports
{
    public interface IViewFactory
    {
        View GetView(ViewInfo viewInfo);
    }
}
