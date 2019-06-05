using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using RacerData.WinForms.Models;
using RacerData.WinForms.Data;

namespace RacerData.WinForms.Controls
{
    public partial class LeaderboardView : UserControl, ILeaderboardView
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
        internal virtual void OnRowResized(int rowIndex, Size size)
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
        internal virtual void OnRowResizing(int rowIndex, Size size)
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

        #region consts

        private const int VerticalCellSpacing = 8;

        #endregion

        #region fields

        private readonly LeaderboardViewModel _viewModel;
        private ObservableCollection<LeaderboardViewRow> _rows { get; set; } = new ObservableCollection<LeaderboardViewRow>();

        #endregion



        #region properties

        private ApplicationAppearance _appearance;
        public virtual ApplicationAppearance Appearance
        {
            get
            {
                return _appearance;
            }
            set
            {
                _appearance = value;
                ApplyTheme(_appearance);
            }
        }

        public bool AllowResize { get; set; } = true;
        public bool AllowDrag { get; set; } = true;

        private ListViewData _dataValues;
        public ListViewData DataValues
        {
            get
            {
                return _dataValues;
            }
            set
            {
                _dataValues = value;
                DisplayDataValues(_dataValues);
            }
        }

        protected IEnumerable<LeaderboardViewRow> OrderedControls
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

        public LeaderboardView(LeaderboardViewModel viewModel)
            : this()
        {
            _viewModel = viewModel ?? throw new ArgumentNullException(nameof(viewModel));
        }

        public LeaderboardView()
        {
            InitializeComponent();

            RowResized += ListView_RowsResized;
            RowResizing += ListView_RowResizing;

            this.Dock = DockStyle.Fill;
            this.BorderStyle = BorderStyle.FixedSingle;
        }

        #endregion

        #region public

        public void BuildLeaderboardView(LeaderboardViewDefinition leaderboardViewDefinition)
        {
            if (leaderboardViewDefinition == null)
                return;

            var rowCount = 0;

            if (leaderboardViewDefinition.ShowCaptions)
            {
                var captionRow = new LeaderboardViewRow()
                {
                    IsColumnCaptions = true,
                    DisplayIndex = 0
                };

                AddRow(captionRow);

                rowCount++;
            }

            if (leaderboardViewDefinition.MaxRows.HasValue)
            {
                var dataRowCount = leaderboardViewDefinition.MaxRows.Value;

                for (int i = 0; i < dataRowCount; i++)
                {
                    var dataRow = new LeaderboardViewRow()
                    {
                        IsColumnCaptions = false,
                        DisplayIndex = i + rowCount
                    };

                    AddRow(dataRow);
                }
            }
            else
            {
                var dataRow0 = new LeaderboardViewRow()
                {
                    IsColumnCaptions = false,
                    DisplayIndex = rowCount
                };
                AddRow(dataRow0);
            }

            AddColumns(leaderboardViewDefinition.Columns);
        }

        #region rows
        public virtual void ClearRows()
        {
            for (int i = _rows.Count - 1; i >= 0; i--)
            {
                RemoveRowAt(i);
            }
        }

        public virtual void AddRows(IEnumerable<LeaderboardViewRow> rows)
        {
            foreach (LeaderboardViewRow row in rows)
            {
                AddRow(row);
            }
        }
        public int AddRow(LeaderboardViewRow row)
        {
            if (row == null)
                throw new ArgumentNullException(nameof(row));

            InsertRowAt(_rows.Count, row);

            return _rows.Count - 1;
        }

        public void InsertRowAt(int index, LeaderboardViewRow row)
        {
            if (row == null)
                throw new ArgumentNullException(nameof(row));

            if (index > 0 && index < _rows.Count)
                throw new IndexOutOfRangeException(nameof(index));

            _rows.Insert(index, row);

            ConfigureResizableRow(row);

            row.ControlMoved += DraggableContainer1_ControlMoved;
            row.ControlsResized += DraggableContainer1_ControlsResized;

            row.Dock = DockStyle.Top;

            row.Height = GetDefaultHeight(row).Height;

            this.Controls.Add(row);

            row.BringToFront();

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
        public virtual void RemoveRow(LeaderboardViewRow row)
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
            foreach (LeaderboardViewRow row in _rows)
            {
                row.ClearDraggableControls();
            }
        }

        public virtual void AddColumns(IEnumerable<LeaderboardViewColumn> columns)
        {
            foreach (LeaderboardViewColumn columnInfo in columns)
            {
                AddColumn(columnInfo);
            }
        }

        public virtual void AddColumn(LeaderboardViewColumn columnInfo)
        {
            if (columnInfo == null)
                throw new ArgumentNullException(nameof(columnInfo));

            var columnIndex = _rows[0].OrderedControls.Count();

            InsertColumnAt(columnIndex, columnInfo);
        }

        public virtual void InsertColumnAt(int index, LeaderboardViewColumn columnInfo)
        {
            if (columnInfo == null)
                throw new ArgumentNullException(nameof(columnInfo));

            foreach (LeaderboardViewRow row in _rows)
            {
                var text = row.IsColumnCaptions ?
                    $"[{index}] {columnInfo.Caption}" :
                    $"[{columnInfo.Caption}]";

                var column = BuildListViewCellFromInfo(columnInfo, row.Height, text);

                column.BorderStyle = BorderStyle.FixedSingle;

                row.InsertDraggableControlAt(index, column);
            }
        }

        public virtual void RemoveColumnAt(int index)
        {
            foreach (LeaderboardViewRow row in _rows)
            {
                row.RemoveDraggableControlAt(index);
            }
        }

        #endregion /* columns */

        #endregion

        #region protected

        protected virtual void ApplyTheme(ApplicationAppearance appearance)
        {
            if (appearance != null)
            {
                this.BackColor = appearance.DialogAppearance.BackColor;
                this.ForeColor = appearance.DialogAppearance.ForeColor;
                this.Font = appearance.DialogAppearance.Font;
            }
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams handleParam = base.CreateParams;
                handleParam.ExStyle |= 0x02000000;   // WS_EX_COMPOSITED       
                return handleParam;
            }
        }

        protected virtual LeaderboardViewCell BuildListViewCellFromInfo(LeaderboardViewColumn column, int rowHeight, string text)
        {
            var listViewCell = new LeaderboardViewCell();

            listViewCell.Size = new Size(100, rowHeight);
            listViewCell.Location = new Point(0, 0);
            listViewCell.BorderStyle = BorderStyle.FixedSingle;
            listViewCell.AllowDrop = true;
            listViewCell.CellLabel.Text = text;
            listViewCell.CellLabel.Font = new Font("Tahoma", 10, FontStyle.Bold);
            listViewCell.CellLabel.TextAlign = (System.Drawing.ContentAlignment)column.Alignment;

            return listViewCell;
        }

        protected virtual void ConfigureResizableRow(LeaderboardViewRow row)
        {
            if (!row.AllowResize)
                return;

            row.Resize += (s, e) =>
            {
                RecalculateControlPositions();
                ResizeChildren(s, e);
            };

            row.MouseEnter += (s, e) =>
            {
                foreach (LeaderboardViewRow listViewRow in Controls.OfType<LeaderboardViewRow>())
                {
                    if (listViewRow != s)
                    {
                        if (listViewRow.ResizeHandle != null)
                            listViewRow.ResizeHandle.SendToBack();
                    }
                }
            };
            row.MouseLeave += (s, e) =>
            {
                if (row.ResizeHandle != null)
                    row.ResizeHandle.SendToBack();
            };
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

        protected virtual void ResizeChildren(object sender, EventArgs e)
        {
            LeaderboardViewRow row = (LeaderboardViewRow)sender;
            foreach (LeaderboardViewCell listViewCell in row.OrderedControls.OfType<LeaderboardViewCell>())
            {
                listViewCell.Height = row.Height;
            }
        }

        protected virtual void ResizeDraggableRows(int rowIndex, Size size)
        {
            if (rowIndex < 0 || rowIndex > _rows.Count - 1)
                throw new IndexOutOfRangeException(nameof(rowIndex));

            var resizedRow = _rows.FirstOrDefault(r => r.DisplayIndex == rowIndex);

            // Allow the column caption row and title row to be resized, but not affecty other row sizes.
            if (!resizedRow.IsColumnCaptions)
            {
                var ordered = _rows.OrderBy(r => r.DisplayIndex);

                for (int i = 0; i < ordered.Count(); i++)
                {
                    if (i != rowIndex)
                    {
                        var row = _rows.FirstOrDefault(r => r.DisplayIndex == i);

                        if (row.AllowResize && !row.IsColumnCaptions)
                        {
                            row.Size = size;

                            row.ResizeDraggableControls(row.Size.Height);
                        }
                    }
                }
            }
        }

        protected virtual Size GetDefaultHeight(LeaderboardViewRow row)
        {
            return GetDefaultHeight(row, "X");
        }
        protected virtual Size GetDefaultHeight(LeaderboardViewRow row, string text)
        {
            Image fakeImage = new Bitmap(1, 1);
            Graphics graphics = Graphics.FromImage(fakeImage);
            SizeF size = graphics.MeasureString(text, row.Font);
            return new Size((int)size.Width, (int)size.Height + VerticalCellSpacing);
        }

        protected virtual void BuildListDisplay(LeaderboardViewDefinition leaderboardViewDefinition)
        {
            if (leaderboardViewDefinition != null)
            {
                // TODO: Remove after testing
                if (leaderboardViewDefinition.MaxRows.HasValue)
                {
                    var rowCount = leaderboardViewDefinition.MaxRows.Value;
                    var columnCount = leaderboardViewDefinition.Columns.Count;

                    ListViewData data = new ListViewData(rowCount, columnCount);

                    for (int r = 0; r < rowCount; r++)
                    {
                        for (int c = 0; c < columnCount; c++)
                        {
                            data.DataValues[r, c] = $"{r}:{c}";
                        }
                    }

                    this.DataValues = data;
                }
            }

            ApplyTheme(Appearance);
        }

        protected virtual void DisplayDataValues(ListViewData dataValues)
        {
            if (dataValues == null)
                return;

            var dataRows = this.OrderedControls.Where(r => r.IsColumnCaptions == false).ToList();

            if (dataRows.Count == 0)
                return;

            for (int r = 0; r < dataValues.DataValues.GetLength(0); r++)
            {
                var row = dataRows[r];

                var dataCells = row.OrderedControls.OfType<LeaderboardViewCell>().ToList();

                for (int c = 0; c < dataValues.DataValues.GetLength(1); c++)
                {
                    dataCells[c].CellLabel.Text = dataValues.DataValues[r, c];
                }
            }
        }

        #endregion

        #region private


        private void View_Load(object sender, EventArgs e)
        {
            _viewModel.PropertyChanged += ViewModel_PropertyChanged;

            _viewModel.GetListDefinitionCommand();
        }

        private async void ViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(LeaderboardViewModel.LeaderboardViewDefinition))
            {
                BuildListDisplay(_viewModel.LeaderboardViewDefinition);

                await _viewModel.GetListDataCommandAsync();
            }
            if (e.PropertyName == nameof(LeaderboardViewModel.ListData))
            {
                DisplayDataValues(_viewModel.ListData);
            }
        }


        private void DraggableContainer1_ControlsResized(object sender, ControlResizedEventArgs e)
        {
            foreach (LeaderboardViewRow row in _rows)
            {
                if (sender != row)
                    row.ResizeDraggableControls(e.NewPositions);
            }
        }

        private void DraggableContainer1_ControlMoved(object sender, ControlMovedEventArgs e)
        {
            foreach (LeaderboardViewRow row in _rows)
            {
                if (sender != row)
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

        //private void CellLabel_TextChanged(object sender, EventArgs e)
        //{
        //    var label = (Label)sender;
        //    var cell = (ListViewCell)label.Parent;
        //    var row = (ListViewRow)cell.Parent;

        //    var textSize = GetDefaultHeight(cell, label.Text);

        //    if (textSize.Width > label.Width)
        //    {
        //        row.Height += textSize.Height;
        //    }
        //}

        #endregion
    }
}
