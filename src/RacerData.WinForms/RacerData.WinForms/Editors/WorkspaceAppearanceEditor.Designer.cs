namespace RacerData.WinForms.Editors
{
    partial class WorkspaceAppearanceEditor
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
            this.workspaceColorEditor = new RacerData.WinForms.Editors.ColorEditor();
            this.pnlEditor = new System.Windows.Forms.Panel();
            this.pnlCaption = new System.Windows.Forms.Panel();
            this.lblCaption = new System.Windows.Forms.Label();
            this.pnlEditor.SuspendLayout();
            this.pnlCaption.SuspendLayout();
            this.SuspendLayout();
            // 
            // workspaceColorEditor
            // 
            this.workspaceColorEditor.Caption = "Back Color";
            this.workspaceColorEditor.Dock = System.Windows.Forms.DockStyle.Top;
            this.workspaceColorEditor.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.workspaceColorEditor.Location = new System.Drawing.Point(5, 5);
            this.workspaceColorEditor.MaximumSize = new System.Drawing.Size(250, 50);
            this.workspaceColorEditor.MinimumSize = new System.Drawing.Size(250, 50);
            this.workspaceColorEditor.Name = "workspaceColorEditor";
            this.workspaceColorEditor.SelectedColor = System.Drawing.Color.White;
            this.workspaceColorEditor.Size = new System.Drawing.Size(250, 50);
            this.workspaceColorEditor.TabIndex = 7;
            // 
            // pnlEditor
            // 
            this.pnlEditor.Controls.Add(this.workspaceColorEditor);
            this.pnlEditor.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlEditor.Location = new System.Drawing.Point(0, 27);
            this.pnlEditor.Name = "pnlEditor";
            this.pnlEditor.Padding = new System.Windows.Forms.Padding(5);
            this.pnlEditor.Size = new System.Drawing.Size(561, 55);
            this.pnlEditor.TabIndex = 8;
            // 
            // pnlCaption
            // 
            this.pnlCaption.Controls.Add(this.lblCaption);
            this.pnlCaption.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCaption.Location = new System.Drawing.Point(0, 0);
            this.pnlCaption.Name = "pnlCaption";
            this.pnlCaption.Size = new System.Drawing.Size(561, 27);
            this.pnlCaption.TabIndex = 13;
            // 
            // lblCaption
            // 
            this.lblCaption.BackColor = System.Drawing.Color.DimGray;
            this.lblCaption.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCaption.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCaption.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCaption.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblCaption.Location = new System.Drawing.Point(0, 0);
            this.lblCaption.Name = "lblCaption";
            this.lblCaption.Size = new System.Drawing.Size(561, 27);
            this.lblCaption.TabIndex = 3;
            this.lblCaption.Text = "Workspace Appearance";
            this.lblCaption.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // WorkspaceAppearanceEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlEditor);
            this.Controls.Add(this.pnlCaption);
            this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "WorkspaceAppearanceEditor";
            this.Size = new System.Drawing.Size(561, 84);
            this.Load += new System.EventHandler(this.WorkspaceAppearanceEditor_Load);
            this.pnlEditor.ResumeLayout(false);
            this.pnlCaption.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private ColorEditor workspaceColorEditor;
        private System.Windows.Forms.Panel pnlEditor;
        private System.Windows.Forms.Panel pnlCaption;
        private System.Windows.Forms.Label lblCaption;
    }
}
