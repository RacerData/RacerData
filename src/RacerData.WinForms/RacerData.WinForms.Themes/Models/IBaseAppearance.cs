using System.Drawing;

namespace RacerData.WinForms.Themes.Models
{
    public interface IBaseAppearance
    {
        Color BackColor { get; set; }
        Font Font { get; set; }
        Color ForeColor { get; set; }
    }
}