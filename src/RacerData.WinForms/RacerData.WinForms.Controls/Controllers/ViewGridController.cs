using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using RacerData.WinForms.Controls;
using RacerData.WinForms.Factories;
using RacerData.WinForms.Models;
using RacerData.WinForms.Ports;
using ViewBase = RacerData.WinForms.Views.ViewBase;

namespace RacerData.WinForms.Controllers
{
    internal class ViewGridController : IViewGridController
    {
        #region events

        public event EventHandler<ViewAddedEventArgs> ViewAdded;
        protected virtual void OnViewAdded(ViewBase view)
        {
            var handler = ViewAdded;
            handler?.Invoke(this, new ViewAddedEventArgs(view));
        }

        public event EventHandler<ViewRemovedEventArgs> ViewRemoved;
        protected virtual void OnViewRemoved(ViewBase view)
        {
            var handler = ViewRemoved;
            handler?.Invoke(this, new ViewRemovedEventArgs(view));
        }

        #endregion

        #region fields

        private readonly IViewFactory _viewFactory;
        private readonly IViewControlFactory _viewControlFactory;
        private TableLayoutPanel _gridTable;
        private float _columnWidth = 0F;
        private float _rowHeight = 0F;

        private Point _dragPoint = Point.Empty;
        private Panel _dragFrame = new Panel() { Visible = false, BorderStyle = BorderStyle.FixedSingle };
        private Panel _dragCoverFrame = new Panel() { Visible = false, BorderStyle = BorderStyle.FixedSingle, BackColor = Color.Black };
        private Timer _dragTimer = new Timer() { Interval = 20 };
        private Color _gridTableDraggingBackColor = Color.Gray;
        private Color _gridTableBackColor;
        private TableLayoutPanelCellBorderStyle _gridTableCellBorderStyle;

        private Size _resizeOriginalSize;
        private Point _resizePoint = Point.Empty;
        private Panel _resizeFrame = new Panel() { Visible = false, BorderStyle = BorderStyle.FixedSingle };

        #endregion

        #region properties

        public int MaxRows { get; set; }
        public int MaxColumns { get; set; }
        public int MinRows { get; set; }
        public int MinColumns { get; set; }
        public int DefaultRowHeight { get; set; }
        public int DefaultColumnWidth { get; set; }
        public float CellSizeChangeFactor { get; set; }

        #endregion

        #region ctor

        internal ViewGridController(
            IViewFactory viewFactory,
            IViewControlFactory viewControlFactory,
            Form parentForm,
            TableLayoutPanel gridTable)
        {
            _viewFactory = viewFactory ?? throw new ArgumentNullException(nameof(viewFactory));
            _viewControlFactory = viewControlFactory ?? throw new ArgumentNullException(nameof(viewControlFactory));
            _gridTable = gridTable ?? throw new ArgumentNullException(nameof(gridTable));

            MaxRows = 40;
            MaxColumns = 40;
            MinRows = 8;
            MinColumns = 8;
            DefaultRowHeight = 50;
            DefaultColumnWidth = 100;
            CellSizeChangeFactor = 0.25F;

            UpdateGridRowCellSizeAbsolute(DefaultColumnWidth, DefaultRowHeight);

            _dragTimer.Tick += DragTimer_Tick;

            _gridTable.AllowDrop = true;
            _gridTable.DragOver += GridTable_DragOver;
            _gridTable.DragDrop += GridTable_DragDrop;

            _gridTable.Parent.AllowDrop = true;
            _gridTable.Parent.DragOver += GridTable_DragOver;
            _gridTable.Parent.DragDrop += GridTable_DragDrop;

            _gridTable.Parent.Controls.Add(_dragFrame);
            _gridTable.Parent.Controls.Add(_dragCoverFrame);

            _gridTable.MouseWheel += GridTable_MouseWheel;

            parentForm.ResizeEnd += ParentForm_ResizeEnd;
        }

        #endregion

        #region public

        public void AddRowColumn()
        {
            try
            {
                AddRowToGrid();
                AddColumnToGrid();
            }
            catch (ViewGridControllerException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                ExceptionHandler("Error adding row + column", ex);
            }
        }
        public void RemoveRowColumn()
        {
            try
            {
                RemoveRowFromGrid();
                RemoveColumnFromGrid();
            }
            catch (ViewGridControllerException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                ExceptionHandler("Error removing row + column", ex);
            }
        }

        public void AddColumn()
        {
            try
            {
                AddColumnToGrid();
            }
            catch (ViewGridControllerException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                ExceptionHandler("Error adding column", ex);
            }
        }
        public void RemoveColumn()
        {
            try
            {
                RemoveColumnFromGrid();
            }
            catch (ViewGridControllerException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                ExceptionHandler("Error removing column", ex);
            }
        }

        public void AddRow()
        {
            try
            {
                AddRowToGrid();
            }
            catch (ViewGridControllerException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                ExceptionHandler("Error adding row", ex);
            }
        }
        public void RemoveRow()
        {
            try
            {
                RemoveRowFromGrid();
            }
            catch (ViewGridControllerException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                ExceptionHandler("Error removing row", ex);
            }
        }

        public void IncreaseCellSize()
        {
            try
            {
                IncreaseGridCellSize();
            }
            catch (Exception ex)
            {
                ExceptionHandler("Error increasing grid cell size", ex);
            }
        }
        public void DecreaseCellSize()
        {
            try
            {
                DecreaseGridCellSize();
            }
            catch (ViewGridControllerException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                ExceptionHandler("Error decreasing grid cell size", ex);
            }
        }

        public void AddView(ViewInfo viewInfo)
        {
            AddViews(new List<ViewInfo>() { viewInfo });
        }
        public void AddViews(IList<ViewInfo> viewInfos)
        {
            try
            {
                AddViewsToGrid(viewInfos);
            }
            catch (ViewGridControllerException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                ExceptionHandler("Error Adding view", ex);
            }
        }

        public void RemoveViewAt(int index)
        {
            try
            {
                if (index < 0)
                    throw new ViewGridControllerException($"Index ({index}) must be greater than 0");

                if (index >= _gridTable.Controls.Count)
                    throw new ViewGridControllerException($"Index ({index}) out of range. Must be between 0 and  {_gridTable.Controls.Count - 1}.");

                RemoveViewAtIndex(index);
            }
            catch (ViewGridControllerException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                ExceptionHandler($"Error removing view at index {index}", ex);
            }
        }

        public void ParentResized()
        {
            try
            {
                AfterParentResized();
            }
            catch (ViewGridControllerException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                ExceptionHandler($"Error handling parent resize", ex);
            }
        }

        #endregion

        #region protected

        #region exception handlers
        protected virtual void ExceptionHandler(string message, Exception ex)
        {
            throw new ViewGridControllerException($"Error in ViewGridController:\r\n{message}:\r\n{ex.Message}", ex);
        }
        protected virtual void ExceptionHandler(string message, Exception ex, ViewBase view)
        {
            throw new ViewGridControllerException($"View error in ViewGridController:\r\n{message}:\r\n{ex.Message}", ex, view);
        }
        #endregion

        #region add/remove views
        protected virtual void AddViewsToGrid(IList<ViewInfo> viewInfos)
        {
            try
            {
                _gridTable.Visible = false;

                _gridTable.SuspendLayout();

                ViewBase view = null;

                foreach (ViewInfo viewInfo in viewInfos)
                {
                    try
                    {
                        view = _viewFactory.GetView(viewInfo);

                        view.SuspendLayout();

                        IViewControl viewControl = _viewControlFactory.GetViewControl(viewInfo);

                        view.SetViewControl(viewControl);

                        // Margin determines the spacing within the grid cells
                        view.Margin = new Padding(0);

                        // Anchor determines the docking within the grid cells
                        view.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Bottom;

                        int viewWidth = viewInfo.CellPosition.ColumnSpan * (int)_columnWidth;
                        int viewHeight = viewInfo.CellPosition.RowSpan * (int)_rowHeight;
                        view.Size = new Size(viewWidth, viewHeight);

                        _gridTable.Controls.Add(view, viewInfo.CellPosition.Column, viewInfo.CellPosition.Row);
                        _gridTable.SetColumnSpan(view, viewInfo.CellPosition.ColumnSpan);
                        _gridTable.SetRowSpan(view, viewInfo.CellPosition.RowSpan);

                        view.RemoveViewRequest += View_RemoveViewRequest;
                        view.BeginViewResizeRequest += View_BeginViewResizeRequest;
                        view.ViewResizeRequest += View_ViewResizeRequest;
                        view.EndViewResizeRequest += View_EndViewResizeRequest;

                        ConfigureDragging(view);

                        OnViewAdded(view);

                        view.ResumeLayout(true);

                    }
                    catch (Exception ex)
                    {
                        ExceptionHandler($"Error adding view '{viewInfo?.Name}'", ex);
                    }
                }
            }
            catch (ViewGridControllerException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                ExceptionHandler("Error adding views", ex);
            }
            finally
            {
                _gridTable.ResumeLayout(true);

                _gridTable.Visible = true;

                SetGridRowColumnCount();
                UpdateViewIndexes();
            }
        }

        protected virtual void RemoveViewAtIndex(int index)
        {
            try
            {
                ViewBase view = (ViewBase)_gridTable.Controls[index];

                RemoveView(view);
            }
            catch (ViewGridControllerException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                ExceptionHandler($"Error removing view at index {index}", ex);
            }
        }
        protected virtual void RemoveView(ViewBase view)
        {
            try
            {
                if (view == null)
                    throw new ArgumentNullException(nameof(view));

                if (_gridTable.Controls.Contains(view))
                {
                    _gridTable.Controls.Remove(view);

                    view.RemoveViewRequest -= View_RemoveViewRequest;

                    OnViewRemoved(view);
                }
            }
            catch (ArgumentNullException ex)
            {
                ExceptionHandler("Error removing view from grid", ex);
            }
            catch (Exception ex)
            {
                ExceptionHandler("Error removing view from grid", ex, view);
            }
            finally
            {
                if (view != null)
                    view.Dispose();

                SetGridRowColumnCount();
                UpdateViewIndexes();
            }
        }
        protected virtual void UpdateViewIndexes()
        {
            foreach (ViewBase view in _gridTable.Controls.OfType<ViewBase>().ToList())
            {
                view.Index = _gridTable.Controls.GetChildIndex(view);
            }
        }
        #endregion

        #region add/remove rows/columns
        protected virtual void AddRowToGrid()
        {
            if (_gridTable.RowCount < MaxRows)
            {
                _gridTable.RowCount += 1;
                _gridTable.RowStyles.Add(new RowStyle(SizeType.Absolute, _rowHeight));
            }
        }
        protected virtual void AddRowsToGrid(int count)
        {
            if (_gridTable.RowCount + count < MaxRows)
            {
                _gridTable.RowCount += count;
                for (int i = 0; i < count; i++)
                {
                    _gridTable.RowStyles.Add(new RowStyle(SizeType.Absolute, _rowHeight));
                }
            }
        }

        protected virtual void RemoveRowFromGrid()
        {
            if (_gridTable.RowCount > MinRows)
            {
                _gridTable.RowCount -= 1;
                _gridTable.RowStyles.RemoveAt(_gridTable.RowStyles.Count - 1);
            }
        }
        protected virtual void AddColumnToGrid()
        {
            if (_gridTable.ColumnCount < MaxColumns)
            {
                _gridTable.ColumnCount += 1;
                _gridTable.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, _columnWidth));
            }
        }
        protected virtual void AddColumnsToGrid(int count)
        {
            if (_gridTable.ColumnCount + count < MaxColumns)
            {
                _gridTable.ColumnCount += count;
                for (int i = 0; i < count; i++)
                {
                    _gridTable.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, _columnWidth));
                }
            }
        }
        protected virtual void RemoveColumnFromGrid()
        {
            if (_gridTable.ColumnCount > MinColumns)
            {
                _gridTable.ColumnCount -= 1;
                _gridTable.ColumnStyles.RemoveAt(_gridTable.ColumnStyles.Count - 1);
            }
        }

        protected virtual void SetGridRowColumnCount()
        {
            var gridMaxRow = 0;
            var gridMaxColumn = 0;
            foreach (ViewBase view in _gridTable.Controls.OfType<ViewBase>())
            {
                var viewMaxRow = _gridTable.GetRow(view) + _gridTable.GetRowSpan(view);
                if (viewMaxRow > gridMaxRow)
                    gridMaxRow = viewMaxRow;

                var viewMaxColumn = _gridTable.GetColumn(view) + _gridTable.GetColumnSpan(view);
                if (viewMaxColumn > gridMaxColumn)
                    gridMaxColumn = viewMaxColumn;
            }

            if (gridMaxRow < _gridTable.RowCount - 1)
            {
                for (int r = _gridTable.RowCount - 1; r > gridMaxRow; r--)
                {
                    _gridTable.RowStyles.RemoveAt(r);
                    _gridTable.RowCount--;
                }
            }
            else if (gridMaxRow > _gridTable.RowCount - 1)
            {
                int rowsToAdd = gridMaxRow - (_gridTable.RowCount - 1);
                AddRowsToGrid(rowsToAdd);
            }

            if (gridMaxColumn < _gridTable.ColumnCount - 1)
            {
                for (int c = _gridTable.ColumnCount - 1; c > gridMaxColumn; c--)
                {
                    _gridTable.ColumnStyles.RemoveAt(c);
                    _gridTable.ColumnCount--;
                }
            }
            else if (gridMaxColumn > _gridTable.ColumnCount - 1)
            {
                int columnsToAdd = gridMaxColumn - (_gridTable.ColumnCount - 1);
                AddColumnsToGrid(columnsToAdd);
            }

            _gridTable.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        }

        #endregion

        #region update grid cell size
        protected virtual void IncreaseGridCellSize()
        {
            UpdateGridRowCellSizeAbsolute(_columnWidth * (1F + CellSizeChangeFactor), _rowHeight * (1F + CellSizeChangeFactor));
        }
        protected virtual void DecreaseGridCellSize()
        {
            UpdateGridRowCellSizeAbsolute(_columnWidth * (1F - CellSizeChangeFactor), _rowHeight * (1F - CellSizeChangeFactor));
        }
        protected virtual void UpdateGridRowCellSizeAbsolute(float newColWidth, float newRowHeight)
        {
            try
            {
                _gridTable.SuspendLayout();

                _gridTable.RowStyles.Clear();
                _gridTable.RowCount = 0;

                _gridTable.ColumnStyles.Clear();
                _gridTable.ColumnCount = 0;

                float totalWidth = 0;
                float totalHeight = 0;

                int currentHeight = _gridTable.Height;

                for (float y = 0; y < currentHeight - 1; y++)
                {
                    _gridTable.RowStyles.Add(new RowStyle(SizeType.Absolute, newRowHeight));
                    _gridTable.RowCount += 1;
                    y += newRowHeight;
                    totalHeight = y;
                }

                int currentWidth = _gridTable.Width;

                for (float x = 0; x < currentWidth - 1; x++)
                {
                    _gridTable.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, newColWidth));
                    _gridTable.ColumnCount += 1;
                    x += newColWidth;
                    totalWidth = x;
                }

                _columnWidth = newColWidth;
                _rowHeight = newRowHeight;
            }
            catch (Exception ex)
            {
                ExceptionHandler("Error auto-setting grid size", ex);
            }
            finally
            {
                _gridTable.ResumeLayout();
            }
        }
        protected virtual void AfterParentResized()
        {
            UpdateGridRowCellSizeAbsolute(_columnWidth, _rowHeight);
        }
        #endregion

        #region drag/drop

        protected virtual void ConfigureDragging(ViewBase view)
        {
            view.MouseDown += (s, e) =>
            {
                if (e.Button == MouseButtons.Left)
                {
                    _gridTableBackColor = _gridTable.BackColor;
                    _gridTableCellBorderStyle = _gridTable.CellBorderStyle;

                    _gridTable.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;

                    // Location relative to the view control
                    _dragPoint = e.Location;

                    var cellPosition = _gridTable.GetCellPosition(view);
                    var columnWidth = _gridTable.ColumnStyles[cellPosition.Column].Width;
                    int viewWidth = (int)columnWidth * _gridTable.GetColumnSpan(view);
                    var rowHeight = _gridTable.RowStyles[cellPosition.Row].Height;
                    int viewHeight = (int)rowHeight * _gridTable.GetRowSpan(view);

                    _dragFrame.Size = new Size(viewWidth, viewHeight);
                    _dragCoverFrame.Size = new Size(viewWidth + 12, viewHeight + 12);

                    _dragTimer.Start();

                    // Location relative to the parent form
                    Point pt = _gridTable.PointToClient(Cursor.Position);

                    _dragFrame.Location = new Point(
                        view.Location.X,
                        view.Location.Y);

                    _dragCoverFrame.Location = new Point(
                        view.Location.X - 1,
                        view.Location.Y - 1);

                    if (_dragFrame.BackgroundImage != null)
                        _dragFrame.BackgroundImage.Dispose();

                    if (_dragCoverFrame.BackgroundImage != null)
                        _dragCoverFrame.BackgroundImage.Dispose();

                    Bitmap bmp = new Bitmap(_dragFrame.ClientSize.Width,
                                            _dragFrame.ClientSize.Height);

                    view.DrawToBitmap(bmp, _dragFrame.ClientRectangle);

                    _dragFrame.BackgroundImage = bmp;

                    Bitmap coverBmp = new Bitmap(_dragFrame.ClientSize.Width,
                                           _dragFrame.ClientSize.Height);

                    using (Graphics gfx = Graphics.FromImage(coverBmp))
                    using (SolidBrush brush = new SolidBrush(Color.FromArgb(200, 100, 100, 100)))
                    {
                        gfx.FillRectangle(brush, 0, 0, coverBmp.Width, coverBmp.Height);
                    }

                    _dragCoverFrame.BackgroundImage = coverBmp;

                    _dragCoverFrame.BringToFront();
                    _dragCoverFrame.Show();

                    _dragFrame.BringToFront();
                    _dragFrame.Show();

                    view.DoDragDrop(view, DragDropEffects.Copy | DragDropEffects.Move);
                }
            };
        }

        protected virtual void DragTimer_Tick(object sender, EventArgs e)
        {
            if ((Control.MouseButtons & MouseButtons.Left) == MouseButtons.None)
            {
                _dragFrame.Hide();
                _dragCoverFrame.Hide();
                _dragTimer.Stop();
            }

            if (_dragFrame.Visible)
            {
                Point pt = _gridTable.PointToClient(Cursor.Position);

                _dragFrame.Location = new Point(pt.X - _dragPoint.X,
                                               pt.Y + 3);
            }
        }

        protected virtual void GridTable_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
            _gridTable.BackColor = _gridTableDraggingBackColor;
        }

        protected virtual void GridTable_DragDrop(object sender, DragEventArgs e)
        {
            ViewBase view = null;
            try
            {
                _dragFrame.Hide();
                _dragCoverFrame.Hide();
                _dragTimer.Stop();

                view = e.Data.GetData(e.Data.GetFormats()[0]) as ViewBase;

                if (view != null)
                {
                    var effectiveDropPoint = new Point(
                        e.X - _dragPoint.X,
                        e.Y - _dragPoint.Y);

                    var hitPoint = _gridTable.PointToClient(new Point(effectiveDropPoint.X, effectiveDropPoint.Y));

                    var newCell = GetRowColIndex(_gridTable, hitPoint);

                    if (newCell == null)
                    {
                        if ((hitPoint.X + view.Width) > _gridTable.Width)
                        {
                            var columnCountToAdd = (int)(((hitPoint.X + view.Width) - _gridTable.Width) / _columnWidth) + 1;
                            AddColumnsToGrid(columnCountToAdd);
                        }

                        if ((hitPoint.Y + view.Height) > _gridTable.Height)
                        {
                            var rowCountToAdd = (int)(((hitPoint.Y + view.Height) - _gridTable.Height) / _rowHeight) + 1;
                            AddRowsToGrid(rowCountToAdd);
                        }

                        newCell = GetRowColIndex(_gridTable, hitPoint);
                    }

                    if (newCell != null)
                    {
                        var rowSpan = _gridTable.GetRowSpan(view);
                        var columnSpan = _gridTable.GetColumnSpan(view);

                        if ((newCell.Value.X + columnSpan) > _gridTable.ColumnCount)
                        {
                            var columnCountToAdd = (newCell.Value.X + columnSpan) - _gridTable.ColumnCount;
                            AddColumnsToGrid(columnCountToAdd);
                        }

                        if ((newCell.Value.Y + rowSpan) > _gridTable.RowCount)
                        {
                            var rowCountToAdd = (newCell.Value.Y + rowSpan) - _gridTable.RowCount;
                            AddRowsToGrid(rowCountToAdd);
                        }

                        _gridTable.Controls.Remove(view);
                        _gridTable.Controls.Add(view, newCell.Value.X, newCell.Value.Y);

                        SetGridRowColumnCount();
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler("Error moving view", ex);
            }
            finally
            {
                _gridTable.BackColor = _gridTableBackColor;
                _gridTable.CellBorderStyle = _gridTableCellBorderStyle;
            }
        }

        protected virtual Point? GetRowColIndex(TableLayoutPanel tlp, Point point)
        {
            if (point.X > tlp.Width || point.Y > tlp.Height)
                return null;

            int w = 0, h = 0;
            int[] widths = tlp.GetColumnWidths();
            int[] heights = tlp.GetRowHeights();

            int i;
            for (i = 0; i < widths.Length && point.X > w; i++)
            {
                w += widths[i];
            }
            int col = i - 1;

            for (i = 0; i < heights.Length && point.Y + tlp.VerticalScroll.Value > h; i++)
            {
                h += heights[i];
            }
            int row = i - 1;

            if (col < 0)
                col = 0;

            if (row < 0)
                row = 0;

            return new Point(col, row);
        }

        #endregion

        #endregion

        #region private

        private void View_RemoveViewRequest(object sender, RemoveViewRequestEventArgs e)
        {
            try
            {
                RemoveViewAt(e.Index);
            }
            catch (Exception ex)
            {
                ExceptionHandler($"Error removing view at {e.Index}", ex);
            }
        }

        private void View_BeginViewResizeRequest(object sender, ViewResizeRequestEventArgs e)
        {
            try
            {
                ViewBase view = (ViewBase)sender;
                _resizePoint = e.Location;
                _gridTable.Parent.Controls.Add(_resizeFrame);

                var cellPosition = _gridTable.GetCellPosition(view);
                var columnWidth = _gridTable.ColumnStyles[cellPosition.Column].Width;
                int viewWidth = (int)columnWidth * _gridTable.GetColumnSpan(view);
                var rowHeight = _gridTable.RowStyles[cellPosition.Row].Height;
                int viewHeight = (int)rowHeight * _gridTable.GetRowSpan(view);

                _resizeFrame.Size = new Size(viewWidth, viewHeight);

                _resizeOriginalSize = _resizeFrame.Size;

                Point pt = _gridTable.PointToClient(Cursor.Position);

                _resizeFrame.Location = new Point(view.Location.X + 12, view.Location.Y + 11);

                _resizeFrame.BringToFront();
                _resizeFrame.Show();

                view.Visible = false;

            }
            catch (Exception ex)
            {
                ExceptionHandler("Error starting view resize", ex);
            }
        }

        private void View_ViewResizeRequest(object sender, ViewResizeRequestEventArgs e)
        {
            try
            {
                var resizeDeltaX = e.Location.X - _resizePoint.X;
                var resizeDeltaY = e.Location.Y - _resizePoint.Y;

                _resizeFrame.Size = new Size(_resizeOriginalSize.Width + resizeDeltaX, _resizeOriginalSize.Height + resizeDeltaY);
            }
            catch (Exception ex)
            {
                ExceptionHandler("Error during view resize", ex);
            }
        }

        private void View_EndViewResizeRequest(object sender, EndViewResizeRequestEventArgs e)
        {
            ViewBase view = (ViewBase)sender;

            try
            {
                _resizeFrame.Hide();
                _gridTable.Parent.Controls.Remove(_resizeFrame);

                var cellPosition = _gridTable.GetCellPosition(view);
                var colSpan = _gridTable.GetColumnSpan(view);
                var rowSpan = _gridTable.GetRowSpan(view);

                Point hitPoint = _gridTable.PointToClient(Cursor.Position);
                var newCellBuffer = GetRowColIndex(_gridTable, hitPoint);

                if (newCellBuffer == null)
                {
                    if ((hitPoint.X + view.Width) > _gridTable.Width)
                    {
                        var columnCountToAdd = (int)(((hitPoint.X + view.Width) - _gridTable.Width) / _columnWidth) + 1;
                        AddColumnsToGrid(columnCountToAdd);
                    }

                    if ((hitPoint.Y + view.Height) > _gridTable.Height)
                    {
                        var rowCountToAdd = (int)(((hitPoint.Y + view.Height) - _gridTable.Height) / _rowHeight) + 1;
                        AddRowsToGrid(rowCountToAdd);
                    }

                    newCellBuffer = GetRowColIndex(_gridTable, hitPoint);
                }

                var newCell = newCellBuffer.Value;

                if (e.ResizeDirection.HasFlag(ResizeDirection.Horizontal))
                {
                    if (newCell.X > cellPosition.Column)
                        _gridTable.SetColumnSpan(view, newCell.X - cellPosition.Column + 1);
                }
                if (e.ResizeDirection.HasFlag(ResizeDirection.Vertical))
                {
                    if (newCell.Y > cellPosition.Row)
                        _gridTable.SetRowSpan(view, newCell.Y - cellPosition.Row + 1);
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler("Error resizing view", ex);
            }
            finally
            {
                view.Visible = true;

                SetGridRowColumnCount();
            }
        }

        private void GridTable_MouseWheel(object sender, MouseEventArgs e)
        {
            try
            {
                if (Control.ModifierKeys == Keys.Control)
                {
                    if (e.Delta > 0)
                    {
                        IncreaseCellSize();
                    }
                    else
                    {
                        DecreaseCellSize();
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler("Error resizing from mouse wheel", ex);
            }
        }

        private void ParentForm_ResizeEnd(object sender, EventArgs e)
        {
            try
            {
                AfterParentResized();
            }
            catch (Exception ex)
            {
                ExceptionHandler("Error resizing from parent form", ex);
            }
        }

        #endregion
    }
}
