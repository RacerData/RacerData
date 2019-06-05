using System.Drawing;
using RacerData.WinForms.Models;

namespace RacerData.WinForms.Controls
{
    public interface IStaticViewField
    {
        Color CaptionBackColor { get; set; }
        Font CaptionFont { get; set; }
        Color CaptionForeColor { get; set; }
        StaticField Field { get; set; }
        string Value { get; set; }
        Color ValueBackColor { get; set; }
        Font ValueFont { get; set; }
        Color ValueForeColor { get; set; }
    }
}