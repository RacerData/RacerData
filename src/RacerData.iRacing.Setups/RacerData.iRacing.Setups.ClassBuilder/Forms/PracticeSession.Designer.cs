namespace RacerData.iRacing.Setups.ClassBuilder.Forms
{
    partial class PracticeSession
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PracticeSession));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tirePressureGraphSet1 = new RacerData.iRacing.Setups.ClassBuilder.Controls.TirePressureGraphSet();
            this.tireTempGraphSet1 = new RacerData.iRacing.Setups.ClassBuilder.Controls.TireTempGraphSet();
            this.tireWearGraphSet1 = new RacerData.iRacing.Setups.ClassBuilder.Controls.TireWearGraphSet();
            this.lapTimeChart1 = new RacerData.iRacing.Setups.ClassBuilder.Controls.LapTimeChart();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnAutoScaleLapTImes = new System.Windows.Forms.ToolStripButton();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Black;
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 293F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 21F));
            this.tableLayoutPanel1.Controls.Add(this.tirePressureGraphSet1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.tireTempGraphSet1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tireWearGraphSet1, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.lapTimeChart1, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(8, 8);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(832, 480);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tirePressureGraphSet1
            // 
            this.tirePressureGraphSet1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tirePressureGraphSet1.BackColor = System.Drawing.Color.Black;
            this.tirePressureGraphSet1.LeftRangeMax = 50;
            this.tirePressureGraphSet1.LeftRangeMin = 0;
            this.tirePressureGraphSet1.Location = new System.Drawing.Point(262, 3);
            this.tirePressureGraphSet1.Name = "tirePressureGraphSet1";
            this.tirePressureGraphSet1.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.tirePressureGraphSet1.RightRangeMax = 50;
            this.tirePressureGraphSet1.RightRangeMin = 0;
            this.tirePressureGraphSet1.Size = new System.Drawing.Size(253, 234);
            this.tirePressureGraphSet1.TabIndex = 0;
            // 
            // tireTempGraphSet1
            // 
            this.tireTempGraphSet1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tireTempGraphSet1.BackColor = System.Drawing.Color.Black;
            this.tireTempGraphSet1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tireTempGraphSet1.Location = new System.Drawing.Point(3, 3);
            this.tireTempGraphSet1.Name = "tireTempGraphSet1";
            this.tireTempGraphSet1.Padding = new System.Windows.Forms.Padding(2);
            this.tireTempGraphSet1.Size = new System.Drawing.Size(253, 234);
            this.tireTempGraphSet1.TabIndex = 1;
            this.tireTempGraphSet1.TireTempRange = 85F;
            this.tireTempGraphSet1.TireTempWarning = 200F;
            // 
            // tireWearGraphSet1
            // 
            this.tireWearGraphSet1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tireWearGraphSet1.BackColor = System.Drawing.Color.Black;
            this.tireWearGraphSet1.Location = new System.Drawing.Point(521, 3);
            this.tireWearGraphSet1.Name = "tireWearGraphSet1";
            this.tireWearGraphSet1.Padding = new System.Windows.Forms.Padding(2);
            this.tireWearGraphSet1.Size = new System.Drawing.Size(287, 234);
            this.tireWearGraphSet1.TabIndex = 2;
            this.tireWearGraphSet1.TireWearRange = 85F;
            this.tireWearGraphSet1.TireWearWarning = 85F;
            // 
            // lapTimeChart1
            // 
            this.lapTimeChart1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lapTimeChart1.AutoScale = true;
            this.lapTimeChart1.AxisLabelColor = System.Drawing.Color.WhiteSmoke;
            this.lapTimeChart1.AxisLineColor = System.Drawing.Color.Gray;
            this.lapTimeChart1.AxisWidth = 1.5F;
            this.lapTimeChart1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lapTimeChart1.BorderColor = System.Drawing.Color.DimGray;
            this.lapTimeChart1.BorderOffset = 4;
            this.lapTimeChart1.BorderWidth = 2F;
            this.tableLayoutPanel1.SetColumnSpan(this.lapTimeChart1, 3);
            this.lapTimeChart1.GridLineColor = System.Drawing.Color.DimGray;
            this.lapTimeChart1.GridLineWidth = 1F;
            this.lapTimeChart1.GridRightOffset = 6F;
            this.lapTimeChart1.GridTopOffset = 6F;
            this.lapTimeChart1.LapTimes = null;
            this.lapTimeChart1.Location = new System.Drawing.Point(3, 243);
            this.lapTimeChart1.Name = "lapTimeChart1";
            this.lapTimeChart1.Padding = new System.Windows.Forms.Padding(2);
            this.lapTimeChart1.SeriesLineColor = System.Drawing.Color.Red;
            this.lapTimeChart1.SeriesLineWidth = 0.5F;
            this.lapTimeChart1.SeriesMax = 22F;
            this.lapTimeChart1.SeriesMin = 12F;
            this.lapTimeChart1.ShowGrid = true;
            this.lapTimeChart1.ShowXAxisLabels = true;
            this.lapTimeChart1.ShowYAxisLabels = true;
            this.lapTimeChart1.Size = new System.Drawing.Size(805, 234);
            this.lapTimeChart1.TabIndex = 3;
            this.lapTimeChart1.XAxisFont = new System.Drawing.Font("Segoe UI", 6F);
            this.lapTimeChart1.XAxisOffset = 20F;
            this.lapTimeChart1.YAxisFont = new System.Drawing.Font("Segoe UI", 6F);
            this.lapTimeChart1.YAxisOffset = 30F;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 25);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tableLayoutPanel1);
            this.splitContainer1.Panel2.Padding = new System.Windows.Forms.Padding(8);
            this.splitContainer1.Size = new System.Drawing.Size(1076, 496);
            this.splitContainer1.SplitterDistance = 224;
            this.splitContainer1.TabIndex = 1;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAutoScaleLapTImes});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1076, 25);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnAutoScaleLapTImes
            // 
            this.btnAutoScaleLapTImes.CheckOnClick = true;
            this.btnAutoScaleLapTImes.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAutoScaleLapTImes.Image = ((System.Drawing.Image)(resources.GetObject("btnAutoScaleLapTImes.Image")));
            this.btnAutoScaleLapTImes.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAutoScaleLapTImes.Name = "btnAutoScaleLapTImes";
            this.btnAutoScaleLapTImes.Size = new System.Drawing.Size(23, 22);
            this.btnAutoScaleLapTImes.Text = "toolStripButton1";
            this.btnAutoScaleLapTImes.CheckedChanged += new System.EventHandler(this.btnAutoScaleLapTImes_CheckedChanged);
            // 
            // PracticeSession
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1076, 521);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "PracticeSession";
            this.Text = "Practice Session";
            this.Load += new System.EventHandler(this.PracticeSession_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private Controls.TirePressureGraphSet tirePressureGraphSet1;
        private Controls.TireTempGraphSet tireTempGraphSet1;
        private Controls.TireWearGraphSet tireWearGraphSet1;
        private Controls.LapTimeChart lapTimeChart1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnAutoScaleLapTImes;
    }
}