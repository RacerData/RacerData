namespace RacerData.WinForms.Controls
{
    partial class DayScheduleItem
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
            this.lblDate = new System.Windows.Forms.Label();
            this.tblSchedule = new System.Windows.Forms.TableLayoutPanel();
            this.SuspendLayout();
            // 
            // lblDate
            // 
            this.lblDate.BackColor = System.Drawing.Color.Silver;
            this.lblDate.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblDate.ForeColor = System.Drawing.Color.Black;
            this.lblDate.Location = new System.Drawing.Point(0, 0);
            this.lblDate.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblDate.Name = "lblDate";
            this.lblDate.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.lblDate.Size = new System.Drawing.Size(500, 25);
            this.lblDate.TabIndex = 2;
            this.lblDate.Text = "dateTime";
            this.lblDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tblSchedule
            // 
            this.tblSchedule.AutoScroll = true;
            this.tblSchedule.AutoSize = true;
            this.tblSchedule.BackColor = System.Drawing.Color.White;
            this.tblSchedule.ColumnCount = 1;
            this.tblSchedule.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblSchedule.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblSchedule.Location = new System.Drawing.Point(0, 25);
            this.tblSchedule.Name = "tblSchedule";
            this.tblSchedule.RowCount = 1;
            this.tblSchedule.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblSchedule.Size = new System.Drawing.Size(500, 197);
            this.tblSchedule.TabIndex = 4;
            // 
            // DayScheduleItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.tblSchedule);
            this.Controls.Add(this.lblDate);
            this.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "DayScheduleItem";
            this.Size = new System.Drawing.Size(500, 222);
            this.Load += new System.EventHandler(this.DayScheduleItem_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.TableLayoutPanel tblSchedule;
    }
}
