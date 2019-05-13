namespace RacerData.rNascarApp.Dialogs
{
    partial class WorkspaceManagementDialog
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
            this.cboWorkspaces = new System.Windows.Forms.ComboBox();
            this.pnlDialogButtons = new System.Windows.Forms.Panel();
            this.btnCancelAndClose = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnCancelSaveAndClose = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnCopy = new System.Windows.Forms.Button();
            this.btnEditSave = new System.Windows.Forms.Button();
            this.pnlDetails = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.lstViews = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkPractice = new System.Windows.Forms.CheckBox();
            this.chkRace = new System.Windows.Forms.CheckBox();
            this.chkQualifying = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.numColumns = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.numRows = new System.Windows.Forms.NumericUpDown();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.lstAllViews = new System.Windows.Forms.ListBox();
            this.btnAddView = new System.Windows.Forms.Button();
            this.btnRemoveView = new System.Windows.Forms.Button();
            this.pnlSelection.SuspendLayout();
            this.pnlDialogButtons.SuspendLayout();
            this.pnlDetails.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numColumns)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRows)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlSelection
            // 
            this.pnlSelection.Controls.Add(this.label1);
            this.pnlSelection.Controls.Add(this.cboWorkspaces);
            this.pnlSelection.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSelection.Location = new System.Drawing.Point(0, 0);
            this.pnlSelection.Name = "pnlSelection";
            this.pnlSelection.Size = new System.Drawing.Size(642, 66);
            this.pnlSelection.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Black", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "Select Workspace:";
            // 
            // cboWorkspaces
            // 
            this.cboWorkspaces.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboWorkspaces.FormattingEnabled = true;
            this.cboWorkspaces.Location = new System.Drawing.Point(12, 30);
            this.cboWorkspaces.Name = "cboWorkspaces";
            this.cboWorkspaces.Size = new System.Drawing.Size(341, 23);
            this.cboWorkspaces.TabIndex = 0;
            this.cboWorkspaces.SelectedIndexChanged += new System.EventHandler(this.cboWorkspaces_SelectedIndexChanged);
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
            this.pnlDialogButtons.Location = new System.Drawing.Point(0, 306);
            this.pnlDialogButtons.Name = "pnlDialogButtons";
            this.pnlDialogButtons.Size = new System.Drawing.Size(642, 50);
            this.pnlDialogButtons.TabIndex = 1;
            // 
            // btnCancelAndClose
            // 
            this.btnCancelAndClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelAndClose.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelAndClose.Location = new System.Drawing.Point(411, 6);
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
            this.btnCancelSaveAndClose.Location = new System.Drawing.Point(524, 6);
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
            this.pnlDetails.Controls.Add(this.btnRemoveView);
            this.pnlDetails.Controls.Add(this.btnAddView);
            this.pnlDetails.Controls.Add(this.label6);
            this.pnlDetails.Controls.Add(this.lstAllViews);
            this.pnlDetails.Controls.Add(this.label5);
            this.pnlDetails.Controls.Add(this.lstViews);
            this.pnlDetails.Controls.Add(this.groupBox1);
            this.pnlDetails.Controls.Add(this.label4);
            this.pnlDetails.Controls.Add(this.numColumns);
            this.pnlDetails.Controls.Add(this.label3);
            this.pnlDetails.Controls.Add(this.numRows);
            this.pnlDetails.Controls.Add(this.txtName);
            this.pnlDetails.Controls.Add(this.label2);
            this.pnlDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDetails.Location = new System.Drawing.Point(0, 66);
            this.pnlDetails.Name = "pnlDetails";
            this.pnlDetails.Size = new System.Drawing.Size(642, 240);
            this.pnlDetails.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(212, 57);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(111, 15);
            this.label5.TabIndex = 11;
            this.label5.Text = "Workspace Views";
            // 
            // lstViews
            // 
            this.lstViews.FormattingEnabled = true;
            this.lstViews.ItemHeight = 15;
            this.lstViews.Location = new System.Drawing.Point(215, 75);
            this.lstViews.Name = "lstViews";
            this.lstViews.Size = new System.Drawing.Size(143, 139);
            this.lstViews.TabIndex = 10;
            this.toolTip1.SetToolTip(this.lstViews, "List of Views in this workspace");
            this.lstViews.SelectedIndexChanged += new System.EventHandler(this.lstViews_SelectedIndexChanged);
            this.lstViews.DoubleClick += new System.EventHandler(this.lstViews_DoubleClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkPractice);
            this.groupBox1.Controls.Add(this.chkRace);
            this.groupBox1.Controls.Add(this.chkQualifying);
            this.groupBox1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(11, 102);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(139, 112);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Default Workspace:";
            this.toolTip1.SetToolTip(this.groupBox1, "Will automatically open this workspace when this type of live event is received");
            // 
            // chkPractice
            // 
            this.chkPractice.AutoSize = true;
            this.chkPractice.Location = new System.Drawing.Point(11, 29);
            this.chkPractice.Name = "chkPractice";
            this.chkPractice.Size = new System.Drawing.Size(74, 19);
            this.chkPractice.TabIndex = 6;
            this.chkPractice.Text = "Practice";
            this.chkPractice.UseVisualStyleBackColor = true;
            // 
            // chkRace
            // 
            this.chkRace.AutoSize = true;
            this.chkRace.Location = new System.Drawing.Point(11, 79);
            this.chkRace.Name = "chkRace";
            this.chkRace.Size = new System.Drawing.Size(55, 19);
            this.chkRace.TabIndex = 8;
            this.chkRace.Text = "Race";
            this.chkRace.UseVisualStyleBackColor = true;
            // 
            // chkQualifying
            // 
            this.chkQualifying.AutoSize = true;
            this.chkQualifying.Location = new System.Drawing.Point(11, 54);
            this.chkQualifying.Name = "chkQualifying";
            this.chkQualifying.Size = new System.Drawing.Size(82, 19);
            this.chkQualifying.TabIndex = 7;
            this.chkQualifying.Text = "Qualifying";
            this.chkQualifying.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(85, 57);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 15);
            this.label4.TabIndex = 5;
            this.label4.Text = "Grid Columns";
            // 
            // numColumns
            // 
            this.numColumns.Location = new System.Drawing.Point(86, 75);
            this.numColumns.Maximum = new decimal(new int[] {
            40,
            0,
            0,
            0});
            this.numColumns.Minimum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.numColumns.Name = "numColumns";
            this.numColumns.Size = new System.Drawing.Size(64, 21);
            this.numColumns.TabIndex = 4;
            this.toolTip1.SetToolTip(this.numColumns, "The number of grid rows and columns for this workspace.");
            this.numColumns.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(10, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 15);
            this.label3.TabIndex = 3;
            this.label3.Text = "Grid Rows";
            // 
            // numRows
            // 
            this.numRows.Location = new System.Drawing.Point(11, 75);
            this.numRows.Maximum = new decimal(new int[] {
            40,
            0,
            0,
            0});
            this.numRows.Minimum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.numRows.Name = "numRows";
            this.numRows.Size = new System.Drawing.Size(64, 21);
            this.numRows.TabIndex = 2;
            this.toolTip1.SetToolTip(this.numRows, "The number of grid rows and columns for this workspace.");
            this.numRows.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
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
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(484, 57);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(96, 15);
            this.label6.TabIndex = 13;
            this.label6.Text = "Available Views";
            // 
            // lstAllViews
            // 
            this.lstAllViews.FormattingEnabled = true;
            this.lstAllViews.ItemHeight = 15;
            this.lstAllViews.Location = new System.Drawing.Point(487, 75);
            this.lstAllViews.Name = "lstAllViews";
            this.lstAllViews.Size = new System.Drawing.Size(143, 139);
            this.lstAllViews.TabIndex = 12;
            this.toolTip1.SetToolTip(this.lstAllViews, "List of Views in this workspace");
            this.lstAllViews.SelectedIndexChanged += new System.EventHandler(this.lstAllViews_SelectedIndexChanged);
            this.lstAllViews.DoubleClick += new System.EventHandler(this.lstAllViews_DoubleClick);
            // 
            // btnAddView
            // 
            this.btnAddView.Location = new System.Drawing.Point(379, 91);
            this.btnAddView.Name = "btnAddView";
            this.btnAddView.Size = new System.Drawing.Size(85, 23);
            this.btnAddView.TabIndex = 14;
            this.btnAddView.Text = "<< Add";
            this.btnAddView.UseVisualStyleBackColor = true;
            this.btnAddView.Click += new System.EventHandler(this.btnAddView_Click);
            // 
            // btnRemoveView
            // 
            this.btnRemoveView.Location = new System.Drawing.Point(379, 156);
            this.btnRemoveView.Name = "btnRemoveView";
            this.btnRemoveView.Size = new System.Drawing.Size(85, 23);
            this.btnRemoveView.TabIndex = 15;
            this.btnRemoveView.Text = "Remove >>";
            this.btnRemoveView.UseVisualStyleBackColor = true;
            this.btnRemoveView.Click += new System.EventHandler(this.btnRemoveView_Click);
            // 
            // WorkspaceManagementDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(642, 356);
            this.Controls.Add(this.pnlDetails);
            this.Controls.Add(this.pnlDialogButtons);
            this.Controls.Add(this.pnlSelection);
            this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "WorkspaceManagementDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Workspace Management";
            this.Load += new System.EventHandler(this.WorkspaceManagementDialog_Load);
            this.pnlSelection.ResumeLayout(false);
            this.pnlSelection.PerformLayout();
            this.pnlDialogButtons.ResumeLayout(false);
            this.pnlDetails.ResumeLayout(false);
            this.pnlDetails.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numColumns)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRows)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlSelection;
        private System.Windows.Forms.Panel pnlDialogButtons;
        private System.Windows.Forms.Panel pnlDetails;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboWorkspaces;
        private System.Windows.Forms.Button btnCancelSaveAndClose;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.Button btnEditSave;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numColumns;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numRows;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListBox lstViews;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkPractice;
        private System.Windows.Forms.CheckBox chkRace;
        private System.Windows.Forms.CheckBox chkQualifying;
        private System.Windows.Forms.Button btnCancelAndClose;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ListBox lstAllViews;
        private System.Windows.Forms.Button btnRemoveView;
        private System.Windows.Forms.Button btnAddView;
    }
}