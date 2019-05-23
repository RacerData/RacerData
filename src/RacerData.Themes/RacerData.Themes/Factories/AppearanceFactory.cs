using RacerData.Themes.Models;
using RacerData.Themes.Ports;

namespace RacerData.Themes.Factories
{
    class AppearanceFactory : IAppearanceFactory
    {
        public IAppearance BuildNewAppearance(ISystemColors colors)
        {
            return new Appearance()
            {
                ForeColor = colors.ControlText,
                BackColor = colors.Control,

                ForeColor2 = colors.WindowText,
                BackColor2 = colors.Window,

                MouseOverForeColor = colors.HighlightText,
                MouseOverBackColor = colors.Highlight,

                SelectedForeColor = colors.ActiveCaptionText,
                SelectedBackColor = colors.ActiveCaption,

                BorderColor = colors.ButtonHighlight,
                BorderThickness = 1
            };
        }
    }
}
