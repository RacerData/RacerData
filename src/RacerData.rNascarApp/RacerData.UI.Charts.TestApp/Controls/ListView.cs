using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using RacerData.WinForms.Models;
using rNascarApp.UI.Models;

namespace RacerData.WinForms.Controls
{
    public partial class ListView : UserControl, IListView
    {
        #region events

        public event EventHandler<string> SetViewHeaderRequest;
        protected virtual void OnSetViewHeaderRequest(string headerText)
        {
            var handler = SetViewHeaderRequest;
            handler?.Invoke(this, headerText);
        }

        public event EventHandler<RemoveViewRequestEventArgs> RemoveViewRequest;
        protected virtual void OnRemoveViewRequest(int index)
        {
            var handler = RemoveViewRequest;
            handler?.Invoke(this, new RemoveViewRequestEventArgs(index));
        }

        public event EventHandler<BeginViewResizeRequestEventArgs> BeginViewResizeRequest;
        protected virtual void OnBeginViewResizeRequest(Point point, ResizeDirection resizeDirection)
        {
            var handler = BeginViewResizeRequest;
            handler?.Invoke(this, new BeginViewResizeRequestEventArgs(point, resizeDirection));
        }

        public event EventHandler<ViewResizeRequestEventArgs> ViewResizeRequest;
        protected virtual void OnViewResizeRequest(Point point, ResizeDirection resizeDirection)
        {
            var handler = ViewResizeRequest;
            handler?.Invoke(this, new ViewResizeRequestEventArgs(point, resizeDirection));
        }

        public event EventHandler<EndViewResizeRequestEventArgs> EndViewResizeRequest;
        protected virtual void OnEndViewResizeRequest(bool cancelled, Point point, ResizeDirection resizeDirection)
        {
            var handler = EndViewResizeRequest;
            if (cancelled)
            {
                handler?.Invoke(this, new EndViewResizeRequestEventArgs(cancelled));
            }
            else
            {
                handler?.Invoke(this, new EndViewResizeRequestEventArgs(point, resizeDirection));
            }
        }

        public event EventHandler<ControlMovedEventArgs> RowMoved;
        protected virtual void OnRowMoved(int oldIndex, int newIndex)
        {
            var handler = RowMoved;

            handler?.Invoke(this, new ControlMovedEventArgs() { OldIndex = oldIndex, NewIndex = newIndex });
        }

        public event EventHandler<RowResizedEventArgs> RowResized;
        protected virtual void OnRowResized(int rowIndex, Size size)
        {
            var handler = RowResized;

            var e = new RowResizedEventArgs()
            {
                RowIndex = rowIndex,
                Size = size
            };

            handler?.Invoke(this, e);
        }

        public event EventHandler<RowResizedEventArgs> RowResizing;
        protected virtual void OnRowResizing(int rowIndex, Size size)
        {
            var handler = RowResizing;

            var e = new RowResizedEventArgs()
            {
                RowIndex = rowIndex,
                Size = size
            };

            handler?.Invoke(this, e);
        }

        #endregion

        #region fields

        private bool _isResizing = false;
        private ObservableCollection<ListViewRow> _rows { get; set; } = new ObservableCollection<ListViewRow>();

        #endregion

        #region properties

        //TODO: pass down to children
        public bool AllowResize { get; set; } = true;
        public bool AllowDrag { get; set; } = true;

        public IEnumerable<ListViewRow> OrderedControls
        {
            get
            {
                return _rows
                    .OrderBy(c => c.Location.X)
                    .ThenBy(c => c.Location.Y);
            }
        }

        #endregion

        #region ctor/load

        public ListView()
        {
            InitializeComponent();

            RowResized += ListView_RowsResized;
            RowResizing += ListView_RowResizing;
        }

        private void ListView_Load(object sender, EventArgs e)
        {

        }

        #endregion

        #region public

        #region rows
        public virtual void ClearRows()
        {
            for (int i = _rows.Count - 1; i >= 0; i--)
            {
                RemoveRowAt(i);
            }
        }

        public virtual void AddRows(IEnumerable<ListViewRow> rows)
        {
            foreach (ListViewRow row in rows)
            {
                AddRow(row);
            }
        }
        public int AddRow(ListViewRow row)
        {
            if (row == null)
                throw new ArgumentNullException(nameof(row));

            InsertRowAt(_rows.Count, row);

            return _rows.Count - 1;
        }

        public void InsertRowAt(int index, ListViewRow row)
        {
            if (row == null)
                throw new ArgumentNullException(nameof(row));

            if (index > 0 && index < _rows.Count)
                throw new IndexOutOfRangeException(nameof(index));

            _rows.Insert(index, row);

            ConfigureResizableRow(row);

            row.ControlMoved += DraggableContainer1_ControlMoved;
            row.ControlsResized += DraggableContainer1_ControlsResized;

            this.Controls.Add(row);

            row.Show();
        }

        public virtual void RemoveRowAt(int index)
        {
            if (index < 0 && index > _rows.Count)
                throw new IndexOutOfRangeException(nameof(index));

            var row = _rows[index];

            if (row == null)
                throw new Exception($"Row at position {index} is invalid");

            RemoveRow(row);
        }
        public virtual void RemoveRow(ListViewRow row)
        {
            if (row == null)
                return;

            row.ClearDraggableControls();

            row.ControlMoved -= DraggableContainer1_ControlMoved;
            row.ControlsResized -= DraggableContainer1_ControlsResized;

            _rows.Remove(row);

            row.Dispose();
        }

        public void MoveRow(int oldIndex, int newIndex)
        {
            if (oldIndex == 0)
                throw new InvalidOperationException("Cannot move list title");

            if (oldIndex == 1)
                throw new InvalidOperationException("Cannot move column captions row");

            MoveRow(oldIndex, newIndex, true);
        }

        public void ResizeRows(IDictionary<int, Size> sizes)
        {
            var ordered = OrderedControls.ToList();

            if (sizes.Count != ordered.Count)
                throw new ArgumentException("Row list count mismatch", nameof(sizes));

            for (int i = 0; i < ordered.Count(); i++)
            {
                ordered[i].Size = sizes[i];
            }
        }
        #endregion /* rows */

        #region columns

        public virtual void ClearColumns()
        {
            foreach (ListViewRow row in _rows)
            {
                if (!row.IsListTitle)
                    row.ClearDraggableControls();
            }
        }

        public virtual void AddColumns(IEnumerable<ListViewColumnInfo> columns)
        {
            foreach (ListViewColumnInfo columnInfo in columns)
            {
                AddColumn(columnInfo);
            }
        }

        public virtual void AddColumn(ListViewColumnInfo columnInfo)
        {
            if (columnInfo == null)
                throw new ArgumentNullException(nameof(columnInfo));

            foreach (ListViewRow row in _rows)
            {
                if (!row.IsListTitle)
                {
                    var text = row.IsColumnCaptions ?
                       columnInfo.Caption :
                       $"[{columnInfo.Caption}]";

                    var column = BuildListViewCellFromInfo(columnInfo, row.Height, text);

                    row.AddDraggableControl(column);
                }
            }
        }

        public virtual void InsertColumnAt(int index, ListViewColumnInfo columnInfo)
        {
            if (columnInfo == null)
                throw new ArgumentNullException(nameof(columnInfo));

            foreach (ListViewRow row in _rows)
            {
                if (!row.IsListTitle)
                {
                    var text = row.IsColumnCaptions ?
                        $"[{index}] {columnInfo.Caption}" :
                        $"[{columnInfo.Caption}]";

                    var column = BuildListViewCellFromInfo(columnInfo, row.Height, text);

                    row.InsertDraggableControlAt(index, column);
                }
            }
        }

        public virtual void RemoveColumnAt(int index)
        {
            foreach (ListViewRow row in _rows)
            {
                if (!row.IsListTitle)
                    row.RemoveDraggableControlAt(index);
            }
        }

        #endregion /* columns */

        #endregion

        #region protected

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams handleParam = base.CreateParams;
                handleParam.ExStyle |= 0x02000000;   // WS_EX_COMPOSITED       
                return handleParam;
            }
        }

        protected virtual ListViewCell BuildListViewCellFromInfo(ListViewColumnInfo info, int rowHeight, string text)
        {
            var column = new ListViewCell();

            column.Size = new Size(100, rowHeight);
            column.Location = new Point(0, 0);
            column.BorderStyle = BorderStyle.FixedSingle;
            column.BackColor = Color.Magenta;
            column.AllowDrop = true;
            column.CellLabel.Text = text;

            return column;
        }

        protected virtual void ConfigureResizableRow(ListViewRow row)
        {
            if (!row.AllowResize)
                return;

            PictureBox resizeHandle = new PictureBox();
            resizeHandle.BackColor = Color.Transparent;
            resizeHandle.Size = new Size(row.Width, 5);
            resizeHandle.Location = new Point(0, row.Height - resizeHandle.Height - 1);
            resizeHandle.Dock = DockStyle.Bottom;
            resizeHandle.Cursor = Cursors.SizeNS;

            resizeHandle.MouseDown += (s, e) =>
            {
                if (AllowResize)
                    _isResizing = true;
            };
            resizeHandle.MouseMove += (s, e) =>
            {
                if (_isResizing)
                {
                    PictureBox innerResizeHandle = (PictureBox)s;
                    ListViewRow parent = (ListViewRow)innerResizeHandle.Parent;
                    parent.Height = innerResizeHandle.Top + e.Y;

                    OnRowResizing(parent.DisplayIndex, parent.Size);
                }
            };
            resizeHandle.MouseUp += (s, e) =>
            {
                PictureBox innerResizeHandle = (PictureBox)s;
                ListViewRow parent = (ListViewRow)innerResizeHandle.Parent;
                parent.Height = innerResizeHandle.Top + e.Y;

                OnRowResized(parent.DisplayIndex, parent.Size);

                _isResizing = false;

                resizeHandle.BringToFront();
            };

            row.Controls.Add(resizeHandle);

            row.Resize += (s, e) =>
            {
                RecalculateControlPositions();
            };

            row.ControlMoved += (s, e) =>
            {
                resizeHandle.BringToFront();
            };

            row.ControlsResized += (s, e) =>
            {
                resizeHandle.BringToFront();
            };

            resizeHandle.BringToFront();
        }

        protected virtual void MoveRow(int oldIndex, int newIndex, bool suppressEvents)
        {
            _rows.Move(oldIndex, newIndex);

            if (!suppressEvents)
                OnRowMoved(oldIndex, newIndex);
        }

        protected virtual void RecalculateControlPositions()
        {
            int runningY = 0;

            for (int i = 0; i < _rows.Count; i++)
            {
                Control control = _rows[i];

                control.Location = new Point(control.Location.X, runningY);

                runningY += control.Height;
            }
        }

        protected virtual void ResizeDraggableRows(int rowIndex, Size size)
        {
            if (rowIndex < 0 || rowIndex > _rows.Count - 1)
                throw new IndexOutOfRangeException(nameof(rowIndex));

            var resizedRow = _rows.FirstOrDefault(r => r.DisplayIndex == rowIndex);

            // Allow the column caption row and title row to be resized, but not affecty other row sizes.
            if (!resizedRow.IsColumnCaptions && !resizedRow.IsListTitle)
            {
                var ordered = _rows.OrderBy(r => r.DisplayIndex);

                for (int i = 0; i < ordered.Count(); i++)
                {
                    if (i != rowIndex)
                    {
                        var row = _rows.FirstOrDefault(r => r.DisplayIndex == i);

                        if (row.AllowResize && !row.IsColumnCaptions && !row.IsListTitle)
                        {
                            row.Size = size;

                            row.ResizeDraggableControls(row.Size.Height);
                        }
                    }
                }
            }
        }

        #endregion

        #region private

        private void DraggableContainer1_ControlsResized(object sender, ControlResizedEventArgs e)
        {
            foreach (ListViewRow row in _rows)
            {
                if (sender != row && !row.IsListTitle)
                    row.ResizeDraggableControls(e.NewPositions);
            }
        }

        private void DraggableContainer1_ControlMoved(object sender, ControlMovedEventArgs e)
        {
            foreach (ListViewRow row in _rows)
            {
                if (sender != row && !row.IsListTitle)
                    row.MoveDraggableControl(e.OldIndex, e.NewIndex);
            }
        }

        /// <summary>
        /// Updates the other rows in the list after a single row has been resized.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListView_RowsResized(object sender, RowResizedEventArgs e)
        {
            ResizeDraggableRows(e.RowIndex, e.Size);
        }

        /// <summary>
        /// Updates the column heights for the single row while it is being resized.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListView_RowResizing(object sender, RowResizedEventArgs e)
        {
            _rows[e.RowIndex].ResizeDraggableControls(e.Size.Height);
        }

        #endregion
    }
}
