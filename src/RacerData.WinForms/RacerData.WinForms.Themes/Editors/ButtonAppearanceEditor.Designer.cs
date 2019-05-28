using RacerData.WinForms.Controls;

namespace RacerData.WinForms.Themes.Editors
{
    partial class ButtonAppearanceEditor
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
            this.pnlCaption = new System.Windows.Forms.Panel();
            this.lblCaption = new System.Windows.Forms.Label();
            this.pnlEditor = new System.Windows.Forms.Panel();
            this.mouseOverColorEditor = new RacerData.WinForms.Themes.Editors.ColorEditor();
            this.mouseDownColorEditor = new RacerData.WinForms.Themes.Editors.ColorEditor();
            this.borderColorEditor = new RacerData.WinForms.Themes.Editors.ColorEditor();
            this.numBorderSize = new System.Windows.Forms.NumericUpDown();
            this.lblBorderSize = new System.Windows.Forms.Label();
            this.foreColorEditor = new RacerData.WinForms.Themes.Editors.ColorEditor();
            this.backColorEditor = new RacerData.WinForms.Themes.Editors.ColorEditor();
            this.fontEditor = new RacerData.WinForms.Themes.Editors.FontEditor();
            this.label1 = new System.Windows.Forms.Label();
            this.textAlignEditor = new RacerData.WinForms.Controls.ContentAlignmentSelector();
            this.cboButtonStyle = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pnlCaption.SuspendLayout();
            this.pnlEditor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numBorderSize)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlCaption
            // 
            this.pnlCaption.Controls.Add(this.lblCaption);
            this.pnlCaption.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCaption.Location = new System.Drawing.Point(0, 0);
            this.pnlCaption.Name = "pnlCaption";
            this.pnlCaption.Size = new System.Drawing.Size(802, 27);
            this.pnlCaption.TabIndex = 14;
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
            this.lblCaption.Size = new System.Drawing.Size(802, 27);
            this.lblCaption.TabIndex = 3;
            this.lblCaption.Text = "Buttons";
            this.lblCaption.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlEditor
            // 
            this.pnlEditor.Controls.Add(this.mouseOverColorEditor);
            this.pnlEditor.Controls.Add(this.mouseDownColorEditor);
            this.pnlEditor.Controls.Add(this.borderColorEditor);
            this.pnlEditor.Controls.Add(this.numBorderSize);
            this.pnlEditor.Controls.Add(this.lblBorderSize);
            this.pnlEditor.Controls.Add(this.foreColorEditor);
            this.pnlEditor.Controls.Add(this.backColorEditor);
            this.pnlEditor.Controls.Add(this.fontEditor);
            this.pnlEditor.Controls.Add(this.label1);
            this.pnlEditor.Controls.Add(this.textAlignEditor);
            this.pnlEditor.Controls.Add(this.cboButtonStyle);
            this.pnlEditor.Controls.Add(this.label2);
            this.pnlEditor.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlEditor.Location = new System.Drawing.Point(0, 27);
            this.pnlEditor.Name = "pnlEditor";
            this.pnlEditor.Padding = new System.Windows.Forms.Padding(4);
            this.pnlEditor.Size = new System.Drawing.Size(802, 159);
            this.pnlEditor.TabIndex = 15;
            // 
            // mouseOverColorEditor
            // 
            this.mouseOverColorEditor.Caption = "Mouse Over Back Color";
            this.mouseOverColorEditor.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mouseOverColorEditor.Location = new System.Drawing.Point(515, 99);
            this.mouseOverColorEditor.MaximumSize = new System.Drawing.Size(250, 50);
            this.mouseOverColorEditor.MinimumSize = new System.Drawing.Size(250, 50);
            this.mouseOverColorEditor.Name = "mouseOverColorEditor";
            this.mouseOverColorEditor.SelectedColor = System.Drawing.Color.White;
            this.mouseOverColorEditor.Size = new System.Drawing.Size(250, 50);
            this.mouseOverColorEditor.TabIndex = 29;
            // 
            // mouseDownColorEditor
            // 
            this.mouseDownColorEditor.Caption = "Mouse Down Back Color";
            this.mouseDownColorEditor.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mouseDownColorEditor.Location = new System.Drawing.Point(259, 99);
            this.mouseDownColorEditor.MaximumSize = new System.Drawing.Size(250, 50);
            this.mouseDownColorEditor.MinimumSize = new System.Drawing.Size(250, 50);
            this.mouseDownColorEditor.Name = "mouseDownColorEditor";
            this.mouseDownColorEditor.SelectedColor = System.Drawing.Color.White;
            this.mouseDownColorEditor.Size = new System.Drawing.Size(250, 50);
            this.mouseDownColorEditor.TabIndex = 28;
            // 
            // borderColorEditor
            // 
            this.borderColorEditor.Caption = "Border Color";
            this.borderColorEditor.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.borderColorEditor.Location = new System.Drawing.Point(3, 99);
            this.borderColorEditor.MaximumSize = new System.Drawing.Size(250, 50);
            this.borderColorEditor.MinimumSize = new System.Drawing.Size(250, 50);
            this.borderColorEditor.Name = "borderColorEditor";
            this.borderColorEditor.SelectedColor = System.Drawing.Color.White;
            this.borderColorEditor.Size = new System.Drawing.Size(250, 50);
            this.borderColorEditor.TabIndex = 27;
            // 
            // numBorderSize
            // 
            this.numBorderSize.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numBorderSize.Location = new System.Drawing.Point(637, 69);
            this.numBorderSize.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numBorderSize.Name = "numBorderSize";
            this.numBorderSize.Size = new System.Drawing.Size(78, 21);
            this.numBorderSize.TabIndex = 26;
            // 
            // lblBorderSize
            // 
            this.lblBorderSize.AutoSize = true;
            this.lblBorderSize.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBorderSize.Location = new System.Drawing.Point(518, 72);
            this.lblBorderSize.Name = "lblBorderSize";
            this.lblBorderSize.Size = new System.Drawing.Size(73, 15);
            this.lblBorderSize.TabIndex = 25;
            this.lblBorderSize.Text = "Border Size";
            // 
            // foreColorEditor
            // 
            this.foreColorEditor.Caption = "ForeColor";
            this.foreColorEditor.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.foreColorEditor.Location = new System.Drawing.Point(3, 7);
            this.foreColorEditor.MaximumSize = new System.Drawing.Size(250, 50);
            this.foreColorEditor.MinimumSize = new System.Drawing.Size(250, 50);
            this.foreColorEditor.Name = "foreColorEditor";
            this.foreColorEditor.SelectedColor = System.Drawing.Color.White;
            this.foreColorEditor.Size = new System.Drawing.Size(250, 50);
            this.foreColorEditor.TabIndex = 22;
            // 
            // backColorEditor
            // 
            this.backColorEditor.Caption = "BackColor";
            this.backColorEditor.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.backColorEditor.Location = new System.Drawing.Point(259, 7);
            this.backColorEditor.MaximumSize = new System.Drawing.Size(250, 50);
            this.backColorEditor.MinimumSize = new System.Drawing.Size(250, 50);
            this.backColorEditor.Name = "backColorEditor";
            this.backColorEditor.SelectedColor = System.Drawing.Color.White;
            this.backColorEditor.Size = new System.Drawing.Size(250, 50);
            this.backColorEditor.TabIndex = 23;
            // 
            // fontEditor
            // 
            this.fontEditor.Caption = "Font";
            this.fontEditor.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fontEditor.Location = new System.Drawing.Point(515, 9);
            this.fontEditor.MaximumSize = new System.Drawing.Size(200, 47);
            this.fontEditor.MinimumSize = new System.Drawing.Size(200, 47);
            this.fontEditor.Name = "fontEditor";
            this.fontEditor.SelectedFont = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fontEditor.Size = new System.Drawing.Size(200, 47);
            this.fontEditor.TabIndex = 24;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(256, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 15);
            this.label1.TabIndex = 19;
            this.label1.Text = "Button Style";
            // 
            // textAlignEditor
            // 
            this.textAlignEditor.Alignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.textAlignEditor.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.textAlignEditor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textAlignEditor.Location = new System.Drawing.Point(109, 67);
            this.textAlignEditor.Name = "textAlignEditor";
            this.textAlignEditor.Padding = new System.Windows.Forms.Padding(1);
            this.textAlignEditor.Size = new System.Drawing.Size(92, 25);
            this.textAlignEditor.TabIndex = 21;
            // 
            // cboButtonStyle
            // 
            this.cboButtonStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboButtonStyle.FormattingEnabled = true;
            this.cboButtonStyle.Location = new System.Drawing.Point(363, 68);
            this.cboButtonStyle.Name = "cboButtonStyle";
            this.cboButtonStyle.Size = new System.Drawing.Size(92, 23);
            this.cboButtonStyle.TabIndex = 18;
            this.cboButtonStyle.SelectedIndexChanged += new System.EventHandler(this.cboButtonStyle_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 15);
            this.label2.TabIndex = 20;
            this.label2.Text = "Text Alignment";
            // 
            // ButtonAppearanceEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.pnlEditor);
            this.Controls.Add(this.pnlCaption);
            this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ButtonAppearanceEditor";
            this.Size = new System.Drawing.Size(802, 187);
            this.Load += new System.EventHandler(this.ButtonAppearanceEditor_Load);
            this.pnlCaption.ResumeLayout(false);
            this.pnlEditor.ResumeLayout(false);
            this.pnlEditor.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numBorderSize)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pnlCaption;
        private System.Windows.Forms.Label lblCaption;
        private System.Windows.Forms.Panel pnlEditor;
        private ColorEditor mouseOverColorEditor;
        private ColorEditor mouseDownColorEditor;
        private ColorEditor borderColorEditor;
        private System.Windows.Forms.NumericUpDown numBorderSize;
        private System.Windows.Forms.Label lblBorderSize;
        private ColorEditor foreColorEditor;
        private ColorEditor backColorEditor;
        private FontEditor fontEditor;
        private System.Windows.Forms.Label label1;
        private ContentAlignmentSelector textAlignEditor;
        private System.Windows.Forms.ComboBox cboButtonStyle;
        private System.Windows.Forms.Label label2;
    }
}
