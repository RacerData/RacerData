namespace RacerData.WinForms.Dialogs
{
    partial class EditorBase
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
            this.dialogButtons1 = new RacerData.WinForms.Controls.DialogButtons();
            this.SuspendLayout();
            // 
            // dialogButtons1
            // 
            this.dialogButtons1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.dialogButtons1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dialogButtons1.ButtonTypes = ((RacerData.WinForms.Models.ButtonTypes)((((((RacerData.WinForms.Models.ButtonTypes.Save | RacerData.WinForms.Models.ButtonTypes.Edit_Save) 
            | RacerData.WinForms.Models.ButtonTypes.Delete) 
            | RacerData.WinForms.Models.ButtonTypes.Copy) 
            | RacerData.WinForms.Models.ButtonTypes.New) 
            | RacerData.WinForms.Models.ButtonTypes.Close_Cancel)));
            this.dialogButtons1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dialogButtons1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dialogButtons1.FormState = RacerData.WinForms.Models.FormStates.Loading;
            this.dialogButtons1.Location = new System.Drawing.Point(0, 385);
            this.dialogButtons1.MinimumSize = new System.Drawing.Size(200, 40);
            this.dialogButtons1.Name = "dialogButtons1";
            this.dialogButtons1.Padding = new System.Windows.Forms.Padding(8);
            this.dialogButtons1.RaiseFormStateEvents = true;
            this.dialogButtons1.Size = new System.Drawing.Size(800, 65);
            this.dialogButtons1.TabIndex = 0;
            this.dialogButtons1.DialogResultClicked += new System.EventHandler<RacerData.WinForms.Events.DialogResultEventArgs>(this.DialogResultClicked);
            this.dialogButtons1.FormStateChanging += new System.EventHandler<RacerData.WinForms.Events.FormStateChangingEventArgs>(this.DialogStateChanging);
            this.dialogButtons1.FormStateChanged += new System.EventHandler<RacerData.WinForms.Events.FormStateChangedEventArgs>(this.DialogStateChanged);
            // 
            // EditorBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dialogButtons1);
            this.Name = "EditorBase";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "EditorBase";
            this.Load += new System.EventHandler(this.EditorBase_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.DialogButtons dialogButtons1;
    }
}