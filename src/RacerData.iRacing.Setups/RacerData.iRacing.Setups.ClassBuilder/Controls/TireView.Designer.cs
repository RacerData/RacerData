namespace RacerData.iRacing.Setups.ClassBuilder.Controls
{
    partial class TireView
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
            this.lblPosition = new System.Windows.Forms.Label();
            this.lblLeftTemp = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblColdPsi = new System.Windows.Forms.Label();
            this.lblHotPsi = new System.Windows.Forms.Label();
            this.lblDeltaPsi = new System.Windows.Forms.Label();
            this.lblLeftWear = new System.Windows.Forms.Label();
            this.lblMiddleWear = new System.Windows.Forms.Label();
            this.lblRightWear = new System.Windows.Forms.Label();
            this.lblRightTemp = new System.Windows.Forms.Label();
            this.lblMiddleTemp = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblPosition
            // 
            this.lblPosition.BackColor = System.Drawing.Color.DimGray;
            this.lblPosition.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPosition.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblPosition.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPosition.ForeColor = System.Drawing.Color.White;
            this.lblPosition.Location = new System.Drawing.Point(2, 2);
            this.lblPosition.Name = "lblPosition";
            this.lblPosition.Size = new System.Drawing.Size(260, 26);
            this.lblPosition.TabIndex = 0;
            this.lblPosition.Text = "LF";
            this.lblPosition.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblLeftTemp
            // 
            this.lblLeftTemp.BackColor = System.Drawing.Color.White;
            this.lblLeftTemp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblLeftTemp.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLeftTemp.Location = new System.Drawing.Point(3, 0);
            this.lblLeftTemp.Name = "lblLeftTemp";
            this.lblLeftTemp.Size = new System.Drawing.Size(83, 34);
            this.lblLeftTemp.TabIndex = 1;
            this.lblLeftTemp.Text = "200";
            this.lblLeftTemp.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.DimGray;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 81F));
            this.tableLayoutPanel1.Controls.Add(this.lblColdPsi, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblHotPsi, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblDeltaPsi, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblLeftWear, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblMiddleWear, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblRightWear, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblRightTemp, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblMiddleTemp, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblLeftTemp, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tableLayoutPanel1.Location = new System.Drawing.Point(2, 28);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 41F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(260, 121);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // lblColdPsi
            // 
            this.lblColdPsi.BackColor = System.Drawing.Color.White;
            this.lblColdPsi.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblColdPsi.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblColdPsi.ForeColor = System.Drawing.Color.Blue;
            this.lblColdPsi.Location = new System.Drawing.Point(3, 80);
            this.lblColdPsi.Name = "lblColdPsi";
            this.lblColdPsi.Size = new System.Drawing.Size(83, 34);
            this.lblColdPsi.TabIndex = 9;
            this.lblColdPsi.Text = "15.5";
            this.lblColdPsi.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblHotPsi
            // 
            this.lblHotPsi.BackColor = System.Drawing.Color.White;
            this.lblHotPsi.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblHotPsi.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHotPsi.ForeColor = System.Drawing.Color.Red;
            this.lblHotPsi.Location = new System.Drawing.Point(92, 80);
            this.lblHotPsi.Name = "lblHotPsi";
            this.lblHotPsi.Size = new System.Drawing.Size(83, 34);
            this.lblHotPsi.TabIndex = 8;
            this.lblHotPsi.Text = "17.2";
            this.lblHotPsi.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblDeltaPsi
            // 
            this.lblDeltaPsi.BackColor = System.Drawing.Color.White;
            this.lblDeltaPsi.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDeltaPsi.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDeltaPsi.Location = new System.Drawing.Point(181, 80);
            this.lblDeltaPsi.Name = "lblDeltaPsi";
            this.lblDeltaPsi.Size = new System.Drawing.Size(76, 34);
            this.lblDeltaPsi.TabIndex = 7;
            this.lblDeltaPsi.Text = "1.7";
            this.lblDeltaPsi.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblLeftWear
            // 
            this.lblLeftWear.BackColor = System.Drawing.Color.White;
            this.lblLeftWear.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblLeftWear.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLeftWear.ForeColor = System.Drawing.Color.Gray;
            this.lblLeftWear.Location = new System.Drawing.Point(3, 40);
            this.lblLeftWear.Name = "lblLeftWear";
            this.lblLeftWear.Size = new System.Drawing.Size(83, 34);
            this.lblLeftWear.TabIndex = 6;
            this.lblLeftWear.Text = "99";
            this.lblLeftWear.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblMiddleWear
            // 
            this.lblMiddleWear.BackColor = System.Drawing.Color.White;
            this.lblMiddleWear.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblMiddleWear.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMiddleWear.ForeColor = System.Drawing.Color.Gray;
            this.lblMiddleWear.Location = new System.Drawing.Point(92, 40);
            this.lblMiddleWear.Name = "lblMiddleWear";
            this.lblMiddleWear.Size = new System.Drawing.Size(83, 34);
            this.lblMiddleWear.TabIndex = 5;
            this.lblMiddleWear.Text = "99";
            this.lblMiddleWear.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblRightWear
            // 
            this.lblRightWear.BackColor = System.Drawing.Color.White;
            this.lblRightWear.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblRightWear.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRightWear.ForeColor = System.Drawing.Color.Gray;
            this.lblRightWear.Location = new System.Drawing.Point(181, 40);
            this.lblRightWear.Name = "lblRightWear";
            this.lblRightWear.Size = new System.Drawing.Size(76, 34);
            this.lblRightWear.TabIndex = 4;
            this.lblRightWear.Text = "100";
            this.lblRightWear.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblRightTemp
            // 
            this.lblRightTemp.BackColor = System.Drawing.Color.White;
            this.lblRightTemp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblRightTemp.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRightTemp.Location = new System.Drawing.Point(181, 0);
            this.lblRightTemp.Name = "lblRightTemp";
            this.lblRightTemp.Size = new System.Drawing.Size(76, 34);
            this.lblRightTemp.TabIndex = 3;
            this.lblRightTemp.Text = "200.0";
            this.lblRightTemp.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblMiddleTemp
            // 
            this.lblMiddleTemp.BackColor = System.Drawing.Color.White;
            this.lblMiddleTemp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblMiddleTemp.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMiddleTemp.Location = new System.Drawing.Point(92, 0);
            this.lblMiddleTemp.Name = "lblMiddleTemp";
            this.lblMiddleTemp.Size = new System.Drawing.Size(83, 34);
            this.lblMiddleTemp.TabIndex = 2;
            this.lblMiddleTemp.Text = "200";
            this.lblMiddleTemp.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // TireView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.lblPosition);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "TireView";
            this.Padding = new System.Windows.Forms.Padding(2);
            this.Size = new System.Drawing.Size(264, 151);
            this.Load += new System.EventHandler(this.LeftTireView_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblPosition;
        private System.Windows.Forms.Label lblLeftTemp;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblRightTemp;
        private System.Windows.Forms.Label lblMiddleTemp;
        private System.Windows.Forms.Label lblLeftWear;
        private System.Windows.Forms.Label lblMiddleWear;
        private System.Windows.Forms.Label lblRightWear;
        private System.Windows.Forms.Label lblColdPsi;
        private System.Windows.Forms.Label lblHotPsi;
        private System.Windows.Forms.Label lblDeltaPsi;
    }
}
