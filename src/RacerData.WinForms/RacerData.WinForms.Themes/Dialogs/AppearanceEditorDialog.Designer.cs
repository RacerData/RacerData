namespace RacerData.WinForms.Dialogs
{
    partial class AppearanceEditorDialog
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlSelection = new System.Windows.Forms.Panel();
            this.lblAppearances = new System.Windows.Forms.Label();
            this.cboAppearances = new System.Windows.Forms.ComboBox();
            this.pnlDialogButtons = new System.Windows.Forms.Panel();
            this.btnSaveAndClose = new System.Windows.Forms.Button();
            this.btnCloseCancel = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnCopy = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnEditSave = new System.Windows.Forms.Button();
            this.appAppearanceEditor1 = new RacerData.WinForms.Themes.Editors.AppAppearanceEditor();
            this.pnlSelection.SuspendLayout();
            this.pnlDialogButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlSelection
            // 
            this.pnlSelection.BackColor = System.Drawing.SystemColors.Control;
            this.pnlSelection.Controls.Add(this.lblAppearances);
            this.pnlSelection.Controls.Add(this.cboAppearances);
            this.pnlSelection.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSelection.Location = new System.Drawing.Point(0, 0);
            this.pnlSelection.Name = "pnlSelection";
            this.pnlSelection.Size = new System.Drawing.Size(915, 70);
            this.pnlSelection.TabIndex = 3;
            // 
            // lblAppearances
            // 
            this.lblAppearances.AutoSize = true;
            this.lblAppearances.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAppearances.Location = new System.Drawing.Point(7, 10);
            this.lblAppearances.Name = "lblAppearances";
            this.lblAppearances.Size = new System.Drawing.Size(83, 15);
            this.lblAppearances.TabIndex = 1;
            this.lblAppearances.Text = "Appearances";
            // 
            // cboAppearances
            // 
            this.cboAppearances.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAppearances.FormattingEnabled = true;
            this.cboAppearances.Location = new System.Drawing.Point(9, 28);
            this.cboAppearances.Name = "cboAppearances";
            this.cboAppearances.Size = new System.Drawing.Size(379, 23);
            this.cboAppearances.TabIndex = 0;
            this.cboAppearances.SelectedIndexChanged += new System.EventHandler(this.cboAppearances_SelectedIndexChanged);
            // 
            // pnlDialogButtons
            // 
            this.pnlDialogButtons.BackColor = System.Drawing.Color.Gainsboro;
            this.pnlDialogButtons.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDialogButtons.Controls.Add(this.btnSaveAndClose);
            this.pnlDialogButtons.Controls.Add(this.btnCloseCancel);
            this.pnlDialogButtons.Controls.Add(this.btnDelete);
            this.pnlDialogButtons.Controls.Add(this.btnCopy);
            this.pnlDialogButtons.Controls.Add(this.btnNew);
            this.pnlDialogButtons.Controls.Add(this.btnEditSave);
            this.pnlDialogButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlDialogButtons.Location = new System.Drawing.Point(0, 688);
            this.pnlDialogButtons.Name = "pnlDialogButtons";
            this.pnlDialogButtons.Size = new System.Drawing.Size(915, 59);
            this.pnlDialogButtons.TabIndex = 5;
            // 
            // btnSaveAndClose
            // 
            this.btnSaveAndClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveAndClose.BackColor = System.Drawing.SystemColors.Control;
            this.btnSaveAndClose.Location = new System.Drawing.Point(705, 12);
            this.btnSaveAndClose.Name = "btnSaveAndClose";
            this.btnSaveAndClose.Size = new System.Drawing.Size(95, 35);
            this.btnSaveAndClose.TabIndex = 5;
            this.btnSaveAndClose.Text = "Save && Close";
            this.btnSaveAndClose.UseVisualStyleBackColor = false;
            this.btnSaveAndClose.Click += new System.EventHandler(this.btnSaveAndClose_Click);
            // 
            // btnCloseCancel
            // 
            this.btnCloseCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCloseCancel.BackColor = System.Drawing.SystemColors.Control;
            this.btnCloseCancel.Location = new System.Drawing.Point(806, 12);
            this.btnCloseCancel.Name = "btnCloseCancel";
            this.btnCloseCancel.Size = new System.Drawing.Size(95, 35);
            this.btnCloseCancel.TabIndex = 4;
            this.btnCloseCancel.Text = "Cancel";
            this.btnCloseCancel.UseVisualStyleBackColor = false;
            this.btnCloseCancel.Click += new System.EventHandler(this.btnCloseCancel_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.SystemColors.Control;
            this.btnDelete.Location = new System.Drawing.Point(315, 12);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(95, 35);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnCopy
            // 
            this.btnCopy.BackColor = System.Drawing.SystemColors.Control;
            this.btnCopy.Location = new System.Drawing.Point(214, 12);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(95, 35);
            this.btnCopy.TabIndex = 2;
            this.btnCopy.Text = "Copy";
            this.btnCopy.UseVisualStyleBackColor = false;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // btnNew
            // 
            this.btnNew.BackColor = System.Drawing.SystemColors.Control;
            this.btnNew.Location = new System.Drawing.Point(113, 12);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(95, 35);
            this.btnNew.TabIndex = 1;
            this.btnNew.Text = "New";
            this.btnNew.UseVisualStyleBackColor = false;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnEditSave
            // 
            this.btnEditSave.BackColor = System.Drawing.SystemColors.Control;
            this.btnEditSave.Location = new System.Drawing.Point(12, 12);
            this.btnEditSave.Name = "btnEditSave";
            this.btnEditSave.Size = new System.Drawing.Size(95, 35);
            this.btnEditSave.TabIndex = 0;
            this.btnEditSave.Text = "Edit";
            this.btnEditSave.UseVisualStyleBackColor = false;
            this.btnEditSave.Click += new System.EventHandler(this.btnEditSave_Click);
            // 
            // appAppearanceEditor1
            // 
            this.appAppearanceEditor1.AllowEdit = true;
            this.appAppearanceEditor1.AppAppearance = null;
            this.appAppearanceEditor1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.appAppearanceEditor1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.appAppearanceEditor1.Location = new System.Drawing.Point(0, 70);
            this.appAppearanceEditor1.Name = "appAppearanceEditor1";
            this.appAppearanceEditor1.Size = new System.Drawing.Size(915, 618);
            this.appAppearanceEditor1.TabIndex = 6;
            // 
            // AppearanceEditorDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(915, 747);
            this.Controls.Add(this.appAppearanceEditor1);
            this.Controls.Add(this.pnlDialogButtons);
            this.Controls.Add(this.pnlSelection);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "AppearanceEditorDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Appearance Editor";
            this.Load += new System.EventHandler(this.AppearanceEditorDialog_Load);
            this.pnlSelection.ResumeLayout(false);
            this.pnlSelection.PerformLayout();
            this.pnlDialogButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlSelection;
        private System.Windows.Forms.Label lblAppearances;
        private System.Windows.Forms.ComboBox cboAppearances;
        private System.Windows.Forms.Panel pnlDialogButtons;
        private System.Windows.Forms.Button btnSaveAndClose;
        private System.Windows.Forms.Button btnCloseCancel;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnEditSave;
        private Themes.Editors.AppAppearanceEditor appAppearanceEditor1;
    }
}