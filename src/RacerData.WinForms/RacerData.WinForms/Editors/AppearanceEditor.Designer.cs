namespace RacerData.WinForms.Editors
{
    partial class AppearanceEditor
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
            this.pnlEditor = new System.Windows.Forms.Panel();
            this.foreColorEditor = new RacerData.WinForms.Editors.ColorEditor();
            this.backColorEditor = new RacerData.WinForms.Editors.ColorEditor();
            this.fontEditor = new RacerData.WinForms.Editors.FontEditor();
            this.pnlCaption = new System.Windows.Forms.Panel();
            this.lblCaption = new System.Windows.Forms.Label();
            this.pnlEditor.SuspendLayout();
            this.pnlCaption.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlEditor
            // 
            this.pnlEditor.Controls.Add(this.foreColorEditor);
            this.pnlEditor.Controls.Add(this.backColorEditor);
            this.pnlEditor.Controls.Add(this.fontEditor);
            this.pnlEditor.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlEditor.Location = new System.Drawing.Point(0, 27);
            this.pnlEditor.Name = "pnlEditor";
            this.pnlEditor.Padding = new System.Windows.Forms.Padding(4);
            this.pnlEditor.Size = new System.Drawing.Size(781, 61);
            this.pnlEditor.TabIndex = 11;
            // 
            // foreColorEditor
            // 
            this.foreColorEditor.Caption = "Fore Color";
            this.foreColorEditor.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.foreColorEditor.Location = new System.Drawing.Point(3, 6);
            this.foreColorEditor.MaximumSize = new System.Drawing.Size(250, 50);
            this.foreColorEditor.MinimumSize = new System.Drawing.Size(250, 50);
            this.foreColorEditor.Name = "foreColorEditor";
            this.foreColorEditor.SelectedColor = System.Drawing.Color.White;
            this.foreColorEditor.Size = new System.Drawing.Size(250, 50);
            this.foreColorEditor.TabIndex = 7;
            // 
            // backColorEditor
            // 
            this.backColorEditor.Caption = "Back Color";
            this.backColorEditor.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.backColorEditor.Location = new System.Drawing.Point(259, 6);
            this.backColorEditor.MaximumSize = new System.Drawing.Size(250, 50);
            this.backColorEditor.MinimumSize = new System.Drawing.Size(250, 50);
            this.backColorEditor.Name = "backColorEditor";
            this.backColorEditor.SelectedColor = System.Drawing.Color.White;
            this.backColorEditor.Size = new System.Drawing.Size(250, 50);
            this.backColorEditor.TabIndex = 8;
            // 
            // fontEditor
            // 
            this.fontEditor.Caption = "Font";
            this.fontEditor.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fontEditor.Location = new System.Drawing.Point(515, 8);
            this.fontEditor.MaximumSize = new System.Drawing.Size(200, 47);
            this.fontEditor.MinimumSize = new System.Drawing.Size(200, 47);
            this.fontEditor.Name = "fontEditor";
            this.fontEditor.SelectedFont = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fontEditor.Size = new System.Drawing.Size(200, 47);
            this.fontEditor.TabIndex = 9;
            // 
            // pnlCaption
            // 
            this.pnlCaption.Controls.Add(this.lblCaption);
            this.pnlCaption.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCaption.Location = new System.Drawing.Point(0, 0);
            this.pnlCaption.Name = "pnlCaption";
            this.pnlCaption.Size = new System.Drawing.Size(781, 27);
            this.pnlCaption.TabIndex = 15;
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
            this.lblCaption.Size = new System.Drawing.Size(781, 27);
            this.lblCaption.TabIndex = 3;
            this.lblCaption.Text = "Buttons";
            this.lblCaption.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // AppearanceEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlEditor);
            this.Controls.Add(this.pnlCaption);
            this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "AppearanceEditor";
            this.Size = new System.Drawing.Size(781, 87);
            this.Load += new System.EventHandler(this.AppearanceEditor_Load);
            this.pnlEditor.ResumeLayout(false);
            this.pnlCaption.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private ColorEditor foreColorEditor;
        private ColorEditor backColorEditor;
        private FontEditor fontEditor;
        private System.Windows.Forms.Panel pnlEditor;
        private System.Windows.Forms.Panel pnlCaption;
        private System.Windows.Forms.Label lblCaption;
    }
}
