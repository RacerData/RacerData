using System.Drawing;
using System.Windows.Forms;

namespace RacerData.WinForms.Themes.Models
{
    public interface IButtonAppearance : IBaseAppearance
    {
        ContentAlignment Alignment { get; set; }
        //FlatButtonAppearance FlatAppearance { get; set; }
        FlatStyle FlatStyle { get; set; }
    }
}