using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RacerData.WinForms.Models;

namespace RacerData.WinForms.Controls
{
    public partial class DraggableContainer : UserControl
    {
        #region events

        public event EventHandler<ControlMovedEventArgs> ControlMoved;
        protected virtual void OnControlMoved(int oldIndex, int newIndex)
        {
            var handler = ControlMoved;

            handler?.Invoke(this, new ControlMovedEventArgs() { OldIndex = oldIndex, NewIndex = newIndex });
        }

        public event EventHandler<ControlResizedEventArgs> ControlsResized;
        protected virtual void OnControlsResized()
        {
            var handler = ControlsResized;

            var e = new ControlResizedEventArgs();

            var ordered = OrderedControls.ToList();

            e.NewPositions = new Rectangle[ordered.Count];

            for (int i = 0; i < ordered.Count(); i++)
            {
                var c = ordered[i];
                e.NewPositions[i] = new Rectangle(c.Location, c.Size);
            }

            handler?.Invoke(this, e);
        }

        #endregion

        #region fields

        private bool _isResizing = false;
        private Point _dragPointToClient = Point.Empty;
        private Timer _dragTimer;
        private Panel _dragFrame;
        private Point _dragPoint = Point.Empty;
        private ObservableCollection<Control> _draggableControls { get; set; } = new ObservableCollection<Control>();

        #endregion

        #region properties

        public bool AllowResize { get; set; } = true;
        public bool AllowDrag { get; set; } = true;
        public IEnumerable<Control> OrderedControls
        {
            get
            {
                return _draggableControls.OrderBy(c => c.Location.X);
            }
        }

        #endregion

        #region ctor / load

        public DraggableContainer()
        {
            InitializeComponent();
        }

        private void DraggableContainer_Load(object sender, EventArgs e)
        {
            _draggableControls.CollectionChanged += (s, collectionArgs) =>
            {
                RecalculateControlPositions();
            };

            _dragFrame = new Panel()
            {
                Visible = false,
                BorderStyle = BorderStyle.FixedSingle
            };

            _dragTimer = new Timer();
            _dragTimer.Interval = 20;

            _dragTimer.Tick += (s, tickArgs) =>
            {
                if ((Control.MouseButtons & MouseButtons.Left) == MouseButtons.None)
                {
                    _dragFrame.Hide();
                    _dragTimer.Stop();
                }

                if (_dragFrame.Visible)
                {
                    Point pt = PointToClient(Cursor.Position);

                    _dragFrame.Location = new Point(
                        pt.X - _dragPoint.X,
                        pt.Y + 3);
                }
            };
        }

        #endregion

        #region public

        public virtual void ClearDraggableControls()
        {
            for (int i = _draggableControls.Count - 1; i >= 0; i--)
            {
                RemoveDraggableControlAt(i);
            }
        }

        public virtual void AddDraggableControls(IEnumerable<Control> controls)
        {
            foreach (Control control in controls)
            {
                AddDraggableControl(control);
            }
        }
        public virtual void AddDraggableControl(Control control)
        {
            if (control == null)
                return;

            InsertDraggableControlAt(_draggableControls.Count, control);
        }

        public virtual void InsertDraggableControlAt(int index, Control control)
        {
            if (control == null)
                return;

            if (index < 0 && index > _draggableControls.Count)
                throw new IndexOutOfRangeException(nameof(index));

            ConfigureResizableControl(control);
            ConfigureDraggableControl(control);

            _draggableControls.Insert(index, control);

            this.Controls.Add(control);
            this.Controls.SetChildIndex(control, index);
        }

        public virtual void RemoveDraggableControlAt(int index)
        {
            if (index < 0 && index > _draggableControls.Count)
                throw new IndexOutOfRangeException(nameof(index));

            var draggableControl = _draggableControls[index];

            if (draggableControl == null)
                throw new Exception($"Control at position {index} is invalid");

            RemoveDraggableControl(draggableControl);
        }
        public virtual void RemoveDraggableControl(Control control)
        {
            if (control == null)
                return;

            this.Controls.Remove(control);
            _draggableControls.Remove(control);

            control.Dispose();
        }

        public void MoveDraggableControl(int oldIndex, int newIndex)
        {
            MoveDraggableControl(oldIndex, newIndex, true);
        }

        public void ResizeDraggableControls(Rectangle[] positions)
        {
            var ordered = OrderedControls.ToList();

            if (positions.Length != ordered.Count)
                throw new ArgumentException("Control list count mismatch", nameof(positions));

            for (int i = 0; i < ordered.Count(); i++)
            {
                ordered[i].Location = positions[i].Location;
                ordered[i].Size = positions[i].Size;
            }
        }

        public void ResizeDraggableControls(int height)
        {
            var ordered = OrderedControls.ToList();

            for (int i = 0; i < ordered.Count(); i++)
            {
                ordered[i].Height = height;
            }
        }

        #endregion

        #region protected

        protected virtual void ReIndexControls()
        {
            var controls = Controls.OfType<ListViewCell>().ToList();

            foreach (ListViewCell lv in controls)
            {
                var lvIndex = Controls.IndexOf(lv);

                var dc = _draggableControls.OfType<ListViewCell>().FirstOrDefault(d => d.CellLabel.Text == lv.CellLabel.Text);

                var dcIndex = _draggableControls.IndexOf(dc);

                Controls.SetChildIndex(lv, dcIndex);
            }

            IndexReport("ReIndexControls");
        }

        protected virtual void MoveDraggableControl(int oldIndex, int newIndex, bool suppressEvents)
        {
            _draggableControls.Move(oldIndex, newIndex);
            var moved = Controls[oldIndex];
            Controls.SetChildIndex(moved, newIndex);

            if (!suppressEvents)
                OnControlMoved(oldIndex, newIndex);
        }

        protected virtual void ConfigureDraggableControl(Control ctx)
        {
            ctx.MouseDown += (s, e) =>
            {
                if (!AllowDrag)
                    return;

                if (e.Button == MouseButtons.Left)
                {
                    _dragPoint = e.Location;

                    _dragTimer.Start();

                    _dragFrame.Size = ctx.Size;

                    Point pt = this.PointToClient(Cursor.Position);

                    _dragPointToClient = pt;

                    _dragFrame.Location = new Point(
                        pt.X - _dragPoint.X,
                        pt.Y + 3);

                    if (_dragFrame.BackgroundImage != null)
                        _dragFrame.BackgroundImage.Dispose();

                    Bitmap bmp = new Bitmap(_dragFrame.ClientSize.Width,
                                            _dragFrame.ClientSize.Height);

                    ctx.DrawToBitmap(bmp, _dragFrame.ClientRectangle);

                    _dragFrame.BackgroundImage = bmp;

                    _dragFrame.BringToFront();
                    _dragFrame.Show();

                    ctx.DoDragDrop(ctx, DragDropEffects.Move);
                }
            };

            ctx.DragOver += (s, e) =>
            {
                e.Effect = DragDropEffects.Move;
            };

            ctx.MouseUp += (s, e) =>
            {
                if (e.Button == MouseButtons.Left)
                {
                    _dragFrame.Hide();
                    _dragTimer.Stop();
                }
            };

            ctx.Leave += (s, e) =>
            {
                _dragFrame.Hide();
                _dragTimer.Stop();
            };

            ctx.DragDrop += (s, e) =>
            {
                _dragFrame?.Hide();
                _dragTimer.Stop();

                Control source = e.Data.GetData(e.Data.GetFormats()[0]) as Control;

                var originalIndex = _draggableControls.IndexOf(source);

                Control target = (Control)s;

                var newIndex = _draggableControls.IndexOf(target);

                MoveDraggableControl(originalIndex, newIndex, false);
            };
        }

        protected virtual void ConfigureResizableControl(Control control)
        {
            PictureBox resizeHandle = new PictureBox();
            resizeHandle.BackColor = Color.Transparent;
            resizeHandle.Size = new Size(4, 10);
            resizeHandle.Location = new Point(control.Width - resizeHandle.Width + 2, control.Height - resizeHandle.Height);
            resizeHandle.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            resizeHandle.Dock = DockStyle.Right;
            resizeHandle.Cursor = Cursors.SizeWE;

            resizeHandle.MouseDown += (s, e) =>
            {
                if (AllowResize)
                    _isResizing = true;
            };
            resizeHandle.MouseMove += (s, e) =>
            {
                if (_isResizing)
                {
                    PictureBox pictureBox = (PictureBox)s;
                    Control parent = (Control)pictureBox.Parent;
                    parent.Width = pictureBox.Left + e.X;

                    OnControlsResized();
                }
            };
            resizeHandle.MouseUp += (s, e) =>
            {
                _isResizing = false;
            };

            control.Controls.Add(resizeHandle);

            control.Resize += (s, e) =>
            {
                RecalculateControlPositions();
            };

            resizeHandle.BringToFront();
        }

        protected virtual void RecalculateControlPositions()
        {
            int runningX = 0;

            for (int i = 0; i < _draggableControls.Count; i++)
            {
                Control control = _draggableControls[i];

                control.Location = new Point(runningX, control.Location.Y);

                runningX += control.Width;
            }

            IndexReport("RecalculateControlPositions");
            ReIndexControls();
        }

        private void DraggableContainer_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void DraggableContainer_DragDrop(object sender, DragEventArgs e)
        {
            _dragFrame?.Hide();
            _dragTimer.Stop();

            Control source = e.Data.GetData(e.Data.GetFormats()[0]) as Control;

            var originalIndex = _draggableControls.IndexOf(source);

            MoveDraggableControl(originalIndex, _draggableControls.Count - 1, false);
        }

        #endregion

        #region private

        private void IndexReport(string action)
        {
#if DEBUG
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"====== {action} ========");

            for (int i = 0; i < Controls.OfType<ListViewCell>().Count(); i++)
            {
                var c = Controls.OfType<ListViewCell>().ToList()[i];
                var d = _draggableControls.OfType<ListViewCell>().ToList()[i];
                var flag = (c.CellLabel.Text != d.CellLabel.Text) ? "*************************" : "";
                sb.AppendLine($"Index: {i}  Control {c.CellLabel.Text} : Draggable {d.CellLabel.Text} {flag}");
            }

            sb.AppendLine("==============");

            Console.WriteLine(sb.ToString());
#endif 
        }

        #endregion
    }
}
