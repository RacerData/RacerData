using System.Windows.Forms;
using RacerData.Themes.UI.Internal;
using RacerData.Themes.UI.Ports;

namespace RacerData.Themes.UI.Factories
{
    class ControlThemerFactory : IControlThemerFactory
    {
        public ControlThemer GetControlThemer(Control control)
        {
            // TODO: MenuItems, ToolStripItems, StatusStripItems, etc.

            // TODO: Implement custom rendering

            if (control is Button)
            {
                return new ButtonThemer(this);
            }
            else if (control is Label)
            {
                return new LabelThemer(this);
            }
            else if (control is TextBox || control is ComboBox || control is ListBox || control is NumericUpDown)
            {
                return new TextBoxThemer(this);
            }
            else if (control is Panel || control is FlowLayoutPanel || control is TableLayoutPanel)
            {
                return new PanelThemer(this);
            }
            else if (control is MenuStrip)
            {
                return new MenuStripThemer(this);
            }
            else if (control is ToolStrip)
            {
                return new ToolStripThemer(this);
            }
            else if (control is StatusStrip)
            {
                return new StatusStripThemer(this);
            }
            else if (control is Form)
            {
                return new FormThemer(this);
            }
            else
            {
                return new DefaultThemer(this);
            }
        }
    }
}
