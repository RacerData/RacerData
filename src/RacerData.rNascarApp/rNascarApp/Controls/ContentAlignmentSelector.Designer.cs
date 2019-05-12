namespace RacerData.rNascarApp.Controls
{
    partial class ContentAlignmentSelector
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
            this.pnlLabels = new System.Windows.Forms.TableLayoutPanel();
            this.panel256 = new System.Windows.Forms.Panel();
            this.panel512 = new System.Windows.Forms.Panel();
            this.panel1024 = new System.Windows.Forms.Panel();
            this.panel16 = new System.Windows.Forms.Panel();
            this.panel32 = new System.Windows.Forms.Panel();
            this.panel64 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtAlignment = new System.Windows.Forms.TextBox();
            this.pnlLabels.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlLabels
            // 
            this.pnlLabels.BackColor = System.Drawing.SystemColors.Control;
            this.pnlLabels.ColumnCount = 3;
            this.pnlLabels.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.pnlLabels.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.pnlLabels.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.pnlLabels.Controls.Add(this.panel256, 0, 2);
            this.pnlLabels.Controls.Add(this.panel512, 1, 2);
            this.pnlLabels.Controls.Add(this.panel1024, 2, 2);
            this.pnlLabels.Controls.Add(this.panel16, 0, 1);
            this.pnlLabels.Controls.Add(this.panel32, 1, 1);
            this.pnlLabels.Controls.Add(this.panel64, 2, 1);
            this.pnlLabels.Controls.Add(this.panel4, 2, 0);
            this.pnlLabels.Controls.Add(this.panel1, 0, 0);
            this.pnlLabels.Controls.Add(this.panel2, 1, 0);
            this.pnlLabels.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLabels.Location = new System.Drawing.Point(1, 22);
            this.pnlLabels.Margin = new System.Windows.Forms.Padding(1);
            this.pnlLabels.Name = "pnlLabels";
            this.pnlLabels.RowCount = 3;
            this.pnlLabels.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.pnlLabels.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.pnlLabels.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.pnlLabels.Size = new System.Drawing.Size(291, 91);
            this.pnlLabels.TabIndex = 0;
            // 
            // panel256
            // 
            this.panel256.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel256.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel256.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel256.Location = new System.Drawing.Point(2, 61);
            this.panel256.Margin = new System.Windows.Forms.Padding(2, 1, 1, 2);
            this.panel256.Name = "panel256";
            this.panel256.Size = new System.Drawing.Size(94, 28);
            this.panel256.TabIndex = 8;
            this.panel256.Tag = "256";
            this.panel256.Click += new System.EventHandler(this.panel_Click);
            // 
            // panel512
            // 
            this.panel512.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel512.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel512.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel512.Location = new System.Drawing.Point(98, 61);
            this.panel512.Margin = new System.Windows.Forms.Padding(1, 1, 1, 2);
            this.panel512.Name = "panel512";
            this.panel512.Size = new System.Drawing.Size(95, 28);
            this.panel512.TabIndex = 6;
            this.panel512.Tag = "512";
            this.panel512.Click += new System.EventHandler(this.panel_Click);
            // 
            // panel1024
            // 
            this.panel1024.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1024.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel1024.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1024.Location = new System.Drawing.Point(195, 61);
            this.panel1024.Margin = new System.Windows.Forms.Padding(1, 1, 2, 2);
            this.panel1024.Name = "panel1024";
            this.panel1024.Size = new System.Drawing.Size(94, 28);
            this.panel1024.TabIndex = 7;
            this.panel1024.Tag = "1024";
            this.panel1024.Click += new System.EventHandler(this.panel_Click);
            // 
            // panel16
            // 
            this.panel16.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel16.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel16.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel16.Location = new System.Drawing.Point(2, 31);
            this.panel16.Margin = new System.Windows.Forms.Padding(2, 1, 1, 1);
            this.panel16.Name = "panel16";
            this.panel16.Size = new System.Drawing.Size(94, 28);
            this.panel16.TabIndex = 5;
            this.panel16.Tag = "16";
            this.panel16.Click += new System.EventHandler(this.panel_Click);
            // 
            // panel32
            // 
            this.panel32.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel32.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel32.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel32.Location = new System.Drawing.Point(98, 31);
            this.panel32.Margin = new System.Windows.Forms.Padding(1);
            this.panel32.Name = "panel32";
            this.panel32.Size = new System.Drawing.Size(95, 28);
            this.panel32.TabIndex = 3;
            this.panel32.Tag = "32";
            this.panel32.Click += new System.EventHandler(this.panel_Click);
            // 
            // panel64
            // 
            this.panel64.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel64.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel64.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel64.Location = new System.Drawing.Point(195, 31);
            this.panel64.Margin = new System.Windows.Forms.Padding(1, 1, 2, 1);
            this.panel64.Name = "panel64";
            this.panel64.Size = new System.Drawing.Size(94, 28);
            this.panel64.TabIndex = 4;
            this.panel64.Tag = "64";
            this.panel64.Click += new System.EventHandler(this.panel_Click);
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Location = new System.Drawing.Point(195, 2);
            this.panel4.Margin = new System.Windows.Forms.Padding(1, 2, 2, 1);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(94, 27);
            this.panel4.TabIndex = 2;
            this.panel4.Tag = "4";
            this.panel4.Click += new System.EventHandler(this.panel_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(2, 2);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 1, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(94, 27);
            this.panel1.TabIndex = 0;
            this.panel1.Click += new System.EventHandler(this.panel_Click);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Location = new System.Drawing.Point(98, 2);
            this.panel2.Margin = new System.Windows.Forms.Padding(1, 2, 1, 1);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(95, 27);
            this.panel2.TabIndex = 1;
            this.panel2.Tag = "2";
            this.panel2.Click += new System.EventHandler(this.panel_Click);
            // 
            // txtAlignment
            // 
            this.txtAlignment.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtAlignment.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAlignment.Location = new System.Drawing.Point(1, 1);
            this.txtAlignment.Name = "txtAlignment";
            this.txtAlignment.ReadOnly = true;
            this.txtAlignment.Size = new System.Drawing.Size(291, 21);
            this.txtAlignment.TabIndex = 1;
            this.txtAlignment.Click += new System.EventHandler(this.txtAlignment_Click);
            this.txtAlignment.TextChanged += new System.EventHandler(this.txtAlignment_TextChanged);
            // 
            // ContentAlignmentSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.pnlLabels);
            this.Controls.Add(this.txtAlignment);
            this.Name = "ContentAlignmentSelector";
            this.Padding = new System.Windows.Forms.Padding(1);
            this.Size = new System.Drawing.Size(293, 114);
            this.Leave += new System.EventHandler(this.ContentAlignmentSelector_Leave);
            this.MouseLeave += new System.EventHandler(this.ContentAlignmentSelector_Leave);
            this.pnlLabels.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel pnlLabels;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel256;
        private System.Windows.Forms.Panel panel512;
        private System.Windows.Forms.Panel panel1024;
        private System.Windows.Forms.Panel panel16;
        private System.Windows.Forms.Panel panel32;
        private System.Windows.Forms.Panel panel64;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtAlignment;
    }
}
