namespace RacerData.rNascarApp.Controls.ListColumnEditor
{
    partial class ListColumnEditor
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
            this.pnlFields = new System.Windows.Forms.Panel();
            this.mnuEditField = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxCaptionLabel = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.txtWidth = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.chkStretch = new System.Windows.Forms.CheckBox();
            this.chkBorder = new System.Windows.Forms.CheckBox();
            this.txtColTest = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtColFormat = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtColCaption = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSaveEditedField = new System.Windows.Forms.Button();
            this.btnCancelEditField = new System.Windows.Forms.Button();
            this.grpEditField = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.calAlignment = new RacerData.rNascarApp.Controls.ContentAlignmentSelector();
            this.dragTimer = new System.Windows.Forms.Timer(this.components);
            this.pnlCaptions = new System.Windows.Forms.Panel();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblHeader = new System.Windows.Forms.Label();
            this.grpViewSettings = new System.Windows.Forms.GroupBox();
            this.label14 = new System.Windows.Forms.Label();
            this.cboThemes = new System.Windows.Forms.ComboBox();
            this.ctxCaptionLabel.SuspendLayout();
            this.grpEditField.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.grpViewSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlFields
            // 
            this.pnlFields.AllowDrop = true;
            this.pnlFields.AutoSize = true;
            this.pnlFields.BackColor = System.Drawing.Color.Gray;
            this.pnlFields.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFields.Location = new System.Drawing.Point(3, 72);
            this.pnlFields.Name = "pnlFields";
            this.pnlFields.Size = new System.Drawing.Size(905, 27);
            this.pnlFields.TabIndex = 14;
            // 
            // mnuEditField
            // 
            this.mnuEditField.Name = "mnuEditField";
            this.mnuEditField.Size = new System.Drawing.Size(122, 22);
            this.mnuEditField.Text = "&Edit Field";
            this.mnuEditField.Click += new System.EventHandler(this.mnuEditField_Click);
            // 
            // ctxCaptionLabel
            // 
            this.ctxCaptionLabel.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuEditField});
            this.ctxCaptionLabel.Name = "ctxCaptionLabel";
            this.ctxCaptionLabel.Size = new System.Drawing.Size(123, 26);
            // 
            // txtWidth
            // 
            this.txtWidth.AllowDrop = true;
            this.txtWidth.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtWidth.Location = new System.Drawing.Point(469, 44);
            this.txtWidth.Name = "txtWidth";
            this.txtWidth.Size = new System.Drawing.Size(90, 21);
            this.txtWidth.TabIndex = 29;
            this.txtWidth.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtWidth_KeyDown);
            this.txtWidth.Leave += new System.EventHandler(this.txtWidth_Leave);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(466, 21);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 15);
            this.label7.TabIndex = 28;
            this.label7.Text = "Width";
            // 
            // chkStretch
            // 
            this.chkStretch.AutoSize = true;
            this.chkStretch.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkStretch.Location = new System.Drawing.Point(576, 48);
            this.chkStretch.Name = "chkStretch";
            this.chkStretch.Size = new System.Drawing.Size(15, 14);
            this.chkStretch.TabIndex = 25;
            this.chkStretch.UseVisualStyleBackColor = true;
            // 
            // chkBorder
            // 
            this.chkBorder.AutoSize = true;
            this.chkBorder.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkBorder.Location = new System.Drawing.Point(680, 48);
            this.chkBorder.Name = "chkBorder";
            this.chkBorder.Size = new System.Drawing.Size(15, 14);
            this.chkBorder.TabIndex = 24;
            this.chkBorder.UseVisualStyleBackColor = true;
            // 
            // txtColTest
            // 
            this.txtColTest.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtColTest.Location = new System.Drawing.Point(227, 102);
            this.txtColTest.Name = "txtColTest";
            this.txtColTest.Size = new System.Drawing.Size(236, 21);
            this.txtColTest.TabIndex = 15;
            this.txtColTest.TextChanged += new System.EventHandler(this.FormatSample_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(224, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 15);
            this.label2.TabIndex = 14;
            this.label2.Text = "Test Value";
            // 
            // txtColFormat
            // 
            this.txtColFormat.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtColFormat.Location = new System.Drawing.Point(12, 102);
            this.txtColFormat.Name = "txtColFormat";
            this.txtColFormat.Size = new System.Drawing.Size(208, 21);
            this.txtColFormat.TabIndex = 13;
            this.txtColFormat.TextChanged += new System.EventHandler(this.FormatSample_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(8, 76);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 15);
            this.label5.TabIndex = 12;
            this.label5.Text = "Format";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(227, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 15);
            this.label4.TabIndex = 8;
            this.label4.Text = "Alignment";
            // 
            // txtColCaption
            // 
            this.txtColCaption.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtColCaption.Location = new System.Drawing.Point(12, 44);
            this.txtColCaption.Name = "txtColCaption";
            this.txtColCaption.Size = new System.Drawing.Size(208, 21);
            this.txtColCaption.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Column Caption";
            // 
            // btnSaveEditedField
            // 
            this.btnSaveEditedField.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveEditedField.BackColor = System.Drawing.Color.DarkGray;
            this.btnSaveEditedField.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro;
            this.btnSaveEditedField.FlatAppearance.BorderSize = 2;
            this.btnSaveEditedField.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveEditedField.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveEditedField.ForeColor = System.Drawing.Color.Black;
            this.btnSaveEditedField.Location = new System.Drawing.Point(746, 91);
            this.btnSaveEditedField.Name = "btnSaveEditedField";
            this.btnSaveEditedField.Size = new System.Drawing.Size(77, 32);
            this.btnSaveEditedField.TabIndex = 1;
            this.btnSaveEditedField.Text = "Save";
            this.btnSaveEditedField.UseVisualStyleBackColor = false;
            this.btnSaveEditedField.Click += new System.EventHandler(this.btnSaveEditedField_Click);
            // 
            // btnCancelEditField
            // 
            this.btnCancelEditField.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelEditField.BackColor = System.Drawing.Color.DarkGray;
            this.btnCancelEditField.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro;
            this.btnCancelEditField.FlatAppearance.BorderSize = 2;
            this.btnCancelEditField.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelEditField.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelEditField.ForeColor = System.Drawing.Color.Black;
            this.btnCancelEditField.Location = new System.Drawing.Point(829, 91);
            this.btnCancelEditField.Name = "btnCancelEditField";
            this.btnCancelEditField.Size = new System.Drawing.Size(77, 32);
            this.btnCancelEditField.TabIndex = 0;
            this.btnCancelEditField.Text = "Cancel";
            this.btnCancelEditField.UseVisualStyleBackColor = false;
            this.btnCancelEditField.Click += new System.EventHandler(this.btnCancelEditField_Click);
            // 
            // grpEditField
            // 
            this.grpEditField.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.grpEditField.Controls.Add(this.label9);
            this.grpEditField.Controls.Add(this.label8);
            this.grpEditField.Controls.Add(this.txtWidth);
            this.grpEditField.Controls.Add(this.label7);
            this.grpEditField.Controls.Add(this.chkStretch);
            this.grpEditField.Controls.Add(this.chkBorder);
            this.grpEditField.Controls.Add(this.calAlignment);
            this.grpEditField.Controls.Add(this.txtColTest);
            this.grpEditField.Controls.Add(this.label2);
            this.grpEditField.Controls.Add(this.txtColFormat);
            this.grpEditField.Controls.Add(this.label5);
            this.grpEditField.Controls.Add(this.label4);
            this.grpEditField.Controls.Add(this.txtColCaption);
            this.grpEditField.Controls.Add(this.label1);
            this.grpEditField.Controls.Add(this.btnSaveEditedField);
            this.grpEditField.Controls.Add(this.btnCancelEditField);
            this.grpEditField.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpEditField.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpEditField.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.grpEditField.Location = new System.Drawing.Point(0, 201);
            this.grpEditField.Margin = new System.Windows.Forms.Padding(3, 3, 3, 7);
            this.grpEditField.Name = "grpEditField";
            this.grpEditField.Size = new System.Drawing.Size(912, 148);
            this.grpEditField.TabIndex = 12;
            this.grpEditField.TabStop = false;
            this.grpEditField.Text = "Selected Column Settings";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(701, 46);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(51, 16);
            this.label9.TabIndex = 31;
            this.label9.Text = "Border";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(597, 46);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 16);
            this.label8.TabIndex = 30;
            this.label8.Text = "Stretch";
            // 
            // calAlignment
            // 
            this.calAlignment.Alignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.calAlignment.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.calAlignment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.calAlignment.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.calAlignment.Location = new System.Drawing.Point(227, 42);
            this.calAlignment.Name = "calAlignment";
            this.calAlignment.Padding = new System.Windows.Forms.Padding(1);
            this.calAlignment.Size = new System.Drawing.Size(236, 25);
            this.calAlignment.TabIndex = 23;
            // 
            // dragTimer
            // 
            this.dragTimer.Interval = 20;
            this.dragTimer.Tick += new System.EventHandler(this.DragTimer_Tick);
            // 
            // pnlCaptions
            // 
            this.pnlCaptions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlCaptions.AutoSize = true;
            this.pnlCaptions.BackColor = System.Drawing.Color.DarkGray;
            this.pnlCaptions.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCaptions.Location = new System.Drawing.Point(3, 38);
            this.pnlCaptions.Name = "pnlCaptions";
            this.pnlCaptions.Size = new System.Drawing.Size(905, 29);
            this.pnlCaptions.TabIndex = 13;
            this.pnlCaptions.Resize += new System.EventHandler(this.pnlCaptions_Resize);
            // 
            // pnlTop
            // 
            this.pnlTop.AutoScroll = true;
            this.pnlTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.pnlTop.Controls.Add(this.pnlHeader);
            this.pnlTop.Controls.Add(this.pnlFields);
            this.pnlTop.Controls.Add(this.pnlCaptions);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(912, 112);
            this.pnlTop.TabIndex = 13;
            // 
            // pnlHeader
            // 
            this.pnlHeader.AutoSize = true;
            this.pnlHeader.BackColor = System.Drawing.Color.Silver;
            this.pnlHeader.Controls.Add(this.lblHeader);
            this.pnlHeader.Location = new System.Drawing.Point(3, 5);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(905, 27);
            this.pnlHeader.TabIndex = 16;
            this.pnlHeader.FontChanged += new System.EventHandler(this.pnlHeader_FontChanged);
            this.pnlHeader.Resize += new System.EventHandler(this.pnlHeader_Resize);
            // 
            // lblHeader
            // 
            this.lblHeader.AutoSize = true;
            this.lblHeader.BackColor = System.Drawing.Color.LightGray;
            this.lblHeader.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblHeader.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.Location = new System.Drawing.Point(0, 0);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(41, 15);
            this.lblHeader.TabIndex = 15;
            this.lblHeader.Text = "label8";
            this.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblHeader.TextChanged += new System.EventHandler(this.lblHeader_TextChanged);
            // 
            // grpViewSettings
            // 
            this.grpViewSettings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.grpViewSettings.Controls.Add(this.label14);
            this.grpViewSettings.Controls.Add(this.cboThemes);
            this.grpViewSettings.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpViewSettings.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpViewSettings.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.grpViewSettings.Location = new System.Drawing.Point(0, 112);
            this.grpViewSettings.Name = "grpViewSettings";
            this.grpViewSettings.Size = new System.Drawing.Size(912, 89);
            this.grpViewSettings.TabIndex = 14;
            this.grpViewSettings.TabStop = false;
            this.grpViewSettings.Text = "View Settings";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(8, 32);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(46, 15);
            this.label14.TabIndex = 23;
            this.label14.Text = "Theme";
            // 
            // cboThemes
            // 
            this.cboThemes.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboThemes.FormattingEnabled = true;
            this.cboThemes.Location = new System.Drawing.Point(12, 50);
            this.cboThemes.Name = "cboThemes";
            this.cboThemes.Size = new System.Drawing.Size(208, 23);
            this.cboThemes.TabIndex = 22;
            this.cboThemes.SelectedIndexChanged += new System.EventHandler(this.cboThemes_SelectedIndexChanged);
            // 
            // ListColumnEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grpEditField);
            this.Controls.Add(this.grpViewSettings);
            this.Controls.Add(this.pnlTop);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ListColumnEditor";
            this.Size = new System.Drawing.Size(912, 349);
            this.Load += new System.EventHandler(this.ListColumnEditor_Load);
            this.ctxCaptionLabel.ResumeLayout(false);
            this.grpEditField.ResumeLayout(false);
            this.grpEditField.PerformLayout();
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.grpViewSettings.ResumeLayout(false);
            this.grpViewSettings.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlFields;
        private System.Windows.Forms.ToolStripMenuItem mnuEditField;
        private System.Windows.Forms.ContextMenuStrip ctxCaptionLabel;
        private System.Windows.Forms.TextBox txtWidth;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox chkStretch;
        private System.Windows.Forms.CheckBox chkBorder;
        private ContentAlignmentSelector calAlignment;
        private System.Windows.Forms.TextBox txtColTest;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtColFormat;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtColCaption;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSaveEditedField;
        private System.Windows.Forms.Button btnCancelEditField;
        private System.Windows.Forms.GroupBox grpEditField;
        private System.Windows.Forms.Timer dragTimer;
        private System.Windows.Forms.Panel pnlCaptions;
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.GroupBox grpViewSettings;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox cboThemes;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
    }
}
