namespace RacerData.iRacing.Setups.ClassBuilder.Controls
{
    partial class GoodyearTireSheet
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.previousTireView = new RacerData.iRacing.Setups.ClassBuilder.Controls.PreviousTireSheetView();
            this.currentTireSheet = new RacerData.iRacing.Setups.ClassBuilder.Controls.CompactTireSheetView();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(57)))), ((int)(((byte)(132)))));
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox1.Image = global::RacerData.iRacing.Setups.ClassBuilder.Properties.Resources.GoodyearLogoSmall;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(351, 86);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // previousTireView
            // 
            this.previousTireView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(57)))), ((int)(((byte)(132)))));
            this.previousTireView.DiffModel = null;
            this.previousTireView.Dock = System.Windows.Forms.DockStyle.Top;
            this.previousTireView.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.previousTireView.Location = new System.Drawing.Point(0, 379);
            this.previousTireView.Margin = new System.Windows.Forms.Padding(6, 9, 6, 9);
            this.previousTireView.Model = null;
            this.previousTireView.Name = "previousTireView";
            this.previousTireView.Size = new System.Drawing.Size(351, 290);
            this.previousTireView.TabIndex = 2;
            this.previousTireView.TempWarning = 2D;
            this.previousTireView.WearWarning = 1D;
            // 
            // currentTireSheet
            // 
            this.currentTireSheet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(57)))), ((int)(((byte)(132)))));
            this.currentTireSheet.Dock = System.Windows.Forms.DockStyle.Top;
            this.currentTireSheet.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currentTireSheet.Location = new System.Drawing.Point(0, 86);
            this.currentTireSheet.Margin = new System.Windows.Forms.Padding(6, 9, 6, 9);
            this.currentTireSheet.Model = null;
            this.currentTireSheet.Name = "currentTireSheet";
            this.currentTireSheet.Size = new System.Drawing.Size(351, 293);
            this.currentTireSheet.TabIndex = 1;
            this.currentTireSheet.TempWarning = 2D;
            this.currentTireSheet.WearWarning = 1D;
            // 
            // GoodyearTireSheet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(57)))), ((int)(((byte)(132)))));
            this.Controls.Add(this.previousTireView);
            this.Controls.Add(this.currentTireSheet);
            this.Controls.Add(this.pictureBox1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "GoodyearTireSheet";
            this.Size = new System.Drawing.Size(351, 900);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private CompactTireSheetView currentTireSheet;
        private PreviousTireSheetView previousTireView;
    }
}
