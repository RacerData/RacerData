namespace RacerData.Themes.UI.Controls
{
    partial class StackView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StackView));
            this.stackStrip = new System.Windows.Forms.ToolStrip();
            this.mailStackButton = new System.Windows.Forms.ToolStripButton();
            this.calendarStackButton = new System.Windows.Forms.ToolStripButton();
            this.contactsStackButton = new System.Windows.Forms.ToolStripButton();
            this.tasksStackButton = new System.Windows.Forms.ToolStripButton();
            this.stackStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // stackStrip
            // 
            this.stackStrip.CanOverflow = false;
            this.stackStrip.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.stackStrip.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stackStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.stackStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mailStackButton,
            this.calendarStackButton,
            this.contactsStackButton,
            this.tasksStackButton});
            this.stackStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
            this.stackStrip.Location = new System.Drawing.Point(0, 8);
            this.stackStrip.Name = "stackStrip";
            this.stackStrip.Padding = new System.Windows.Forms.Padding(0, 7, 0, 0);
            this.stackStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.stackStrip.Size = new System.Drawing.Size(239, 113);
            this.stackStrip.TabIndex = 0;
            this.stackStrip.Text = "toolStrip1";
            // 
            // mailStackButton
            // 
            this.mailStackButton.Checked = true;
            this.mailStackButton.CheckOnClick = true;
            this.mailStackButton.CheckState = System.Windows.Forms.CheckState.Checked;
            this.mailStackButton.Image = ((System.Drawing.Image)(resources.GetObject("mailStackButton.Image")));
            this.mailStackButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.mailStackButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.mailStackButton.ImageTransparentColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.mailStackButton.Margin = new System.Windows.Forms.Padding(0);
            this.mailStackButton.Name = "mailStackButton";
            this.mailStackButton.Padding = new System.Windows.Forms.Padding(3);
            this.mailStackButton.Size = new System.Drawing.Size(238, 26);
            this.mailStackButton.Text = "Mail";
            this.mailStackButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.mailStackButton.Click += new System.EventHandler(this.stackButton_Click);
            // 
            // calendarStackButton
            // 
            this.calendarStackButton.Checked = true;
            this.calendarStackButton.CheckOnClick = true;
            this.calendarStackButton.CheckState = System.Windows.Forms.CheckState.Checked;
            this.calendarStackButton.Image = ((System.Drawing.Image)(resources.GetObject("calendarStackButton.Image")));
            this.calendarStackButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.calendarStackButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.calendarStackButton.ImageTransparentColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.calendarStackButton.Margin = new System.Windows.Forms.Padding(0);
            this.calendarStackButton.Name = "calendarStackButton";
            this.calendarStackButton.Padding = new System.Windows.Forms.Padding(3);
            this.calendarStackButton.Size = new System.Drawing.Size(540, 26);
            this.calendarStackButton.Text = "Calendar";
            this.calendarStackButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // contactsStackButton
            // 
            this.contactsStackButton.Checked = true;
            this.contactsStackButton.CheckOnClick = true;
            this.contactsStackButton.CheckState = System.Windows.Forms.CheckState.Checked;
            this.contactsStackButton.Image = ((System.Drawing.Image)(resources.GetObject("contactsStackButton.Image")));
            this.contactsStackButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.contactsStackButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.contactsStackButton.ImageTransparentColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.contactsStackButton.Margin = new System.Windows.Forms.Padding(0);
            this.contactsStackButton.Name = "contactsStackButton";
            this.contactsStackButton.Padding = new System.Windows.Forms.Padding(3);
            this.contactsStackButton.Size = new System.Drawing.Size(540, 26);
            this.contactsStackButton.Text = "Contacts";
            this.contactsStackButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.contactsStackButton.Click += new System.EventHandler(this.stackButton_Click);
            // 
            // tasksStackButton
            // 
            this.tasksStackButton.Checked = true;
            this.tasksStackButton.CheckOnClick = true;
            this.tasksStackButton.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tasksStackButton.Image = ((System.Drawing.Image)(resources.GetObject("tasksStackButton.Image")));
            this.tasksStackButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tasksStackButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tasksStackButton.ImageTransparentColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.tasksStackButton.Margin = new System.Windows.Forms.Padding(0);
            this.tasksStackButton.Name = "tasksStackButton";
            this.tasksStackButton.Padding = new System.Windows.Forms.Padding(3);
            this.tasksStackButton.Size = new System.Drawing.Size(540, 26);
            this.tasksStackButton.Text = "Tasks";
            this.tasksStackButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tasksStackButton.Click += new System.EventHandler(this.stackButton_Click);
            // 
            // StackView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.stackStrip);
            this.Name = "StackView";
            this.Size = new System.Drawing.Size(239, 121);
            this.Load += new System.EventHandler(this.StackView_Load);
            this.stackStrip.ResumeLayout(false);
            this.stackStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip stackStrip;
        private System.Windows.Forms.ToolStripButton mailStackButton;
        private System.Windows.Forms.ToolStripButton calendarStackButton;
        private System.Windows.Forms.ToolStripButton contactsStackButton;
        private System.Windows.Forms.ToolStripButton tasksStackButton;
    }
}
