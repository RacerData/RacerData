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
            this.dragTimer = new System.Windows.Forms.Timer(this.components);
            this.grpEditField = new System.Windows.Forms.GroupBox();
            this.txtWidth = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.chkStretch = new System.Windows.Forms.CheckBox();
            this.chkBorder = new System.Windows.Forms.CheckBox();
            this.calAlignment = new RacerData.rNascarApp.Controls.ContentAlignmentSelector();
            this.cboConvertedType = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtColType = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lblFormatHelp = new System.Windows.Forms.Label();
            this.txtColTest = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtColFormat = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtColCaption = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSaveEditedField = new System.Windows.Forms.Button();
            this.btnCancelEditField = new System.Windows.Forms.Button();
            this.ctxCaptionLabel = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuEditField = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlCaptions = new System.Windows.Forms.Panel();
            this.pnlFields = new System.Windows.Forms.Panel();
            this.grpEditField.SuspendLayout();
            this.ctxCaptionLabel.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblCaption
            // 
            this.lblCaption.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblCaption.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCaption.Location = new System.Drawing.Point(5, 0);
            this.lblCaption.Margin = new System.Windows.Forms.Padding(3, 0, 3, 9);
            this.lblCaption.Name = "lblCaption";
            this.lblCaption.Padding = new System.Windows.Forms.Padding(2);
            this.lblCaption.Size = new System.Drawing.Size(853, 40);
            this.lblCaption.TabIndex = 5;
            this.lblCaption.Text = "<Caption>";
            this.lblCaption.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dragTimer
            // 
            this.dragTimer.Interval = 20;
            // 
            // grpEditField
            // 
            this.grpEditField.Controls.Add(this.txtWidth);
            this.grpEditField.Controls.Add(this.label7);
            this.grpEditField.Controls.Add(this.chkStretch);
            this.grpEditField.Controls.Add(this.chkBorder);
            this.grpEditField.Controls.Add(this.calAlignment);
            this.grpEditField.Controls.Add(this.cboConvertedType);
            this.grpEditField.Controls.Add(this.label3);
            this.grpEditField.Controls.Add(this.txtColType);
            this.grpEditField.Controls.Add(this.label6);
            this.grpEditField.Controls.Add(this.lblFormatHelp);
            this.grpEditField.Controls.Add(this.txtColTest);
            this.grpEditField.Controls.Add(this.label2);
            this.grpEditField.Controls.Add(this.txtColFormat);
            this.grpEditField.Controls.Add(this.label5);
            this.grpEditField.Controls.Add(this.label4);
            this.grpEditField.Controls.Add(this.txtColCaption);
            this.grpEditField.Controls.Add(this.label1);
            this.grpEditField.Controls.Add(this.btnSaveEditedField);
            this.grpEditField.Controls.Add(this.btnCancelEditField);
            this.grpEditField.Enabled = false;
            this.grpEditField.Location = new System.Drawing.Point(5, 116);
            this.grpEditField.Margin = new System.Windows.Forms.Padding(3, 3, 3, 6);
            this.grpEditField.Name = "grpEditField";
            this.grpEditField.Size = new System.Drawing.Size(853, 272);
            this.grpEditField.TabIndex = 8;
            this.grpEditField.TabStop = false;
            // 
            // txtWidth
            // 
            this.txtWidth.AllowDrop = true;
            this.txtWidth.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtWidth.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtWidth.Location = new System.Drawing.Point(404, 38);
            this.txtWidth.Name = "txtWidth";
            this.txtWidth.Size = new System.Drawing.Size(78, 21);
            this.txtWidth.TabIndex = 29;
            this.txtWidth.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtWidth_KeyDown);
            this.txtWidth.Leave += new System.EventHandler(this.txtWidth_Leave);
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(400, 18);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(45, 16);
            this.label7.TabIndex = 28;
            this.label7.Text = "Width";
            // 
            // chkStretch
            // 
            this.chkStretch.AutoSize = true;
            this.chkStretch.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkStretch.Location = new System.Drawing.Point(488, 40);
            this.chkStretch.Name = "chkStretch";
            this.chkStretch.Size = new System.Drawing.Size(68, 19);
            this.chkStretch.TabIndex = 25;
            this.chkStretch.Text = "Stretch";
            this.chkStretch.UseVisualStyleBackColor = true;
            this.chkStretch.CheckedChanged += new System.EventHandler(this.chkStretch_CheckedChanged);
            // 
            // chkBorder
            // 
            this.chkBorder.AutoSize = true;
            this.chkBorder.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkBorder.Location = new System.Drawing.Point(404, 88);
            this.chkBorder.Name = "chkBorder";
            this.chkBorder.Size = new System.Drawing.Size(65, 19);
            this.chkBorder.TabIndex = 24;
            this.chkBorder.Text = "Border";
            this.chkBorder.UseVisualStyleBackColor = true;
            this.chkBorder.CheckedChanged += new System.EventHandler(this.chkBorder_CheckedChanged);
            // 
            // calAlignment
            // 
            this.calAlignment.Alignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.calAlignment.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.calAlignment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.calAlignment.Location = new System.Drawing.Point(195, 36);
            this.calAlignment.Name = "calAlignment";
            this.calAlignment.Padding = new System.Windows.Forms.Padding(1);
            this.calAlignment.Size = new System.Drawing.Size(203, 25);
            this.calAlignment.TabIndex = 23;
            this.calAlignment.AlignmentChanged += new System.EventHandler<System.Drawing.ContentAlignment>(this.calAlignment_AlignmentChanged);
            // 
            // cboConvertedType
            // 
            this.cboConvertedType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboConvertedType.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboConvertedType.FormattingEnabled = true;
            this.cboConvertedType.Location = new System.Drawing.Point(620, 87);
            this.cboConvertedType.Name = "cboConvertedType";
            this.cboConvertedType.Size = new System.Drawing.Size(226, 23);
            this.cboConvertedType.TabIndex = 22;
            this.cboConvertedType.SelectedIndexChanged += new System.EventHandler(this.cboConvertedType_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(616, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 16);
            this.label3.TabIndex = 21;
            this.label3.Text = "Convert To:";
            // 
            // txtColType
            // 
            this.txtColType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtColType.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtColType.Location = new System.Drawing.Point(620, 38);
            this.txtColType.Name = "txtColType";
            this.txtColType.ReadOnly = true;
            this.txtColType.Size = new System.Drawing.Size(226, 21);
            this.txtColType.TabIndex = 20;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(616, 18);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 16);
            this.label6.TabIndex = 19;
            this.label6.Text = "Data Type";
            // 
            // lblFormatHelp
            // 
            this.lblFormatHelp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblFormatHelp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblFormatHelp.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFormatHelp.Location = new System.Drawing.Point(7, 173);
            this.lblFormatHelp.Name = "lblFormatHelp";
            this.lblFormatHelp.Padding = new System.Windows.Forms.Padding(4);
            this.lblFormatHelp.Size = new System.Drawing.Size(478, 83);
            this.lblFormatHelp.TabIndex = 18;
            // 
            // txtColTest
            // 
            this.txtColTest.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtColTest.Location = new System.Drawing.Point(195, 88);
            this.txtColTest.Name = "txtColTest";
            this.txtColTest.Size = new System.Drawing.Size(203, 21);
            this.txtColTest.TabIndex = 15;
            this.txtColTest.TextChanged += new System.EventHandler(this.formatTest_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(192, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 16);
            this.label2.TabIndex = 14;
            this.label2.Text = "Test Value";
            // 
            // txtColFormat
            // 
            this.txtColFormat.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtColFormat.Location = new System.Drawing.Point(10, 88);
            this.txtColFormat.Name = "txtColFormat";
            this.txtColFormat.Size = new System.Drawing.Size(179, 21);
            this.txtColFormat.TabIndex = 13;
            this.txtColFormat.TextChanged += new System.EventHandler(this.formatTest_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(7, 66);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 16);
            this.label5.TabIndex = 12;
            this.label5.Text = "Format";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(195, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 16);
            this.label4.TabIndex = 8;
            this.label4.Text = "Alignment";
            // 
            // txtColCaption
            // 
            this.txtColCaption.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtColCaption.Location = new System.Drawing.Point(10, 38);
            this.txtColCaption.Name = "txtColCaption";
            this.txtColCaption.Size = new System.Drawing.Size(179, 21);
            this.txtColCaption.TabIndex = 3;
            this.txtColCaption.TextChanged += new System.EventHandler(this.txtColCaption_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(7, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Column Caption";
            // 
            // btnSaveEditedField
            // 
            this.btnSaveEditedField.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveEditedField.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveEditedField.Location = new System.Drawing.Point(670, 227);
            this.btnSaveEditedField.Name = "btnSaveEditedField";
            this.btnSaveEditedField.Size = new System.Drawing.Size(87, 29);
            this.btnSaveEditedField.TabIndex = 1;
            this.btnSaveEditedField.Text = "Save";
            this.btnSaveEditedField.UseVisualStyleBackColor = true;
            this.btnSaveEditedField.Click += new System.EventHandler(this.btnSaveEditedField_Click);
            // 
            // btnCancelEditField
            // 
            this.btnCancelEditField.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelEditField.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelEditField.Location = new System.Drawing.Point(763, 227);
            this.btnCancelEditField.Name = "btnCancelEditField";
            this.btnCancelEditField.Size = new System.Drawing.Size(87, 29);
            this.btnCancelEditField.TabIndex = 0;
            this.btnCancelEditField.Text = "Cancel";
            this.btnCancelEditField.UseVisualStyleBackColor = true;
            this.btnCancelEditField.Click += new System.EventHandler(this.btnCancelEditField_Click);
            // 
            // ctxCaptionLabel
            // 
            this.ctxCaptionLabel.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuEditField});
            this.ctxCaptionLabel.Name = "ctxCaptionLabel";
            this.ctxCaptionLabel.Size = new System.Drawing.Size(123, 26);
            // 
            // mnuEditField
            // 
            this.mnuEditField.Name = "mnuEditField";
            this.mnuEditField.Size = new System.Drawing.Size(122, 22);
            this.mnuEditField.Text = "&Edit Field";
            this.mnuEditField.Click += new System.EventHandler(this.mnuEditField_Click);
            // 
            // pnlCaptions
            // 
            this.pnlCaptions.BackColor = System.Drawing.Color.Gray;
            this.pnlCaptions.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCaptions.Location = new System.Drawing.Point(5, 40);
            this.pnlCaptions.Name = "pnlCaptions";
            this.pnlCaptions.Size = new System.Drawing.Size(853, 29);
            this.pnlCaptions.TabIndex = 9;
            // 
            // pnlFields
            // 
            this.pnlFields.AllowDrop = true;
            this.pnlFields.BackColor = System.Drawing.Color.Gray;
            this.pnlFields.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFields.Location = new System.Drawing.Point(5, 69);
            this.pnlFields.Name = "pnlFields";
            this.pnlFields.Size = new System.Drawing.Size(853, 29);
            this.pnlFields.TabIndex = 10;
            // 
            // CreateViewWizard3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlFields);
            this.Controls.Add(this.pnlCaptions);
            this.Controls.Add(this.grpEditField);
            this.Controls.Add(this.lblCaption);
            this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "CreateViewWizard3";
            this.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.Size = new System.Drawing.Size(863, 388);
            this.Load += new System.EventHandler(this.CreateViewWizard3_Load);
            this.grpEditField.ResumeLayout(false);
            this.grpEditField.PerformLayout();
            this.ctxCaptionLabel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblCaption;
        private System.Windows.Forms.Timer dragTimer;
        private System.Windows.Forms.GroupBox grpEditField;
        private System.Windows.Forms.Button btnCancelEditField;
        private System.Windows.Forms.Button btnSaveEditedField;
        private System.Windows.Forms.TextBox txtColCaption;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtColFormat;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ContextMenuStrip ctxCaptionLabel;
        private System.Windows.Forms.ToolStripMenuItem mnuEditField;
        private System.Windows.Forms.TextBox txtColTest;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblFormatHelp;
        private System.Windows.Forms.TextBox txtColType;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboConvertedType;
        private System.Windows.Forms.Label label3;
        private ContentAlignmentSelector calAlignment;
        private System.Windows.Forms.CheckBox chkStretch;
        private System.Windows.Forms.CheckBox chkBorder;
        private System.Windows.Forms.Panel pnlCaptions;
        private System.Windows.Forms.Panel pnlFields;
        private System.Windows.Forms.TextBox txtWidth;
        private System.Windows.Forms.Label label7;
    }
}
