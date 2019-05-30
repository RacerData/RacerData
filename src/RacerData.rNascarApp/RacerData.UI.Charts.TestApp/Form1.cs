using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using rNascarApp.UI.Factories;
using rNascarApp.UI.Models;
using rNascarApp.UI.Ports;

namespace rNascarApp.UI
{
    public partial class Form1 : Form
    {
        #region fields

        private IViewController _viewController;

        #endregion

        #region ctor

        public Form1(
            IViewFactory viewFactory,
            IViewControllerFactory viewControllerFactory)
            : this()
        {
            _viewController = viewControllerFactory.GetViewController(viewFactory, GridTable);

            _viewController.ViewAdded += _viewController_ViewAdded;
            _viewController.ViewRemoved += _viewController_ViewRemoved;
        }
        public Form1()
        {
            InitializeComponent();

            IViewFactory viewFactory = new ViewFactory();
            IViewControllerFactory viewControllerFactory = new ViewControllerFactory(viewFactory);

            _viewController = viewControllerFactory.GetViewController(viewFactory, GridTable);

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

        #endregion

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
            var views = new List<ViewInfo>();

            var list1 = new ListViewInfo()
            {
                Key = Guid.NewGuid(),
                Name = "List 1",
                DataSource = "LiveFeed",
                DataMember = "Position",
                CellPosition = new ViewPosition()
                {
                    Column = 0,
                    Row = 2,
                    ColumnSpan = 4,
                    RowSpan = 8
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
            views.Add(list1);

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
            views.Add(graph1);

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
            views.Add(static1);

            _viewController.AddViews(views);
        }

        #endregion

        #region private

        private void btnAddRow_Click(object sender, EventArgs e)
        {
            try
            {
                _viewController.AddRow();
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }

        private void btnRemoveRow_Click(object sender, EventArgs e)
        {
            try
            {
                _viewController.RemoveRow();
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }

        private void btnAddCol_Click(object sender, EventArgs e)
        {
            try
            {
                _viewController.AddColumn();
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }

        private void btnRemoveCol_Click(object sender, EventArgs e)
        {
            try
            {
                _viewController.RemoveColumn();
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }

        private void btnIncreaseCellSize_Click(object sender, EventArgs e)
        {
            try
            {
                _viewController.IncreaseCellSize();
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }

        private void btnDecreaseCellSize_Click(object sender, EventArgs e)
        {
            try
            {
                _viewController.DecreaseCellSize();
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }

        private void btnAddViews_Click(object sender, EventArgs e)
        {
            try
            {
                AddViews();
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }

        private void btnRemoveView_Click(object sender, EventArgs e)
        {
            try
            {
                _viewController.RemoveViewAt(0);
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }

        #endregion

        private void GridTable_Resize(object sender, EventArgs e)
        {
            this.Text = $"{GridTable.Size} - {GridTable.ColumnCount}:{GridTable.RowCount}";
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            GridTable.Size = new Size(GridTable.Width + 100, GridTable.Height + 100);
            _viewController.AddColumn();
            _viewController.AddRow();
        }
    }
}
