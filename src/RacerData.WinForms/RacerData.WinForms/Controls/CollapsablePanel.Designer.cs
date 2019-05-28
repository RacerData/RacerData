namespace RacerData.WinForms.Controls
{
    partial class CollapsablePanel
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CollapsablePanel));
            this.pnlCaption = new System.Windows.Forms.Panel();
            this.lblCaption = new System.Windows.Forms.Label();
            this.btnShowHide = new System.Windows.Forms.Button();
            this.showHideImageList = new System.Windows.Forms.ImageList(this.components);
            this.pnlCaption.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlCaption
            // 
            this.pnlCaption.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pnlCaption.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCaption.Controls.Add(this.lblCaption);
            this.pnlCaption.Controls.Add(this.btnShowHide);
            this.pnlCaption.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCaption.Location = new System.Drawing.Point(0, 0);
            this.pnlCaption.Name = "pnlCaption";
            this.pnlCaption.Padding = new System.Windows.Forms.Padding(2);
            this.pnlCaption.Size = new System.Drawing.Size(449, 25);
            this.pnlCaption.TabIndex = 0;
            // 
            // lblCaption
            // 
            this.lblCaption.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCaption.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCaption.ForeColor = System.Drawing.Color.Black;
            this.lblCaption.Location = new System.Drawing.Point(2, 2);
            this.lblCaption.Name = "lblCaption";
            this.lblCaption.Size = new System.Drawing.Size(420, 19);
            this.lblCaption.TabIndex = 0;
            this.lblCaption.Text = "Caption";
            this.lblCaption.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblCaption.BackColorChanged += new System.EventHandler(this.lblCaption_BackColorChanged);
            // 
            // btnShowHide
            // 
            this.btnShowHide.BackColor = System.Drawing.Color.Transparent;
            this.btnShowHide.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnShowHide.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnShowHide.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DodgerBlue;
            this.btnShowHide.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnShowHide.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShowHide.ImageIndex = 0;
            this.btnShowHide.ImageList = this.showHideImageList;
            this.btnShowHide.Location = new System.Drawing.Point(422, 2);
            this.btnShowHide.Name = "btnShowHide";
            this.btnShowHide.Size = new System.Drawing.Size(23, 19);
            this.btnShowHide.TabIndex = 1;
            this.btnShowHide.Text = "-";
            this.btnShowHide.UseVisualStyleBackColor = false;
            this.btnShowHide.Click += new System.EventHandler(this.btnShowHide_Click);
            // 
            // showHideImageList
            // 
            this.showHideImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("showHideImageList.ImageStream")));
            this.showHideImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.showHideImageList.Images.SetKeyName(0, "FillUpHS.png");
            this.showHideImageList.Images.SetKeyName(1, "FillDownHS.png");
            // 
            // CollapsablePanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.pnlCaption);
            this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "CollapsablePanel";
            this.Size = new System.Drawing.Size(449, 113);
            this.Load += new System.EventHandler(this.CollapsablePanel_Load);
            this.pnlCaption.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlCaption;
        private System.Windows.Forms.Button btnShowHide;
        private System.Windows.Forms.Label lblCaption;
        private System.Windows.Forms.ImageList showHideImageList;
    }
}
