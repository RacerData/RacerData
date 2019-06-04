using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using RacerData.WinForms.Controls;
using RacerData.WinForms.Models;

namespace RacerData.WinForms
{
    public partial class LeaderboardViewTest : Form
    {
        IList<DraggableContainer> Rows { get; set; }

        public LeaderboardViewTest()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                //PopulateList();
                var LeaderboardViewInfo = GetLeaderboardViewInfo();
                LeaderboardView1.BuildLeaderboardView(LeaderboardViewInfo.LeaderboardViewDefinition);
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

            int listWidth = LeaderboardView1.Width - 2;
            int rowHeight = 80;// 45;
            int columnWidth = 100;

            LeaderboardView1.ClearRows();

            for (int rowIndex = 0; rowIndex < rowCount; rowIndex++)
            {
                LeaderboardViewRow row = new LeaderboardViewRow();
                row.Size = new Size(listWidth, rowHeight);
                row.Location = new Point(0, rowHeight * rowIndex);
                row.BorderStyle = BorderStyle.FixedSingle;
                row.BackColor = Color.SteelBlue;
                row.AllowDrop = (rowIndex > 0);
                row.AllowResize = true;
                row.DisplayIndex = rowIndex;
                row.IsColumnCaptions = (rowIndex == 1);

                if (row.IsColumnCaptions)
                {
                    for (int columnIndex = 0; columnIndex < columnCount; columnIndex++)
                    {
                        var column = new LeaderboardViewCell();

                        column.Size = new Size(columnWidth, row.Height);
                        column.Location = new Point((columnWidth * columnIndex), 0);
                        column.BorderStyle = BorderStyle.FixedSingle;
                        column.BackColor = Color.RoyalBlue;
                        column.AllowDrop = true;
                        column.CellLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

                        column.CellLabel.Text = $"COLUMN {columnIndex}";

                        row.AddDraggableControl(column);
                    }
                }
                else
                {
                    for (int columnIndex = 0; columnIndex < columnCount; columnIndex++)
                    {
                        var column = new LeaderboardViewCell();

                        column.Size = new Size(columnWidth, row.Height);
                        column.Location = new Point((columnWidth * columnIndex), 0);
                        column.BorderStyle = BorderStyle.FixedSingle;
                        column.BackColor = Color.SkyBlue;
                        column.AllowDrop = true;
                        column.CellLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

                        column.CellLabel.Text = $"Row:{rowIndex} Col:{columnIndex}";

                        row.AddDraggableControl(column);
                    }
                }

                LeaderboardView1.AddRow(row);
            }
        }

        protected virtual LeaderboardViewInfo GetLeaderboardViewInfo()
        {
            return new LeaderboardViewInfo()
            {
                Key = Guid.NewGuid(),
                Name = "List 1",
                DataSource = "LiveFeed",
                DataMember = "Position",
                CellPosition = new ViewPosition()
                {
                    Column = 1,
                    Row = 1,
                    ColumnSpan = 6,
                    RowSpan = 6
                },
                LeaderboardViewDefinition = new LeaderboardViewDefinition()
                {
                    DataSource = "LiveFeed",
                    DataMember = "Position",
                    Header = "List 1",
                    MaxRows = 20,
                    ShowCaptions = true,
                    Columns = new List<LeaderboardViewColumn>()
                        {
                        new LeaderboardViewColumn()
                        {
                            Caption ="Position",
                            DataMember ="Position",
                            DataSource ="LiveFeed",
                            DataPath ="LiveFeed\\Drivers\\",
                            Alignment = System.Drawing.ContentAlignment.MiddleLeft
                        },
                        new LeaderboardViewColumn()
                        {
                            Caption ="Driver",
                            DataMember ="Driver",
                            DataSource ="LiveFeed",
                            DataPath ="LiveFeed\\Drivers\\",
                            Alignment = ContentAlignment.MiddleLeft
                        },
                        new LeaderboardViewColumn()
                        {
                            Caption ="Lap Speed",
                            DataMember ="LapSpeed",
                            DataSource ="LiveFeed",
                            DataPath ="LiveFeed\\Drivers\\",
                            Alignment = ContentAlignment.MiddleCenter
                        },
                        new LeaderboardViewColumn()
                        {
                            Caption ="Lap Time",
                            DataMember ="LapTime",
                            DataSource ="LiveFeed",
                            DataPath ="LiveFeed\\Drivers\\",
                            Alignment = ContentAlignment.MiddleCenter
                        }
                        }
                }
            };
        }
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            LeaderboardViewColumn info = new LeaderboardViewColumn() { Caption = "Mike Honcho" };

            LeaderboardView1.AddColumn(info);
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            LeaderboardViewColumn info = new LeaderboardViewColumn() { Caption = "INSERT THIS" };

            LeaderboardView1.InsertColumnAt(2, info);
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            LeaderboardView1.RemoveColumnAt(2);
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            IList<LeaderboardViewColumn> infos = new List<LeaderboardViewColumn>()
            {
                new LeaderboardViewColumn() { Caption = "What Now Bitches" },
                new LeaderboardViewColumn() { Caption = "Mike Honcho 2" }
            };

            LeaderboardView1.AddColumns(infos);
        }
    }
}
