using System.Drawing;
using Newtonsoft.Json;
using RacerData.Themes.Ports;

namespace RacerData.Themes.Models
{

    public class SystemColors : ISystemColors
    {
        #region static properties

        [JsonIgnore()]
        public static SystemColors DefaultSystemColors { get; private set; }

        #endregion

        #region properties

        //
        // Summary:
        //     Gets a System.Drawing.Color structure that is the color of the active window's
        //     border.
        //
        // Returns:
        //     A System.Drawing.Color that is the color of the active window's border.
        public Color ActiveBorder { get; set; }
        //
        // Summary:
        //     Gets a System.Drawing.Color structure that is the color of the background in
        //     the client area of a window.
        //
        // Returns:
        //     A System.Drawing.Color that is the color of the background in the client area
        //     of a window.
        public Color Window { get; set; }
        //
        // Summary:
        //     Gets a System.Drawing.Color structure that is the color of the background of
        //     a scroll bar.
        //
        // Returns:
        //     A System.Drawing.Color that is the color of the background of a scroll bar.
        public Color ScrollBar { get; set; }
        //
        // Summary:
        //     Gets a System.Drawing.Color structure that is the color of a menu's text.
        //
        // Returns:
        //     A System.Drawing.Color that is the color of a menu's text.
        public Color MenuText { get; set; }
        //
        // Summary:
        //     Gets a System.Drawing.Color structure that is the color used to highlight menu
        //     items when the menu appears as a flat menu.
        //
        // Returns:
        //     A System.Drawing.Color that is the color used to highlight menu items when the
        //     menu appears as a flat menu.
        public Color MenuHighlight { get; set; }
        //
        // Summary:
        //     Gets a System.Drawing.Color structure that is the color of the background of
        //     a menu bar.
        //
        // Returns:
        //     A System.Drawing.Color that is the color of the background of a menu bar.
        public Color MenuBar { get; set; }
        //
        // Summary:
        //     Gets a System.Drawing.Color structure that is the color of a menu's background.
        //
        // Returns:
        //     A System.Drawing.Color that is the color of a menu's background.
        public Color Menu { get; set; }
        //
        // Summary:
        //     Gets a System.Drawing.Color structure that is the color of the text of a ToolTip.
        //
        // Returns:
        //     A System.Drawing.Color that is the color of the text of a ToolTip.
        public Color InfoText { get; set; }
        //
        // Summary:
        //     Gets a System.Drawing.Color structure that is the color of the background of
        //     a ToolTip.
        //
        // Returns:
        //     A System.Drawing.Color that is the color of the background of a ToolTip.
        public Color Info { get; set; }
        //
        // Summary:
        //     Gets a System.Drawing.Color structure that is the color of the text in an inactive
        //     window's title bar.
        //
        // Returns:
        //     A System.Drawing.Color that is the color of the text in an inactive window's
        //     title bar.
        public Color InactiveCaptionText { get; set; }
        //
        // Summary:
        //     Gets a System.Drawing.Color structure that is the color of the background of
        //     an inactive window's title bar.
        //
        // Returns:
        //     A System.Drawing.Color that is the color of the background of an inactive window's
        //     title bar.
        public Color InactiveCaption { get; set; }
        //
        // Summary:
        //     Gets a System.Drawing.Color structure that is the color of an inactive window's
        //     border.
        //
        // Returns:
        //     A System.Drawing.Color that is the color of an inactive window's border.
        public Color InactiveBorder { get; set; }
        //
        // Summary:
        //     Gets a System.Drawing.Color structure that is the color used to designate a hot-tracked
        //     item.
        //
        // Returns:
        //     A System.Drawing.Color that is the color used to designate a hot-tracked item.
        public Color HotTrack { get; set; }
        //
        // Summary:
        //     Gets a System.Drawing.Color structure that is the color of the text of selected
        //     items.
        //
        // Returns:
        //     A System.Drawing.Color that is the color of the text of selected items.
        public Color HighlightText { get; set; }
        //
        // Summary:
        //     Gets a System.Drawing.Color structure that is the color of the background of
        //     selected items.
        //
        // Returns:
        //     A System.Drawing.Color that is the color of the background of selected items.
        public Color Highlight { get; set; }
        //
        // Summary:
        //     Gets a System.Drawing.Color structure that is the color of a window frame.
        //
        // Returns:
        //     A System.Drawing.Color that is the color of a window frame.
        public Color WindowFrame { get; set; }
        //
        // Summary:
        //     Gets a System.Drawing.Color structure that is the color of dimmed text.
        //
        // Returns:
        //     A System.Drawing.Color that is the color of dimmed text.
        public Color GrayText { get; set; }
        //
        // Summary:
        //     Gets a System.Drawing.Color structure that is the lightest color in the color
        //     gradient of an active window's title bar.
        //
        // Returns:
        //     A System.Drawing.Color that is the lightest color in the color gradient of an
        //     active window's title bar.
        public Color GradientActiveCaption { get; set; }
        //
        // Summary:
        //     Gets a System.Drawing.Color structure that is the color of the desktop.
        //
        // Returns:
        //     A System.Drawing.Color that is the color of the desktop.
        public Color Desktop { get; set; }
        //
        // Summary:
        //     Gets a System.Drawing.Color structure that is the color of text in a 3-D element.
        //
        // Returns:
        //     A System.Drawing.Color that is the color of text in a 3-D element.
        public Color ControlText { get; set; }
        //
        // Summary:
        //     Gets a System.Drawing.Color structure that is the highlight color of a 3-D element.
        //
        // Returns:
        //     A System.Drawing.Color that is the highlight color of a 3-D element.
        public Color ControlLightLight { get; set; }
        //
        // Summary:
        //     Gets a System.Drawing.Color structure that is the light color of a 3-D element.
        //
        // Returns:
        //     A System.Drawing.Color that is the light color of a 3-D element.
        public Color ControlLight { get; set; }
        //
        // Summary:
        //     Gets a System.Drawing.Color structure that is the dark shadow color of a 3-D
        //     element.
        //
        // Returns:
        //     A System.Drawing.Color that is the dark shadow color of a 3-D element.
        public Color ControlDarkDark { get; set; }
        //
        // Summary:
        //     Gets a System.Drawing.Color structure that is the shadow color of a 3-D element.
        //
        // Returns:
        //     A System.Drawing.Color that is the shadow color of a 3-D element.
        public Color ControlDark { get; set; }
        //
        // Summary:
        //     Gets a System.Drawing.Color structure that is the face color of a 3-D element.
        //
        // Returns:
        //     A System.Drawing.Color that is the face color of a 3-D element.
        public Color Control { get; set; }
        //
        // Summary:
        //     Gets a System.Drawing.Color structure that is the shadow color of a 3-D element.
        //
        // Returns:
        //     A System.Drawing.Color that is the shadow color of a 3-D element.
        public Color ButtonShadow { get; set; }
        //
        // Summary:
        //     Gets a System.Drawing.Color structure that is the highlight color of a 3-D element.
        //
        // Returns:
        //     A System.Drawing.Color that is the highlight color of a 3-D element.
        public Color ButtonHighlight { get; set; }
        //
        // Summary:
        //     Gets a System.Drawing.Color structure that is the face color of a 3-D element.
        //
        // Returns:
        //     A System.Drawing.Color that is the face color of a 3-D element.
        public Color ButtonFace { get; set; }
        //
        // Summary:
        //     Gets a System.Drawing.Color structure that is the color of the application workspace.
        //
        // Returns:
        //     A System.Drawing.Color that is the color of the application workspace.
        public Color AppWorkspace { get; set; }
        //
        // Summary:
        //     Gets a System.Drawing.Color structure that is the color of the text in the active
        //     window's title bar.
        //
        // Returns:
        //     A System.Drawing.Color that is the color of the text in the active window's title
        //     bar.
        public Color ActiveCaptionText { get; set; }
        //
        // Summary:
        //     Gets a System.Drawing.Color structure that is the color of the background of
        //     the active window's title bar.
        //
        // Returns:
        //     A System.Drawing.Color that is the color of the active window's title bar.
        public Color ActiveCaption { get; set; }
        //
        // Summary:
        //     Gets a System.Drawing.Color structure that is the lightest color in the color
        //     gradient of an inactive window's title bar.
        //
        // Returns:
        //     A System.Drawing.Color that is the lightest color in the color gradient of an
        //     inactive window's title bar.
        public Color GradientInactiveCaption { get; set; }
        //
        // Summary:
        //     Gets a System.Drawing.Color structure that is the color of the text in the client
        //     area of a window.
        //
        // Returns:
        //     A System.Drawing.Color that is the color of the text in the client area of a
        //     window.
        public Color WindowText { get; set; }

        #endregion

        #region ctor

        static SystemColors()
        {
            DefaultSystemColors = JsonConvert.DeserializeObject<SystemColors>(Properties.Resources.DefaultColorsJson);
        }

        #endregion
    }
}
