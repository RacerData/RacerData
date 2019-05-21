using System;
using RacerData.Themes.Ports;

namespace RacerData.Themes.Models
{
    public static class StandardThemes
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

        public static ITheme SystemTheme { get; private set; }
        public static ITheme BlackTheme { get; private set; }
        public static ITheme BlueTheme { get; private set; }

        #endregion

        #region ctor

        static StandardThemes()
        {
            SystemTheme = new ThemeDefinition()
            {
                Key = _systemThemeKey,
                Name = SystemThemeName,
                Appearance = StandardAppearances.SystemAppearance
            };
            BlackTheme = new ThemeDefinition()
            {
                Key = _blackThemeKey,
                Name = BlackThemeName,
                Appearance = StandardAppearances.BlackAppearance
            };
            BlueTheme = new ThemeDefinition()
            {
                Key = _blueThemeKey,
                Name = BlueThemeName,
                Appearance = StandardAppearances.BlueAppearance
            };
        }

        #endregion
    }
}
