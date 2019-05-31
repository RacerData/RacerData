﻿namespace rNascarApp.UI.Views
{
    partial class View
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.picCorner = new System.Windows.Forms.PictureBox();
            this.picRight = new System.Windows.Forms.PictureBox();
            this.picBottom = new System.Windows.Forms.PictureBox();
            this.lblHeader = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCorner)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBottom)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 3F));
            this.tableLayoutPanel1.Controls.Add(this.picCorner, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.picRight, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.picBottom, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 30);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 3F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(642, 347);
            this.tableLayoutPanel1.TabIndex = 2;
            this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.Border_Paint);
            // 
            // picCorner
            // 
            this.picCorner.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picCorner.BackColor = System.Drawing.Color.Transparent;
            this.picCorner.Cursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.picCorner.Location = new System.Drawing.Point(639, 344);
            this.picCorner.Margin = new System.Windows.Forms.Padding(0);
            this.picCorner.Name = "picCorner";
            this.picCorner.Size = new System.Drawing.Size(3, 3);
            this.picCorner.TabIndex = 3;
            this.picCorner.TabStop = false;
            this.picCorner.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ResizeBoth_MouseDown);
            this.picCorner.MouseLeave += new System.EventHandler(this.Resize_MouseLeave);
            this.picCorner.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Resize_MouseMove);
            this.picCorner.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Resize_MouseUp);
            // 
            // picRight
            // 
            this.picRight.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picRight.BackColor = System.Drawing.Color.Transparent;
            this.picRight.Cursor = System.Windows.Forms.Cursors.SizeWE;
            this.picRight.Location = new System.Drawing.Point(639, 0);
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
            // picBottom
            // 
            this.picBottom.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picBottom.BackColor = System.Drawing.Color.Transparent;
            this.picBottom.Cursor = System.Windows.Forms.Cursors.SizeNS;
            this.picBottom.Location = new System.Drawing.Point(0, 344);
            this.picBottom.Margin = new System.Windows.Forms.Padding(0);
            this.picBottom.Name = "picBottom";
            this.picBottom.Size = new System.Drawing.Size(639, 3);
            this.picBottom.TabIndex = 0;
            this.picBottom.TabStop = false;
            this.picBottom.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ResizeVertical_MouseDown);
            this.picBottom.MouseLeave += new System.EventHandler(this.Resize_MouseLeave);
            this.picBottom.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Resize_MouseMove);
            this.picBottom.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Resize_MouseUp);
            // 
            // lblHeader
            // 
            this.lblHeader.AutoEllipsis = true;
            this.lblHeader.BackColor = System.Drawing.Color.Black;
            this.lblHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblHeader.Image = global::rNascarApp.UI.Properties.Resources.headerHighlight;
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
            // View
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.lblHeader);
            this.DoubleBuffered = true;
            this.Name = "View";
            this.Size = new System.Drawing.Size(642, 377);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picCorner)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBottom)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.PictureBox picBottom;
        private System.Windows.Forms.PictureBox picCorner;
        private System.Windows.Forms.PictureBox picRight;
    }
}
