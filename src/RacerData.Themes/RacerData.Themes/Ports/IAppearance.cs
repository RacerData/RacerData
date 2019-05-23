using System.ComponentModel;
using System.Drawing;
using RacerData.Themes.Models;

namespace RacerData.Themes.Ports
{
    public interface IAppearance
    {
        Color BackColor { get; set; }
        Color BackColor2 { get; set; }
        Color BorderColor { get; set; }
        int BorderThickness { get; set; }
        FontInfo CaptionFontInfo { get; set; }
        FontInfo FontInfo { get; set; }
        Color ForeColor { get; set; }
        Color ForeColor2 { get; set; }
        FontInfo Heading1FontInfo { get; set; }
        Color MouseOverBackColor { get; set; }
        Color MouseOverForeColor { get; set; }
        FontInfo RowItemFontInfo { get; set; }
        Color SelectedBackColor { get; set; }
        Color SelectedForeColor { get; set; }

        event PropertyChangedEventHandler PropertyChanged;
    }
}