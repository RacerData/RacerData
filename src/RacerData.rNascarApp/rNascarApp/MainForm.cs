using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using log4net;
using log4net.Core;
using Microsoft.Extensions.DependencyInjection;
using RacerData.NascarApi.Client.Models.LiveFeed;
using RacerData.NascarApi.Service;
using RacerData.NascarApi.Service.Ports;
using RacerData.rNascarApp.Controls;
using RacerData.rNascarApp.Dialogs;
using RacerData.rNascarApp.Factories;
using RacerData.rNascarApp.Logging;
using RacerData.rNascarApp.Models;
using RacerData.rNascarApp.Settings;
using RacerData.rNascarApp.Themes;

namespace RacerData.rNascarApp
{
    public partial class MainForm : Form, INotifyPropertyChanged, IMonitorClient
    {
        #region events

        public delegate void SafeCallDelegate(object sender, LiveFeedUpdatedEventArgs e);

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;

            if (handler != null)
            {
                handler.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public event EventHandler<Theme> ThemeUpdated;
        protected virtual void OnThemeUpdated(Theme theme)
        {
            var handler = ThemeUpdated;

            if (handler != null)
            {
                handler.Invoke(this, theme);
            }
        }

        public event EventHandler<ViewState> ViewStateUpdated;
        protected virtual void OnViewStateUpdated(ViewState viewState)
        {
            var handler = ViewStateUpdated;

            if (handler != null)
            {
                handler.Invoke(this, viewState);
            }
        }

        #endregion

        #region fields

        private Point _dragPoint = Point.Empty;
        private Panel _dragFrame;
        private bool _saveSettingsOnExit = false;
        private IMonitorService _feedService;

        #endregion

        #region properties

        private UserSettings _userSettings;
        public UserSettings UserSettings
        {
            get
            {
                if (_userSettings == null)
                    _userSettings = UserSettings.Load();

                return _userSettings;
            }
            set
            {
                _userSettings = value;
                OnPropertyChanged(nameof(UserSettings));
            }
        }

        private AppSettings _appSettings;
        public AppSettings AppSettings
        {
            get
            {
                if (_appSettings == null)
                    _appSettings = AppSettings.Load();

                return _appSettings;
            }
            set
            {
                _appSettings = value;
                OnPropertyChanged(nameof(AppSettings));
            }
        }

        public ILog Log { get; set; }

        public IList<Theme> Themes { get; set; }

        #endregion

        #region ctor / load

        public MainForm()
        {
            InitializeComponent();

            Logger.Setup();

            try
            {
                this.SuspendLayout();

                this.WindowState = AppSettings.WindowState;
                if (this.WindowState == FormWindowState.Normal)
                {
                    this.Size = AppSettings.Size;
                    this.Location = AppSettings.Location;
                    this.StartPosition = AppSettings.StartPosition;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                this.ResumeLayout();
            }

        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;  // Turn on WS_EX_COMPOSITED
                return cp;
            }
        }

        protected virtual void MainForm_Load(object sender, EventArgs e)
        {
            try
            {
                InitializeMainForm();
            }
            catch (Exception ex)
            {
                ExceptionHandler("Error loading main form", ex);
            }
        }

        protected virtual void InitializeMainForm()
        {
            try
            {
                Log = LogManager.GetLogger("MainForm");

                LogInfo("rNascar Timing & Scoring App Started");

                _feedService = ServiceProvider.Instance.GetRequiredService<IMonitorService>();

                _feedService.Register(this);

                Themes = UserThemeRepository.GetThemes();

                PropertyChanged += MainForm_PropertyChanged;

                UserSettings = UserSettings.Load();

                MainToolStrip.DataBindings.Add(new Binding("Visible", UserSettings, "ShowToolBar", false, DataSourceUpdateMode.OnPropertyChanged));
                MainStatusStrip.DataBindings.Add(new Binding("Visible", UserSettings, "ShowStatusBar", false, DataSourceUpdateMode.OnPropertyChanged));

                LogInfo("User settings loaded");

                _dragFrame = new Panel()
                {
                    Visible = false,
                    BorderStyle = BorderStyle.FixedSingle
                };

                Controls.Add(_dragFrame);

                dragTimer.Tick += DragTimer_Tick;

                SetGridCellSizes(AppSettings.GridRowCount, AppSettings.GridColumnCount);

                LoadViewStates();
            }
            catch (Exception ex)
            {
                ExceptionHandler("Error initializing main form", ex);
            }
        }

        protected virtual void ClearViewStates()
        {
            foreach (UserControlBase controlBase in GridTable.Controls.OfType<UserControlBase>().ToList())
            {
                RemoveUserControlBase(controlBase);
            }
        }

        protected virtual void RemoveUserControlBase(UserControlBase controlBase)
        {
            this.GridTable.Controls.Remove(controlBase);

            this.ThemeUpdated -= controlBase.OnThemeUpdated;
            this.ViewStateUpdated -= controlBase.OnViewStateUpdated;
            controlBase.ResizeControlRequest -= BaseControl_ResizeControlRequest;
            controlBase.RemoveControlRequest -= ControlBase_RemoveControlRequest;
            controlBase.EditThemeRequest -= ControlBase_EditThemeRequest;
            controlBase.EditViewRequest -= ControlBase_EditViewRequest;

            controlBase.Dispose();
        }

        protected virtual void LoadViewStates()
        {
            foreach (ViewState viewState in AppSettings.ViewStates.OrderBy(v => v.Index))
            {
                if (viewState.IsDisplayed)
                {
                    var controlBase = AddControl(viewState);
                }
            }
        }

        protected virtual void SaveViewStates()
        {
            int i = 0;

            foreach (UserControlBase controlBase in GridTable.Controls.OfType<UserControlBase>().ToList())
            {
                var cell = GridTable.GetPositionFromControl(controlBase);

                var existingViewState = AppSettings.ViewStates.FirstOrDefault(v => v.Id == controlBase.State.Id);

                if (existingViewState == null)
                {
                    var viewState = new ViewState()
                    {
                        Id = Guid.NewGuid(),
                        Name = controlBase.Name,
                        HeaderText = controlBase.State.HeaderText,
                        Index = i,
                        CellPosition = new ViewCellPosition()
                        {
                            Row = cell.Row,
                            Column = cell.Column,
                            RowSpan = GridTable.GetRowSpan(controlBase),
                            ColumnSpan = GridTable.GetColumnSpan(controlBase)
                        },
                        ListSettings = controlBase.State.ListSettings,
                        ThemeId = controlBase.State.ThemeId
                    };

                    AppSettings.ViewStates.Add(viewState);
                }
                else
                {
                    existingViewState.Index = i;
                    existingViewState.CellPosition = new ViewCellPosition()
                    {
                        Row = cell.Row,
                        Column = cell.Column,
                        RowSpan = GridTable.GetRowSpan(controlBase),
                        ColumnSpan = GridTable.GetColumnSpan(controlBase)
                    };
                    existingViewState.ThemeId = controlBase.State.ThemeId;
                }

                i++;
            }

            AppSettings.Save();
        }

        protected virtual void SaveAppState()
        {
            AppSettings.WindowState = this.WindowState;

            if (AppSettings.WindowState == FormWindowState.Normal)
            {
                AppSettings.Size = this.Size;
                AppSettings.Location = this.Location;
                AppSettings.StartPosition = this.StartPosition;
            }

            AppSettings.Save();
        }
        protected virtual void BeforeFormCloses()
        {
            SaveAppState();

            if (!_saveSettingsOnExit)
                return;

            if (UserSettings != null)
                UserSettings.Save();

            SaveViewStates();
        }

        #endregion

        #region protected

        protected virtual void ExceptionHandler(string message, Exception ex)
        {
            if (Log != null)
                Log.Error(message, ex);
#if DEBUG
            Console.WriteLine(ex);
#endif
            MessageBox.Show($"{message}: {ex.Message}");
        }

        protected virtual void SetLogLevel(Level logLevel)
        {
            if (((log4net.Repository.Hierarchy.Hierarchy)LogManager.GetRepository()).Root.Level == logLevel)
                return;

            ((log4net.Repository.Hierarchy.Hierarchy)LogManager.GetRepository()).Root.Level = logLevel;
            ((log4net.Repository.Hierarchy.Hierarchy)LogManager.GetRepository()).RaiseConfigurationChanged(EventArgs.Empty);

            if (UserSettings.LogLevel != logLevel)
                UserSettings.LogLevel = logLevel;

            LogInfo($"Log level set to {logLevel.ToString()}");
        }

        protected virtual void LogInfo(string message)
        {
            if (Log == null)
                Console.WriteLine(message);
            else
                Log.Info(message);
        }

        protected virtual UserControlBase AddControl(ViewState viewState)
        {
            UserControlBase controlBase = new UserControlBase(viewState);

            return AddControl(
                controlBase,
                viewState.CellPosition.Row,
                viewState.CellPosition.Column,
                viewState.CellPosition.RowSpan,
                viewState.CellPosition.ColumnSpan);
        }

        protected virtual UserControlBase AddControl(
            UserControlBase controlBase,
            int row,
            int column,
            int rowSpan,
            int columnSpan)
        {
            try
            {
                controlBase.State.IsDisplayed = true;

                controlBase.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Right;

                GridTable.Controls.Add(controlBase, column, row);
                GridTable.SetRowSpan(controlBase, rowSpan);
                GridTable.SetColumnSpan(controlBase, columnSpan);

                UpdateGridCapacity();

                this.ThemeUpdated += controlBase.OnThemeUpdated;
                this.ViewStateUpdated += controlBase.OnViewStateUpdated;
                controlBase.ResizeControlRequest += BaseControl_ResizeControlRequest;
                controlBase.RemoveControlRequest += ControlBase_RemoveControlRequest;
                controlBase.EditThemeRequest += ControlBase_EditThemeRequest;
                controlBase.EditViewRequest += ControlBase_EditViewRequest;

                ConfigureDragging(controlBase);
            }
            catch (IndexOutOfRangeException)
            {
                MessageBox.Show(this, "Can't add another view", "Grid Full", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                GridTable.Controls.Remove(controlBase);
            }
            catch (Exception ex)
            {
                ExceptionHandler("Error adding a new view", ex);
            }

            return controlBase;
        }

        protected virtual void ConfigureDragging(UserControlBase ctl)
        {
            ctl.MouseDown += (s, e) =>
            {
                if (e.Button == MouseButtons.Left)
                {
                    GridTable.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;

                    _dragPoint = e.Location;

                    dragTimer.Start();

                    _dragFrame.Size = ctl.Size;

                    Point pt = this.PointToClient(Cursor.Position);

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
                    dragTimer.Stop();
                }
            };

            ctl.Leave += (s, e) =>
            {
                _dragFrame.Hide();
                dragTimer.Stop();
            };
        }

        protected virtual void DragTimer_Tick(object sender, EventArgs e)
        {
            if ((Control.MouseButtons & MouseButtons.Left) == MouseButtons.None)
            {
                _dragFrame.Hide();
                dragTimer.Stop();
            }

            if (_dragFrame.Visible)
            {
                Point pt = this.PointToClient(Cursor.Position);

                _dragFrame.Location = new Point(pt.X - _dragPoint.X,
                                               pt.Y + 3);
            }
        }

        protected virtual void GridTable_DragOver(object sender, DragEventArgs e)
        {
            UserControlBase controlBase = e.Data.GetData(e.Data.GetFormats()[0]) as UserControlBase;

            var hitPoint = this.GridTable.PointToClient(new Point(e.X, e.Y));
            var newCell = GetRowColIndex(GridTable, hitPoint);

            if (newCell != null)
            {

                var rowSpan = GridTable.GetRowSpan(controlBase);
                var columnSpan = GridTable.GetColumnSpan(controlBase);

                if ((newCell.Value.Y + rowSpan) > GridTable.RowCount)
                {
                    Console.WriteLine($"newCell={newCell.Value.X}:{newCell.Value.Y}; rowSpan={rowSpan}; newCell.Value.Y + rowSpan={newCell.Value.Y + rowSpan}; GridTable.RowCount={GridTable.RowCount}");
                    GridTable.BackColor = Color.Red;
                }
                else if ((newCell.Value.X + columnSpan) > GridTable.ColumnCount)
                {
                    Console.WriteLine($"newCell={newCell.Value.X}:{newCell.Value.Y}; columnSpan={columnSpan}; newCell.Value.X + columnSpan={newCell.Value.X + columnSpan }; GridTable.ColumnCount={GridTable.ColumnCount}");
                    GridTable.BackColor = Color.Red;
                }
                else
                {
                    e.Effect = DragDropEffects.Move;
                    GridTable.BackColor = Color.LimeGreen;
                }
            }
        }

        protected virtual void GridTable_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                _dragFrame.Hide();
                dragTimer.Stop();

                UserControlBase controlBase = e.Data.GetData(e.Data.GetFormats()[0]) as UserControlBase;
                if (controlBase != null)
                {
                    var hitPoint = this.GridTable.PointToClient(new Point(e.X, e.Y));
                    var newCell = GetRowColIndex(GridTable, hitPoint);

                    if (newCell != null)
                    {
                        var rowSpan = GridTable.GetRowSpan(controlBase);
                        var columnSpan = GridTable.GetColumnSpan(controlBase);

                        if (((newCell.Value.Y + rowSpan) <= GridTable.RowCount) && ((newCell.Value.X + columnSpan) <= GridTable.RowCount))
                        {
                            this.GridTable.Controls.Remove(controlBase);
                            this.GridTable.Controls.Add(controlBase, newCell.Value.X, newCell.Value.Y);
                        }
                    }
                }

                GridTable.BackColor = Color.FromKnownColor(KnownColor.Control);

                UpdateGridCapacity();
                //int rowCapacity = GridTable.RowCount;
                //int columnCapacity = GridTable.ColumnCount;

                //foreach (UserControlBase cbase in GridTable.Controls)
                //{
                //    var rowSpan = GridTable.GetRowSpan(cbase);
                //    var columnSpan = GridTable.GetColumnSpan(cbase);
                //    var cell = GridTable.GetPositionFromControl(cbase);

                //    rowCapacity = ((rowSpan + cell.Row) > rowCapacity) ? rowSpan + cell.Row : rowCapacity;
                //    columnCapacity = ((columnSpan + cell.Column) > columnCapacity) ? columnSpan + cell.Column : columnCapacity;


                //    //Console.WriteLine($"{cbase.Title} - rowSpan {rowSpan} + cell.Row {cell.Row} = {rowSpan + cell.Row} | GridTable.RowCount {GridTable.RowCount} ## columnSpan {columnSpan} + cell.Column {cell.Column} = {columnSpan + cell.Column} | GridTable.ColumnCount {GridTable.ColumnCount}");
                //}
                //SetGridCellSizes(rowCapacity, columnCapacity);
            }
            catch (ArgumentException)
            {
                MessageBox.Show(this, "Can't move view here", "Outside Grid Bounds", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                ExceptionHandler("Error moving view", ex);
            }
            finally
            {
                //try
                //{

                GridTable.CellBorderStyle = TableLayoutPanelCellBorderStyle.None;
                //}
                //catch (Exception)
                //{

                //}
            }
        }

        protected virtual Point? GetRowColIndex(TableLayoutPanel tlp, Point point)
        {
            if (point.X > tlp.Width || point.Y > tlp.Height)
                return null;

            int w = tlp.Width;
            int h = tlp.Height;
            int[] widths = tlp.GetColumnWidths();

            int i;
            for (i = widths.Length - 1; i >= 0 && point.X < w; i--)
                w -= widths[i];
            int col = i + 1;

            int[] heights = tlp.GetRowHeights();
            for (i = heights.Length - 1; i >= 0 && point.Y < h; i--)
                h -= heights[i];

            int row = i + 1;

            return new Point(col, row);
        }

        private void ControlBase_EditViewRequest(object sender, ViewState e)
        {
            DisplayViewDesignerDialog(e);
        }

        private void ControlBase_EditThemeRequest(object sender, Guid e)
        {
            DisplayThemeDialog(e);
        }

        protected virtual void ControlBase_RemoveControlRequest(object sender, EventArgs e)
        {
            ((UserControlBase)sender).State.IsDisplayed = false;
            SaveViewStates();
            RemoveUserControlBase((UserControlBase)sender);
        }

        protected virtual void BaseControl_ResizeControlRequest(object sender, EventArgs e)
        {
            UserControlBase controlBase = (UserControlBase)sender;

            var rowSpan = GridTable.GetRowSpan(controlBase);
            var columnSpan = GridTable.GetColumnSpan(controlBase);

            var dialog = new ResizeControlDialog(controlBase, rowSpan, columnSpan);

            dialog.SpanSettingsChanged += Dialog_SpanSettingsChanged;

            dialog.ShowDialog(this);

            dialog.SpanSettingsChanged -= Dialog_SpanSettingsChanged;
        }

        protected virtual void Dialog_SpanSettingsChanged(object sender, Point e)
        {
            if (sender is UserControlBase)
            {
                UserControlBase controlBase = (UserControlBase)sender;

                GridTable.SetRowSpan(controlBase, e.X);
                GridTable.SetColumnSpan(controlBase, e.Y);
            }
            else if (sender == GridTable)
            {
                SetGridCellSizes(e.X, e.Y);
            }
        }

        protected virtual void UpdateGridCapacity()
        {
            int rowCapacity = GridTable.RowCount;
            int columnCapacity = GridTable.ColumnCount;

            foreach (UserControlBase cbase in GridTable.Controls)
            {
                var rowSpan = GridTable.GetRowSpan(cbase);
                var columnSpan = GridTable.GetColumnSpan(cbase);
                var cell = GridTable.GetPositionFromControl(cbase);

                rowCapacity = ((rowSpan + cell.Row) > rowCapacity) ? rowSpan + cell.Row : rowCapacity;
                columnCapacity = ((columnSpan + cell.Column) > columnCapacity) ? columnSpan + cell.Column : columnCapacity;
                //Console.WriteLine($"{cbase.Title} - rowSpan {rowSpan} + cell.Row {cell.Row} = {rowSpan + cell.Row} | GridTable.RowCount {GridTable.RowCount} ## columnSpan {columnSpan} + cell.Column {cell.Column} = {columnSpan + cell.Column} | GridTable.ColumnCount {GridTable.ColumnCount}");
            }

            SetGridCellSizes(rowCapacity, columnCapacity);
        }

        protected virtual void SetGridCellSizes(int rowCount, int columnCount)
        {
            GridTable.RowCount = rowCount;
            float newRowSize = GridTable.Height * (float)(((float)100 / (float)GridTable.RowCount) * .01);

            GridTable.RowStyles.Clear();
            for (int i = 0; i < GridTable.RowCount; i++)
            {
                GridTable.RowStyles.Add(new RowStyle(SizeType.Absolute, newRowSize));
            }

            GridTable.ColumnCount = columnCount;
            float newColumnSize = GridTable.Width * (float)(((float)100 / (float)GridTable.ColumnCount) * .01);
            GridTable.ColumnStyles.Clear();
            for (int i = 0; i < GridTable.ColumnCount; i++)
            {
                GridTable.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, newColumnSize));
            }
        }

        protected virtual void MainForm_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case "UserSettings":
                    {
                        SetLogLevel(UserSettings.LogLevel);

                        break;
                    }
            }
        }

        protected virtual void DisplayLogFile()
        {
            try
            {
                using (var dialog = new FileViewerDialog() { Title = "Log File", FilePath = Logger.GetLogFilePath() })
                {
                    dialog.ShowDialog(this);
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler("Error displaying log file", ex);
            }
        }

        protected virtual void DisplayUserSettingsFile()
        {
            try
            {
                using (var dialog = new FileViewerDialog() { Title = "User Settings File", FilePath = UserSettings.GetSettingsFilePath() })
                {
                    dialog.ShowDialog(this);
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler("Error displaying settings file", ex);
            }
        }

        protected virtual void DisplayThemeDialog()
        {
            DisplayThemeDialog(null);
        }
        protected virtual void DisplayThemeDialog(Guid? themeId)
        {
            try
            {
                var themes = UserThemeRepository.GetThemes();

                using (var dialog = new ThemeDesignerDialog()
                {
                    Themes = themes,
                    ViewStates = AppSettings.ViewStates,
                    ThemeId = themeId
                })
                {
                    dialog.ThemeUpdated += ThemeDialog_UpdatedTheme;

                    if (dialog.ShowDialog(this) == DialogResult.OK)
                    {
                        UserThemeRepository.SaveThemes(dialog.Themes);
                    }

                    dialog.ThemeUpdated -= ThemeDialog_UpdatedTheme;
                }

                Themes = UserThemeRepository.GetThemes();

                foreach (Theme theme in Themes)
                {
                    OnThemeUpdated(theme);
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler("Error displaying themes designer", ex);
            }
        }

        protected virtual void DisplayViewDesignerDialog()
        {
            DisplayViewDesignerDialog(null);
        }
        protected virtual void DisplayViewDesignerDialog(ViewState viewStateToEdit)
        {
            try
            {
                var localAppSettings = AppSettings.Load();
                var factory = new ViewDataSourceFactory();
                var sources = factory.GetList();

                using (var dialog = new ViewDesignerDialog()
                {
                    ViewStates = localAppSettings.ViewStates,
                    Themes = this.Themes,
                    DataSources = sources,
                    ViewStateId = viewStateToEdit?.Id
                })
                {

                    dialog.ViewStateUpdated += ViewDialog_ViewStateUpdated;

                    if (dialog.ShowDialog(this) == DialogResult.OK)
                    {
                        AppSettings.ViewStates = dialog.ViewStates;

                        AppSettings.Save();

                        foreach (ViewState viewState in AppSettings.ViewStates)
                        {
                            OnViewStateUpdated(viewState);
                        }
                    }

                    dialog.ViewStateUpdated -= ViewDialog_ViewStateUpdated;
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler("Error displaying view designer", ex);
            }
        }

        private void ViewDialog_ViewStateUpdated(object sender, ViewState e)
        {
            OnViewStateUpdated(e);

            if (!e.IsDisplayed)
            {
                foreach (UserControlBase controlBase in GridTable.Controls.OfType<UserControlBase>().Where(u => u.State.Id == e.Id))
                {
                    controlBase.State.IsDisplayed = false;
                    SaveViewStates();

                    RemoveUserControlBase(controlBase);
                }
            }
            else
            {
                var controlBase = GridTable.Controls.OfType<UserControlBase>().FirstOrDefault(u => u.State.Id == e.Id);

                if (controlBase == null)
                {
                    controlBase.State.IsDisplayed = true;
                    SaveViewStates();

                    AddControl(e);
                }
            }
        }

        protected virtual void ThemeDialog_UpdatedTheme(object sender, Theme theme)
        {
            OnThemeUpdated(theme);
        }

        protected virtual void DisplayGridResizeDialog()
        {
            try
            {
                GridTable.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;

                var dialog = new ResizeControlDialog((Control)GridTable, GridTable.RowCount, GridTable.ColumnCount);

                dialog.SpanSettingsChanged += Dialog_SpanSettingsChanged;

                dialog.ShowDialog(this);

                dialog.SpanSettingsChanged -= Dialog_SpanSettingsChanged;
            }
            catch (Exception ex)
            {
                ExceptionHandler("", ex);
            }
            finally
            {
                GridTable.CellBorderStyle = TableLayoutPanelCellBorderStyle.None;
            }
        }

        protected virtual void ResetViews()
        {
            try
            {
                ClearViewStates();

                LoadViewStates();
            }
            catch (Exception ex)
            {
                ExceptionHandler("Error resetting views", ex);
            }
        }

        #endregion

        #region private

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _saveSettingsOnExit = true;
            this.Close();
        }

        private void statusBarToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            if (MainStatusStrip.Visible != statusBarToolStripMenuItem.Checked)
                MainStatusStrip.Visible = statusBarToolStripMenuItem.Checked;
        }

        private void MainStatusStrip_VisibleChanged(object sender, EventArgs e)
        {
            if (statusBarToolStripMenuItem.Checked != MainStatusStrip.Visible)
                statusBarToolStripMenuItem.Checked = MainStatusStrip.Visible;
        }

        private void toolBarToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            if (MainToolStrip.Visible != toolBarToolStripMenuItem.Checked)
                MainToolStrip.Visible = toolBarToolStripMenuItem.Checked;
        }

        private void MainToolStrip_VisibleChanged(object sender, EventArgs e)
        {
            if (toolBarToolStripMenuItem.Checked != MainToolStrip.Visible)
                toolBarToolStripMenuItem.Checked = MainToolStrip.Visible;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            BeforeFormCloses();
        }

        private void logFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DisplayLogFile();
        }

        private void userSettingsFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DisplayUserSettingsFile();
        }

        private void themeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DisplayThemeDialog();
        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void GridTable_Resize(object sender, EventArgs e)
        {
            SetGridCellSizes(GridTable.RowCount, GridTable.ColumnCount);
        }

        private void gridSizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DisplayGridResizeDialog();
        }

        private void gridSizeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DisplayGridResizeDialog();
        }

        private void viewDesignerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DisplayViewDesignerDialog();
        }

        private void btnFeedReader_Click(object sender, EventArgs e)
        {
            try
            {
                _feedService.Start();
            }
            catch (Exception ex)
            {
                ExceptionHandler("Error subscribing to feed reader", ex);
            }
        }

        public void Monitor_LiveFeedStarted(object sender, LiveFeedStartedEventArgs e)
        {

        }

        public void Monitor_LiveFeedUpdated(object sender, LiveFeedUpdatedEventArgs e)
        {
            if (this.InvokeRequired)
            {
                var d = new SafeCallDelegate(Monitor_LiveFeedUpdated);
                Invoke(d, new object[] { sender, e });
            }
            else
            {
                UpdateStatusLabel(e.LiveFeedData);

                foreach (UserControlBase controlBase in GridTable.Controls.OfType<UserControlBase>())
                {
                    controlBase.LiveFeedData = e.LiveFeedData;
                    var data = controlBase.GetViewData();
                    controlBase.UpdateListRowsData(data);
                }
            }
        }

        public void Monitor_ServiceStateChanged(object sender, ServiceStateChangedEventArgs e)
        {

        }

        public void Monitor_ServiceActivity(object sender, ServiceActivityEventArgs e)
        {

        }

        private void UpdateStatusLabel(LiveFeedData data)
        {
            var series = data.SeriesId == 1 ? "MENCS" : data.SeriesId == 2 ? "XFinity Series" : data.SeriesId == 3 ? "NGOTS" : "Other";
            lblTrackName.Text = data.TrackName;
            lblEvent.Text = $"{series} {data.RunName}";
            lblSession.Text = data.RunType.ToString();
            lblTrackState.Text = data.FlagState.ToString();
        }

        private void btnUnsubscribe_Click(object sender, EventArgs e)
        {
            try
            {
                _feedService.Pause();
            }
            catch (Exception ex)
            {
                ExceptionHandler("Error unsubscribing from feed reader", ex);
            }
        }

        private void resetViewsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ResetViews();
        }

        #endregion
    }
}
