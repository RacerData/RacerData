using System.Drawing;
using RacerData.Themes.Models;

namespace RacerData.Themes.UI.Models
{
    public class SystemFontInfo : FontInfo
    {
        public SystemFontInfo()
        {
            var systemFont = SystemFonts.MessageBoxFont;

            this.Name = systemFont.FontFamily.Name;
            this.Size = systemFont.Size;
            this.Bold = systemFont.Bold;
            this.Italic = systemFont.Italic;
        }
    }
}
