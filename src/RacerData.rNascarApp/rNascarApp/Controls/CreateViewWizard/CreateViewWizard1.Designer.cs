namespace RacerData.rNascarApp.Controls.CreateViewWizard
{
    partial class CreateViewWizard1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateViewWizard1));
            this.pnlDataSources = new System.Windows.Forms.Panel();
            this.trvDataSources = new System.Windows.Forms.TreeView();
            this.ilDataSourceImages = new System.Windows.Forms.ImageList(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.lblCaption = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pnlDataSources.SuspendLayout();
            this.SuspendLayout();
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
            this.pnlDataSources.Size = new System.Drawing.Size(219, 347);
            this.pnlDataSources.TabIndex = 2;
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
            this.trvDataSources.Size = new System.Drawing.Size(215, 314);
            this.trvDataSources.TabIndex = 3;
            this.trvDataSources.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.trvDataSources_AfterSelect);
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
            this.label1.Size = new System.Drawing.Size(215, 29);
            this.label1.TabIndex = 4;
            this.label1.Text = "Data Source";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCaption
            // 
            this.lblCaption.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblCaption.Location = new System.Drawing.Point(0, 0);
            this.lblCaption.Name = "lblCaption";
            this.lblCaption.Padding = new System.Windows.Forms.Padding(2);
            this.lblCaption.Size = new System.Drawing.Size(516, 20);
            this.lblCaption.TabIndex = 5;
            this.lblCaption.Text = "<Caption>";
            this.lblCaption.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(279, 183);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(161, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Select a data source to continue";
            // 
            // CreateViewWizard1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pnlDataSources);
            this.Controls.Add(this.lblCaption);
            this.Name = "CreateViewWizard1";
            this.Size = new System.Drawing.Size(516, 367);
            this.Load += new System.EventHandler(this.CreateViewWizard1_Load);
            this.pnlDataSources.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlDataSources;
        private System.Windows.Forms.TreeView trvDataSources;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ImageList ilDataSourceImages;
        private System.Windows.Forms.Label lblCaption;
        private System.Windows.Forms.Label label2;
    }
}
