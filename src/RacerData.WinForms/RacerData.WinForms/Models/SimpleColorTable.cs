using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace RacerData.WinForms.Models
{
    public class SimpleColorTable : ProfessionalColorTable, ISimpleColorTable
    {
        #region properties

        #region /*** general ***/
        /// <inheritdoc/>
        [DisplayName("ForeColor")]
        [Description("Primary text color for menus, toolstrip items, and status labels")]
        [Category("General")]
        public Color ForeColor { get; set; }

        /// <inheritdoc/>
        [DisplayName("BackColor")]
        [Description("Primary background color for menus, toolstrip items, and status labels")]
        [Category("General")]
        public Color BackColor { get; set; }

        /// <inheritdoc/>
        [DisplayName("Border Color")]
        [Description("Primary border color for menustrips, toolstrips, and statusbars")]
        [Category("General")]
        public Color MenuBorderColor { get; set; }


        /// <inheritdoc/>
        [DisplayName("MouseOver ForeColor")]
        [Description("Text color for menus and toolstrip items when the mouse moves over them")]
        [Category("General")]
        public Color MouseOverForeColor { get; set; }

        /// <inheritdoc/>
        [DisplayName("MouseOver BackColor")]
        [Description("Background color for menus and toolstrip items when the mouse moves over them")]
        [Category("General")]
        public Color MouseOverBackColor { get; set; }
        #endregion

        #region /*** menustrip ***/
        /// <inheritdoc/>
        [DisplayName("MenuStrip MouseOver Border")]
        [Description("Border color for menustrip items when the mouse moves over them")]
        [Category("MenuStrip")]
        public Color MenuStripMouseOverBorderColor { get; set; }

        /// <inheritdoc/>
        [DisplayName("Open Menu BackColor")]
        [Description("Background color for open menu items")]
        [Category("MenuStrip")]
        public Color OpenMenuBackColor { get; set; }

        /// <inheritdoc/>
        [DisplayName("CheckBox BackColor")]
        [Description("Background color for the checkbox for checkable menu items")]
        [Category("MenuStrip")]
        public Color CheckBoxBackColor { get; set; }

        /// <inheritdoc/>
        [DisplayName("CheckBox Border")]
        [Description("Border color for the checkbox on checkable menu items")]
        [Category("MenuStrip")]
        public Color CheckedBorderColor { get; set; }
        #endregion

        #region /*** toolstrip ***/

        /// <inheritdoc/>
        [DisplayName("Click Button BackColor")]
        [Description("Background color for toolstrip button when it is clicked")]
        [Category("ToolStrip")]
        public Color ButtonClickBackColor { get; set; }

        /// <inheritdoc/>
        [DisplayName("Checked Button BackColor")]
        [Description("Background color for 'Checked' buttons on toolstrips")]
        [Category("ToolStrip")]
        public Color CheckedButtonBackColor { get; set; }

        /// <inheritdoc/>
        [DisplayName("Checked Button MouseOver BackColor")]
        [Description("Background color for 'Checked' buttons on toolstrips when the mouse moves over them")]
        [Category("ToolStrip")]
        public Color CheckedButtonMouseOverBackColor { get; set; }

        /// <inheritdoc/>
        [DisplayName("ToolStrip MouseOver Border")]
        [Description("Border color for toolstrip items when the mouse moves over them")]
        [Category("ToolStrip")]
        public Color ToolStripMouseOverBorderColor { get; set; }

        /// <inheritdoc/>
        [DisplayName("Checked Button Border")]
        [Description("Border color for 'Checked' buttons on toolstrips")]
        [Category("ToolStrip")]
        public Color CheckedButtonBorderColor { get; set; }
        #endregion

        #region /*** separator ***/
        /// <inheritdoc/>
        [DisplayName("Separator Primary")]
        [Description("Primary color used for toolstrip and menu item separators")]
        [Category("Separator")]
        public Color SeparatorDarkColor { get; set; }

        /// <inheritdoc/>
        [DisplayName("Separator Secondary")]
        [Description("Secondary color used for toolstrip and menu item separators")]
        [Category("Separator")]
        public Color SeparatorLightColor { get; set; }

        #endregion

        #region /*** overrides ***/

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
        public override Color CheckBackground => CheckBoxBackColor;
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override Color CheckSelectedBackground => CheckBoxBackColor;
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
        public override Color ButtonSelectedBorder => ToolStripMouseOverBorderColor;
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override Color ButtonSelectedHighlight => MouseOverBackColor;
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override Color ButtonSelectedHighlightBorder => base.ButtonSelectedHighlightBorder;

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
        public override Color ButtonCheckedHighlightBorder => base.ButtonCheckedHighlightBorder;

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
        public override Color ButtonPressedHighlightBorder => base.ButtonPressedHighlightBorder;

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
        public override Color MenuItemBorder => MenuStripMouseOverBorderColor;

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override Color GripDark => BackColor;
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override Color GripLight => BackColor;

        #endregion

        #endregion

        #region ctor

        public SimpleColorTable()
            : base()
        {
            MenuStripMouseOverBorderColor = base.MenuBorder;
            BackColor = base.ToolStripGradientBegin;
            MouseOverBackColor = base.MenuItemSelectedGradientBegin;
            OpenMenuBackColor = base.ButtonPressedGradientBegin;
            CheckedButtonBackColor = base.ButtonCheckedGradientBegin;
            CheckBoxBackColor = base.CheckBackground;
            CheckedBorderColor = base.ButtonPressedBorder;
            CheckedButtonMouseOverBackColor = base.ButtonPressedGradientBegin;
            SeparatorDarkColor = base.SeparatorDark;
            SeparatorLightColor = base.SeparatorLight;
        }

        #endregion

        #region public

        public SimpleColorTable Copy()
        {
            return (SimpleColorTable)this.MemberwiseClone();
        }

        #endregion
    }
}
