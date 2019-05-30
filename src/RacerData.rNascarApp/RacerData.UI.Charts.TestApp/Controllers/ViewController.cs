using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using rNascarApp.UI.Models;
using rNascarApp.UI.Ports;
using View = rNascarApp.UI.Views.View;

namespace rNascarApp.UI.Controllers
{
    internal class ViewController : IViewController
    {
        #region events

        public event EventHandler<ViewAddedEventArgs> ViewAdded;
        protected virtual void OnViewAdded(View view)
        {
            var handler = ViewAdded;
            handler?.Invoke(this, new ViewAddedEventArgs(view));
            PrintReport("OnViewAdded");
        }

        public event EventHandler<ViewRemovedEventArgs> ViewRemoved;
        protected virtual void OnViewRemoved(View view)
        {
            var handler = ViewRemoved;
            handler?.Invoke(this, new ViewRemovedEventArgs(view));
            PrintReport("OnViewRemoved");
        }

        #endregion

        #region fields

        private readonly IViewFactory _viewFactory;
        private TableLayoutPanel _gridTable;
        private float _columnWidth = 0F;
        private float _rowHeight = 0F;

        private Point _dragPoint = Point.Empty;
        private Panel _dragFrame = new Panel() { Visible = false, BorderStyle = BorderStyle.FixedSingle };
        private Timer _dragTimer = new Timer() { Interval = 20 };
        private Color _gridTableDraggingBackColor = Color.Gainsboro;
        private Color _gridTableBackColor;
        private TableLayoutPanelCellBorderStyle _gridTableCellBorderStyle;

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

        internal ViewController(
            IViewFactory viewFactory,
            TableLayoutPanel gridTable)
        {
            _viewFactory = viewFactory ?? throw new ArgumentNullException(nameof(viewFactory));
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
            Console.WriteLine(ex.ToString());

            throw new ViewGridControllerException($"Error in ViewGridController:\r\n{message}:\r\n{ex.Message}", ex);
        }
        protected virtual void ExceptionHandler(string message, Exception ex, View view)
        {
            Console.WriteLine(ex.ToString());

            throw new ViewGridControllerException($"View error in ViewGridController:\r\n{message}:\r\n{ex.Message}", ex, view);
        }
        #endregion

        #region add/remove views
        protected virtual void AddViewsToGrid(IList<ViewInfo> viewInfos)
        {
            try
            {
                View view = null;

                foreach (ViewInfo viewInfo in viewInfos)
                {
                    try
                    {
                        view = _viewFactory.GetView(viewInfo);

                        // Margin determines the spacing within the grid cells
                        view.Margin = new Padding(4);

                        // Anchor determines the docking within the grid cells
                        view.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Bottom;

                        int viewWidth = viewInfo.CellPosition.ColumnSpan * (int)_columnWidth;
                        int viewHeight = viewInfo.CellPosition.RowSpan * (int)_rowHeight;
                        view.Size = new Size(viewWidth, viewHeight);

                        _gridTable.Controls.Add(view, viewInfo.CellPosition.Column, viewInfo.CellPosition.Row);
                        _gridTable.SetColumnSpan(view, viewInfo.CellPosition.ColumnSpan);
                        _gridTable.SetRowSpan(view, viewInfo.CellPosition.RowSpan);

                        view.RemoveViewRequest += View_RemoveViewRequest;

                        ConfigureDragging(view);

                        OnViewAdded(view);
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
                SetGridRowColumnCount();
                UpdateViewIndexes();
            }
        }
        protected virtual void RemoveViewAtIndex(int index)
        {
            try
            {
                View view = (View)_gridTable.Controls[index];

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
        protected virtual void RemoveView(View view)
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
            foreach (View view in _gridTable.Controls.OfType<View>().ToList())
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
            PrintReport("AddRowToGrid");
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
            PrintReport("AddRowsToGrid");
        }

        protected virtual void RemoveRowFromGrid()
        {
            if (_gridTable.RowCount > MinRows)
            {
                _gridTable.RowCount -= 1;
                _gridTable.RowStyles.RemoveAt(_gridTable.RowStyles.Count - 1);
            }
            PrintReport("RemoveRowFromGrid");
        }
        protected virtual void AddColumnToGrid()
        {
            if (_gridTable.ColumnCount < MaxColumns)
            {
                _gridTable.ColumnCount += 1;
                _gridTable.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, _columnWidth));
            }
            PrintReport("AddColumnToGrid");
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
            PrintReport("AddColumnsToGrid");
        }
        protected virtual void RemoveColumnFromGrid()
        {
            if (_gridTable.ColumnCount > MinColumns)
            {
                _gridTable.ColumnCount -= 1;
                _gridTable.ColumnStyles.RemoveAt(_gridTable.ColumnStyles.Count - 1);
            }
            PrintReport("RemoveColumnFromGrid");
        }

        protected virtual void SetGridRowColumnCount()
        {
            var gridMaxRow = 0;
            var gridMaxColumn = 0;
            foreach (View view in _gridTable.Controls.OfType<View>())
            {
                var viewMaxRow = _gridTable.GetRow(view) + _gridTable.GetRowSpan(view);
                if (viewMaxRow > gridMaxRow)
                    gridMaxRow = viewMaxRow;

                var viewMaxColumn = _gridTable.GetColumn(view) + _gridTable.GetColumnSpan(view);
                if (viewMaxColumn > gridMaxColumn)
                    gridMaxColumn = viewMaxColumn;
            }

            Console.WriteLine($"GridMaxRow: {gridMaxRow} GridMaxColumn: {gridMaxColumn}");

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

                PrintReport("UpdateGridRowCellSizeAbsolute");
            }
        }
        protected virtual void AfterParentResized()
        {
            UpdateGridRowCellSizeAbsolute(_columnWidth, _rowHeight);
        }
        #endregion

        #region drag/drop

        protected virtual void ConfigureDragging(View ctl)
        {
            ctl.MouseDown += (s, e) =>
            {
                if (e.Button == MouseButtons.Left)
                {
                    _gridTableBackColor = _gridTable.BackColor;
                    _gridTableCellBorderStyle = _gridTable.CellBorderStyle;

                    _gridTable.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;

                    _dragPoint = e.Location;

                    _dragTimer.Start();

                    _dragFrame.Size = ctl.Size;

                    Point pt = _gridTable.PointToClient(Cursor.Position);

                    _dragFrame.Location = new Point(pt.X - _dragPoint.X,
                                                   pt.Y + 3);

                    if (_dragFrame.BackgroundImage != null)
                        _dragFrame.BackgroundImage.Dispose();
                    Bitmap bmp = new Bitmap(_dragFrame.ClientSize.Width,
                                            _dragFrame.ClientSize.Height);
                    ctl.DrawToBitmap(bmp, _dragFrame.ClientRectangle);
                    _dragFrame.BackgroundImage = bmp;

                    _dragFrame.BringToFront();
                    _dragFrame.Show();
                    ctl.DoDragDrop(ctl, DragDropEffects.Copy | DragDropEffects.Move);
                }
            };

            ctl.MouseUp += (s, e) =>
            {
                if (e.Button == MouseButtons.Left)
                {
                    _dragFrame.Hide();
                    _dragTimer.Stop();
                }
            };

            ctl.Leave += (s, e) =>
            {
                _dragFrame.Hide();
                _dragTimer.Stop();
            };
        }

        protected virtual void DragTimer_Tick(object sender, EventArgs e)
        {
            if ((Control.MouseButtons & MouseButtons.Left) == MouseButtons.None)
            {
                _dragFrame.Hide();
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
            try
            {
                _dragFrame.Hide();
                _dragTimer.Stop();

                View controlBase = e.Data.GetData(e.Data.GetFormats()[0]) as View;
                if (controlBase != null)
                {
                    var hitPoint = _gridTable.PointToClient(new Point(e.X, e.Y));

                    var newCell = GetRowColIndex(_gridTable, hitPoint);

                    if (newCell == null)
                    {
                        if ((hitPoint.X + controlBase.Width) > _gridTable.Width)
                        {
                            var columnCountToAdd = (int)(((hitPoint.X + controlBase.Width) - _gridTable.Width) / _columnWidth) + 1;
                            AddColumnsToGrid(columnCountToAdd);
                        }

                        if ((hitPoint.Y + controlBase.Height) > _gridTable.Height)
                        {
                            var rowCountToAdd = (int)(((hitPoint.Y + controlBase.Height) - _gridTable.Height) / _rowHeight) + 1;
                            AddRowsToGrid(rowCountToAdd);
                        }

                        newCell = GetRowColIndex(_gridTable, hitPoint);
                    }

                    if (newCell != null)
                    {
                        var rowSpan = _gridTable.GetRowSpan(controlBase);
                        var columnSpan = _gridTable.GetColumnSpan(controlBase);

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

                        _gridTable.Controls.Remove(controlBase);
                        _gridTable.Controls.Add(controlBase, newCell.Value.X, newCell.Value.Y);

                        // TODO: Trim unused rows/columns?
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

            return new Point(col, row);
        }

        #endregion

        #endregion

        #region private

        private void View_RemoveViewRequest(object sender, RemoveViewRequestEventArgs e)
        {
            RemoveViewAt(e.Index);
        }

        #endregion
    }
}
