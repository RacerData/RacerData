using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using RacerData.WinForms.Models;

namespace RacerData.WinForms.Controls
{
    public partial class LeaderboardViewRow : DraggableContainer
    {
        #region properties

        internal PictureBox ResizeHandle { get; set; }
        internal bool IsResizing { get; set; } = false;
        public bool IsColumnCaptions { get; set; }
        public int DisplayIndex { get; set; }

        #endregion

        #region ctor

        public LeaderboardViewRow()
        {
            InitializeComponent();

            ConfigureResizeHandle();
        }

        #endregion

        #region internal

        internal void ApplyTheme(ApplicationAppearance appearance)
        {
            this.BackColor = appearance.ListAppearance.BackColor;

            Models.Appearance listAppearance = null;

            if (IsColumnCaptions)
            {
                listAppearance = appearance.ListAppearance;
            }
            else
            {
                listAppearance = DisplayIndex % 2 == 0 ?
                              appearance.ListAppearance.ListItemAppearance :
                              appearance.ListAppearance.AlternatingListItemAppearance;
            }


            foreach (LeaderboardViewCell field in OrderedControls.OfType<LeaderboardViewCell>().ToList())
            {
                field.CellLabel.BackColor = listAppearance.BackColor;
                field.CellLabel.ForeColor = listAppearance.ForeColor;
                field.CellLabel.Font = listAppearance.Font;
            }
        }

        #endregion

        #region protected

        protected virtual void ConfigureResizeHandle()
        {
            ResizeHandle = new PictureBox();

            ResizeHandle.Name = "resizeHandle";
            ResizeHandle.Size = new Size(Width, 2);
            ResizeHandle.BackColor = Color.Transparent;
            ResizeHandle.Location = new Point(0, Height - ResizeHandle.Height - 1);
            ResizeHandle.Dock = DockStyle.Bottom;
            ResizeHandle.Cursor = Cursors.SizeNS;

            ResizeHandle.MouseDown += (s, e) =>
            {
                if (AllowResize)
                    IsResizing = true;
            };

            ResizeHandle.MouseMove += (s, e) =>
            {
                if (IsResizing)
                {
                    Height = ResizeHandle.Top + e.Y;
                    LeaderboardView parentListView = (LeaderboardView)this.Parent;
                    parentListView.OnRowResizing(DisplayIndex, Size);
                }
            };

            ResizeHandle.MouseUp += (s, e) =>
            {
                Height = ResizeHandle.Top + e.Y;
                LeaderboardView parentListView = (LeaderboardView)this.Parent;
                parentListView.OnRowResized(DisplayIndex, Size);

                IsResizing = false;
            };

            ResizeHandle.MouseLeave += (s, e) =>
            {
                ResizeHandle.SendToBack();
                Cursor = Cursors.Default;
                IsResizing = false;
            };

            Controls.Add(ResizeHandle);
        }

        protected virtual void ListViewRow_ControlAdded(object sender, ControlEventArgs e)
        {
            LeaderboardViewCell listViewCell = e.Control as LeaderboardViewCell;

            if (listViewCell != null)
            {
                listViewCell.MouseEnter += (s, mouseEnterArgs) =>
                {
                    this.OnMouseEnter(mouseEnterArgs);
                };
                listViewCell.MouseLeave += (s, mouseEnterArgs) =>
                {
                    this.OnMouseLeave(mouseEnterArgs);
                };
            }
        }

        #endregion
    }
}
