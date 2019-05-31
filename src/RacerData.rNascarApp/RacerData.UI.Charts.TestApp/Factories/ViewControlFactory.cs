using System.Windows.Forms;
using rNascarApp.UI.Controls;
using rNascarApp.UI.Models;
using rNascarApp.UI.Ports;

namespace rNascarApp.UI.Factories
{
    class ViewControlFactory : IViewControlFactory
    {
        public Control GetViewControl(ViewType viewType)
        {
            switch (viewType)
            {
                case ViewType.Graph:
                    return new GraphView();
                case ViewType.List:
                    return new ListView();
                case ViewType.Static:
                    return new StaticView();
                default:
                    return new Panel();
            }
            
        }
    }
   
}
