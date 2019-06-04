using System.Windows.Forms;

namespace RacerData.WinForms.Models
{
    public class DialogAppearance : Appearance
    {
        public virtual ButtonAppearance ButtonAppearance { get; set; }
        public virtual ListAppearance ListAppearance { get; set; }
        public virtual FormBorderStyle FormBorderStyle { get; set; }

        public DialogAppearance()
        {
            ButtonAppearance = new ButtonAppearance();
            ListAppearance = new ListAppearance();
        }
    }
}
