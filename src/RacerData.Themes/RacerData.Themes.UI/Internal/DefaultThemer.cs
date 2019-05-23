using System.Windows.Forms;
using RacerData.Themes.Ports;
using RacerData.Themes.UI.Extensions;

namespace RacerData.Themes.UI.Internal
{
    class DefaultThemer : ControlThemer<Control>
    {
        #region public

        public override void ApplyTheme<TControl>(TControl control, IThemeDefinition theme, bool applyToChildren)
        {
            try
            {
                control.ForeColor = theme.Appearance.ForeColor;
            }
            catch (System.Exception ex)
            {
            }
            control.BackColor = theme.Appearance.BackColor;
            control.Font = theme.Appearance.FontInfo.ToFont();
        }

        #endregion
    }
}
