namespace RacerData.WinForms.Themes.Editors
{
    partial class DialogAppearanceEditor
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
            this.dialogListAppearanceEditor = new RacerData.WinForms.Themes.Editors.AppearanceEditor();
            this.pnlEditor = new System.Windows.Forms.Panel();
            this.dialogButtonAppearanceEditor = new RacerData.WinForms.Themes.Editors.ButtonAppearanceEditor();
            this.pnlCaption = new System.Windows.Forms.Panel();
            this.lblCaption = new System.Windows.Forms.Label();
            this.pnlEditor.SuspendLayout();
            this.pnlCaption.SuspendLayout();
            this.SuspendLayout();
            // 
            // dialogListAppearanceEditor
            // 
            this.dialogListAppearanceEditor.BaseAppearance = null;
            this.dialogListAppearanceEditor.Caption = "Dialog List Item Appearance";
            this.dialogListAppearanceEditor.CaptionBackColor = System.Drawing.Color.Silver;
            this.dialogListAppearanceEditor.CaptionForeColor = System.Drawing.Color.Black;
            this.dialogListAppearanceEditor.Dock = System.Windows.Forms.DockStyle.Top;
            this.dialogListAppearanceEditor.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dialogListAppearanceEditor.Location = new System.Drawing.Point(5, 5);
            this.dialogListAppearanceEditor.Margin = new System.Windows.Forms.Padding(0);
            this.dialogListAppearanceEditor.Name = "dialogListAppearanceEditor";
            this.dialogListAppearanceEditor.Size = new System.Drawing.Size(768, 93);
            this.dialogListAppearanceEditor.TabIndex = 1;
            // 
            // pnlEditor
            // 
            this.pnlEditor.Controls.Add(this.dialogButtonAppearanceEditor);
            this.pnlEditor.Controls.Add(this.dialogListAppearanceEditor);
            this.pnlEditor.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlEditor.Location = new System.Drawing.Point(0, 27);
            this.pnlEditor.Name = "pnlEditor";
            this.pnlEditor.Padding = new System.Windows.Forms.Padding(5);
            this.pnlEditor.Size = new System.Drawing.Size(778, 288);
            this.pnlEditor.TabIndex = 5;
            // 
            // dialogButtonAppearanceEditor
            // 
            this.dialogButtonAppearanceEditor.BackColor = System.Drawing.Color.White;
            this.dialogButtonAppearanceEditor.ButtonAppearance = null;
            this.dialogButtonAppearanceEditor.Caption = "Dialog Buttons";
            this.dialogButtonAppearanceEditor.CaptionBackColor = System.Drawing.Color.Silver;
            this.dialogButtonAppearanceEditor.CaptionForeColor = System.Drawing.Color.Black;
            this.dialogButtonAppearanceEditor.Dock = System.Windows.Forms.DockStyle.Top;
            this.dialogButtonAppearanceEditor.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dialogButtonAppearanceEditor.Location = new System.Drawing.Point(5, 98);
            this.dialogButtonAppearanceEditor.MaximumSize = new System.Drawing.Size(765, 187);
            this.dialogButtonAppearanceEditor.MinimumSize = new System.Drawing.Size(765, 187);
            this.dialogButtonAppearanceEditor.Name = "dialogButtonAppearanceEditor";
            this.dialogButtonAppearanceEditor.Size = new System.Drawing.Size(765, 187);
            this.dialogButtonAppearanceEditor.TabIndex = 2;
            // 
            // pnlCaption
            // 
            this.pnlCaption.Controls.Add(this.lblCaption);
            this.pnlCaption.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCaption.Location = new System.Drawing.Point(0, 0);
            this.pnlCaption.Name = "pnlCaption";
            this.pnlCaption.Size = new System.Drawing.Size(778, 27);
            this.pnlCaption.TabIndex = 11;
            // 
            // lblCaption
            // 
            this.lblCaption.BackColor = System.Drawing.Color.DimGray;
            this.lblCaption.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCaption.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCaption.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCaption.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblCaption.Location = new System.Drawing.Point(0, 0);
            this.lblCaption.Margin = new System.Windows.Forms.Padding(3);
            this.lblCaption.Name = "lblCaption";
            this.lblCaption.Size = new System.Drawing.Size(778, 27);
            this.lblCaption.TabIndex = 3;
            this.lblCaption.Text = "Dialog Appearance";
            this.lblCaption.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // DialogAppearanceEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Controls.Add(this.pnlEditor);
            this.Controls.Add(this.pnlCaption);
            this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "DialogAppearanceEditor";
            this.Size = new System.Drawing.Size(778, 313);
            this.Load += new System.EventHandler(this.DialogAppearanceEditor_Load);
            this.pnlEditor.ResumeLayout(false);
            this.pnlCaption.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private AppearanceEditor dialogListAppearanceEditor;
        private System.Windows.Forms.Panel pnlEditor;
        private System.Windows.Forms.Panel pnlCaption;
        private System.Windows.Forms.Label lblCaption;
        private ButtonAppearanceEditor dialogButtonAppearanceEditor;
    }
}
