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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.workspaceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openWorkspaceToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.saveWorkspaceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyWorkspaceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
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
            this.displayFormatsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.workspaceManagementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewManagementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.lblCurrentWorkspaceCaption = new System.Windows.Forms.ToolStripLabel();
            this.workspacesDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.fffToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.GridTable = new System.Windows.Forms.TableLayoutPanel();
            this.ctxGridTable = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.gridSizeToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.dragTimer = new System.Windows.Forms.Timer(this.components);
            this.pnlGrid = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            this.MainStatusStrip.SuspendLayout();
            this.tlsMain.SuspendLayout();
            this.ctxGridTable.SuspendLayout();
            this.pnlGrid.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.menuStrip1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.toolsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1077, 24);
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
            this.toolStripMenuItem2,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.ForeColor = System.Drawing.Color.DarkGray;
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(38)))));
            this.newToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewToolStripMenuItem1,
            this.workspaceToolStripMenuItem});
            this.newToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.newToolStripMenuItem.Image = global::RacerData.rNascarApp.Properties.Resources._new;
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.newToolStripMenuItem.Text = "&New...";
            // 
            // viewToolStripMenuItem1
            // 
            this.viewToolStripMenuItem1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(38)))));
            this.viewToolStripMenuItem1.ForeColor = System.Drawing.Color.White;
            this.viewToolStripMenuItem1.Image = global::RacerData.rNascarApp.Properties.Resources.newView;
            this.viewToolStripMenuItem1.Name = "viewToolStripMenuItem1";
            this.viewToolStripMenuItem1.Size = new System.Drawing.Size(136, 22);
            this.viewToolStripMenuItem1.Text = "&View";
            this.viewToolStripMenuItem1.Click += new System.EventHandler(this.viewToolStripMenuItem1_Click);
            // 
            // workspaceToolStripMenuItem
            // 
            this.workspaceToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(38)))));
            this.workspaceToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.workspaceToolStripMenuItem.Image = global::RacerData.rNascarApp.Properties.Resources.newWorkspace;
            this.workspaceToolStripMenuItem.Name = "workspaceToolStripMenuItem";
            this.workspaceToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.workspaceToolStripMenuItem.Text = "&Workspace";
            this.workspaceToolStripMenuItem.Click += new System.EventHandler(this.workspaceToolStripMenuItem_Click);
            // 
            // openWorkspaceToolStripMenuItem1
            // 
            this.openWorkspaceToolStripMenuItem1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(38)))));
            this.openWorkspaceToolStripMenuItem1.ForeColor = System.Drawing.Color.White;
            this.openWorkspaceToolStripMenuItem1.Image = global::RacerData.rNascarApp.Properties.Resources.open;
            this.openWorkspaceToolStripMenuItem1.Name = "openWorkspaceToolStripMenuItem1";
            this.openWorkspaceToolStripMenuItem1.Size = new System.Drawing.Size(169, 22);
            this.openWorkspaceToolStripMenuItem1.Text = "&Open Workspace";
            this.openWorkspaceToolStripMenuItem1.Click += new System.EventHandler(this.openWorkspaceToolStripMenuItem1_Click);
            // 
            // saveWorkspaceToolStripMenuItem
            // 
            this.saveWorkspaceToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(38)))));
            this.saveWorkspaceToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.saveWorkspaceToolStripMenuItem.Image = global::RacerData.rNascarApp.Properties.Resources.save;
            this.saveWorkspaceToolStripMenuItem.Name = "saveWorkspaceToolStripMenuItem";
            this.saveWorkspaceToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.saveWorkspaceToolStripMenuItem.Text = "&Save Workspace";
            this.saveWorkspaceToolStripMenuItem.Click += new System.EventHandler(this.saveWorkspaceToolStripMenuItem_Click);
            // 
            // copyWorkspaceToolStripMenuItem
            // 
            this.copyWorkspaceToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(38)))));
            this.copyWorkspaceToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.copyWorkspaceToolStripMenuItem.Image = global::RacerData.rNascarApp.Properties.Resources.copy;
            this.copyWorkspaceToolStripMenuItem.Name = "copyWorkspaceToolStripMenuItem";
            this.copyWorkspaceToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.copyWorkspaceToolStripMenuItem.Text = "&Copy Workspace";
            this.copyWorkspaceToolStripMenuItem.Click += new System.EventHandler(this.copyWorkspaceToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(166, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(38)))));
            this.exitToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.exitToolStripMenuItem.Image = global::RacerData.rNascarApp.Properties.Resources.exit1;
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
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
            this.viewToolStripMenuItem.ForeColor = System.Drawing.Color.DarkGray;
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(45, 20);
            this.viewToolStripMenuItem.Text = "&View";
            // 
            // statusBarToolStripMenuItem
            // 
            this.statusBarToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(38)))));
            this.statusBarToolStripMenuItem.Checked = true;
            this.statusBarToolStripMenuItem.CheckOnClick = true;
            this.statusBarToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.statusBarToolStripMenuItem.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.statusBarToolStripMenuItem.Image = global::RacerData.rNascarApp.Properties.Resources.status;
            this.statusBarToolStripMenuItem.Name = "statusBarToolStripMenuItem";
            this.statusBarToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.statusBarToolStripMenuItem.Text = "&Status Bar";
            this.statusBarToolStripMenuItem.CheckedChanged += new System.EventHandler(this.statusBarToolStripMenuItem_CheckedChanged);
            // 
            // toolBarToolStripMenuItem
            // 
            this.toolBarToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(38)))));
            this.toolBarToolStripMenuItem.Checked = true;
            this.toolBarToolStripMenuItem.CheckOnClick = true;
            this.toolBarToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolBarToolStripMenuItem.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.toolBarToolStripMenuItem.Image = global::RacerData.rNascarApp.Properties.Resources.tool;
            this.toolBarToolStripMenuItem.Name = "toolBarToolStripMenuItem";
            this.toolBarToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.toolBarToolStripMenuItem.Text = "&Tool Bar";
            this.toolBarToolStripMenuItem.CheckedChanged += new System.EventHandler(this.toolBarToolStripMenuItem_CheckedChanged);
            // 
            // logFileToolStripMenuItem
            // 
            this.logFileToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(38)))));
            this.logFileToolStripMenuItem.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.logFileToolStripMenuItem.Image = global::RacerData.rNascarApp.Properties.Resources.logFile;
            this.logFileToolStripMenuItem.Name = "logFileToolStripMenuItem";
            this.logFileToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.logFileToolStripMenuItem.Text = "&Log File";
            this.logFileToolStripMenuItem.Click += new System.EventHandler(this.logFileToolStripMenuItem_Click);
            // 
            // userSettingsFileToolStripMenuItem
            // 
            this.userSettingsFileToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(38)))));
            this.userSettingsFileToolStripMenuItem.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.userSettingsFileToolStripMenuItem.Image = global::RacerData.rNascarApp.Properties.Resources.settings;
            this.userSettingsFileToolStripMenuItem.Name = "userSettingsFileToolStripMenuItem";
            this.userSettingsFileToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.userSettingsFileToolStripMenuItem.Text = "&User Settings File";
            this.userSettingsFileToolStripMenuItem.Click += new System.EventHandler(this.userSettingsFileToolStripMenuItem_Click);
            // 
            // viewListToolStripMenuItem
            // 
            this.viewListToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(38)))));
            this.viewListToolStripMenuItem.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.viewListToolStripMenuItem.Image = global::RacerData.rNascarApp.Properties.Resources.views2;
            this.viewListToolStripMenuItem.Name = "viewListToolStripMenuItem";
            this.viewListToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.viewListToolStripMenuItem.Text = "View List";
            this.viewListToolStripMenuItem.DropDownOpening += new System.EventHandler(this.viewListToolStripMenuItem_DropDownOpening);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gridSizeToolStripMenuItem,
            this.themeToolStripMenuItem,
            this.displayFormatsToolStripMenuItem,
            this.workspaceManagementToolStripMenuItem,
            this.viewManagementToolStripMenuItem});
            this.toolsToolStripMenuItem.ForeColor = System.Drawing.Color.DarkGray;
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(49, 20);
            this.toolsToolStripMenuItem.Text = "&Tools";
            // 
            // gridSizeToolStripMenuItem
            // 
            this.gridSizeToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(38)))));
            this.gridSizeToolStripMenuItem.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.gridSizeToolStripMenuItem.Image = global::RacerData.rNascarApp.Properties.Resources.grid;
            this.gridSizeToolStripMenuItem.Name = "gridSizeToolStripMenuItem";
            this.gridSizeToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.gridSizeToolStripMenuItem.Text = "&Grid Size";
            this.gridSizeToolStripMenuItem.Click += new System.EventHandler(this.gridSizeToolStripMenuItem_Click);
            // 
            // themeToolStripMenuItem
            // 
            this.themeToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(38)))));
            this.themeToolStripMenuItem.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.themeToolStripMenuItem.Image = global::RacerData.rNascarApp.Properties.Resources.theme;
            this.themeToolStripMenuItem.Name = "themeToolStripMenuItem";
            this.themeToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.themeToolStripMenuItem.Text = "&Theme Designer";
            this.themeToolStripMenuItem.Click += new System.EventHandler(this.themeToolStripMenuItem_Click);
            // 
            // displayFormatsToolStripMenuItem
            // 
            this.displayFormatsToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(38)))));
            this.displayFormatsToolStripMenuItem.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.displayFormatsToolStripMenuItem.Image = global::RacerData.rNascarApp.Properties.Resources.format;
            this.displayFormatsToolStripMenuItem.Name = "displayFormatsToolStripMenuItem";
            this.displayFormatsToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.displayFormatsToolStripMenuItem.Text = "&Display Formats";
            this.displayFormatsToolStripMenuItem.Click += new System.EventHandler(this.displayFormatsToolStripMenuItem_Click);
            // 
            // workspaceManagementToolStripMenuItem
            // 
            this.workspaceManagementToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(38)))));
            this.workspaceManagementToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.workspaceManagementToolStripMenuItem.Image = global::RacerData.rNascarApp.Properties.Resources.workspace;
            this.workspaceManagementToolStripMenuItem.Name = "workspaceManagementToolStripMenuItem";
            this.workspaceManagementToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.workspaceManagementToolStripMenuItem.Text = "&Workspace Management";
            this.workspaceManagementToolStripMenuItem.Click += new System.EventHandler(this.workspaceManagementToolStripMenuItem_Click);
            // 
            // viewManagementToolStripMenuItem
            // 
            this.viewManagementToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(38)))));
            this.viewManagementToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.viewManagementToolStripMenuItem.Image = global::RacerData.rNascarApp.Properties.Resources.view;
            this.viewManagementToolStripMenuItem.Name = "viewManagementToolStripMenuItem";
            this.viewManagementToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.viewManagementToolStripMenuItem.Text = "&View Management";
            this.viewManagementToolStripMenuItem.Click += new System.EventHandler(this.viewManagementToolStripMenuItem_Click);
            // 
            // MainStatusStrip
            // 
            this.MainStatusStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(38)))));
            this.MainStatusStrip.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.MainStatusStrip.Location = new System.Drawing.Point(0, 381);
            this.MainStatusStrip.Name = "MainStatusStrip";
            this.MainStatusStrip.Padding = new System.Windows.Forms.Padding(1, 0, 16, 0);
            this.MainStatusStrip.Size = new System.Drawing.Size(1077, 28);
            this.MainStatusStrip.TabIndex = 1;
            this.MainStatusStrip.Text = "statusStrip1";
            this.MainStatusStrip.VisibleChanged += new System.EventHandler(this.MainStatusStrip_VisibleChanged);
            // 
            // toolStripStatusLabel0
            // 
            this.toolStripStatusLabel0.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.toolStripStatusLabel0.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.toolStripStatusLabel0.ForeColor = System.Drawing.Color.DarkGray;
            this.toolStripStatusLabel0.Image = global::RacerData.rNascarApp.Properties.Resources.track2;
            this.toolStripStatusLabel0.Name = "toolStripStatusLabel0";
            this.toolStripStatusLabel0.Size = new System.Drawing.Size(60, 23);
            this.toolStripStatusLabel0.Text = "Track:";
            // 
            // lblTrackName
            // 
            this.lblTrackName.AutoSize = false;
            this.lblTrackName.AutoToolTip = true;
            this.lblTrackName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.lblTrackName.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.lblTrackName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTrackName.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblTrackName.Name = "lblTrackName";
            this.lblTrackName.Size = new System.Drawing.Size(200, 23);
            this.lblTrackName.Text = "-none-";
            this.lblTrackName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.toolStripStatusLabel3.ForeColor = System.Drawing.Color.DarkGray;
            this.toolStripStatusLabel3.Image = global::RacerData.rNascarApp.Properties.Resources._event;
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(56, 23);
            this.toolStripStatusLabel3.Text = "Event:";
            // 
            // lblEvent
            // 
            this.lblEvent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.lblEvent.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.lblEvent.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblEvent.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblEvent.Name = "lblEvent";
            this.lblEvent.Size = new System.Drawing.Size(147, 23);
            this.lblEvent.Spring = true;
            this.lblEvent.Text = "-none-";
            this.lblEvent.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.toolStripStatusLabel1.ForeColor = System.Drawing.Color.DarkGray;
            this.toolStripStatusLabel1.Image = global::RacerData.rNascarApp.Properties.Resources.session;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(72, 23);
            this.toolStripStatusLabel1.Text = "Session:";
            // 
            // lblSession
            // 
            this.lblSession.AutoSize = false;
            this.lblSession.AutoToolTip = true;
            this.lblSession.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.lblSession.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.lblSession.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblSession.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblSession.Name = "lblSession";
            this.lblSession.Size = new System.Drawing.Size(100, 23);
            this.lblSession.Text = "-none-";
            this.lblSession.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.toolStripStatusLabel2.ForeColor = System.Drawing.Color.DarkGray;
            this.toolStripStatusLabel2.Image = global::RacerData.rNascarApp.Properties.Resources.flag;
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(87, 23);
            this.toolStripStatusLabel2.Text = "Track State:";
            // 
            // lblTrackState
            // 
            this.lblTrackState.AutoSize = false;
            this.lblTrackState.AutoToolTip = true;
            this.lblTrackState.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.lblTrackState.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.lblTrackState.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTrackState.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblTrackState.Name = "lblTrackState";
            this.lblTrackState.Size = new System.Drawing.Size(100, 23);
            this.lblTrackState.Text = "-none-";
            this.lblTrackState.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripStatusLabel4
            // 
            this.toolStripStatusLabel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.toolStripStatusLabel4.ForeColor = System.Drawing.Color.DarkGray;
            this.toolStripStatusLabel4.Image = global::RacerData.rNascarApp.Properties.Resources.workspace;
            this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            this.toolStripStatusLabel4.Size = new System.Drawing.Size(88, 23);
            this.toolStripStatusLabel4.Text = "Workspace:";
            // 
            // lblWorkspace
            // 
            this.lblWorkspace.AutoSize = false;
            this.lblWorkspace.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.lblWorkspace.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblWorkspace.ForeColor = System.Drawing.Color.LightGray;
            this.lblWorkspace.Name = "lblWorkspace";
            this.lblWorkspace.Size = new System.Drawing.Size(150, 23);
            this.lblWorkspace.Text = "-none-";
            this.lblWorkspace.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tlsMain
            // 
            this.tlsMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.tlsMain.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tlsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnMonitor,
            this.toolStripSeparator1,
            this.lblCurrentWorkspaceCaption,
            this.workspacesDropDownButton1,
            this.toolStripSeparator2});
            this.tlsMain.Location = new System.Drawing.Point(0, 24);
            this.tlsMain.Name = "tlsMain";
            this.tlsMain.Size = new System.Drawing.Size(1077, 25);
            this.tlsMain.TabIndex = 2;
            this.tlsMain.Text = "toolStrip1";
            this.tlsMain.VisibleChanged += new System.EventHandler(this.MainToolStrip_VisibleChanged);
            // 
            // btnMonitor
            // 
            this.btnMonitor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.btnMonitor.ForeColor = System.Drawing.Color.DarkGray;
            this.btnMonitor.Image = global::RacerData.rNascarApp.Properties.Resources.Running_16xLG;
            this.btnMonitor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnMonitor.Name = "btnMonitor";
            this.btnMonitor.Size = new System.Drawing.Size(95, 22);
            this.btnMonitor.Text = "Start Monitor";
            this.btnMonitor.ToolTipText = "Monitor On/Off";
            this.btnMonitor.Click += new System.EventHandler(this.btnMonitor_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // lblCurrentWorkspaceCaption
            // 
            this.lblCurrentWorkspaceCaption.ForeColor = System.Drawing.Color.DarkGray;
            this.lblCurrentWorkspaceCaption.Image = global::RacerData.rNascarApp.Properties.Resources.workspace;
            this.lblCurrentWorkspaceCaption.Margin = new System.Windows.Forms.Padding(4, 1, 0, 2);
            this.lblCurrentWorkspaceCaption.Name = "lblCurrentWorkspaceCaption";
            this.lblCurrentWorkspaceCaption.Size = new System.Drawing.Size(135, 22);
            this.lblCurrentWorkspaceCaption.Text = "Current Workspace: ";
            // 
            // workspacesDropDownButton1
            // 
            this.workspacesDropDownButton1.AutoSize = false;
            this.workspacesDropDownButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.workspacesDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.fffToolStripMenuItem});
            this.workspacesDropDownButton1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.workspacesDropDownButton1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.workspacesDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.workspacesDropDownButton1.Name = "workspacesDropDownButton1";
            this.workspacesDropDownButton1.Size = new System.Drawing.Size(250, 22);
            this.workspacesDropDownButton1.Text = "[workspace]";
            this.workspacesDropDownButton1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.workspacesDropDownButton1.DropDownOpening += new System.EventHandler(this.workspacesDropDownButton1_DropDownOpening);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(83, 6);
            // 
            // fffToolStripMenuItem
            // 
            this.fffToolStripMenuItem.Name = "fffToolStripMenuItem";
            this.fffToolStripMenuItem.Size = new System.Drawing.Size(86, 22);
            this.fffToolStripMenuItem.Text = "fff";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // GridTable
            // 
            this.GridTable.AllowDrop = true;
            this.GridTable.AutoSize = true;
            this.GridTable.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
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
            this.GridTable.Size = new System.Drawing.Size(1077, 332);
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
            this.pnlGrid.Size = new System.Drawing.Size(1077, 332);
            this.pnlGrid.TabIndex = 4;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1077, 409);
            this.Controls.Add(this.pnlGrid);
            this.Controls.Add(this.tlsMain);
            this.Controls.Add(this.MainStatusStrip);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
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
        private System.Windows.Forms.ToolStripButton btnMonitor;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem displayFormatsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem workspaceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveWorkspaceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyWorkspaceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openWorkspaceToolStripMenuItem1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
        private System.Windows.Forms.ToolStripStatusLabel lblWorkspace;
        private System.Windows.Forms.ToolStripMenuItem workspaceManagementToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewManagementToolStripMenuItem;
        private System.Windows.Forms.ToolStripDropDownButton workspacesDropDownButton1;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem fffToolStripMenuItem;
        private System.Windows.Forms.ToolStripLabel lblCurrentWorkspaceCaption;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
    }
}

