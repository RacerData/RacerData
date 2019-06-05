using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Extensions.DependencyInjection;
using RacerData.Commmon.Results;
using RacerData.WinForms.Controllers;
using RacerData.WinForms.Controls;
using RacerData.WinForms.Dialogs;
using RacerData.WinForms.Models;
using RacerData.WinForms.Ports;
using RacerData.WinForms.Renderers;

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

            _viewGridController = (IViewGridController)viewGridControllerFactory.GetViewGridController(this, viewGrid1.Grid);

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

            var list1 = GetLeaderboardViewInfo();
            viewInfos.Add(list1);

            var static1 = GetStaticViewInfo();
            viewInfos.Add(static1);

            var graph1 = GetGraphViewInfo();
            viewInfos.Add(graph1);

            var video1 = GetVideoViewInfo();
            viewInfos.Add(video1);

            var audio1 = GetAudioViewInfo();
            viewInfos.Add(audio1);

            var weekendSchedule1 = GetWeekendScheduleViewInfo();
            viewInfos.Add(weekendSchedule1);

            _viewGridController.AddViews(viewInfos);
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
                            Alignment = ContentAlignment.MiddleLeft
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
            var viewInfo = new StaticViewInfo()
            {
                Key = Guid.NewGuid(),
                Name = "Static View Test",
                CellPosition = new ViewPosition()
                {
                    Row = 0,
                    Column = 0,
                    RowSpan = 6,
                    ColumnSpan = 6
                }
            };

            viewInfo.AddField(
                   new StaticField()
                   {
                       X = 8,
                       Y = 8,
                       Width = 100,
                       Height = 50,
                       CaptionAlignment = CaptionAlignment.Above,
                       Name = "Test Static Field 1",
                       ShowCaption = true,
                       Alignment = ContentAlignment.MiddleLeft
                   });

            viewInfo.AddField(
                   new StaticField()
                   {
                       X = 216,
                       Y = 8,
                       Width = 100,
                       Height = 50,
                       CaptionAlignment = CaptionAlignment.Above,
                       Name = "Test Static Field 2",
                       ShowCaption = true,
                       Alignment = ContentAlignment.MiddleLeft
                   });

            viewInfo.AddField(
                   new StaticField()
                   {
                       X = 8,
                       Y = 60,
                       Width = 200,
                       Height = 28,
                       CaptionAlignment = CaptionAlignment.Left,
                       Name = "Test Static Field 3",
                       ShowCaption = true,
                       Alignment = ContentAlignment.MiddleLeft
                   });

            viewInfo.AddField(
                   new StaticField()
                   {
                       X = 216,
                       Y = 60,
                       Width = 200,
                       Height = 28,
                       CaptionAlignment = CaptionAlignment.Left,
                       Name = "Test Static Field 4",
                       ShowCaption = true,
                       Alignment = ContentAlignment.MiddleLeft
                   });

            return viewInfo;
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

            var list1 = GetLeaderboardViewInfo();
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

        protected virtual async Task<IList<ApplicationAppearance>> LoadAppearancesAsync()
        {
            var appearanceRepository = ServiceProvider.Instance.GetRequiredService<IAppAppearanceRepository>();

            var result = await appearanceRepository.SelectListAsync();

            if (!result.IsSuccessful())
            {
                ExceptionHandler(result.Exception);

                return null;
            }

            return result.Value;
        }

        private void AppearanceMenu_Click(object sender, EventArgs e)
        {
            ToolStripItem menuItem = (ToolStripItem)sender;

            ApplicationAppearance appearance = (ApplicationAppearance)menuItem.Tag;

            _viewGridController.Appearance = appearance;

            toolStripStatusLabel1.Text = appearance.Name;
        }

        private async void toolStripDropDownButtonThemes_DropDownOpening(object sender, EventArgs e)
        {
            this.toolStripDropDownButtonThemes.DropDownItems.Clear();

            var appearances = await LoadAppearancesAsync();

            var appearanceMenuItems = new ToolStripItem[appearances.Count];

            int i = 0;

            foreach (ApplicationAppearance appearance in appearances)
            {
                var menu = new ToolStripMenuItem()
                {
                    Name = $"mnu{appearance.Name}",
                    Size = new Size(180, 22),
                    Text = appearance.Name,
                    Tag = appearance
                };

                menu.Click += AppearanceMenu_Click;

                appearanceMenuItems[i] = menu;

                i++;
            }

            this.toolStripDropDownButtonThemes.DropDownItems.AddRange(appearanceMenuItems);

            if (_viewGridController.Appearance != null)
                this.toolStrip1.Renderer = new ToolStripCustomRenderer((SimpleColorTable)_viewGridController.Appearance.MenuColorTable);
        }

        private void btnEditThemes_Click(object sender, EventArgs e)
        {
            var dialog = ServiceProvider.Instance.GetRequiredService<AppearanceEditorDialog>();

            dialog.ShowDialog(this);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void messageBoxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var dialogService = ServiceProvider.Instance.GetRequiredService<IDialogService>();
                dialogService.Appearance = _viewGridController.Appearance;

                dialogService.DisplayMessageBox(this, "Test", "This is a test", ButtonTypes.Ok);
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void inputBoxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var dialogService = ServiceProvider.Instance.GetRequiredService<IDialogService>();
            dialogService.Appearance = _viewGridController.Appearance;

            dialogService.DisplayInputDialog(this, "Test", "This is a test");
        }

        private void exceptionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var dialogService = ServiceProvider.Instance.GetRequiredService<IDialogService>();
            dialogService.Appearance = _viewGridController.Appearance;

            dialogService.DisplayException(this, "Test", ButtonTypes.Ok, new ArgumentNullException("NO! Bad Ubu!"));
        }

        private void fileViewerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var dialogService = ServiceProvider.Instance.GetRequiredService<IDialogService>();
            dialogService.Appearance = _viewGridController.Appearance;

            dialogService.DisplayFileViewer(this, "Test", @"C:\Users\Rob\Documents\rNascar\SettingsappAppearances.json");
        }
    }
}
