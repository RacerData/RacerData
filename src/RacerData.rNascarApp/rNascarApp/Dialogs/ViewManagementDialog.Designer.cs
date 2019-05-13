namespace RacerData.rNascarApp.Dialogs
{
    partial class ViewManagementDialog
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
            this.components = new System.ComponentModel.Container();
            this.pnlSelection = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.cboViewStates = new System.Windows.Forms.ComboBox();
            this.pnlDialogButtons = new System.Windows.Forms.Panel();
            this.btnCancelAndClose = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnCancelSaveAndClose = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnCopy = new System.Windows.Forms.Button();
            this.btnEditSave = new System.Windows.Forms.Button();
            this.pnlDetails = new System.Windows.Forms.Panel();
            this.btnEditFields = new System.Windows.Forms.Button();
            this.lstFields = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.pnlSelection.SuspendLayout();
            this.pnlDialogButtons.SuspendLayout();
            this.pnlDetails.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlSelection
            // 
            this.pnlSelection.Controls.Add(this.label1);
            this.pnlSelection.Controls.Add(this.cboViewStates);
            this.pnlSelection.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSelection.Location = new System.Drawing.Point(0, 0);
            this.pnlSelection.Name = "pnlSelection";
            this.pnlSelection.Size = new System.Drawing.Size(600, 66);
            this.pnlSelection.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Black", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "Select View:";
            // 
            // cboViewStates
            // 
            this.cboViewStates.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboViewStates.FormattingEnabled = true;
            this.cboViewStates.Location = new System.Drawing.Point(12, 30);
            this.cboViewStates.Name = "cboViewStates";
            this.cboViewStates.Size = new System.Drawing.Size(341, 23);
            this.cboViewStates.TabIndex = 0;
            this.cboViewStates.SelectedIndexChanged += new System.EventHandler(this.cboViews_SelectedIndexChanged);
            // 
            // pnlDialogButtons
            // 
            this.pnlDialogButtons.Controls.Add(this.btnCancelAndClose);
            this.pnlDialogButtons.Controls.Add(this.btnNew);
            this.pnlDialogButtons.Controls.Add(this.btnCancelSaveAndClose);
            this.pnlDialogButtons.Controls.Add(this.btnDelete);
            this.pnlDialogButtons.Controls.Add(this.btnCopy);
            this.pnlDialogButtons.Controls.Add(this.btnEditSave);
            this.pnlDialogButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlDialogButtons.Location = new System.Drawing.Point(0, 298);
            this.pnlDialogButtons.Name = "pnlDialogButtons";
            this.pnlDialogButtons.Size = new System.Drawing.Size(600, 50);
            this.pnlDialogButtons.TabIndex = 1;
            // 
            // btnCancelAndClose
            // 
            this.btnCancelAndClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelAndClose.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelAndClose.Location = new System.Drawing.Point(369, 6);
            this.btnCancelAndClose.Name = "btnCancelAndClose";
            this.btnCancelAndClose.Size = new System.Drawing.Size(106, 37);
            this.btnCancelAndClose.TabIndex = 5;
            this.btnCancelAndClose.Text = "Cancel && Close";
            this.toolTip1.SetToolTip(this.btnCancelAndClose, "Cancel all changes and close this form");
            this.btnCancelAndClose.UseVisualStyleBackColor = true;
            this.btnCancelAndClose.Click += new System.EventHandler(this.btnCancelAndClose_Click);
            // 
            // btnNew
            // 
            this.btnNew.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNew.Location = new System.Drawing.Point(100, 6);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(82, 37);
            this.btnNew.TabIndex = 4;
            this.btnNew.Text = "New";
            this.toolTip1.SetToolTip(this.btnNew, "Create a new workspace");
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnCancelSaveAndClose
            // 
            this.btnCancelSaveAndClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelSaveAndClose.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelSaveAndClose.Location = new System.Drawing.Point(482, 6);
            this.btnCancelSaveAndClose.Name = "btnCancelSaveAndClose";
            this.btnCancelSaveAndClose.Size = new System.Drawing.Size(106, 37);
            this.btnCancelSaveAndClose.TabIndex = 3;
            this.btnCancelSaveAndClose.Text = "Save && Close";
            this.toolTip1.SetToolTip(this.btnCancelSaveAndClose, "Save all changes and close the form");
            this.btnCancelSaveAndClose.UseVisualStyleBackColor = true;
            this.btnCancelSaveAndClose.Click += new System.EventHandler(this.btnCancelOrSaveAndClose_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(276, 6);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(82, 37);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "Delete";
            this.toolTip1.SetToolTip(this.btnDelete, "Delete the selected workspace");
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnCopy
            // 
            this.btnCopy.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCopy.Location = new System.Drawing.Point(188, 6);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(82, 37);
            this.btnCopy.TabIndex = 1;
            this.btnCopy.Text = "Copy";
            this.toolTip1.SetToolTip(this.btnCopy, "Make a copy of the selected workspace");
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // btnEditSave
            // 
            this.btnEditSave.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditSave.Location = new System.Drawing.Point(12, 6);
            this.btnEditSave.Name = "btnEditSave";
            this.btnEditSave.Size = new System.Drawing.Size(82, 37);
            this.btnEditSave.TabIndex = 0;
            this.btnEditSave.Text = "Edit";
            this.toolTip1.SetToolTip(this.btnEditSave, "Edit the selected workspace");
            this.btnEditSave.UseVisualStyleBackColor = true;
            this.btnEditSave.Click += new System.EventHandler(this.btnEditOrSave_Click);
            // 
            // pnlDetails
            // 
            this.pnlDetails.Controls.Add(this.btnEditFields);
            this.pnlDetails.Controls.Add(this.lstFields);
            this.pnlDetails.Controls.Add(this.label5);
            this.pnlDetails.Controls.Add(this.txtName);
            this.pnlDetails.Controls.Add(this.label2);
            this.pnlDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDetails.Location = new System.Drawing.Point(0, 66);
            this.pnlDetails.Name = "pnlDetails";
            this.pnlDetails.Size = new System.Drawing.Size(600, 232);
            this.pnlDetails.TabIndex = 2;
            // 
            // btnEditFields
            // 
            this.btnEditFields.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditFields.Location = new System.Drawing.Point(369, 180);
            this.btnEditFields.Name = "btnEditFields";
            this.btnEditFields.Size = new System.Drawing.Size(106, 37);
            this.btnEditFields.TabIndex = 8;
            this.btnEditFields.Text = "Edit Fields...";
            this.toolTip1.SetToolTip(this.btnEditFields, "Edit the selected workspace");
            this.btnEditFields.UseVisualStyleBackColor = true;
            this.btnEditFields.Visible = false;
            this.btnEditFields.Click += new System.EventHandler(this.btnEditFields_Click);
            // 
            // lstFields
            // 
            this.lstFields.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstFields.FormattingEnabled = true;
            this.lstFields.ItemHeight = 15;
            this.lstFields.Location = new System.Drawing.Point(12, 78);
            this.lstFields.Name = "lstFields";
            this.lstFields.Size = new System.Drawing.Size(340, 139);
            this.lstFields.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, 60);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 15);
            this.label5.TabIndex = 6;
            this.label5.Text = "Fields";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(12, 25);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(341, 21);
            this.txtName.TabIndex = 1;
            this.toolTip1.SetToolTip(this.txtName, "Name of the workspace. Must be unique.");
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(9, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "Name";
            // 
            // ViewManagementDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 348);
            this.Controls.Add(this.pnlDetails);
            this.Controls.Add(this.pnlDialogButtons);
            this.Controls.Add(this.pnlSelection);
            this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MinimumSize = new System.Drawing.Size(615, 275);
            this.Name = "ViewManagementDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "View Management";
            this.Load += new System.EventHandler(this.ViewManagementDialog_Load);
            this.pnlSelection.ResumeLayout(false);
            this.pnlSelection.PerformLayout();
            this.pnlDialogButtons.ResumeLayout(false);
            this.pnlDetails.ResumeLayout(false);
            this.pnlDetails.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlSelection;
        private System.Windows.Forms.Panel pnlDialogButtons;
        private System.Windows.Forms.Panel pnlDetails;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboViewStates;
        private System.Windows.Forms.Button btnCancelSaveAndClose;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.Button btnEditSave;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnCancelAndClose;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ListBox lstFields;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnEditFields;
    }
}