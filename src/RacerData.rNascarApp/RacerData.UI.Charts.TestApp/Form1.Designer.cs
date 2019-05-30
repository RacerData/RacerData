namespace rNascarApp.UI
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnAddViews = new System.Windows.Forms.ToolStripButton();
            this.btnRemoveView = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnAddRow = new System.Windows.Forms.ToolStripButton();
            this.btnRemoveRow = new System.Windows.Forms.ToolStripButton();
            this.btnAddCol = new System.Windows.Forms.ToolStripButton();
            this.btnRemoveCol = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnIncreaseCellSize = new System.Windows.Forms.ToolStripButton();
            this.btnDecreaseCellSize = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.GridTable = new System.Windows.Forms.TableLayoutPanel();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAddViews,
            this.btnRemoveView,
            this.toolStripSeparator1,
            this.btnAddRow,
            this.btnRemoveRow,
            this.btnAddCol,
            this.btnRemoveCol,
            this.toolStripSeparator2,
            this.btnIncreaseCellSize,
            this.btnDecreaseCellSize,
            this.toolStripSeparator3,
            this.toolStripButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(800, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnAddViews
            // 
            this.btnAddViews.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnAddViews.Image = ((System.Drawing.Image)(resources.GetObject("btnAddViews.Image")));
            this.btnAddViews.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAddViews.Name = "btnAddViews";
            this.btnAddViews.Size = new System.Drawing.Size(66, 22);
            this.btnAddViews.Text = "Add Views";
            this.btnAddViews.Click += new System.EventHandler(this.btnAddViews_Click);
            // 
            // btnRemoveView
            // 
            this.btnRemoveView.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnRemoveView.Image = ((System.Drawing.Image)(resources.GetObject("btnRemoveView.Image")));
            this.btnRemoveView.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRemoveView.Name = "btnRemoveView";
            this.btnRemoveView.Size = new System.Drawing.Size(82, 22);
            this.btnRemoveView.Text = "Remove View";
            this.btnRemoveView.Click += new System.EventHandler(this.btnRemoveView_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // btnAddRow
            // 
            this.btnAddRow.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnAddRow.Image = ((System.Drawing.Image)(resources.GetObject("btnAddRow.Image")));
            this.btnAddRow.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAddRow.Name = "btnAddRow";
            this.btnAddRow.Size = new System.Drawing.Size(50, 22);
            this.btnAddRow.Text = "Rows +";
            this.btnAddRow.Click += new System.EventHandler(this.btnAddRow_Click);
            // 
            // btnRemoveRow
            // 
            this.btnRemoveRow.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnRemoveRow.Image = ((System.Drawing.Image)(resources.GetObject("btnRemoveRow.Image")));
            this.btnRemoveRow.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRemoveRow.Name = "btnRemoveRow";
            this.btnRemoveRow.Size = new System.Drawing.Size(47, 22);
            this.btnRemoveRow.Text = "Rows -";
            this.btnRemoveRow.Click += new System.EventHandler(this.btnRemoveRow_Click);
            // 
            // btnAddCol
            // 
            this.btnAddCol.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnAddCol.Image = ((System.Drawing.Image)(resources.GetObject("btnAddCol.Image")));
            this.btnAddCol.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAddCol.Name = "btnAddCol";
            this.btnAddCol.Size = new System.Drawing.Size(45, 22);
            this.btnAddCol.Text = "Cols +";
            this.btnAddCol.Click += new System.EventHandler(this.btnAddCol_Click);
            // 
            // btnRemoveCol
            // 
            this.btnRemoveCol.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnRemoveCol.Image = ((System.Drawing.Image)(resources.GetObject("btnRemoveCol.Image")));
            this.btnRemoveCol.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRemoveCol.Name = "btnRemoveCol";
            this.btnRemoveCol.Size = new System.Drawing.Size(42, 22);
            this.btnRemoveCol.Text = "Cols -";
            this.btnRemoveCol.Click += new System.EventHandler(this.btnRemoveCol_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // btnIncreaseCellSize
            // 
            this.btnIncreaseCellSize.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnIncreaseCellSize.Image = ((System.Drawing.Image)(resources.GetObject("btnIncreaseCellSize.Image")));
            this.btnIncreaseCellSize.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnIncreaseCellSize.Name = "btnIncreaseCellSize";
            this.btnIncreaseCellSize.Size = new System.Drawing.Size(56, 22);
            this.btnIncreaseCellSize.Text = "Zoom In";
            this.btnIncreaseCellSize.Click += new System.EventHandler(this.btnIncreaseCellSize_Click);
            // 
            // btnDecreaseCellSize
            // 
            this.btnDecreaseCellSize.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnDecreaseCellSize.Image = ((System.Drawing.Image)(resources.GetObject("btnDecreaseCellSize.Image")));
            this.btnDecreaseCellSize.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDecreaseCellSize.Name = "btnDecreaseCellSize";
            this.btnDecreaseCellSize.Size = new System.Drawing.Size(66, 22);
            this.btnDecreaseCellSize.Text = "Zoom Out";
            this.btnDecreaseCellSize.Click += new System.EventHandler(this.btnDecreaseCellSize_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // GridTable
            // 
            this.GridTable.AutoScroll = true;
            this.GridTable.BackColor = System.Drawing.Color.White;
            this.GridTable.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.GridTable.ColumnCount = 16;
            this.GridTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.GridTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.GridTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.GridTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.GridTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.GridTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.GridTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.GridTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.GridTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.GridTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.GridTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.GridTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.GridTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.GridTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.GridTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.GridTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.GridTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GridTable.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.AddColumns;
            this.GridTable.Location = new System.Drawing.Point(8, 8);
            this.GridTable.Name = "GridTable";
            this.GridTable.RowCount = 16;
            this.GridTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.GridTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.GridTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.GridTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.GridTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.GridTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.GridTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.GridTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.GridTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.GridTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.GridTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.GridTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.GridTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.GridTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.GridTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.GridTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.GridTable.Size = new System.Drawing.Size(784, 409);
            this.GridTable.TabIndex = 1;
            this.GridTable.Resize += new System.EventHandler(this.GridTable_Resize);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "toolStripButton1";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.AutoScrollMargin = new System.Drawing.Size(0, 10);
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.GridTable);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 25);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(8);
            this.panel1.Size = new System.Drawing.Size(800, 425);
            this.panel1.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.DoubleBuffered = true;
            this.Name = "Form1";
            this.Text = "Form1";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.TableLayoutPanel GridTable;
        private System.Windows.Forms.ToolStripButton btnAddViews;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnAddRow;
        private System.Windows.Forms.ToolStripButton btnRemoveRow;
        private System.Windows.Forms.ToolStripButton btnAddCol;
        private System.Windows.Forms.ToolStripButton btnRemoveCol;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnIncreaseCellSize;
        private System.Windows.Forms.ToolStripButton btnDecreaseCellSize;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton btnRemoveView;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.Panel panel1;
    }
}

