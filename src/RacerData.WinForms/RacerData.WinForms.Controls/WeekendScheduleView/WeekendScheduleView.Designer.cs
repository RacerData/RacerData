namespace RacerData.WinForms.Controls.WeekendScheduleView
{
    partial class WeekendScheduleView
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
            this.tblSchedule = new System.Windows.Forms.TableLayoutPanel();
            this.SuspendLayout();
            // 
            // tblSchedule
            // 
            this.tblSchedule.AutoScroll = true;
            this.tblSchedule.AutoSize = true;
            this.tblSchedule.BackColor = System.Drawing.Color.White;
            this.tblSchedule.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tblSchedule.ColumnCount = 1;
            this.tblSchedule.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblSchedule.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblSchedule.Location = new System.Drawing.Point(0, 0);
            this.tblSchedule.Name = "tblSchedule";
            this.tblSchedule.Padding = new System.Windows.Forms.Padding(4);
            this.tblSchedule.RowCount = 1;
            this.tblSchedule.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblSchedule.Size = new System.Drawing.Size(623, 248);
            this.tblSchedule.TabIndex = 3;
            // 
            // ScheduleView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tblSchedule);
            this.Name = "ScheduleView";
            this.Size = new System.Drawing.Size(623, 248);
            this.Load += new System.EventHandler(this.ScheduleView_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tblSchedule;
    }
}
