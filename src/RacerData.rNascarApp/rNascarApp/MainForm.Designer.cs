﻿namespace RacerData.rNascarApp
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
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusBarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolBarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.logFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.userSettingsFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.resetViewsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gridSizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.themeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewDesignerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MainStatusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel0 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblTrackName = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblEvent = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblSession = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblTrackState = new System.Windows.Forms.ToolStripStatusLabel();
            this.MainToolStrip = new System.Windows.Forms.ToolStrip();
            this.btnMonitor = new System.Windows.Forms.ToolStripButton();
            this.txtMonitorState = new System.Windows.Forms.ToolStripTextBox();
            this.GridTable = new System.Windows.Forms.TableLayoutPanel();
            this.ctxGridTable = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.gridSizeToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.dragTimer = new System.Windows.Forms.Timer(this.components);
            this.pnlGrid = new System.Windows.Forms.Panel();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnThemeDesigner = new System.Windows.Forms.ToolStripButton();
            this.btnViewDesigner = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnGridSize = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.menuStrip1.SuspendLayout();
            this.MainStatusStrip.SuspendLayout();
            this.MainToolStrip.SuspendLayout();
            this.ctxGridTable.SuspendLayout();
            this.pnlGrid.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.toolsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1038, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "&Edit";
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Enabled = false;
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.copyToolStripMenuItem.Text = "&Copy";
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusBarToolStripMenuItem,
            this.toolBarToolStripMenuItem,
            this.toolStripMenuItem2,
            this.logFileToolStripMenuItem,
            this.userSettingsFileToolStripMenuItem,
            this.toolStripMenuItem1,
            this.resetViewsToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "&View";
            // 
            // statusBarToolStripMenuItem
            // 
            this.statusBarToolStripMenuItem.Checked = true;
            this.statusBarToolStripMenuItem.CheckOnClick = true;
            this.statusBarToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.statusBarToolStripMenuItem.Name = "statusBarToolStripMenuItem";
            this.statusBarToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.statusBarToolStripMenuItem.Text = "&Status Bar";
            this.statusBarToolStripMenuItem.CheckedChanged += new System.EventHandler(this.statusBarToolStripMenuItem_CheckedChanged);
            // 
            // toolBarToolStripMenuItem
            // 
            this.toolBarToolStripMenuItem.Checked = true;
            this.toolBarToolStripMenuItem.CheckOnClick = true;
            this.toolBarToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolBarToolStripMenuItem.Name = "toolBarToolStripMenuItem";
            this.toolBarToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.toolBarToolStripMenuItem.Text = "&Tool Bar";
            this.toolBarToolStripMenuItem.CheckedChanged += new System.EventHandler(this.toolBarToolStripMenuItem_CheckedChanged);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(177, 6);
            // 
            // logFileToolStripMenuItem
            // 
            this.logFileToolStripMenuItem.Name = "logFileToolStripMenuItem";
            this.logFileToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.logFileToolStripMenuItem.Text = "&Log File";
            this.logFileToolStripMenuItem.Click += new System.EventHandler(this.logFileToolStripMenuItem_Click);
            // 
            // userSettingsFileToolStripMenuItem
            // 
            this.userSettingsFileToolStripMenuItem.Name = "userSettingsFileToolStripMenuItem";
            this.userSettingsFileToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.userSettingsFileToolStripMenuItem.Text = "&User Settings File";
            this.userSettingsFileToolStripMenuItem.Click += new System.EventHandler(this.userSettingsFileToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(177, 6);
            // 
            // resetViewsToolStripMenuItem
            // 
            this.resetViewsToolStripMenuItem.Name = "resetViewsToolStripMenuItem";
            this.resetViewsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.resetViewsToolStripMenuItem.Text = "&Reset Views";
            this.resetViewsToolStripMenuItem.Click += new System.EventHandler(this.resetViewsToolStripMenuItem_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gridSizeToolStripMenuItem,
            this.toolStripMenuItem4,
            this.themeToolStripMenuItem,
            this.viewDesignerToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.toolsToolStripMenuItem.Text = "&Tools";
            // 
            // gridSizeToolStripMenuItem
            // 
            this.gridSizeToolStripMenuItem.Name = "gridSizeToolStripMenuItem";
            this.gridSizeToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.gridSizeToolStripMenuItem.Text = "&Grid Size";
            this.gridSizeToolStripMenuItem.Click += new System.EventHandler(this.gridSizeToolStripMenuItem_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(177, 6);
            // 
            // themeToolStripMenuItem
            // 
            this.themeToolStripMenuItem.Name = "themeToolStripMenuItem";
            this.themeToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.themeToolStripMenuItem.Text = "&Theme Designer";
            this.themeToolStripMenuItem.Click += new System.EventHandler(this.themeToolStripMenuItem_Click);
            // 
            // viewDesignerToolStripMenuItem
            // 
            this.viewDesignerToolStripMenuItem.Name = "viewDesignerToolStripMenuItem";
            this.viewDesignerToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.viewDesignerToolStripMenuItem.Text = "&View Designer";
            this.viewDesignerToolStripMenuItem.Click += new System.EventHandler(this.viewDesignerToolStripMenuItem_Click);
            // 
            // MainStatusStrip
            // 
            this.MainStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel0,
            this.lblTrackName,
            this.toolStripStatusLabel3,
            this.lblEvent,
            this.toolStripStatusLabel1,
            this.lblSession,
            this.toolStripStatusLabel2,
            this.lblTrackState});
            this.MainStatusStrip.Location = new System.Drawing.Point(0, 522);
            this.MainStatusStrip.Name = "MainStatusStrip";
            this.MainStatusStrip.Size = new System.Drawing.Size(1038, 24);
            this.MainStatusStrip.TabIndex = 1;
            this.MainStatusStrip.Text = "statusStrip1";
            this.MainStatusStrip.VisibleChanged += new System.EventHandler(this.MainStatusStrip_VisibleChanged);
            // 
            // toolStripStatusLabel0
            // 
            this.toolStripStatusLabel0.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.toolStripStatusLabel0.Name = "toolStripStatusLabel0";
            this.toolStripStatusLabel0.Size = new System.Drawing.Size(42, 19);
            this.toolStripStatusLabel0.Text = "Track:";
            // 
            // lblTrackName
            // 
            this.lblTrackName.AutoSize = false;
            this.lblTrackName.AutoToolTip = true;
            this.lblTrackName.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.lblTrackName.Name = "lblTrackName";
            this.lblTrackName.Size = new System.Drawing.Size(200, 19);
            this.lblTrackName.Text = "-none-";
            this.lblTrackName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(39, 19);
            this.toolStripStatusLabel3.Text = "Event:";
            // 
            // lblEvent
            // 
            this.lblEvent.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.lblEvent.Name = "lblEvent";
            this.lblEvent.Size = new System.Drawing.Size(426, 19);
            this.lblEvent.Spring = true;
            this.lblEvent.Text = "-none-";
            this.lblEvent.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(49, 19);
            this.toolStripStatusLabel1.Text = "Session:";
            // 
            // lblSession
            // 
            this.lblSession.AutoSize = false;
            this.lblSession.AutoToolTip = true;
            this.lblSession.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.lblSession.Name = "lblSession";
            this.lblSession.Size = new System.Drawing.Size(100, 19);
            this.lblSession.Text = "-none-";
            this.lblSession.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(67, 19);
            this.toolStripStatusLabel2.Text = "Track State:";
            // 
            // lblTrackState
            // 
            this.lblTrackState.AutoSize = false;
            this.lblTrackState.AutoToolTip = true;
            this.lblTrackState.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.lblTrackState.Name = "lblTrackState";
            this.lblTrackState.Size = new System.Drawing.Size(100, 19);
            this.lblTrackState.Text = "-none-";
            this.lblTrackState.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // MainToolStrip
            // 
            this.MainToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnMonitor,
            this.txtMonitorState,
            this.toolStripSeparator1,
            this.btnThemeDesigner,
            this.btnViewDesigner,
            this.toolStripSeparator2,
            this.btnGridSize,
            this.toolStripSeparator3});
            this.MainToolStrip.Location = new System.Drawing.Point(0, 24);
            this.MainToolStrip.Name = "MainToolStrip";
            this.MainToolStrip.Size = new System.Drawing.Size(1038, 25);
            this.MainToolStrip.TabIndex = 2;
            this.MainToolStrip.Text = "toolStrip1";
            this.MainToolStrip.VisibleChanged += new System.EventHandler(this.MainToolStrip_VisibleChanged);
            // 
            // btnMonitor
            // 
            this.btnMonitor.BackColor = System.Drawing.SystemColors.Control;
            this.btnMonitor.Image = ((System.Drawing.Image)(resources.GetObject("btnMonitor.Image")));
            this.btnMonitor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnMonitor.Name = "btnMonitor";
            this.btnMonitor.Size = new System.Drawing.Size(97, 22);
            this.btnMonitor.Text = "Start Monitor";
            this.btnMonitor.ToolTipText = "Monitor On/Off";
            this.btnMonitor.Click += new System.EventHandler(this.btnMonitor_Click);
            // 
            // txtMonitorState
            // 
            this.txtMonitorState.AutoSize = false;
            this.txtMonitorState.BackColor = System.Drawing.Color.DarkOliveGreen;
            this.txtMonitorState.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMonitorState.Name = "txtMonitorState";
            this.txtMonitorState.Size = new System.Drawing.Size(25, 23);
            // 
            // GridTable
            // 
            this.GridTable.AllowDrop = true;
            this.GridTable.AutoSize = true;
            this.GridTable.BackColor = System.Drawing.SystemColors.AppWorkspace;
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
            this.GridTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.GridTable.Size = new System.Drawing.Size(1038, 473);
            this.GridTable.TabIndex = 3;
            this.GridTable.DragDrop += new System.Windows.Forms.DragEventHandler(this.GridTable_DragDrop);
            this.GridTable.DragOver += new System.Windows.Forms.DragEventHandler(this.GridTable_DragOver);
            this.GridTable.Resize += new System.EventHandler(this.GridTable_Resize);
            // 
            // ctxGridTable
            // 
            this.ctxGridTable.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gridSizeToolStripMenuItem1});
            this.ctxGridTable.Name = "ctxGridTable";
            this.ctxGridTable.Size = new System.Drawing.Size(120, 26);
            // 
            // gridSizeToolStripMenuItem1
            // 
            this.gridSizeToolStripMenuItem1.Name = "gridSizeToolStripMenuItem1";
            this.gridSizeToolStripMenuItem1.Size = new System.Drawing.Size(119, 22);
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
            this.pnlGrid.Size = new System.Drawing.Size(1038, 473);
            this.pnlGrid.TabIndex = 4;
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // btnThemeDesigner
            // 
            this.btnThemeDesigner.Image = ((System.Drawing.Image)(resources.GetObject("btnThemeDesigner.Image")));
            this.btnThemeDesigner.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnThemeDesigner.Name = "btnThemeDesigner";
            this.btnThemeDesigner.Size = new System.Drawing.Size(113, 22);
            this.btnThemeDesigner.Text = "Theme Designer";
            this.btnThemeDesigner.ToolTipText = "Theme Designer";
            this.btnThemeDesigner.Click += new System.EventHandler(this.btnThemeDesigner_Click);
            // 
            // btnViewDesigner
            // 
            this.btnViewDesigner.Image = ((System.Drawing.Image)(resources.GetObject("btnViewDesigner.Image")));
            this.btnViewDesigner.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnViewDesigner.Name = "btnViewDesigner";
            this.btnViewDesigner.Size = new System.Drawing.Size(101, 22);
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
            this.btnGridSize.Image = ((System.Drawing.Image)(resources.GetObject("btnGridSize.Image")));
            this.btnGridSize.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnGridSize.Name = "btnGridSize";
            this.btnGridSize.Size = new System.Drawing.Size(72, 22);
            this.btnGridSize.Text = "Grid Size";
            this.btnGridSize.Click += new System.EventHandler(this.btnGridSize_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1038, 546);
            this.Controls.Add(this.pnlGrid);
            this.Controls.Add(this.MainToolStrip);
            this.Controls.Add(this.MainStatusStrip);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "r/Nascar Timing & Scoring";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.MainStatusStrip.ResumeLayout(false);
            this.MainStatusStrip.PerformLayout();
            this.MainToolStrip.ResumeLayout(false);
            this.MainToolStrip.PerformLayout();
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
        private System.Windows.Forms.ToolStrip MainToolStrip;
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
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolBarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem logFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem userSettingsFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem themeToolStripMenuItem;
        private System.Windows.Forms.Timer dragTimer;
        private System.Windows.Forms.Panel pnlGrid;
        private System.Windows.Forms.ToolStripMenuItem gridSizeToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip ctxGridTable;
        private System.Windows.Forms.ToolStripMenuItem gridSizeToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem viewDesignerToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem resetViewsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
        private System.Windows.Forms.ToolStripButton btnMonitor;
        private System.Windows.Forms.ToolStripTextBox txtMonitorState;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnThemeDesigner;
        private System.Windows.Forms.ToolStripButton btnViewDesigner;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnGridSize;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
    }
}

