namespace RacerData.WinForms.Dialogs
{
    partial class ExceptionDialog
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtStackTrace = new System.Windows.Forms.TextBox();
            this.dialogButtons1 = new RacerData.WinForms.Controls.DialogButtons();
            this.btnCopy = new System.Windows.Forms.Button();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 133);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "Stack Trace:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtStackTrace
            // 
            this.txtStackTrace.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtStackTrace.Location = new System.Drawing.Point(12, 151);
            this.txtStackTrace.Multiline = true;
            this.txtStackTrace.Name = "txtStackTrace";
            this.txtStackTrace.ReadOnly = true;
            this.txtStackTrace.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtStackTrace.Size = new System.Drawing.Size(698, 182);
            this.txtStackTrace.TabIndex = 6;
            // 
            // dialogButtons1
            // 
            this.dialogButtons1.Appearance = null;
            this.dialogButtons1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.dialogButtons1.ButtonTypes = RacerData.WinForms.Models.ButtonTypes.Blank;
            this.dialogButtons1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dialogButtons1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dialogButtons1.FormState = RacerData.WinForms.Models.FormStates.Loading;
            this.dialogButtons1.Location = new System.Drawing.Point(0, 380);
            this.dialogButtons1.MinimumSize = new System.Drawing.Size(200, 40);
            this.dialogButtons1.Name = "dialogButtons1";
            this.dialogButtons1.Padding = new System.Windows.Forms.Padding(8);
            this.dialogButtons1.RaiseFormStateEvents = true;
            this.dialogButtons1.Size = new System.Drawing.Size(722, 42);
            this.dialogButtons1.TabIndex = 0;
            this.dialogButtons1.DialogResultClicked += new System.EventHandler<RacerData.WinForms.Events.DialogResultEventArgs>(this.dialogButtons1_DialogResultClicked);
            // 
            // btnCopy
            // 
            this.btnCopy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCopy.Location = new System.Drawing.Point(530, 339);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(181, 35);
            this.btnCopy.TabIndex = 7;
            this.btnCopy.Text = "Copy to Clipboard";
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // txtMessage
            // 
            this.txtMessage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMessage.Location = new System.Drawing.Point(13, 27);
            this.txtMessage.Multiline = true;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.ReadOnly = true;
            this.txtMessage.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtMessage.Size = new System.Drawing.Size(696, 103);
            this.txtMessage.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(10, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 15);
            this.label2.TabIndex = 9;
            this.label2.Text = "Message:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ExceptionDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(722, 422);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.btnCopy);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dialogButtons1);
            this.Controls.Add(this.txtStackTrace);
            this.Name = "ExceptionDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Exception";
            this.Load += new System.EventHandler(this.ExceptionDialog_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controls.DialogButtons dialogButtons1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtStackTrace;
        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.Label label2;
    }
}