using System.ComponentModel;
using System.Drawing;

namespace RacerData.Themes.UI.ColorTables
{
    public interface ISimpleColorTable
    {
        /*** General ***/

        [DisplayName("ForeColor")]
        [Description("Primary Text Color")]
        [Category("General")]
         Color ForeColor { get; set; }

        [DisplayName("MouseOver ForeColor")]
        [Description("MouseOver Text Color")]
        [Category("General")]
         Color MouseOverForeColor { get; set; }

        [DisplayName("Primary Background")]
        [Description("Primary Background Color")]
        [Category("General")]
         Color BackColor { get; set; }

        [DisplayName("MouseOver BackColor")]
        [Description("MouseOver Background Color")]
        [Category("General")]
         Color MouseOverBackColor { get; set; }

        /*** MenuStrip ***/

        [DisplayName("Menu Border")]
        [Description("Menu Border Color")]
        [Category("MenuStrip")]
         Color MenuBorderColor { get; set; }

        [DisplayName("Open Menu BackColor")]
        [Description("Open Menu Background Color")]
        [Category("MenuStrip")]
         Color OpenMenuBackColor { get; set; }

        [DisplayName("Checked CheckBox BackColor")]
        [Description("Checked MenuItem CheckBox Background Color")]
        [Category("MenuStrip")]
         Color CheckedCheckBoxBackColor { get; set; }

        /*** ToolStrip ***/

        [DisplayName("Checked Button BackColor")]
        [Description("Checked ToolStrip Button Background Color")]
        [Category("ToolStrip")]
         Color CheckedButtonBackColor { get; set; }

        [DisplayName("Checked Button Border")]
        [Description("Checked ToolStrip Button Border Color")]
        [Category("ToolStrip")]
         Color CheckedButtonBorderColor { get; set; }

        [DisplayName("Checked Button MouseOver BackColor")]
        [Description("Checked ToolStrip Button MouseOver Background Color")]
        [Category("ToolStrip")]
         Color CheckedButtonMouseOverBackColor { get; set; }

        /*** Separator ***/

        [DisplayName("Separator Primary")]
        [Description("Separator Primary Color")]
        [Category("Separator")]
         Color SeparatorDarkColor { get; set; }

        [DisplayName("Separator Secondary")]
        [Description("Separator Secondary Color")]
        [Category("Separator")]
         Color SeparatorLightColor { get; set; }
    }
}
