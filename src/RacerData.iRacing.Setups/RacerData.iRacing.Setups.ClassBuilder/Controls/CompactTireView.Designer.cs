namespace RacerData.iRacing.Setups.ClassBuilder.Controls
{
    partial class CompactTireView
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
            this.lblRight = new System.Windows.Forms.Label();
            this.lblMiddle = new System.Windows.Forms.Label();
            this.lblLeft = new System.Windows.Forms.Label();
            this.lblEffective = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblRight
            // 
            this.lblRight.BackColor = System.Drawing.Color.White;
            this.lblRight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblRight.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRight.ForeColor = System.Drawing.Color.DimGray;
            this.lblRight.Location = new System.Drawing.Point(115, 0);
            this.lblRight.Name = "lblRight";
            this.lblRight.Size = new System.Drawing.Size(56, 24);
            this.lblRight.TabIndex = 6;
            this.lblRight.Text = "200.0";
            this.lblRight.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMiddle
            // 
            this.lblMiddle.BackColor = System.Drawing.Color.White;
            this.lblMiddle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblMiddle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMiddle.ForeColor = System.Drawing.Color.DimGray;
            this.lblMiddle.Location = new System.Drawing.Point(58, 0);
            this.lblMiddle.Name = "lblMiddle";
            this.lblMiddle.Size = new System.Drawing.Size(56, 24);
            this.lblMiddle.TabIndex = 5;
            this.lblMiddle.Text = "200";
            this.lblMiddle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblLeft
            // 
            this.lblLeft.BackColor = System.Drawing.Color.White;
            this.lblLeft.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblLeft.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLeft.ForeColor = System.Drawing.Color.DimGray;
            this.lblLeft.Location = new System.Drawing.Point(0, 0);
            this.lblLeft.Name = "lblLeft";
            this.lblLeft.Size = new System.Drawing.Size(57, 24);
            this.lblLeft.TabIndex = 4;
            this.lblLeft.Text = "200";
            this.lblLeft.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblEffective
            // 
            this.lblEffective.BackColor = System.Drawing.Color.White;
            this.lblEffective.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblEffective.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEffective.Location = new System.Drawing.Point(0, 23);
            this.lblEffective.Name = "lblEffective";
            this.lblEffective.Size = new System.Drawing.Size(171, 24);
            this.lblEffective.TabIndex = 7;
            this.lblEffective.Text = "200.0";
            this.lblEffective.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CompactTireView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblEffective);
            this.Controls.Add(this.lblRight);
            this.Controls.Add(this.lblMiddle);
            this.Controls.Add(this.lblLeft);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "CompactTireView";
            this.Padding = new System.Windows.Forms.Padding(2);
            this.Size = new System.Drawing.Size(172, 48);
            this.Load += new System.EventHandler(this.LeftTireView_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblRight;
        private System.Windows.Forms.Label lblMiddle;
        private System.Windows.Forms.Label lblLeft;
        private System.Windows.Forms.Label lblEffective;
    }
}
