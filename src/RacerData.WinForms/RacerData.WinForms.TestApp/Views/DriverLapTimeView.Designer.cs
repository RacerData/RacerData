namespace RacerData.WinForms.Views
{
    partial class DriverLapTimeView
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
            this.lblDriver = new System.Windows.Forms.Label();
            this.pnlDriver = new System.Windows.Forms.Panel();
            this.lblCarNumber = new System.Windows.Forms.Label();
            this.lvLapTimes = new System.Windows.Forms.ListView();
            this.colLap = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSpeed = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblPosition = new System.Windows.Forms.Label();
            this.pnlBestLap = new System.Windows.Forms.Panel();
            this.lblBestLapTime = new System.Windows.Forms.Label();
            this.lblBestLapNumber = new System.Windows.Forms.Label();
            this.lblBestLapSpeed = new System.Windows.Forms.Label();
            this.pnlDriver.SuspendLayout();
            this.pnlBestLap.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblDriver
            // 
            this.lblDriver.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDriver.Location = new System.Drawing.Point(30, 0);
            this.lblDriver.Name = "lblDriver";
            this.lblDriver.Size = new System.Drawing.Size(113, 27);
            this.lblDriver.TabIndex = 0;
            this.lblDriver.Text = "Wallace";
            this.lblDriver.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlDriver
            // 
            this.pnlDriver.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDriver.Controls.Add(this.lblDriver);
            this.pnlDriver.Controls.Add(this.lblPosition);
            this.pnlDriver.Controls.Add(this.lblCarNumber);
            this.pnlDriver.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlDriver.Location = new System.Drawing.Point(0, 0);
            this.pnlDriver.Name = "pnlDriver";
            this.pnlDriver.Size = new System.Drawing.Size(177, 29);
            this.pnlDriver.TabIndex = 1;
            // 
            // lblCarNumber
            // 
            this.lblCarNumber.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblCarNumber.Location = new System.Drawing.Point(143, 0);
            this.lblCarNumber.Name = "lblCarNumber";
            this.lblCarNumber.Size = new System.Drawing.Size(32, 27);
            this.lblCarNumber.TabIndex = 0;
            this.lblCarNumber.Text = "43";
            this.lblCarNumber.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lvLapTimes
            // 
            this.lvLapTimes.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colLap,
            this.colTime,
            this.colSpeed});
            this.lvLapTimes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvLapTimes.FullRowSelect = true;
            this.lvLapTimes.GridLines = true;
            this.lvLapTimes.HideSelection = false;
            this.lvLapTimes.Location = new System.Drawing.Point(0, 58);
            this.lvLapTimes.Name = "lvLapTimes";
            this.lvLapTimes.Size = new System.Drawing.Size(177, 360);
            this.lvLapTimes.TabIndex = 2;
            this.lvLapTimes.UseCompatibleStateImageBehavior = false;
            this.lvLapTimes.View = System.Windows.Forms.View.Details;
            // 
            // colLap
            // 
            this.colLap.Text = "Lap";
            this.colLap.Width = 30;
            // 
            // colTime
            // 
            this.colTime.Text = "Time";
            // 
            // colSpeed
            // 
            this.colSpeed.Text = "Speed";
            // 
            // lblPosition
            // 
            this.lblPosition.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblPosition.Location = new System.Drawing.Point(0, 0);
            this.lblPosition.Name = "lblPosition";
            this.lblPosition.Size = new System.Drawing.Size(30, 27);
            this.lblPosition.TabIndex = 1;
            this.lblPosition.Text = "0";
            this.lblPosition.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlBestLap
            // 
            this.pnlBestLap.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlBestLap.Controls.Add(this.lblBestLapTime);
            this.pnlBestLap.Controls.Add(this.lblBestLapNumber);
            this.pnlBestLap.Controls.Add(this.lblBestLapSpeed);
            this.pnlBestLap.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBestLap.Location = new System.Drawing.Point(0, 29);
            this.pnlBestLap.Name = "pnlBestLap";
            this.pnlBestLap.Size = new System.Drawing.Size(177, 29);
            this.pnlBestLap.TabIndex = 3;
            // 
            // lblBestLapTime
            // 
            this.lblBestLapTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblBestLapTime.Location = new System.Drawing.Point(30, 0);
            this.lblBestLapTime.Name = "lblBestLapTime";
            this.lblBestLapTime.Size = new System.Drawing.Size(49, 27);
            this.lblBestLapTime.TabIndex = 0;
            this.lblBestLapTime.Text = "44.254";
            this.lblBestLapTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblBestLapNumber
            // 
            this.lblBestLapNumber.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblBestLapNumber.Location = new System.Drawing.Point(0, 0);
            this.lblBestLapNumber.Name = "lblBestLapNumber";
            this.lblBestLapNumber.Size = new System.Drawing.Size(30, 27);
            this.lblBestLapNumber.TabIndex = 1;
            this.lblBestLapNumber.Text = "0";
            this.lblBestLapNumber.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblBestLapSpeed
            // 
            this.lblBestLapSpeed.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblBestLapSpeed.Location = new System.Drawing.Point(79, 0);
            this.lblBestLapSpeed.Name = "lblBestLapSpeed";
            this.lblBestLapSpeed.Size = new System.Drawing.Size(96, 27);
            this.lblBestLapSpeed.TabIndex = 0;
            this.lblBestLapSpeed.Text = "204.568 mph";
            this.lblBestLapSpeed.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DriverLapTimeView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lvLapTimes);
            this.Controls.Add(this.pnlBestLap);
            this.Controls.Add(this.pnlDriver);
            this.Name = "DriverLapTimeView";
            this.Size = new System.Drawing.Size(177, 418);
            this.Load += new System.EventHandler(this.DriverLapTimeView_Load);
            this.pnlDriver.ResumeLayout(false);
            this.pnlBestLap.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblDriver;
        private System.Windows.Forms.Panel pnlDriver;
        private System.Windows.Forms.Label lblCarNumber;
        private System.Windows.Forms.ListView lvLapTimes;
        private System.Windows.Forms.ColumnHeader colLap;
        private System.Windows.Forms.ColumnHeader colTime;
        private System.Windows.Forms.ColumnHeader colSpeed;
        private System.Windows.Forms.Label lblPosition;
        private System.Windows.Forms.Panel pnlBestLap;
        private System.Windows.Forms.Label lblBestLapTime;
        private System.Windows.Forms.Label lblBestLapNumber;
        private System.Windows.Forms.Label lblBestLapSpeed;
    }
}
