//using System.Drawing;

//namespace System.Windows.Forms.My
//{
//    //
//    // Summary:
//    //     Provides colors used for Microsoft Office display elements.
//    public class ProfessionalColorTable
//    {
//        //
//        // Summary:
//        //     Initializes a new instance of the System.Windows.Forms.ProfessionalColorTable
//        //     class.
//        public ProfessionalColorTable();

//        //
//        // Summary:
//        //     Gets the end color of the gradient used in the System.Windows.Forms.MenuStrip.
//        //
//        // Returns:
//        //     A System.Drawing.Color that is the end color of the gradient used in the System.Windows.Forms.MenuStrip.
//        [SRDescriptionAttribute("ProfessionalColorsMenuStripGradientEndDescr")]
//        public virtual Color MenuStripGradientEnd { get; }
//        //
//        // Summary:
//        //     Gets the solid color to use when a System.Windows.Forms.ToolStripMenuItem other
//        //     than the top-level System.Windows.Forms.ToolStripMenuItem is selected.
//        //
//        // Returns:
//        //     A System.Drawing.Color that is the solid color to use when a System.Windows.Forms.ToolStripMenuItem
//        //     other than the top-level System.Windows.Forms.ToolStripMenuItem is selected.
//        [SRDescriptionAttribute("ProfessionalColorsMenuItemSelectedDescr")]
//        public virtual Color MenuItemSelected { get; }
//        //
//        // Summary:
//        //     Gets the border color to use with a System.Windows.Forms.ToolStripMenuItem.
//        //
//        // Returns:
//        //     A System.Drawing.Color that is the border color to use with a System.Windows.Forms.ToolStripMenuItem.
//        [SRDescriptionAttribute("ProfessionalColorsMenuItemBorderDescr")]
//        public virtual Color MenuItemBorder { get; }
//        //
//        // Summary:
//        //     Gets the color that is the border color to use on a System.Windows.Forms.MenuStrip.
//        //
//        // Returns:
//        //     A System.Drawing.Color that is the border color to use on a System.Windows.Forms.MenuStrip.
//        [SRDescriptionAttribute("ProfessionalColorsMenuBorderDescr")]
//        public virtual Color MenuBorder { get; }
//        //
//        // Summary:
//        //     Gets the starting color of the gradient used when the System.Windows.Forms.ToolStripMenuItem
//        //     is selected.
//        //
//        // Returns:
//        //     A System.Drawing.Color that is the starting color of the gradient used when the
//        //     System.Windows.Forms.ToolStripMenuItem is selected.
//        [SRDescriptionAttribute("ProfessionalColorsMenuItemSelectedGradientBeginDescr")]
//        public virtual Color MenuItemSelectedGradientBegin { get; }
//        //
//        // Summary:
//        //     Gets the end color of the gradient used when the System.Windows.Forms.ToolStripMenuItem
//        //     is selected.
//        //
//        // Returns:
//        //     A System.Drawing.Color that is the end color of the gradient used when the System.Windows.Forms.ToolStripMenuItem
//        //     is selected.
//        [SRDescriptionAttribute("ProfessionalColorsMenuItemSelectedGradientEndDescr")]
//        public virtual Color MenuItemSelectedGradientEnd { get; }
//        //
//        // Summary:
//        //     Gets the starting color of the gradient used when a top-level System.Windows.Forms.ToolStripMenuItem
//        //     is pressed.
//        //
//        // Returns:
//        //     A System.Drawing.Color that is the starting color of the gradient used when a
//        //     top-level System.Windows.Forms.ToolStripMenuItem is pressed.
//        [SRDescriptionAttribute("ProfessionalColorsMenuItemPressedGradientBeginDescr")]
//        public virtual Color MenuItemPressedGradientBegin { get; }
//        //
//        // Summary:
//        //     Gets the middle color of the gradient used when a top-level System.Windows.Forms.ToolStripMenuItem
//        //     is pressed.
//        //
//        // Returns:
//        //     A System.Drawing.Color that is the middle color of the gradient used when a top-level
//        //     System.Windows.Forms.ToolStripMenuItem is pressed.
//        [SRDescriptionAttribute("ProfessionalColorsMenuItemPressedGradientMiddleDescr")]
//        public virtual Color MenuItemPressedGradientMiddle { get; }
//        //
//        // Summary:
//        //     Gets the end color of the gradient used when a top-level System.Windows.Forms.ToolStripMenuItem
//        //     is pressed.
//        //
//        // Returns:
//        //     A System.Drawing.Color that is the end color of the gradient used when a top-level
//        //     System.Windows.Forms.ToolStripMenuItem is pressed.
//        [SRDescriptionAttribute("ProfessionalColorsMenuItemPressedGradientEndDescr")]
//        public virtual Color MenuItemPressedGradientEnd { get; }
//        //
//        // Summary:
//        //     Gets the starting color of the gradient used in the System.Windows.Forms.ToolStripContainer.
//        //
//        // Returns:
//        //     A System.Drawing.Color that is the starting color of the gradient used in the
//        //     System.Windows.Forms.ToolStripContainer.
//        [SRDescriptionAttribute("ProfessionalColorsRaftingContainerGradientBeginDescr")]
//        public virtual Color RaftingContainerGradientBegin { get; }
//        //
//        // Summary:
//        //     Gets the end color of the gradient used in the System.Windows.Forms.ToolStripContainer.
//        //
//        // Returns:
//        //     A System.Drawing.Color that is the end color of the gradient used in the System.Windows.Forms.ToolStripContainer.
//        [SRDescriptionAttribute("ProfessionalColorsRaftingContainerGradientEndDescr")]
//        public virtual Color RaftingContainerGradientEnd { get; }
//        //
//        // Summary:
//        //     Gets the color to use to for shadow effects on the System.Windows.Forms.ToolStripSeparator.
//        //
//        // Returns:
//        //     A System.Drawing.Color that is the color to use to for shadow effects on the
//        //     System.Windows.Forms.ToolStripSeparator.
//        [SRDescriptionAttribute("ProfessionalColorsSeparatorDarkDescr")]
//        public virtual Color SeparatorDark { get; }
//        //
//        // Summary:
//        //     Gets the color to use to for highlight effects on the System.Windows.Forms.ToolStripSeparator.
//        //
//        // Returns:
//        //     A System.Drawing.Color that is the color to use to for highlight effects on the
//        //     System.Windows.Forms.ToolStripSeparator.
//        [SRDescriptionAttribute("ProfessionalColorsSeparatorLightDescr")]
//        public virtual Color SeparatorLight { get; }
//        //
//        // Summary:
//        //     Gets the starting color of the gradient used on the System.Windows.Forms.StatusStrip.
//        //
//        // Returns:
//        //     A System.Drawing.Color that is the starting color of the gradient used on the
//        //     System.Windows.Forms.StatusStrip.
//        [SRDescriptionAttribute("ProfessionalColorsStatusStripGradientBeginDescr")]
//        public virtual Color StatusStripGradientBegin { get; }
//        //
//        // Summary:
//        //     Gets the end color of the gradient used on the System.Windows.Forms.StatusStrip.
//        //
//        // Returns:
//        //     A System.Drawing.Color that is the end color of the gradient used on the System.Windows.Forms.StatusStrip.
//        [SRDescriptionAttribute("ProfessionalColorsStatusStripGradientEndDescr")]
//        public virtual Color StatusStripGradientEnd { get; }
//        //
//        // Summary:
//        //     Gets the border color to use on the bottom edge of the System.Windows.Forms.ToolStrip.
//        //
//        // Returns:
//        //     A System.Drawing.Color that is the border color to use on the bottom edge of
//        //     the System.Windows.Forms.ToolStrip.
//        [SRDescriptionAttribute("ProfessionalColorsToolStripBorderDescr")]
//        public virtual Color ToolStripBorder { get; }
//        //
//        // Summary:
//        //     Gets the solid background color of the System.Windows.Forms.ToolStripDropDown.
//        //
//        // Returns:
//        //     A System.Drawing.Color that is the solid background color of the System.Windows.Forms.ToolStripDropDown.
//        [SRDescriptionAttribute("ProfessionalColorsToolStripDropDownBackgroundDescr")]
//        public virtual Color ToolStripDropDownBackground { get; }
//        //
//        // Summary:
//        //     Gets the starting color of the gradient used in the System.Windows.Forms.ToolStrip
//        //     background.
//        //
//        // Returns:
//        //     A System.Drawing.Color that is the starting color of the gradient used in the
//        //     System.Windows.Forms.ToolStrip background.
//        [SRDescriptionAttribute("ProfessionalColorsToolStripGradientBeginDescr")]
//        public virtual Color ToolStripGradientBegin { get; }
//        //
//        // Summary:
//        //     Gets the middle color of the gradient used in the System.Windows.Forms.ToolStrip
//        //     background.
//        //
//        // Returns:
//        //     A System.Drawing.Color that is the middle color of the gradient used in the System.Windows.Forms.ToolStrip
//        //     background.
//        [SRDescriptionAttribute("ProfessionalColorsToolStripGradientMiddleDescr")]
//        public virtual Color ToolStripGradientMiddle { get; }
//        //
//        // Summary:
//        //     Gets the end color of the gradient used in the System.Windows.Forms.ToolStrip
//        //     background.
//        //
//        // Returns:
//        //     A System.Drawing.Color that is the end color of the gradient used in the System.Windows.Forms.ToolStrip
//        //     background.
//        [SRDescriptionAttribute("ProfessionalColorsToolStripGradientEndDescr")]
//        public virtual Color ToolStripGradientEnd { get; }
//        //
//        // Summary:
//        //     Gets the starting color of the gradient used in the System.Windows.Forms.ToolStripContentPanel.
//        //
//        // Returns:
//        //     A System.Drawing.Color that is the starting color of the gradient used in the
//        //     System.Windows.Forms.ToolStripContentPanel.
//        [SRDescriptionAttribute("ProfessionalColorsToolStripContentPanelGradientBeginDescr")]
//        public virtual Color ToolStripContentPanelGradientBegin { get; }
//        //
//        // Summary:
//        //     Gets the end color of the gradient used in the System.Windows.Forms.ToolStripContentPanel.
//        //
//        // Returns:
//        //     A System.Drawing.Color that is the end color of the gradient used in the System.Windows.Forms.ToolStripContentPanel.
//        [SRDescriptionAttribute("ProfessionalColorsToolStripContentPanelGradientEndDescr")]
//        public virtual Color ToolStripContentPanelGradientEnd { get; }
//        //
//        // Summary:
//        //     Gets the starting color of the gradient used in the System.Windows.Forms.ToolStripPanel.
//        //
//        // Returns:
//        //     A System.Drawing.Color that is the starting color of the gradient used in the
//        //     System.Windows.Forms.ToolStripPanel.
//        [SRDescriptionAttribute("ProfessionalColorsToolStripPanelGradientBeginDescr")]
//        public virtual Color ToolStripPanelGradientBegin { get; }
//        //
//        // Summary:
//        //     Gets the end color of the gradient used in the System.Windows.Forms.ToolStripPanel.
//        //
//        // Returns:
//        //     A System.Drawing.Color that is the end color of the gradient used in the System.Windows.Forms.ToolStripPanel.
//        [SRDescriptionAttribute("ProfessionalColorsToolStripPanelGradientEndDescr")]
//        public virtual Color ToolStripPanelGradientEnd { get; }
//        //
//        // Summary:
//        //     Gets the starting color of the gradient used in the System.Windows.Forms.ToolStripOverflowButton.
//        //
//        // Returns:
//        //     A System.Drawing.Color that is the starting color of the gradient used in the
//        //     System.Windows.Forms.ToolStripOverflowButton.
//        [SRDescriptionAttribute("ProfessionalColorsOverflowButtonGradientBeginDescr")]
//        public virtual Color OverflowButtonGradientBegin { get; }
//        //
//        // Summary:
//        //     Gets the starting color of the gradient used in the System.Windows.Forms.MenuStrip.
//        //
//        // Returns:
//        //     A System.Drawing.Color that is the starting color of the gradient used in the
//        //     System.Windows.Forms.MenuStrip.
//        [SRDescriptionAttribute("ProfessionalColorsMenuStripGradientBeginDescr")]
//        public virtual Color MenuStripGradientBegin { get; }
//        //
//        // Summary:
//        //     Gets the end color of the gradient used in the image margin of a System.Windows.Forms.ToolStripDropDownMenu
//        //     when an item is revealed.
//        //
//        // Returns:
//        //     A System.Drawing.Color that is the end color of the gradient used in the image
//        //     margin of a System.Windows.Forms.ToolStripDropDownMenu when an item is revealed.
//        [SRDescriptionAttribute("ProfessionalColorsImageMarginRevealedGradientEndDescr")]
//        public virtual Color ImageMarginRevealedGradientEnd { get; }
//        //
//        // Summary:
//        //     Gets the middle color of the gradient used in the image margin of a System.Windows.Forms.ToolStripDropDownMenu
//        //     when an item is revealed.
//        //
//        // Returns:
//        //     A System.Drawing.Color that is the middle color of the gradient used in the image
//        //     margin of a System.Windows.Forms.ToolStripDropDownMenu when an item is revealed.
//        [SRDescriptionAttribute("ProfessionalColorsImageMarginRevealedGradientMiddleDescr")]
//        public virtual Color ImageMarginRevealedGradientMiddle { get; }
//        //
//        // Summary:
//        //     Gets the starting color of the gradient used in the image margin of a System.Windows.Forms.ToolStripDropDownMenu
//        //     when an item is revealed.
//        //
//        // Returns:
//        //     A System.Drawing.Color that is the starting color of the gradient used in the
//        //     image margin of a System.Windows.Forms.ToolStripDropDownMenu when an item is
//        //     revealed.
//        [SRDescriptionAttribute("ProfessionalColorsImageMarginRevealedGradientBeginDescr")]
//        public virtual Color ImageMarginRevealedGradientBegin { get; }
//        //
//        // Summary:
//        //     Gets or sets a value indicating whether to use System.Drawing.SystemColors rather
//        //     than colors that match the current visual style.
//        //
//        // Returns:
//        //     true to use System.Drawing.SystemColors; otherwise, false. The default is false.
//        public bool UseSystemColors { get; set; }
//        //
//        // Summary:
//        //     Gets the solid color used when the button is selected.
//        //
//        // Returns:
//        //     A System.Drawing.Color that is the solid color used when the button is selected.
//        [SRDescriptionAttribute("ProfessionalColorsButtonSelectedHighlightDescr")]
//        public virtual Color ButtonSelectedHighlight { get; }
//        //
//        // Summary:
//        //     Gets the border color to use with System.Windows.Forms.ProfessionalColorTable.ButtonSelectedHighlight.
//        //
//        // Returns:
//        //     A System.Drawing.Color that is the border color to use with System.Windows.Forms.ProfessionalColorTable.ButtonSelectedHighlight.
//        [SRDescriptionAttribute("ProfessionalColorsButtonSelectedHighlightBorderDescr")]
//        public virtual Color ButtonSelectedHighlightBorder { get; }
//        //
//        // Summary:
//        //     Gets the solid color used when the button is pressed.
//        //
//        // Returns:
//        //     A System.Drawing.Color that is the solid color used when the button is pressed.
//        [SRDescriptionAttribute("ProfessionalColorsButtonPressedHighlightDescr")]
//        public virtual Color ButtonPressedHighlight { get; }
//        //
//        // Summary:
//        //     Gets the border color to use with System.Windows.Forms.ProfessionalColorTable.ButtonPressedHighlight.
//        //
//        // Returns:
//        //     A System.Drawing.Color that is the border color to use with System.Windows.Forms.ProfessionalColorTable.ButtonPressedHighlight.
//        [SRDescriptionAttribute("ProfessionalColorsButtonPressedHighlightBorderDescr")]
//        public virtual Color ButtonPressedHighlightBorder { get; }
//        //
//        // Summary:
//        //     Gets the solid color used when the button is checked.
//        //
//        // Returns:
//        //     A System.Drawing.Color that is the solid color used when the button is checked.
//        [SRDescriptionAttribute("ProfessionalColorsButtonCheckedHighlightDescr")]
//        public virtual Color ButtonCheckedHighlight { get; }
//        //
//        // Summary:
//        //     Gets the border color to use with System.Windows.Forms.ProfessionalColorTable.ButtonCheckedHighlight.
//        //
//        // Returns:
//        //     A System.Drawing.Color that is the border color to use with System.Windows.Forms.ProfessionalColorTable.ButtonCheckedHighlight.
//        [SRDescriptionAttribute("ProfessionalColorsButtonCheckedHighlightBorderDescr")]
//        public virtual Color ButtonCheckedHighlightBorder { get; }
//        //
//        // Summary:
//        //     Gets the border color to use with the System.Windows.Forms.ProfessionalColorTable.ButtonPressedGradientBegin,
//        //     System.Windows.Forms.ProfessionalColorTable.ButtonPressedGradientMiddle, and
//        //     System.Windows.Forms.ProfessionalColorTable.ButtonPressedGradientEnd colors.
//        //
//        // Returns:
//        //     A System.Drawing.Color that is the border color to use with the System.Windows.Forms.ProfessionalColorTable.ButtonPressedGradientBegin,
//        //     System.Windows.Forms.ProfessionalColorTable.ButtonPressedGradientMiddle, and
//        //     System.Windows.Forms.ProfessionalColorTable.ButtonPressedGradientEnd colors.
//        [SRDescriptionAttribute("ProfessionalColorsButtonPressedBorderDescr")]
//        public virtual Color ButtonPressedBorder { get; }
//        //
//        // Summary:
//        //     Gets the border color to use with the System.Windows.Forms.ProfessionalColorTable.ButtonSelectedGradientBegin,
//        //     System.Windows.Forms.ProfessionalColorTable.ButtonSelectedGradientMiddle, and
//        //     System.Windows.Forms.ProfessionalColorTable.ButtonSelectedGradientEnd colors.
//        //
//        // Returns:
//        //     A System.Drawing.Color that is the border color to use with the System.Windows.Forms.ProfessionalColorTable.ButtonSelectedGradientBegin,
//        //     System.Windows.Forms.ProfessionalColorTable.ButtonSelectedGradientMiddle, and
//        //     System.Windows.Forms.ProfessionalColorTable.ButtonSelectedGradientEnd colors.
//        [SRDescriptionAttribute("ProfessionalColorsButtonSelectedBorderDescr")]
//        public virtual Color ButtonSelectedBorder { get; }
//        //
//        // Summary:
//        //     Gets the starting color of the gradient used when the button is checked.
//        //
//        // Returns:
//        //     A System.Drawing.Color that is the starting color of the gradient used when the
//        //     button is checked.
//        [SRDescriptionAttribute("ProfessionalColorsButtonCheckedGradientBeginDescr")]
//        public virtual Color ButtonCheckedGradientBegin { get; }
//        //
//        // Summary:
//        //     Gets the middle color of the gradient used when the button is checked.
//        //
//        // Returns:
//        //     A System.Drawing.Color that is the middle color of the gradient used when the
//        //     button is checked.
//        [SRDescriptionAttribute("ProfessionalColorsButtonCheckedGradientMiddleDescr")]
//        public virtual Color ButtonCheckedGradientMiddle { get; }
//        //
//        // Summary:
//        //     Gets the end color of the gradient used when the button is checked.
//        //
//        // Returns:
//        //     A System.Drawing.Color that is the end color of the gradient used when the button
//        //     is checked.
//        [SRDescriptionAttribute("ProfessionalColorsButtonCheckedGradientEndDescr")]
//        public virtual Color ButtonCheckedGradientEnd { get; }
//        //
//        // Summary:
//        //     Gets the middle color of the gradient used in the System.Windows.Forms.ToolStripOverflowButton.
//        //
//        // Returns:
//        //     A System.Drawing.Color that is the middle color of the gradient used in the System.Windows.Forms.ToolStripOverflowButton.
//        [SRDescriptionAttribute("ProfessionalColorsOverflowButtonGradientMiddleDescr")]
//        public virtual Color OverflowButtonGradientMiddle { get; }
//        //
//        // Summary:
//        //     Gets the starting color of the gradient used when the button is selected.
//        //
//        // Returns:
//        //     A System.Drawing.Color that is the starting color of the gradient used when the
//        //     button is selected.
//        [SRDescriptionAttribute("ProfessionalColorsButtonSelectedGradientBeginDescr")]
//        public virtual Color ButtonSelectedGradientBegin { get; }
//        //
//        // Summary:
//        //     Gets the end color of the gradient used when the button is selected.
//        //
//        // Returns:
//        //     A System.Drawing.Color that is the end color of the gradient used when the button
//        //     is selected.
//        [SRDescriptionAttribute("ProfessionalColorsButtonSelectedGradientEndDescr")]
//        public virtual Color ButtonSelectedGradientEnd { get; }
//        //
//        // Summary:
//        //     Gets the starting color of the gradient used when the button is pressed.
//        //
//        // Returns:
//        //     A System.Drawing.Color that is the starting color of the gradient used when the
//        //     button is pressed.
//        [SRDescriptionAttribute("ProfessionalColorsButtonPressedGradientBeginDescr")]
//        public virtual Color ButtonPressedGradientBegin { get; }
//        //
//        // Summary:
//        //     Gets the middle color of the gradient used when the button is pressed.
//        //
//        // Returns:
//        //     A System.Drawing.Color that is the middle color of the gradient used when the
//        //     button is pressed.
//        [SRDescriptionAttribute("ProfessionalColorsButtonPressedGradientMiddleDescr")]
//        public virtual Color ButtonPressedGradientMiddle { get; }
//        //
//        // Summary:
//        //     Gets the end color of the gradient used when the button is pressed.
//        //
//        // Returns:
//        //     A System.Drawing.Color that is the end color of the gradient used when the button
//        //     is pressed.
//        [SRDescriptionAttribute("ProfessionalColorsButtonPressedGradientEndDescr")]
//        public virtual Color ButtonPressedGradientEnd { get; }
//        //
//        // Summary:
//        //     Gets the solid color to use when the button is checked and gradients are being
//        //     used.
//        //
//        // Returns:
//        //     A System.Drawing.Color that is the solid color to use when the button is checked
//        //     and gradients are being used.
//        [SRDescriptionAttribute("ProfessionalColorsCheckBackgroundDescr")]
//        public virtual Color CheckBackground { get; }
//        //
//        // Summary:
//        //     Gets the solid color to use when the button is checked and selected and gradients
//        //     are being used.
//        //
//        // Returns:
//        //     A System.Drawing.Color that is the solid color to use when the button is checked
//        //     and selected and gradients are being used.
//        [SRDescriptionAttribute("ProfessionalColorsCheckSelectedBackgroundDescr")]
//        public virtual Color CheckSelectedBackground { get; }
//        //
//        // Summary:
//        //     Gets the solid color to use when the button is checked and selected and gradients
//        //     are being used.
//        //
//        // Returns:
//        //     A System.Drawing.Color that is the solid color to use when the button is checked
//        //     and selected and gradients are being used.
//        [SRDescriptionAttribute("ProfessionalColorsCheckPressedBackgroundDescr")]
//        public virtual Color CheckPressedBackground { get; }
//        //
//        // Summary:
//        //     Gets the color to use for shadow effects on the grip (move handle).
//        //
//        // Returns:
//        //     A System.Drawing.Color that is the color to use for shadow effects on the grip
//        //     (move handle).
//        [SRDescriptionAttribute("ProfessionalColorsGripDarkDescr")]
//        public virtual Color GripDark { get; }
//        //
//        // Summary:
//        //     Gets the color to use for highlight effects on the grip (move handle).
//        //
//        // Returns:
//        //     A System.Drawing.Color that is the color to use for highlight effects on the
//        //     grip (move handle).
//        [SRDescriptionAttribute("ProfessionalColorsGripLightDescr")]
//        public virtual Color GripLight { get; }
//        //
//        // Summary:
//        //     Gets the starting color of the gradient used in the image margin of a System.Windows.Forms.ToolStripDropDownMenu.
//        //
//        // Returns:
//        //     A System.Drawing.Color that is the starting color of the gradient used in the
//        //     image margin of a System.Windows.Forms.ToolStripDropDownMenu.
//        [SRDescriptionAttribute("ProfessionalColorsImageMarginGradientBeginDescr")]
//        public virtual Color ImageMarginGradientBegin { get; }
//        //
//        // Summary:
//        //     Gets the middle color of the gradient used in the image margin of a System.Windows.Forms.ToolStripDropDownMenu.
//        //
//        // Returns:
//        //     A System.Drawing.Color that is the middle color of the gradient used in the image
//        //     margin of a System.Windows.Forms.ToolStripDropDownMenu.
//        [SRDescriptionAttribute("ProfessionalColorsImageMarginGradientMiddleDescr")]
//        public virtual Color ImageMarginGradientMiddle { get; }
//        //
//        // Summary:
//        //     Gets the end color of the gradient used in the image margin of a System.Windows.Forms.ToolStripDropDownMenu.
//        //
//        // Returns:
//        //     A System.Drawing.Color that is the end color of the gradient used in the image
//        //     margin of a System.Windows.Forms.ToolStripDropDownMenu.
//        [SRDescriptionAttribute("ProfessionalColorsImageMarginGradientEndDescr")]
//        public virtual Color ImageMarginGradientEnd { get; }
//        //
//        // Summary:
//        //     Gets the middle color of the gradient used when the button is selected.
//        //
//        // Returns:
//        //     A System.Drawing.Color that is the middle color of the gradient used when the
//        //     button is selected.
//        [SRDescriptionAttribute("ProfessionalColorsButtonSelectedGradientMiddleDescr")]
//        public virtual Color ButtonSelectedGradientMiddle { get; }
//        //
//        // Summary:
//        //     Gets the end color of the gradient used in the System.Windows.Forms.ToolStripOverflowButton.
//        //
//        // Returns:
//        //     A System.Drawing.Color that is the end color of the gradient used in the System.Windows.Forms.ToolStripOverflowButton.
//        [SRDescriptionAttribute("ProfessionalColorsOverflowButtonGradientEndDescr")]
//        public virtual Color OverflowButtonGradientEnd { get; }
//    }
//}