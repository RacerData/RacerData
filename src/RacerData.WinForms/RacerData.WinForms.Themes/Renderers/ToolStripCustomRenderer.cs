using System.Drawing;
using System.Windows.Forms;
using RacerData.WinForms.Themes.Models;

namespace RacerData.WinForms.Themes.Renderers
{
    public class ToolStripCustomRenderer : ToolStripProfessionalRenderer
    {
        #region prioperties

        public static Color MenuTextColor = default(Color);
        public static Color SelectedMenuTextColor = default(Color);
        public static Color CheckedButtonBorderColor = default(Color);
        public static Color CheckedBorderColor = default(Color);
        public static Color ButtonClickBackColor = default(Color);

        #endregion

        #region ctor

        public ToolStripCustomRenderer()
            : base()
        {

        }

        public ToolStripCustomRenderer(ProfessionalColorTable colorTable)
            : base(colorTable)
        {
            var textColorTable = colorTable as ISimpleColorTable;

            if (textColorTable != null)
            {
                MenuTextColor = textColorTable.ForeColor;
                SelectedMenuTextColor = textColorTable.MouseOverForeColor;
                CheckedButtonBorderColor = textColorTable.CheckedButtonBorderColor;
                CheckedBorderColor = textColorTable.CheckedBorderColor;
                ButtonClickBackColor = textColorTable.ButtonClickBackColor;
            }
        }

        #endregion

        #region protected

        protected override void OnRenderArrow(ToolStripArrowRenderEventArgs e)
        {
            e.ArrowColor = e.Item.Selected || e.Item.Pressed ? SelectedMenuTextColor : MenuTextColor; ;
            base.OnRenderArrow(e);
        }

        protected override void OnRenderItemCheck(ToolStripItemImageRenderEventArgs e)
        {
            base.OnRenderItemCheck(e);
            if (e.Item is ToolStripMenuItem)
            {
                ToolStripMenuItem item = e.Item as ToolStripMenuItem;
                if (item.CheckState != CheckState.Unchecked)
                {
                    Rectangle bounds = new Rectangle(e.ImageRectangle.Left - 2, 1, e.ImageRectangle.Width + 4, e.Item.Height - 2);
                    Graphics g = e.Graphics;
                    using (Pen p = new Pen(CheckedBorderColor))
                    {
                        g.DrawRectangle(p, bounds.X, bounds.Y, bounds.Width - 1, bounds.Height - 1);
                    }
                }
            }
        }

        protected override void OnRenderItemText(ToolStripItemTextRenderEventArgs e)
        {
            e.TextColor = e.Item.Selected || e.Item.Pressed ? SelectedMenuTextColor : MenuTextColor;
            base.OnRenderItemText(e);
        }

        protected override void OnRenderButtonBackground(ToolStripItemRenderEventArgs e)
        {
            base.OnRenderButtonBackground(e);

            ToolStripButton item = e.Item as ToolStripButton;
            Graphics g = e.Graphics;
            Rectangle bounds = new Rectangle(Point.Empty, item.Size);

            if (item.Pressed)
            {
                using (Brush b = new SolidBrush(ButtonClickBackColor))
                {
                    g.FillRectangle(b, bounds.X, bounds.Y, bounds.Width - 1, bounds.Height - 1);
                }
            }

            if (item.CheckState == CheckState.Checked)
            {
                using (Pen p = new Pen(CheckedButtonBorderColor))
                {
                    g.DrawRectangle(p, bounds.X, bounds.Y, bounds.Width - 1, bounds.Height - 1);
                }
            }
        }

        #endregion
    }
}
