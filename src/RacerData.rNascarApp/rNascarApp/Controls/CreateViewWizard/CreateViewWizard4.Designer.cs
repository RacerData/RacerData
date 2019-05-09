namespace RacerData.rNascarApp.Controls.CreateViewWizard
{
    partial class CreateViewWizard4
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
            this.pnlCaptions = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlFields = new System.Windows.Forms.FlowLayoutPanel();
            this.lblCaption = new System.Windows.Forms.Label();
            this.pnlFields1 = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlListView = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlViewTitle = new System.Windows.Forms.Panel();
            this.lblViewTitle = new System.Windows.Forms.Label();
            this.btnSaveView = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cboThemes = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.numMaxRows = new System.Windows.Forms.NumericUpDown();
            this.panel1 = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.pnlListView.SuspendLayout();
            this.pnlViewTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxRows)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlCaptions
            // 
            this.pnlCaptions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlCaptions.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pnlCaptions.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCaptions.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlCaptions.Location = new System.Drawing.Point(1, 25);
            this.pnlCaptions.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.pnlCaptions.Name = "pnlCaptions";
            this.pnlCaptions.Size = new System.Drawing.Size(738, 25);
            this.pnlCaptions.TabIndex = 10;
            // 
            // pnlFields
            // 
            this.pnlFields.AllowDrop = true;
            this.pnlFields.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlFields.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pnlFields.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFields.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlFields.Location = new System.Drawing.Point(1, 50);
            this.pnlFields.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.pnlFields.Name = "pnlFields";
            this.pnlFields.Size = new System.Drawing.Size(738, 25);
            this.pnlFields.TabIndex = 9;
            // 
            // lblCaption
            // 
            this.lblCaption.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblCaption.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCaption.Location = new System.Drawing.Point(0, 0);
            this.lblCaption.Name = "lblCaption";
            this.lblCaption.Padding = new System.Windows.Forms.Padding(2);
            this.lblCaption.Size = new System.Drawing.Size(789, 40);
            this.lblCaption.TabIndex = 8;
            this.lblCaption.Text = "<Caption>";
            this.lblCaption.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlFields1
            // 
            this.pnlFields1.AllowDrop = true;
            this.pnlFields1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlFields1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pnlFields1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFields1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlFields1.Location = new System.Drawing.Point(1, 75);
            this.pnlFields1.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.pnlFields1.Name = "pnlFields1";
            this.pnlFields1.Size = new System.Drawing.Size(738, 25);
            this.pnlFields1.TabIndex = 11;
            // 
            // pnlListView
            // 
            this.pnlListView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlListView.Controls.Add(this.pnlViewTitle);
            this.pnlListView.Controls.Add(this.pnlCaptions);
            this.pnlListView.Controls.Add(this.pnlFields);
            this.pnlListView.Controls.Add(this.pnlFields1);
            this.pnlListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlListView.Location = new System.Drawing.Point(0, 0);
            this.pnlListView.Margin = new System.Windows.Forms.Padding(0);
            this.pnlListView.Name = "pnlListView";
            this.pnlListView.Size = new System.Drawing.Size(735, 259);
            this.pnlListView.TabIndex = 12;
            // 
            // pnlViewTitle
            // 
            this.pnlViewTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlViewTitle.Controls.Add(this.lblViewTitle);
            this.pnlViewTitle.Location = new System.Drawing.Point(0, 0);
            this.pnlViewTitle.Margin = new System.Windows.Forms.Padding(0);
            this.pnlViewTitle.Name = "pnlViewTitle";
            this.pnlViewTitle.Padding = new System.Windows.Forms.Padding(2);
            this.pnlViewTitle.Size = new System.Drawing.Size(737, 25);
            this.pnlViewTitle.TabIndex = 0;
            // 
            // lblViewTitle
            // 
            this.lblViewTitle.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblViewTitle.Location = new System.Drawing.Point(2, 2);
            this.lblViewTitle.Name = "lblViewTitle";
            this.lblViewTitle.Size = new System.Drawing.Size(507, 19);
            this.lblViewTitle.TabIndex = 0;
            this.lblViewTitle.Text = "<View Title>";
            this.lblViewTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblViewTitle.DoubleClick += new System.EventHandler(this.lblViewTitle_DoubleClick);
            // 
            // btnSaveView
            // 
            this.btnSaveView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveView.Location = new System.Drawing.Point(699, 140);
            this.btnSaveView.Name = "btnSaveView";
            this.btnSaveView.Size = new System.Drawing.Size(87, 29);
            this.btnSaveView.TabIndex = 13;
            this.btnSaveView.Text = "Save View";
            this.btnSaveView.UseVisualStyleBackColor = true;
            this.btnSaveView.Click += new System.EventHandler(this.btnSaveView_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 88);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(159, 15);
            this.label1.TabIndex = 14;
            this.label1.Text = "Select a theme for the view::";
            // 
            // cboThemes
            // 
            this.cboThemes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboThemes.FormattingEnabled = true;
            this.cboThemes.Location = new System.Drawing.Point(12, 106);
            this.cboThemes.Name = "cboThemes";
            this.cboThemes.Size = new System.Drawing.Size(309, 23);
            this.cboThemes.TabIndex = 15;
            this.cboThemes.SelectedIndexChanged += new System.EventHandler(this.cboThemes_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(135, 15);
            this.label2.TabIndex = 16;
            this.label2.Text = "Enter a title for the view:";
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(12, 22);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(312, 21);
            this.txtTitle.TabIndex = 17;
            this.txtTitle.TextChanged += new System.EventHandler(this.txtTitle_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(306, 15);
            this.label3.TabIndex = 18;
            this.label3.Text = "Enter the maximum number of rows for the view (1-42):";
            // 
            // numMaxRows
            // 
            this.numMaxRows.Location = new System.Drawing.Point(12, 64);
            this.numMaxRows.Maximum = new decimal(new int[] {
            42,
            0,
            0,
            0});
            this.numMaxRows.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numMaxRows.Name = "numMaxRows";
            this.numMaxRows.Size = new System.Drawing.Size(67, 21);
            this.numMaxRows.TabIndex = 19;
            this.numMaxRows.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.numMaxRows.ValueChanged += new System.EventHandler(this.numMaxRows_ValueChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.btnSaveView);
            this.panel1.Controls.Add(this.numMaxRows);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.cboThemes);
            this.panel1.Controls.Add(this.txtTitle);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 299);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(789, 172);
            this.panel1.TabIndex = 20;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 40);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.pnlListView);
            this.splitContainer1.Size = new System.Drawing.Size(789, 259);
            this.splitContainer1.SplitterDistance = 735;
            this.splitContainer1.TabIndex = 21;
            // 
            // CreateViewWizard4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblCaption);
            this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "CreateViewWizard4";
            this.Size = new System.Drawing.Size(789, 471);
            this.Load += new System.EventHandler(this.CreateViewWizard4_Load);
            this.pnlListView.ResumeLayout(false);
            this.pnlViewTitle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numMaxRows)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel pnlCaptions;
        private System.Windows.Forms.FlowLayoutPanel pnlFields;
        private System.Windows.Forms.Label lblCaption;
        private System.Windows.Forms.FlowLayoutPanel pnlFields1;
        private System.Windows.Forms.FlowLayoutPanel pnlListView;
        private System.Windows.Forms.Panel pnlViewTitle;
        private System.Windows.Forms.Label lblViewTitle;
        private System.Windows.Forms.Button btnSaveView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboThemes;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numMaxRows;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.SplitContainer splitContainer1;
    }
}
