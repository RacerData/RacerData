using System.Drawing;
using System.Windows.Forms;

namespace RacerData.WinForms.Controls
{
    public partial class ListViewRow : DraggableContainer
    {
        #region properties

        internal PictureBox ResizeHandle { get; set; }
        internal bool IsResizing { get; set; } = false;
        public bool IsColumnCaptions { get; set; }
        public int DisplayIndex { get; set; }

        #endregion

        #region ctor

        public ListViewRow()
        {
            InitializeComponent();

            ConfigureResizeHandle();
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
                    ListView parentListView = (ListView)this.Parent;
                    parentListView.OnRowResizing(DisplayIndex, Size);
                }
            };

            ResizeHandle.MouseUp += (s, e) =>
            {
                Height = ResizeHandle.Top + e.Y;
                ListView parentListView = (ListView)this.Parent;
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
            ListViewCell listViewCell = e.Control as ListViewCell;

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
