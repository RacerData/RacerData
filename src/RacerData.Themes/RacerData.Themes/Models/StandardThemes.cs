using System;
using RacerData.Themes.Ports;

namespace RacerData.Themes.Models
{
    public class StandardThemes
    {
        #region consts

        private const string SystemThemeName = "System";
        private const string BlueThemeName = "Blue";
        private const string BlackThemeName = "Black";

        #endregion

        #region fields

        private static Guid _systemThemeKey = Guid.Parse("{E72BC9D9-A6E2-43A4-8685-E6C09245BD7A}");
        private static Guid _blackThemeKey = Guid.Parse("{9F287EAE-6C71-48CE-8D9A-6BE5932A349A}");
        private static Guid _blueThemeKey = Guid.Parse("{9F287EAE-6C71-48CE-8D9A-6BE5932A349A}");

        #endregion

        #region properties

        public static IThemeDefinition SystemTheme { get; private set; }
        public static IThemeDefinition BlackTheme { get; private set; }
        public static IThemeDefinition BlueTheme { get; private set; }

        #endregion

        #region ctor

        static StandardThemes()
        {
            SystemTheme = new ThemeDefinition()
            {
                Key = _systemThemeKey,
                Name = SystemThemeName,
                Appearance = StandardAppearances.SystemAppearance,
                IsReadOnly = true
            };
            BlackTheme = new ThemeDefinition()
            {
                Key = _blackThemeKey,
                Name = BlackThemeName,
                Appearance = StandardAppearances.BlackAppearance,
                IsReadOnly = true
            };
            BlueTheme = new ThemeDefinition()
            {
                Key = _blueThemeKey,
                Name = BlueThemeName,
                Appearance = StandardAppearances.BlueAppearance,
                IsReadOnly = true
            };
        }

        #endregion
    }
}
