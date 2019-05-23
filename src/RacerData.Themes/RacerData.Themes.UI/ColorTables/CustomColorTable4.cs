using System.Drawing;
using System.Windows.Forms;

namespace RacerData.Themes.UI.ColorTables
{

    public class CustomColorTable4 : ProfessionalColorTable
    {
        public static Color PanelBlue = Color.FromArgb(255, 51, 153, 255);
        //public static Color IconBlue = Color.FromArgb(255, 122, 193, 255);
        public static Color GhostWhite = Color.FromArgb(255, 248, 248, 255);
        public static Color AlmostWhite = Color.FromArgb(255, 215, 215, 215);
        public static Color MidWhite = Color.FromArgb(255, 125, 125, 125);

        public static Color LightLightGrey = Color.FromArgb(255, 104, 104, 104);
        public static Color LightGrey = Color.FromArgb(255, 63, 63, 70);
        public static Color MediumGrey = Color.FromArgb(255, 45, 45, 48);
        public static Color DarkGrey = Color.FromArgb(255, 37, 37, 38);
        public static Color DarkDarkGrey = Color.FromArgb(255, 28, 28, 28);
        public static Color DimGrey = Color.FromArgb(255, 12, 12, 12);

        //public static Color UnselectedItemBackColor = MediumGrey;
        //public static Color SelectedItemBackColor = PanelBlue;
        //public static Color SeparatorBackColor = LightGrey;
        //public static Color BorderColor = PanelBlue;

        public string Name { get; set; } = "Dark";

        public CustomColorTable4()
            : base()
        {
            UseSystemColors = false;

            ToolStripGradientBegin = base.ToolStripGradientBegin;
            ToolStripGradientMiddle = base.ToolStripGradientMiddle;
            MenuStripGradientBegin = base.MenuStripGradientBegin;
            MenuStripGradientEnd = base.MenuStripGradientEnd;
            StatusStripGradientBegin = base.StatusStripGradientBegin;
            StatusStripGradientEnd = base.StatusStripGradientEnd;
            MenuItemSelectedGradientBegin = base.MenuItemSelectedGradientBegin;
            MenuItemSelectedGradientEnd = base.MenuItemSelectedGradientEnd;
            MenuItemPressedGradientBegin = base.MenuItemPressedGradientBegin;
            MenuItemPressedGradientMiddle = base.MenuItemPressedGradientMiddle;
            MenuItemPressedGradientEnd = base.MenuItemPressedGradientEnd;
            ImageMarginGradientBegin = base.ImageMarginGradientBegin;
            ImageMarginGradientMiddle = base.ImageMarginGradientMiddle;
            ImageMarginGradientEnd = base.ImageMarginGradientEnd;
            ToolStripPanelGradientBegin = base.ToolStripPanelGradientBegin;
            ToolStripPanelGradientEnd = base.ToolStripPanelGradientEnd;
            ToolStripDropDownBackground = base.ToolStripDropDownBackground;
            ToolStripContentPanelGradientBegin = base.ToolStripContentPanelGradientBegin;
            ToolStripContentPanelGradientEnd = base.ToolStripContentPanelGradientEnd;
            ToolStripGradientBegin = base.ToolStripGradientBegin;
            CheckBackground = base.CheckBackground;
            CheckSelectedBackground = base.CheckSelectedBackground;
            CheckPressedBackground = base.CheckPressedBackground;
            ButtonSelectedGradientBegin = base.ButtonSelectedGradientBegin;
            ButtonSelectedGradientMiddle = base.ButtonSelectedGradientMiddle;
            ButtonSelectedGradientEnd = base.ButtonSelectedGradientEnd;
            ButtonSelectedBorder = base.ButtonSelectedBorder;
            ButtonSelectedHighlightBorder = base.ButtonSelectedHighlightBorder;
            ButtonCheckedGradientBegin = base.ButtonCheckedGradientBegin;
            ButtonCheckedGradientMiddle = base.ButtonCheckedGradientMiddle;
            ButtonCheckedGradientEnd = base.ButtonCheckedGradientEnd;
            ButtonCheckedHighlight = base.ButtonCheckedHighlight;
            ButtonCheckedHighlightBorder = base.ButtonCheckedHighlightBorder;
            ButtonPressedHighlight = base.ButtonPressedHighlight;
            ButtonPressedHighlightBorder = base.ButtonPressedHighlightBorder;
            ButtonPressedBorder = base.ButtonPressedBorder;
            ButtonPressedGradientBegin = base.ButtonPressedGradientBegin;
            ButtonPressedGradientMiddle = base.ButtonPressedGradientMiddle;
            ButtonPressedGradientEnd = base.ButtonPressedGradientEnd;
            MenuBorder = base.MenuBorder;
            ImageMarginRevealedGradientBegin = base.ImageMarginRevealedGradientBegin;
            ImageMarginRevealedGradientMiddle = base.ImageMarginRevealedGradientMiddle;
            ImageMarginRevealedGradientEnd = base.ImageMarginRevealedGradientEnd;
            OverflowButtonGradientBegin = base.OverflowButtonGradientBegin;
            OverflowButtonGradientMiddle = base.OverflowButtonGradientMiddle;
            OverflowButtonGradientEnd = base.OverflowButtonGradientEnd;
            ToolStripBorder = base.ToolStripBorder;
            RaftingContainerGradientBegin = base.RaftingContainerGradientBegin;
            RaftingContainerGradientEnd = base.RaftingContainerGradientEnd;
            MenuItemSelected = base.MenuItemSelected;
            MenuItemBorder = base.MenuItemBorder;
            SeparatorDark = base.SeparatorDark;
            SeparatorLight = base.SeparatorLight;
            ButtonSelectedHighlight = base.ButtonSelectedHighlight;
            CheckBackground = base.CheckBackground;
            GripDark = base.GripDark;
            GripLight = base.GripLight;
        }

        public new Color ToolStripGradientBegin { get; set; }
        public new Color ToolStripGradientMiddle { get; set; }
        public new Color ToolStripGradientEnd { get; set; }

        public new Color MenuStripGradientBegin { get; set; }
        public new Color MenuStripGradientEnd { get; set; }

        public new Color StatusStripGradientBegin { get; set; }
        public new Color StatusStripGradientEnd { get; set; }

        // Hover color for top-level menu items
        public new Color MenuItemSelectedGradientBegin { get; set; }
        public new Color MenuItemSelectedGradientEnd { get; set; }

        // Color for top-level menu when opened
        public new Color MenuItemPressedGradientBegin { get; set; }
        public new Color MenuItemPressedGradientMiddle { get; set; }
        public new Color MenuItemPressedGradientEnd { get; set; }

        public new Color ImageMarginGradientBegin { get; set; }
        public new Color ImageMarginGradientMiddle { get; set; }
        public new Color ImageMarginGradientEnd { get; set; }

        public new Color ToolStripPanelGradientBegin { get; set; }
        public new Color ToolStripPanelGradientEnd { get; set; }

        // Main back color for menu items (except image margin)
        public new Color ToolStripDropDownBackground { get; set; }
        public new Color ToolStripContentPanelGradientBegin { get; set; }
        public new Color ToolStripContentPanelGradientEnd { get; set; }

        public new Color CheckBackground { get; set; }
        public new Color CheckSelectedBackground { get; set; }
        // Check background while mouse button is pressed
        public new Color CheckPressedBackground { get; set; }
        public new Color ButtonSelectedGradientBegin { get; set; }
        public new Color ButtonSelectedGradientMiddle { get; set; }
        public new Color ButtonSelectedGradientEnd { get; set; }

        public new Color ButtonSelectedBorder { get; set; }
        public new Color ButtonSelectedHighlightBorder { get; set; }

        public new Color ButtonCheckedGradientBegin { get; set; }
        public new Color ButtonCheckedGradientMiddle { get; set; }
        public new Color ButtonCheckedGradientEnd { get; set; }
        // ?????
        public new Color ButtonCheckedHighlight { get; set; }
        public new Color ButtonCheckedHighlightBorder { get; set; }
        public new Color ButtonPressedHighlight { get; set; }
        public new Color ButtonPressedHighlightBorder { get; set; }
        public new Color ButtonPressedBorder { get; set; }
        // Button background when hovering over a checked button
        public new Color ButtonPressedGradientBegin { get; set; }
        public new Color ButtonPressedGradientMiddle { get; set; }
        public new Color ButtonPressedGradientEnd { get; set; }

        // Border around opened top-level menu item
        public new Color MenuBorder { get; set; }
        public new Color ImageMarginRevealedGradientBegin { get; set; }
        public new Color ImageMarginRevealedGradientMiddle { get; set; }
        public new Color ImageMarginRevealedGradientEnd { get; set; }
        public new Color OverflowButtonGradientBegin { get; set; }
        public new Color OverflowButtonGradientMiddle { get; set; }
        public new Color OverflowButtonGradientEnd { get; set; }

        public new Color ToolStripBorder { get; set; }

        public new Color RaftingContainerGradientBegin { get; set; }

        public new Color RaftingContainerGradientEnd { get; set; }

        public new Color MenuItemSelected { get; set; }
        public new Color MenuItemBorder { get; set; }

        public new Color SeparatorDark { get; set; }
        public new Color SeparatorLight { get; set; }

        public new Color ButtonSelectedHighlight { get; set; }
        public new Color GripDark { get; set; }
        public new Color GripLight { get; set; }
    }
    public class CustomColorTable2 : ProfessionalColorTable
    {
        public static Color PanelBlue = Color.FromArgb(255, 51, 153, 255);
        //public static Color IconBlue = Color.FromArgb(255, 122, 193, 255);
        public static Color GhostWhite = Color.FromArgb(255, 248, 248, 255);
        public static Color AlmostWhite = Color.FromArgb(255, 215, 215, 215);
        public static Color MidWhite = Color.FromArgb(255, 125, 125, 125);

        public static Color LightLightGrey = Color.FromArgb(255, 104, 104, 104);
        public static Color LightGrey = Color.FromArgb(255, 63, 63, 70);
        public static Color MediumGrey = Color.FromArgb(255, 45, 45, 48);
        public static Color DarkGrey = Color.FromArgb(255, 37, 37, 38);
        public static Color DarkDarkGrey = Color.FromArgb(255, 28, 28, 28);
        public static Color DimGrey = Color.FromArgb(255, 12, 12, 12);

        //public static Color UnselectedItemBackColor = MediumGrey;
        //public static Color SelectedItemBackColor = PanelBlue;
        //public static Color SeparatorBackColor = LightGrey;
        //public static Color BorderColor = PanelBlue;

        public string Name { get; set; } = "Dark";

        public CustomColorTable2()
            : base()
        {
            UseSystemColors = false;
        }

        public override Color ToolStripGradientBegin
        { get { return DarkGrey; } }

        public override Color ToolStripGradientMiddle
        { get { return DarkGrey; } }

        public override Color ToolStripGradientEnd
        { get { return DarkDarkGrey; } }


        public override Color MenuStripGradientBegin
        { get { return DarkGrey; } }

        public override Color MenuStripGradientEnd
        { get { return DarkDarkGrey; } }

        public override Color StatusStripGradientBegin => DarkGrey;//base.StatusStripGradientBegin;
        public override Color StatusStripGradientEnd => DarkDarkGrey;//base.StatusStripGradientEnd;

        // Hover color for top-level menu items
        public override Color MenuItemSelectedGradientBegin => MediumGrey;//base.StatusStripGradientBegin;
        public override Color MenuItemSelectedGradientEnd => MediumGrey;//base.StatusStripGradientEnd;

        // Color for top-level menu when opened
        public override Color MenuItemPressedGradientBegin => LightGrey;//base.MenuItemPressedGradientBegin;
        public override Color MenuItemPressedGradientMiddle => LightGrey;//base.MenuItemPressedGradientMiddle;
        public override Color MenuItemPressedGradientEnd => LightGrey;//base.MenuItemPressedGradientEnd;

        public override Color ImageMarginGradientBegin => LightGrey;//base.ImageMarginGradientBegin;
        public override Color ImageMarginGradientMiddle => LightGrey;//base.ImageMarginGradientMiddle;
        public override Color ImageMarginGradientEnd => LightGrey;//base.ImageMarginGradientEnd;

        public override Color ToolStripPanelGradientBegin => Color.HotPink;//base.ToolStripPanelGradientBegin;
        public override Color ToolStripPanelGradientEnd => Color.LimeGreen;//base.ToolStripPanelGradientEnd;

        // Main back color for menu items (except image margin)
        public override Color ToolStripDropDownBackground => DarkDarkGrey;//base.ToolStripDropDownBackground;

        public override Color ToolStripContentPanelGradientBegin => Color.LimeGreen;// base.ToolStripContentPanelGradientBegin;
        public override Color ToolStripContentPanelGradientEnd => Color.HotPink;//base.ToolStripContentPanelGradientEnd;

        public override Color CheckBackground => AlmostWhite;// => base.CheckBackground;
        public override Color CheckSelectedBackground => AlmostWhite;//base.CheckSelectedBackground;
        // Check background while mouse button is pressed
        public override Color CheckPressedBackground => Color.White;//base.CheckPressedBackground;

        public override Color ButtonSelectedGradientBegin => MediumGrey;//base.ButtonSelectedGradientBegin;
        public override Color ButtonSelectedGradientMiddle => MediumGrey;//base.ButtonSelectedGradientMiddle;
        public override Color ButtonSelectedGradientEnd => MediumGrey;//base.ButtonSelectedGradientEnd;

        public override Color ButtonSelectedBorder => LightGrey;//base.ButtonSelectedBorder;
        public override Color ButtonSelectedHighlightBorder => LightGrey;//base.ButtonSelectedHighlightBorder;

        public override Color ButtonCheckedGradientBegin => LightGrey;//base.ButtonCheckedGradientBegin;
        public override Color ButtonCheckedGradientMiddle => Color.Yellow;//MediumGrey;//base.ButtonCheckedGradientMiddle;
        public override Color ButtonCheckedGradientEnd => LightGrey;//base.ButtonCheckedGradientEnd;

        // ?????
        public override Color ButtonCheckedHighlight => Color.Yellow;// MidWhite;//base.ButtonCheckedHighlight;
        public override Color ButtonCheckedHighlightBorder => Color.HotPink;// => base.ButtonCheckedHighlightBorder;
        public override Color ButtonPressedHighlight => Color.LimeGreen;//=> base.ButtonPressedHighlight;
        public override Color ButtonPressedHighlightBorder => Color.LimeGreen;//=> base.ButtonPressedHighlightBorder;
        public override Color ButtonPressedBorder => Color.LimeGreen;//=> base.ButtonPressedBorder;

        // Button background when hovering over a checked button
        public override Color ButtonPressedGradientBegin => LightGrey;//base.ButtonPressedGradientBegin;
        public override Color ButtonPressedGradientMiddle => LightGrey;//base.ButtonPressedGradientMiddle;
        public override Color ButtonPressedGradientEnd => LightGrey;//base.ButtonPressedGradientEnd;

        // Border around opened top-level menu item
        public override Color MenuBorder => LightGrey;//base.MenuBorder;

        public override Color ImageMarginRevealedGradientBegin => LightGrey;//base.ImageMarginRevealedGradientBegin;
        public override Color ImageMarginRevealedGradientMiddle => LightGrey;//base.ImageMarginRevealedGradientMiddle;
        public override Color ImageMarginRevealedGradientEnd => LightGrey;//base.ImageMarginRevealedGradientEnd;

        public override Color OverflowButtonGradientBegin => LightGrey;//base.OverflowButtonGradientBegin;
        public override Color OverflowButtonGradientMiddle => LightGrey;//base.OverflowButtonGradientMiddle;
        public override Color OverflowButtonGradientEnd => LightGrey;//base.OverflowButtonGradientEnd;
        //
        // Summary:
        //     Gets the border color to use on the bottom edge of the System.Windows.Forms.ToolStrip.
        //
        // Returns:
        //     A System.Drawing.Color that is the border color to use on the bottom edge of
        //     the System.Windows.Forms.ToolStrip.
        public override Color ToolStripBorder => base.ToolStripBorder;

        //
        //Summary:
        //     Gets the starting color of the gradient used in the System.Windows.Forms.ToolStripContainer.

        // Returns:
        //     A System.Drawing.Color that is the starting color of the gradient used in the
        //     System.Windows.Forms.ToolStripContainer.
        public override Color RaftingContainerGradientBegin { get; } = DarkGrey;

        //
        //Summary:
        //     Gets the end color of the gradient used in the System.Windows.Forms.ToolStripContainer.

        // Returns:
        //     A System.Drawing.Color that is the end color of the gradient used in the System.Windows.Forms.ToolStripContainer.
        public override Color RaftingContainerGradientEnd { get; } = DarkDarkGrey;

        #region Menu Items

        //
        // Summary:
        //     Gets the solid color to use when a System.Windows.Forms.ToolStripMenuItem other
        //     than the top-level System.Windows.Forms.ToolStripMenuItem is selected.
        //
        // Returns:
        //     A System.Drawing.Color that is the solid color to use when a System.Windows.Forms.ToolStripMenuItem
        //     other than the top-level System.Windows.Forms.ToolStripMenuItem is selected.
        public override Color MenuItemSelected { get; } = LightGrey;

        //
        // Summary:
        //     Gets the border color to use with a System.Windows.Forms.ToolStripMenuItem.
        //
        // Returns:
        //     A System.Drawing.Color that is the border color to use with a System.Windows.Forms.ToolStripMenuItem.
        public override Color MenuItemBorder { get; } = Color.Silver;// LightLightGrey;

        public override Color SeparatorDark { get; } = Color.Silver;
        public override Color SeparatorLight { get; } = LightGrey;


        #endregion

        #region Buttons

        //
        // Summary:
        //     Gets the solid color used when the button is selected.
        //
        // Returns:
        //     A System.Drawing.Color that is the solid color used when the button is selected.
        //public override Color ButtonSelectedHighlight { get { return base.ButtonSelectedHighlight; } }
        public override Color ButtonSelectedHighlight { get { return base.ButtonSelectedHighlight; } }

        // TextBox Border on ToolStrip
        //
        // Summary:
        //     Gets the border color to use with System.Windows.Forms.ProfessionalColorTable.ButtonSelectedHighlight.
        //
        // Returns:
        //     A System.Drawing.Color that is the border color to use with System.Windows.Forms.ProfessionalColorTable.ButtonSelectedHighlight.
        //public override Color ButtonSelectedHighlightBorder { get { return base.ButtonSelectedHighlightBorder; } }
        //public override Color ButtonSelectedHighlightBorder { get; } = PanelBlue;
        //
        // Summary:
        //     Gets the solid color used when the button is pressed.
        //
        // Returns:
        //     A System.Drawing.Color that is the solid color used when the button is pressed.
        //public override Color ButtonPressedHighlight { get { return base.ButtonPressedHighlight; } }
        //public override Color ButtonPressedHighlight { get; } = Color.LimeGreen;
        //
        // Summary:
        //     Gets the border color to use with System.Windows.Forms.ProfessionalColorTable.ButtonPressedHighlight.
        //
        // Returns:
        //     A System.Drawing.Color that is the border color to use with System.Windows.Forms.ProfessionalColorTable.ButtonPressedHighlight.
        // public override Color ButtonPressedHighlightBorder { get { return base.ButtonPressedHighlightBorder; } }
        //public override Color ButtonPressedHighlightBorder { get; } = Color.LimeGreen;
        //
        // Summary:
        //     Gets the solid color used when the button is checked.
        //
        // Returns:
        //     A System.Drawing.Color that is the solid color used when the button is checked.
        //public override Color ButtonCheckedHighlight { get { return base.ButtonCheckedHighlight; } }
        //public override Color ButtonCheckedHighlight { get; } = Color.LimeGreen;
        //
        // Summary:
        //     Gets the border color to use with System.Windows.Forms.ProfessionalColorTable.ButtonCheckedHighlight.
        //
        // Returns:
        //     A System.Drawing.Color that is the border color to use with System.Windows.Forms.ProfessionalColorTable.ButtonCheckedHighlight.
        //public override Color ButtonCheckedHighlightBorder { get { return base.ButtonCheckedHighlightBorder; } }
        //public override Color ButtonCheckedHighlightBorder { get; } = Color.LimeGreen;
        //
        // Summary:
        //     Gets the border color to use with the System.Windows.Forms.ProfessionalColorTable.ButtonPressedGradientBegin,
        //     System.Windows.Forms.ProfessionalColorTable.ButtonPressedGradientMiddle, and
        //     System.Windows.Forms.ProfessionalColorTable.ButtonPressedGradientEnd colors.
        //
        // Returns:
        //     A System.Drawing.Color that is the border color to use with the System.Windows.Forms.ProfessionalColorTable.ButtonPressedGradientBegin,
        //     System.Windows.Forms.ProfessionalColorTable.ButtonPressedGradientMiddle, and
        //     System.Windows.Forms.ProfessionalColorTable.ButtonPressedGradientEnd colors.
        //public override Color ButtonPressedBorder { get { return base.ButtonPressedBorder; } }
        //public override Color ButtonPressedBorder { get; } = Color.LimeGreen;
        //
        // Summary:
        //     Gets the border color to use with the System.Windows.Forms.ProfessionalColorTable.ButtonSelectedGradientBegin,
        //     System.Windows.Forms.ProfessionalColorTable.ButtonSelectedGradientMiddle, and
        //     System.Windows.Forms.ProfessionalColorTable.ButtonSelectedGradientEnd colors.
        //
        // Returns:
        //     A System.Drawing.Color that is the border color to use with the System.Windows.Forms.ProfessionalColorTable.ButtonSelectedGradientBegin,
        //     System.Windows.Forms.ProfessionalColorTable.ButtonSelectedGradientMiddle, and
        //     System.Windows.Forms.ProfessionalColorTable.ButtonSelectedGradientEnd colors.
        //public override Color ButtonSelectedBorder { get { return base.ButtonSelectedBorder; } }
        //public override Color ButtonSelectedBorder { get; } = Color.LimeGreen;

        // Menu item Checked check background color
        //
        // Summary:
        //     Gets the solid color to use when the button is checked and gradients are being
        //     used.
        //
        // Returns:
        //     A System.Drawing.Color that is the solid color to use when the button is checked
        //     and gradients are being used.
        //public override Color CheckBackground { get { return base.CheckBackground; } }
        //public override Color CheckBackground { get; } = Color.LightSalmon;

        // Menu item Checked + Hovered check background color
        //
        // Summary:
        //     Gets the solid color to use when the button is checked and selected and gradients
        //     are being used.
        //
        // Returns:
        //     A System.Drawing.Color that is the solid color to use when the button is checked
        //     and selected and gradients are being used.
        //public override Color CheckSelectedBackground { get { return base.CheckSelectedBackground; } }
        //public override Color CheckSelectedBackground { get; } = Color.Yellow;
        //
        // Summary:
        //     Gets the solid color to use when the button is checked and selected and gradients
        //     are being used.
        //
        // Returns:
        //     A System.Drawing.Color that is the solid color to use when the button is checked
        //     and selected and gradients are being used.
        //public override Color CheckPressedBackground { get { return base.CheckPressedBackground; } }
        //public override Color CheckPressedBackground { get; } = Color.Khaki;

        #endregion

        #region Grip

        //
        // Summary:
        //     Gets the color to use for shadow effects on the grip (move handle).
        //
        // Returns:
        //     A System.Drawing.Color that is the color to use for shadow effects on the grip
        //     (move handle).
        public override Color GripDark { get { return base.GripDark; } }
        //
        // Summary:
        //     Gets the color to use for highlight effects on the grip (move handle).
        //
        // Returns:
        //     A System.Drawing.Color that is the color to use for highlight effects on the
        //     grip (move handle).
        public override Color GripLight { get { return base.GripLight; } }

        #endregion
    }
}
