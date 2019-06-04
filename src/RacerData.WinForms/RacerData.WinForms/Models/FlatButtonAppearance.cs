using System.Drawing;

namespace RacerData.WinForms.Models
{
    public class FlatButtonAppearance
    {
        #region properties

        public Color BorderColor { get; set; }
        public int BorderSize { get; set; }
        public Color MouseDownBackColor { get; set; }
        public Color MouseOverBackColor { get; set; }

        #endregion

        #region ctor

        public FlatButtonAppearance()
        {
            BorderColor = default(Color);
            BorderSize = 1;
            MouseDownBackColor = default(Color);
            MouseOverBackColor = default(Color);
        }

        #endregion

    }
}
