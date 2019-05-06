namespace RacerData.rNascarApp.Dialogs
{
    partial class DisplayFormatMapDialog
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DisplayFormatMapDialog));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.pnlDataSources = new System.Windows.Forms.Panel();
            this.trvDataSources = new System.Windows.Forms.TreeView();
            this.label1 = new System.Windows.Forms.Label();
            this.lstDisplayFormats = new System.Windows.Forms.ListBox();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSetFormat = new System.Windows.Forms.Button();
            this.btnClearFormat = new System.Windows.Forms.Button();
            this.pnlMap = new System.Windows.Forms.Panel();
            this.ilDataSourceImages = new System.Windows.Forms.ImageList(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.grpDisplayFormat = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDfName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.rbLeft = new System.Windows.Forms.RadioButton();
            this.rbCenter = new System.Windows.Forms.RadioButton();
            this.rbRight = new System.Windows.Forms.RadioButton();
            this.txtDfFormat = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDfMaxWidth = new System.Windows.Forms.TextBox();
            this.lblDfMaxWidth = new System.Windows.Forms.Label();
            this.lblDsField = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lblDsType = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnNewFormat = new System.Windows.Forms.Button();
            this.btnCancelNewFormat = new System.Windows.Forms.Button();
            this.pnlDialogButtons = new System.Windows.Forms.Panel();
            this.btnSaveAll = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.ctxFormats = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label6 = new System.Windows.Forms.Label();
            this.lstUsedBy = new System.Windows.Forms.ListBox();
            this.btnApply = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.pnlDataSources.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.pnlMap.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.grpDisplayFormat.SuspendLayout();
            this.pnlDialogButtons.SuspendLayout();
            this.ctxFormats.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.pnlDataSources);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(788, 500);
            this.splitContainer1.SplitterDistance = 289;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 0;
            // 
            // pnlDataSources
            // 
            this.pnlDataSources.Controls.Add(this.trvDataSources);
            this.pnlDataSources.Controls.Add(this.label1);
            this.pnlDataSources.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDataSources.Location = new System.Drawing.Point(0, 0);
            this.pnlDataSources.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlDataSources.Name = "pnlDataSources";
            this.pnlDataSources.Size = new System.Drawing.Size(289, 500);
            this.pnlDataSources.TabIndex = 0;
            // 
            // trvDataSources
            // 
            this.trvDataSources.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trvDataSources.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.trvDataSources.HideSelection = false;
            this.trvDataSources.ImageIndex = 0;
            this.trvDataSources.ImageList = this.ilDataSourceImages;
            this.trvDataSources.Location = new System.Drawing.Point(0, 29);
            this.trvDataSources.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.trvDataSources.Name = "trvDataSources";
            this.trvDataSources.SelectedImageIndex = 0;
            this.trvDataSources.Size = new System.Drawing.Size(289, 471);
            this.trvDataSources.TabIndex = 3;
            this.trvDataSources.BeforeCollapse += new System.Windows.Forms.TreeViewCancelEventHandler(this.trvDataSources_BeforeCollapse);
            this.trvDataSources.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.trvDataSources_BeforeExpand);
            this.trvDataSources.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(this.trvDataSources_BeforeSelect);
            this.trvDataSources.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.trvDataSources_AfterSelect);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.InfoText;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(289, 29);
            this.label1.TabIndex = 4;
            this.label1.Text = "Data Sources";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lstDisplayFormats
            // 
            this.lstDisplayFormats.ContextMenuStrip = this.ctxFormats;
            this.lstDisplayFormats.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstDisplayFormats.FormattingEnabled = true;
            this.lstDisplayFormats.ItemHeight = 16;
            this.lstDisplayFormats.Location = new System.Drawing.Point(0, 29);
            this.lstDisplayFormats.Name = "lstDisplayFormats";
            this.lstDisplayFormats.Size = new System.Drawing.Size(259, 278);
            this.lstDisplayFormats.TabIndex = 0;
            this.lstDisplayFormats.SelectedIndexChanged += new System.EventHandler(this.lstDisplayFormats_SelectedIndexChanged);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.pnlMap);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.lstDisplayFormats);
            this.splitContainer2.Panel2.Controls.Add(this.label6);
            this.splitContainer2.Panel2.Controls.Add(this.lstUsedBy);
            this.splitContainer2.Panel2.Controls.Add(this.label2);
            this.splitContainer2.Size = new System.Drawing.Size(494, 500);
            this.splitContainer2.SplitterDistance = 231;
            this.splitContainer2.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.InfoText;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(259, 29);
            this.label2.TabIndex = 5;
            this.label2.Text = "Display Formats";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnSetFormat
            // 
            this.btnSetFormat.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSetFormat.Location = new System.Drawing.Point(28, 5);
            this.btnSetFormat.Name = "btnSetFormat";
            this.btnSetFormat.Size = new System.Drawing.Size(171, 28);
            this.btnSetFormat.TabIndex = 0;
            this.btnSetFormat.Text = "Set Format";
            this.btnSetFormat.UseVisualStyleBackColor = true;
            this.btnSetFormat.Click += new System.EventHandler(this.btnSetFormat_Click);
            // 
            // btnClearFormat
            // 
            this.btnClearFormat.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearFormat.Location = new System.Drawing.Point(28, 39);
            this.btnClearFormat.Name = "btnClearFormat";
            this.btnClearFormat.Size = new System.Drawing.Size(171, 25);
            this.btnClearFormat.TabIndex = 1;
            this.btnClearFormat.Text = "Clear Format";
            this.btnClearFormat.UseVisualStyleBackColor = true;
            this.btnClearFormat.Click += new System.EventHandler(this.btnClearFormat_Click);
            // 
            // pnlMap
            // 
            this.pnlMap.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.pnlMap.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlMap.Controls.Add(this.btnCancelNewFormat);
            this.pnlMap.Controls.Add(this.btnNewFormat);
            this.pnlMap.Controls.Add(this.groupBox1);
            this.pnlMap.Controls.Add(this.btnSetFormat);
            this.pnlMap.Controls.Add(this.btnClearFormat);
            this.pnlMap.Controls.Add(this.grpDisplayFormat);
            this.pnlMap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMap.Location = new System.Drawing.Point(0, 0);
            this.pnlMap.Name = "pnlMap";
            this.pnlMap.Padding = new System.Windows.Forms.Padding(2);
            this.pnlMap.Size = new System.Drawing.Size(231, 500);
            this.pnlMap.TabIndex = 2;
            // 
            // ilDataSourceImages
            // 
            this.ilDataSourceImages.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilDataSourceImages.ImageStream")));
            this.ilDataSourceImages.TransparentColor = System.Drawing.Color.Transparent;
            this.ilDataSourceImages.Images.SetKeyName(0, "lines_Text_left_justify_16xMD.png");
            this.ilDataSourceImages.Images.SetKeyName(1, "lines_Text_right_justify_16xMD.png");
            this.ilDataSourceImages.Images.SetKeyName(2, "lines_Text_centered_16xMD.png");
            this.ilDataSourceImages.Images.SetKeyName(3, "StatusAnnotations_Critical_16xMD_color.png");
            this.ilDataSourceImages.Images.SetKeyName(4, "folder_Open_16xMD.png");
            this.ilDataSourceImages.Images.SetKeyName(5, "folder_Closed_16xMD.png");
            this.ilDataSourceImages.Images.SetKeyName(6, "Guage_16xLG.png");
            this.ilDataSourceImages.Images.SetKeyName(7, "gear_16xLG.png");
            this.ilDataSourceImages.Images.SetKeyName(8, "flag_16xLG.png");
            this.ilDataSourceImages.Images.SetKeyName(9, "star_16xLG.png");
            this.ilDataSourceImages.Images.SetKeyName(10, "clock_16xLG.png");
            this.ilDataSourceImages.Images.SetKeyName(11, "base_gauge.png");
            this.ilDataSourceImages.Images.SetKeyName(12, "Gear.png");
            this.ilDataSourceImages.Images.SetKeyName(13, "Flag.png");
            this.ilDataSourceImages.Images.SetKeyName(14, "List_NumberedHS.png");
            this.ilDataSourceImages.Images.SetKeyName(15, "1522_stop_watch_48x48.png");
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.lblDsType);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.lblDsField);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(2, 134);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(225, 127);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Data Source";
            // 
            // grpDisplayFormat
            // 
            this.grpDisplayFormat.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.grpDisplayFormat.Controls.Add(this.txtDfMaxWidth);
            this.grpDisplayFormat.Controls.Add(this.lblDfMaxWidth);
            this.grpDisplayFormat.Controls.Add(this.txtDfFormat);
            this.grpDisplayFormat.Controls.Add(this.label5);
            this.grpDisplayFormat.Controls.Add(this.rbRight);
            this.grpDisplayFormat.Controls.Add(this.rbCenter);
            this.grpDisplayFormat.Controls.Add(this.rbLeft);
            this.grpDisplayFormat.Controls.Add(this.label4);
            this.grpDisplayFormat.Controls.Add(this.txtDfName);
            this.grpDisplayFormat.Controls.Add(this.label3);
            this.grpDisplayFormat.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grpDisplayFormat.Location = new System.Drawing.Point(2, 261);
            this.grpDisplayFormat.Name = "grpDisplayFormat";
            this.grpDisplayFormat.Size = new System.Drawing.Size(225, 235);
            this.grpDisplayFormat.TabIndex = 3;
            this.grpDisplayFormat.TabStop = false;
            this.grpDisplayFormat.Text = "Display Format";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(7, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 16);
            this.label3.TabIndex = 0;
            this.label3.Text = "Name";
            // 
            // txtDfName
            // 
            this.txtDfName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDfName.Location = new System.Drawing.Point(6, 41);
            this.txtDfName.Name = "txtDfName";
            this.txtDfName.Size = new System.Drawing.Size(213, 22);
            this.txtDfName.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(7, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 16);
            this.label4.TabIndex = 2;
            this.label4.Text = "Alignment";
            // 
            // rbLeft
            // 
            this.rbLeft.AutoSize = true;
            this.rbLeft.Location = new System.Drawing.Point(7, 91);
            this.rbLeft.Name = "rbLeft";
            this.rbLeft.Size = new System.Drawing.Size(47, 20);
            this.rbLeft.TabIndex = 3;
            this.rbLeft.TabStop = true;
            this.rbLeft.Text = "Left";
            this.rbLeft.UseVisualStyleBackColor = true;
            // 
            // rbCenter
            // 
            this.rbCenter.AutoSize = true;
            this.rbCenter.Location = new System.Drawing.Point(60, 91);
            this.rbCenter.Name = "rbCenter";
            this.rbCenter.Size = new System.Drawing.Size(64, 20);
            this.rbCenter.TabIndex = 4;
            this.rbCenter.TabStop = true;
            this.rbCenter.Text = "Center";
            this.rbCenter.UseVisualStyleBackColor = true;
            // 
            // rbRight
            // 
            this.rbRight.AutoSize = true;
            this.rbRight.Location = new System.Drawing.Point(130, 91);
            this.rbRight.Name = "rbRight";
            this.rbRight.Size = new System.Drawing.Size(56, 20);
            this.rbRight.TabIndex = 5;
            this.rbRight.TabStop = true;
            this.rbRight.Text = "Right";
            this.rbRight.UseVisualStyleBackColor = true;
            // 
            // txtDfFormat
            // 
            this.txtDfFormat.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDfFormat.Location = new System.Drawing.Point(6, 133);
            this.txtDfFormat.Name = "txtDfFormat";
            this.txtDfFormat.Size = new System.Drawing.Size(213, 22);
            this.txtDfFormat.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(7, 114);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 16);
            this.label5.TabIndex = 6;
            this.label5.Text = "Format";
            // 
            // txtDfMaxWidth
            // 
            this.txtDfMaxWidth.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDfMaxWidth.Location = new System.Drawing.Point(6, 179);
            this.txtDfMaxWidth.Name = "txtDfMaxWidth";
            this.txtDfMaxWidth.Size = new System.Drawing.Size(213, 22);
            this.txtDfMaxWidth.TabIndex = 9;
            // 
            // lblDfMaxWidth
            // 
            this.lblDfMaxWidth.AutoSize = true;
            this.lblDfMaxWidth.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDfMaxWidth.Location = new System.Drawing.Point(7, 160);
            this.lblDfMaxWidth.Name = "lblDfMaxWidth";
            this.lblDfMaxWidth.Size = new System.Drawing.Size(76, 16);
            this.lblDfMaxWidth.TabIndex = 8;
            this.lblDfMaxWidth.Text = "Max Width";
            // 
            // lblDsField
            // 
            this.lblDsField.AutoSize = true;
            this.lblDsField.Location = new System.Drawing.Point(4, 46);
            this.lblDsField.Name = "lblDsField";
            this.lblDsField.Size = new System.Drawing.Size(12, 16);
            this.lblDsField.TabIndex = 1;
            this.lblDsField.Text = "-";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(4, 68);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(38, 16);
            this.label11.TabIndex = 2;
            this.label11.Text = "Type";
            // 
            // lblDsType
            // 
            this.lblDsType.AutoSize = true;
            this.lblDsType.Location = new System.Drawing.Point(4, 90);
            this.lblDsType.Name = "lblDsType";
            this.lblDsType.Size = new System.Drawing.Size(12, 16);
            this.lblDsType.TabIndex = 3;
            this.lblDsType.Text = "-";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(4, 24);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 16);
            this.label7.TabIndex = 4;
            this.label7.Text = "Field";
            // 
            // btnNewFormat
            // 
            this.btnNewFormat.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNewFormat.Location = new System.Drawing.Point(28, 70);
            this.btnNewFormat.Name = "btnNewFormat";
            this.btnNewFormat.Size = new System.Drawing.Size(171, 25);
            this.btnNewFormat.TabIndex = 4;
            this.btnNewFormat.Text = "New Format";
            this.btnNewFormat.UseVisualStyleBackColor = true;
            this.btnNewFormat.Click += new System.EventHandler(this.btnNewFormat_Click);
            // 
            // btnCancelNewFormat
            // 
            this.btnCancelNewFormat.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelNewFormat.Location = new System.Drawing.Point(28, 101);
            this.btnCancelNewFormat.Name = "btnCancelNewFormat";
            this.btnCancelNewFormat.Size = new System.Drawing.Size(171, 25);
            this.btnCancelNewFormat.TabIndex = 5;
            this.btnCancelNewFormat.Text = "Cancel";
            this.btnCancelNewFormat.UseVisualStyleBackColor = true;
            this.btnCancelNewFormat.Visible = false;
            this.btnCancelNewFormat.Click += new System.EventHandler(this.btnCancelNewFormat_Click);
            // 
            // pnlDialogButtons
            // 
            this.pnlDialogButtons.Controls.Add(this.btnApply);
            this.pnlDialogButtons.Controls.Add(this.btnCancel);
            this.pnlDialogButtons.Controls.Add(this.btnSaveAll);
            this.pnlDialogButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlDialogButtons.Location = new System.Drawing.Point(0, 500);
            this.pnlDialogButtons.Name = "pnlDialogButtons";
            this.pnlDialogButtons.Size = new System.Drawing.Size(788, 40);
            this.pnlDialogButtons.TabIndex = 1;
            // 
            // btnSaveAll
            // 
            this.btnSaveAll.Location = new System.Drawing.Point(12, 7);
            this.btnSaveAll.Name = "btnSaveAll";
            this.btnSaveAll.Size = new System.Drawing.Size(75, 25);
            this.btnSaveAll.TabIndex = 0;
            this.btnSaveAll.Text = "Save";
            this.btnSaveAll.UseVisualStyleBackColor = true;
            this.btnSaveAll.Click += new System.EventHandler(this.btnSaveAll_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(701, 7);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 25);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // ctxFormats
            // 
            this.ctxFormats.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.ctxFormats.Name = "ctxFormats";
            this.ctxFormats.Size = new System.Drawing.Size(108, 48);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.editToolStripMenuItem.Text = "Edit";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label6.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label6.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.InfoText;
            this.label6.Location = new System.Drawing.Point(0, 307);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(259, 29);
            this.label6.TabIndex = 6;
            this.label6.Text = "Used By";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lstUsedBy
            // 
            this.lstUsedBy.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lstUsedBy.Enabled = false;
            this.lstUsedBy.FormattingEnabled = true;
            this.lstUsedBy.ItemHeight = 16;
            this.lstUsedBy.Location = new System.Drawing.Point(0, 336);
            this.lstUsedBy.Name = "lstUsedBy";
            this.lstUsedBy.Size = new System.Drawing.Size(259, 164);
            this.lstUsedBy.TabIndex = 7;
            // 
            // btnApply
            // 
            this.btnApply.Location = new System.Drawing.Point(93, 7);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(75, 25);
            this.btnApply.TabIndex = 2;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // DisplayFormatMapDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(788, 540);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.pnlDialogButtons);
            this.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "DisplayFormatMapDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Display Format Mapping";
            this.Load += new System.EventHandler(this.DisplayFormatMapDialog_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.pnlDataSources.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.pnlMap.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.grpDisplayFormat.ResumeLayout(false);
            this.grpDisplayFormat.PerformLayout();
            this.pnlDialogButtons.ResumeLayout(false);
            this.ctxFormats.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel pnlDataSources;
        private System.Windows.Forms.TreeView trvDataSources;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lstDisplayFormats;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnClearFormat;
        private System.Windows.Forms.Button btnSetFormat;
        private System.Windows.Forms.Panel pnlMap;
        private System.Windows.Forms.ImageList ilDataSourceImages;
        private System.Windows.Forms.GroupBox grpDisplayFormat;
        private System.Windows.Forms.TextBox txtDfMaxWidth;
        private System.Windows.Forms.Label lblDfMaxWidth;
        private System.Windows.Forms.TextBox txtDfFormat;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RadioButton rbRight;
        private System.Windows.Forms.RadioButton rbCenter;
        private System.Windows.Forms.RadioButton rbLeft;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDfName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblDsType;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblDsField;
        private System.Windows.Forms.Button btnNewFormat;
        private System.Windows.Forms.Button btnCancelNewFormat;
        private System.Windows.Forms.Panel pnlDialogButtons;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSaveAll;
        private System.Windows.Forms.ContextMenuStrip ctxFormats;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ListBox lstUsedBy;
        private System.Windows.Forms.Button btnApply;
    }
}