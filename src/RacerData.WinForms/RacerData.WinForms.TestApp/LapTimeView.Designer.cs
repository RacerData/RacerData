namespace RacerData.WinForms
{
    partial class LapTimeView
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
            this.driverLapTimeView1 = new RacerData.WinForms.Views.DriverLapTimeView();
            this.SuspendLayout();
            // 
            // driverLapTimeView1
            // 
            this.driverLapTimeView1.Dock = System.Windows.Forms.DockStyle.Left;
            this.driverLapTimeView1.Location = new System.Drawing.Point(0, 0);
            this.driverLapTimeView1.Name = "driverLapTimeView1";
            this.driverLapTimeView1.Size = new System.Drawing.Size(177, 450);
            this.driverLapTimeView1.TabIndex = 0;
            // 
            // LapTimeView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.driverLapTimeView1);
            this.Name = "LapTimeView";
            this.Text = "LapTimeView";
            this.Load += new System.EventHandler(this.LapTimeView_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Views.DriverLapTimeView driverLapTimeView1;
    }
}