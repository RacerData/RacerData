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

        private IViewController _viewController;

        #endregion

        public Form2()
        {
            InitializeComponent();

            IViewFactory viewFactory = new ViewFactory();
            IViewControllerFactory viewControllerFactory = new ViewControllerFactory(viewFactory);

            _viewController = viewControllerFactory.GetViewController(viewFactory, this, viewGrid1.Grid);

            _viewController.ViewAdded += _viewController_ViewAdded;
            _viewController.ViewRemoved += _viewController_ViewRemoved;
        }

        private void _viewController_ViewRemoved(object sender, ViewRemovedEventArgs e)
        {
            Console.WriteLine($"View {e.View.Name} removed");
        }

        private void _viewController_ViewAdded(object sender, ViewAddedEventArgs e)
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

            var list1 = new ListViewInfo()
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
            viewInfos.Add(list1);

            var graph1 = new GraphViewInfo()
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
            viewInfos.Add(graph1);

            var static1 = new StaticViewInfo()
            {
                Key = Guid.NewGuid(),
                Name = "Static 1",
                CellPosition = new ViewPosition()
                {
                    Row = 0,
                    Column = 0,
                    RowSpan = 2,
                    ColumnSpan = 4
                },
                DataMember = "LiveFeed",
                DataSource = "EventInfo",
                StaticFields = new List<StaticField>()
                    {
                        new StaticField()
                        {
                            Index=0,
                            Name = "Track",
                            CaptionAlignment = CaptionAlignment.Above ,
                            DataMember = "TrackName",
                            ShowCaption =true,
                            Type = "System.String",
                            X=50,
                            Y=10,
                            Width = 200,
                            Height =24
                        },
                         new StaticField()
                        {
                            Index=1,
                            Name = "Run",
                            CaptionAlignment = CaptionAlignment.Above ,
                            DataMember = "RunName",
                            ShowCaption =true,
                            Type = "System.String",
                            X=230,
                            Y=10,
                            Width = 200,
                            Height =24
                        }
                    }
            };
            viewInfos.Add(static1);

            _viewController.AddViews(viewInfos);
        }

        #endregion

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            _viewController.AddRowColumn();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            _viewController.IncreaseCellSize();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            _viewController.DecreaseCellSize();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            _viewController.RemoveRowColumn();
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            AddViews();
        }
    }
}
