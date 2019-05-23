using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace RacerData.Themes.UI.ColorTables
{
    public class SimpleCustomColorTable : ProfessionalColorTable, IColorTableText, ISimpleColorTable
    {
        #region properties

        /*** General ***/

        [DisplayName("ForeColor")]
        [Description("Primary Text Color")]
        [Category("General")]
        public Color ForeColor { get; set; }

        [DisplayName("MouseOver ForeColor")]
        [Description("MouseOver Text Color")]
        [Category("General")]
        public Color MouseOverForeColor { get; set; }

        [DisplayName("Primary Background")]
        [Description("Primary Background Color")]
        [Category("General")]
        public Color BackColor { get; set; }

        [DisplayName("MouseOver BackColor")]
        [Description("MouseOver Background Color")]
        [Category("General")]
        public Color MouseOverBackColor { get; set; }

        /*** MenuStrip ***/

        [DisplayName("Menu Border")]
        [Description("Menu Border Color")]
        [Category("MenuStrip")]
        public Color MenuBorderColor { get; set; }

        [DisplayName("Open Menu BackColor")]
        [Description("Open Menu Background Color")]
        [Category("MenuStrip")]
        public Color OpenMenuBackColor { get; set; }

        [DisplayName("Checked CheckBox BackColor")]
        [Description("Checked MenuItem CheckBox Background Color")]
        [Category("MenuStrip")]
        public Color CheckedCheckBoxBackColor { get; set; }
        
        /*** ToolStrip ***/

        [DisplayName("Checked Button BackColor")]
        [Description("Checked ToolStrip Button Background Color")]
        [Category("ToolStrip")]
        public Color CheckedButtonBackColor { get; set; }

        [DisplayName("Checked Button Border")]
        [Description("Checked ToolStrip Button Border Color")]
        [Category("ToolStrip")]
        public Color CheckedButtonBorderColor { get; set; }

        [DisplayName("Checked Button MouseOver BackColor")]
        [Description("Checked ToolStrip Button MouseOver Background Color")]
        [Category("ToolStrip")]
        public Color CheckedButtonMouseOverBackColor { get; set; }

        /*** Separator ***/

        [DisplayName("Separator Primary")]
        [Description("Separator Primary Color")]
        [Category("Separator")]
        public Color SeparatorDarkColor { get; set; }

        [DisplayName("Separator Secondary")]
        [Description("Separator Secondary Color")]
        [Category("Separator")]
        public Color SeparatorLightColor { get; set; }

        #region overrides
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override Color SeparatorDark => SeparatorDarkColor;
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override Color SeparatorLight => SeparatorLightColor;

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override Color MenuBorder => MenuBorderColor;

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override Color ToolStripGradientBegin => BackColor;
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override Color ToolStripGradientMiddle => BackColor;
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override Color ToolStripGradientEnd => BackColor;

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override Color MenuStripGradientBegin => BackColor;
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override Color MenuStripGradientEnd => BackColor;
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override Color StatusStripGradientBegin => BackColor;
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override Color StatusStripGradientEnd => BackColor;

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override Color MenuItemSelectedGradientBegin => MouseOverBackColor;
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override Color MenuItemSelectedGradientEnd => MouseOverBackColor;

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override Color MenuItemPressedGradientBegin => OpenMenuBackColor;
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override Color MenuItemPressedGradientMiddle => OpenMenuBackColor;
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override Color MenuItemPressedGradientEnd => OpenMenuBackColor;

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override Color ImageMarginGradientBegin => BackColor;
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override Color ImageMarginGradientMiddle => BackColor;
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override Color ImageMarginGradientEnd => BackColor;

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override Color ToolStripPanelGradientBegin => BackColor;
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override Color ToolStripPanelGradientEnd => BackColor;

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override Color ToolStripContentPanelGradientBegin => BackColor;
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override Color ToolStripContentPanelGradientEnd => BackColor;

        // Main back color for menu items (except image margin)
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override Color ToolStripDropDownBackground => BackColor;

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override Color CheckBackground => CheckedCheckBoxBackColor;
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override Color CheckSelectedBackground => CheckedCheckBoxBackColor;
        [Browsable(false)]
        // Check background while mouse button is pressed
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override Color CheckPressedBackground => MouseOverBackColor;

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override Color ButtonSelectedGradientBegin => MouseOverBackColor;
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override Color ButtonSelectedGradientMiddle => MouseOverBackColor;
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override Color ButtonSelectedGradientEnd => MouseOverBackColor;

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override Color ButtonSelectedBorder => CheckedButtonBorderColor;
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override Color ButtonSelectedHighlight => MouseOverBackColor;
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override Color ButtonSelectedHighlightBorder => CheckedButtonBorderColor;

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override Color ButtonCheckedGradientBegin => CheckedButtonBackColor;
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override Color ButtonCheckedGradientMiddle => CheckedButtonBackColor;
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override Color ButtonCheckedGradientEnd => CheckedButtonBackColor;

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override Color ButtonCheckedHighlight => MouseOverBackColor;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public override Color ButtonCheckedHighlightBorder => CheckedButtonBorderColor;

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override Color ButtonPressedGradientBegin => CheckedButtonMouseOverBackColor;
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override Color ButtonPressedGradientMiddle => CheckedButtonMouseOverBackColor;
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override Color ButtonPressedGradientEnd => CheckedButtonMouseOverBackColor;

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override Color ButtonPressedBorder => CheckedButtonBorderColor;
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override Color ButtonPressedHighlight => MouseOverBackColor;
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override Color ButtonPressedHighlightBorder => CheckedButtonBorderColor;

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override Color ImageMarginRevealedGradientBegin => BackColor;
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override Color ImageMarginRevealedGradientMiddle => BackColor;
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override Color ImageMarginRevealedGradientEnd => BackColor;

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override Color OverflowButtonGradientBegin => BackColor;
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override Color OverflowButtonGradientMiddle => BackColor;
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override Color OverflowButtonGradientEnd => BackColor;

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override Color ToolStripBorder => MenuBorderColor;

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override Color RaftingContainerGradientBegin => BackColor;
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override Color RaftingContainerGradientEnd => BackColor;

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override Color MenuItemSelected => MouseOverBackColor;
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override Color MenuItemBorder => MenuBorderColor;

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override Color GripDark => BackColor;
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override Color GripLight => BackColor;
        #endregion

        #endregion

        #region ctor
        public SimpleCustomColorTable()
            : base()
        {
            MenuBorderColor = base.MenuBorder;
            BackColor = base.ToolStripGradientBegin;
            MouseOverBackColor = base.MenuItemSelectedGradientBegin;
            OpenMenuBackColor = base.ButtonPressedGradientBegin;
            CheckedButtonBackColor = base.ButtonCheckedGradientBegin;
            CheckedCheckBoxBackColor = base.CheckBackground;
            CheckedButtonBorderColor = base.ButtonPressedHighlightBorder;
            CheckedButtonMouseOverBackColor = base.ButtonPressedGradientBegin;
            SeparatorDarkColor = base.SeparatorDark;
            SeparatorLightColor = base.SeparatorLight;
        }
        #endregion
    }
}
