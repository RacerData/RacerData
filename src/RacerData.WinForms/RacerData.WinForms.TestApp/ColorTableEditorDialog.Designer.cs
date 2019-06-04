using RacerData.WinForms.Editors;

namespace RacerData.WinForms
{
    partial class ColorTableEditorDialog
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSaveAndClose = new System.Windows.Forms.Button();
            this.btnCloseCancel = new System.Windows.Forms.Button();
            this.colorTableEditor1 = new ColorTableEditor();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnSaveAndClose);
            this.panel1.Controls.Add(this.btnCloseCancel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 455);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 59);
            this.panel1.TabIndex = 0;
            // 
            // btnSaveAndClose
            // 
            this.btnSaveAndClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveAndClose.BackColor = System.Drawing.SystemColors.Control;
            this.btnSaveAndClose.Location = new System.Drawing.Point(591, 12);
            this.btnSaveAndClose.Name = "btnSaveAndClose";
            this.btnSaveAndClose.Size = new System.Drawing.Size(95, 35);
            this.btnSaveAndClose.TabIndex = 7;
            this.btnSaveAndClose.Text = "Save && Close";
            this.btnSaveAndClose.UseVisualStyleBackColor = false;
            // 
            // btnCloseCancel
            // 
            this.btnCloseCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCloseCancel.BackColor = System.Drawing.SystemColors.Control;
            this.btnCloseCancel.Location = new System.Drawing.Point(692, 12);
            this.btnCloseCancel.Name = "btnCloseCancel";
            this.btnCloseCancel.Size = new System.Drawing.Size(95, 35);
            this.btnCloseCancel.TabIndex = 6;
            this.btnCloseCancel.Text = "Cancel";
            this.btnCloseCancel.UseVisualStyleBackColor = false;
            // 
            // colorTableEditor1
            // 
            this.colorTableEditor1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.colorTableEditor1.Location = new System.Drawing.Point(0, 0);
            this.colorTableEditor1.Name = "colorTableEditor1";
            this.colorTableEditor1.Size = new System.Drawing.Size(800, 455);
            this.colorTableEditor1.TabIndex = 1;
            // 
            // ColorTableEditorDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 514);
            this.Controls.Add(this.colorTableEditor1);
            this.Controls.Add(this.panel1);
            this.Name = "ColorTableEditorDialog";
            this.Text = "Color Table Editor";
            this.Load += new System.EventHandler(this.ColorTableEditorDialog_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnSaveAndClose;
        private System.Windows.Forms.Button btnCloseCancel;
        private ColorTableEditor colorTableEditor1;
    }
}