namespace RacerData.rNascarApp.Controls.CreateViewWizard
{
    partial class CreateViewWizard3
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
            this.lblCaption = new System.Windows.Forms.Label();
            this.pnlFields = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlCaptions = new System.Windows.Forms.FlowLayoutPanel();
            this.dragTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // lblCaption
            // 
            this.lblCaption.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblCaption.Location = new System.Drawing.Point(0, 0);
            this.lblCaption.Name = "lblCaption";
            this.lblCaption.Padding = new System.Windows.Forms.Padding(2);
            this.lblCaption.Size = new System.Drawing.Size(740, 20);
            this.lblCaption.TabIndex = 5;
            this.lblCaption.Text = "<Caption>";
            this.lblCaption.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlFields
            // 
            this.pnlFields.AllowDrop = true;
            this.pnlFields.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlFields.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pnlFields.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFields.Location = new System.Drawing.Point(17, 109);
            this.pnlFields.Margin = new System.Windows.Forms.Padding(2, 3, 0, 3);
            this.pnlFields.Name = "pnlFields";
            this.pnlFields.Size = new System.Drawing.Size(703, 46);
            this.pnlFields.TabIndex = 6;
            this.pnlFields.DragDrop += new System.Windows.Forms.DragEventHandler(this.pnlFields_DragDrop);
            this.pnlFields.DragOver += new System.Windows.Forms.DragEventHandler(this.pnlFields_DragOver);
            // 
            // pnlCaptions
            // 
            this.pnlCaptions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlCaptions.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pnlCaptions.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCaptions.Location = new System.Drawing.Point(17, 57);
            this.pnlCaptions.Margin = new System.Windows.Forms.Padding(2, 3, 0, 3);
            this.pnlCaptions.Name = "pnlCaptions";
            this.pnlCaptions.Size = new System.Drawing.Size(703, 46);
            this.pnlCaptions.TabIndex = 7;
            // 
            // dragTimer
            // 
            this.dragTimer.Interval = 20;
            // 
            // CreateViewWizard3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlCaptions);
            this.Controls.Add(this.pnlFields);
            this.Controls.Add(this.lblCaption);
            this.Name = "CreateViewWizard3";
            this.Size = new System.Drawing.Size(740, 336);
            this.Load += new System.EventHandler(this.CreateViewWizard3_Load);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.CreateViewWizard3_MouseMove);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblCaption;
        private System.Windows.Forms.FlowLayoutPanel pnlFields;
        private System.Windows.Forms.FlowLayoutPanel pnlCaptions;
        private System.Windows.Forms.Timer dragTimer;
    }
}
