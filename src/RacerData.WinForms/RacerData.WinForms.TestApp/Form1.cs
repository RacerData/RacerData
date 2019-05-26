using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using RacerData.WinForms.Controls;
using RacerData.WinForms.Models;

namespace RacerData.WinForms
{
    public partial class Form1 : Form
    {
        IList<DraggableContainer> Rows { get; set; }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                PopulateList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void PopulateList()
        {
            int rowCount = 2;
            int columnCount = 4;

            int listWidth = listView1.Width - 2;
            int rowHeight = 45;
            int columnWidth = 100;

            listView1.ClearRows();

            for (int rowIndex = 0; rowIndex < rowCount; rowIndex++)
            {
                ListViewRow row = new ListViewRow();
                row.Size = new Size(listWidth, rowHeight);
                row.Location = new Point(0, rowHeight * rowIndex);
                row.BorderStyle = BorderStyle.FixedSingle;
                row.BackColor = Color.SteelBlue;
                row.AllowDrop = (rowIndex > 0);
                row.AllowResize = true;
                row.DisplayIndex = rowIndex;
                row.IsListTitle = (rowIndex == 0);
                row.IsColumnCaptions = (rowIndex == 1);

                if (row.IsListTitle)
                {
                    var column = new ListViewCell();

                    column.Size = new Size(row.Width, row.Height);
                    column.Location = new Point(0, 0);
                    column.BorderStyle = BorderStyle.FixedSingle;
                    column.BackColor = Color.Magenta;
                    column.AllowDrop = false;

                    column.CellLabel.Text = $"List Title";

                    row.AddDraggableControl(column);
                }
                else if (row.IsColumnCaptions)
                {
                    for (int columnIndex = 0; columnIndex < columnCount; columnIndex++)
                    {
                        var column = new ListViewCell();

                        column.Size = new Size(columnWidth, row.Height);
                        column.Location = new Point((columnWidth * columnIndex), 0);
                        column.BorderStyle = BorderStyle.FixedSingle;
                        column.BackColor = Color.RoyalBlue;
                        column.AllowDrop = true;

                        column.CellLabel.Text = $"COLUMN {columnIndex}";

                        row.AddDraggableControl(column);
                    }
                }
                else
                {
                    for (int columnIndex = 0; columnIndex < columnCount; columnIndex++)
                    {
                        var column = new ListViewCell();

                        column.Size = new Size(columnWidth, row.Height);
                        column.Location = new Point((columnWidth * columnIndex), 0);
                        column.BorderStyle = BorderStyle.FixedSingle;
                        column.BackColor = Color.SkyBlue;
                        column.AllowDrop = true;

                        column.CellLabel.Text = $"Row:{rowIndex} Col:{columnIndex}";

                        row.AddDraggableControl(column);
                    }
                }

                listView1.AddRow(row);
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            ListViewColumnInfo info = new ListViewColumnInfo() { Caption = "Mike Honcho" };

            listView1.AddColumn(info);
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            ListViewColumnInfo info = new ListViewColumnInfo() { Caption = "INSERT THIS" };

            listView1.InsertColumnAt(2, info);
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            listView1.RemoveColumnAt(2);
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            IList<ListViewColumnInfo> infos = new List<ListViewColumnInfo>()
            {
                new ListViewColumnInfo() { Caption = "What Now Bitches" },
                new ListViewColumnInfo() { Caption = "Mike Honcho 2" }
            };

            listView1.AddColumns(infos);
        }
    }
}
