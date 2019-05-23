﻿using System.Windows.Forms;
using RacerData.Themes.Ports;
using RacerData.Themes.UI.Extensions;

namespace RacerData.Themes.UI.Internal
{
    class ListBoxThemer : ControlThemer<ListBox>
    {
        #region public

        public override void ApplyTheme<TControl>(TControl control, IThemeDefinition theme, bool applyToChildren)
        {
            base.ApplyTheme(control, theme, applyToChildren);

            control.BackColor = theme.Appearance.BackColor;
            control.ForeColor = theme.Appearance.ForeColor;
            control.Font = theme.Appearance.FontInfo.ToFont();
        }

        #endregion
    }
}

