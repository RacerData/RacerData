using System.Drawing;

namespace RacerData.Themes.Models
{
    public static class StandardAppearances
    {
        #region properties

        public static Appearance SystemAppearance { get; private set; }
        public static Appearance BlackAppearance { get; private set; }
        public static Appearance BlueAppearance { get; private set; }

        #endregion

        #region ctor

        static StandardAppearances()
        {
            SystemAppearance = new Appearance()
            {
                ForeColor = CustomSystemColors.DefaultSystemColors.ControlText,
                BackColor = CustomSystemColors.DefaultSystemColors.Control,

                ForeColor2 = CustomSystemColors.DefaultSystemColors.WindowText,
                BackColor2 = CustomSystemColors.DefaultSystemColors.Window,

                MouseOverForeColor = CustomSystemColors.DefaultSystemColors.HighlightText,
                MouseOverBackColor = CustomSystemColors.DefaultSystemColors.Highlight,

                SelectedForeColor = CustomSystemColors.DefaultSystemColors.ActiveCaptionText,
                SelectedBackColor = CustomSystemColors.DefaultSystemColors.ActiveCaption,

                BorderColor = CustomSystemColors.DefaultSystemColors.ButtonHighlight,
                BorderThickness = 0
            };
            BlackAppearance = new Appearance()
            {
                ForeColor = Color.GhostWhite,
                BackColor = Color.DarkGray,

                ForeColor2 = Color.White,
                BackColor2 = Color.DimGray,

                MouseOverForeColor = Color.Silver,
                MouseOverBackColor = Color.Gray,

                SelectedForeColor = Color.Black,
                SelectedBackColor = Color.SkyBlue,

                BorderColor = Color.SkyBlue,
                BorderThickness = 1
            };
            BlueAppearance = new Appearance()
            {
                ForeColor = Color.SkyBlue,
                BackColor = Color.DarkBlue,

                ForeColor2 = Color.LightSteelBlue,
                BackColor2 = Color.SteelBlue,

                MouseOverForeColor = Color.Black,
                MouseOverBackColor = Color.DodgerBlue,

                SelectedForeColor = Color.DimGray,
                SelectedBackColor = Color.Navy,

                BorderColor = Color.Cyan,
                BorderThickness = 1
            };
        }

        #endregion
    }
}
