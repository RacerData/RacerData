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
            this.grpEditField = new System.Windows.Forms.GroupBox();
            this.cboConvertedType = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtColType = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lblFormatHelp = new System.Windows.Forms.Label();
            this.txtColTest = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtColFormat = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.rbRight = new System.Windows.Forms.RadioButton();
            this.rbCenter = new System.Windows.Forms.RadioButton();
            this.rbLeft = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.txtColCaption = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSaveEditedField = new System.Windows.Forms.Button();
            this.btnCancelEditField = new System.Windows.Forms.Button();
            this.ctxCaptionLabel = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuEditField = new System.Windows.Forms.ToolStripMenuItem();
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
            // pnlFields
            // 
            this.pnlFields.AllowDrop = true;
            this.pnlFields.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pnlFields.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFields.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFields.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlFields.Location = new System.Drawing.Point(5, 69);
            this.pnlFields.Margin = new System.Windows.Forms.Padding(0);
            this.pnlFields.Name = "pnlFields";
            this.pnlFields.Size = new System.Drawing.Size(853, 29);
            this.pnlFields.TabIndex = 6;
            this.pnlFields.DragDrop += new System.Windows.Forms.DragEventHandler(this.pnlFields_DragDrop);
            this.pnlFields.DragOver += new System.Windows.Forms.DragEventHandler(this.pnlFields_DragOver);
            // 
            // pnlCaptions
            // 
            this.pnlCaptions.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pnlCaptions.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCaptions.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCaptions.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlCaptions.Location = new System.Drawing.Point(5, 40);
            this.pnlCaptions.Margin = new System.Windows.Forms.Padding(0);
            this.pnlCaptions.Name = "pnlCaptions";
            this.pnlCaptions.Size = new System.Drawing.Size(853, 29);
            this.pnlCaptions.TabIndex = 7;
            // 
            // dragTimer
            // 
            this.dragTimer.Interval = 20;
            // 
            // grpEditField
            // 
            this.grpEditField.Controls.Add(this.cboConvertedType);
            this.grpEditField.Controls.Add(this.label3);
            this.grpEditField.Controls.Add(this.txtColType);
            this.grpEditField.Controls.Add(this.label6);
            this.grpEditField.Controls.Add(this.lblFormatHelp);
            this.grpEditField.Controls.Add(this.txtColTest);
            this.grpEditField.Controls.Add(this.label2);
            this.grpEditField.Controls.Add(this.txtColFormat);
            this.grpEditField.Controls.Add(this.label5);
            this.grpEditField.Controls.Add(this.rbRight);
            this.grpEditField.Controls.Add(this.rbCenter);
            this.grpEditField.Controls.Add(this.rbLeft);
            this.grpEditField.Controls.Add(this.label4);
            this.grpEditField.Controls.Add(this.txtColCaption);
            this.grpEditField.Controls.Add(this.label1);
            this.grpEditField.Controls.Add(this.btnSaveEditedField);
            this.grpEditField.Controls.Add(this.btnCancelEditField);
            this.grpEditField.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpEditField.Enabled = false;
            this.grpEditField.Location = new System.Drawing.Point(5, 98);
            this.grpEditField.Margin = new System.Windows.Forms.Padding(3, 3, 3, 6);
            this.grpEditField.Name = "grpEditField";
            this.grpEditField.Size = new System.Drawing.Size(853, 290);
            this.grpEditField.TabIndex = 8;
            this.grpEditField.TabStop = false;
            // 
            // cboConvertedType
            // 
            this.cboConvertedType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboConvertedType.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboConvertedType.FormattingEnabled = true;
            this.cboConvertedType.Location = new System.Drawing.Point(620, 88);
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
            this.label6.Location = new System.Drawing.Point(616, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 16);
            this.label6.TabIndex = 19;
            this.label6.Text = "Data Type";
            // 
            // lblFormatHelp
            // 
            this.lblFormatHelp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblFormatHelp.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFormatHelp.Location = new System.Drawing.Point(10, 115);
            this.lblFormatHelp.Name = "lblFormatHelp";
            this.lblFormatHelp.Padding = new System.Windows.Forms.Padding(4);
            this.lblFormatHelp.Size = new System.Drawing.Size(478, 171);
            this.lblFormatHelp.TabIndex = 18;
            // 
            // txtColTest
            // 
            this.txtColTest.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtColTest.Location = new System.Drawing.Point(282, 88);
            this.txtColTest.Name = "txtColTest";
            this.txtColTest.Size = new System.Drawing.Size(206, 21);
            this.txtColTest.TabIndex = 15;
            this.txtColTest.TextChanged += new System.EventHandler(this.FormatTest_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(279, 66);
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
            this.txtColFormat.TextChanged += new System.EventHandler(this.FormatTest_TextChanged);
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
            // rbRight
            // 
            this.rbRight.AutoSize = true;
            this.rbRight.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbRight.Location = new System.Drawing.Point(426, 40);
            this.rbRight.Name = "rbRight";
            this.rbRight.Size = new System.Drawing.Size(54, 19);
            this.rbRight.TabIndex = 11;
            this.rbRight.TabStop = true;
            this.rbRight.Text = "Right";
            this.rbRight.UseVisualStyleBackColor = true;
            this.rbRight.CheckedChanged += new System.EventHandler(this.rbAlignmentControls_CheckedChanged);
            // 
            // rbCenter
            // 
            this.rbCenter.AutoSize = true;
            this.rbCenter.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbCenter.Location = new System.Drawing.Point(344, 40);
            this.rbCenter.Name = "rbCenter";
            this.rbCenter.Size = new System.Drawing.Size(62, 19);
            this.rbCenter.TabIndex = 10;
            this.rbCenter.TabStop = true;
            this.rbCenter.Text = "Center";
            this.rbCenter.UseVisualStyleBackColor = true;
            this.rbCenter.CheckedChanged += new System.EventHandler(this.rbAlignmentControls_CheckedChanged);
            // 
            // rbLeft
            // 
            this.rbLeft.AutoSize = true;
            this.rbLeft.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbLeft.Location = new System.Drawing.Point(282, 40);
            this.rbLeft.Name = "rbLeft";
            this.rbLeft.Size = new System.Drawing.Size(45, 19);
            this.rbLeft.TabIndex = 9;
            this.rbLeft.TabStop = true;
            this.rbLeft.Text = "Left";
            this.rbLeft.UseVisualStyleBackColor = true;
            this.rbLeft.CheckedChanged += new System.EventHandler(this.rbAlignmentControls_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(282, 18);
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
            this.btnSaveEditedField.Location = new System.Drawing.Point(670, 245);
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
            this.btnCancelEditField.Location = new System.Drawing.Point(763, 245);
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
            // CreateViewWizard3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grpEditField);
            this.Controls.Add(this.pnlFields);
            this.Controls.Add(this.pnlCaptions);
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
        private System.Windows.Forms.FlowLayoutPanel pnlFields;
        private System.Windows.Forms.FlowLayoutPanel pnlCaptions;
        private System.Windows.Forms.Timer dragTimer;
        private System.Windows.Forms.GroupBox grpEditField;
        private System.Windows.Forms.Button btnCancelEditField;
        private System.Windows.Forms.Button btnSaveEditedField;
        private System.Windows.Forms.TextBox txtColCaption;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtColFormat;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RadioButton rbRight;
        private System.Windows.Forms.RadioButton rbCenter;
        private System.Windows.Forms.RadioButton rbLeft;
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
    }
}
