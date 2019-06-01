using rNascarApp.UI.Data;

namespace RacerData.WinForms.Controls
{
    partial class ListViewBase
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlListPanel = new System.Windows.Forms.Panel();
            this.listView1 = new RacerData.WinForms.Controls.ListView();
            this.pnlListPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Location = new System.Drawing.Point(8, 8);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(492, 32);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "label1";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlListPanel
            // 
            this.pnlListPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlListPanel.Controls.Add(this.listView1);
            this.pnlListPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlListPanel.Location = new System.Drawing.Point(8, 40);
            this.pnlListPanel.Name = "pnlListPanel";
            this.pnlListPanel.Size = new System.Drawing.Size(492, 349);
            this.pnlListPanel.TabIndex = 1;
            // 
            // listView1
            // 
            this.listView1.AllowDrag = true;
            this.listView1.AllowResize = true;
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.Location = new System.Drawing.Point(0, 0);
            this.listView1.Name = "listView1";
            this.listView1.Padding = new System.Windows.Forms.Padding(8);
            this.listView1.Size = new System.Drawing.Size(490, 347);
            this.listView1.TabIndex = 0;
            // 
            // ListViewBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlListPanel);
            this.Controls.Add(this.lblTitle);
            this.DoubleBuffered = true;
            this.Name = "ListViewBase";
            this.Padding = new System.Windows.Forms.Padding(8);
            this.Size = new System.Drawing.Size(508, 397);
            this.pnlListPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlListPanel;
        private ListView<DataModel> listView1;
    }
}
