using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using log4net;
using log4net.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RacerData.NascarApi.Client.Models.LiveFeed;
using RacerData.NascarApi.Service;
using RacerData.NascarApi.Service.Ports;
using RacerData.rNascarApp.Controls;
using RacerData.rNascarApp.Dialogs;
using RacerData.rNascarApp.Factories;
using RacerData.rNascarApp.Logging;
using RacerData.rNascarApp.Models;
using RacerData.rNascarApp.Services;
using RacerData.rNascarApp.Settings;
using RacerData.rNascarApp.Themes;

namespace RacerData.rNascarApp
{
    public partial class MainForm : Form, INotifyPropertyChanged, IMonitorClient
    {
        #region consts

        private const string ApplicationTitle = "r/NACAR Timing and Scoring";

        #endregion

        #region events

        public delegate void LiveFeedSafeCallDelegate(object sender, LiveFeedUpdatedEventArgs e);
        public delegate void LapAveragesSafeCallDelegate(object sender, LapAveragesUpdatedEventArgs e);
        public delegate void LapTimesSafeCallDelegate(object sender, LapTimesUpdatedEventArgs e);
        public delegate void LivePitDataSafeCallDelegate(object sender, LivePitDataUpdatedEventArgs e);
        public delegate void LiveFlagDataSafeCallDelegate(object sender, LiveFlagDataUpdatedEventArgs e);
        public delegate void LivePointsDataSafeCallDelegate(object sender, LivePointsDataUpdatedEventArgs e);
        public delegate void LiveQualifyingDataSafeCallDelegate(object sender, LiveQualifyingDataUpdatedEventArgs e);

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
        private Panel _dragFrame = null;
        private bool _saveSettingsOnExit = false;
        private IMonitorService _feedService = null;
        private IWorkspaceService _workspaceService = null;
        private Color _gridTableBackColor;
        private bool _isMonitorEnabled = false;
        private bool _isFullScreen = false;
        private FormBorderStyle _previousBorderStyle;
        private FormWindowState _previousWindowState;

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

        #region ctor/load

        public MainForm()
        {
            InitializeComponent();

            tlsMain.Renderer = new ToolStripRenderer();

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

                var configuration = ServiceProvider.Instance.GetRequiredService<IConfiguration>();

                Themes = UserThemeRepository.GetThemes();

                PropertyChanged += MainForm_PropertyChanged;

                UserSettings = UserSettings.Load();

                ViewStateUpdated += MainForm_ViewStateUpdated;

                tlsMain.DataBindings.Add(new Binding("Visible", UserSettings, "ShowToolBar", false, DataSourceUpdateMode.OnPropertyChanged));
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

                _workspaceService = ServiceProvider.Instance.GetRequiredService<IWorkspaceService>();

                _workspaceService.WorkspaceChanged += WorkspaceService_WorkspaceChanged;

                UpdateCurrentWorkspaceName(_workspaceService.CurrentWorkspace.Name);

                LoadViewStates();

                _gridTableBackColor = GridTable.BackColor;

                var autoStartMonitor = configuration["monitor:autoStartService"] == "true";
                SetMonitorState(autoStartMonitor);
            }
            catch (Exception ex)
            {
                ExceptionHandler("Error initializing main form", ex);
            }
        }
        #endregion

        #region logging
        protected virtual void ExceptionHandler(string message, Exception ex)
        {
            Log?.Error(message, ex);
#if DEBUG
            Console.WriteLine(ex);
#endif
            MessageBox.Show(this, ex.Message, message, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        protected virtual DialogResult ExceptionHandler(string message, Exception ex, MessageBoxButtons buttons)
        {
            Log?.Error(message, ex);
#if DEBUG
            Console.WriteLine(ex);
#endif
            return MessageBox.Show(this, ex.Message, message, buttons, MessageBoxIcon.Warning);
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
        #endregion

        #region drag/drop
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
                    GridTable.BackColor = Color.DimGray;
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

                GridTable.BackColor = _gridTableBackColor;

                UpdateGridCapacity();
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
                GridTable.CellBorderStyle = TableLayoutPanelCellBorderStyle.None;
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
        #endregion

        #region control base
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
                controlBase.ResizeControlRequest += ControlBase_ResizeControlRequest;
                controlBase.RemoveControlRequest += ControlBase_RemoveControlRequest;
                controlBase.EditThemeRequest += ControlBase_EditThemeRequest;
                controlBase.EditViewRequest += ControlBase_EditViewRequest;

                ConfigureDragging(controlBase);

                if (!_workspaceService.CurrentWorkspace.ViewStates.Contains(controlBase.State.Id))
                    _workspaceService.CurrentWorkspace.ViewStates.Add(controlBase.State.Id);
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

        protected virtual void RemoveUserControlBase(UserControlBase controlBase)
        {
            this.GridTable.Controls.Remove(controlBase);

            this.ThemeUpdated -= controlBase.OnThemeUpdated;
            this.ViewStateUpdated -= controlBase.OnViewStateUpdated;
            controlBase.ResizeControlRequest -= ControlBase_ResizeControlRequest;
            controlBase.RemoveControlRequest -= ControlBase_RemoveControlRequest;
            controlBase.EditThemeRequest -= ControlBase_EditThemeRequest;
            controlBase.EditViewRequest -= ControlBase_EditViewRequest;

            _workspaceService.CurrentWorkspace.ViewStates.Remove(controlBase.State.Id);

            controlBase.Dispose();
        }

        protected virtual void ControlBase_RemoveControlRequest(object sender, EventArgs e)
        {
            ((UserControlBase)sender).State.IsDisplayed = false;
            SaveViewStates();
            RemoveUserControlBase((UserControlBase)sender);
        }
        protected virtual void ControlBase_ResizeControlRequest(object sender, EventArgs e)
        {
            UserControlBase controlBase = (UserControlBase)sender;

            var rowSpan = GridTable.GetRowSpan(controlBase);
            var columnSpan = GridTable.GetColumnSpan(controlBase);

            var dialog = new ResizeControlDialog(controlBase, rowSpan, columnSpan);

            dialog.SpanSettingsChanged += SpanSettingsChanged;

            dialog.ShowDialog(this);

            dialog.SpanSettingsChanged -= SpanSettingsChanged;
        }
        private void ControlBase_EditViewRequest(object sender, ViewState e)
        {
            DisplayViewDesignerDialog(e);
        }
        private void ControlBase_EditThemeRequest(object sender, Guid e)
        {
            DisplayThemeDialog(e);
        }
        #endregion

        #region workspaces
        private void WorkspaceService_WorkspaceChanged(object sender, WorkspaceChangedEventArgs e)
        {
            try
            {
                UpdateCurrentWorkspaceName(e.CurrentWorkspace.Name);

                ResetViews();
            }
            catch (Exception ex)
            {
                ExceptionHandler("Error setting current workspace", ex);
            }
        }
        private void workspaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateNewWorkspace();
        }
        private void saveWorkspaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveWorkspace();
        }
        private void copyWorkspaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var workspace = SelectWorkspace("Select workspace to copy");

                if (workspace != null)
                    CopyWorkspace(workspace);
            }
            catch (Exception ex)
            {
                ExceptionHandler("Error copying workspace", ex);
            }
        }
        private void openWorkspaceToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                var workspace = SelectWorkspace("Select workspace to open");

                if (workspace != null)
                    _workspaceService.SetActiveWorkspace(workspace.Name);
            }
            catch (Exception ex)
            {
                ExceptionHandler("Error setting active workspace", ex);
            }
        }
        private void removeWorkspaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var workspace = SelectWorkspace("Select workspace to delete");

                if (workspace != null)
                    DeleteWorkspace(workspace);
            }
            catch (Exception ex)
            {
                ExceptionHandler("Error deleting workspace", ex);
            }
        }
        protected virtual void UpdateCurrentWorkspaceName(string name)
        {
            this.Text = $"{ApplicationTitle} [{name}]";
            lblWorkspace.Text = name;
        }
        protected virtual Workspace SelectWorkspace(string title, string prompt = "")
        {
            Workspace workspace = null;

            try
            {
                if (String.IsNullOrEmpty(prompt))
                    prompt = $"Current workspace: {_workspaceService.CurrentWorkspace.Name}";

                var dialog = new WorkspaceSelectionDialog()
                {
                    Title = title,
                    Prompt = prompt,
                    Workspaces = _workspaceService.Workspaces
                };

                var result = dialog.ShowDialog(this);

                if (result == DialogResult.OK)
                    workspace = dialog.Workspace;

            }
            catch (Exception ex)
            {
                ExceptionHandler("Error selecting workspace", ex);
            }

            return workspace;
        }
        protected virtual void SaveWorkspace()
        {
            try
            {
                _workspaceService.Save();
            }
            catch (Exception ex)
            {
                ExceptionHandler("Error saving workspace", ex);
            }
        }
        protected virtual void CopyWorkspace(Workspace workspace)
        {
            try
            {
                var isDone = false;

                while (!isDone)
                {
                    using (var dialog = new InputDialog(
                       "Copy Workspace",
                       "Enter a name for the new workspace",
                       $"Copy of {workspace.Name}"))
                    {
                        if (dialog.ShowDialog(this) != DialogResult.Cancel)
                        {
                            if (dialog.Value == Workspace.DefaultWorkspaceName)
                            {
                                var result = MessageBox.Show(this,
                                    $"The name '{Workspace.DefaultWorkspaceName}' is reserved.\r\n\r\nDo you want to try again?",
                                    "Error copying workspace",
                                    MessageBoxButtons.YesNo,
                                    MessageBoxIcon.Error);

                                isDone = (result != DialogResult.Yes);
                            }
                            else if (dialog.Value == String.Empty)
                            {
                                var result = MessageBox.Show(this,
                                    $"The name cannot be blank.\r\n\r\nDo you want to try again?",
                                    "Error copying workspace",
                                    MessageBoxButtons.YesNo,
                                    MessageBoxIcon.Error);

                                isDone = (result != DialogResult.Yes);
                            }
                            else
                            {
                                var newWorkspace = new Workspace()
                                {
                                    Name = dialog.Value,
                                    ViewStates = workspace.ViewStates.ToList()
                                };

                                try
                                {
                                    _workspaceService.AddWorkspace(newWorkspace);

                                    _workspaceService.SetActiveWorkspace(newWorkspace.Name);

                                    MessageBox.Show(this, $"Workspace '{newWorkspace.Name}' has been set as the active workspace",
                                        "Workspace copied",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Information);

                                    isDone = true;
                                }
                                catch (InvalidOperationException ex)
                                {
                                    var result = MessageBox.Show(this,
                                        $"There was an error copying the workspace:\r\n{ex.Message}\r\n\r\nDo you want to try again?",
                                        "Error copying workspace",
                                        MessageBoxButtons.YesNo,
                                        MessageBoxIcon.Error);

                                    isDone = (result != DialogResult.Yes);
                                }
                                catch (Exception)
                                {
                                    throw;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler("Error copying workspace", ex);
            }
        }
        protected virtual void CreateNewWorkspace()
        {
            try
            {
                var isDone = false;

                while (!isDone)
                {
                    using (var dialog = new InputDialog(
                       "New Workspace",
                       "Enter a name for the new workspace",
                       $"<Workspace Name>"))
                    {
                        if (dialog.ShowDialog(this) != DialogResult.Cancel)
                        {
                            if (dialog.Value == Workspace.DefaultWorkspaceName)
                            {
                                var result = MessageBox.Show(this,
                                    $"The name '{Workspace.DefaultWorkspaceName}' is reserved.\r\n\r\nDo you want to try again?",
                                    "Error creating workspace",
                                    MessageBoxButtons.YesNo,
                                    MessageBoxIcon.Error);

                                isDone = (result != DialogResult.Yes);
                            }
                            else if (dialog.Value == String.Empty)
                            {
                                var result = MessageBox.Show(this,
                                    $"The name cannot be blank.\r\n\r\nDo you want to try again?",
                                    "Error creating workspace",
                                    MessageBoxButtons.YesNo,
                                    MessageBoxIcon.Error);

                                isDone = (result != DialogResult.Yes);
                            }
                            else
                            {
                                var newWorkspace = new Workspace()
                                {
                                    Name = dialog.Value
                                };

                                try
                                {
                                    _workspaceService.AddWorkspace(newWorkspace);

                                    _workspaceService.SetActiveWorkspace(newWorkspace.Name);

                                    MessageBox.Show(this, $"Workspace '{newWorkspace.Name}' has been set as the active workspace",
                                        "Workspace created",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Information);

                                    isDone = true;
                                }
                                catch (InvalidOperationException ex)
                                {
                                    var result = MessageBox.Show(this,
                                        $"There was an error creating the workspace:\r\n{ex.Message}\r\n\r\nDo you want to try again?",
                                        "Error creating workspace",
                                        MessageBoxButtons.YesNo,
                                        MessageBoxIcon.Error);

                                    isDone = (result != DialogResult.Yes);
                                }
                                catch (Exception)
                                {
                                    throw;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler("Error creating new workspace", ex);
            }
        }
        protected virtual void DeleteWorkspace(Workspace workspace)
        {
            try
            {
                if (workspace.Name == Workspace.DefaultWorkspaceName)
                    throw new InvalidOperationException("Cannot delete default workspace");

                var result = MessageBox.Show(this,
                                       $"You are about to permanently delete workspace '{workspace.Name}'.\r\n\r\nContinue?",
                                       "Comfirm delete workspace",
                                       MessageBoxButtons.YesNo,
                                       MessageBoxIcon.Error);

                if (result != DialogResult.Yes)
                    return;

                _workspaceService.RemoveWorkspace(workspace);

                MessageBox.Show(this, $"Workspace '{workspace.Name}' has been deleted",
                                       "Workspace removed",
                                       MessageBoxButtons.OK,
                                       MessageBoxIcon.Information);

                workspace = null;
            }
            catch (Exception ex)
            {
                ExceptionHandler($"Error deleting workspace", ex);
            }
        }
        #endregion

        #region view states  
        private void viewListToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
        {
            try
            {
                foreach (ToolStripMenuItem item in viewListToolStripMenuItem.DropDownItems)
                {
                    item.CheckedChanged -= ViewStateStripMenuItem_CheckedChanged;
                }

                viewListToolStripMenuItem.DropDownItems.Clear();

                foreach (ViewState viewState in AppSettings.ViewStates)
                {
                    var fooToolStripMenuItem = new ToolStripMenuItem();
                    fooToolStripMenuItem.Name = $"{viewState.Name.Replace(" ", "_")}MenuItem";
                    fooToolStripMenuItem.Size = new Size(180, 22);
                    fooToolStripMenuItem.Text = viewState.Name;
                    fooToolStripMenuItem.CheckOnClick = true;
                    fooToolStripMenuItem.Tag = viewState;

                    foreach (UserControlBase controlBase in GridTable.Controls.OfType<UserControlBase>())
                    {
                        if (controlBase.State.Name == viewState.Name)
                        {
                            fooToolStripMenuItem.Checked = true;
                            break;
                        }
                    }

                    fooToolStripMenuItem.CheckedChanged += ViewStateStripMenuItem_CheckedChanged;
                    viewListToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { fooToolStripMenuItem });
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler("Error displaying view list", ex);
            }
        }
        private void ViewStateStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            ToolStripMenuItem item = (ToolStripMenuItem)sender;
            ViewState viewState = (ViewState)item.Tag;

            if (item.Checked)
            {
                viewState.IsDisplayed = true;
                AddControl(viewState);
            }
            else
            {
                UserControlBase controlToClose = null;
                foreach (UserControlBase controlBase in GridTable.Controls.OfType<UserControlBase>())
                {
                    if (controlBase.State.Name == viewState.Name)
                    {
                        controlToClose = controlBase;
                        break;
                    }
                }
                if (controlToClose != null)
                {
                    RemoveUserControlBase(controlToClose);
                    viewState.IsDisplayed = false;
                }
            }
        }
        private void resetViewsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ResetViews();
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
        protected virtual void ClearViewStates()
        {
            foreach (UserControlBase controlBase in GridTable.Controls.OfType<UserControlBase>().ToList())
            {
                RemoveUserControlBase(controlBase);
            }
        }
        protected virtual void LoadViewStates()
        {
            foreach (Guid id in _workspaceService.CurrentWorkspace.ViewStates)
            {
                var viewState = AppSettings.ViewStates.SingleOrDefault(v => v.Id == id);

                if (viewState != null && viewState.IsDisplayed)
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
        #endregion

        #region main form properties
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
        #endregion

        #region form closing
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _saveSettingsOnExit = true;
            this.Close();
        }
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            BeforeFormCloses();
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

            _workspaceService.Save();
        }
        #endregion

        #region menu/status control visible states
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
            if (tlsMain.Visible != toolBarToolStripMenuItem.Checked)
                tlsMain.Visible = toolBarToolStripMenuItem.Checked;
        }

        private void MainToolStrip_VisibleChanged(object sender, EventArgs e)
        {
            if (toolBarToolStripMenuItem.Checked != tlsMain.Visible)
                toolBarToolStripMenuItem.Checked = tlsMain.Visible;
        }
        #endregion

        #region options
        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        #endregion

        #region file viewer
        private void logFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DisplayLogFile();
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
        private void userSettingsFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DisplayUserSettingsFile();
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
        #endregion

        #region monitor service
        private void btnMonitor_Click(object sender, EventArgs e)
        {
            SetMonitorState(!_isMonitorEnabled);
        }
        private void SetMonitorState(bool enableMonitor)
        {
            try
            {
                if (enableMonitor)
                {
                    txtMonitorState.BackColor = Color.LimeGreen;
                    btnMonitor.Text = "Stop";
                    btnMonitor.Image = Properties.Resources.Symbols_Pause_32xLG;

                    var feedTypes = GetFeedTypes();

                    _feedService.Register(this, feedTypes);

                    _feedService.Start();
                }
                else
                {
                    txtMonitorState.BackColor = Color.DarkGreen;
                    btnMonitor.Text = "Start";
                    btnMonitor.Image = Properties.Resources.Symbols_Play_32xLG;

                    _feedService.Unregister(this);

                    _feedService.Pause();
                }

                _isMonitorEnabled = enableMonitor;
            }
            catch (Exception ex)
            {
                ExceptionHandler("Error setting monitor status", ex);
            }
        }
        private ApiFeedType GetFeedTypes()
        {
            ApiFeedType feeds = ApiFeedType.None;

            foreach (UserControlBase controlBase in GridTable.Controls.OfType<UserControlBase>())
            {
                feeds |= controlBase.State.ListSettings.ApiFeedType;
            }

            return feeds;
        }
        public void Monitor_LiveFeedStarted(object sender, LiveFeedStartedEventArgs e)
        {
        }
        public void Monitor_ServiceStateChanged(object sender, ServiceStateChangedEventArgs e)
        {
        }
        public void Monitor_ServiceActivity(object sender, ServiceActivityEventArgs e)
        {
        }
        public void Monitor_ServiceStatusChanged(object sender, ServiceActivityEventArgs e)
        {
        }

        public void Monitor_LiveFeedUpdated(object sender, LiveFeedUpdatedEventArgs e)
        {
            try
            {
                if (this.InvokeRequired)
                {
                    var d = new LiveFeedSafeCallDelegate(Monitor_LiveFeedUpdated);
                    Invoke(d, new object[] { sender, e });
                }
                else
                {
                    UpdateStatusLabel(e.LiveFeedData);

                    foreach (UserControlBase controlBase in GridTable.Controls.OfType<UserControlBase>())
                    {
                        var data = controlBase.GetViewData(e.LiveFeedData, ApiFeedType.LiveFeedData);
                        controlBase.UpdateListRowsData(data);
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler("Error receiving live feed data", ex);
            }
        }

        public void Monitor_LapAveragesUpdated(object sender, LapAveragesUpdatedEventArgs e)
        {
            try
            {
                if (this.InvokeRequired)
                {
                    var d = new LapAveragesSafeCallDelegate(Monitor_LapAveragesUpdated);
                    Invoke(d, new object[] { sender, e });
                }
                else
                {
                    foreach (UserControlBase controlBase in GridTable.Controls.OfType<UserControlBase>())
                    {
                        var data = controlBase.GetViewData(e.Data, ApiFeedType.LapAverageData);
                        controlBase.UpdateListRowsData(data);
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler("Error receiving lap average data", ex);
            }
        }

        public void Monitor_LapTimesUpdated(object sender, LapTimesUpdatedEventArgs e)
        {
            try
            {
                if (this.InvokeRequired)
                {
                    var d = new LapTimesSafeCallDelegate(Monitor_LapTimesUpdated);
                    Invoke(d, new object[] { sender, e });
                }
                else
                {
                    foreach (UserControlBase controlBase in GridTable.Controls.OfType<UserControlBase>())
                    {
                        var data = controlBase.GetViewData(e.Data, ApiFeedType.LapTimeData);
                        controlBase.UpdateListRowsData(data);
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler("Error receiving lap time data", ex);
            }
        }

        public void Monitor_LivePointsDataUpdated(object sender, LivePointsDataUpdatedEventArgs e)
        {
            try
            {
                if (this.InvokeRequired)
                {
                    var d = new LivePointsDataSafeCallDelegate(Monitor_LivePointsDataUpdated);
                    Invoke(d, new object[] { sender, e });
                }
                else
                {
                    foreach (UserControlBase controlBase in GridTable.Controls.OfType<UserControlBase>())
                    {
                        var data = controlBase.GetViewData(e.Data, ApiFeedType.LivePointsData);
                        controlBase.UpdateListRowsData(data);
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler("Error receiving live points data", ex);
            }
        }

        public void Monitor_LivePitDataUpdated(object sender, LivePitDataUpdatedEventArgs e)
        {
            try
            {
                if (this.InvokeRequired)
                {
                    var d = new LivePitDataSafeCallDelegate(Monitor_LivePitDataUpdated);
                    Invoke(d, new object[] { sender, e });
                }
                else
                {
                    foreach (UserControlBase controlBase in GridTable.Controls.OfType<UserControlBase>())
                    {
                        var data = controlBase.GetViewData(e.Data, ApiFeedType.LivePitData);
                        controlBase.UpdateListRowsData(data);
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler("Error receiving live pit data", ex);
            }
        }

        public void Monitor_LiveFlagDataUpdated(object sender, LiveFlagDataUpdatedEventArgs e)
        {
            try
            {
                if (this.InvokeRequired)
                {
                    var d = new LiveFlagDataSafeCallDelegate(Monitor_LiveFlagDataUpdated);
                    Invoke(d, new object[] { sender, e });
                }
                else
                {
                    foreach (UserControlBase controlBase in GridTable.Controls.OfType<UserControlBase>())
                    {
                        var data = controlBase.GetViewData(e.Data, ApiFeedType.LiveFlagData);
                        controlBase.UpdateListRowsData(data);
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler("Error receiving live flag data", ex);
            }
        }

        public void Monitor_LiveQualifyingDataUpdated(object sender, LiveQualifyingDataUpdatedEventArgs e)
        {
            try
            {
                if (this.InvokeRequired)
                {
                    var d = new LiveQualifyingDataSafeCallDelegate(Monitor_LiveQualifyingDataUpdated);
                    Invoke(d, new object[] { sender, e });
                }
                else
                {
                    foreach (UserControlBase controlBase in GridTable.Controls.OfType<UserControlBase>())
                    {
                        var data = controlBase.GetViewData(e.Data, ApiFeedType.LiveQualifyingData);
                        controlBase.UpdateListRowsData(data);
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler("Error receiving live qualifying data", ex);
            }
        }


        public virtual void Monitor_NascarApiDataUpdated<T>(object sender, NascarApiDataUpdatedEventArgs<T> e)
        {
            try
            {
                if (this.InvokeRequired)
                {
                    var d = new LiveQualifyingDataSafeCallDelegate(Monitor_LiveQualifyingDataUpdated);
                    Invoke(d, new object[] { sender, e });
                }
                else
                {
                    foreach (UserControlBase controlBase in GridTable.Controls.OfType<UserControlBase>())
                    {
                        var data = controlBase.GetViewData(e.Data, e.ApiFeedType);
                        controlBase.UpdateListRowsData(data);
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler("Error receiving live data", ex);
            }
        }

        private void UpdateStatusLabel(LiveFeedData data)
        {
            var series = data.SeriesType.ToString();
            lblTrackName.Text = data.TrackName;
            lblEvent.Text = $"{series} {data.RunName}";
            lblSession.Text = data.RunType.ToString();
            lblTrackState.Text = data.FlagState.ToString();
        }
        #endregion

        #region theme designer
        private void themeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DisplayThemeDialog();
        }
        private void btnThemeDesigner_Click(object sender, EventArgs e)
        {
            DisplayThemeDialog();
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
        protected virtual void ThemeDialog_UpdatedTheme(object sender, Theme theme)
        {
            OnThemeUpdated(theme);
        }
        #endregion

        #region view designer
        private void viewDesignerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DisplayViewDesignerDialog();
        }
        private void btnViewDesigner_Click(object sender, EventArgs e)
        {
            DisplayViewDesignerDialog();
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

                IViewDesigner dialog = null;

                using (dialog = new ViewDesignerDialog()
                {
                    ViewStates = localAppSettings.ViewStates,
                    Themes = this.Themes,
                    DataSources = sources,
                    ViewStateId = viewStateToEdit?.Id
                })
                {
                    if (dialog.ShowDialog(this) == DialogResult.OK)
                    {
                        AppSettings.ViewStates = dialog.ViewStates;

                        AppSettings.Save();

                        foreach (ViewState viewState in AppSettings.ViewStates)
                        {
                            OnViewStateUpdated(viewState);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler("Error displaying view designer", ex);
            }
        }
        private void MainForm_ViewStateUpdated(object sender, ViewState e)
        {
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

                if (controlBase != null)
                {
                    controlBase.State.IsDisplayed = true;
                    SaveViewStates();

                    AddControl(e);
                }
            }
        }
        #endregion

        #region grid size
        private void btnGridSize_Click(object sender, EventArgs e)
        {
            DisplayGridResizeDialog();
        }
        private void gridSizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DisplayGridResizeDialog();
        }
        private void gridSizeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DisplayGridResizeDialog();
        }
        private void GridTable_Resize(object sender, EventArgs e)
        {
            SetGridCellSizes(GridTable.RowCount, GridTable.ColumnCount);
        }
        protected virtual void DisplayGridResizeDialog()
        {
            try
            {
                GridTable.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;

                var dialog = new ResizeControlDialog((Control)GridTable, GridTable.RowCount, GridTable.ColumnCount);

                dialog.SpanSettingsChanged += SpanSettingsChanged;

                dialog.ShowDialog(this);

                dialog.SpanSettingsChanged -= SpanSettingsChanged;
            }
            catch (Exception ex)
            {
                ExceptionHandler("Error setting grid size", ex);
            }
            finally
            {
                GridTable.CellBorderStyle = TableLayoutPanelCellBorderStyle.None;
            }
        }
        protected virtual void SpanSettingsChanged(object sender, Point e)
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
        #endregion

        #region display formats
        private void displayFormatsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DisplayViewDisplayFormatDialog();
        }
        private void btnDisplayFormats_Click(object sender, EventArgs e)
        {
            DisplayViewDisplayFormatDialog();
        }

        protected virtual void DisplayViewDisplayFormatDialog()
        {
            try
            {
                var dataSourceFactory = new ViewDataSourceFactory();
                var dataSources = dataSourceFactory.GetList();

                var displayFormatFactory = new ViewDisplayFormatFactory();
                var displayFormats = displayFormatFactory.GetViewDisplayFormats();

                DisplayFormatMapService mapService = null;

                try
                {
                    mapService = new DisplayFormatMapService();
                }
                catch (Exception ex)
                {
                    var result = ExceptionHandler("Error loading DisplayFormatMap service. Continue?", ex, MessageBoxButtons.YesNo);

                    if (result != DialogResult.Yes)
                        return;
                }


                using (var dialog = new DisplayFormatMapDialog()
                {
                    DataSources = dataSources,
                    MapService = mapService
                })
                {
                    if (dialog.ShowDialog(this) == DialogResult.OK)
                    {
                        // Update the views
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler("Error displaying Data Format form", ex);
            }
        }
        #endregion

        #region Create view wizard
        private void viewToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DisplayViewDesignWizard();
        }
        private void btnNewVeiwWizard_Click(object sender, EventArgs e)
        {
            DisplayViewDesignWizard();
        }

        protected virtual void DisplayViewDesignWizard()
        {
            try
            {
                var dataSourceFactory = new ViewDataSourceFactory();
                var dataSources = dataSourceFactory.GetList();

                var displayFormatFactory = new ViewDisplayFormatFactory();
                var displayFormats = displayFormatFactory.GetViewDisplayFormats();

                var mapService = new DisplayFormatMapService();

                using (var dialog = new CreateViewWizard()
                {
                    DataSources = dataSources,
                    MapService = mapService
                })
                {
                    if (dialog.ShowDialog(this) == DialogResult.OK)
                    {
                        var newViewState = dialog.NewViewState;
                        AppSettings.ViewStates.Add(newViewState);

                        SaveAppState();

                        ResetViews();
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler("Error displaying Create View Wizard", ex);
            }
        }
        #endregion

        #region full screen
        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F11)
                ToggleFullscreen();
        }
        protected virtual void ToggleFullscreen()
        {
            if (_isFullScreen)
            {
                this.TopMost = false;
                this.FormBorderStyle = _previousBorderStyle;
                this.WindowState = _previousWindowState;
            }
            else
            {
                _previousBorderStyle = this.FormBorderStyle;
                _previousWindowState = this.WindowState;

                this.TopMost = true;
                this.FormBorderStyle = FormBorderStyle.None;
                this.WindowState = FormWindowState.Maximized;
            }

            _isFullScreen = !_isFullScreen;
        }
        #endregion

        #region classes

        public class ToolStripRenderer : ToolStripSystemRenderer
        {
            public ToolStripRenderer() { }

            protected override void OnRenderToolStripBorder(ToolStripRenderEventArgs e)
            {
                // comment to prevent toolstrip border from being drawn
                //base.OnRenderToolStripBorder(e);
            }
        }

        #endregion
    }
}
