using System.Windows.Forms;
using RacerData.Themes.Ports;

namespace RacerData.Themes.UI.Ports
{
    public interface IControlThemer<T> where T : Control
    {
        void ApplyTheme<TControl>(TControl control, IThemeDefinition theme, bool applyToChildren) where TControl : Control;
        void ClearTheme<TControl>(TControl control, bool applyToChildren) where TControl : Control;
    }
}