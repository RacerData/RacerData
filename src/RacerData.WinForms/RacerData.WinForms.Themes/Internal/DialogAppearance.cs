using System.Windows.Forms;
using RacerData.WinForms.Themes.Models;

namespace RacerData.WinForms.Themes.Internal
{
    internal class DialogAppearance : Appearance
    {
        public virtual IButtonAppearance ButtonAppearance { get; set; }
        public virtual IListAppearance ListAppearance { get; set; }
        public virtual FormBorderStyle FormBorderStyle { get; set; }
    }
}
