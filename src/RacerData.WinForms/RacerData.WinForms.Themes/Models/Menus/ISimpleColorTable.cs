using System.Drawing;

namespace RacerData.WinForms.Themes.Models.Menus
{
    public interface ISimpleColorTable
    {
        /// <summary>
        /// Primary Text Color
        /// </summary>
        Color ForeColor { get; set; }

        /// <summary>
        /// MouseOver Text Color
        /// </summary>
        Color MouseOverForeColor { get; set; }

        /// <summary>
        /// Primary Background Color
        /// </summary>
        Color BackColor { get; set; }

        /// <summary>
        /// MouseOver Background Color
        /// </summary>
        Color MouseOverBackColor { get; set; }

        /// <summary>
        /// Primary border color for menustrips, toolstrips, and statusbars
        /// </summary>
        Color MenuBorderColor { get; set; }

        /// <summary>
        /// MouseOver Border Color
        /// </summary>
        Color ToolStripMouseOverBorderColor { get; set; }

        /// <summary>
        /// Checked ToolStrip Button Border Color
        /// </summary>
        Color CheckedBorderColor { get; set; }

        /// <summary>
        /// Menu Item Border Color
        /// </summary>
        Color MenuStripMouseOverBorderColor { get; set; }

        /// <summary>
        /// Open Menu Background Color
        /// </summary>
        Color OpenMenuBackColor { get; set; }

        /// <summary>
        ///  CheckBox Background Color
        /// </summary>
        Color CheckBoxBackColor { get; set; }

        /// <summary>
        /// Checked ToolStrip Button Background Color
        /// </summary>
        Color CheckedButtonBackColor { get; set; }

        /// <summary>
        /// Checked ToolStrip Button MouseOver Background Color
        /// </summary>
        Color CheckedButtonMouseOverBackColor { get; set; }

        /// <summary>
        /// Background color for toolstrip button when it is clicked
        /// </summary>
        Color ButtonClickBackColor { get; set; }

        /// <summary>
        /// Border color for 'Checked' buttons on toolstrips
        /// </summary>
        Color CheckedButtonBorderColor { get; set; }

        /// <summary>
        /// Separator Primary Color
        /// </summary>
        Color SeparatorDarkColor { get; set; }

        /// <summary>
        /// Separator Secondary Color
        /// </summary>
        Color SeparatorLightColor { get; set; }
    }
}
