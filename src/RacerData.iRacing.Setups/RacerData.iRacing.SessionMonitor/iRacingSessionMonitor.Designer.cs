namespace RacerData.iRacing.SessionMonitor
{
    partial class iRacingSessionMonitor
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblVehicle = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblTrack = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblEventType = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblSessionType = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel5 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblActivityStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel6 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblSetup = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel7 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblSdkStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reloadTelemetryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addRunToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeLastRUnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearRunsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addRunsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.telemetryDirectoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.dgvSessionRuns = new System.Windows.Forms.DataGridView();
            this.ctxSessionRuns = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.clearAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dgvLaps = new System.Windows.Forms.DataGridView();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lapTimeChartView1 = new RacerData.iRacing.Sessions.Ui.LapTimeChart.LapTimeChartView();
            this.tireSheetView1 = new RacerData.iRacing.Sessions.Ui.TireSheet.TireSheetView();
            this.tireSheetView2 = new RacerData.iRacing.Sessions.Ui.TireSheet.TireSheetView();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSessionRuns)).BeginInit();
            this.ctxSessionRuns.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLaps)).BeginInit();
            this.pnlTop.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.lblVehicle,
            this.toolStripStatusLabel2,
            this.lblTrack,
            this.toolStripStatusLabel3,
            this.lblEventType,
            this.toolStripStatusLabel4,
            this.lblSessionType,
            this.toolStripStatusLabel5,
            this.lblActivityStatus,
            this.toolStripStatusLabel6,
            this.lblSetup,
            this.toolStripStatusLabel7,
            this.lblSdkStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 551);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1357, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(47, 17);
            this.toolStripStatusLabel1.Text = "Vehicle:";
            // 
            // lblVehicle
            // 
            this.lblVehicle.Name = "lblVehicle";
            this.lblVehicle.Size = new System.Drawing.Size(12, 17);
            this.lblVehicle.Text = "-";
            this.lblVehicle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(38, 17);
            this.toolStripStatusLabel2.Text = "Track:";
            // 
            // lblTrack
            // 
            this.lblTrack.Name = "lblTrack";
            this.lblTrack.Size = new System.Drawing.Size(12, 17);
            this.lblTrack.Text = "-";
            this.lblTrack.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(67, 17);
            this.toolStripStatusLabel3.Text = "Event Type:";
            // 
            // lblEventType
            // 
            this.lblEventType.Name = "lblEventType";
            this.lblEventType.Size = new System.Drawing.Size(12, 17);
            this.lblEventType.Text = "-";
            this.lblEventType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripStatusLabel4
            // 
            this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            this.toolStripStatusLabel4.Size = new System.Drawing.Size(77, 17);
            this.toolStripStatusLabel4.Text = "Session Type:";
            // 
            // lblSessionType
            // 
            this.lblSessionType.Name = "lblSessionType";
            this.lblSessionType.Size = new System.Drawing.Size(12, 17);
            this.lblSessionType.Text = "-";
            this.lblSessionType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripStatusLabel5
            // 
            this.toolStripStatusLabel5.Name = "toolStripStatusLabel5";
            this.toolStripStatusLabel5.Size = new System.Drawing.Size(50, 17);
            this.toolStripStatusLabel5.Text = "Activity:";
            // 
            // lblActivityStatus
            // 
            this.lblActivityStatus.Name = "lblActivityStatus";
            this.lblActivityStatus.Size = new System.Drawing.Size(12, 17);
            this.lblActivityStatus.Text = "-";
            this.lblActivityStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripStatusLabel6
            // 
            this.toolStripStatusLabel6.Name = "toolStripStatusLabel6";
            this.toolStripStatusLabel6.Size = new System.Drawing.Size(40, 17);
            this.toolStripStatusLabel6.Text = "Setup:";
            this.toolStripStatusLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblSetup
            // 
            this.lblSetup.Name = "lblSetup";
            this.lblSetup.Size = new System.Drawing.Size(12, 17);
            this.lblSetup.Text = "-";
            this.lblSetup.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripStatusLabel7
            // 
            this.toolStripStatusLabel7.Name = "toolStripStatusLabel7";
            this.toolStripStatusLabel7.Size = new System.Drawing.Size(64, 17);
            this.toolStripStatusLabel7.Text = "Sdk Status:";
            // 
            // lblSdkStatus
            // 
            this.lblSdkStatus.Name = "lblSdkStatus";
            this.lblSdkStatus.Size = new System.Drawing.Size(57, 17);
            this.lblSdkStatus.Text = "Waiting...";
            this.lblSdkStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.testingToolStripMenuItem,
            this.startToolStripMenuItem,
            this.stopToolStripMenuItem,
            this.toolsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1357, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.reloadTelemetryToolStripMenuItem,
            this.toolStripMenuItem2,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // reloadTelemetryToolStripMenuItem
            // 
            this.reloadTelemetryToolStripMenuItem.Name = "reloadTelemetryToolStripMenuItem";
            this.reloadTelemetryToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.reloadTelemetryToolStripMenuItem.Text = "Reload Telemetry";
            this.reloadTelemetryToolStripMenuItem.Click += new System.EventHandler(this.reloadTelemetryToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(162, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // testingToolStripMenuItem
            // 
            this.testingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addRunToolStripMenuItem,
            this.removeLastRUnToolStripMenuItem,
            this.clearRunsToolStripMenuItem,
            this.addRunsToolStripMenuItem});
            this.testingToolStripMenuItem.Name = "testingToolStripMenuItem";
            this.testingToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.testingToolStripMenuItem.Text = "Testing";
            // 
            // addRunToolStripMenuItem
            // 
            this.addRunToolStripMenuItem.Name = "addRunToolStripMenuItem";
            this.addRunToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.addRunToolStripMenuItem.Text = "Add Run";
            this.addRunToolStripMenuItem.Click += new System.EventHandler(this.addRunToolStripMenuItem_Click);
            // 
            // removeLastRUnToolStripMenuItem
            // 
            this.removeLastRUnToolStripMenuItem.Name = "removeLastRUnToolStripMenuItem";
            this.removeLastRUnToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.removeLastRUnToolStripMenuItem.Text = "Remove Last Run";
            this.removeLastRUnToolStripMenuItem.Click += new System.EventHandler(this.removeLastRunToolStripMenuItem_Click);
            // 
            // clearRunsToolStripMenuItem
            // 
            this.clearRunsToolStripMenuItem.Name = "clearRunsToolStripMenuItem";
            this.clearRunsToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.clearRunsToolStripMenuItem.Text = "Clear Runs";
            this.clearRunsToolStripMenuItem.Click += new System.EventHandler(this.clearRunsToolStripMenuItem_Click);
            // 
            // addRunsToolStripMenuItem
            // 
            this.addRunsToolStripMenuItem.Name = "addRunsToolStripMenuItem";
            this.addRunsToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.addRunsToolStripMenuItem.Text = "Add Runs";
            this.addRunsToolStripMenuItem.Click += new System.EventHandler(this.addRunsToolStripMenuItem_Click);
            // 
            // startToolStripMenuItem
            // 
            this.startToolStripMenuItem.Name = "startToolStripMenuItem";
            this.startToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.startToolStripMenuItem.Text = "Start";
            this.startToolStripMenuItem.Click += new System.EventHandler(this.startToolStripMenuItem_Click);
            // 
            // stopToolStripMenuItem
            // 
            this.stopToolStripMenuItem.Name = "stopToolStripMenuItem";
            this.stopToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.stopToolStripMenuItem.Text = "Stop";
            this.stopToolStripMenuItem.Click += new System.EventHandler(this.stopToolStripMenuItem_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.telemetryDirectoryToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // telemetryDirectoryToolStripMenuItem
            // 
            this.telemetryDirectoryToolStripMenuItem.Name = "telemetryDirectoryToolStripMenuItem";
            this.telemetryDirectoryToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.telemetryDirectoryToolStripMenuItem.Text = "Telemetry Directory";
            this.telemetryDirectoryToolStripMenuItem.Click += new System.EventHandler(this.telemetryDirectoryToolStripMenuItem_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1357, 25);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // dgvSessionRuns
            // 
            this.dgvSessionRuns.AllowUserToAddRows = false;
            this.dgvSessionRuns.AllowUserToOrderColumns = true;
            this.dgvSessionRuns.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvSessionRuns.BackgroundColor = System.Drawing.Color.Black;
            this.dgvSessionRuns.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSessionRuns.ContextMenuStrip = this.ctxSessionRuns;
            this.dgvSessionRuns.Dock = System.Windows.Forms.DockStyle.Left;
            this.dgvSessionRuns.Location = new System.Drawing.Point(0, 0);
            this.dgvSessionRuns.Margin = new System.Windows.Forms.Padding(4);
            this.dgvSessionRuns.MinimumSize = new System.Drawing.Size(480, 100);
            this.dgvSessionRuns.Name = "dgvSessionRuns";
            this.dgvSessionRuns.ReadOnly = true;
            this.dgvSessionRuns.RowHeadersWidth = 25;
            this.dgvSessionRuns.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSessionRuns.Size = new System.Drawing.Size(480, 347);
            this.dgvSessionRuns.TabIndex = 3;
            // 
            // ctxSessionRuns
            // 
            this.ctxSessionRuns.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteToolStripMenuItem,
            this.toolStripMenuItem1,
            this.clearAllToolStripMenuItem});
            this.ctxSessionRuns.Name = "ctxSessionRuns";
            this.ctxSessionRuns.Size = new System.Drawing.Size(119, 54);
            this.ctxSessionRuns.Opening += new System.ComponentModel.CancelEventHandler(this.ctxSessionRuns_Opening);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(115, 6);
            // 
            // clearAllToolStripMenuItem
            // 
            this.clearAllToolStripMenuItem.Name = "clearAllToolStripMenuItem";
            this.clearAllToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.clearAllToolStripMenuItem.Text = "Clear All";
            this.clearAllToolStripMenuItem.Click += new System.EventHandler(this.clearAllToolStripMenuItem_Click);
            // 
            // dgvLaps
            // 
            this.dgvLaps.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvLaps.BackgroundColor = System.Drawing.Color.Black;
            this.dgvLaps.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvLaps.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvLaps.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLaps.Dock = System.Windows.Forms.DockStyle.Left;
            this.dgvLaps.Location = new System.Drawing.Point(480, 0);
            this.dgvLaps.Name = "dgvLaps";
            this.dgvLaps.RowHeadersWidth = 25;
            this.dgvLaps.Size = new System.Drawing.Size(396, 347);
            this.dgvLaps.TabIndex = 7;
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter1.Location = new System.Drawing.Point(0, 396);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(1357, 3);
            this.splitter1.TabIndex = 10;
            this.splitter1.TabStop = false;
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.Black;
            this.pnlTop.Controls.Add(this.panel1);
            this.pnlTop.Controls.Add(this.dgvLaps);
            this.pnlTop.Controls.Add(this.dgvSessionRuns);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 49);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(1357, 347);
            this.pnlTop.TabIndex = 11;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Controls.Add(this.tireSheetView2);
            this.panel1.Controls.Add(this.tireSheetView1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(876, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(481, 347);
            this.panel1.TabIndex = 8;
            // 
            // lapTimeChartView1
            // 
            this.lapTimeChartView1.AutoScale = true;
            this.lapTimeChartView1.AxisLabelColor = System.Drawing.Color.WhiteSmoke;
            this.lapTimeChartView1.AxisLineColor = System.Drawing.Color.Gray;
            this.lapTimeChartView1.AxisWidth = 1.5F;
            this.lapTimeChartView1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lapTimeChartView1.BorderColor = System.Drawing.Color.DimGray;
            this.lapTimeChartView1.BorderOffset = 4;
            this.lapTimeChartView1.BorderWidth = 2F;
            this.lapTimeChartView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lapTimeChartView1.GridLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lapTimeChartView1.GridLineWidth = 0.5F;
            this.lapTimeChartView1.GridRightOffset = 6F;
            this.lapTimeChartView1.GridTopOffset = 6F;
            this.lapTimeChartView1.LapTimes = null;
            this.lapTimeChartView1.Location = new System.Drawing.Point(0, 399);
            this.lapTimeChartView1.Margin = new System.Windows.Forms.Padding(4);
            this.lapTimeChartView1.Name = "lapTimeChartView1";
            this.lapTimeChartView1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lapTimeChartView1.SeriesLineColor = System.Drawing.Color.Red;
            this.lapTimeChartView1.SeriesLineWidth = 0.5F;
            this.lapTimeChartView1.SeriesMax = 22F;
            this.lapTimeChartView1.SeriesMin = 12F;
            this.lapTimeChartView1.ShowGrid = true;
            this.lapTimeChartView1.ShowLapTimePointLabels = false;
            this.lapTimeChartView1.ShowXAxisLabels = true;
            this.lapTimeChartView1.ShowYAxisLabels = true;
            this.lapTimeChartView1.Size = new System.Drawing.Size(1357, 152);
            this.lapTimeChartView1.TabIndex = 9;
            this.lapTimeChartView1.XAxisFont = new System.Drawing.Font("Segoe UI", 8F);
            this.lapTimeChartView1.XAxisOffset = 20F;
            this.lapTimeChartView1.YAxisFont = new System.Drawing.Font("Segoe UI", 8F);
            this.lapTimeChartView1.YAxisOffset = 30F;
            // 
            // tireSheetView1
            // 
            this.tireSheetView1.BackColor = System.Drawing.Color.Black;
            this.tireSheetView1.Dock = System.Windows.Forms.DockStyle.Left;
            this.tireSheetView1.EnableWarnings = false;
            this.tireSheetView1.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tireSheetView1.HeaderBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.tireSheetView1.HeaderForeColor = System.Drawing.Color.Black;
            this.tireSheetView1.InfoBackColor = System.Drawing.Color.Blue;
            this.tireSheetView1.InfoForeColor = System.Drawing.Color.White;
            this.tireSheetView1.Location = new System.Drawing.Point(0, 0);
            this.tireSheetView1.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.tireSheetView1.Model = null;
            this.tireSheetView1.Name = "tireSheetView1";
            this.tireSheetView1.Size = new System.Drawing.Size(367, 330);
            this.tireSheetView1.TabIndex = 0;
            this.tireSheetView1.TempWarning = 2D;
            this.tireSheetView1.WearWarning = 1D;
            // 
            // tireSheetView2
            // 
            this.tireSheetView2.BackColor = System.Drawing.Color.Black;
            this.tireSheetView2.Dock = System.Windows.Forms.DockStyle.Left;
            this.tireSheetView2.EnableWarnings = false;
            this.tireSheetView2.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tireSheetView2.HeaderBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.tireSheetView2.HeaderForeColor = System.Drawing.Color.Black;
            this.tireSheetView2.InfoBackColor = System.Drawing.Color.Blue;
            this.tireSheetView2.InfoForeColor = System.Drawing.Color.White;
            this.tireSheetView2.Location = new System.Drawing.Point(367, 0);
            this.tireSheetView2.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.tireSheetView2.Model = null;
            this.tireSheetView2.Name = "tireSheetView2";
            this.tireSheetView2.Size = new System.Drawing.Size(367, 330);
            this.tireSheetView2.TabIndex = 1;
            this.tireSheetView2.TempWarning = 2D;
            this.tireSheetView2.WearWarning = 1D;
            // 
            // iRacingSessionMonitor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1357, 573);
            this.Controls.Add(this.lapTimeChartView1);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.pnlTop);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "iRacingSessionMonitor";
            this.Text = "iRacing Session Monitor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.iRacingSessionMonitor_FormClosing);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSessionRuns)).EndInit();
            this.ctxSessionRuns.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLaps)).EndInit();
            this.pnlTop.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel lblVehicle;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel lblTrack;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel lblEventType;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
        private System.Windows.Forms.ToolStripStatusLabel lblSessionType;
        private System.Windows.Forms.DataGridView dgvSessionRuns;
        private System.Windows.Forms.ToolStripMenuItem testingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addRunToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeLastRUnToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearRunsToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel lblActivityStatus;
        private System.Windows.Forms.ContextMenuStrip ctxSessionRuns;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem clearAllToolStripMenuItem;
        private System.Windows.Forms.DataGridView dgvLaps;
        private Sessions.Ui.LapTimeChart.LapTimeChartView lapTimeChartView1;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.ToolStripMenuItem startToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stopToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addRunsToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel5;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel6;
        private System.Windows.Forms.ToolStripStatusLabel lblSetup;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel7;
        private System.Windows.Forms.ToolStripStatusLabel lblSdkStatus;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripMenuItem reloadTelemetryToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem telemetryDirectoryToolStripMenuItem;
        private Sessions.Ui.TireSheet.TireSheetView tireSheetView2;
        private Sessions.Ui.TireSheet.TireSheetView tireSheetView1;
    }
}

