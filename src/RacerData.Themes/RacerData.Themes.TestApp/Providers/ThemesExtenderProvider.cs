using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Drawing.Design;
using System.Windows.Forms;
using RacerData.Themes.Models;
using RacerData.Themes.Ports;
using RacerData.Themes.TestApp.Extensions;

namespace RacerData.Themes.TestApp.Providers
{
    [ProvideProperty("Themes", typeof(Control))]
    [DesignerSerializer(typeof(ThemesSerializer<Themes>), typeof(CodeDomSerializer))]
    class ThemesExtenderProvider : Component, IExtenderProvider
    {
        #region fields

        Dictionary<Control, string[]> constants;
        private Hashtable _themeNames;
        private IDictionary<string, IThemeDefinition> _themeList;

        #endregion

        #region ctor

        public ThemesExtenderProvider()
        {
            this.constants = new Dictionary<Control, string[]>();

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
        [Editor(typeof(ThemesEditor<Themes>), typeof(UITypeEditor))]
        public string[] GetThemes(Control control)
        {
            string[] constantsForControl;

            if (this.constants.TryGetValue(control, out constantsForControl))
            {
                return constantsForControl;
            }
            else
            {
                return null;
            }
        }

        public void SetThemes(Control control, string[] constantsForControl)
        {
            this.constants[control] = constantsForControl;

            if (constantsForControl.Length == 0)
            {
                _themeNames.Remove(control);
            }
            else
            {
                string value = constantsForControl[0];

                if (_themeList.ContainsKey(value))
                {
                    _themeNames[control] = value;

                    IThemeDefinition theme = _themeList[value];

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