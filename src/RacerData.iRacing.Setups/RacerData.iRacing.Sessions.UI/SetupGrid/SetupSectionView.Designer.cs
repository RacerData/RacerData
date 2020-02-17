namespace RacerData.iRacing.Sessions.Ui.SetupGrid
{
    partial class SetupSectionView
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
            this.SetupValuesListView = new System.Windows.Forms.ListView();
            this.colProperty = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colValue = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colPreviousValue = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDelta = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblSectionName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // SetupValuesListView
            // 
            this.SetupValuesListView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SetupValuesListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colProperty,
            this.colValue,
            this.colPreviousValue,
            this.colDelta});
            this.SetupValuesListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SetupValuesListView.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SetupValuesListView.FullRowSelect = true;
            this.SetupValuesListView.GridLines = true;
            this.SetupValuesListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.SetupValuesListView.Location = new System.Drawing.Point(2, 27);
            this.SetupValuesListView.Name = "SetupValuesListView";
            this.SetupValuesListView.ShowGroups = false;
            this.SetupValuesListView.Size = new System.Drawing.Size(403, 133);
            this.SetupValuesListView.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.SetupValuesListView.TabIndex = 0;
            this.SetupValuesListView.UseCompatibleStateImageBehavior = false;
            this.SetupValuesListView.View = System.Windows.Forms.View.Details;
            // 
            // colProperty
            // 
            this.colProperty.Text = "";
            this.colProperty.Width = 125;
            // 
            // colValue
            // 
            this.colValue.Text = "Current";
            this.colValue.Width = 85;
            // 
            // colPreviousValue
            // 
            this.colPreviousValue.Text = "Previous";
            this.colPreviousValue.Width = 85;
            // 
            // colDelta
            // 
            this.colDelta.Text = "+/-";
            this.colDelta.Width = 85;
            // 
            // lblSectionName
            // 
            this.lblSectionName.BackColor = System.Drawing.Color.SteelBlue;
            this.lblSectionName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSectionName.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblSectionName.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSectionName.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblSectionName.Location = new System.Drawing.Point(2, 2);
            this.lblSectionName.Name = "lblSectionName";
            this.lblSectionName.Size = new System.Drawing.Size(403, 25);
            this.lblSectionName.TabIndex = 1;
            this.lblSectionName.Text = "Section Name";
            this.lblSectionName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // SetupSectionView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.SetupValuesListView);
            this.Controls.Add(this.lblSectionName);
            this.Name = "SetupSectionView";
            this.Padding = new System.Windows.Forms.Padding(2);
            this.Size = new System.Drawing.Size(407, 162);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView SetupValuesListView;
        private System.Windows.Forms.Label lblSectionName;
        private System.Windows.Forms.ColumnHeader colProperty;
        private System.Windows.Forms.ColumnHeader colValue;
        private System.Windows.Forms.ColumnHeader colPreviousValue;
        private System.Windows.Forms.ColumnHeader colDelta;
    }
}
