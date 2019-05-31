using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using rNascarApp.UI.Controllers;
using rNascarApp.UI.Factories;
using rNascarApp.UI.Models;
using rNascarApp.UI.Ports;

namespace rNascarApp.UI
{
    public partial class Form2 : Form
    {
        #region fields

        private IViewGridController _viewGridController;

        #endregion

        public Form2()
        {
            InitializeComponent();

            IViewFactory viewFactory = new ViewFactory();
            IViewGridControllerFactory viewGridControllerFactory = new ViewGridControllerFactory(viewFactory);

            _viewGridController = viewGridControllerFactory.GetViewGridController(viewFactory, this, viewGrid1.Grid);

            _viewGridController.ViewAdded += _viewGridController_ViewAdded;
            _viewGridController.ViewRemoved += _viewGridController_ViewRemoved;
        }

        private void _viewGridController_ViewRemoved(object sender, ViewRemovedEventArgs e)
        {
            Console.WriteLine($"View {e.View.Name} removed");
        }

        private void _viewGridController_ViewAdded(object sender, ViewAddedEventArgs e)
        {
            Console.WriteLine($"View {e.View.Name} added");
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;  // Turn on WS_EX_COMPOSITED
                return cp;
            }
        }

        #region protected

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

            //var graph1 = GetGraphViewInfo();
            //viewInfos.Add(graph1);

            //var video1 = GetVideoViewInfo();
            //viewInfos.Add(video1);

            //var audio1 = GetAudioViewInfo();
            //viewInfos.Add(audio1);

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
                    ColumnSpan = 2,
                    RowSpan = 3
                },
                ListDefinition = new ListDefinition()
                {
                    DataSource = "LiveFeed",
                    DataMember = "Position",
                    Header = "List 1",
                    MaxRows = 10,
                    Columns = new List<ListColumn>()
                                      {
                                          new ListColumn()
                                          {
                                               Caption ="Position",
                                                DataMember ="Position",
                                                 DataSource ="LiveFeed",
                                                  DataPath ="LiveFeed\\Drivers\\"
                                          },
                                           new ListColumn()
                                          {
                                               Caption ="Driver",
                                                DataMember ="Name",
                                                 DataSource ="LiveFeed",
                                                  DataPath ="LiveFeed\\Drivers\\"
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
                    RowSpan = 4,
                    ColumnSpan = 4
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
            AddViews();
        }
    }
}
