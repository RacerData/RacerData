using System.Drawing;
using System.Windows.Forms;
using RacerData.Themes.UI.ColorTables;

namespace RacerData.Themes.UI.Renderers
{
    public class CustomProToolStripSystemRenderer2 : ToolStripProfessionalRenderer
    {
        public static Color MenuTextColor = Color.Silver;
        public static Color SelectedMenuTextColor = Color.GhostWhite;

        public CustomProToolStripSystemRenderer2()
            : base()
        {

        }

        public CustomProToolStripSystemRenderer2(ProfessionalColorTable colorTable)
            : base(colorTable)
        {
            var textColorTable = colorTable as IColorTableText;

            if (textColorTable != null)
            {
                MenuTextColor = textColorTable.ForeColor;
                SelectedMenuTextColor = textColorTable.MouseOverForeColo;
            }
        }

        /// <summary>
        /// Hide the border
        /// </summary>
        /// <param name="e"></param>
        protected override void OnRenderToolStripBorder(ToolStripRenderEventArgs e)
        {
            // comment out to prevent toolstrip border from being drawn
            //base.OnRenderToolStripBorder(e);               
        }

        /// <summary>
        /// Renders the drop-down V and sub-menu -> arrow
        /// </summary>
        /// <param name="e"></param>
        protected override void OnRenderArrow(ToolStripArrowRenderEventArgs e)
        {
            e.ArrowColor = e.Item.Selected || e.Item.Pressed ? SelectedMenuTextColor : MenuTextColor; ;
            base.OnRenderArrow(e);
        }

        protected override void OnRenderItemImage(ToolStripItemImageRenderEventArgs e)
        {
            var e2= e.Image;
            base.OnRenderItemImage(e);
        }

        /// <summary>
        /// Renders the text for all menustrip/toolstrip/statusbar items
        /// </summary>
        /// <param name="e"></param>
        protected override void OnRenderItemText(ToolStripItemTextRenderEventArgs e)
        {
            e.TextColor = e.Item.Selected || e.Item.Pressed ? SelectedMenuTextColor : MenuTextColor;
            base.OnRenderItemText(e);
        }
    }


    public class CustomProToolStripSystemRenderer : ToolStripProfessionalRenderer
    {
        public static Color PanelBlue = Color.FromArgb(255, 51, 153, 255);
        public static Color IconBlue = Color.FromArgb(255, 122, 193, 255);

        public static Color LightLightGrey = Color.FromArgb(255, 104, 104, 104);
        public static Color LightGrey = Color.FromArgb(255, 63, 63, 70);
        public static Color MediumGrey = Color.FromArgb(255, 45, 45, 48);
        public static Color DarkGrey = Color.FromArgb(255, 37, 37, 38);
        public static Color DarkDarkGrey = Color.FromArgb(255, 28, 28, 28);

        public static Color SeparatorBackColor = LightGrey;

        public static Color BorderColor = LightLightGrey;

        public static Color MenuItemBackColor = MediumGrey;
        public static Color SelectedMenuItemBackColor = LightGrey;

        public static Color MenuItemText = Color.Silver;
        public static Color SelecedMenuItemText = Color.GhostWhite;

        public static Color CheckBorderColor = BorderColor;
        public static Color CheckBackColor = LightLightGrey;
        public static Color CheckHoverBackColor = LightGrey;


        public CustomProToolStripSystemRenderer()
            : base()
        {

        }
        public CustomProToolStripSystemRenderer(ProfessionalColorTable colorTable)
            : base(colorTable)
        {

        }
        /// <summary>
        /// Hide the border
        /// </summary>
        /// <param name="e"></param>
        protected override void OnRenderToolStripBorder(ToolStripRenderEventArgs e)
        {
            // comment to prevent toolstrip border from being drawn
            //base.OnRenderToolStripBorder(e);               
        }

        /// <summary>
        /// Renders the drop-down V and sub-menu -> arrow
        /// </summary>
        /// <param name="e"></param>
        protected override void OnRenderArrow(ToolStripArrowRenderEventArgs e)
        {
            e.ArrowColor = MenuItemText;
            base.OnRenderArrow(e);
        }

        /// <summary>
        /// Renders the text for all menustrip/toolstrip/statusbar items
        /// </summary>
        /// <param name="e"></param>
        protected override void OnRenderItemText(ToolStripItemTextRenderEventArgs e)
        {
            e.TextColor = e.Item.Selected ? SelecedMenuItemText : MenuItemText;
            base.OnRenderItemText(e);
        }

        /// <summary>
        /// Border surrounding all drop down menu items
        /// Can be overwritten by ImageMargin
        /// </summary>
        /// <param name="e"></param>
        protected override void OnRenderToolStripBackground(ToolStripRenderEventArgs e)
        {
            ToolStripDropDown dr = e.ToolStrip as ToolStripDropDown;

            if (dr != null)
            {
                Rectangle rc = e.AffectedBounds;
                Color c = BorderColor;
                using (SolidBrush brush = new SolidBrush(c))
                    e.Graphics.FillRectangle(brush, rc);

                rc.Inflate(-1, -1);
                Color cInner = CheckBackColor;
                using (SolidBrush brush = new SolidBrush(cInner))
                    e.Graphics.FillRectangle(brush, rc);
            }
        }

        /// <summary>
        /// Vertical line on far right of menu item
        /// </summary>
        /// <param name="e"></param>
        protected override void OnRenderImageMargin(ToolStripRenderEventArgs e)
        {
            Rectangle rc = new Rectangle(Point.Empty, e.AffectedBounds.Size);
            Color c = CheckBorderColor;
            using (SolidBrush brush = new SolidBrush(c))
                e.Graphics.FillRectangle(brush, rc);

            rc.Inflate(-1, -1);
            Color cInner = MenuItemBackColor;
            using (SolidBrush brush = new SolidBrush(cInner))
                e.Graphics.FillRectangle(brush, rc);
        }
        /// <summary>
        /// Background color for non-separator items
        /// </summary>
        /// <param name="e"></param>
        protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
        {
            Rectangle rc = new Rectangle(new Point(1, 0), e.Item.Size);
            Color c = e.Item.Selected ? SelectedMenuItemBackColor : MenuItemBackColor;
            using (SolidBrush brush = new SolidBrush(c))
                e.Graphics.FillRectangle(brush, rc);
        }
    }
    public class BasicToolStripRenderer : ToolStripSystemRenderer
    {
        /// <summary>
        /// Hide the border
        /// </summary>
        /// <param name="e"></param>
        protected override void OnRenderToolStripBorder(ToolStripRenderEventArgs e)
        {
            // comment to prevent toolstrip border from being drawn
            //base.OnRenderToolStripBorder(e);               
        }
    }
    public class CustomToolStripRenderer : ToolStripSystemRenderer
    {
        // https://referencesource.microsoft.com/#system.windows.forms/winforms/managed/system/winforms/ToolStripRenderer.cs

        public static Color PanelBlue = Color.FromArgb(255, 51, 153, 255);
        public static Color IconBlue = Color.FromArgb(255, 122, 193, 255);

        public static Color LightLightGrey = Color.FromArgb(255, 104, 104, 104);
        public static Color LightGrey = Color.FromArgb(255, 63, 63, 70);
        public static Color MediumGrey = Color.FromArgb(255, 45, 45, 48);
        public static Color DarkGrey = Color.FromArgb(255, 37, 37, 38);
        public static Color DarkDarkGrey = Color.FromArgb(255, 28, 28, 28);

        public static Color UnselectedItemBackColor = MediumGrey;
        public static Color SelectedItemBackColor = PanelBlue;
        public static Color SeparatorBackColor = LightGrey;
        public static Color BorderColor = PanelBlue;

        public CustomToolStripRenderer() { }

        /// <summary>
        /// Hide the border
        /// </summary>
        /// <param name="e"></param>
        protected override void OnRenderToolStripBorder(ToolStripRenderEventArgs e)
        {
            // comment to prevent toolstrip border from being drawn
            //base.OnRenderToolStripBorder(e);               
        }

        /// <summary>
        /// Renders the drop-down arrow
        /// </summary>
        /// <param name="e"></param>
        protected override void OnRenderArrow(ToolStripArrowRenderEventArgs e)
        {
            e.ArrowColor = PanelBlue;
            base.OnRenderArrow(e);
        }

        /// <summary>
        /// Border surrounding all drop down menu items
        /// Can be overwritten by ImageMargin
        /// </summary>
        /// <param name="e"></param>
        protected override void OnRenderToolStripBackground(ToolStripRenderEventArgs e)
        {
            ToolStripDropDown dr = e.ToolStrip as ToolStripDropDown;

            if (dr != null)
            {
                Rectangle rc = e.AffectedBounds;
                Color c = BorderColor;
                using (SolidBrush brush = new SolidBrush(c))
                    e.Graphics.FillRectangle(brush, rc);

                rc.Inflate(-1, -1);
                Color cInner = UnselectedItemBackColor;
                using (SolidBrush brush = new SolidBrush(cInner))
                    e.Graphics.FillRectangle(brush, rc);
            }
        }

        /// <summary>
        /// Checked indicator image
        /// </summary>
        /// <param name="e"></param>
        protected override void OnRenderItemCheck(ToolStripItemImageRenderEventArgs e)
        {
            int width = 20;
            int height = 20;
            Bitmap selectedIndicator = new Bitmap(width, height);
            using (Graphics gfx = Graphics.FromImage(selectedIndicator))
            using (SolidBrush brush = new SolidBrush(IconBlue))
            {
                gfx.FillRectangle(brush, 0, 0, width, height);
            }

            var myE = new ToolStripItemImageRenderEventArgs(e.Graphics, e.Item, selectedIndicator, e.ImageRectangle);
            base.OnRenderItemCheck(myE);
        }

        /// <summary>
        /// Vertical line on far right of menu item
        /// </summary>
        /// <param name="e"></param>
        protected override void OnRenderImageMargin(ToolStripRenderEventArgs e)
        {
            Rectangle rc = new Rectangle(Point.Empty, e.AffectedBounds.Size);
            Color c = BorderColor;
            using (SolidBrush brush = new SolidBrush(c))
                e.Graphics.FillRectangle(brush, rc);

            rc.Inflate(-1, -1);
            Color cInner = UnselectedItemBackColor;
            using (SolidBrush brush = new SolidBrush(cInner))
                e.Graphics.FillRectangle(brush, rc);
        }

        /// <summary>
        /// Background color for non-separator items
        /// </summary>
        /// <param name="e"></param>
        protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
        {
            Rectangle rc = new Rectangle(new Point(1, 0), e.Item.Size);
            Color c = e.Item.Selected ? SelectedItemBackColor : UnselectedItemBackColor;
            using (SolidBrush brush = new SolidBrush(c))
                e.Graphics.FillRectangle(brush, rc);
        }

        /// <summary>
        /// Separator body
        /// </summary>
        /// <param name="e"></param>
        protected override void OnRenderSeparator(ToolStripSeparatorRenderEventArgs e)
        {
            if ((e.Item as ToolStripSeparator) == null)
            {
                base.OnRenderSeparator(e);
                return;
            }

            if (!e.Vertical)
            {
                ToolStripSeparator toolStripSeparator = (ToolStripSeparator)e.Item;
                int width = toolStripSeparator.Width;
                int height = toolStripSeparator.Height;
                e.Graphics.FillRectangle(new SolidBrush(SeparatorBackColor), 0, 0, width, height);
            }
            else
            {
                base.OnRenderSeparator(e);
            }
        }
    }
}
