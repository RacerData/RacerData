using System.Drawing;
using System.Windows.Forms;

namespace RacerData.WinForms.Themes.Models
{
    public interface IDialogAppearance : IAppearance
    {
        BorderStyle BorderStyle { get; set; }
        Color ButtonBackColor { get; set; }
        Font ButtonFont { get; set; }
        Color ButtonForeColor { get; set; }
    }
}