using System.Drawing;

namespace RacerData.Themes.Ports
{
    public interface ISystemColors
    {
        #region properties

        Color ActiveBorder { get; set; }
        Color ActiveCaption { get; set; }
        Color ActiveCaptionText { get; set; }
        Color AppWorkspace { get; set; }
        Color ButtonFace { get; set; }
        Color ButtonHighlight { get; set; }
        Color ButtonShadow { get; set; }
        Color Control { get; set; }
        Color ControlDark { get; set; }
        Color ControlDarkDark { get; set; }
        Color ControlLight { get; set; }
        Color ControlLightLight { get; set; }
        Color ControlText { get; set; }
        Color Desktop { get; set; }
        Color GradientActiveCaption { get; set; }
        Color GradientInactiveCaption { get; set; }
        Color GrayText { get; set; }
        Color Highlight { get; set; }
        Color HighlightText { get; set; }
        Color HotTrack { get; set; }
        Color InactiveBorder { get; set; }
        Color InactiveCaption { get; set; }
        Color InactiveCaptionText { get; set; }
        Color Info { get; set; }
        Color InfoText { get; set; }
        Color Menu { get; set; }
        Color MenuBar { get; set; }
        Color MenuHighlight { get; set; }
        Color MenuText { get; set; }
        Color ScrollBar { get; set; }
        Color Window { get; set; }
        Color WindowFrame { get; set; }
        Color WindowText { get; set; }

        #endregion
    }
}