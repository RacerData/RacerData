namespace RacerData.rNascarApp.Dialogs
{
    partial class ViewDesignerDialog2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewDesignerDialog2));
            this.pnlDialogButtons = new System.Windows.Forms.Panel();
            this.btnApply = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSaveAll = new System.Windows.Forms.Button();
            this.ilDataSourceImages = new System.Windows.Forms.ImageList(this.components);
            this.pnlSteps = new System.Windows.Forms.Panel();
            this.pnlStepCaptions = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlStepDetails = new System.Windows.Forms.Panel();
            this.lblStepDetails = new System.Windows.Forms.Label();
            this.lblStepsCaption = new System.Windows.Forms.Label();
            this.pnlStepBody = new System.Windows.Forms.Panel();
            this.pnlNavigation = new System.Windows.Forms.Panel();
            this.lblError = new System.Windows.Forms.Label();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnPrevious = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblStepCaption = new System.Windows.Forms.Label();
            this.pnlDialogButtons.SuspendLayout();
            this.pnlSteps.SuspendLayout();
            this.pnlStepCaptions.SuspendLayout();
            this.pnlStepDetails.SuspendLayout();
            this.pnlNavigation.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlDialogButtons
            // 
            this.pnlDialogButtons.Controls.Add(this.btnApply);
            this.pnlDialogButtons.Controls.Add(this.btnCancel);
            this.pnlDialogButtons.Controls.Add(this.btnSaveAll);
            this.pnlDialogButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlDialogButtons.Location = new System.Drawing.Point(0, 410);
            this.pnlDialogButtons.Name = "pnlDialogButtons";
            this.pnlDialogButtons.Size = new System.Drawing.Size(916, 40);
            this.pnlDialogButtons.TabIndex = 2;
            // 
            // btnApply
            // 
            this.btnApply.Location = new System.Drawing.Point(93, 7);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(75, 25);
            this.btnApply.TabIndex = 2;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(829, 7);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 25);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnSaveAll
            // 
            this.btnSaveAll.Location = new System.Drawing.Point(12, 7);
            this.btnSaveAll.Name = "btnSaveAll";
            this.btnSaveAll.Size = new System.Drawing.Size(75, 25);
            this.btnSaveAll.TabIndex = 0;
            this.btnSaveAll.Text = "Save";
            this.btnSaveAll.UseVisualStyleBackColor = true;
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
            // pnlSteps
            // 
            this.pnlSteps.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSteps.Controls.Add(this.pnlStepCaptions);
            this.pnlSteps.Controls.Add(this.pnlStepDetails);
            this.pnlSteps.Controls.Add(this.lblStepsCaption);
            this.pnlSteps.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSteps.Location = new System.Drawing.Point(0, 0);
            this.pnlSteps.Name = "pnlSteps";
            this.pnlSteps.Size = new System.Drawing.Size(213, 410);
            this.pnlSteps.TabIndex = 3;
            // 
            // pnlStepCaptions
            // 
            this.pnlStepCaptions.Controls.Add(this.lblStepCaption);
            this.pnlStepCaptions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlStepCaptions.Location = new System.Drawing.Point(0, 28);
            this.pnlStepCaptions.Name = "pnlStepCaptions";
            this.pnlStepCaptions.Padding = new System.Windows.Forms.Padding(8);
            this.pnlStepCaptions.Size = new System.Drawing.Size(211, 280);
            this.pnlStepCaptions.TabIndex = 1;
            // 
            // pnlStepDetails
            // 
            this.pnlStepDetails.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlStepDetails.Controls.Add(this.lblStepDetails);
            this.pnlStepDetails.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlStepDetails.Location = new System.Drawing.Point(0, 308);
            this.pnlStepDetails.Name = "pnlStepDetails";
            this.pnlStepDetails.Padding = new System.Windows.Forms.Padding(4, 8, 4, 4);
            this.pnlStepDetails.Size = new System.Drawing.Size(211, 100);
            this.pnlStepDetails.TabIndex = 2;
            // 
            // lblStepDetails
            // 
            this.lblStepDetails.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblStepDetails.Location = new System.Drawing.Point(4, 8);
            this.lblStepDetails.Name = "lblStepDetails";
            this.lblStepDetails.Size = new System.Drawing.Size(199, 65);
            this.lblStepDetails.TabIndex = 0;
            this.lblStepDetails.Text = "Step Details";
            // 
            // lblStepsCaption
            // 
            this.lblStepsCaption.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblStepsCaption.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblStepsCaption.Location = new System.Drawing.Point(0, 0);
            this.lblStepsCaption.Name = "lblStepsCaption";
            this.lblStepsCaption.Size = new System.Drawing.Size(211, 28);
            this.lblStepsCaption.TabIndex = 0;
            this.lblStepsCaption.Text = "Create a View";
            this.lblStepsCaption.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlStepBody
            // 
            this.pnlStepBody.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlStepBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlStepBody.Location = new System.Drawing.Point(8, 8);
            this.pnlStepBody.Name = "pnlStepBody";
            this.pnlStepBody.Size = new System.Drawing.Size(685, 350);
            this.pnlStepBody.TabIndex = 4;
            // 
            // pnlNavigation
            // 
            this.pnlNavigation.Controls.Add(this.lblError);
            this.pnlNavigation.Controls.Add(this.btnNext);
            this.pnlNavigation.Controls.Add(this.btnPrevious);
            this.pnlNavigation.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlNavigation.Location = new System.Drawing.Point(8, 358);
            this.pnlNavigation.Name = "pnlNavigation";
            this.pnlNavigation.Size = new System.Drawing.Size(685, 42);
            this.pnlNavigation.TabIndex = 0;
            // 
            // lblError
            // 
            this.lblError.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblError.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblError.ForeColor = System.Drawing.Color.Maroon;
            this.lblError.Location = new System.Drawing.Point(69, 7);
            this.lblError.Name = "lblError";
            this.lblError.Padding = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.lblError.Size = new System.Drawing.Size(547, 26);
            this.lblError.TabIndex = 3;
            this.lblError.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnNext
            // 
            this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNext.Location = new System.Drawing.Point(622, 7);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(60, 27);
            this.btnNext.TabIndex = 2;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnPrevious
            // 
            this.btnPrevious.Location = new System.Drawing.Point(3, 7);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(60, 27);
            this.btnPrevious.TabIndex = 1;
            this.btnPrevious.Text = "Previous";
            this.btnPrevious.UseVisualStyleBackColor = true;
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.pnlStepBody);
            this.panel1.Controls.Add(this.pnlNavigation);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(213, 0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(8);
            this.panel1.Size = new System.Drawing.Size(703, 410);
            this.panel1.TabIndex = 5;
            // 
            // lblStepCaption
            // 
            this.lblStepCaption.Location = new System.Drawing.Point(11, 8);
            this.lblStepCaption.Name = "lblStepCaption";
            this.lblStepCaption.Size = new System.Drawing.Size(150, 23);
            this.lblStepCaption.TabIndex = 0;
            this.lblStepCaption.Text = "label2";
            this.lblStepCaption.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ViewDesignerDialog2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(916, 450);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnlSteps);
            this.Controls.Add(this.pnlDialogButtons);
            this.Name = "ViewDesignerDialog2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "View Designer";
            this.Load += new System.EventHandler(this.ViewDesignerDialog2_Load);
            this.pnlDialogButtons.ResumeLayout(false);
            this.pnlSteps.ResumeLayout(false);
            this.pnlStepCaptions.ResumeLayout(false);
            this.pnlStepDetails.ResumeLayout(false);
            this.pnlNavigation.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlDialogButtons;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSaveAll;
        private System.Windows.Forms.ImageList ilDataSourceImages;
        private System.Windows.Forms.Panel pnlSteps;
        private System.Windows.Forms.Panel pnlStepDetails;
        private System.Windows.Forms.FlowLayoutPanel pnlStepCaptions;
        private System.Windows.Forms.Label lblStepsCaption;
        private System.Windows.Forms.Label lblStepDetails;
        private System.Windows.Forms.Panel pnlStepBody;
        private System.Windows.Forms.Panel pnlNavigation;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnPrevious;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblStepCaption;
    }
}