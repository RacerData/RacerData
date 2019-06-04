using System.Drawing;

namespace RacerData.WinForms.Models
{
    public interface IBaseAppearance
    {
        Color BackColor { get; set; }
        Font Font { get; set; }
        Color ForeColor { get; set; }
    }
}