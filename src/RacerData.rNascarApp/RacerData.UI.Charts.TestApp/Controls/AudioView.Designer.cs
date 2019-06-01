namespace rNascarApp.UI.Controls
{
    partial class AudioView<TModel>
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
            this.btnPlayFeed = new System.Windows.Forms.Button();
            this.txtFeed = new System.Windows.Forms.TextBox();
            this.cboChannel = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlSelection.SuspendLayout();
            this.SuspendLayout();
            // 
            // webViewCompatible1
            // 
            this.webViewCompatible1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webViewCompatible1.Location = new System.Drawing.Point(0, 52);
            this.webViewCompatible1.Name = "webViewCompatible1";
            this.webViewCompatible1.Size = new System.Drawing.Size(421, 215);
            this.webViewCompatible1.TabIndex = 0;
            this.webViewCompatible1.Text = "webViewCompatible1";
            // 
            // pnlSelection
            // 
            this.pnlSelection.Controls.Add(this.btnPlayFeed);
            this.pnlSelection.Controls.Add(this.txtFeed);
            this.pnlSelection.Controls.Add(this.cboChannel);
            this.pnlSelection.Controls.Add(this.label1);
            this.pnlSelection.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSelection.Location = new System.Drawing.Point(0, 0);
            this.pnlSelection.Name = "pnlSelection";
            this.pnlSelection.Size = new System.Drawing.Size(421, 52);
            this.pnlSelection.TabIndex = 1;
            // 
            // btnPlayFeed
            // 
            this.btnPlayFeed.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPlayFeed.Location = new System.Drawing.Point(379, 25);
            this.btnPlayFeed.Name = "btnPlayFeed";
            this.btnPlayFeed.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnPlayFeed.Size = new System.Drawing.Size(39, 20);
            this.btnPlayFeed.TabIndex = 3;
            this.btnPlayFeed.Text = ">";
            this.btnPlayFeed.UseVisualStyleBackColor = true;
            this.btnPlayFeed.Click += new System.EventHandler(this.btnPlayFeed_Click);
            // 
            // txtFeed
            // 
            this.txtFeed.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFeed.Location = new System.Drawing.Point(158, 25);
            this.txtFeed.Name = "txtFeed";
            this.txtFeed.Size = new System.Drawing.Size(215, 20);
            this.txtFeed.TabIndex = 2;
            // 
            // cboChannel
            // 
            this.cboChannel.FormattingEnabled = true;
            this.cboChannel.Location = new System.Drawing.Point(6, 25);
            this.cboChannel.Name = "cboChannel";
            this.cboChannel.Size = new System.Drawing.Size(146, 21);
            this.cboChannel.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Channel:";
            // 
            // AudioView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.webViewCompatible1);
            this.Controls.Add(this.pnlSelection);
            this.Name = "AudioView";
            this.Size = new System.Drawing.Size(421, 267);
            this.pnlSelection.ResumeLayout(false);
            this.pnlSelection.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Toolkit.Forms.UI.Controls.WebViewCompatible webViewCompatible1;
        private System.Windows.Forms.Panel pnlSelection;
        private System.Windows.Forms.ComboBox cboChannel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnPlayFeed;
        private System.Windows.Forms.TextBox txtFeed;
    }
}
