namespace RacerData.WinForms.Themes.Editors
{
    partial class ListAppearanceEditor
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
            this.baseAppearanceEditor1 = new RacerData.WinForms.Themes.Editors.AppearanceEditor();
            this.pnlEditor = new System.Windows.Forms.Panel();
            this.pnlCaption = new System.Windows.Forms.Panel();
            this.lblCaption = new System.Windows.Forms.Label();
            this.pnlEditor.SuspendLayout();
            this.pnlCaption.SuspendLayout();
            this.SuspendLayout();
            // 
            // baseAppearanceEditor1
            // 
            this.baseAppearanceEditor1.BaseAppearance = null;
            this.baseAppearanceEditor1.Caption = "List Item Appearance";
            this.baseAppearanceEditor1.CaptionBackColor = System.Drawing.Color.Silver;
            this.baseAppearanceEditor1.CaptionForeColor = System.Drawing.Color.Black;
            this.baseAppearanceEditor1.Dock = System.Windows.Forms.DockStyle.Top;
            this.baseAppearanceEditor1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.baseAppearanceEditor1.Location = new System.Drawing.Point(5, 5);
            this.baseAppearanceEditor1.Margin = new System.Windows.Forms.Padding(0);
            this.baseAppearanceEditor1.Name = "baseAppearanceEditor1";
            this.baseAppearanceEditor1.Size = new System.Drawing.Size(775, 90);
            this.baseAppearanceEditor1.TabIndex = 6;
            // 
            // pnlEditor
            // 
            this.pnlEditor.Controls.Add(this.baseAppearanceEditor1);
            this.pnlEditor.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlEditor.Location = new System.Drawing.Point(0, 27);
            this.pnlEditor.Name = "pnlEditor";
            this.pnlEditor.Padding = new System.Windows.Forms.Padding(5);
            this.pnlEditor.Size = new System.Drawing.Size(785, 90);
            this.pnlEditor.TabIndex = 7;
            // 
            // pnlCaption
            // 
            this.pnlCaption.Controls.Add(this.lblCaption);
            this.pnlCaption.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCaption.Location = new System.Drawing.Point(0, 0);
            this.pnlCaption.Name = "pnlCaption";
            this.pnlCaption.Size = new System.Drawing.Size(785, 27);
            this.pnlCaption.TabIndex = 12;
            // 
            // lblCaption
            // 
            this.lblCaption.BackColor = System.Drawing.Color.DimGray;
            this.lblCaption.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCaption.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCaption.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCaption.ForeColor = System.Drawing.Color.White;
            this.lblCaption.Location = new System.Drawing.Point(0, 0);
            this.lblCaption.Name = "lblCaption";
            this.lblCaption.Size = new System.Drawing.Size(785, 27);
            this.lblCaption.TabIndex = 3;
            this.lblCaption.Text = "List Appearance";
            this.lblCaption.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ListAppearanceEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlEditor);
            this.Controls.Add(this.pnlCaption);
            this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ListAppearanceEditor";
            this.Size = new System.Drawing.Size(785, 117);
            this.Load += new System.EventHandler(this.ListAppearanceEditor_Load);
            this.pnlEditor.ResumeLayout(false);
            this.pnlCaption.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private AppearanceEditor baseAppearanceEditor1;
        private System.Windows.Forms.Panel pnlEditor;
        private System.Windows.Forms.Panel pnlCaption;
        private System.Windows.Forms.Label lblCaption;
    }
}
