namespace rNascarApp.UI.Views
{
    partial class ViewBase
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewBase));
            this.picCorner = new System.Windows.Forms.PictureBox();
            this.picRight = new System.Windows.Forms.PictureBox();
            this.lblHeader = new System.Windows.Forms.Label();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.picBottom = new System.Windows.Forms.PictureBox();
            this.pnlControl = new System.Windows.Forms.Panel();
            this.picLeft = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picCorner)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRight)).BeginInit();
            this.pnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBottom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLeft)).BeginInit();
            this.SuspendLayout();
            // 
            // picCorner
            // 
            this.picCorner.BackColor = System.Drawing.Color.Transparent;
            this.picCorner.Cursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.picCorner.Dock = System.Windows.Forms.DockStyle.Right;
            this.picCorner.Location = new System.Drawing.Point(637, 0);
            this.picCorner.Margin = new System.Windows.Forms.Padding(0);
            this.picCorner.Name = "picCorner";
            this.picCorner.Size = new System.Drawing.Size(5, 1);
            this.picCorner.TabIndex = 3;
            this.picCorner.TabStop = false;
            this.picCorner.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ResizeBoth_MouseDown);
            this.picCorner.MouseLeave += new System.EventHandler(this.Resize_MouseLeave);
            this.picCorner.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Resize_MouseMove);
            this.picCorner.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Resize_MouseUp);
            // 
            // picRight
            // 
            this.picRight.BackColor = System.Drawing.Color.Transparent;
            this.picRight.Cursor = System.Windows.Forms.Cursors.SizeWE;
            this.picRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.picRight.Location = new System.Drawing.Point(639, 30);
            this.picRight.Margin = new System.Windows.Forms.Padding(0);
            this.picRight.Name = "picRight";
            this.picRight.Size = new System.Drawing.Size(3, 344);
            this.picRight.TabIndex = 2;
            this.picRight.TabStop = false;
            this.picRight.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ResizeHorizontal_MouseDown);
            this.picRight.MouseLeave += new System.EventHandler(this.Resize_MouseLeave);
            this.picRight.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Resize_MouseMove);
            this.picRight.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Resize_MouseUp);
            // 
            // lblHeader
            // 
            this.lblHeader.AutoEllipsis = true;
            this.lblHeader.BackColor = System.Drawing.Color.Black;
            this.lblHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblHeader.Image = ((System.Drawing.Image)(resources.GetObject("lblHeader.Image")));
            this.lblHeader.Location = new System.Drawing.Point(0, 0);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(642, 30);
            this.lblHeader.TabIndex = 1;
            this.lblHeader.Text = "    Best 5 Lap Average";
            this.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblHeader.Paint += new System.Windows.Forms.PaintEventHandler(this.Border_Paint);
            this.lblHeader.DoubleClick += new System.EventHandler(this.Header_DoubleClick);
            this.lblHeader.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Header_MouseDown);
            // 
            // pnlBottom
            // 
            this.pnlBottom.BackColor = System.Drawing.Color.Transparent;
            this.pnlBottom.Controls.Add(this.picCorner);
            this.pnlBottom.Controls.Add(this.picBottom);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.ForeColor = System.Drawing.Color.Transparent;
            this.pnlBottom.Location = new System.Drawing.Point(0, 374);
            this.pnlBottom.Margin = new System.Windows.Forms.Padding(0);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(642, 3);
            this.pnlBottom.TabIndex = 4;
            // 
            // picBottom
            // 
            this.picBottom.Cursor = System.Windows.Forms.Cursors.SizeNS;
            this.picBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.picBottom.Location = new System.Drawing.Point(0, 1);
            this.picBottom.Margin = new System.Windows.Forms.Padding(0);
            this.picBottom.Name = "picBottom";
            this.picBottom.Size = new System.Drawing.Size(642, 2);
            this.picBottom.TabIndex = 0;
            this.picBottom.TabStop = false;
            this.picBottom.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ResizeVertical_MouseDown);
            this.picBottom.MouseLeave += new System.EventHandler(this.Resize_MouseLeave);
            this.picBottom.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Resize_MouseMove);
            this.picBottom.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Resize_MouseUp);
            // 
            // pnlControl
            // 
            this.pnlControl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pnlControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlControl.ForeColor = System.Drawing.Color.Transparent;
            this.pnlControl.Location = new System.Drawing.Point(0, 30);
            this.pnlControl.Margin = new System.Windows.Forms.Padding(0);
            this.pnlControl.Name = "pnlControl";
            this.pnlControl.Size = new System.Drawing.Size(639, 344);
            this.pnlControl.TabIndex = 5;
            // 
            // picLeft
            // 
            this.picLeft.BackColor = System.Drawing.Color.Transparent;
            this.picLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.picLeft.Location = new System.Drawing.Point(0, 30);
            this.picLeft.Name = "picLeft";
            this.picLeft.Size = new System.Drawing.Size(3, 344);
            this.picLeft.TabIndex = 6;
            this.picLeft.TabStop = false;
            // 
            // ViewBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.picLeft);
            this.Controls.Add(this.pnlControl);
            this.Controls.Add(this.picRight);
            this.Controls.Add(this.lblHeader);
            this.Controls.Add(this.pnlBottom);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ViewBase";
            this.Size = new System.Drawing.Size(642, 377);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Border_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.picCorner)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRight)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picBottom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLeft)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.PictureBox picCorner;
        private System.Windows.Forms.PictureBox picRight;
        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.Panel pnlControl;
        private System.Windows.Forms.PictureBox picBottom;
        private System.Windows.Forms.PictureBox picLeft;
    }
}
