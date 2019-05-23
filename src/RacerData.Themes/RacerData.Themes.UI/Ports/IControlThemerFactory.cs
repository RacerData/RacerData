using System.Windows.Forms;
using RacerData.Themes.UI.Internal;

namespace RacerData.Themes.UI.Ports
{
    public interface IControlThemerFactory
    {
        ControlThemer GetControlThemer(Control control);
    }
}