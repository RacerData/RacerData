namespace RacerData.iRacing.Sessions.Ui.TirePressureGraph
{
    partial class TirePressureGraphSet
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.graphTable = new System.Windows.Forms.TableLayoutPanel();
            this.tirePressureViewRR = new RacerData.iRacing.Sessions.Ui.TirePressureGraph.TirePressureGraphView();
            this.tirePressureViewRF = new RacerData.iRacing.Sessions.Ui.TirePressureGraph.TirePressureGraphView();
            this.tirePressureViewLF = new RacerData.iRacing.Sessions.Ui.TirePressureGraph.TirePressureGraphView();
            this.tirePressureViewLR = new RacerData.iRacing.Sessions.Ui.TirePressureGraph.TirePressureGraphView();
            this.graphTable.SuspendLayout();
            this.SuspendLayout();
            // 
            // graphTable
            // 
            this.graphTable.ColumnCount = 2;
            this.graphTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.graphTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.graphTable.Controls.Add(this.tirePressureViewRR, 1, 1);
            this.graphTable.Controls.Add(this.tirePressureViewRF, 1, 0);
            this.graphTable.Controls.Add(this.tirePressureViewLF, 0, 0);
            this.graphTable.Controls.Add(this.tirePressureViewLR, 0, 1);
            this.graphTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.graphTable.Location = new System.Drawing.Point(20, 0);
            this.graphTable.Name = "graphTable";
            this.graphTable.RowCount = 2;
            this.graphTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.graphTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.graphTable.Size = new System.Drawing.Size(247, 260);
            this.graphTable.TabIndex = 0;
            // 
            // tirePressureViewRR
            // 
            this.tirePressureViewRR.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tirePressureViewRR.AxisLabelColor = System.Drawing.Color.LightGray;
            this.tirePressureViewRR.AxisLabelFont = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tirePressureViewRR.BackColor = System.Drawing.Color.Black;
            this.tirePressureViewRR.BorderLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tirePressureViewRR.BorderLineSize = 1F;
            this.tirePressureViewRR.ColdPsi = 18.5F;
            this.tirePressureViewRR.ColdValueLabelColor = System.Drawing.Color.LightSkyBlue;
            this.tirePressureViewRR.ColumnCount = 2;
            this.tirePressureViewRR.DeltaValueLabelColor = System.Drawing.Color.White;
            this.tirePressureViewRR.DeltaValueLabelFont = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tirePressureViewRR.GridLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.tirePressureViewRR.GridLineSize = 1F;
            this.tirePressureViewRR.HotPsi = 21.4F;
            this.tirePressureViewRR.HotValueLabelColor = System.Drawing.Color.OrangeRed;
            this.tirePressureViewRR.Location = new System.Drawing.Point(126, 133);
            this.tirePressureViewRR.Name = "tirePressureViewRR";
            this.tirePressureViewRR.Padding = new System.Windows.Forms.Padding(2);
            this.tirePressureViewRR.RangeMax = 24;
            this.tirePressureViewRR.RangeMin = 17;
            this.tirePressureViewRR.ShowGridLines = true;
            this.tirePressureViewRR.ShowLabels = true;
            this.tirePressureViewRR.Size = new System.Drawing.Size(118, 124);
            this.tirePressureViewRR.TabIndex = 3;
            this.tirePressureViewRR.ValueLabelFont = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // tirePressureViewRF
            // 
            this.tirePressureViewRF.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tirePressureViewRF.AxisLabelColor = System.Drawing.Color.LightGray;
            this.tirePressureViewRF.AxisLabelFont = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tirePressureViewRF.BackColor = System.Drawing.Color.Black;
            this.tirePressureViewRF.BorderLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tirePressureViewRF.BorderLineSize = 1F;
            this.tirePressureViewRF.ColdPsi = 18.5F;
            this.tirePressureViewRF.ColdValueLabelColor = System.Drawing.Color.LightSkyBlue;
            this.tirePressureViewRF.ColumnCount = 2;
            this.tirePressureViewRF.DeltaValueLabelColor = System.Drawing.Color.White;
            this.tirePressureViewRF.DeltaValueLabelFont = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tirePressureViewRF.GridLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.tirePressureViewRF.GridLineSize = 1F;
            this.tirePressureViewRF.HotPsi = 21.4F;
            this.tirePressureViewRF.HotValueLabelColor = System.Drawing.Color.OrangeRed;
            this.tirePressureViewRF.Location = new System.Drawing.Point(126, 3);
            this.tirePressureViewRF.Name = "tirePressureViewRF";
            this.tirePressureViewRF.Padding = new System.Windows.Forms.Padding(2);
            this.tirePressureViewRF.RangeMax = 24;
            this.tirePressureViewRF.RangeMin = 17;
            this.tirePressureViewRF.ShowGridLines = true;
            this.tirePressureViewRF.ShowLabels = true;
            this.tirePressureViewRF.Size = new System.Drawing.Size(118, 124);
            this.tirePressureViewRF.TabIndex = 2;
            this.tirePressureViewRF.ValueLabelFont = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // tirePressureViewLF
            // 
            this.tirePressureViewLF.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tirePressureViewLF.AxisLabelColor = System.Drawing.Color.LightGray;
            this.tirePressureViewLF.AxisLabelFont = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tirePressureViewLF.BackColor = System.Drawing.Color.Black;
            this.tirePressureViewLF.BorderLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tirePressureViewLF.BorderLineSize = 1F;
            this.tirePressureViewLF.ColdPsi = 15F;
            this.tirePressureViewLF.ColdValueLabelColor = System.Drawing.Color.LightSkyBlue;
            this.tirePressureViewLF.ColumnCount = 2;
            this.tirePressureViewLF.DeltaValueLabelColor = System.Drawing.Color.White;
            this.tirePressureViewLF.DeltaValueLabelFont = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tirePressureViewLF.GridLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.tirePressureViewLF.GridLineSize = 1F;
            this.tirePressureViewLF.HotPsi = 17.24F;
            this.tirePressureViewLF.HotValueLabelColor = System.Drawing.Color.OrangeRed;
            this.tirePressureViewLF.Location = new System.Drawing.Point(3, 3);
            this.tirePressureViewLF.Name = "tirePressureViewLF";
            this.tirePressureViewLF.Padding = new System.Windows.Forms.Padding(2);
            this.tirePressureViewLF.RangeMax = 19;
            this.tirePressureViewLF.RangeMin = 12;
            this.tirePressureViewLF.ShowGridLines = true;
            this.tirePressureViewLF.ShowLabels = true;
            this.tirePressureViewLF.Size = new System.Drawing.Size(117, 124);
            this.tirePressureViewLF.TabIndex = 0;
            this.tirePressureViewLF.ValueLabelFont = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // tirePressureViewLR
            // 
            this.tirePressureViewLR.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tirePressureViewLR.AxisLabelColor = System.Drawing.Color.LightGray;
            this.tirePressureViewLR.AxisLabelFont = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tirePressureViewLR.BackColor = System.Drawing.Color.Black;
            this.tirePressureViewLR.BorderLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tirePressureViewLR.BorderLineSize = 1F;
            this.tirePressureViewLR.ColdPsi = 15F;
            this.tirePressureViewLR.ColdValueLabelColor = System.Drawing.Color.LightSkyBlue;
            this.tirePressureViewLR.ColumnCount = 2;
            this.tirePressureViewLR.DeltaValueLabelColor = System.Drawing.Color.White;
            this.tirePressureViewLR.DeltaValueLabelFont = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tirePressureViewLR.GridLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.tirePressureViewLR.GridLineSize = 1F;
            this.tirePressureViewLR.HotPsi = 17.25F;
            this.tirePressureViewLR.HotValueLabelColor = System.Drawing.Color.OrangeRed;
            this.tirePressureViewLR.Location = new System.Drawing.Point(3, 133);
            this.tirePressureViewLR.Name = "tirePressureViewLR";
            this.tirePressureViewLR.Padding = new System.Windows.Forms.Padding(2);
            this.tirePressureViewLR.RangeMax = 19;
            this.tirePressureViewLR.RangeMin = 12;
            this.tirePressureViewLR.ShowGridLines = true;
            this.tirePressureViewLR.ShowLabels = true;
            this.tirePressureViewLR.Size = new System.Drawing.Size(117, 124);
            this.tirePressureViewLR.TabIndex = 1;
            this.tirePressureViewLR.ValueLabelFont = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // TirePressureGraphSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.graphTable);
            this.Name = "TirePressureGraphSet";
            this.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.Size = new System.Drawing.Size(267, 260);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.TirePressureGraphSet_Paint);
            this.graphTable.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel graphTable;
        private TirePressureGraphView tirePressureViewLF;
        private TirePressureGraphView tirePressureViewRR;
        private TirePressureGraphView tirePressureViewRF;
        private TirePressureGraphView tirePressureViewLR;
    }
}
