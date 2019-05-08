namespace RacerData.rNascarApp.Dialogs
{
    partial class CreateViewWizard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateViewWizard));
            this.pnlDialogButtons = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.ilDataSourceImages = new System.Windows.Forms.ImageList(this.components);
            this.pnlSteps = new System.Windows.Forms.Panel();
            this.pnlStepCaptions = new System.Windows.Forms.FlowLayoutPanel();
            this.lblStepCaption = new System.Windows.Forms.Label();
            this.pnlStepDetails = new System.Windows.Forms.Panel();
            this.lblStepDetails = new System.Windows.Forms.Label();
            this.lblStepsCaption = new System.Windows.Forms.Label();
            this.pnlStepBody = new System.Windows.Forms.Panel();
            this.pnlNavigation = new System.Windows.Forms.Panel();
            this.lblError = new System.Windows.Forms.Label();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnPrevious = new System.Windows.Forms.Button();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlDialogButtons.SuspendLayout();
            this.pnlSteps.SuspendLayout();
            this.pnlStepCaptions.SuspendLayout();
            this.pnlStepDetails.SuspendLayout();
            this.pnlNavigation.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlDialogButtons
            // 
            this.pnlDialogButtons.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pnlDialogButtons.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDialogButtons.Controls.Add(this.btnCancel);
            this.pnlDialogButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlDialogButtons.Location = new System.Drawing.Point(0, 523);
            this.pnlDialogButtons.Name = "pnlDialogButtons";
            this.pnlDialogButtons.Size = new System.Drawing.Size(1132, 46);
            this.pnlDialogButtons.TabIndex = 2;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(1037, 6);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(87, 29);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
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
            this.pnlSteps.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.pnlSteps.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSteps.Controls.Add(this.pnlStepCaptions);
            this.pnlSteps.Controls.Add(this.pnlStepDetails);
            this.pnlSteps.Controls.Add(this.lblStepsCaption);
            this.pnlSteps.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSteps.Location = new System.Drawing.Point(0, 0);
            this.pnlSteps.Name = "pnlSteps";
            this.pnlSteps.Size = new System.Drawing.Size(248, 523);
            this.pnlSteps.TabIndex = 3;
            // 
            // pnlStepCaptions
            // 
            this.pnlStepCaptions.BackColor = System.Drawing.SystemColors.Info;
            this.pnlStepCaptions.Controls.Add(this.lblStepCaption);
            this.pnlStepCaptions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlStepCaptions.Location = new System.Drawing.Point(0, 32);
            this.pnlStepCaptions.Name = "pnlStepCaptions";
            this.pnlStepCaptions.Padding = new System.Windows.Forms.Padding(9, 9, 9, 9);
            this.pnlStepCaptions.Size = new System.Drawing.Size(246, 374);
            this.pnlStepCaptions.TabIndex = 1;
            // 
            // lblStepCaption
            // 
            this.lblStepCaption.Location = new System.Drawing.Point(12, 9);
            this.lblStepCaption.Name = "lblStepCaption";
            this.lblStepCaption.Size = new System.Drawing.Size(175, 27);
            this.lblStepCaption.TabIndex = 0;
            this.lblStepCaption.Text = "label2";
            this.lblStepCaption.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlStepDetails
            // 
            this.pnlStepDetails.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pnlStepDetails.Controls.Add(this.lblStepDetails);
            this.pnlStepDetails.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlStepDetails.Location = new System.Drawing.Point(0, 406);
            this.pnlStepDetails.Name = "pnlStepDetails";
            this.pnlStepDetails.Padding = new System.Windows.Forms.Padding(5, 9, 5, 5);
            this.pnlStepDetails.Size = new System.Drawing.Size(246, 115);
            this.pnlStepDetails.TabIndex = 2;
            // 
            // lblStepDetails
            // 
            this.lblStepDetails.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblStepDetails.Location = new System.Drawing.Point(5, 9);
            this.lblStepDetails.Name = "lblStepDetails";
            this.lblStepDetails.Size = new System.Drawing.Size(236, 91);
            this.lblStepDetails.TabIndex = 0;
            this.lblStepDetails.Text = "Step Details";
            // 
            // lblStepsCaption
            // 
            this.lblStepsCaption.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblStepsCaption.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblStepsCaption.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblStepsCaption.Font = new System.Drawing.Font("Arial Black", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStepsCaption.Location = new System.Drawing.Point(0, 0);
            this.lblStepsCaption.Name = "lblStepsCaption";
            this.lblStepsCaption.Size = new System.Drawing.Size(246, 32);
            this.lblStepsCaption.TabIndex = 0;
            this.lblStepsCaption.Text = "Create a View";
            this.lblStepsCaption.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlStepBody
            // 
            this.pnlStepBody.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.pnlStepBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlStepBody.Location = new System.Drawing.Point(0, 0);
            this.pnlStepBody.Name = "pnlStepBody";
            this.pnlStepBody.Padding = new System.Windows.Forms.Padding(4, 0, 4, 2);
            this.pnlStepBody.Size = new System.Drawing.Size(884, 475);
            this.pnlStepBody.TabIndex = 4;
            // 
            // pnlNavigation
            // 
            this.pnlNavigation.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pnlNavigation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlNavigation.Controls.Add(this.lblError);
            this.pnlNavigation.Controls.Add(this.btnNext);
            this.pnlNavigation.Controls.Add(this.btnPrevious);
            this.pnlNavigation.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlNavigation.Location = new System.Drawing.Point(0, 475);
            this.pnlNavigation.Name = "pnlNavigation";
            this.pnlNavigation.Size = new System.Drawing.Size(884, 48);
            this.pnlNavigation.TabIndex = 0;
            // 
            // lblError
            // 
            this.lblError.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblError.ForeColor = System.Drawing.Color.Maroon;
            this.lblError.Location = new System.Drawing.Point(111, 0);
            this.lblError.Name = "lblError";
            this.lblError.Padding = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.lblError.Size = new System.Drawing.Size(659, 46);
            this.lblError.TabIndex = 3;
            this.lblError.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnNext
            // 
            this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNext.Location = new System.Drawing.Point(789, 8);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(87, 29);
            this.btnNext.TabIndex = 2;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnPrevious
            // 
            this.btnPrevious.Location = new System.Drawing.Point(3, 8);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(87, 29);
            this.btnPrevious.TabIndex = 1;
            this.btnPrevious.Text = "Previous";
            this.btnPrevious.UseVisualStyleBackColor = true;
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pnlMain.Controls.Add(this.pnlStepBody);
            this.pnlMain.Controls.Add(this.pnlNavigation);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(248, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(884, 523);
            this.pnlMain.TabIndex = 5;
            // 
            // ViewDesignerDialog2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1132, 569);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlSteps);
            this.Controls.Add(this.pnlDialogButtons);
            this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ViewDesignerDialog2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "View Designer";
            this.Load += new System.EventHandler(this.ViewDesignerDialog2_Load);
            this.pnlDialogButtons.ResumeLayout(false);
            this.pnlSteps.ResumeLayout(false);
            this.pnlStepCaptions.ResumeLayout(false);
            this.pnlStepDetails.ResumeLayout(false);
            this.pnlNavigation.ResumeLayout(false);
            this.pnlMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlDialogButtons;
        private System.Windows.Forms.Button btnCancel;
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
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Label lblStepCaption;
    }
}