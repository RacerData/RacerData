namespace RacerData.Data.TestApp
{
    partial class Form1
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
            this.lstS3Objects = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cboRepositories = new System.Windows.Forms.ComboBox();
            this.btnGetS3Objects = new System.Windows.Forms.Button();
            this.pnlMessages = new System.Windows.Forms.Panel();
            this.txtMessages = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtS3ObjectETag = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtS3ObjectContentLength = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtS3ObjectContentType = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnDeleteS3Object = new System.Windows.Forms.Button();
            this.btnPutS3Object = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtS3ObjectKey = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnGetS3Object = new System.Windows.Forms.Button();
            this.txtS3Object = new System.Windows.Forms.RichTextBox();
            this.pnlMessages.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstS3Objects
            // 
            this.lstS3Objects.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lstS3Objects.FormattingEnabled = true;
            this.lstS3Objects.Location = new System.Drawing.Point(20, 71);
            this.lstS3Objects.Name = "lstS3Objects";
            this.lstS3Objects.Size = new System.Drawing.Size(274, 381);
            this.lstS3Objects.TabIndex = 0;
            this.lstS3Objects.SelectedIndexChanged += new System.EventHandler(this.lstS3Objects_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "S3Objects";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Get List of S3Objects";
            // 
            // cboRepositories
            // 
            this.cboRepositories.FormattingEnabled = true;
            this.cboRepositories.Location = new System.Drawing.Point(20, 31);
            this.cboRepositories.Name = "cboRepositories";
            this.cboRepositories.Size = new System.Drawing.Size(274, 21);
            this.cboRepositories.TabIndex = 3;
            this.cboRepositories.TextChanged += new System.EventHandler(this.cboRepositories_TextChanged);
            // 
            // btnGetS3Objects
            // 
            this.btnGetS3Objects.Location = new System.Drawing.Point(300, 31);
            this.btnGetS3Objects.Name = "btnGetS3Objects";
            this.btnGetS3Objects.Size = new System.Drawing.Size(130, 23);
            this.btnGetS3Objects.TabIndex = 4;
            this.btnGetS3Objects.Text = "Get S3Objects";
            this.btnGetS3Objects.UseVisualStyleBackColor = true;
            this.btnGetS3Objects.Click += new System.EventHandler(this.btnGetS3Objects_Click);
            // 
            // pnlMessages
            // 
            this.pnlMessages.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlMessages.Controls.Add(this.txtMessages);
            this.pnlMessages.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlMessages.Location = new System.Drawing.Point(0, 481);
            this.pnlMessages.Name = "pnlMessages";
            this.pnlMessages.Padding = new System.Windows.Forms.Padding(2);
            this.pnlMessages.Size = new System.Drawing.Size(1085, 115);
            this.pnlMessages.TabIndex = 5;
            // 
            // txtMessages
            // 
            this.txtMessages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMessages.Location = new System.Drawing.Point(2, 2);
            this.txtMessages.Multiline = true;
            this.txtMessages.Name = "txtMessages";
            this.txtMessages.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtMessages.Size = new System.Drawing.Size(1079, 109);
            this.txtMessages.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txtS3Object);
            this.panel2.Controls.Add(this.txtS3ObjectETag);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.txtS3ObjectContentLength);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.txtS3ObjectContentType);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.btnDeleteS3Object);
            this.panel2.Controls.Add(this.btnPutS3Object);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.txtS3ObjectKey);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.btnGetS3Object);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.lstS3Objects);
            this.panel2.Controls.Add(this.btnGetS3Objects);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.cboRepositories);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1085, 481);
            this.panel2.TabIndex = 6;
            // 
            // txtS3ObjectETag
            // 
            this.txtS3ObjectETag.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtS3ObjectETag.Location = new System.Drawing.Point(738, 71);
            this.txtS3ObjectETag.Name = "txtS3ObjectETag";
            this.txtS3ObjectETag.Size = new System.Drawing.Size(335, 20);
            this.txtS3ObjectETag.TabIndex = 17;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(738, 57);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "S3Object ETag";
            // 
            // txtS3ObjectContentLength
            // 
            this.txtS3ObjectContentLength.Location = new System.Drawing.Point(587, 71);
            this.txtS3ObjectContentLength.Name = "txtS3ObjectContentLength";
            this.txtS3ObjectContentLength.Size = new System.Drawing.Size(145, 20);
            this.txtS3ObjectContentLength.TabIndex = 15;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(587, 57);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(124, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "S3Object ContentLength";
            // 
            // txtS3ObjectContentType
            // 
            this.txtS3ObjectContentType.Location = new System.Drawing.Point(436, 71);
            this.txtS3ObjectContentType.Name = "txtS3ObjectContentType";
            this.txtS3ObjectContentType.Size = new System.Drawing.Size(145, 20);
            this.txtS3ObjectContentType.TabIndex = 13;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(436, 57);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(115, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "S3Object ContentType";
            // 
            // btnDeleteS3Object
            // 
            this.btnDeleteS3Object.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteS3Object.Location = new System.Drawing.Point(943, 441);
            this.btnDeleteS3Object.Name = "btnDeleteS3Object";
            this.btnDeleteS3Object.Size = new System.Drawing.Size(130, 23);
            this.btnDeleteS3Object.TabIndex = 11;
            this.btnDeleteS3Object.Text = "Delete S3Object";
            this.btnDeleteS3Object.UseVisualStyleBackColor = true;
            this.btnDeleteS3Object.Click += new System.EventHandler(this.btnDeleteS3Object_Click);
            // 
            // btnPutS3Object
            // 
            this.btnPutS3Object.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPutS3Object.Location = new System.Drawing.Point(436, 441);
            this.btnPutS3Object.Name = "btnPutS3Object";
            this.btnPutS3Object.Size = new System.Drawing.Size(130, 23);
            this.btnPutS3Object.TabIndex = 10;
            this.btnPutS3Object.Text = "Put S3Object";
            this.btnPutS3Object.UseVisualStyleBackColor = true;
            this.btnPutS3Object.Click += new System.EventHandler(this.btnPutS3Object_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(433, 121);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "S3Object";
            // 
            // txtS3ObjectKey
            // 
            this.txtS3ObjectKey.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtS3ObjectKey.Location = new System.Drawing.Point(436, 34);
            this.txtS3ObjectKey.Name = "txtS3ObjectKey";
            this.txtS3ObjectKey.Size = new System.Drawing.Size(637, 20);
            this.txtS3ObjectKey.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(433, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "S3Object Key";
            // 
            // btnGetS3Object
            // 
            this.btnGetS3Object.Location = new System.Drawing.Point(300, 71);
            this.btnGetS3Object.Name = "btnGetS3Object";
            this.btnGetS3Object.Size = new System.Drawing.Size(130, 23);
            this.btnGetS3Object.TabIndex = 5;
            this.btnGetS3Object.Text = "Get S3Object";
            this.btnGetS3Object.UseVisualStyleBackColor = true;
            this.btnGetS3Object.Click += new System.EventHandler(this.btnGetS3Object_Click);
            // 
            // txtS3Object
            // 
            this.txtS3Object.AcceptsTab = true;
            this.txtS3Object.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtS3Object.Location = new System.Drawing.Point(436, 139);
            this.txtS3Object.Name = "txtS3Object";
            this.txtS3Object.Size = new System.Drawing.Size(637, 296);
            this.txtS3Object.TabIndex = 18;
            this.txtS3Object.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1085, 596);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pnlMessages);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.pnlMessages.ResumeLayout(false);
            this.pnlMessages.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lstS3Objects;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboRepositories;
        private System.Windows.Forms.Button btnGetS3Objects;
        private System.Windows.Forms.Panel pnlMessages;
        private System.Windows.Forms.TextBox txtMessages;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnGetS3Object;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtS3ObjectKey;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnDeleteS3Object;
        private System.Windows.Forms.Button btnPutS3Object;
        private System.Windows.Forms.TextBox txtS3ObjectContentType;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtS3ObjectETag;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtS3ObjectContentLength;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RichTextBox txtS3Object;
    }
}

