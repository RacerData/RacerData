namespace RacerData.WinForms.Controls.Wizard
{
    partial class WizardTest
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
            this.MovePreviousButton = new System.Windows.Forms.Button();
            this.MoveNextButton = new System.Windows.Forms.Button();
            this.SaveAndCloseButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.HelpTextLabel = new System.Windows.Forms.Label();
            this.DescriptionLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.TitleLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.WizardStepPanel = new System.Windows.Forms.Panel();
            this.lstSteps = new System.Windows.Forms.ListBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // MovePreviousButton
            // 
            this.MovePreviousButton.Location = new System.Drawing.Point(172, 352);
            this.MovePreviousButton.Name = "MovePreviousButton";
            this.MovePreviousButton.Size = new System.Drawing.Size(75, 23);
            this.MovePreviousButton.TabIndex = 0;
            this.MovePreviousButton.Text = "<<";
            this.MovePreviousButton.UseVisualStyleBackColor = true;
            this.MovePreviousButton.Click += new System.EventHandler(this.MovePreviousButton_Click);
            // 
            // MoveNextButton
            // 
            this.MoveNextButton.Location = new System.Drawing.Point(713, 352);
            this.MoveNextButton.Name = "MoveNextButton";
            this.MoveNextButton.Size = new System.Drawing.Size(75, 23);
            this.MoveNextButton.TabIndex = 1;
            this.MoveNextButton.Text = ">>";
            this.MoveNextButton.UseVisualStyleBackColor = true;
            this.MoveNextButton.Click += new System.EventHandler(this.MoveNextButton_Click);
            // 
            // SaveAndCloseButton
            // 
            this.SaveAndCloseButton.Location = new System.Drawing.Point(650, 403);
            this.SaveAndCloseButton.Name = "SaveAndCloseButton";
            this.SaveAndCloseButton.Size = new System.Drawing.Size(138, 35);
            this.SaveAndCloseButton.TabIndex = 2;
            this.SaveAndCloseButton.Text = "SaveAndCloseButton";
            this.SaveAndCloseButton.UseVisualStyleBackColor = true;
            this.SaveAndCloseButton.Click += new System.EventHandler(this.SaveAndCloseButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(405, 403);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "help";
            // 
            // HelpTextLabel
            // 
            this.HelpTextLabel.AutoSize = true;
            this.HelpTextLabel.Location = new System.Drawing.Point(408, 420);
            this.HelpTextLabel.Name = "HelpTextLabel";
            this.HelpTextLabel.Size = new System.Drawing.Size(76, 13);
            this.HelpTextLabel.TabIndex = 4;
            this.HelpTextLabel.Text = "HelpTextLabel";
            // 
            // DescriptionLabel
            // 
            this.DescriptionLabel.AutoSize = true;
            this.DescriptionLabel.Location = new System.Drawing.Point(31, 300);
            this.DescriptionLabel.Name = "DescriptionLabel";
            this.DescriptionLabel.Size = new System.Drawing.Size(86, 13);
            this.DescriptionLabel.TabIndex = 6;
            this.DescriptionLabel.Text = "DescriptionLabel";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 283);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "description";
            // 
            // TitleLabel
            // 
            this.TitleLabel.AutoSize = true;
            this.TitleLabel.Location = new System.Drawing.Point(169, 44);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Size = new System.Drawing.Size(53, 13);
            this.TitleLabel.TabIndex = 8;
            this.TitleLabel.Text = "TitleLabel";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(166, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(23, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "title";
            // 
            // WizardStepPanel
            // 
            this.WizardStepPanel.BackColor = System.Drawing.SystemColors.Info;
            this.WizardStepPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.WizardStepPanel.Location = new System.Drawing.Point(169, 82);
            this.WizardStepPanel.Name = "WizardStepPanel";
            this.WizardStepPanel.Size = new System.Drawing.Size(234, 247);
            this.WizardStepPanel.TabIndex = 9;
            // 
            // lstSteps
            // 
            this.lstSteps.FormattingEnabled = true;
            this.lstSteps.Location = new System.Drawing.Point(18, 88);
            this.lstSteps.Name = "lstSteps";
            this.lstSteps.Size = new System.Drawing.Size(125, 173);
            this.lstSteps.TabIndex = 10;
            this.lstSteps.SelectedIndexChanged += new System.EventHandler(this.lstSteps_SelectedIndexChanged);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.flowLayoutPanel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(443, 88);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(308, 241);
            this.flowLayoutPanel1.TabIndex = 11;
            // 
            // WizardTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.lstSteps);
            this.Controls.Add(this.WizardStepPanel);
            this.Controls.Add(this.TitleLabel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.DescriptionLabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.HelpTextLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SaveAndCloseButton);
            this.Controls.Add(this.MoveNextButton);
            this.Controls.Add(this.MovePreviousButton);
            this.Name = "WizardTest";
            this.Text = "WizardTest";
            this.Load += new System.EventHandler(this.WizardTest_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button MovePreviousButton;
        private System.Windows.Forms.Button MoveNextButton;
        private System.Windows.Forms.Button SaveAndCloseButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label HelpTextLabel;
        private System.Windows.Forms.Label DescriptionLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label TitleLabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel WizardStepPanel;
        private System.Windows.Forms.ListBox lstSteps;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    }
}