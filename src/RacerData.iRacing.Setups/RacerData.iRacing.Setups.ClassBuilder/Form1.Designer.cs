namespace RacerData.iRacing.Setups.ClassBuilder
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnOpenFile = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnOpenDirectory = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblTelemetryFileName = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblUpdateCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.lstSetups = new System.Windows.Forms.ListBox();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnSessionInfo = new System.Windows.Forms.ToolStripButton();
            this.txtSessionData = new System.Windows.Forms.TextBox();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnTireSheet = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnOpenFile,
            this.toolStripSeparator1,
            this.btnOpenDirectory,
            this.toolStripSeparator2,
            this.btnSessionInfo,
            this.toolStripSeparator3,
            this.btnTireSheet});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(800, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnOpenFile
            // 
            this.btnOpenFile.Image = ((System.Drawing.Image)(resources.GetObject("btnOpenFile.Image")));
            this.btnOpenFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnOpenFile.Name = "btnOpenFile";
            this.btnOpenFile.Size = new System.Drawing.Size(77, 22);
            this.btnOpenFile.Text = "Open File";
            this.btnOpenFile.Click += new System.EventHandler(this.btnOpenFile_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // btnOpenDirectory
            // 
            this.btnOpenDirectory.Image = ((System.Drawing.Image)(resources.GetObject("btnOpenDirectory.Image")));
            this.btnOpenDirectory.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnOpenDirectory.Name = "btnOpenDirectory";
            this.btnOpenDirectory.Size = new System.Drawing.Size(107, 22);
            this.btnOpenDirectory.Text = "Open Directory";
            this.btnOpenDirectory.Click += new System.EventHandler(this.btnOpenDirectory_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.lblTelemetryFileName,
            this.toolStripStatusLabel2,
            this.lblUpdateCount});
            this.statusStrip1.Location = new System.Drawing.Point(0, 502);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(800, 24);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(83, 19);
            this.toolStripStatusLabel1.Text = "Telemetry File:";
            // 
            // lblTelemetryFileName
            // 
            this.lblTelemetryFileName.AutoSize = false;
            this.lblTelemetryFileName.BackColor = System.Drawing.Color.White;
            this.lblTelemetryFileName.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.lblTelemetryFileName.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenInner;
            this.lblTelemetryFileName.Name = "lblTelemetryFileName";
            this.lblTelemetryFileName.Size = new System.Drawing.Size(250, 19);
            this.lblTelemetryFileName.Text = "-";
            this.lblTelemetryFileName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(53, 19);
            this.toolStripStatusLabel2.Text = "Updates:";
            // 
            // lblUpdateCount
            // 
            this.lblUpdateCount.AutoSize = false;
            this.lblUpdateCount.BackColor = System.Drawing.Color.White;
            this.lblUpdateCount.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.lblUpdateCount.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenInner;
            this.lblUpdateCount.Name = "lblUpdateCount";
            this.lblUpdateCount.Size = new System.Drawing.Size(40, 19);
            this.lblUpdateCount.Text = "-";
            this.lblUpdateCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lstSetups
            // 
            this.lstSetups.Dock = System.Windows.Forms.DockStyle.Left;
            this.lstSetups.FormattingEnabled = true;
            this.lstSetups.Location = new System.Drawing.Point(0, 25);
            this.lstSetups.Name = "lstSetups";
            this.lstSetups.Size = new System.Drawing.Size(340, 477);
            this.lstSetups.TabIndex = 2;
            this.lstSetups.SelectedIndexChanged += new System.EventHandler(this.lstSetups_SelectedIndexChanged);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // btnSessionInfo
            // 
            this.btnSessionInfo.Image = ((System.Drawing.Image)(resources.GetObject("btnSessionInfo.Image")));
            this.btnSessionInfo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSessionInfo.Name = "btnSessionInfo";
            this.btnSessionInfo.Size = new System.Drawing.Size(90, 22);
            this.btnSessionInfo.Text = "Session Info";
            this.btnSessionInfo.Click += new System.EventHandler(this.btnSessionInfo_Click);
            // 
            // txtSessionData
            // 
            this.txtSessionData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSessionData.Location = new System.Drawing.Point(340, 25);
            this.txtSessionData.Multiline = true;
            this.txtSessionData.Name = "txtSessionData";
            this.txtSessionData.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtSessionData.Size = new System.Drawing.Size(460, 477);
            this.txtSessionData.TabIndex = 3;
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // btnTireSheet
            // 
            this.btnTireSheet.Image = ((System.Drawing.Image)(resources.GetObject("btnTireSheet.Image")));
            this.btnTireSheet.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnTireSheet.Name = "btnTireSheet";
            this.btnTireSheet.Size = new System.Drawing.Size(79, 22);
            this.btnTireSheet.Text = "Tire Sheet";
            this.btnTireSheet.Click += new System.EventHandler(this.btnTireSheet_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 526);
            this.Controls.Add(this.txtSessionData);
            this.Controls.Add(this.lstSetups);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Form1";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblTelemetryFileName;
        private System.Windows.Forms.ToolStripButton btnOpenFile;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripStatusLabel lblUpdateCount;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripButton btnOpenDirectory;
        private System.Windows.Forms.ListBox lstSetups;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnSessionInfo;
        private System.Windows.Forms.TextBox txtSessionData;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton btnTireSheet;
    }
}

