using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Drawing.Design;
using System.Windows.Forms;
using RacerData.Themes.Models;
using RacerData.Themes.Ports;
using RacerData.Themes.UI.Extensions;

namespace RacerData.Themes.UI.Providers
{
    [Category("Appearance")]
    [DisplayName("Theme")]
    [ProvideProperty("ThemeName", typeof(Control))]
    [DesignerSerializer(typeof(ThemeNameSerializer<ThemeNames>), typeof(CodeDomSerializer))]
    class ThemeNameExtenderProvider : Component, IExtenderProvider
    {
        #region fields

        Dictionary<Control, string> constants;
        private Hashtable _themeNames;
        private IDictionary<string, IThemeDefinition> _themeList;

        #endregion

        #region ctor

        public ThemeNameExtenderProvider()
        {
            this.constants = new Dictionary<Control, string>();

            _themeNames = new Hashtable();

            _themeList = new Dictionary<string, IThemeDefinition>
            {
                { StandardThemes.SystemTheme.Name, StandardThemes.SystemTheme },
                { StandardThemes.BlackTheme.Name, StandardThemes.BlackTheme },
                { StandardThemes.BlueTheme.Name, StandardThemes.BlueTheme }
            };
        }

        #endregion

        #region IExtenderProvider Members

        public bool CanExtend(object extendee)
        {
            return extendee is Control;
        }

        #endregion

        #region Constants Get and Set

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Editor(typeof(ThemeNameEditor), typeof(UITypeEditor))]
        public string GetThemeName(Control control)
        {
            string constantsForControl = String.Empty;

            if (this.constants.TryGetValue(control, out constantsForControl))
            {
                return constantsForControl;
            }
            else
            {
                return String.Empty;
            }
        }

        public void SetThemeName(Control control, string constantsForControl)
        {
            if (String.IsNullOrEmpty(constantsForControl))
            {
                this.constants.Remove(control);

                _themeNames.Remove(control);
            }
            else
            {
                if (_themeList.ContainsKey(constantsForControl))
                {
                    _themeNames[control] = constantsForControl;

                    this.constants[control] = constantsForControl;

                    IThemeDefinition theme = _themeList[constantsForControl];

                    if (theme != null)
                    {
                        ApplyTheme(control, theme);
                    }
                }
            }
        }

        #endregion

        #region protected

        private void ApplyTheme(Control control, IThemeDefinition theme)
        {
            control.ForeColor = theme.Appearance.ForeColor;
            control.BackColor = theme.Appearance.BackColor;

            control.Font = theme.Appearance.FontInfo.ToFont();

            var button = control is Button ? (Button)control : null;

            if (button != null && button.FlatStyle == FlatStyle.Flat)
            {
                button.FlatAppearance.BorderColor = theme.Appearance.BorderColor;
                button.FlatAppearance.BorderSize = theme.Appearance.BorderThickness;
                button.FlatAppearance.MouseDownBackColor = theme.Appearance.SelectedBackColor;
                button.FlatAppearance.MouseOverBackColor = theme.Appearance.MouseOverBackColor;
                button.FlatAppearance.CheckedBackColor = theme.Appearance.SelectedBackColor;
            }

            control.Invalidate();
        }

        #endregion
    }
}