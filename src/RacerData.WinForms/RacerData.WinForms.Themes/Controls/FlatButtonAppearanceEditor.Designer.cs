namespace RacerData.WinForms.Themes.Controls
{
    partial class FlatButtonAppearanceEditor
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
            this.mouseOverColorEditor = new RacerData.WinForms.Themes.Controls.ColorEditor();
            this.mouseDownColorEditor = new RacerData.WinForms.Themes.Controls.ColorEditor();
            this.borderColorEditor = new RacerData.WinForms.Themes.Controls.ColorEditor();
            this.numBorderSize = new System.Windows.Forms.NumericUpDown();
            this.lblBorderSize = new System.Windows.Forms.Label();
            this.pnlEditor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numBorderSize)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlEditor
            // 
            this.pnlEditor.Controls.Add(this.mouseOverColorEditor);
            this.pnlEditor.Controls.Add(this.mouseDownColorEditor);
            this.pnlEditor.Controls.Add(this.borderColorEditor);
            this.pnlEditor.Controls.Add(this.numBorderSize);
            this.pnlEditor.Controls.Add(this.lblBorderSize);
            this.pnlEditor.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlEditor.Location = new System.Drawing.Point(0, 0);
            this.pnlEditor.Name = "pnlEditor";
            this.pnlEditor.Padding = new System.Windows.Forms.Padding(5);
            this.pnlEditor.Size = new System.Drawing.Size(629, 91);
            this.pnlEditor.TabIndex = 16;
            // 
            // mouseOverColorEditor
            // 
            this.mouseOverColorEditor.Caption = "MouseOver";
            this.mouseOverColorEditor.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mouseOverColorEditor.Location = new System.Drawing.Point(420, 7);
            this.mouseOverColorEditor.MaximumSize = new System.Drawing.Size(200, 47);
            this.mouseOverColorEditor.MinimumSize = new System.Drawing.Size(200, 47);
            this.mouseOverColorEditor.Name = "mouseOverColorEditor";
            this.mouseOverColorEditor.SelectedColor = System.Drawing.Color.White;
            this.mouseOverColorEditor.Size = new System.Drawing.Size(200, 47);
            this.mouseOverColorEditor.TabIndex = 7;
            // 
            // mouseDownColorEditor
            // 
            this.mouseDownColorEditor.Caption = "Mouse Down";
            this.mouseDownColorEditor.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mouseDownColorEditor.Location = new System.Drawing.Point(214, 7);
            this.mouseDownColorEditor.MaximumSize = new System.Drawing.Size(200, 47);
            this.mouseDownColorEditor.MinimumSize = new System.Drawing.Size(200, 47);
            this.mouseDownColorEditor.Name = "mouseDownColorEditor";
            this.mouseDownColorEditor.SelectedColor = System.Drawing.Color.White;
            this.mouseDownColorEditor.Size = new System.Drawing.Size(200, 47);
            this.mouseDownColorEditor.TabIndex = 6;
            // 
            // borderColorEditor
            // 
            this.borderColorEditor.Caption = "BorderColor";
            this.borderColorEditor.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.borderColorEditor.Location = new System.Drawing.Point(3, 7);
            this.borderColorEditor.MaximumSize = new System.Drawing.Size(200, 47);
            this.borderColorEditor.MinimumSize = new System.Drawing.Size(200, 47);
            this.borderColorEditor.Name = "borderColorEditor";
            this.borderColorEditor.SelectedColor = System.Drawing.Color.White;
            this.borderColorEditor.Size = new System.Drawing.Size(200, 47);
            this.borderColorEditor.TabIndex = 5;
            this.borderColorEditor.Load += new System.EventHandler(this.FlatButtonAppearanceEditor_Load);
            // 
            // numBorderSize
            // 
            this.numBorderSize.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numBorderSize.Location = new System.Drawing.Point(125, 60);
            this.numBorderSize.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numBorderSize.Name = "numBorderSize";
            this.numBorderSize.Size = new System.Drawing.Size(78, 21);
            this.numBorderSize.TabIndex = 4;
            // 
            // lblBorderSize
            // 
            this.lblBorderSize.AutoSize = true;
            this.lblBorderSize.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBorderSize.Location = new System.Drawing.Point(47, 63);
            this.lblBorderSize.Name = "lblBorderSize";
            this.lblBorderSize.Size = new System.Drawing.Size(73, 15);
            this.lblBorderSize.TabIndex = 2;
            this.lblBorderSize.Text = "Border Size";
            // 
            // FlatButtonAppearanceEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlEditor);
            this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FlatButtonAppearanceEditor";
            this.Size = new System.Drawing.Size(629, 90);
            this.pnlEditor.ResumeLayout(false);
            this.pnlEditor.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numBorderSize)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pnlEditor;
        private System.Windows.Forms.NumericUpDown numBorderSize;
        private System.Windows.Forms.Label lblBorderSize;
        private ColorEditor mouseOverColorEditor;
        private ColorEditor mouseDownColorEditor;
        private ColorEditor borderColorEditor;
    }
}
