﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Extensions.DependencyInjection;
using RacerData.WinForms.Controls.Models.AudioView;
using RacerData.WinForms.Models;
using RacerData.WinForms.Ports;

namespace RacerData.WinForms
{
    public partial class ViewGridTest : Form
    {
        #region fields

        private IViewGridController _viewGridController;

        #endregion

        #region ctor

        public ViewGridTest()
        {
            InitializeComponent();

            IViewGridControllerFactory viewGridControllerFactory = ServiceProvider.Instance.GetRequiredService<IViewGridControllerFactory>();

            _viewGridController = viewGridControllerFactory.GetViewGridController(this, viewGrid1.Grid);

            _viewGridController.ViewAdded += _viewGridController_ViewAdded;
            _viewGridController.ViewRemoved += _viewGridController_ViewRemoved;
        }

        #endregion

        #region protected

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;  // Turn on WS_EX_COMPOSITED
                return cp;
            }
        }

        protected virtual void ExceptionHandler(Exception ex)
        {
            ExceptionHandler("Error!", ex);
        }
        protected virtual void ExceptionHandler(string message, Exception ex)
        {
            Console.WriteLine(ex.ToString());
            MessageBox.Show(ex.Message);
        }

        protected virtual void AddViews()
        {
            var viewInfos = new List<ViewInfo>();

            //var list1 = GetListViewInfo();
            //viewInfos.Add(list1);

            //var static1 = GetStaticViewInfo();
            //viewInfos.Add(static1);

            //var graph1 = GetGraphViewInfo();
            //viewInfos.Add(graph1);

            //var video1 = GetVideoViewInfo();
            //viewInfos.Add(video1);

            var audio1 = GetAudioViewInfo();
            viewInfos.Add(audio1);

            //var audio2 = GetAudioViewInfo();
            //viewInfos.Add(audio2);

            var weekendSchedule1 = GetWeekendScheduleViewInfo();
            viewInfos.Add(weekendSchedule1);

            _viewGridController.AddViews(viewInfos);
        }
        protected virtual ListViewInfo GetListViewInfo()
        {
            return new ListViewInfo()
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
                ListDefinition = new ListDefinition()
                {
                    DataSource = "LiveFeed",
                    DataMember = "Position",
                    Header = "List 1",
                    MaxRows = 20,
                    ShowCaptions = true,
                    Columns = new List<ListColumn>()
                        {
                        new ListColumn()
                        {
                            Caption ="Position",
                            DataMember ="Position",
                            DataSource ="LiveFeed",
                            DataPath ="LiveFeed\\Drivers\\",
                            Alignment = ContentAlignment.MiddleLeft
                        },
                        new ListColumn()
                        {
                            Caption ="Driver",
                            DataMember ="Driver",
                            DataSource ="LiveFeed",
                            DataPath ="LiveFeed\\Drivers\\",
                            Alignment = ContentAlignment.MiddleLeft
                        },
                        new ListColumn()
                        {
                            Caption ="Lap Speed",
                            DataMember ="LapSpeed",
                            DataSource ="LiveFeed",
                            DataPath ="LiveFeed\\Drivers\\",
                            Alignment = ContentAlignment.MiddleCenter
                        },
                        new ListColumn()
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
        protected virtual GraphViewInfo GetGraphViewInfo()
        {
            return new GraphViewInfo()
            {
                Key = Guid.NewGuid(),
                Name = "Graph 1",
                CellPosition = new ViewPosition()
                {
                    Row = 0,
                    Column = 4,
                    RowSpan = 6,
                    ColumnSpan = 8
                },
                DataMember = "LiveFeed",
                DataSource = "LapTimes",
                GraphType = GraphType.Normal,
                GraphSeries = new GraphSeries()
                {
                    Color = Color.Red.ToArgb(),
                    Name = "Driver Lap Times",
                    ShowCaption = true,
                    DataSource = "LapTimes",
                    GraphXRange = new GraphRange()
                    {
                        DisplayMember = "Name",
                        DataPath = "Drivers\\Name",
                        Increment = 1,
                        RangeMin = 0,
                        RangeMax = 10,
                        ShowCaption = true,
                        ShowLabels = true,
                        AutoScale = true,
                        Name = "Drivers",
                        ValueMember = "Position"
                    },
                    GraphYRange = new GraphRange()
                    {
                        DisplayMember = "LapNumber",
                        DataPath = "LapNumber",
                        Increment = 1,
                        RangeMin = 0,
                        RangeMax = 50,
                        ShowCaption = true,
                        ShowLabels = true,
                        AutoScale = true,
                        Name = "Laps",
                        ValueMember = "LapNumber"
                    }
                }
            };
        }
        protected virtual StaticViewInfo GetStaticViewInfo()
        {
            return new StaticViewInfo()
            {
                Key = Guid.NewGuid(),
                Name = "Static View Test",
                CellPosition = new ViewPosition()
                {
                    Row = 0,
                    Column = 0,
                    RowSpan = 6,
                    ColumnSpan = 6
                },
                Fields = new List<StaticField>()
                {
                    new StaticField()
                    {
                        X=8,
                        Y=8,
                        Width = 100,
                        Height = 50,
                        CaptionAlignment = CaptionAlignment.Above,
                        Name="Test Static Field 1",
                        ShowCaption=true,
                        Alignment = ContentAlignment.MiddleLeft
                    },new StaticField()
                    {
                        X=216,
                        Y=8,
                        Width = 100,
                        Height = 50,
                        CaptionAlignment = CaptionAlignment.Above,
                        Name="Test Static Field 2",
                        ShowCaption=true,
                        Alignment = ContentAlignment.MiddleLeft
                    },
                    new StaticField()
                    {
                        X=8,
                        Y=60,
                        Width = 200,
                        Height = 28,
                        CaptionAlignment = CaptionAlignment.Left,
                        Name="Test Static Field 3",
                        ShowCaption=true,
                        Alignment = ContentAlignment.MiddleLeft
                    },
                    new StaticField()
                    {
                        X=216,
                        Y=60,
                        Width = 200,
                        Height = 28,
                        CaptionAlignment = CaptionAlignment.Left,
                        Name="Test Static Field 4",
                        ShowCaption=true,
                        Alignment = ContentAlignment.MiddleLeft
                    }
                }
            };
        }
        protected virtual WeekendScheduleViewInfo GetWeekendScheduleViewInfo()
        {
            return new WeekendScheduleViewInfo()
            {
                Key = Guid.NewGuid(),
                Name = "Weekend Schedule",
                CellPosition = new ViewPosition()
                {
                    Row = 0,
                    Column = 0,
                    RowSpan = 6,
                    ColumnSpan = 6
                }
            };
        }
        protected virtual VideoViewInfo GetVideoViewInfo()
        {
            return new VideoViewInfo()
            {
                Key = Guid.NewGuid(),
                Name = "Video Feed",
                CellPosition = new ViewPosition()
                {
                    Row = 0,
                    Column = 0,
                    RowSpan = 6,
                    ColumnSpan = 6
                },
                DataMember = "LiveFeed",
                DataSource = "EventInfo"
            };
        }
        protected virtual AudioViewInfo GetAudioViewInfo()
        {
            return new AudioViewInfo()
            {
                Key = Guid.NewGuid(),
                Name = "Audio Feed",
                CellPosition = new ViewPosition()
                {
                    Row = 4,
                    Column = 0,
                    RowSpan = 4,
                    ColumnSpan = 4
                },
                DataMember = "LiveFeed",
                DataSource = "EventInfo"
            };
        }

        #endregion

        #region private

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            _viewGridController.AddRowColumn();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            _viewGridController.IncreaseCellSize();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            _viewGridController.DecreaseCellSize();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            _viewGridController.RemoveRowColumn();
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            try
            {
                AddViews();
            }
            catch (Exception ex)
            {
                ExceptionHandler("", ex);
            }
        }

        private void btnRemoveView_Click(object sender, EventArgs e)
        {
            _viewGridController.RemoveViewAt(0);
        }

        private void _viewGridController_ViewRemoved(object sender, ViewRemovedEventArgs e)
        {
#if TRACE
            Console.WriteLine($"View {e.View.Name} removed");
#endif
        }

        private void _viewGridController_ViewAdded(object sender, ViewAddedEventArgs e)
        {
#if TRACE
            Console.WriteLine($"View {e.View.Name} added");
#endif
        }

        private void audioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var viewInfos = new List<ViewInfo>();

            var audio1 = GetAudioViewInfo();
            viewInfos.Add(audio1);

            _viewGridController.AddViews(viewInfos);
        }

        private void staticToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var viewInfos = new List<ViewInfo>();

            var static1 = GetStaticViewInfo();
            viewInfos.Add(static1);

            _viewGridController.AddViews(viewInfos);
        }

        private void scheduleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var viewInfos = new List<ViewInfo>();

            var weekendSchedule1 = GetWeekendScheduleViewInfo();
            viewInfos.Add(weekendSchedule1);

            _viewGridController.AddViews(viewInfos);
        }

        private void listToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var viewInfos = new List<ViewInfo>();

            var list1 = GetListViewInfo();
            viewInfos.Add(list1);

            _viewGridController.AddViews(viewInfos);
        }

        private void videoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var viewInfos = new List<ViewInfo>();

            var video1 = GetVideoViewInfo();
            viewInfos.Add(video1);

            _viewGridController.AddViews(viewInfos);
        }

        private void graphToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var viewInfos = new List<ViewInfo>();

            var graph1 = GetGraphViewInfo();
            viewInfos.Add(graph1);

            _viewGridController.AddViews(viewInfos);
        }

        #endregion
    }
}