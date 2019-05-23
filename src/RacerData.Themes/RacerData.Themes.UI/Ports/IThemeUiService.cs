using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using RacerData.Themes.Ports;

namespace RacerData.Themes.UI.Ports
{
    public interface IThemeUiService
    {
        Task ApplyThemeAsync(Control control, string themeName, bool applyToChildren);
        Task ApplyThemeAsync(Control control, Guid themeId, bool applyToChildren);
        Task ApplyThemeAsync(Control control, IThemeDefinition theme, bool applyToChildren);
        Task ClearThemeAsync(Control control, bool applyToChildren);
    }
}
