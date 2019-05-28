namespace RacerData.WinForms.Themes.Controls
{
    partial class ColorTableAppearanceEditor
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
            RacerData.WinForms.Themes.Models.SimpleColorTable simpleColorTable1 = new RacerData.WinForms.Themes.Models.SimpleColorTable();
            this.pnlCaption = new System.Windows.Forms.Panel();
            this.lblCaption = new System.Windows.Forms.Label();
            this.colorTableEditor = new RacerData.Themes.UI.Controls.ColorTableEditor();
            this.pnlCaption.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlCaption
            // 
            this.pnlCaption.Controls.Add(this.lblCaption);
            this.pnlCaption.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCaption.Location = new System.Drawing.Point(0, 0);
            this.pnlCaption.Name = "pnlCaption";
            this.pnlCaption.Size = new System.Drawing.Size(736, 27);
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
            this.lblCaption.Size = new System.Drawing.Size(736, 27);
            this.lblCaption.TabIndex = 3;
            this.lblCaption.Text = "Menu / Tools Strip / Status Strip Appearances";
            this.lblCaption.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // colorTableEditor
            // 
            simpleColorTable1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            simpleColorTable1.ButtonClickBackColor = System.Drawing.Color.Empty;
            simpleColorTable1.CheckBoxBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(215)))), ((int)(((byte)(243)))));
            simpleColorTable1.CheckedBorderColor = System.Drawing.SystemColors.Highlight;
            simpleColorTable1.CheckedButtonBackColor = System.Drawing.Color.Empty;
            simpleColorTable1.CheckedButtonBorderColor = System.Drawing.Color.Empty;
            simpleColorTable1.CheckedButtonMouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(188)))), ((int)(((byte)(235)))));
            simpleColorTable1.ForeColor = System.Drawing.Color.Empty;
            simpleColorTable1.MenuBorderColor = System.Drawing.Color.Empty;
            simpleColorTable1.MenuStripMouseOverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            simpleColorTable1.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(215)))), ((int)(((byte)(243)))));
            simpleColorTable1.MouseOverForeColor = System.Drawing.Color.Empty;
            simpleColorTable1.OpenMenuBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(188)))), ((int)(((byte)(235)))));
            simpleColorTable1.SeparatorDarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(189)))));
            simpleColorTable1.SeparatorLightColor = System.Drawing.SystemColors.ButtonHighlight;
            simpleColorTable1.ToolStripMouseOverBorderColor = System.Drawing.Color.Empty;
            simpleColorTable1.UseSystemColors = false;
            this.colorTableEditor.ColorTable = simpleColorTable1;
            this.colorTableEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.colorTableEditor.Location = new System.Drawing.Point(0, 27);
            this.colorTableEditor.Name = "colorTableEditor";
            this.colorTableEditor.Size = new System.Drawing.Size(736, 462);
            this.colorTableEditor.TabIndex = 16;
            // 
            // ColorTableAppearanceEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.colorTableEditor);
            this.Controls.Add(this.pnlCaption);
            this.Name = "ColorTableAppearanceEditor";
            this.Size = new System.Drawing.Size(736, 489);
            this.pnlCaption.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlCaption;
        private System.Windows.Forms.Label lblCaption;
        private RacerData.Themes.UI.Controls.ColorTableEditor colorTableEditor;
    }
}
