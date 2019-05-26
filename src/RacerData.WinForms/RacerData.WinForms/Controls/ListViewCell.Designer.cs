namespace RacerData.WinForms.Controls
{
    partial class ListViewCell
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
            this.CellLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // CellLabel
            // 
            this.CellLabel.BackColor = System.Drawing.Color.White;
            this.CellLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CellLabel.Location = new System.Drawing.Point(1, 1);
            this.CellLabel.Name = "CellLabel";
            this.CellLabel.Size = new System.Drawing.Size(181, 72);
            this.CellLabel.TabIndex = 0;
            this.CellLabel.Text = "Cell";
            this.CellLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.CellLabel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ListViewCell_MouseDown);
            this.CellLabel.MouseLeave += new System.EventHandler(this.ListViewCell_MouseLeave);
            this.CellLabel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ListViewCell_MouseMove);
            // 
            // ListViewCell
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.CellLabel);
            this.DoubleBuffered = true;
            this.Name = "ListViewCell";
            this.Padding = new System.Windows.Forms.Padding(1);
            this.Size = new System.Drawing.Size(183, 74);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Label CellLabel;
    }
}
