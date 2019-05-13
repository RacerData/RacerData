namespace RacerData.rNascarApp
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.workspaceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openWorkspaceToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.saveWorkspaceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyWorkspaceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeWorkspaceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusBarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolBarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.userSettingsFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gridSizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.themeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewDesignerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.displayFormatsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MainStatusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel0 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblTrackName = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblEvent = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblSession = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblTrackState = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblWorkspace = new System.Windows.Forms.ToolStripStatusLabel();
            this.tlsMain = new System.Windows.Forms.ToolStrip();
            this.btnMonitor = new System.Windows.Forms.ToolStripButton();
            this.txtMonitorState = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnThemeDesigner = new System.Windows.Forms.ToolStripButton();
            this.btnViewDesigner = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnGridSize = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnDisplayFormats = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.btnNewViewWizard = new System.Windows.Forms.ToolStripButton();
            this.GridTable = new System.Windows.Forms.TableLayoutPanel();
            this.ctxGridTable = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.gridSizeToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.dragTimer = new System.Windows.Forms.Timer(this.components);
            this.pnlGrid = new System.Windows.Forms.Panel();
            this.workspaceManagementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.MainStatusStrip.SuspendLayout();
            this.tlsMain.SuspendLayout();
            this.ctxGridTable.SuspendLayout();
            this.pnlGrid.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.menuStrip1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.toolsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1211, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openWorkspaceToolStripMenuItem1,
            this.saveWorkspaceToolStripMenuItem,
            this.copyWorkspaceToolStripMenuItem,
            this.removeWorkspaceToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.BackColor = System.Drawing.Color.Black;
            this.newToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewToolStripMenuItem1,
            this.workspaceToolStripMenuItem});
            this.newToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.newToolStripMenuItem.Text = "&New...";
            // 
            // viewToolStripMenuItem1
            // 
            this.viewToolStripMenuItem1.BackColor = System.Drawing.Color.Black;
            this.viewToolStripMenuItem1.ForeColor = System.Drawing.Color.White;
            this.viewToolStripMenuItem1.Name = "viewToolStripMenuItem1";
            this.viewToolStripMenuItem1.Size = new System.Drawing.Size(136, 22);
            this.viewToolStripMenuItem1.Text = "&View";
            this.viewToolStripMenuItem1.Click += new System.EventHandler(this.viewToolStripMenuItem1_Click);
            // 
            // workspaceToolStripMenuItem
            // 
            this.workspaceToolStripMenuItem.BackColor = System.Drawing.Color.Black;
            this.workspaceToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.workspaceToolStripMenuItem.Name = "workspaceToolStripMenuItem";
            this.workspaceToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.workspaceToolStripMenuItem.Text = "&Workspace";
            this.workspaceToolStripMenuItem.Click += new System.EventHandler(this.workspaceToolStripMenuItem_Click);
            // 
            // openWorkspaceToolStripMenuItem1
            // 
            this.openWorkspaceToolStripMenuItem1.BackColor = System.Drawing.Color.Black;
            this.openWorkspaceToolStripMenuItem1.ForeColor = System.Drawing.Color.White;
            this.openWorkspaceToolStripMenuItem1.Name = "openWorkspaceToolStripMenuItem1";
            this.openWorkspaceToolStripMenuItem1.Size = new System.Drawing.Size(185, 22);
            this.openWorkspaceToolStripMenuItem1.Text = "&Open Workspace";
            this.openWorkspaceToolStripMenuItem1.Click += new System.EventHandler(this.openWorkspaceToolStripMenuItem1_Click);
            // 
            // saveWorkspaceToolStripMenuItem
            // 
            this.saveWorkspaceToolStripMenuItem.BackColor = System.Drawing.Color.Black;
            this.saveWorkspaceToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.saveWorkspaceToolStripMenuItem.Name = "saveWorkspaceToolStripMenuItem";
            this.saveWorkspaceToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.saveWorkspaceToolStripMenuItem.Text = "&Save Workspace";
            this.saveWorkspaceToolStripMenuItem.Click += new System.EventHandler(this.saveWorkspaceToolStripMenuItem_Click);
            // 
            // copyWorkspaceToolStripMenuItem
            // 
            this.copyWorkspaceToolStripMenuItem.BackColor = System.Drawing.Color.Black;
            this.copyWorkspaceToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.copyWorkspaceToolStripMenuItem.Name = "copyWorkspaceToolStripMenuItem";
            this.copyWorkspaceToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.copyWorkspaceToolStripMenuItem.Text = "&Copy Workspace";
            this.copyWorkspaceToolStripMenuItem.Click += new System.EventHandler(this.copyWorkspaceToolStripMenuItem_Click);
            // 
            // removeWorkspaceToolStripMenuItem
            // 
            this.removeWorkspaceToolStripMenuItem.BackColor = System.Drawing.Color.Black;
            this.removeWorkspaceToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.removeWorkspaceToolStripMenuItem.Name = "removeWorkspaceToolStripMenuItem";
            this.removeWorkspaceToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.removeWorkspaceToolStripMenuItem.Text = "&Remove Workspace";
            this.removeWorkspaceToolStripMenuItem.Click += new System.EventHandler(this.removeWorkspaceToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.BackColor = System.Drawing.Color.Black;
            this.exitToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusBarToolStripMenuItem,
            this.toolBarToolStripMenuItem,
            this.logFileToolStripMenuItem,
            this.userSettingsFileToolStripMenuItem,
            this.viewListToolStripMenuItem});
            this.viewToolStripMenuItem.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(45, 20);
            this.viewToolStripMenuItem.Text = "&View";
            // 
            // statusBarToolStripMenuItem
            // 
            this.statusBarToolStripMenuItem.BackColor = System.Drawing.Color.Black;
            this.statusBarToolStripMenuItem.Checked = true;
            this.statusBarToolStripMenuItem.CheckOnClick = true;
            this.statusBarToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.statusBarToolStripMenuItem.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.statusBarToolStripMenuItem.Name = "statusBarToolStripMenuItem";
            this.statusBarToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.statusBarToolStripMenuItem.Text = "&Status Bar";
            this.statusBarToolStripMenuItem.CheckedChanged += new System.EventHandler(this.statusBarToolStripMenuItem_CheckedChanged);
            // 
            // toolBarToolStripMenuItem
            // 
            this.toolBarToolStripMenuItem.BackColor = System.Drawing.Color.Black;
            this.toolBarToolStripMenuItem.Checked = true;
            this.toolBarToolStripMenuItem.CheckOnClick = true;
            this.toolBarToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolBarToolStripMenuItem.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.toolBarToolStripMenuItem.Name = "toolBarToolStripMenuItem";
            this.toolBarToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.toolBarToolStripMenuItem.Text = "&Tool Bar";
            this.toolBarToolStripMenuItem.CheckedChanged += new System.EventHandler(this.toolBarToolStripMenuItem_CheckedChanged);
            // 
            // logFileToolStripMenuItem
            // 
            this.logFileToolStripMenuItem.BackColor = System.Drawing.Color.Black;
            this.logFileToolStripMenuItem.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.logFileToolStripMenuItem.Name = "logFileToolStripMenuItem";
            this.logFileToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.logFileToolStripMenuItem.Text = "&Log File";
            this.logFileToolStripMenuItem.Click += new System.EventHandler(this.logFileToolStripMenuItem_Click);
            // 
            // userSettingsFileToolStripMenuItem
            // 
            this.userSettingsFileToolStripMenuItem.BackColor = System.Drawing.Color.Black;
            this.userSettingsFileToolStripMenuItem.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.userSettingsFileToolStripMenuItem.Name = "userSettingsFileToolStripMenuItem";
            this.userSettingsFileToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.userSettingsFileToolStripMenuItem.Text = "&User Settings File";
            this.userSettingsFileToolStripMenuItem.Click += new System.EventHandler(this.userSettingsFileToolStripMenuItem_Click);
            // 
            // viewListToolStripMenuItem
            // 
            this.viewListToolStripMenuItem.BackColor = System.Drawing.Color.Black;
            this.viewListToolStripMenuItem.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.viewListToolStripMenuItem.Name = "viewListToolStripMenuItem";
            this.viewListToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.viewListToolStripMenuItem.Text = "View List";
            this.viewListToolStripMenuItem.DropDownOpening += new System.EventHandler(this.viewListToolStripMenuItem_DropDownOpening);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.BackColor = System.Drawing.Color.Black;
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gridSizeToolStripMenuItem,
            this.themeToolStripMenuItem,
            this.viewDesignerToolStripMenuItem,
            this.displayFormatsToolStripMenuItem,
            this.workspaceManagementToolStripMenuItem});
            this.toolsToolStripMenuItem.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(49, 20);
            this.toolsToolStripMenuItem.Text = "&Tools";
            // 
            // gridSizeToolStripMenuItem
            // 
            this.gridSizeToolStripMenuItem.BackColor = System.Drawing.Color.Black;
            this.gridSizeToolStripMenuItem.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.gridSizeToolStripMenuItem.Name = "gridSizeToolStripMenuItem";
            this.gridSizeToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.gridSizeToolStripMenuItem.Text = "&Grid Size";
            this.gridSizeToolStripMenuItem.Click += new System.EventHandler(this.gridSizeToolStripMenuItem_Click);
            // 
            // themeToolStripMenuItem
            // 
            this.themeToolStripMenuItem.BackColor = System.Drawing.Color.Black;
            this.themeToolStripMenuItem.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.themeToolStripMenuItem.Name = "themeToolStripMenuItem";
            this.themeToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.themeToolStripMenuItem.Text = "&Theme Designer";
            this.themeToolStripMenuItem.Click += new System.EventHandler(this.themeToolStripMenuItem_Click);
            // 
            // viewDesignerToolStripMenuItem
            // 
            this.viewDesignerToolStripMenuItem.BackColor = System.Drawing.Color.Black;
            this.viewDesignerToolStripMenuItem.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.viewDesignerToolStripMenuItem.Name = "viewDesignerToolStripMenuItem";
            this.viewDesignerToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.viewDesignerToolStripMenuItem.Text = "&View Designer";
            this.viewDesignerToolStripMenuItem.Click += new System.EventHandler(this.viewDesignerToolStripMenuItem_Click);
            // 
            // displayFormatsToolStripMenuItem
            // 
            this.displayFormatsToolStripMenuItem.BackColor = System.Drawing.Color.Black;
            this.displayFormatsToolStripMenuItem.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.displayFormatsToolStripMenuItem.Name = "displayFormatsToolStripMenuItem";
            this.displayFormatsToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.displayFormatsToolStripMenuItem.Text = "&Display Formats";
            this.displayFormatsToolStripMenuItem.Click += new System.EventHandler(this.displayFormatsToolStripMenuItem_Click);
            // 
            // MainStatusStrip
            // 
            this.MainStatusStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.MainStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel0,
            this.lblTrackName,
            this.toolStripStatusLabel3,
            this.lblEvent,
            this.toolStripStatusLabel1,
            this.lblSession,
            this.toolStripStatusLabel2,
            this.lblTrackState,
            this.toolStripStatusLabel4,
            this.lblWorkspace});
            this.MainStatusStrip.Location = new System.Drawing.Point(0, 602);
            this.MainStatusStrip.Name = "MainStatusStrip";
            this.MainStatusStrip.Padding = new System.Windows.Forms.Padding(1, 0, 16, 0);
            this.MainStatusStrip.Size = new System.Drawing.Size(1211, 28);
            this.MainStatusStrip.TabIndex = 1;
            this.MainStatusStrip.Text = "statusStrip1";
            this.MainStatusStrip.VisibleChanged += new System.EventHandler(this.MainStatusStrip_VisibleChanged);
            // 
            // toolStripStatusLabel0
            // 
            this.toolStripStatusLabel0.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.toolStripStatusLabel0.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.toolStripStatusLabel0.ForeColor = System.Drawing.Color.Gainsboro;
            this.toolStripStatusLabel0.Name = "toolStripStatusLabel0";
            this.toolStripStatusLabel0.Size = new System.Drawing.Size(42, 23);
            this.toolStripStatusLabel0.Text = "Track:";
            // 
            // lblTrackName
            // 
            this.lblTrackName.AutoSize = false;
            this.lblTrackName.AutoToolTip = true;
            this.lblTrackName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.lblTrackName.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.lblTrackName.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblTrackName.Name = "lblTrackName";
            this.lblTrackName.Size = new System.Drawing.Size(200, 23);
            this.lblTrackName.Text = "-none-";
            this.lblTrackName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.toolStripStatusLabel3.ForeColor = System.Drawing.Color.Gainsboro;
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(39, 23);
            this.toolStripStatusLabel3.Text = "Event:";
            // 
            // lblEvent
            // 
            this.lblEvent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.lblEvent.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.lblEvent.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblEvent.Name = "lblEvent";
            this.lblEvent.Size = new System.Drawing.Size(379, 23);
            this.lblEvent.Spring = true;
            this.lblEvent.Text = "-none-";
            this.lblEvent.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.toolStripStatusLabel1.ForeColor = System.Drawing.Color.Gainsboro;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(49, 23);
            this.toolStripStatusLabel1.Text = "Session:";
            // 
            // lblSession
            // 
            this.lblSession.AutoSize = false;
            this.lblSession.AutoToolTip = true;
            this.lblSession.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.lblSession.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.lblSession.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblSession.Name = "lblSession";
            this.lblSession.Size = new System.Drawing.Size(100, 23);
            this.lblSession.Text = "-none-";
            this.lblSession.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.toolStripStatusLabel2.ForeColor = System.Drawing.Color.Gainsboro;
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(67, 23);
            this.toolStripStatusLabel2.Text = "Track State:";
            // 
            // lblTrackState
            // 
            this.lblTrackState.AutoSize = false;
            this.lblTrackState.AutoToolTip = true;
            this.lblTrackState.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.lblTrackState.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.lblTrackState.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblTrackState.Name = "lblTrackState";
            this.lblTrackState.Size = new System.Drawing.Size(100, 23);
            this.lblTrackState.Text = "-none-";
            this.lblTrackState.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripStatusLabel4
            // 
            this.toolStripStatusLabel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.toolStripStatusLabel4.ForeColor = System.Drawing.Color.White;
            this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            this.toolStripStatusLabel4.Size = new System.Drawing.Size(68, 23);
            this.toolStripStatusLabel4.Text = "Workspace:";
            // 
            // lblWorkspace
            // 
            this.lblWorkspace.AutoSize = false;
            this.lblWorkspace.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.lblWorkspace.ForeColor = System.Drawing.Color.LightGray;
            this.lblWorkspace.Name = "lblWorkspace";
            this.lblWorkspace.Size = new System.Drawing.Size(150, 23);
            this.lblWorkspace.Text = "-none-";
            this.lblWorkspace.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tlsMain
            // 
            this.tlsMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.tlsMain.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tlsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnMonitor,
            this.txtMonitorState,
            this.toolStripSeparator1,
            this.btnThemeDesigner,
            this.btnViewDesigner,
            this.toolStripSeparator2,
            this.btnGridSize,
            this.toolStripSeparator3,
            this.btnDisplayFormats,
            this.toolStripSeparator4,
            this.btnNewViewWizard});
            this.tlsMain.Location = new System.Drawing.Point(0, 24);
            this.tlsMain.Name = "tlsMain";
            this.tlsMain.Size = new System.Drawing.Size(1211, 25);
            this.tlsMain.TabIndex = 2;
            this.tlsMain.Text = "toolStrip1";
            this.tlsMain.VisibleChanged += new System.EventHandler(this.MainToolStrip_VisibleChanged);
            // 
            // btnMonitor
            // 
            this.btnMonitor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.btnMonitor.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnMonitor.Image = global::RacerData.rNascarApp.Properties.Resources.Symbols_Play_32xLG;
            this.btnMonitor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnMonitor.Name = "btnMonitor";
            this.btnMonitor.Size = new System.Drawing.Size(95, 22);
            this.btnMonitor.Text = "Start Monitor";
            this.btnMonitor.ToolTipText = "Monitor On/Off";
            this.btnMonitor.Click += new System.EventHandler(this.btnMonitor_Click);
            // 
            // txtMonitorState
            // 
            this.txtMonitorState.AutoSize = false;
            this.txtMonitorState.BackColor = System.Drawing.Color.DarkGreen;
            this.txtMonitorState.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMonitorState.Name = "txtMonitorState";
            this.txtMonitorState.Size = new System.Drawing.Size(29, 23);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // btnThemeDesigner
            // 
            this.btnThemeDesigner.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnThemeDesigner.Image = global::RacerData.rNascarApp.Properties.Resources.ColorDialog_671;
            this.btnThemeDesigner.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnThemeDesigner.Name = "btnThemeDesigner";
            this.btnThemeDesigner.Size = new System.Drawing.Size(120, 22);
            this.btnThemeDesigner.Text = "Theme Designer";
            this.btnThemeDesigner.ToolTipText = "Theme Designer";
            this.btnThemeDesigner.Click += new System.EventHandler(this.btnThemeDesigner_Click);
            // 
            // btnViewDesigner
            // 
            this.btnViewDesigner.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnViewDesigner.Image = global::RacerData.rNascarApp.Properties.Resources.DialogID_6220_32x;
            this.btnViewDesigner.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnViewDesigner.Name = "btnViewDesigner";
            this.btnViewDesigner.Size = new System.Drawing.Size(107, 22);
            this.btnViewDesigner.Text = "View Designer";
            this.btnViewDesigner.Click += new System.EventHandler(this.btnViewDesigner_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // btnGridSize
            // 
            this.btnGridSize.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnGridSize.Image = global::RacerData.rNascarApp.Properties.Resources._2_two_rows_2_two_columns_9715;
            this.btnGridSize.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnGridSize.Name = "btnGridSize";
            this.btnGridSize.Size = new System.Drawing.Size(76, 22);
            this.btnGridSize.Text = "Grid Size";
            this.btnGridSize.Click += new System.EventHandler(this.btnGridSize_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // btnDisplayFormats
            // 
            this.btnDisplayFormats.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnDisplayFormats.Image = global::RacerData.rNascarApp.Properties.Resources.View_8933_32x;
            this.btnDisplayFormats.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDisplayFormats.Name = "btnDisplayFormats";
            this.btnDisplayFormats.Size = new System.Drawing.Size(117, 22);
            this.btnDisplayFormats.Text = "Display Formats";
            this.btnDisplayFormats.Click += new System.EventHandler(this.btnDisplayFormats_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // btnNewViewWizard
            // 
            this.btnNewViewWizard.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnNewViewWizard.Image = global::RacerData.rNascarApp.Properties.Resources.NewConsoleAppTest_8615;
            this.btnNewViewWizard.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNewViewWizard.Name = "btnNewViewWizard";
            this.btnNewViewWizard.Size = new System.Drawing.Size(121, 22);
            this.btnNewViewWizard.Text = "New View Wizard";
            this.btnNewViewWizard.Click += new System.EventHandler(this.btnNewVeiwWizard_Click);
            // 
            // GridTable
            // 
            this.GridTable.AllowDrop = true;
            this.GridTable.AutoSize = true;
            this.GridTable.BackColor = System.Drawing.Color.Black;
            this.GridTable.ColumnCount = 4;
            this.GridTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.GridTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.GridTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.GridTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.GridTable.ContextMenuStrip = this.ctxGridTable;
            this.GridTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GridTable.Location = new System.Drawing.Point(0, 0);
            this.GridTable.Name = "GridTable";
            this.GridTable.RowCount = 5;
            this.GridTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.GridTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.GridTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.GridTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.GridTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.GridTable.Size = new System.Drawing.Size(1211, 553);
            this.GridTable.TabIndex = 3;
            this.GridTable.DragDrop += new System.Windows.Forms.DragEventHandler(this.GridTable_DragDrop);
            this.GridTable.DragOver += new System.Windows.Forms.DragEventHandler(this.GridTable_DragOver);
            this.GridTable.Resize += new System.EventHandler(this.GridTable_Resize);
            // 
            // ctxGridTable
            // 
            this.ctxGridTable.BackColor = System.Drawing.Color.DimGray;
            this.ctxGridTable.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gridSizeToolStripMenuItem1});
            this.ctxGridTable.Name = "ctxGridTable";
            this.ctxGridTable.Size = new System.Drawing.Size(124, 26);
            // 
            // gridSizeToolStripMenuItem1
            // 
            this.gridSizeToolStripMenuItem1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.gridSizeToolStripMenuItem1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.gridSizeToolStripMenuItem1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridSizeToolStripMenuItem1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.gridSizeToolStripMenuItem1.Name = "gridSizeToolStripMenuItem1";
            this.gridSizeToolStripMenuItem1.Size = new System.Drawing.Size(123, 22);
            this.gridSizeToolStripMenuItem1.Text = "Grid Size";
            this.gridSizeToolStripMenuItem1.Click += new System.EventHandler(this.gridSizeToolStripMenuItem1_Click);
            // 
            // dragTimer
            // 
            this.dragTimer.Interval = 20;
            // 
            // pnlGrid
            // 
            this.pnlGrid.AutoScroll = true;
            this.pnlGrid.Controls.Add(this.GridTable);
            this.pnlGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGrid.Location = new System.Drawing.Point(0, 49);
            this.pnlGrid.Name = "pnlGrid";
            this.pnlGrid.Size = new System.Drawing.Size(1211, 553);
            this.pnlGrid.TabIndex = 4;
            // 
            // workspaceManagementToolStripMenuItem
            // 
            this.workspaceManagementToolStripMenuItem.BackColor = System.Drawing.Color.Black;
            this.workspaceManagementToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.workspaceManagementToolStripMenuItem.Name = "workspaceManagementToolStripMenuItem";
            this.workspaceManagementToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.workspaceManagementToolStripMenuItem.Text = "&Workspace Management";
            this.workspaceManagementToolStripMenuItem.Click += new System.EventHandler(this.workspaceManagementToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1211, 630);
            this.Controls.Add(this.pnlGrid);
            this.Controls.Add(this.tlsMain);
            this.Controls.Add(this.MainStatusStrip);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "r/Nascar Timing & Scoring";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.MainStatusStrip.ResumeLayout(false);
            this.MainStatusStrip.PerformLayout();
            this.tlsMain.ResumeLayout(false);
            this.tlsMain.PerformLayout();
            this.ctxGridTable.ResumeLayout(false);
            this.pnlGrid.ResumeLayout(false);
            this.pnlGrid.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.StatusStrip MainStatusStrip;
        private System.Windows.Forms.ToolStrip tlsMain;
        internal System.Windows.Forms.TableLayoutPanel GridTable;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel0;
        private System.Windows.Forms.ToolStripStatusLabel lblTrackName;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel lblSession;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel lblTrackState;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel lblEvent;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem statusBarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolBarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem userSettingsFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem themeToolStripMenuItem;
        private System.Windows.Forms.Timer dragTimer;
        private System.Windows.Forms.Panel pnlGrid;
        private System.Windows.Forms.ToolStripMenuItem gridSizeToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip ctxGridTable;
        private System.Windows.Forms.ToolStripMenuItem gridSizeToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem viewDesignerToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton btnMonitor;
        private System.Windows.Forms.ToolStripTextBox txtMonitorState;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnThemeDesigner;
        private System.Windows.Forms.ToolStripButton btnViewDesigner;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnGridSize;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem displayFormatsToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton btnDisplayFormats;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton btnNewViewWizard;
        private System.Windows.Forms.ToolStripMenuItem viewListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem workspaceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveWorkspaceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyWorkspaceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openWorkspaceToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem removeWorkspaceToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
        private System.Windows.Forms.ToolStripStatusLabel lblWorkspace;
        private System.Windows.Forms.ToolStripMenuItem workspaceManagementToolStripMenuItem;
    }
}

