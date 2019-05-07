namespace RacerData.rNascarApp.Controls.CreateViewWizard
{
    partial class CreateViewWizard2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateViewWizard2));
            this.lblCaption = new System.Windows.Forms.Label();
            this.pnlDataSources = new System.Windows.Forms.Panel();
            this.trvDataSources = new System.Windows.Forms.TreeView();
            this.ilDataSourceImages = new System.Windows.Forms.ImageList(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.lstSelected = new System.Windows.Forms.ListBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.pnlDataSources.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblCaption
            // 
            this.lblCaption.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblCaption.Location = new System.Drawing.Point(0, 0);
            this.lblCaption.Name = "lblCaption";
            this.lblCaption.Padding = new System.Windows.Forms.Padding(2);
            this.lblCaption.Size = new System.Drawing.Size(683, 20);
            this.lblCaption.TabIndex = 4;
            this.lblCaption.Text = "<Caption>";
            this.lblCaption.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlDataSources
            // 
            this.pnlDataSources.Controls.Add(this.trvDataSources);
            this.pnlDataSources.Controls.Add(this.label1);
            this.pnlDataSources.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlDataSources.Location = new System.Drawing.Point(0, 20);
            this.pnlDataSources.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlDataSources.Name = "pnlDataSources";
            this.pnlDataSources.Padding = new System.Windows.Forms.Padding(2);
            this.pnlDataSources.Size = new System.Drawing.Size(270, 340);
            this.pnlDataSources.TabIndex = 5;
            // 
            // trvDataSources
            // 
            this.trvDataSources.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trvDataSources.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.trvDataSources.HideSelection = false;
            this.trvDataSources.ImageIndex = 0;
            this.trvDataSources.ImageList = this.ilDataSourceImages;
            this.trvDataSources.Location = new System.Drawing.Point(2, 31);
            this.trvDataSources.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.trvDataSources.Name = "trvDataSources";
            this.trvDataSources.SelectedImageIndex = 0;
            this.trvDataSources.Size = new System.Drawing.Size(266, 307);
            this.trvDataSources.TabIndex = 3;
            this.trvDataSources.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.trvDataSources_AfterSelect);
            this.trvDataSources.DoubleClick += new System.EventHandler(this.trvDataSources_DoubleClick);
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
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.InfoText;
            this.label1.Location = new System.Drawing.Point(2, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(266, 29);
            this.label1.TabIndex = 4;
            this.label1.Text = "Fields";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lstSelected
            // 
            this.lstSelected.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstSelected.FormattingEnabled = true;
            this.lstSelected.Location = new System.Drawing.Point(2, 31);
            this.lstSelected.Name = "lstSelected";
            this.lstSelected.Size = new System.Drawing.Size(261, 307);
            this.lstSelected.TabIndex = 6;
            this.lstSelected.SelectedIndexChanged += new System.EventHandler(this.lstSelected_SelectedIndexChanged);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(20, 3);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 7;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(20, 41);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(75, 23);
            this.btnRemove.TabIndex = 8;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.btnAdd);
            this.panel1.Controls.Add(this.btnRemove);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(270, 20);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(383, 340);
            this.panel1.TabIndex = 9;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lstSelected);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(118, 0);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(2);
            this.panel2.Size = new System.Drawing.Size(265, 340);
            this.panel2.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.InfoText;
            this.label2.Location = new System.Drawing.Point(2, 2);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(261, 29);
            this.label2.TabIndex = 5;
            this.label2.Text = "Selected";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CreateViewWizard2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnlDataSources);
            this.Controls.Add(this.lblCaption);
            this.Name = "CreateViewWizard2";
            this.Size = new System.Drawing.Size(683, 360);
            this.Load += new System.EventHandler(this.CreateViewWizard2_Load);
            this.pnlDataSources.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblCaption;
        private System.Windows.Forms.Panel pnlDataSources;
        private System.Windows.Forms.TreeView trvDataSources;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ImageList ilDataSourceImages;
        private System.Windows.Forms.ListBox lstSelected;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
    }
}
