﻿namespace rNascarApp.UI.Controls
{
    partial class VideoView<TModel>
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
            this.webViewCompatible1 = new Microsoft.Toolkit.Forms.UI.Controls.WebViewCompatible();
            this.SuspendLayout();
            // 
            // webViewCompatible1
            // 
            this.webViewCompatible1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webViewCompatible1.Location = new System.Drawing.Point(0, 0);
            this.webViewCompatible1.Name = "webViewCompatible1";
            this.webViewCompatible1.Size = new System.Drawing.Size(477, 334);
            this.webViewCompatible1.TabIndex = 0;
            this.webViewCompatible1.Text = "webViewCompatible1";
            // 
            // StaticView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Controls.Add(this.webViewCompatible1);
            this.Name = "StaticView";
            this.Size = new System.Drawing.Size(477, 334);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Toolkit.Forms.UI.Controls.WebViewCompatible webViewCompatible1;
    }
}