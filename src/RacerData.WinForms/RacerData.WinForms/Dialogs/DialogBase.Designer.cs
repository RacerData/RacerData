namespace RacerData.WinForms.Dialogs
{
    partial class DialogBase
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
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.dialogButtons1 = new RacerData.WinForms.Controls.DialogButtons();
            this.SuspendLayout();
            // 
            // dialogButtons1
            // 
            this.dialogButtons1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.dialogButtons1.ButtonTypes = RacerData.WinForms.Models.ButtonTypes.Blank;
            this.dialogButtons1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dialogButtons1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dialogButtons1.FormState = RacerData.WinForms.Models.FormStates.Loading;
            this.dialogButtons1.Location = new System.Drawing.Point(0, 319);
            this.dialogButtons1.MinimumSize = new System.Drawing.Size(200, 40);
            this.dialogButtons1.Name = "dialogButtons1";
            this.dialogButtons1.Padding = new System.Windows.Forms.Padding(8);
            this.dialogButtons1.RaiseFormStateEvents = true;
            this.dialogButtons1.Size = new System.Drawing.Size(666, 40);
            this.dialogButtons1.TabIndex = 0;
            // 
            // DialogBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(666, 359);
            this.Controls.Add(this.dialogButtons1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "DialogBase";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "DialogBase";
            this.Load += new System.EventHandler(this.DialogBase_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolTip toolTip1;
        private Controls.DialogButtons dialogButtons1;
    }
}