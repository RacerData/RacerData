namespace RacerData.Themes.UI.Controls
{
    partial class AppearanceColorEditor
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
            this.lblFieldTitle = new System.Windows.Forms.Label();
            this.picColor = new System.Windows.Forms.PictureBox();
            this.lblColorArgb = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picColor)).BeginInit();
            this.SuspendLayout();
            // 
            // lblFieldTitle
            // 
            this.lblFieldTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblFieldTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFieldTitle.Location = new System.Drawing.Point(2, 2);
            this.lblFieldTitle.Name = "lblFieldTitle";
            this.lblFieldTitle.Size = new System.Drawing.Size(223, 30);
            this.lblFieldTitle.TabIndex = 0;
            this.lblFieldTitle.Text = "<field>";
            this.lblFieldTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // picColor
            // 
            this.picColor.Dock = System.Windows.Forms.DockStyle.Right;
            this.picColor.Location = new System.Drawing.Point(323, 2);
            this.picColor.Name = "picColor";
            this.picColor.Size = new System.Drawing.Size(94, 30);
            this.picColor.TabIndex = 1;
            this.picColor.TabStop = false;
            this.picColor.DoubleClick += new System.EventHandler(this.picColor_DoubleClick);
            // 
            // lblColorArgb
            // 
            this.lblColorArgb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblColorArgb.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblColorArgb.Location = new System.Drawing.Point(225, 2);
            this.lblColorArgb.Name = "lblColorArgb";
            this.lblColorArgb.Size = new System.Drawing.Size(98, 30);
            this.lblColorArgb.TabIndex = 2;
            this.lblColorArgb.Text = "<argb>";
            this.lblColorArgb.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // AppearanceColorEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblFieldTitle);
            this.Controls.Add(this.lblColorArgb);
            this.Controls.Add(this.picColor);
            this.Name = "AppearanceColorEditor";
            this.Padding = new System.Windows.Forms.Padding(2);
            this.Size = new System.Drawing.Size(419, 34);
            this.Load += new System.EventHandler(this.AppearanceColorEditor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picColor)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblFieldTitle;
        private System.Windows.Forms.PictureBox picColor;
        private System.Windows.Forms.Label lblColorArgb;
    }
}
