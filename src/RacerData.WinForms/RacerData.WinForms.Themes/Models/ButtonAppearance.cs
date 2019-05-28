using System.Drawing;
using System.Windows.Forms;

namespace RacerData.WinForms.Themes.Models
{
    public class ButtonAppearance : Appearance
    {
        #region properties

        public virtual FlatStyle FlatStyle { get; set; } = FlatStyle.Standard;
        public virtual ContentAlignment Alignment { get; set; }
        public virtual FlatButtonAppearance FlatAppearance { get; set; }

        #endregion

        #region ctor

        public ButtonAppearance()
        {
            FlatAppearance = new FlatButtonAppearance();
        }

        #endregion
    }
}
