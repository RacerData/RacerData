using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using log4net;
using log4net.Core;
using Microsoft.Extensions.DependencyInjection;
using RacerData.NascarApi.Client.Models.LiveFeed;
using RacerData.NascarApi.Service;
using RacerData.NascarApi.Service.Ports;
using RacerData.rNascarApp.Controls;
using RacerData.rNascarApp.Dialogs;
using RacerData.rNascarApp.Logging;
using RacerData.rNascarApp.Models;
using RacerData.rNascarApp.Services;
using RacerData.rNascarApp.Themes;
using RacerData.UpdaterService.Models;
using RacerData.WinForms.Ports;

namespace RacerData.rNascarApp
{
    public partial class MainForm : Form, IMonitorClient
    {
        #region consts

        private const string ApplicationTitle = "r/NACAR Timing and Scoring";
        private const int MaxGridRows = 100;
        private const int MaxGridColumns = 100;

        #endregion

        #region events

        public delegate void LiveFeedSafeCallDelegate(object sender, LiveFeedUpdatedEventArgs e);
        public delegate void LapAveragesSafeCallDelegate(object sender, LapAveragesUpdatedEventArgs e);
        public delegate void LapTimesSafeCallDelegate(object sender, LapTimesUpdatedEventArgs e);
        public delegate void LivePitDataSafeCallDelegate(object sender, LivePitDataUpdatedEventArgs e);
        public delegate void LiveFlagDataSafeCallDelegate(object sender, LiveFlagDataUpdatedEventArgs e);
        public delegate void LivePointsDataSafeCallDelegate(object sender, LivePointsDataUpdatedEventArgs e);
        public delegate void LiveQualifyingDataSafeCallDelegate(object sender, LiveQualifyingDataUpdatedEventArgs e);

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
        private IMonitorService _feedService = null;
        private IWorkspaceService _workspaceService = null;
        private ILocalUpdaterService _localUpdaterService;
        private IDialogService _dialogService;
        private IExceptionHandlerService _exceptionHandlerService;
        private Color _gridTableBackColor = Color.FromArgb(0, 28, 28, 28);
        private bool _isMonitorEnabled = false;
        private bool _isFullScreen = false;
        private bool _isLoading = true;
        private FormBorderStyle _previousBorderStyle;
        private FormWindowState _previousWindowState;
        private SplashForm _splashScreen = new SplashForm();

        private IStateService _stateService { get; set; }

        private ILog _log { get; set; }

        // TODO: ThemeService
        private IList<Theme> _themes { get; set; }

        #endregion

        #region ctor/load

        public MainForm()
        {
            InitializeComponent();

            tlsMain.Renderer = new ToolStripRenderer();
            menuStrip1.Renderer = new ToolStripRenderer();

            Logger.Setup();
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
                this.Hide();

                Application.DoEvents();

                this.SuspendLayout();

                InitializeMainForm();
            }
            catch (Exception ex)
            {
                ExceptionHandler("Error loading main form", ex);
            }
            finally
            {
                if (Properties.Settings.Default.ShowSplash)
                    SplashForm.CloseSplash(SplashForm.SplashTypeOfMessage.Success, string.Empty, false);

                this.ResumeLayout(true);

                this.Show();

                this.Activate();
            }
        }

        protected virtual void InitializeMainForm()
        {
            try
            {
                SplashForm.SplashMessage("Initializing logging...");
                _log = LogManager.GetLogger("MainForm");

                SplashForm.SplashMessage("Loading framework services...");
                _dialogService = ServiceProvider.Instance.GetRequiredService<IDialogService>();
                _exceptionHandlerService = ServiceProvider.Instance.GetRequiredService<IExceptionHandlerService>();

                SplashForm.SplashMessage("Applying window state...");
                ApplyWindowState();

                SplashForm.SplashMessage("Loading themes...");
                _themes = UserThemeRepository.GetThemes();

                SplashForm.SplashMessage("Loading API feed service...");
                _feedService = ServiceProvider.Instance.GetRequiredService<IMonitorService>();

                SplashForm.SplashMessage("Loading application state services...");
                _stateService = ServiceProvider.Instance.GetRequiredService<IStateService>();

                tlsMain.DataBindings.Add(new Binding("Visible", _stateService.State, "ShowToolBar", false, DataSourceUpdateMode.OnPropertyChanged));
                MainStatusStrip.DataBindings.Add(new Binding("Visible", _stateService.State, "ShowStatusBar", false, DataSourceUpdateMode.OnPropertyChanged));

                SplashForm.SplashMessage("Loading workspace services...");
                _workspaceService = ServiceProvider.Instance.GetRequiredService<IWorkspaceService>();
                _workspaceService.CurrentWorkspaceChanging += WorkspaceService_CurrentWorkspaceChanging;
                _workspaceService.CurrentWorkspaceChanged += WorkspaceService_WorkspaceChanged;
                UpdateCurrentWorkspace(_workspaceService.CurrentWorkspace);

                SplashForm.SplashMessage("Updating API monitor state...");
                SetMonitorState(_stateService.State.AutoStartApiMonitor);

                // TODO: Apply theme
            }
            catch (Exception ex)
            {
                ExceptionHandler("Error initializing main form", ex);
            }
            finally
            {
                SplashForm.SplashMessage("Ready!");
                _isLoading = false;
            }
        }

        #endregion

        #region logging
        protected virtual void ExceptionHandler(string message, Exception ex)
        {
            _exceptionHandlerService.HandleException(this, message, ex);
            //_log?.Error(message, ex);

            //_dialogService.DisplayException(this, message, ex);
        }
        protected virtual void SetLogLevel(Level logLevel)
        {
            if (((log4net.Repository.Hierarchy.Hierarchy)LogManager.GetRepository()).Root.Level == logLevel)
                return;

            ((log4net.Repository.Hierarchy.Hierarchy)LogManager.GetRepository()).Root.Level = logLevel;
            ((log4net.Repository.Hierarchy.Hierarchy)LogManager.GetRepository()).RaiseConfigurationChanged(EventArgs.Empty);

            if (_stateService.State.LogLevel != logLevel)
                _stateService.State.LogLevel = logLevel;

            LogInfo($"Log level set to {logLevel.ToString()}");
        }
        protected virtual void LogInfo(string message)
        {
            if (_log == null)
                Console.WriteLine(message);
            else
                _log.Info(message);
        }
        #endregion

        #region help

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DisplayAboutDialog();
        }

        private async void checkForupdatesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            await CheckForUpdates();
        }

        protected virtual void DisplayAboutDialog()
        {
            try
            {
                using (var dialog = new AboutDialog())
                {
                    dialog.ShowDialog(this);
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler("Error displaying About.. dialog", ex);
            }
        }

        protected virtual async Task CheckForUpdates()
        {
            try
            {
                _localUpdaterService = ServiceProvider.Instance.GetRequiredService<ILocalUpdaterService>();

                var currentVersion = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;

                var result = await _localUpdaterService.CheckForUpdatesAsync(currentVersion);

                if (result.HasUpdatesAvailable)
                {
                    var updateType = ((IUpdate)result.LatestUpdate).IsUpgrade ? "Upgrade" : "Patches";

                    var message = $"{updateType} available: {result.LatestUpdate.Version.ToString()}.";

                    var installUpdatePromptResult = _dialogService.DisplayMessageBox(
                        this,
                        $"Updates Available for {currentVersion}",
                        $"{message}\r\nWould you like to update now?\r\n(The application will have to close to be updated)",
                        WinForms.Models.ButtonTypes.YesNo);


                    if (installUpdatePromptResult == DialogResult.Yes)
                    {
                        InstallUpdates();
                    }
                }
                else
                {

                    _dialogService.DisplayMessageBox(
                        this,
                        "You are up to date!",
                        $"No updates available for {currentVersion}",
                        WinForms.Models.ButtonTypes.Ok);
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler("Error checking for updates", ex);
            }
        }

        protected virtual void InstallUpdates()
        {
            _localUpdaterService.DisplayUpdater();
            Close();
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

                    dragFrame.Size = ctl.Size;

                    Point pt = this.PointToClient(Cursor.Position);

                    dragFrame.Location = new Point(pt.X - _dragPoint.X,
                                                   pt.Y + 3);

                    if (dragFrame.BackgroundImage != null)
                        dragFrame.BackgroundImage.Dispose();
                    Bitmap bmp = new Bitmap(dragFrame.ClientSize.Width,
                                            dragFrame.ClientSize.Height);
                    ctl.DrawToBitmap(bmp, dragFrame.ClientRectangle);
                    dragFrame.BackgroundImage = bmp;

                    dragFrame.BringToFront();
                    dragFrame.Show();
                    ctl.DoDragDrop(ctl, DragDropEffects.Copy | DragDropEffects.Move);
                }
            };

            ctl.MouseUp += (s, e) =>
            {
                if (e.Button == MouseButtons.Left)
                {
                    dragFrame.Hide();
                    dragTimer.Stop();
                }
            };

            ctl.Leave += (s, e) =>
            {
                dragFrame.Hide();
                dragTimer.Stop();
            };
        }

        protected virtual void DragTimer_Tick(object sender, EventArgs e)
        {
            if ((Control.MouseButtons & MouseButtons.Left) == MouseButtons.None)
            {
                dragFrame.Hide();
                dragTimer.Stop();
            }

            if (dragFrame.Visible)
            {
                Point pt = this.PointToClient(Cursor.Position);

                dragFrame.Location = new Point(pt.X - _dragPoint.X,
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
                    GridTable.BackColor = Color.Red;
                }
                else if ((newCell.Value.X + columnSpan) > GridTable.ColumnCount)
                {
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
                dragFrame.Hide();
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

                        controlBase.View.CellPosition.Row = newCell.Value.X;
                        controlBase.View.CellPosition.Column = newCell.Value.Y;
                    }
                }

                GridTable.BackColor = _gridTableBackColor;

                UpdateGridCapacity();
            }
            catch (ArgumentException)
            {
                _dialogService.DisplayMessageBox(this, "Outside Grid Bounds", "Can't move view here", WinForms.Models.ButtonTypes.Ok);
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

            int row = i + (_isFullScreen ? 1 : 0);

            return new Point(col, row);
        }
        #endregion

        #region control base

        protected virtual UserControlBase AddControl(ViewState view)
        {
            UserControlBase controlBase = null;

            try
            {
                SetViewSize(view);

                controlBase = new UserControlBase(view);

                controlBase.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Right;

                GridTable.Controls.Add(controlBase, view.CellPosition.Column, view.CellPosition.Row);
                GridTable.SetRowSpan(controlBase, view.CellPosition.RowSpan);
                GridTable.SetColumnSpan(controlBase, view.CellPosition.ColumnSpan);

                UpdateGridCapacity();

                this.ThemeUpdated += controlBase.OnThemeUpdated;
                this.ViewStateUpdated += controlBase.OnViewStateUpdated;
                controlBase.ResizeControlRequest += ControlBase_ResizeControlRequest;
                controlBase.RemoveControlRequest += ControlBase_RemoveControlRequest;
                controlBase.EditThemeRequest += ControlBase_EditThemeRequest;
                controlBase.EditViewRequest += ControlBase_EditViewRequest;

                ConfigureDragging(controlBase);

                if (!_workspaceService.CurrentWorkspace.ViewStates.Contains(controlBase.View.Id))
                    _workspaceService.CurrentWorkspace.ViewStates.Add(controlBase.View.Id);
            }
            catch (Exception ex)
            {
                ExceptionHandler("Error adding a new view", ex);
                GridTable.Controls.Remove(controlBase);
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

            controlBase.Dispose();
        }

        protected virtual void ControlBase_RemoveControlRequest(object sender, EventArgs e)
        {
            UserControlBase controlToClose = (UserControlBase)sender;

            RemoveUserControlBase(controlToClose);

            RemoveViewFromWorkspace(controlToClose.View);
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
            DisplayViewManagement(e);
        }
        private void ControlBase_EditThemeRequest(object sender, Guid e)
        {
            DisplayThemeDialog(e);
        }
        #endregion

        #region workspaces
        private void WorkspaceService_CurrentWorkspaceChanging(object sender, WorkspaceChangedEventArgs e)
        {
            // TODO: Update views?
            e.CurrentWorkspace.GridColumnCount = GridTable.ColumnCount;
            e.CurrentWorkspace.GridRowCount = GridTable.RowCount;
        }
        private void WorkspaceService_WorkspaceChanged(object sender, WorkspaceChangedEventArgs e)
        {
            UpdateCurrentWorkspace(e.CurrentWorkspace);
        }

        private void newWorkspaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateNewWorkspace();
        }
        private void saveWorkspaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveApplicationStates();
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
        private void workspaceManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DisplayWorkspaceManagement();
        }

        // dropdown menu item
        private void workspacesDropDownButton1_DropDownOpening(object sender, EventArgs e)
        {
            try
            {
                foreach (ToolStripMenuItem item in workspacesDropDownButton1.DropDownItems.OfType<ToolStripMenuItem>())
                {
                    if (item.Tag is Workspace)
                        item.CheckedChanged -= WorkspaceSelectionMenuItem_CheckedChanged;
                }

                workspacesDropDownButton1.DropDownItems.Clear();

                foreach (Workspace workspace in _workspaceService.Workspaces)
                {
                    var workspaceMenuItem = new ToolStripMenuItem();
                    workspaceMenuItem.Name = $"{workspace.Name.Replace(" ", "_")}MenuItem";
                    workspaceMenuItem.Size = new Size(180, 22);

                    workspaceMenuItem.Text = workspace.IsDefaultPracticeWorkspace ? $"{workspace.Name} [Practice]" :
                        workspace.IsDefaultQualifyingWorkspace ? $"{workspace.Name} [Qualifying]" :
                        workspace.IsDefaultRaceWorkspace ? $"{workspace.Name} [Race]" :
                        workspace.Name;

                    workspaceMenuItem.CheckOnClick = true;
                    workspaceMenuItem.Checked = workspace.IsActive;
                    workspaceMenuItem.Tag = workspace;

                    workspaceMenuItem.CheckedChanged += WorkspaceSelectionMenuItem_CheckedChanged;
                    workspacesDropDownButton1.DropDownItems.AddRange(new ToolStripItem[] { workspaceMenuItem });

                    workspaceMenuItem.ForeColor = workspacesDropDownButton1.ForeColor;
                    workspaceMenuItem.BackColor = workspacesDropDownButton1.BackColor;
                    workspaceMenuItem.Font = lblCurrentWorkspaceCaption.Font;
                }

                var separator = new ToolStripSeparator();
                separator.Name = "workspaceManagementSeparatorMenuItem";
                separator.Size = new Size(180, 22);
                separator.ForeColor = workspacesDropDownButton1.ForeColor;
                separator.BackColor = workspacesDropDownButton1.BackColor;
                workspacesDropDownButton1.DropDownItems.AddRange(new ToolStripItem[] { separator });

                // add a menu item for workspace management
                var workspaceManagementMenuItem = new ToolStripMenuItem();
                workspaceManagementMenuItem.Name = "workspaceManagementMenuItem";
                workspaceManagementMenuItem.Size = new Size(180, 22);
                workspaceManagementMenuItem.Text = "Workspace Manager";
                workspaceManagementMenuItem.Click += (s, args) => { DisplayWorkspaceManagement(); };
                workspaceManagementMenuItem.Image = Properties.Resources.workspace;
                workspaceManagementMenuItem.ForeColor = workspacesDropDownButton1.ForeColor;
                workspaceManagementMenuItem.BackColor = workspacesDropDownButton1.BackColor;
                workspaceManagementMenuItem.Font = lblCurrentWorkspaceCaption.Font;
                workspacesDropDownButton1.DropDownItems.AddRange(new ToolStripItem[] { workspaceManagementMenuItem });
            }
            catch (Exception ex)
            {
                ExceptionHandler("Error displaying workspace list", ex);
            }
        }
        private void WorkspaceSelectionMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            ToolStripMenuItem item = (ToolStripMenuItem)sender;
            Workspace workspace = (Workspace)item.Tag;

            if (item.Checked)
            {
                _workspaceService.SetActiveWorkspace(workspace.Name);
            }
        }

        protected virtual void DisplayWorkspaceManagement()
        {
            try
            {
                using (var dialog = ServiceProvider.Instance.GetRequiredService<WorkspaceManagementDialog>())
                {
                    var workspaceManagementDialogResult = dialog.ShowDialog(this);

                    if (workspaceManagementDialogResult == DialogResult.OK)
                    {
                        var changeSet = dialog.ChangeSet;

                        if (changeSet.HasChanges)
                        {
                            _workspaceService.ProcessChangeSet(changeSet);

                            _workspaceService.Save();

                            UpdateCurrentWorkspace(_workspaceService.CurrentWorkspace);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler("Error displaying Workspace Management form", ex);
            }
        }

        protected virtual void UpdateCurrentWorkspace(Workspace workspace)
        {
            try
            {
                this.SuspendLayout();

                UpdateGridRowColumnCounts(workspace.GridRowCount, workspace.GridColumnCount);

                string version = System.Reflection.Assembly.GetEntryAssembly().GetName().Version.ToString();

                this.Text = $"{ApplicationTitle} v{version} [{workspace.Name}]";

                lblWorkspace.Text = workspace.Name;

                workspacesDropDownButton1.Text = workspace.Name;

                ReloadViews();
            }
            catch (Exception ex)
            {
                ExceptionHandler("Error setting current workspace", ex);
            }
            finally
            {
                this.ResumeLayout();
            }
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
                                var result = _dialogService.DisplayMessageBox(
                                    this,
                                    "Error copying workspace",
                                    $"The name '{Workspace.DefaultWorkspaceName}' is reserved.\r\n\r\nDo you want to try again?",
                                    WinForms.Models.ButtonTypes.YesNo,
                                    WinForms.Models.MsgIcon.Error);

                                isDone = (result != DialogResult.Yes);
                            }
                            else if (dialog.Value == String.Empty)
                            {
                                var result = _dialogService.DisplayMessageBox(
                                   this,
                                   "Error copying workspace",
                                   $"The name cannot be blank.\r\n\r\nDo you want to try again?",
                                   WinForms.Models.ButtonTypes.YesNo,
                                   WinForms.Models.MsgIcon.Error);

                                isDone = (result != DialogResult.Yes);
                            }
                            else
                            {
                                var newWorkspace = workspace.Copy(dialog.Value);

                                try
                                {
                                    _workspaceService.AddWorkspace(newWorkspace);

                                    _workspaceService.Save();

                                    _workspaceService.SetActiveWorkspace(newWorkspace.Name);

                                    _dialogService.DisplayMessageBox(
                                        this,
                                        "Workspace copied",
                                        $"Workspace '{newWorkspace.Name}' has been set as the active workspace",
                                        WinForms.Models.ButtonTypes.Ok,
                                        WinForms.Models.MsgIcon.Information);

                                    isDone = true;
                                }
                                catch (InvalidOperationException ex)
                                {
                                    var result = _dialogService.DisplayMessageBox(
                                        this,
                                        "Error copying workspace",
                                        $"There was an error copying the workspace:\r\n{ex.Message}\r\n\r\nDo you want to try again?",
                                        WinForms.Models.ButtonTypes.YesNo,
                                        WinForms.Models.MsgIcon.Error);

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
                                var result = _dialogService.DisplayMessageBox(
                                    this,
                                    "Error creating workspace",
                                    $"The name '{Workspace.DefaultWorkspaceName}' is reserved.\r\n\r\nDo you want to try again?",
                                    WinForms.Models.ButtonTypes.YesNo,
                                    WinForms.Models.MsgIcon.Error);

                                isDone = (result != DialogResult.Yes);
                            }
                            else if (dialog.Value == String.Empty)
                            {
                                var result = _dialogService.DisplayMessageBox(
                                      this,
                                      "Error creating workspace",
                                      $"The name cannot be blank.\r\n\r\nDo you want to try again?",
                                      WinForms.Models.ButtonTypes.YesNo,
                                      WinForms.Models.MsgIcon.Error);

                                isDone = (result != DialogResult.Yes);
                            }
                            else
                            {
                                var newWorkspace = new Workspace()
                                {
                                    Name = dialog.Value,
                                    GridColumnCount = GridTable.ColumnCount,
                                    GridRowCount = GridTable.RowCount
                                };

                                try
                                {
                                    _workspaceService.AddWorkspace(newWorkspace);

                                    _workspaceService.SetActiveWorkspace(newWorkspace.Name);

                                    _dialogService.DisplayMessageBox(
                                        this,
                                        "Workspace created",
                                        $"Workspace '{newWorkspace.Name}' has been set as the active workspace",
                                        WinForms.Models.ButtonTypes.Ok,
                                        WinForms.Models.MsgIcon.Information);

                                    isDone = true;
                                }
                                catch (InvalidOperationException ex)
                                {
                                    var result = _dialogService.DisplayMessageBox(
                                        this,
                                        "Error creating workspace",
                                        $"There was an error creating the workspace:\r\n{ex.Message}\r\n\r\nDo you want to try again?",
                                        WinForms.Models.ButtonTypes.YesNo,
                                        WinForms.Models.MsgIcon.Error);

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

                var result = _dialogService.DisplayMessageBox(
                    this,
                    "Comfirm delete",
                    $"You are about to permanently delete workspace '{workspace.Name}'.\r\n\r\nContinue?",
                    WinForms.Models.ButtonTypes.YesNo,
                    WinForms.Models.MsgIcon.Warning);

                if (result != DialogResult.Yes)
                    return;

                _workspaceService.RemoveWorkspace(workspace);

                _dialogService.DisplayMessageBox(
                    this,
                    "Workspace removed",
                    $"Workspace '{workspace.Name}' has been deleted",
                    WinForms.Models.ButtonTypes.Ok,
                    WinForms.Models.MsgIcon.Information);

                workspace = null;
            }
            catch (Exception ex)
            {
                ExceptionHandler($"Error deleting workspace", ex);
            }
        }
        #endregion

        #region view functions
        #region view management
        private void viewDesignerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DisplayViewManagement();
        }
        private void btnViewDesigner_Click(object sender, EventArgs e)
        {
            DisplayViewManagement();
        }
        private void viewManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DisplayViewManagement(null);
        }

        protected virtual void DisplayViewManagement(ViewState viewState = null)
        {
            try
            {
                using (var dialog = ServiceProvider.Instance.GetRequiredService<ViewManagementDialog>())
                {
                    dialog.View = viewState;

                    var viewManagementDialogResult = dialog.ShowDialog(this);

                    if (viewManagementDialogResult == DialogResult.OK)
                    {
                        var changeSet = dialog.ChangeSet;

                        if (changeSet.HasChanges)
                        {
                            _stateService.ProcessChangeSet(changeSet);

                            _workspaceService.ProcessChangeSet(changeSet);

                            _stateService.Save();

                            _workspaceService.Save();

                            UpdateCurrentWorkspace(_workspaceService.CurrentWorkspace);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler("Error displaying View Management form", ex);
            }
        }
        #endregion

        #region view wizard
        private void viewToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DisplayNewViewWizard();
        }

        protected virtual void DisplayNewViewWizard()
        {
            try
            {
                using (var dialog = ServiceProvider.Instance.GetRequiredService<CreateViewWizard>())
                {
                    if (dialog.ShowDialog(this) == DialogResult.OK)
                    {
                        var view = dialog.ViewState;

                        SetViewSize(view);

                        _stateService.State.ViewStates.Add(view);

                        _workspaceService.CurrentWorkspace.ViewStates.Add(view.Id);

                        ReloadViews();
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler("Error displaying Create View Wizard", ex);
            }
        }
        #endregion

        #region views  
        private void viewListToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
        {
            try
            {
                foreach (ToolStripMenuItem item in viewListToolStripMenuItem.DropDownItems)
                {
                    item.CheckedChanged -= ViewStateStripMenuItem_CheckedChanged;
                }

                viewListToolStripMenuItem.DropDownItems.Clear();

                foreach (ViewState viewState in _stateService.State.ViewStates)
                {
                    var viewStateStripMenuItem = new ToolStripMenuItem();
                    viewStateStripMenuItem.Name = $"{viewState.Name.Replace(" ", "_")}MenuItem";
                    viewStateStripMenuItem.Size = new Size(180, 22);
                    viewStateStripMenuItem.Text = viewState.Name;
                    viewStateStripMenuItem.CheckOnClick = true;
                    viewStateStripMenuItem.ForeColor = viewListToolStripMenuItem.ForeColor;
                    viewStateStripMenuItem.BackColor = viewListToolStripMenuItem.BackColor;
                    viewStateStripMenuItem.Font = viewListToolStripMenuItem.Font;
                    viewStateStripMenuItem.Tag = viewState;

                    foreach (UserControlBase controlBase in GridTable.Controls.OfType<UserControlBase>())
                    {
                        if (controlBase.View.Name == viewState.Name)
                        {
                            viewStateStripMenuItem.Checked = true;
                            break;
                        }
                    }

                    viewStateStripMenuItem.CheckedChanged += ViewStateStripMenuItem_CheckedChanged;
                    viewListToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { viewStateStripMenuItem });
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
            ViewState view = (ViewState)item.Tag;

            if (item.Checked)
            {
                AddControl(view);
            }
            else
            {
                UserControlBase controlToClose = null;
                foreach (UserControlBase controlBase in GridTable.Controls.OfType<UserControlBase>())
                {
                    if (controlBase.View.Name == view.Name)
                    {
                        controlToClose = controlBase;
                        break;
                    }
                }
                if (controlToClose != null)
                {
                    RemoveUserControlBase(controlToClose);
                    RemoveViewFromWorkspace(controlToClose.View);
                }
            }
        }

        protected virtual void SetViewSize(ViewState view)
        {
            UpdateNullRowWidths(view);

            view.CellPosition.Row = Math.Min(view.CellPosition.Row, GridTable.RowCount);
            view.CellPosition.Column = Math.Min(view.CellPosition.Column, GridTable.ColumnCount);
            view.CellPosition.RowSpan = Math.Min(view.CellPosition.RowSpan, GridTable.RowCount);
            view.CellPosition.ColumnSpan = Math.Min(view.CellPosition.ColumnSpan, GridTable.ColumnCount);

            if (view.CellPosition.RowSpan <= 1 && view.CellPosition.ColumnSpan <= 1)
            {
                view.CellPosition.RowSpan = _stateService.State.DefaultViewSize.X;
                view.CellPosition.ColumnSpan = _stateService.State.DefaultViewSize.Y;
            }

            return;

            // TODO - refactor SetViewSize

            //var defaultRowCount = 8;
            //var defaultRowHeight = 24;
            //var defaultColumnWidth = 150;

            //// width
            //var gridWidth = view.ListDefinition.Columns.Sum(c => c.Width.HasValue ? c.Width.Value : defaultColumnWidth);

            //view.CellPosition.ColumnSpan = (gridWidth / (int)GridTable.ColumnStyles[0].Width);

            //// height
            //var listRowsCount = view.ListDefinition.MaxRows.HasValue ?
            //    view.ListDefinition.MaxRows.Value :
            //    defaultRowCount;

            //var captionCount = view.ListDefinition.ShowCaptions ? 1 : 0;
            //var headerCount = view.ListDefinition.ShowHeader ? 1 : 0;
            //headerCount += view.ListDefinition.MultilineHeader ? 1 : 0;

            //var totalGridRowCount = listRowsCount + captionCount + headerCount;

            //var rowHeight = view.ListDefinition.RowHeight.HasValue ?
            //    view.ListDefinition.RowHeight.Value :
            //    defaultRowHeight;

            //var gridHeight = rowHeight * totalGridRowCount;

            //view.CellPosition.RowSpan = (gridHeight / (int)GridTable.RowStyles[0].Height);
        }

        protected virtual void UpdateNullRowWidths(ViewState view)
        {
            if (view.ListDefinition.Columns.Count(c => c.Width == null && c.Fill == false) <= 0)
                return;

            Image image = new Bitmap(1, 1);
            Graphics graphics = Graphics.FromImage(image);
            var theme = _themes.FirstOrDefault(t => t.Id == view.ThemeId);
            foreach (var column in view.ListDefinition.Columns)
            {
                if (column.Width == null && !column.Fill)
                {
                    SizeF labelTextSize = graphics.MeasureString(column.Caption, theme.GridFont);
                    column.Width = (int)Math.Round(labelTextSize.Width);
                }
            }
        }

        protected virtual void ReloadViews()
        {
            try
            {
                if (!_isLoading)
                {
                    ClearViews();
                }

                LoadViews();
            }
            catch (Exception ex)
            {
                ExceptionHandler("Error resetting views", ex);
            }
        }
        protected virtual void ClearViews()
        {
            foreach (UserControlBase controlBase in GridTable.Controls.OfType<UserControlBase>().ToList())
            {
                RemoveUserControlBase(controlBase);
            }
        }
        protected virtual void LoadViews()
        {
            var currentWorkspace = _workspaceService.CurrentWorkspace;

            foreach (Guid viewStateId in currentWorkspace.ViewStates.ToList())
            {
                try
                {
                    var viewState = _stateService.State.ViewStates.SingleOrDefault(v => v.Id == viewStateId);

                    if (viewState == null)
                    {
                        currentWorkspace.ViewStates.Remove(viewStateId);
                        throw new ArgumentException($"Invalid View Id {viewStateId} in Workspace '{currentWorkspace.Name}'.\r\nView has been removed from workspace.");
                    }

                    AddControl(viewState);
                }
                catch (Exception ex)
                {
                    ExceptionHandler("Error loading workspace", ex);
                }
            }
        }
        protected virtual void UpdateViews()
        {
            int i = 0;

            foreach (UserControlBase controlBase in GridTable.Controls.OfType<UserControlBase>().ToList())
            {
                var cell = GridTable.GetPositionFromControl(controlBase);

                var existingViewState = _stateService.State.ViewStates.FirstOrDefault(v => v.Id == controlBase.View.Id);

                if (existingViewState == null)
                {
                    var viewState = new ViewState()
                    {
                        Id = Guid.NewGuid(),
                        Name = controlBase.Name,
                        HeaderText = controlBase.View.HeaderText,
                        Index = i,
                        CellPosition = new ViewCellPosition()
                        {
                            Row = cell.Row,
                            Column = cell.Column,
                            RowSpan = GridTable.GetRowSpan(controlBase),
                            ColumnSpan = GridTable.GetColumnSpan(controlBase)
                        },
                        ListDefinition = controlBase.View.ListDefinition,
                        ThemeId = controlBase.View.ThemeId
                    };

                    _stateService.State.ViewStates.Add(viewState);
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
                    existingViewState.ThemeId = controlBase.View.ThemeId;
                }

                i++;
            }

            _workspaceService.CurrentWorkspace.GridColumnCount = GridTable.ColumnCount;
            _workspaceService.CurrentWorkspace.GridRowCount = GridTable.RowCount;
        }
        protected virtual void RemoveViewFromWorkspace(ViewState view)
        {
            _workspaceService.CurrentWorkspace.ViewStates.Remove(view.Id);
        }
        #endregion
        #endregion

        #region form closing
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveWindowState();

            UpdateViews();

            if (!_stateService.State.AutoSaveOnExit &&
                (e.CloseReason == CloseReason.UserClosing ||
                e.CloseReason == CloseReason.ApplicationExitCall))
            {
                e.Cancel = PromptToSaveChanges();
            }
            else
            {
                SaveApplicationStates();
            }
        }

        protected virtual bool PromptToSaveChanges()
        {
            bool cancelClose = false;

            var workspaceHasChanges = _workspaceService.HasChanges;
            var stateHasChanges = _stateService.HasChanges;

            if (workspaceHasChanges || stateHasChanges)
            {
                var promptResult = _dialogService.DisplayMessageBox(
                    this,
                    "Unsaved Changes",
                    "Save changes before exiting?",
                    WinForms.Models.ButtonTypes.YesNoCancel,
                    WinForms.Models.MsgIcon.Question);

                if (promptResult == DialogResult.Yes)
                {
                    SaveApplicationStates();
                }
                else if (promptResult == DialogResult.Cancel)
                {
                    cancelClose = true;
                }
            }

            return cancelClose;
        }

        protected virtual void SaveApplicationStates()
        {
            _stateService.Save();
            _workspaceService.Save();
        }

        protected virtual void SaveWindowState()
        {
            if (WindowState == FormWindowState.Maximized)
            {
                Properties.Settings.Default.Location = RestoreBounds.Location;
                Properties.Settings.Default.Size = RestoreBounds.Size;
                Properties.Settings.Default.Maximized = true;
                Properties.Settings.Default.Minimized = false;
            }
            else if (WindowState == FormWindowState.Normal)
            {
                Properties.Settings.Default.Location = Location;
                Properties.Settings.Default.Size = Size;
                Properties.Settings.Default.Maximized = false;
                Properties.Settings.Default.Minimized = false;
            }
            else
            {
                Properties.Settings.Default.Location = RestoreBounds.Location;
                Properties.Settings.Default.Size = RestoreBounds.Size;
                Properties.Settings.Default.Maximized = false;
                Properties.Settings.Default.Minimized = true;
            }

            Properties.Settings.Default.Save();
        }

        protected virtual void ApplyWindowState()
        {
            if (Properties.Settings.Default.Maximized)
            {
                WindowState = FormWindowState.Maximized;
                Location = Properties.Settings.Default.Location;
                Size = Properties.Settings.Default.Size;
            }
            else if (Properties.Settings.Default.Minimized)
            {
                WindowState = FormWindowState.Minimized;
                Location = Properties.Settings.Default.Location;
                Size = Properties.Settings.Default.Size;
            }
            else
            {
                Location = Properties.Settings.Default.Location;
                Size = Properties.Settings.Default.Size;
            }
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

        #region file viewer
        private void displayLogFileToolStripMenuItem_Click(object sender, EventArgs e)
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
                    btnMonitor.Text = "Stop";
                    btnMonitor.Image = Properties.Resources.pause;

                    var feedTypes = GetFeedTypes();

                    _feedService.Register(this, feedTypes);

                    _feedService.Start();
                }
                else
                {
                    btnMonitor.Text = "Start";
                    btnMonitor.Image = Properties.Resources.Running_16xLG;

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
                feeds |= controlBase.View.ListDefinition.ApiFeedType;
            }

            return feeds;
        }
        private void UpdateStatusLabel(LiveFeedData data)
        {
            var series = data.SeriesType.ToString();
            lblTrackName.Text = data.TrackName;
            lblEvent.Text = $"{series} {data.RunName}";
            lblSession.Text = data.RunType.ToString();
            lblTrackState.Text = data.FlagState.ToString();
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
                        if (data != null)
                        {
                            controlBase.UpdateListRowsData(data);
                        }
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
                    SetMonitorState(false);
                    foreach (UserControlBase controlBase in GridTable.Controls.OfType<UserControlBase>())
                    {
                        var data = controlBase.GetViewData(e.Data, ApiFeedType.LapAverageData);
                        if (data != null)
                        {
                            controlBase.UpdateListRowsData(data);
                        }
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
                        if (data != null)
                        {
                            controlBase.UpdateListRowsData(data);
                        }
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
                        if (data != null)
                        {
                            controlBase.UpdateListRowsData(data);
                        }
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
                        if (data != null)
                        {
                            controlBase.UpdateListRowsData(data);
                        }
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
                        if (data != null)
                        {
                            controlBase.UpdateListRowsData(data);
                        }
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
                        if (data != null)
                        {
                            controlBase.UpdateListRowsData(data);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler("Error receiving live qualifying data", ex);
            }
        }
        #endregion

        #region theme designer
        private void themeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DisplayThemeDialog();
        }
        protected virtual void ThemeDialog_UpdatedTheme(object sender, Theme theme)
        {
            OnThemeUpdated(theme);
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
                    // TODO: Load from service provider
                    Themes = themes,
                    ViewStates = _stateService.State.ViewStates,
                    StateService = _stateService,
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

                _themes = UserThemeRepository.GetThemes();

                foreach (Theme theme in _themes)
                {
                    OnThemeUpdated(theme);
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler("Error displaying themes designer", ex);
            }
        }
        #endregion

        #region grid size
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
            UpdateGridRowColumnCounts(GridTable.RowCount, GridTable.ColumnCount);
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
                UpdateGridRowColumnCounts(e.X, e.Y);
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
            }

            UpdateGridRowColumnCounts(rowCapacity, columnCapacity);
        }
        protected virtual void UpdateGridRowColumnCounts(int rowCount, int columnCount)
        {
            try
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
            catch (Exception ex)
            {
                ExceptionHandler("Error auto-setting grid size", ex);
            }
        }
        protected virtual void IncreaseGridRowCount()
        {
            if (GridTable.RowCount < MaxGridRows - 1)
            {
                UpdateGridRowColumnCounts(GridTable.RowCount + 1, GridTable.ColumnCount);
            }
        }
        protected virtual void DecreaseGridRowCount()
        {
            if (GridTable.RowCount > 3)
            {
                UpdateGridRowColumnCounts(GridTable.RowCount - 1, GridTable.ColumnCount);
            }
        }
        protected virtual void IncreaseGridColumnCount()
        {
            if (GridTable.ColumnCount < MaxGridColumns - 1)
            {
                UpdateGridRowColumnCounts(GridTable.RowCount, GridTable.ColumnCount + 1);
            }
        }
        protected virtual void DecreaseGridColumnCount()
        {
            if (GridTable.ColumnCount > 3)
            {
                UpdateGridRowColumnCounts(GridTable.RowCount, GridTable.ColumnCount - 1);
            }
        }
        #endregion

        #region display formats
        private void displayFormatsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DisplayViewDisplayFormatDialog();
        }

        protected virtual void DisplayViewDisplayFormatDialog()
        {
            try
            {
                using (var dialog = ServiceProvider.Instance.GetRequiredService<DisplayFormatMapDialog>())
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

        #region full screen
        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F11)
                ToggleFullscreen();
            else if (e.KeyCode == Keys.Up && e.Modifiers == Keys.Control)
            {
                IncreaseGridRowCount();
            }
            else if (e.KeyCode == Keys.Down && e.Modifiers == Keys.Control)
            {
                DecreaseGridRowCount();
            }
            else if (e.KeyCode == Keys.Right && e.Modifiers == Keys.Control)
            {
                IncreaseGridColumnCount();
            }
            else if (e.KeyCode == Keys.Left && e.Modifiers == Keys.Control)
            {
                DecreaseGridColumnCount();
            }
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
            // https://referencesource.microsoft.com/#system.windows.forms/winforms/managed/system/winforms/ToolStripRenderer.cs

            public static Color PanelBlue = Color.FromArgb(255, 51, 153, 255);
            public static Color IconBlue = Color.FromArgb(255, 122, 193, 255);

            public static Color LightLightGrey = Color.FromArgb(255, 104, 104, 104);
            public static Color LightGrey = Color.FromArgb(255, 63, 63, 70);
            public static Color MediumGrey = Color.FromArgb(255, 45, 45, 48);
            public static Color DarkGrey = Color.FromArgb(255, 37, 37, 38);
            public static Color DarkDarkGrey = Color.FromArgb(255, 28, 28, 28);

            public static Color UnselectedItemBackColor = MediumGrey;
            public static Color SelectedItemBackColor = PanelBlue;
            public static Color SeparatorBackColor = LightGrey;
            public static Color BorderColor = PanelBlue;

            public ToolStripRenderer() { }

            /// <summary>
            /// Hide the border
            /// </summary>
            /// <param name="e"></param>
            protected override void OnRenderToolStripBorder(ToolStripRenderEventArgs e)
            {
                // comment to prevent toolstrip border from being drawn
                //base.OnRenderToolStripBorder(e);               
            }

            protected override void OnRenderDropDownButtonBackground(ToolStripItemRenderEventArgs e)
            {
                base.OnRenderDropDownButtonBackground(e);
                //Color c = LightLightGrey;
                //using (SolidBrush brush = new SolidBrush(c))
                //    e.Graphics.FillRectangle(brush, e.Item.ContentRectangle);
            }

            protected override void OnRenderArrow(ToolStripArrowRenderEventArgs e)
            {
                e.ArrowColor = PanelBlue;
                base.OnRenderArrow(e);
                //Color c = Color.Gold;// LightLightGrey;
                //using (SolidBrush brush = new SolidBrush(c))
                //    e.Graphics.FillRectangle(brush, e.ArrowRectangle);
            }

            /// <summary>
            /// Border surrounding all drop down menu items
            /// Can be overwritten by ImageMargin
            /// </summary>
            /// <param name="e"></param>
            protected override void OnRenderToolStripBackground(ToolStripRenderEventArgs e)
            {
                ToolStripDropDown dr = e.ToolStrip as ToolStripDropDown;

                if (dr != null)
                {
                    Rectangle rc = e.AffectedBounds;
                    Color c = BorderColor;
                    using (SolidBrush brush = new SolidBrush(c))
                        e.Graphics.FillRectangle(brush, rc);

                    rc.Inflate(-1, -1);
                    Color cInner = UnselectedItemBackColor;
                    using (SolidBrush brush = new SolidBrush(cInner))
                        e.Graphics.FillRectangle(brush, rc);
                }
            }

            /// <summary>
            /// Checked indicator image
            /// </summary>
            /// <param name="e"></param>
            protected override void OnRenderItemCheck(ToolStripItemImageRenderEventArgs e)
            {
                int width = 20;
                int height = 20;
                Bitmap selectedIndicator = new Bitmap(width, height);
                using (Graphics gfx = Graphics.FromImage(selectedIndicator))
                using (SolidBrush brush = new SolidBrush(IconBlue))
                {
                    gfx.FillRectangle(brush, 0, 0, width, height);
                }

                var myE = new ToolStripItemImageRenderEventArgs(e.Graphics, e.Item, selectedIndicator, e.ImageRectangle);
                base.OnRenderItemCheck(myE);
            }

            /// <summary>
            /// Vertical line on far right of menu item
            /// </summary>
            /// <param name="e"></param>
            protected override void OnRenderImageMargin(ToolStripRenderEventArgs e)
            {
                Rectangle rc = new Rectangle(Point.Empty, e.AffectedBounds.Size);
                Color c = BorderColor;
                using (SolidBrush brush = new SolidBrush(c))
                    e.Graphics.FillRectangle(brush, rc);

                rc.Inflate(-1, -1);
                Color cInner = UnselectedItemBackColor;
                using (SolidBrush brush = new SolidBrush(cInner))
                    e.Graphics.FillRectangle(brush, rc);
            }

            /// <summary>
            /// Background color for non-separator items
            /// </summary>
            /// <param name="e"></param>
            protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
            {
                Rectangle rc = new Rectangle(new Point(1, 0), e.Item.Size);
                Color c = e.Item.Selected ? SelectedItemBackColor : UnselectedItemBackColor;
                using (SolidBrush brush = new SolidBrush(c))
                    e.Graphics.FillRectangle(brush, rc);
            }

            /// <summary>
            /// Separator body
            /// </summary>
            /// <param name="e"></param>
            protected override void OnRenderSeparator(ToolStripSeparatorRenderEventArgs e)
            {
                if ((e.Item as ToolStripSeparator) == null)
                {
                    base.OnRenderSeparator(e);
                    return;
                }

                if (!e.Vertical)
                {
                    ToolStripSeparator toolStripSeparator = (ToolStripSeparator)e.Item;
                    int width = toolStripSeparator.Width;
                    int height = toolStripSeparator.Height;
                    e.Graphics.FillRectangle(new SolidBrush(SeparatorBackColor), 0, 0, width, height);
                }
                else
                {
                    base.OnRenderSeparator(e);
                }
            }
        }

        #endregion
    }
}
