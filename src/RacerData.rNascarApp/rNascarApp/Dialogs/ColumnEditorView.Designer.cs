namespace RacerData.rNascarApp.Dialogs
{
    partial class ColumnEditorView
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
            this.pnlDialogButtons = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.listColumnEditor1 = new RacerData.rNascarApp.Controls.ListColumnEditor.ListColumnEditor();
            this.pnlDialogButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlDialogButtons
            // 
            this.pnlDialogButtons.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.pnlDialogButtons.Controls.Add(this.btnSave);
            this.pnlDialogButtons.Controls.Add(this.btnCancel);
            this.pnlDialogButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlDialogButtons.Location = new System.Drawing.Point(0, 278);
            this.pnlDialogButtons.Name = "pnlDialogButtons";
            this.pnlDialogButtons.Size = new System.Drawing.Size(933, 55);
            this.pnlDialogButtons.TabIndex = 1;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.BackColor = System.Drawing.Color.Silver;
            this.btnSave.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro;
            this.btnSave.FlatAppearance.BorderSize = 2;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.Black;
            this.btnSave.Location = new System.Drawing.Point(711, 10);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(101, 33);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.BackColor = System.Drawing.Color.Silver;
            this.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro;
            this.btnCancel.FlatAppearance.BorderSize = 2;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.Black;
            this.btnCancel.Location = new System.Drawing.Point(820, 10);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(101, 33);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // listColumnEditor1
            // 
            this.listColumnEditor1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listColumnEditor1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listColumnEditor1.IsEditing = false;
            this.listColumnEditor1.Location = new System.Drawing.Point(0, 0);
            this.listColumnEditor1.Name = "listColumnEditor1";
            this.listColumnEditor1.ShowViewSettings = false;
            this.listColumnEditor1.Size = new System.Drawing.Size(933, 278);
            this.listColumnEditor1.TabIndex = 2;
            this.listColumnEditor1.ViewState = null;
            // 
            // ColumnEditorView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(933, 333);
            this.Controls.Add(this.listColumnEditor1);
            this.Controls.Add(this.pnlDialogButtons);
            this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ColumnEditorView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "View Columns Editor";
            this.Load += new System.EventHandler(this.ListColumnControlTest_Load);
            this.pnlDialogButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pnlDialogButtons;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private Controls.ListColumnEditor.ListColumnEditor listColumnEditor1;
    }
}