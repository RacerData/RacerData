using System.Drawing;
using System.Windows.Forms;
using RacerData.WinForms.Themes.Models;

namespace RacerData.WinForms.Themes.Internal
{
    internal class ButtonAppearance : BaseAppearance, IButtonAppearance
    {
        public virtual FlatStyle FlatStyle { get; set; }
        //public virtual FlatButtonAppearance FlatAppearance { get; set; }
        public virtual ContentAlignment Alignment { get; set; }
    }
}
