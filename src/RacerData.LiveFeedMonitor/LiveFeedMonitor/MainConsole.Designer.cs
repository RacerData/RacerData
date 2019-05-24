namespace RacerData.LiveFeedMonitor
{
    partial class MainConsole
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainConsole));
            this.pnlTop = new System.Windows.Forms.Panel();
            this.lblEventDetails = new System.Windows.Forms.Label();
            this.btnLog = new System.Windows.Forms.Button();
            this.btnSleep = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.pnlBody = new System.Windows.Forms.Panel();
            this.rtbOut = new System.Windows.Forms.RichTextBox();
            this.ctxOut = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.clearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.lblFeedInfo = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblActivity = new System.Windows.Forms.Label();
            this.ctxWakeTarget = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuSleep1Hour = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSleep1Day = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSleep3Days = new System.Windows.Forms.ToolStripMenuItem();
            this.btnIndicator = new System.Windows.Forms.Button();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.verboseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlTop.SuspendLayout();
            this.pnlBody.SuspendLayout();
            this.ctxOut.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.ctxWakeTarget.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.Black;
            this.pnlTop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTop.Controls.Add(this.btnIndicator);
            this.pnlTop.Controls.Add(this.lblEventDetails);
            this.pnlTop.Controls.Add(this.btnLog);
            this.pnlTop.Controls.Add(this.btnSleep);
            this.pnlTop.Controls.Add(this.btnStop);
            this.pnlTop.Controls.Add(this.btnStart);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Padding = new System.Windows.Forms.Padding(5);
            this.pnlTop.Size = new System.Drawing.Size(996, 47);
            this.pnlTop.TabIndex = 1;
            // 
            // lblEventDetails
            // 
            this.lblEventDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblEventDetails.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEventDetails.ForeColor = System.Drawing.Color.DarkGray;
            this.lblEventDetails.Location = new System.Drawing.Point(363, 5);
            this.lblEventDetails.Name = "lblEventDetails";
            this.lblEventDetails.Size = new System.Drawing.Size(586, 37);
            this.lblEventDetails.TabIndex = 5;
            this.lblEventDetails.Text = "No events";
            // 
            // btnLog
            // 
            this.btnLog.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btnLog.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkGray;
            this.btnLog.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.btnLog.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLog.ForeColor = System.Drawing.SystemColors.Info;
            this.btnLog.Location = new System.Drawing.Point(273, 8);
            this.btnLog.Name = "btnLog";
            this.btnLog.Size = new System.Drawing.Size(75, 29);
            this.btnLog.TabIndex = 4;
            this.btnLog.Text = "Log";
            this.btnLog.UseVisualStyleBackColor = true;
            this.btnLog.Click += new System.EventHandler(this.btnLog_Click);
            // 
            // btnSleep
            // 
            this.btnSleep.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btnSleep.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkGray;
            this.btnSleep.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.btnSleep.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSleep.ForeColor = System.Drawing.SystemColors.Info;
            this.btnSleep.Location = new System.Drawing.Point(166, 8);
            this.btnSleep.Name = "btnSleep";
            this.btnSleep.Size = new System.Drawing.Size(75, 29);
            this.btnSleep.TabIndex = 3;
            this.btnSleep.Text = "Sleep";
            this.btnSleep.UseVisualStyleBackColor = true;
            this.btnSleep.Click += new System.EventHandler(this.btnSleep_Click);
            // 
            // btnStop
            // 
            this.btnStop.Enabled = false;
            this.btnStop.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btnStop.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkGray;
            this.btnStop.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.btnStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStop.ForeColor = System.Drawing.SystemColors.Info;
            this.btnStop.Location = new System.Drawing.Point(85, 8);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 29);
            this.btnStop.TabIndex = 2;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnStart
            // 
            this.btnStart.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btnStart.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkGray;
            this.btnStart.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.btnStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStart.ForeColor = System.Drawing.SystemColors.Info;
            this.btnStart.Location = new System.Drawing.Point(4, 8);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 29);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // pnlBody
            // 
            this.pnlBody.BackColor = System.Drawing.Color.Black;
            this.pnlBody.Controls.Add(this.rtbOut);
            this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBody.Location = new System.Drawing.Point(0, 47);
            this.pnlBody.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Padding = new System.Windows.Forms.Padding(5);
            this.pnlBody.Size = new System.Drawing.Size(996, 336);
            this.pnlBody.TabIndex = 2;
            // 
            // rtbOut
            // 
            this.rtbOut.BackColor = System.Drawing.Color.Black;
            this.rtbOut.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbOut.ContextMenuStrip = this.ctxOut;
            this.rtbOut.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbOut.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbOut.ForeColor = System.Drawing.Color.Gainsboro;
            this.rtbOut.Location = new System.Drawing.Point(5, 5);
            this.rtbOut.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rtbOut.Name = "rtbOut";
            this.rtbOut.Size = new System.Drawing.Size(986, 326);
            this.rtbOut.TabIndex = 0;
            this.rtbOut.Text = "";
            // 
            // ctxOut
            // 
            this.ctxOut.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clearToolStripMenuItem,
            this.copyAllToolStripMenuItem,
            this.toolStripMenuItem1,
            this.verboseToolStripMenuItem});
            this.ctxOut.Name = "ctxOut";
            this.ctxOut.Size = new System.Drawing.Size(181, 98);
            // 
            // clearToolStripMenuItem
            // 
            this.clearToolStripMenuItem.Name = "clearToolStripMenuItem";
            this.clearToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.clearToolStripMenuItem.Text = "Clear";
            this.clearToolStripMenuItem.Click += new System.EventHandler(this.clearToolStripMenuItem_Click);
            // 
            // copyAllToolStripMenuItem
            // 
            this.copyAllToolStripMenuItem.Name = "copyAllToolStripMenuItem";
            this.copyAllToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.copyAllToolStripMenuItem.Text = "Copy All";
            this.copyAllToolStripMenuItem.Click += new System.EventHandler(this.copyAllToolStripMenuItem_Click);
            // 
            // pnlBottom
            // 
            this.pnlBottom.BackColor = System.Drawing.Color.Black;
            this.pnlBottom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlBottom.Controls.Add(this.lblFeedInfo);
            this.pnlBottom.Controls.Add(this.label2);
            this.pnlBottom.Controls.Add(this.lblStatus);
            this.pnlBottom.Controls.Add(this.label3);
            this.pnlBottom.Controls.Add(this.label1);
            this.pnlBottom.Controls.Add(this.lblActivity);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 383);
            this.pnlBottom.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Padding = new System.Windows.Forms.Padding(2);
            this.pnlBottom.Size = new System.Drawing.Size(996, 32);
            this.pnlBottom.TabIndex = 3;
            // 
            // lblFeedInfo
            // 
            this.lblFeedInfo.AutoEllipsis = true;
            this.lblFeedInfo.BackColor = System.Drawing.Color.Black;
            this.lblFeedInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFeedInfo.ForeColor = System.Drawing.Color.DarkGray;
            this.lblFeedInfo.Location = new System.Drawing.Point(290, 2);
            this.lblFeedInfo.Name = "lblFeedInfo";
            this.lblFeedInfo.Size = new System.Drawing.Size(450, 26);
            this.lblFeedInfo.TabIndex = 5;
            this.lblFeedInfo.Text = "No live event";
            this.lblFeedInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Black;
            this.label2.Dock = System.Windows.Forms.DockStyle.Left;
            this.label2.ForeColor = System.Drawing.Color.Gray;
            this.label2.Location = new System.Drawing.Point(238, 2);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 26);
            this.label2.TabIndex = 4;
            this.label2.Text = "Event:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblStatus
            // 
            this.lblStatus.BackColor = System.Drawing.Color.Black;
            this.lblStatus.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblStatus.ForeColor = System.Drawing.Color.DarkGray;
            this.lblStatus.Location = new System.Drawing.Point(48, 2);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(190, 26);
            this.lblStatus.TabIndex = 1;
            this.lblStatus.Text = "-";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Black;
            this.label3.Dock = System.Windows.Forms.DockStyle.Right;
            this.label3.ForeColor = System.Drawing.Color.Gray;
            this.label3.Location = new System.Drawing.Point(740, 2);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 26);
            this.label3.TabIndex = 2;
            this.label3.Text = "Activity:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Black;
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.ForeColor = System.Drawing.Color.Gray;
            this.label1.Location = new System.Drawing.Point(2, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "Status:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblActivity
            // 
            this.lblActivity.AutoEllipsis = true;
            this.lblActivity.BackColor = System.Drawing.Color.Black;
            this.lblActivity.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblActivity.ForeColor = System.Drawing.Color.DarkGray;
            this.lblActivity.Location = new System.Drawing.Point(792, 2);
            this.lblActivity.Name = "lblActivity";
            this.lblActivity.Size = new System.Drawing.Size(200, 26);
            this.lblActivity.TabIndex = 3;
            this.lblActivity.Text = "No live event";
            this.lblActivity.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ctxWakeTarget
            // 
            this.ctxWakeTarget.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuSleep1Hour,
            this.mnuSleep1Day,
            this.mnuSleep3Days});
            this.ctxWakeTarget.Name = "ctxWakeTarget";
            this.ctxWakeTarget.Size = new System.Drawing.Size(142, 70);
            // 
            // mnuSleep1Hour
            // 
            this.mnuSleep1Hour.AutoToolTip = true;
            this.mnuSleep1Hour.Name = "mnuSleep1Hour";
            this.mnuSleep1Hour.Size = new System.Drawing.Size(141, 22);
            this.mnuSleep1Hour.Text = "Sleep 1 Hour";
            this.mnuSleep1Hour.Click += new System.EventHandler(this.mnuSleep1Hour_Click);
            // 
            // mnuSleep1Day
            // 
            this.mnuSleep1Day.Name = "mnuSleep1Day";
            this.mnuSleep1Day.Size = new System.Drawing.Size(141, 22);
            this.mnuSleep1Day.Text = "Sleep 1 Day";
            this.mnuSleep1Day.Click += new System.EventHandler(this.mnuSleep1Day_Click);
            // 
            // mnuSleep3Days
            // 
            this.mnuSleep3Days.Name = "mnuSleep3Days";
            this.mnuSleep3Days.Size = new System.Drawing.Size(141, 22);
            this.mnuSleep3Days.Text = "Sleep 3 Days";
            this.mnuSleep3Days.Click += new System.EventHandler(this.mnuSleep3Days_Click);
            // 
            // btnIndicator
            // 
            this.btnIndicator.BackColor = System.Drawing.Color.Silver;
            this.btnIndicator.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnIndicator.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btnIndicator.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkGray;
            this.btnIndicator.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.btnIndicator.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIndicator.ForeColor = System.Drawing.SystemColors.Info;
            this.btnIndicator.Location = new System.Drawing.Point(954, 5);
            this.btnIndicator.Name = "btnIndicator";
            this.btnIndicator.Size = new System.Drawing.Size(35, 35);
            this.btnIndicator.TabIndex = 6;
            this.btnIndicator.UseVisualStyleBackColor = false;
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(177, 6);
            // 
            // verboseToolStripMenuItem
            // 
            this.verboseToolStripMenuItem.CheckOnClick = true;
            this.verboseToolStripMenuItem.Name = "verboseToolStripMenuItem";
            this.verboseToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.verboseToolStripMenuItem.Text = "Verbose";
            this.verboseToolStripMenuItem.CheckedChanged += new System.EventHandler(this.verboseToolStripMenuItem_CheckedChanged);
            // 
            // MainConsole
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(996, 415);
            this.Controls.Add(this.pnlBody);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.pnlTop);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MainConsole";
            this.Text = "Live Feed Monitor Console";
            this.Load += new System.EventHandler(this.MainConsole_Load);
            this.pnlTop.ResumeLayout(false);
            this.pnlBody.ResumeLayout(false);
            this.ctxOut.ResumeLayout(false);
            this.pnlBottom.ResumeLayout(false);
            this.ctxWakeTarget.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Panel pnlBody;
        private System.Windows.Forms.RichTextBox rtbOut;
        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblActivity;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.ContextMenuStrip ctxOut;
        private System.Windows.Forms.ToolStripMenuItem clearToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyAllToolStripMenuItem;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnSleep;
        private System.Windows.Forms.ContextMenuStrip ctxWakeTarget;
        private System.Windows.Forms.ToolStripMenuItem mnuSleep1Hour;
        private System.Windows.Forms.ToolStripMenuItem mnuSleep1Day;
        private System.Windows.Forms.ToolStripMenuItem mnuSleep3Days;
        private System.Windows.Forms.Button btnLog;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblFeedInfo;
        private System.Windows.Forms.Label lblEventDetails;
        private System.Windows.Forms.Button btnIndicator;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem verboseToolStripMenuItem;
    }
}

