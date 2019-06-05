namespace RacerData.WinForms.Controls
{
    partial class AudioView
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
            this.pnlSelection = new System.Windows.Forms.Panel();
            this.cboSeries = new System.Windows.Forms.ComboBox();
            this.lblSeries = new System.Windows.Forms.Label();
            this.cboChannel = new System.Windows.Forms.ComboBox();
            this.lblChannel = new System.Windows.Forms.Label();
            this.pnlSelection.SuspendLayout();
            this.SuspendLayout();
            // 
            // webViewCompatible1
            // 
            this.webViewCompatible1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webViewCompatible1.Location = new System.Drawing.Point(0, 52);
            this.webViewCompatible1.Name = "webViewCompatible1";
            this.webViewCompatible1.Size = new System.Drawing.Size(626, 215);
            this.webViewCompatible1.TabIndex = 0;
            this.webViewCompatible1.Text = "webViewCompatible1";
            // 
            // pnlSelection
            // 
            this.pnlSelection.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pnlSelection.Controls.Add(this.cboSeries);
            this.pnlSelection.Controls.Add(this.lblSeries);
            this.pnlSelection.Controls.Add(this.cboChannel);
            this.pnlSelection.Controls.Add(this.lblChannel);
            this.pnlSelection.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSelection.Location = new System.Drawing.Point(0, 0);
            this.pnlSelection.Name = "pnlSelection";
            this.pnlSelection.Size = new System.Drawing.Size(626, 52);
            this.pnlSelection.TabIndex = 1;
            // 
            // cboSeries
            // 
            this.cboSeries.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboSeries.FormattingEnabled = true;
            this.cboSeries.Location = new System.Drawing.Point(6, 25);
            this.cboSeries.Name = "cboSeries";
            this.cboSeries.Size = new System.Drawing.Size(131, 23);
            this.cboSeries.TabIndex = 3;
            this.cboSeries.SelectedIndexChanged += new System.EventHandler(this.cboSeries_SelectedIndexChanged);
            // 
            // lblSeries
            // 
            this.lblSeries.AutoSize = true;
            this.lblSeries.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSeries.Location = new System.Drawing.Point(3, 9);
            this.lblSeries.Name = "lblSeries";
            this.lblSeries.Size = new System.Drawing.Size(47, 15);
            this.lblSeries.TabIndex = 2;
            this.lblSeries.Text = "Series:";
            // 
            // cboChannel
            // 
            this.cboChannel.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboChannel.FormattingEnabled = true;
            this.cboChannel.Location = new System.Drawing.Point(143, 25);
            this.cboChannel.Name = "cboChannel";
            this.cboChannel.Size = new System.Drawing.Size(162, 23);
            this.cboChannel.TabIndex = 1;
            // 
            // lblChannel
            // 
            this.lblChannel.AutoSize = true;
            this.lblChannel.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChannel.Location = new System.Drawing.Point(140, 9);
            this.lblChannel.Name = "lblChannel";
            this.lblChannel.Size = new System.Drawing.Size(56, 15);
            this.lblChannel.TabIndex = 0;
            this.lblChannel.Text = "Channel:";
            // 
            // AudioView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.webViewCompatible1);
            this.Controls.Add(this.pnlSelection);
            this.Name = "AudioView";
            this.Size = new System.Drawing.Size(626, 267);
            this.Load += new System.EventHandler(this.AudioView_Load);
            this.pnlSelection.ResumeLayout(false);
            this.pnlSelection.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Toolkit.Forms.UI.Controls.WebViewCompatible webViewCompatible1;
        private System.Windows.Forms.Panel pnlSelection;
        private System.Windows.Forms.ComboBox cboChannel;
        private System.Windows.Forms.Label lblChannel;
        private System.Windows.Forms.ComboBox cboSeries;
        private System.Windows.Forms.Label lblSeries;
    }
}
