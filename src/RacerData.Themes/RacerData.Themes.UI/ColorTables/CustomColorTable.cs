using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace RacerData.Themes.UI.ColorTables
{
    public class CustomColorTable : ProfessionalColorTable, IColorTableText
    {
        public Color ForeColor { get; set; }
        public Color MouseOverForeColor { get; set; }

        // general

        [DisplayName("Menu Border")]
        [Description("Menu Border Color")]
        [Category("General")]
        public Color MenuBorderColor { get; set; }

        [DisplayName("Highlight")]
        [Description("Highlight Color")]
        [Category("General")]
        public Color HighlightColor { get; set; }

     

        // background

        [DisplayName("Background 1")]
        [Description("Toolstrip and Status Strip Begin Gradient Color")]
        [Category("Background")]
        public Color StripBackgroundGradientBegin { get; set; }

        [DisplayName("Background 2")]
        [Description("Toolstrip and Status Strip Middle Gradient Color")]
        [Category("Background")]
        public Color StripBackgroundGradientMiddle { get; set; }

        [DisplayName("Background 3")]
        [Description("Toolstrip and Status Strip End Gradient Color")]
        [Category("Background")]
        public Color StripBackgroundGradientEnd { get; set; }

        // hover

        [DisplayName("Hover Background 1")]
        [Description("Hover Item Begin Gradient Color")]
        [Category("Hover Item")]
        public Color HoverBackgroundGradientBegin { get; set; }

        //[DisplayName("Hover Background 2")]
        //[Description("Hover Item Middle Gradient Color")]
        //[Category("Hover Item")]
        //public Color HoverBackgroundGradientMiddle { get; set; }

        [DisplayName("Hover Background 3")]
        [Description("Hover Item End Gradient Color")]
        [Category("Hover Item")]
        public Color HoverBackgroundGradientEnd { get; set; }

        // checked

        [DisplayName("Checked CheckBox Hover")]
        [Description("CheckBox Checked Hover Color")]
        [Category("Checked Item")]
        public Color HoverHighlightColor { get; set; }

        [DisplayName("Checked Button 1")]
        [Description("Checked Button Begin Gradient Color")]
        [Category("Checked Item")]
        public Color CheckedBackgroundGradientBegin { get; set; }

        [DisplayName("Checked Button 2")]
        [Description("Checked Button Middle Gradient Color")]
        [Category("Checked Item")]
        public Color CheckedBackgroundGradientMiddle { get; set; }

        [DisplayName("Checked Button 3")]
        [Description("Checked Button End Gradient Color")]
        [Category("Checked Item")]
        public Color CheckedBackgroundGradientEnd { get; set; }

        [DisplayName("Checked Highlight")]
        [Description("Checked Highlight Color")]
        [Category("Checked Item")]
        public Color CheckedHighlightColor { get; set; }

        [DisplayName("Checked Item Border")]
        [Description("Checked Item Border Color")]
        [Category("Checked Item")]
        public Color HighlightBorderColor { get; set; }

        // opened

        [DisplayName("Open Menu Background 1")]
        [Description("Open Menu & Clicked Button Begin Gradient Color")]
        [Category("Menu Item")]
        public Color PressedBackgroundGradientBegin { get; set; }

        [DisplayName("Open Menu Background 2")]
        [Description("Open Menu & Clicked Button Middle Gradient Color")]
        [Category("Menu Item")]
        public Color PressedBackgroundGradientMiddle { get; set; }

        [DisplayName("Open Menu Background 3")]
        [Description("Open Menu & Clicked Button End Gradient Color")]
        [Category("Menu Item")]
        public Color PressedBackgroundGradientEnd { get; set; }

        [DisplayName("Open Menu Highlight")]
        [Description("Open Menu Highlight Color")]
        [Category("Menu Item")]
        public Color PressedHighlightColor { get; set; }


        // separator

        private Color _sepDark = Color.Red;
        [DisplayName("Separator Primary")]
        [Description("Toolstrip Separator Primary Color")]
        [Category("Separator")]
        public Color SeparatorDarkColor
        {
            get
            {
                return _sepDark;
            }
            set
            {
                _sepDark = value;
            }
        }
        [DisplayName("Separator Primary")]
        [Description("Toolstrip Separator Secondary Color")]
        [Category("Separator")]
        public Color SeparatorLightColor { get; set; }


        public CustomColorTable()
            : base()
        {
            PressedHighlightColor = base.CheckPressedBackground;
            CheckedHighlightColor = base.ButtonCheckedHighlight;
            HighlightColor = base.ButtonPressedHighlight;
            HighlightBorderColor = base.ButtonPressedHighlightBorder;

            SeparatorDarkColor = base.SeparatorDark;
            SeparatorLightColor = base.SeparatorLight;
            MenuBorderColor = base.MenuBorder;

            PressedBackgroundGradientBegin = base.ButtonPressedGradientBegin;
            PressedBackgroundGradientMiddle = base.ButtonPressedGradientMiddle;
            PressedBackgroundGradientEnd = base.ButtonPressedGradientEnd;

            CheckedBackgroundGradientBegin = base.ButtonCheckedGradientBegin;
            CheckedBackgroundGradientMiddle = base.ButtonCheckedGradientMiddle;
            CheckedBackgroundGradientEnd = base.ButtonCheckedGradientEnd;

            StripBackgroundGradientBegin = base.ToolStripGradientBegin;
            StripBackgroundGradientMiddle = base.ToolStripGradientMiddle;
            StripBackgroundGradientEnd = base.ToolStripGradientEnd;

            HoverBackgroundGradientBegin = base.MenuItemSelectedGradientBegin;
            HoverBackgroundGradientEnd = base.MenuItemSelectedGradientEnd;
        }

        /*********************************************/

        public override Color SeparatorDark => SeparatorDarkColor;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override Color SeparatorLight => SeparatorLightColor;

        // Border around opened top-level menu item
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override Color MenuBorder => MenuBorderColor;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override Color ToolStripGradientBegin => StripBackgroundGradientBegin;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override Color ToolStripGradientMiddle => StripBackgroundGradientMiddle;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override Color ToolStripGradientEnd => StripBackgroundGradientEnd;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override Color MenuStripGradientBegin => StripBackgroundGradientBegin;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override Color MenuStripGradientEnd => StripBackgroundGradientEnd;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override Color StatusStripGradientBegin => StripBackgroundGradientBegin;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override Color StatusStripGradientEnd => StripBackgroundGradientEnd;

        // Hover color for top-level menu items
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override Color MenuItemSelectedGradientBegin => HoverBackgroundGradientBegin;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override Color MenuItemSelectedGradientEnd => HoverBackgroundGradientEnd;

        // Color for top-level menu when opened
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override Color MenuItemPressedGradientBegin => PressedBackgroundGradientBegin;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override Color MenuItemPressedGradientMiddle => PressedBackgroundGradientMiddle;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override Color MenuItemPressedGradientEnd => PressedBackgroundGradientEnd;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override Color ImageMarginGradientBegin => StripBackgroundGradientBegin;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override Color ImageMarginGradientMiddle => StripBackgroundGradientMiddle;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override Color ImageMarginGradientEnd => StripBackgroundGradientEnd;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override Color ToolStripPanelGradientBegin => StripBackgroundGradientBegin;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override Color ToolStripPanelGradientEnd => StripBackgroundGradientEnd;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override Color ToolStripContentPanelGradientBegin => StripBackgroundGradientBegin;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override Color ToolStripContentPanelGradientEnd => StripBackgroundGradientEnd;

        // Main back color for menu items (except image margin)
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override Color ToolStripDropDownBackground => StripBackgroundGradientBegin;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override Color CheckBackground => StripBackgroundGradientEnd;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override Color CheckSelectedBackground => HoverHighlightColor;
        // Check background while mouse button is pressed
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override Color CheckPressedBackground => PressedHighlightColor;


        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override Color ButtonSelectedGradientBegin => HoverBackgroundGradientBegin;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override Color ButtonSelectedGradientMiddle => HoverBackgroundGradientBegin;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override Color ButtonSelectedGradientEnd => HoverBackgroundGradientEnd;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override Color ButtonSelectedBorder => HighlightBorderColor;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override Color ButtonSelectedHighlight => HoverHighlightColor;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override Color ButtonSelectedHighlightBorder => HighlightBorderColor;


        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override Color ButtonCheckedGradientBegin => CheckedBackgroundGradientBegin;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override Color ButtonCheckedGradientMiddle => CheckedBackgroundGradientMiddle;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override Color ButtonCheckedGradientEnd => CheckedBackgroundGradientEnd;

        // ?????
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override Color ButtonCheckedHighlight => CheckedHighlightColor;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override Color ButtonCheckedHighlightBorder => HighlightBorderColor;


        // Button background when hovering over a checked button
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override Color ButtonPressedGradientBegin => PressedBackgroundGradientBegin;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override Color ButtonPressedGradientMiddle => PressedBackgroundGradientMiddle;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override Color ButtonPressedGradientEnd => PressedBackgroundGradientEnd;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override Color ButtonPressedBorder => HighlightBorderColor;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override Color ButtonPressedHighlight => HighlightColor;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override Color ButtonPressedHighlightBorder => HighlightBorderColor;


        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override Color ImageMarginRevealedGradientBegin => StripBackgroundGradientBegin;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override Color ImageMarginRevealedGradientMiddle => StripBackgroundGradientMiddle;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override Color ImageMarginRevealedGradientEnd => StripBackgroundGradientEnd;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override Color OverflowButtonGradientBegin => StripBackgroundGradientBegin;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override Color OverflowButtonGradientMiddle => StripBackgroundGradientMiddle;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override Color OverflowButtonGradientEnd => StripBackgroundGradientEnd;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override Color ToolStripBorder => MenuBorderColor;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override Color RaftingContainerGradientBegin => StripBackgroundGradientBegin;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override Color RaftingContainerGradientEnd => StripBackgroundGradientEnd;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override Color MenuItemSelected => HoverBackgroundGradientBegin;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override Color MenuItemBorder => MenuBorderColor;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override Color GripDark => StripBackgroundGradientBegin;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override Color GripLight => StripBackgroundGradientEnd;
    }
}
