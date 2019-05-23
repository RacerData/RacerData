using System.Drawing;
using System.Windows.Forms;
using RacerData.Themes.Ports;
using RacerData.Themes.UI.Extensions;
using RacerData.Themes.UI.Ports;

namespace RacerData.Themes.UI.Internal
{
    class ButtonThemer : ControlThemer<Button>, IControlThemer<Button>
    {
        #region public

        public override void ApplyTheme<TControl>(TControl control, IThemeDefinition theme, bool applyToChildren)
        {
            control.BackColor = theme.Appearance.BackColor;
            control.ForeColor = theme.Appearance.ForeColor;
            control.Font = theme.Appearance.FontInfo.ToFont();

            var button = control as Button;

            if (button != null)
            {
                if (button.FlatStyle == FlatStyle.Flat)
                {
                    button.FlatAppearance.BorderColor = theme.Appearance.BorderColor;
                    button.FlatAppearance.BorderSize = theme.Appearance.BorderThickness;
                    button.FlatAppearance.MouseDownBackColor = theme.Appearance.SelectedBackColor;
                    button.FlatAppearance.MouseOverBackColor = theme.Appearance.BackColor2;
                    button.FlatAppearance.CheckedBackColor = theme.Appearance.SelectedBackColor;
                }
            }
        }

        #endregion
    }
}
