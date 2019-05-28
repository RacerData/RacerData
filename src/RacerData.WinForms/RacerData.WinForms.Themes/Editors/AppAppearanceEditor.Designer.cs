namespace RacerData.WinForms.Themes.Editors
{
    partial class AppAppearanceEditor
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
            RacerData.WinForms.Themes.Models.SimpleColorTable simpleColorTable2 = new RacerData.WinForms.Themes.Models.SimpleColorTable();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.pnlSubEditors = new System.Windows.Forms.Panel();
            this.pnlDetails = new System.Windows.Forms.Panel();
            this.colorTableAppearanceEditor = new RacerData.WinForms.Themes.Editors.ColorTableAppearanceEditor();
            this.listAppearanceEditor = new RacerData.WinForms.Themes.Editors.ListAppearanceEditor();
            this.dialogAppearanceEditor = new RacerData.WinForms.Themes.Editors.DialogAppearanceEditor();
            this.buttonAppearanceEditor = new RacerData.WinForms.Themes.Editors.ButtonAppearanceEditor();
            this.darkAccentAppearanceEditor = new RacerData.WinForms.Themes.Editors.AppearanceEditor();
            this.lightAccentAppearanceEditor = new RacerData.WinForms.Themes.Editors.AppearanceEditor();
            this.workspaceAppearanceEditor = new RacerData.WinForms.Themes.Editors.WorkspaceAppearanceEditor();
            this.pnlSubEditors.SuspendLayout();
            this.pnlDetails.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(6, 27);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(380, 21);
            this.txtName.TabIndex = 3;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(3, 9);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(40, 15);
            this.lblName.TabIndex = 4;
            this.lblName.Text = "Name";
            // 
            // pnlSubEditors
            // 
            this.pnlSubEditors.AutoScroll = true;
            this.pnlSubEditors.AutoScrollMargin = new System.Drawing.Size(0, 10);
            this.pnlSubEditors.AutoSize = true;
            this.pnlSubEditors.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.pnlSubEditors.Controls.Add(this.colorTableAppearanceEditor);
            this.pnlSubEditors.Controls.Add(this.listAppearanceEditor);
            this.pnlSubEditors.Controls.Add(this.dialogAppearanceEditor);
            this.pnlSubEditors.Controls.Add(this.buttonAppearanceEditor);
            this.pnlSubEditors.Controls.Add(this.darkAccentAppearanceEditor);
            this.pnlSubEditors.Controls.Add(this.lightAccentAppearanceEditor);
            this.pnlSubEditors.Controls.Add(this.workspaceAppearanceEditor);
            this.pnlSubEditors.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSubEditors.Location = new System.Drawing.Point(0, 62);
            this.pnlSubEditors.Name = "pnlSubEditors";
            this.pnlSubEditors.Padding = new System.Windows.Forms.Padding(8, 4, 8, 4);
            this.pnlSubEditors.Size = new System.Drawing.Size(835, 986);
            this.pnlSubEditors.TabIndex = 11;
            // 
            // pnlDetails
            // 
            this.pnlDetails.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pnlDetails.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDetails.Controls.Add(this.txtName);
            this.pnlDetails.Controls.Add(this.lblName);
            this.pnlDetails.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlDetails.Location = new System.Drawing.Point(0, 0);
            this.pnlDetails.Name = "pnlDetails";
            this.pnlDetails.Size = new System.Drawing.Size(835, 62);
            this.pnlDetails.TabIndex = 12;
            // 
            // colorTableAppearanceEditor
            // 
            this.colorTableAppearanceEditor.Caption = "Menu / Tools Strip / Status Strip Appearances";
            this.colorTableAppearanceEditor.CaptionBackColor = System.Drawing.Color.DimGray;
            this.colorTableAppearanceEditor.CaptionForeColor = System.Drawing.Color.WhiteSmoke;
            simpleColorTable2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            simpleColorTable2.ButtonClickBackColor = System.Drawing.Color.Empty;
            simpleColorTable2.CheckBoxBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(215)))), ((int)(((byte)(243)))));
            simpleColorTable2.CheckedBorderColor = System.Drawing.SystemColors.Highlight;
            simpleColorTable2.CheckedButtonBackColor = System.Drawing.Color.Empty;
            simpleColorTable2.CheckedButtonBorderColor = System.Drawing.Color.Empty;
            simpleColorTable2.CheckedButtonMouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(188)))), ((int)(((byte)(235)))));
            simpleColorTable2.ForeColor = System.Drawing.Color.Empty;
            simpleColorTable2.MenuBorderColor = System.Drawing.Color.Empty;
            simpleColorTable2.MenuStripMouseOverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            simpleColorTable2.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(215)))), ((int)(((byte)(243)))));
            simpleColorTable2.MouseOverForeColor = System.Drawing.Color.Empty;
            simpleColorTable2.OpenMenuBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(188)))), ((int)(((byte)(235)))));
            simpleColorTable2.SeparatorDarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(189)))));
            simpleColorTable2.SeparatorLightColor = System.Drawing.SystemColors.ButtonHighlight;
            simpleColorTable2.ToolStripMouseOverBorderColor = System.Drawing.Color.Empty;
            simpleColorTable2.UseSystemColors = false;
            this.colorTableAppearanceEditor.ColorTable = simpleColorTable2;
            this.colorTableAppearanceEditor.Dock = System.Windows.Forms.DockStyle.Top;
            this.colorTableAppearanceEditor.Location = new System.Drawing.Point(8, 898);
            this.colorTableAppearanceEditor.Name = "colorTableAppearanceEditor";
            this.colorTableAppearanceEditor.Size = new System.Drawing.Size(802, 540);
            this.colorTableAppearanceEditor.TabIndex = 10;
            // 
            // listAppearanceEditor
            // 
            this.listAppearanceEditor.BackColor = System.Drawing.Color.White;
            this.listAppearanceEditor.Caption = "List Item Appearance";
            this.listAppearanceEditor.CaptionBackColor = System.Drawing.Color.Gainsboro;
            this.listAppearanceEditor.CaptionForeColor = System.Drawing.Color.Black;
            this.listAppearanceEditor.Dock = System.Windows.Forms.DockStyle.Top;
            this.listAppearanceEditor.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listAppearanceEditor.ListAppearance = null;
            this.listAppearanceEditor.Location = new System.Drawing.Point(8, 770);
            this.listAppearanceEditor.Name = "listAppearanceEditor";
            this.listAppearanceEditor.Size = new System.Drawing.Size(802, 128);
            this.listAppearanceEditor.TabIndex = 8;
            this.listAppearanceEditor.Load += new System.EventHandler(this.dialogAppearanceEditor_Load);
            // 
            // dialogAppearanceEditor
            // 
            this.dialogAppearanceEditor.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dialogAppearanceEditor.Caption = "Buttons";
            this.dialogAppearanceEditor.CaptionBackColor = System.Drawing.Color.Gainsboro;
            this.dialogAppearanceEditor.CaptionForeColor = System.Drawing.Color.Black;
            this.dialogAppearanceEditor.DialogAppearance = null;
            this.dialogAppearanceEditor.Dock = System.Windows.Forms.DockStyle.Top;
            this.dialogAppearanceEditor.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dialogAppearanceEditor.Location = new System.Drawing.Point(8, 457);
            this.dialogAppearanceEditor.Name = "dialogAppearanceEditor";
            this.dialogAppearanceEditor.Size = new System.Drawing.Size(802, 313);
            this.dialogAppearanceEditor.TabIndex = 9;
            // 
            // buttonAppearanceEditor
            // 
            this.buttonAppearanceEditor.BackColor = System.Drawing.SystemColors.Control;
            this.buttonAppearanceEditor.ButtonAppearance = null;
            this.buttonAppearanceEditor.Caption = "Button Appearance";
            this.buttonAppearanceEditor.CaptionBackColor = System.Drawing.Color.Gainsboro;
            this.buttonAppearanceEditor.CaptionForeColor = System.Drawing.Color.Black;
            this.buttonAppearanceEditor.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonAppearanceEditor.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAppearanceEditor.Location = new System.Drawing.Point(8, 270);
            this.buttonAppearanceEditor.Name = "buttonAppearanceEditor";
            this.buttonAppearanceEditor.Size = new System.Drawing.Size(802, 187);
            this.buttonAppearanceEditor.TabIndex = 6;
            // 
            // darkAccentAppearanceEditor
            // 
            this.darkAccentAppearanceEditor.BackColor = System.Drawing.SystemColors.Control;
            this.darkAccentAppearanceEditor.BaseAppearance = null;
            this.darkAccentAppearanceEditor.Caption = "Dark Accents";
            this.darkAccentAppearanceEditor.CaptionBackColor = System.Drawing.Color.Gainsboro;
            this.darkAccentAppearanceEditor.CaptionForeColor = System.Drawing.Color.Black;
            this.darkAccentAppearanceEditor.Dock = System.Windows.Forms.DockStyle.Top;
            this.darkAccentAppearanceEditor.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.darkAccentAppearanceEditor.Location = new System.Drawing.Point(8, 180);
            this.darkAccentAppearanceEditor.Margin = new System.Windows.Forms.Padding(0);
            this.darkAccentAppearanceEditor.Name = "darkAccentAppearanceEditor";
            this.darkAccentAppearanceEditor.Size = new System.Drawing.Size(802, 90);
            this.darkAccentAppearanceEditor.TabIndex = 2;
            // 
            // lightAccentAppearanceEditor
            // 
            this.lightAccentAppearanceEditor.BackColor = System.Drawing.SystemColors.Control;
            this.lightAccentAppearanceEditor.BaseAppearance = null;
            this.lightAccentAppearanceEditor.Caption = "Light Accents";
            this.lightAccentAppearanceEditor.CaptionBackColor = System.Drawing.Color.Gainsboro;
            this.lightAccentAppearanceEditor.CaptionForeColor = System.Drawing.Color.Black;
            this.lightAccentAppearanceEditor.Dock = System.Windows.Forms.DockStyle.Top;
            this.lightAccentAppearanceEditor.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lightAccentAppearanceEditor.Location = new System.Drawing.Point(8, 92);
            this.lightAccentAppearanceEditor.Margin = new System.Windows.Forms.Padding(0);
            this.lightAccentAppearanceEditor.Name = "lightAccentAppearanceEditor";
            this.lightAccentAppearanceEditor.Size = new System.Drawing.Size(802, 88);
            this.lightAccentAppearanceEditor.TabIndex = 1;
            // 
            // workspaceAppearanceEditor
            // 
            this.workspaceAppearanceEditor.BackColor = System.Drawing.SystemColors.Control;
            this.workspaceAppearanceEditor.Caption = "Back Color";
            this.workspaceAppearanceEditor.CaptionBackColor = System.Drawing.Color.Gainsboro;
            this.workspaceAppearanceEditor.CaptionForeColor = System.Drawing.Color.Black;
            this.workspaceAppearanceEditor.Dock = System.Windows.Forms.DockStyle.Top;
            this.workspaceAppearanceEditor.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.workspaceAppearanceEditor.Location = new System.Drawing.Point(8, 4);
            this.workspaceAppearanceEditor.Name = "workspaceAppearanceEditor";
            this.workspaceAppearanceEditor.SelectedColor = System.Drawing.Color.White;
            this.workspaceAppearanceEditor.Size = new System.Drawing.Size(802, 88);
            this.workspaceAppearanceEditor.TabIndex = 0;
            // 
            // AppAppearanceEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlSubEditors);
            this.Controls.Add(this.pnlDetails);
            this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "AppAppearanceEditor";
            this.Size = new System.Drawing.Size(835, 1048);
            this.pnlSubEditors.ResumeLayout(false);
            this.pnlDetails.ResumeLayout(false);
            this.pnlDetails.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Panel pnlSubEditors;
        private System.Windows.Forms.Panel pnlDetails;
        private AppearanceEditor darkAccentAppearanceEditor;
        private AppearanceEditor lightAccentAppearanceEditor;
        private WorkspaceAppearanceEditor workspaceAppearanceEditor;
        private ButtonAppearanceEditor buttonAppearanceEditor;
        private ListAppearanceEditor listAppearanceEditor;
        private DialogAppearanceEditor dialogAppearanceEditor;
        private ColorTableAppearanceEditor colorTableAppearanceEditor;
    }
}
