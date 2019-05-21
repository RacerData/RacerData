using System.Drawing;
using RacerData.Themes.Models;

namespace RacerData.Themes.UI.Extensions
{
    public static class FontInfoExtensions
    {
        public static Font ToFont(this FontInfo fontInfo)
        {
            FontStyle fontStyle = new FontStyle();

            if (fontInfo.Bold)
            {
                fontStyle = fontStyle | FontStyle.Bold;
            }
            if (fontInfo.Italic)
            {
                fontStyle = fontStyle | FontStyle.Italic;
            }

            return new Font(fontInfo.Name, fontInfo.Size, fontStyle);
        }

        public static FontInfo ToFontInfo(this Font font)
        {
            return new FontInfo()
            {
                Name = font.FontFamily.Name,
                Size = font.Size,
                Bold = font.Bold,
                Italic = font.Italic
            };
        }
    }
}
