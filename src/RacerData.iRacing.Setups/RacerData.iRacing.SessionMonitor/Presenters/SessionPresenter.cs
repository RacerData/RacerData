using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using iRacingSdkWrapper;
using iRacingSimulator;
using RacerData.iRacing.SessionMonitor.Internal.Services;
using RacerData.iRacing.SessionMonitor.ViewModels;
using RacerData.iRacing.SessionMonitor.Views;
using RacerData.iRacing.Sessions.Ui.LapTimeChart;
using RacerData.iRacing.Telemetry;
using RacerData.iRacing.Telemetry.Sdk.Factories;
using static RacerData.iRacing.Sessions.Ui.TireSheet.TireSheetViewModel;

namespace RacerData.iRacing.SessionMonitor.Presenters
{
    class SessionPresenter : IDisposable
    {
        #region consts

        private const string SetupRootDirectory = @"C:\Users\Rob\Documents\iRacing\setups";
        private const string SetupAutoBackupDirectory = @"C:\Users\Rob\Documents\iRacing\telemetry\setups\autoBackup";

        #endregion

        #region fields

        int _lapNumberColumnIdx = 0;
        int _firstLapColumnIdx = 1;
        int _secondLapColumnIdx = 2;
        int _lapDeltaColumnIdx = 3;
        int _runDeltaColumnIdx = 4;

        int _idColumnIdx = 0;
        int _startTimeColumnIdx = 1;
        int _eventTypeColumnIdx = 2;
        int _sessionTypeColumnIdx = 3;
        int _lapCountColumnIdx = 4;
        int _validLapCountColumnIdx = 5;
        int _coreLapCountColumnIdx = 6;
        int _lapAverageCellIdx = 7;
        int _bestLapTimeCellIdx = 8;
        int _stdDevColumnIdx = 9;
        int _tenLapEstimateColumnIdx = 10;
        int _sessionStartLapColumnIdx = 11;
        int _sessionEndLapCellIdx = 12;

        IDictionary<int, Color> _seriesColors = new Dictionary<int, Color>();

        Color _run1TextColor = Color.White;
        readonly Color _run2TextColor = Color.WhiteSmoke;

        private readonly ISessionView _view = null;
        private readonly SessionViewModel _viewModel = null;
        private readonly SynchronizationContext _context;
        private TelemetryDirectoryMonitorSevice _telemetryDirectoryMonitor;
        BindingSource _sessionRunsBindingSource = null;
        BindingSource _selectedLapsBindingSource = null;
        LapComparisonSet _lapComparisonSet = new LapComparisonSet();

        #endregion

        #region properties

        public bool iRacingIsRunning
        {
            get
            {
                Process[] pname = Process.GetProcessesByName("iRacingLocalServer64");
                return (pname.Length > 0);
            }
        }

        #endregion

        #region ctor

        public SessionPresenter(
            SynchronizationContext context,
            ISessionView view,
            SessionViewModel viewModel)
        {
            _context = context;
            _view = view;
            _viewModel = viewModel;

            _seriesColors.Add(0, Color.Blue);
            _seriesColors.Add(1, Color.Red);
            _seriesColors.Add(2, Color.Yellow);
            _seriesColors.Add(3, Color.Green);
            _seriesColors.Add(4, Color.Purple);
            _seriesColors.Add(5, Color.Orange);
            _seriesColors.Add(6, Color.Cyan);
            _seriesColors.Add(7, Color.White);

            InitializeMonitors();

            InitializeWrapper();

            InitializeBinding();

            InitializeRunGridColumns();

            InitializeLapGridColumns();
        }

        #endregion

        #region public [development]

        public void ReloadDirectory()
        {
            _context.Post(
                   async delegate
                   {
                       foreach (string file in Directory.GetFiles(@"C:\Users\Rob\Documents\iRacing\telemetry\", "*.ibt"))
                       {
                           SessionRunViewModel sessionRunViewModel = await TelemetryFileCreatedAsync(file).ConfigureAwait(true);

                           _viewModel.SessionRuns.Add(sessionRunViewModel);
                       }

                   }, null);
        }
        public void StartServices()
        {
            if (iRacingIsRunning)
                Sim.Instance.Start(1);
        }
        public void StopServices()
        {
            Sim.Instance.Stop();
            _telemetryDirectoryMonitor.StopService();
        }

        public void AddRun()
        {
            var lastSessionLap = _viewModel.SessionRuns.Count == 0 ? 0 : _viewModel.SessionRuns.Max(r => r.SessionEndLap);

            var nextSessionLap = lastSessionLap + 1;

            var lastSessionId = _viewModel.SessionRuns.Count == 0 ? 0 : _viewModel.SessionRuns.Max(s => s.Id);

            var nextSessionId = lastSessionId + 1;

            var sessionRunViewModel = GetSessionRunViewModel(nextSessionLap, nextSessionId);

            _viewModel.SessionRuns.Add(sessionRunViewModel);
        }
        public void AddRuns()
        {
            var maxIdx = _viewModel.SessionRuns.Count == 0 ? 0 : _viewModel.SessionRuns.Max(s => s.Id);

            int startId = maxIdx + 1;
            int currentSessionLap = 0;
            int runCountToAdd = 4;

            for (int i = startId; i < startId + runCountToAdd; i++)
            {
                var sessionRun = new SessionRunViewModel()
                {
                    Id = _viewModel.SessionRuns.Count,
                    StartTime = DateTime.Now
                };

                SessionRunViewModel run = GetSessionRunViewModel(currentSessionLap, i);

                _viewModel.SessionRuns.Add(run);

                currentSessionLap = run.SessionEndLap + 1;
            }
        }
        public void RemoveLastRun()
        {
            if (_viewModel.SessionRuns.Count > 0)
                _viewModel.SessionRuns.RemoveAt(_viewModel.SessionRuns.Count - 1);
        }
        public void RemoveSelectedRuns()
        {
            foreach (DataGridViewRow row in _view.SessionRuns.SelectedRows)
            {
                int idx = row.Index;
                if (idx > 0)
                    _viewModel.SessionRuns.RemoveAt(idx);
            }

            _sessionRunsBindingSource.ResetBindings(false);
        }
        public void ClearRuns()
        {
            _viewModel.SessionRuns.Clear();
        }

        private SessionRunViewModel GetSessionRunViewModel(int startLap, int id)
        {
            Random rnd = new Random(DateTime.Now.Millisecond);

            return new SessionRunViewModel()
            {
                Id = id,
                StartTime = DateTime.Now,
                Laps = GetLaps(startLap, rnd.Next(35, 45)),
                EventType = "Testing",
                SessionType = "Test",
                Setup = new SetupViewModel()
                {
                    Name = $"Setup{id}",
                    Values = new List<SetupValueViewModel>()
                     {
                         new SetupValueViewModel()
                         {
                            Group ="Chassis.Front",
                            Name = "SwayBarSize",
                            Value = "2.00 in"
                         },
                         new SetupValueViewModel()
                         {
                            Group ="Tires.LeftFront",
                            Name = "ColdPSI",
                            Value = "15 psi"
                         }
                     }
                }
            };
        }
        private IList<SessionLapViewModel> GetLaps(int startingSessionLapNumber, int count)
        {
            IList<SessionLapViewModel> laps = new List<SessionLapViewModel>();
            Random rnd = new Random(DateTime.Now.Millisecond);

            for (int i = 0; i < count; i++)
            {
                laps.Add(new SessionLapViewModel()
                {
                    SessionLapNumber = startingSessionLapNumber + i,
                    RunLapNumber = i,
                    LapTime = 15 + (float)rnd.NextDouble(),
                    Status = i == 0 ? SessionLapStatus.OutLap : i == (count - 1) ? SessionLapStatus.InLap : SessionLapStatus.ValidLap
                });
            }

            return laps;
        }
        #endregion

        #region protected

        protected virtual void ExceptionHandler(Exception ex, string message)
        {
            MessageBox.Show($"{DateTime.Now}: {message} {ex.Message}");
        }

        #region view model events

        protected virtual void _viewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            _view.UpdateStatusLabels();
        }

        #endregion

        #region sim events

        protected virtual void OnSessionInfoUpdated(object sender, SdkWrapper.SessionInfoUpdatedEventArgs e)
        {
            try
            {
                _viewModel.EventType = Sim.Instance.SessionData.EventType;
                _viewModel.SessionType = Sim.Instance.SessionData.SessionType;
                _viewModel.Track = Sim.Instance.SessionData.Track.Name;
                _viewModel.Vehicle = Sim.Instance.Driver.Car.CarName;

                YamlQuery query = e.SessionInfo["DriverInfo"]["DriverSetupName"];
                string setupName = GetYamlQueryResult(query);
                _viewModel.SetupName = setupName;

                //// The session info has updated
                //bool shouldUpdateGrid = false;

                //// Let's check every driver for a new lap
                //foreach (var driver in Sim.Instance.Drivers)
                //{
                //    // Ignore if there are no results yet
                //    if (driver.CurrentResults == null) continue;

                //    // Get the number of laps this driver has completed
                //    var currentLap = driver.CurrentResults.LapsComplete;

                //    // Check what lap this driver was on the last update
                //    int? previousLap = null;
                //    if (previousLaps.ContainsKey(driver.Id))
                //    {
                //        // We already stored their previous lap
                //        previousLap = previousLaps[driver.Id];

                //        // Then update the lap number to the current lap
                //        previousLaps[driver.Id] = currentLap;
                //    }
                //    else
                //    {
                //        // We didn't store their lap yet, so add it
                //        previousLaps.Add(driver.Id, currentLap);
                //    }

                //    // Check if their lap number has changed
                //    if (previousLap == null || previousLap.Value < currentLap)
                //    {
                //        // Lap has changed, grab their laptime and add to the list of lap entries
                //        var lastTime = driver.CurrentResults.LastTime;

                //        var entry = new LapEntry();
                //        entry.CustomerId = driver.CustId;
                //        entry.Name = driver.Name;
                //        entry.CarNumber = driver.CarNumber;

                //        entry.Lap = lastTime.LapNumber;
                //        entry.Laptime = lastTime.Value;
                //        entry.LaptimeDisplay = lastTime.Display;

                //        laps.Add(entry);

                //        // After we checked every driver we need to update the grid to reflect the changes
                //        shouldUpdateGrid = true;
                //    }
                //}

                //if (shouldUpdateGrid)
                //{
                //    bindingSource.ResetBindings(false);
                //}
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex, "Error parsing session yaml");
            }
        }

        protected virtual void OnSimConnected(object sender, EventArgs eventArgs)
        {
            _viewModel.Connected = true;
        }

        protected virtual void OnSimDisconnected(object sender, EventArgs eventArgs)
        {
            _viewModel.Connected = false;
        }

        protected virtual void OnTelemetryInfoUpdated(object sender, SdkWrapper.TelemetryUpdatedEventArgs e)
        {
            try
            {
                _viewModel.ActivityStatus = e.TelemetryInfo.IsOnTrack.Value ?
                    ActivityStatus.Track :
                    ActivityStatus.Garage;
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex, "Error parsing live telemetry");
            }
        }

        #endregion

        #region monitor service events

        // Telemetry File

        protected virtual void _telemetryDirectoryMonitor_FileServiceError(object sender, System.IO.ErrorEventArgs e)
        {
            ExceptionHandler(e.GetException(), "Error in TelemetryMonitor");
        }

        protected virtual void _telemetryDirectoryMonitor_FileCreated(object sender, Internal.Models.DirectoryMonitorEventArgs e)
        {
            _context.Post(
                    async delegate
                    {
                        SessionRunViewModel sessionRunViewModel = await TelemetryFileCreatedAsync(e.FileName, true).ConfigureAwait(true);

                        _viewModel.SessionRuns.Add(sessionRunViewModel);
                    }, null);
        }

        #endregion

        #region view events

        protected virtual void SessionRuns_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;

            if (e.ListChangedType == ListChangedType.ItemAdded)
            {
                HighlightFastestLap(dgv);
            }

            foreach (DataGridViewRow row in dgv.Rows)
            {
                row.Selected = false;
            }

            if (dgv.Rows.Count > 1)
            {
                dgv.Rows[dgv.Rows.Count - 2].Selected = true;
                dgv.Rows[dgv.Rows.Count - 1].Selected = true;
                dgv.FirstDisplayedScrollingRowIndex = dgv.SelectedRows[0].Index;
            }
            else if (dgv.Rows.Count > 0)
            {
                dgv.Rows[dgv.Rows.Count - 1].Selected = true;
                dgv.FirstDisplayedScrollingRowIndex = dgv.SelectedRows[0].Index;
            }
        }

        protected virtual void SessionRuns_SelectionChanged(object sender, EventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;

            var selected = dgv.SelectedRows.OfType<DataGridViewRow>().Select(r => r.DataBoundItem as SessionRunViewModel).ToList();

            var toRemove = _viewModel.SelectedSessionRuns.Except(selected).ToList();
            toRemove.ForEach(r => _viewModel.SelectedSessionRuns.Remove(r));

            var toAdd = selected.Except(_viewModel.SelectedSessionRuns).ToList();
            toAdd.ForEach(r => _viewModel.SelectedSessionRuns.Add(r));

            DisplaySelectedLaps();

            DisplaySelectedSessionRunTireSheets();
        }

        #endregion

        #endregion

        #region private

        private void InitializeBinding()
        {
            _viewModel.PropertyChanged += _viewModel_PropertyChanged;

            _sessionRunsBindingSource = new BindingSource(_viewModel, nameof(_viewModel.SessionRuns));
            _view.SessionRuns.SelectionChanged += SessionRuns_SelectionChanged;
            _view.SessionRuns.DataBindingComplete += SessionRuns_DataBindingComplete;
            _view.SessionRuns.DataSource = _sessionRunsBindingSource;

            _selectedLapsBindingSource = new BindingSource(_lapComparisonSet, nameof(_lapComparisonSet.LapsCompared));
            _view.SelectedLapsComparison.DataSource = _selectedLapsBindingSource;
        }

        private void InitializeRunGridColumns()
        {
            _view.SessionRuns.EnableHeadersVisualStyles = false;
            _view.SessionRuns.AllowUserToResizeColumns = true;
            _view.SessionRuns.AllowUserToOrderColumns = true;
            _view.SessionRuns.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            _view.SessionRuns.Font = new Font("Arial", 10, FontStyle.Regular);
            _view.SessionRuns.GridColor = Color.DimGray;
            _view.SessionRuns.BackgroundColor = Color.Black;
            _view.SessionRuns.CellBorderStyle = DataGridViewCellBorderStyle.None;
            _view.SessionRuns.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            _view.SessionRuns.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            _view.SessionRuns.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _view.SessionRuns.DefaultCellStyle.SelectionBackColor = Color.FromArgb(32, 32, 32);
            _view.SessionRuns.DefaultCellStyle.SelectionForeColor = Color.White;
            _view.SessionRuns.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _view.SessionRuns.DefaultCellStyle.Font = new Font("Arial", 10, FontStyle.Regular);
            _view.SessionRuns.DefaultCellStyle.BackColor = Color.Black;
            _view.SessionRuns.DefaultCellStyle.ForeColor = Color.LightGray;
            _view.SessionRuns.RowHeadersDefaultCellStyle.BackColor = Color.Black;
            _view.SessionRuns.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10, FontStyle.Bold);
            _view.SessionRuns.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _view.SessionRuns.ColumnHeadersDefaultCellStyle.BackColor = Color.Black;
            _view.SessionRuns.ColumnHeadersDefaultCellStyle.ForeColor = Color.LightGray;
            
            _view.SessionRuns.Columns[_idColumnIdx].HeaderText = "#";
            _view.SessionRuns.Columns[_idColumnIdx].SortMode = DataGridViewColumnSortMode.Automatic;
            _view.SessionRuns.Columns[_idColumnIdx].HeaderCell.Style.Font = new Font("Arial", 10, FontStyle.Bold);
            _view.SessionRuns.Columns[_idColumnIdx].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _view.SessionRuns.Columns[_idColumnIdx].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            
            _view.SessionRuns.Columns[_startTimeColumnIdx].Visible = false;
            _view.SessionRuns.Columns[_startTimeColumnIdx].HeaderText = "Timestamp";

            _view.SessionRuns.Columns[_eventTypeColumnIdx].Visible = false;
            _view.SessionRuns.Columns[_sessionTypeColumnIdx].Visible = false;
            _view.SessionRuns.Columns[_lapCountColumnIdx].HeaderText = "# Laps";
            _view.SessionRuns.Columns[_lapCountColumnIdx].SortMode = DataGridViewColumnSortMode.Automatic;
            _view.SessionRuns.Columns[_lapCountColumnIdx].HeaderCell.Style.Font = new Font("Arial", 10, FontStyle.Bold);
            _view.SessionRuns.Columns[_lapCountColumnIdx].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _view.SessionRuns.Columns[_lapCountColumnIdx].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            _view.SessionRuns.Columns[_lapAverageCellIdx].HeaderText = "Avg";
            _view.SessionRuns.Columns[_lapAverageCellIdx].DefaultCellStyle.Format = "N2";
            _view.SessionRuns.Columns[_lapAverageCellIdx].SortMode = DataGridViewColumnSortMode.Automatic;
            _view.SessionRuns.Columns[_lapAverageCellIdx].HeaderCell.Style.Font = new Font("Arial", 10, FontStyle.Bold);
            _view.SessionRuns.Columns[_lapAverageCellIdx].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _view.SessionRuns.Columns[_lapAverageCellIdx].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            _view.SessionRuns.Columns[_bestLapTimeCellIdx].HeaderText = "Best";
            _view.SessionRuns.Columns[_bestLapTimeCellIdx].DefaultCellStyle.Format = "N2";
            _view.SessionRuns.Columns[_bestLapTimeCellIdx].SortMode = DataGridViewColumnSortMode.Automatic;
            _view.SessionRuns.Columns[_bestLapTimeCellIdx].HeaderCell.Style.Font = new Font("Arial", 10, FontStyle.Bold);
            _view.SessionRuns.Columns[_bestLapTimeCellIdx].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _view.SessionRuns.Columns[_bestLapTimeCellIdx].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            _view.SessionRuns.Columns[_stdDevColumnIdx].HeaderText = "Std Dev";
            _view.SessionRuns.Columns[_stdDevColumnIdx].DefaultCellStyle.Format = "N2";
            _view.SessionRuns.Columns[_stdDevColumnIdx].SortMode = DataGridViewColumnSortMode.Automatic;
            _view.SessionRuns.Columns[_stdDevColumnIdx].HeaderCell.Style.Font = new Font("Arial", 10, FontStyle.Bold);
            _view.SessionRuns.Columns[_stdDevColumnIdx].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _view.SessionRuns.Columns[_stdDevColumnIdx].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            _view.SessionRuns.Columns[_tenLapEstimateColumnIdx].Visible = false;

            _view.SessionRuns.Columns[_sessionStartLapColumnIdx].HeaderText = "From";
            _view.SessionRuns.Columns[_sessionStartLapColumnIdx].DisplayIndex = 2;
            _view.SessionRuns.Columns[_sessionStartLapColumnIdx].HeaderCell.Style.Font = new Font("Arial", 10, FontStyle.Bold);
            _view.SessionRuns.Columns[_sessionStartLapColumnIdx].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _view.SessionRuns.Columns[_sessionStartLapColumnIdx].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            _view.SessionRuns.Columns[_sessionEndLapCellIdx].HeaderText = "To";
            _view.SessionRuns.Columns[_sessionEndLapCellIdx].DisplayIndex = 3;
            _view.SessionRuns.Columns[_sessionEndLapCellIdx].HeaderCell.Style.Font = new Font("Arial", 10, FontStyle.Bold);
            _view.SessionRuns.Columns[_sessionEndLapCellIdx].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _view.SessionRuns.Columns[_sessionEndLapCellIdx].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            _view.SessionRuns.Columns[_validLapCountColumnIdx].Visible = false;
            _view.SessionRuns.Columns[_coreLapCountColumnIdx].Visible = false;

            for (int i = 13; i <= _view.SessionRuns.Columns.Count - 1; i++)
            {
                _view.SessionRuns.Columns[i].Visible = false;
            }
        }

        private void InitializeLapGridColumns()
        {
            _view.SelectedLapsComparison.EnableHeadersVisualStyles = false;

            _view.SelectedLapsComparison.AllowUserToResizeColumns = true;
            _view.SelectedLapsComparison.AllowUserToOrderColumns = true;
            _view.SelectedLapsComparison.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            _view.SelectedLapsComparison.Font = new Font("Arial", 10, FontStyle.Regular);
            _view.SelectedLapsComparison.GridColor = Color.DimGray;
            _view.SelectedLapsComparison.BackgroundColor = Color.Black;
            _view.SelectedLapsComparison.CellBorderStyle = DataGridViewCellBorderStyle.None;
            _view.SelectedLapsComparison.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            _view.SelectedLapsComparison.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            _view.SelectedLapsComparison.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _view.SelectedLapsComparison.DefaultCellStyle.SelectionBackColor = Color.FromArgb(32, 32, 32);
            _view.SelectedLapsComparison.DefaultCellStyle.SelectionForeColor = Color.White;
            _view.SelectedLapsComparison.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _view.SelectedLapsComparison.DefaultCellStyle.Font = new Font("Arial", 10, FontStyle.Regular);
            _view.SelectedLapsComparison.DefaultCellStyle.BackColor = Color.Black;
            _view.SelectedLapsComparison.DefaultCellStyle.ForeColor = Color.LightGray;

            _view.SelectedLapsComparison.RowHeadersDefaultCellStyle.BackColor = Color.Black;

            _view.SelectedLapsComparison.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10, FontStyle.Bold);
            _view.SelectedLapsComparison.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _view.SelectedLapsComparison.ColumnHeadersDefaultCellStyle.BackColor = Color.Black;
            _view.SelectedLapsComparison.ColumnHeadersDefaultCellStyle.ForeColor = Color.LightGray;

            _view.SelectedLapsComparison.Columns[_lapNumberColumnIdx].HeaderText = "Lap #";
            _view.SelectedLapsComparison.Columns[_lapNumberColumnIdx].HeaderCell.Style.Font = new Font("Arial", 10, FontStyle.Bold);
            _view.SelectedLapsComparison.Columns[_lapNumberColumnIdx].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _view.SelectedLapsComparison.Columns[_lapNumberColumnIdx].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            _view.SelectedLapsComparison.Columns[_firstLapColumnIdx].HeaderText = "Run 1";
            _view.SelectedLapsComparison.Columns[_firstLapColumnIdx].DefaultCellStyle.Format = "N2";
            _view.SelectedLapsComparison.Columns[_firstLapColumnIdx].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            _view.SelectedLapsComparison.Columns[_firstLapColumnIdx].HeaderCell.Style.BackColor = _seriesColors[0];
            _view.SelectedLapsComparison.Columns[_firstLapColumnIdx].HeaderCell.Style.ForeColor = _run1TextColor;
            _view.SelectedLapsComparison.Columns[_firstLapColumnIdx].HeaderCell.Style.Font = new Font("Arial", 10, FontStyle.Bold);
            _view.SelectedLapsComparison.Columns[_firstLapColumnIdx].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            _view.SelectedLapsComparison.Columns[_secondLapColumnIdx].HeaderText = "Run 2";
            _view.SelectedLapsComparison.Columns[_secondLapColumnIdx].DefaultCellStyle.Format = "N2";
            _view.SelectedLapsComparison.Columns[_secondLapColumnIdx].HeaderCell.Style.BackColor = _seriesColors[1];
            _view.SelectedLapsComparison.Columns[_secondLapColumnIdx].HeaderCell.Style.ForeColor = _run2TextColor;
            _view.SelectedLapsComparison.Columns[_secondLapColumnIdx].HeaderCell.Style.Font = new Font("Arial", 10, FontStyle.Bold);
            _view.SelectedLapsComparison.Columns[_secondLapColumnIdx].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            _view.SelectedLapsComparison.Columns[_secondLapColumnIdx].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            _view.SelectedLapsComparison.Columns[_lapDeltaColumnIdx].HeaderText = "+/-";
            _view.SelectedLapsComparison.Columns[_lapDeltaColumnIdx].HeaderCell.Style.Font = new Font("Arial", 10, FontStyle.Bold);
            _view.SelectedLapsComparison.Columns[_lapDeltaColumnIdx].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            _view.SelectedLapsComparison.Columns[_lapDeltaColumnIdx].DefaultCellStyle.Format = "N2";
            _view.SelectedLapsComparison.Columns[_lapDeltaColumnIdx].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            _view.SelectedLapsComparison.Columns[_runDeltaColumnIdx].HeaderText = "Run +/-";
            _view.SelectedLapsComparison.Columns[_runDeltaColumnIdx].HeaderCell.Style.Font = new Font("Arial", 10, FontStyle.Bold);
            _view.SelectedLapsComparison.Columns[_runDeltaColumnIdx].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            _view.SelectedLapsComparison.Columns[_runDeltaColumnIdx].DefaultCellStyle.Format = "N2";
            _view.SelectedLapsComparison.Columns[_runDeltaColumnIdx].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            _view.SelectedLapsComparison.AutoResizeColumns();
        }

        private void HighlightFastestLap(DataGridView dgv)
        {
            float bestLapTime = 999F;
            float bestLapAverage = 999F;
            int bestLapTimeIndex = 0;
            int bestLapAverageIndex = 0;

            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (float.Parse(row.Cells[_bestLapTimeCellIdx].Value.ToString()) < bestLapTime)
                {
                    bestLapTime = float.Parse(row.Cells[_bestLapTimeCellIdx].Value.ToString());
                    bestLapTimeIndex = row.Index;
                }
                if (float.Parse(row.Cells[_lapAverageCellIdx].Value.ToString()) < bestLapAverage)
                {
                    bestLapAverage = float.Parse(row.Cells[_lapAverageCellIdx].Value.ToString());
                    bestLapAverageIndex = row.Index;
                }
            }

            dgv.Rows[bestLapTimeIndex].Cells[_bestLapTimeCellIdx].Style.BackColor = Color.Lime;
            dgv.Rows[bestLapTimeIndex].Cells[_bestLapTimeCellIdx].Style.ForeColor = Color.Black;
            dgv.Rows[bestLapTimeIndex].Cells[_bestLapTimeCellIdx].Style.SelectionBackColor = Color.Lime;
            dgv.Rows[bestLapTimeIndex].Cells[_bestLapTimeCellIdx].Style.SelectionForeColor = Color.Black;

            dgv.Rows[bestLapAverageIndex].Cells[_lapAverageCellIdx].Style.BackColor = Color.LimeGreen;
            dgv.Rows[bestLapAverageIndex].Cells[_lapAverageCellIdx].Style.ForeColor = Color.Black;
            dgv.Rows[bestLapAverageIndex].Cells[_lapAverageCellIdx].Style.SelectionBackColor = Color.LimeGreen;
            dgv.Rows[bestLapAverageIndex].Cells[_lapAverageCellIdx].Style.SelectionForeColor = Color.Black;
        }

        private void HighlightLapComparisons()
        {
            float bestRun1LapTime = 999F;
            float bestRun2LapTime = 999F;
            int bestRun1LapTimeIndex = 0;
            int bestRun2LapTimeIndex = 0;

            foreach (DataGridViewRow row in _view.SelectedLapsComparison.Rows)
            {
                if (row.Cells[_firstLapColumnIdx].Value != null && float.Parse(row.Cells[_firstLapColumnIdx].Value.ToString()) < bestRun1LapTime)
                {
                    bestRun1LapTime = float.Parse(row.Cells[_firstLapColumnIdx].Value.ToString());
                    bestRun1LapTimeIndex = row.Index;
                }
                if (row.Cells[_secondLapColumnIdx].Value != null && float.Parse(row.Cells[_secondLapColumnIdx].Value.ToString()) < bestRun2LapTime)
                {
                    bestRun2LapTime = float.Parse(row.Cells[_secondLapColumnIdx].Value.ToString());
                    bestRun2LapTimeIndex = row.Index;
                }
                if (row.Cells[_lapDeltaColumnIdx].Value != null && float.Parse(row.Cells[_lapDeltaColumnIdx].Value.ToString()) < 0)
                {
                    row.Cells[_lapDeltaColumnIdx].Style.BackColor = Color.Green;
                    row.Cells[_lapDeltaColumnIdx].Style.ForeColor = Color.Black;
                    row.Cells[_lapDeltaColumnIdx].Style.SelectionBackColor = Color.Green;
                    row.Cells[_lapDeltaColumnIdx].Style.SelectionForeColor = Color.Black;
                }
                if (row.Cells[_runDeltaColumnIdx].Value != null && float.Parse(row.Cells[_runDeltaColumnIdx].Value.ToString()) < 0)
                {
                    row.Cells[_runDeltaColumnIdx].Style.BackColor = Color.LimeGreen;
                    row.Cells[_runDeltaColumnIdx].Style.ForeColor = Color.Black;
                    row.Cells[_runDeltaColumnIdx].Style.SelectionBackColor = Color.LimeGreen;
                    row.Cells[_runDeltaColumnIdx].Style.SelectionForeColor = Color.Black;
                }
            }

            if (bestRun1LapTime < 999)
            {
                _view.SelectedLapsComparison.Rows[bestRun1LapTimeIndex].Cells[_firstLapColumnIdx].Style.BackColor = Color.DarkGreen;
                _view.SelectedLapsComparison.Rows[bestRun1LapTimeIndex].Cells[_firstLapColumnIdx].Style.ForeColor = Color.WhiteSmoke;
                _view.SelectedLapsComparison.Rows[bestRun1LapTimeIndex].Cells[_firstLapColumnIdx].Style.SelectionBackColor = Color.DarkGreen;
                _view.SelectedLapsComparison.Rows[bestRun1LapTimeIndex].Cells[_firstLapColumnIdx].Style.SelectionForeColor = Color.WhiteSmoke;
            }

            if (bestRun2LapTime < 999)
            {
                _view.SelectedLapsComparison.Rows[bestRun2LapTimeIndex].Cells[_secondLapColumnIdx].Style.BackColor = Color.DarkGreen;
                _view.SelectedLapsComparison.Rows[bestRun2LapTimeIndex].Cells[_secondLapColumnIdx].Style.ForeColor = Color.WhiteSmoke;
                _view.SelectedLapsComparison.Rows[bestRun2LapTimeIndex].Cells[_secondLapColumnIdx].Style.SelectionBackColor = Color.DarkGreen;
                _view.SelectedLapsComparison.Rows[bestRun2LapTimeIndex].Cells[_secondLapColumnIdx].Style.SelectionForeColor = Color.WhiteSmoke;
            }
        }

        private void InitializeMonitors()
        {
            _telemetryDirectoryMonitor = new TelemetryDirectoryMonitorSevice();
            _telemetryDirectoryMonitor.FileCreated += _telemetryDirectoryMonitor_FileCreated;
            _telemetryDirectoryMonitor.FileServiceError += _telemetryDirectoryMonitor_FileServiceError;

            _telemetryDirectoryMonitor.StartService();
        }

        private void InitializeWrapper()
        {
            // Listen for relevant events
            Sim.Instance.Connected += OnSimConnected;
            Sim.Instance.Disconnected += OnSimDisconnected;
            Sim.Instance.SessionInfoUpdated += OnSessionInfoUpdated;
            Sim.Instance.TelemetryUpdated += OnTelemetryInfoUpdated;

            // if (_autoStartSim && iRacingIsRunning)
            Sim.Instance.Start(1);
        }

        private bool IsFileReady(string filename)
        {
            // If the file can be opened for exclusive access it means that the file
            // is no longer locked by another process.
            try
            {
                using (FileStream inputStream = File.Open(filename, FileMode.Open, FileAccess.Read, FileShare.None))
                    return inputStream.Length > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private IDictionary<string, TireSheetValues> GetTireSheetValues(SessionRunViewModel sessionRun)
        {
            IDictionary<string, TireSheetValues> tsvDictionary = new Dictionary<string, TireSheetValues>();

            var tireSheetViewModel = sessionRun.TireSheet;

            TireSheetValues tsvTelemetry = new TireSheetValues()
            {
                Run = sessionRun.Id.ToString(),
                Setup = $"Run {sessionRun.Id}  [Telemetry]",
                AverageLap = sessionRun.CoreLapsAverage,
                BestLap = sessionRun.CoreLapsBestLapTime,
                Laps = sessionRun.CoreLaps.Count()
            };

            for (int i = 0; i < 4; i++)
            {
                TirePosition tirePosition = (TirePosition)i;
                tsvTelemetry.Tires[tirePosition].ColdPsi = (double)tireSheetViewModel.Tires[(int)tirePosition].ColdPsi;
                tsvTelemetry.Tires[tirePosition].HotPsi = (double)tireSheetViewModel.Tires[(int)tirePosition].HotPsi;

                tsvTelemetry.Tires[tirePosition].Temperatures.Inside = (double)tireSheetViewModel.Tires[(int)tirePosition].Temperatures[(int)TreadPosition.Inside];
                tsvTelemetry.Tires[tirePosition].Temperatures.Middle = (double)tireSheetViewModel.Tires[(int)tirePosition].Temperatures[(int)TreadPosition.Middle];
                tsvTelemetry.Tires[tirePosition].Temperatures.Outside = (double)tireSheetViewModel.Tires[(int)tirePosition].Temperatures[(int)TreadPosition.Outside];

                tsvTelemetry.Tires[tirePosition].Wear.Inside = (double)tireSheetViewModel.Tires[(int)tirePosition].Wear[(int)TreadPosition.Inside];
                tsvTelemetry.Tires[tirePosition].Wear.Middle = (double)tireSheetViewModel.Tires[(int)tirePosition].Wear[(int)TreadPosition.Middle];
                tsvTelemetry.Tires[tirePosition].Wear.Outside = (double)tireSheetViewModel.Tires[(int)tirePosition].Wear[(int)TreadPosition.Outside];
            }

            tsvDictionary.Add("Telemetry", tsvTelemetry);

            TireSheetValues tsvSetup = new TireSheetValues()
            {
                Run = sessionRun.Id.ToString(),
                Setup = $"Run {sessionRun.Id}  [Setup]",
                AverageLap = sessionRun.CoreLapsAverage,
                BestLap = sessionRun.CoreLapsBestLapTime,
                Laps = sessionRun.CoreLaps.Count()
            };

            tireSheetViewModel = sessionRun.TireSheetFromSetup;

            for (int i = 0; i < 4; i++)
            {
                TirePosition tirePosition = (TirePosition)i;
                tsvSetup.Tires[tirePosition].ColdPsi = (double)tireSheetViewModel.Tires[(int)tirePosition].ColdPsi;
                tsvSetup.Tires[tirePosition].HotPsi = (double)tireSheetViewModel.Tires[(int)tirePosition].HotPsi;

                tsvSetup.Tires[tirePosition].Temperatures.Inside = (double)tireSheetViewModel.Tires[(int)tirePosition].Temperatures[(int)TreadPosition.Inside];
                tsvSetup.Tires[tirePosition].Temperatures.Middle = (double)tireSheetViewModel.Tires[(int)tirePosition].Temperatures[(int)TreadPosition.Middle];
                tsvSetup.Tires[tirePosition].Temperatures.Outside = (double)tireSheetViewModel.Tires[(int)tirePosition].Temperatures[(int)TreadPosition.Outside];

                tsvSetup.Tires[tirePosition].Wear.Inside = (double)tireSheetViewModel.Tires[(int)tirePosition].Wear[(int)TreadPosition.Inside];
                tsvSetup.Tires[tirePosition].Wear.Middle = (double)tireSheetViewModel.Tires[(int)tirePosition].Wear[(int)TreadPosition.Middle];
                tsvSetup.Tires[tirePosition].Wear.Outside = (double)tireSheetViewModel.Tires[(int)tirePosition].Wear[(int)TreadPosition.Outside];
            }

            tsvDictionary.Add("Setup", tsvSetup);

            return tsvDictionary;
        }

        private void DisplaySelectedSessionRunTireSheets()
        {
            if (_viewModel.SelectedSessionRuns.Count == 0)
            {
                _view.TireSheetView.ClearDisplay();
                return;
            }
            else if (_viewModel.SelectedSessionRuns.Count == 1)
            {
                _view.TireSheetView2.Visible = true;

                SessionRunViewModel sessionRun = _viewModel.SelectedSessionRuns.LastOrDefault();
                TireSheetViewModel tireSheetViewModel = sessionRun.TireSheet;

                IDictionary<string, TireSheetValues> tsvDictionary = GetTireSheetValues(sessionRun);

                TireSheetValues tsv1 = tsvDictionary["Telemetry"];

                _view.TireSheetView.HeaderBackColor = _seriesColors[0];
                _view.TireSheetView.HeaderForeColor = Color.White;
                _view.TireSheetView.InfoBackColor = _seriesColors[0];
                _view.TireSheetView.InfoForeColor = Color.White;

                _view.TireSheetView.Model = tsv1;

                TireSheetValues tsvSetup = tsvDictionary["Setup"];

                _view.TireSheetView2.HeaderBackColor = _seriesColors[0];
                _view.TireSheetView2.HeaderForeColor = Color.White;
                _view.TireSheetView2.InfoBackColor = _seriesColors[0];
                _view.TireSheetView2.InfoForeColor = Color.White;

                _view.TireSheetView2.Model = tsvSetup;
            }
            else if (_viewModel.SelectedSessionRuns.Count > 1)
            {
                _view.TireSheetView2.Visible = true;

                SessionRunViewModel sessionRun = _viewModel.SelectedSessionRuns.LastOrDefault();
                TireSheetViewModel tireSheetViewModel = sessionRun.TireSheet;

                TireSheetValues tsv = new TireSheetValues()
                {
                    Run = sessionRun.Id.ToString(),
                    Setup = $"Run {sessionRun.Id}",
                    AverageLap = sessionRun.CoreLapsAverage,
                    BestLap = sessionRun.CoreLapsBestLapTime,
                    Laps = sessionRun.CoreLaps.Count()
                };

                for (int i = 0; i < 4; i++)
                {
                    TirePosition tirePosition = (TirePosition)i;
                    tsv.Tires[tirePosition].ColdPsi = (double)tireSheetViewModel.Tires[(int)tirePosition].ColdPsi;
                    tsv.Tires[tirePosition].HotPsi = (double)tireSheetViewModel.Tires[(int)tirePosition].HotPsi;

                    tsv.Tires[tirePosition].Temperatures.Inside = (double)tireSheetViewModel.Tires[(int)tirePosition].Temperatures[(int)TreadPosition.Inside];
                    tsv.Tires[tirePosition].Temperatures.Middle = (double)tireSheetViewModel.Tires[(int)tirePosition].Temperatures[(int)TreadPosition.Middle];
                    tsv.Tires[tirePosition].Temperatures.Outside = (double)tireSheetViewModel.Tires[(int)tirePosition].Temperatures[(int)TreadPosition.Outside];

                    tsv.Tires[tirePosition].Wear.Inside = (double)tireSheetViewModel.Tires[(int)tirePosition].Wear[(int)TreadPosition.Inside];
                    tsv.Tires[tirePosition].Wear.Middle = (double)tireSheetViewModel.Tires[(int)tirePosition].Wear[(int)TreadPosition.Middle];
                    tsv.Tires[tirePosition].Wear.Outside = (double)tireSheetViewModel.Tires[(int)tirePosition].Wear[(int)TreadPosition.Outside];
                }

                _view.TireSheetView2.HeaderBackColor = _seriesColors[1];
                _view.TireSheetView2.HeaderForeColor = Color.White;
                _view.TireSheetView2.InfoBackColor = _seriesColors[1];
                _view.TireSheetView2.InfoForeColor = Color.White;

                _view.TireSheetView2.Model = tsv;

                SessionRunViewModel sessionRun2 = _viewModel.SelectedSessionRuns[_viewModel.SelectedSessionRuns.Count - 2];
                TireSheetViewModel tireSheetViewModel2 = sessionRun2.TireSheet;

                TireSheetValues tsv2 = new TireSheetValues()
                {
                    Run = sessionRun2.Id.ToString(),
                    Setup = $"Run {sessionRun2.Id}",
                    AverageLap = sessionRun2.CoreLapsAverage,
                    BestLap = sessionRun2.CoreLapsBestLapTime,
                    Laps = sessionRun2.CoreLaps.Count()
                };

                for (int i = 0; i < 4; i++)
                {
                    TirePosition tirePosition = (TirePosition)i;
                    tsv2.Tires[tirePosition].ColdPsi = (double)tireSheetViewModel2.Tires[(int)tirePosition].ColdPsi;
                    tsv2.Tires[tirePosition].HotPsi = (double)tireSheetViewModel2.Tires[(int)tirePosition].HotPsi;

                    tsv2.Tires[tirePosition].Temperatures.Inside = (double)tireSheetViewModel2.Tires[(int)tirePosition].Temperatures[(int)TreadPosition.Inside];
                    tsv2.Tires[tirePosition].Temperatures.Middle = (double)tireSheetViewModel2.Tires[(int)tirePosition].Temperatures[(int)TreadPosition.Middle];
                    tsv2.Tires[tirePosition].Temperatures.Outside = (double)tireSheetViewModel2.Tires[(int)tirePosition].Temperatures[(int)TreadPosition.Outside];

                    tsv2.Tires[tirePosition].Wear.Inside = (double)tireSheetViewModel2.Tires[(int)tirePosition].Wear[(int)TreadPosition.Inside];
                    tsv2.Tires[tirePosition].Wear.Middle = (double)tireSheetViewModel2.Tires[(int)tirePosition].Wear[(int)TreadPosition.Middle];
                    tsv2.Tires[tirePosition].Wear.Outside = (double)tireSheetViewModel2.Tires[(int)tirePosition].Wear[(int)TreadPosition.Outside];
                }

                _view.TireSheetView.HeaderBackColor = _seriesColors[0];
                _view.TireSheetView.HeaderForeColor = Color.White;
                _view.TireSheetView.InfoBackColor = _seriesColors[0];
                _view.TireSheetView.InfoForeColor = Color.White;

                _view.TireSheetView.Model = tsv2;
            }
        }

        private void DisplaySelectedLaps()
        {
            if (_viewModel.SelectedSessionRuns.Count == 0)
            {
                _view.SelectedLapsComparison.DataSource = new List<LapComparison>();
                _view.LapTimeChart.Clear();
                return;
            }

            string run1Header = null;
            string run2Header = "-";

            LapComparisonSet lapComparisonSet = new LapComparisonSet();

            if (_viewModel.SelectedSessionRuns.Count == 1)
            {
                lapComparisonSet.FirstRunLaps = _viewModel.SelectedSessionRuns[_viewModel.SelectedSessionRuns.Count - 1].Laps;
                run1Header = $"Run {_viewModel.SelectedSessionRuns[_viewModel.SelectedSessionRuns.Count - 1].Id}";
            }
            else if (_viewModel.SelectedSessionRuns.Count > 1)
            {
                lapComparisonSet.FirstRunLaps = _viewModel.SelectedSessionRuns[_viewModel.SelectedSessionRuns.Count - 2].Laps;
                run1Header = $"Run {_viewModel.SelectedSessionRuns[_viewModel.SelectedSessionRuns.Count - 2].Id}";

                lapComparisonSet.SecondRunLaps = _viewModel.SelectedSessionRuns[_viewModel.SelectedSessionRuns.Count - 1].Laps;
                run2Header = $"Run {_viewModel.SelectedSessionRuns[_viewModel.SelectedSessionRuns.Count - 1].Id}";
            }

            _view.SelectedLapsComparison.DataSource = lapComparisonSet.LapsCompared;

            _view.SelectedLapsComparison.Columns[_firstLapColumnIdx].HeaderText = run1Header;
            _view.SelectedLapsComparison.Columns[_secondLapColumnIdx].HeaderText = run2Header;

            HighlightLapComparisons();

            IList<LapTimeChartViewModel> chartLaps = new List<LapTimeChartViewModel>();
            int idx = 0;
            foreach (SessionRunViewModel sessionRun in _viewModel.SelectedSessionRuns)
            {
                int colorIdx = sessionRun.Id % _seriesColors.Keys.Count;
                Console.WriteLine($"sessionRun.Id;{sessionRun.Id} _seriesColors.Keys.Count:{_seriesColors.Keys.Count} colorIdx:{colorIdx} _seriesColors[colorIdx]:{_seriesColors[colorIdx]}");
                chartLaps.Add(new LapTimeChartViewModel()
                {
                    RunId = sessionRun.Id,
                    Laps = sessionRun.Laps.Select(l => new LapTimeChartViewModel.LapInfo()
                    {
                        LapNumber = l.RunLapNumber,
                        LapTime = l.LapTime
                    }).ToList(),
                    SeriesLineColor = _seriesColors[idx % _seriesColors.Keys.Count],
                    SeriesLineWidth = 1,
                    Title = $"Run {sessionRun.Id}"
                });
                idx++;
            }

            _view.LapTimeChart.DisplayLaps(chartLaps);
        }

        private async Task<SessionRunViewModel> TelemetryFileCreatedAsync(string path)
        {
            return await TelemetryFileCreatedAsync(path, false);
        }
        private async Task<SessionRunViewModel> TelemetryFileCreatedAsync(string telemetryFilePath, bool backupSetup)
        {
            while (!IsFileReady(telemetryFilePath)) { }

            ITelemetryFileReader telemetryFileReader = TelemetryFileReaderFactory.GetTelemetryFileReader(telemetryFilePath);

            ITelemetryFile telemetryFile = await telemetryFileReader.ReadTelemetryFileAsync();

            if (backupSetup)
            {
                string setupBackupFile = await BackupSetupFileAsync(telemetryFilePath, telemetryFile);
            }

            return GetNewSessionRunViewModel(telemetryFile);
        }

        private async Task<string> BackupSetupFileAsync(string telemetryFilePath, ITelemetryFile telemetryFile)
        {
            string setupBackupFile = null;

            try
            {
                var setupName = telemetryFile.SessionInfo.DriverInfo.DriverSetupName;
                int updateCount = telemetryFile.SessionInfo.CarSetup.UpdateCount;
                int driverIndex = telemetryFile.SessionInfo.DriverInfo.DriverCarIdx;
                var setupVehicleDirectory = Path.Combine(SetupRootDirectory, telemetryFile.SessionInfo.DriverInfo.Drivers[driverIndex].CarPath);                

                SetupBackupService setupBackupService = new SetupBackupService(SetupAutoBackupDirectory);

                setupBackupFile = await setupBackupService.BackupSetupFileAsync(telemetryFilePath, setupName, setupVehicleDirectory, updateCount);
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex, $"Error backing up setup file: {ex.Message}");
            }

            return setupBackupFile;
        }

        private SessionRunViewModel GetNewSessionRunViewModel(ITelemetryFile telemetryFile)
        {
            int id = _viewModel.SessionRuns.Count + 1;
            return new SessionRunViewModel()
            {
                Id = id,
                StartTime = DateTime.Now,
                Laps = GetSessionRunLaps(telemetryFile),
                EventType = telemetryFile.SessionInfo.WeekendInfo.EventType.ToString(),
                SessionType = telemetryFile.SessionInfo.ActiveSession.SessionType.ToString(),
                Setup = new SetupViewModel()
                {
                    Name = telemetryFile.SessionInfo.DriverInfo.DriverSetupName,
                    Values = new List<SetupValueViewModel>()
                },
                TireSheet = GetTireSheetViewModel(id, telemetryFile.TireSheet),
                TireSheetFromSetup = GetTireSheetViewModel(id, telemetryFile.TireSheetFromSetup)
            };
        }

        private TireSheetViewModel GetTireSheetViewModel(int id, ITireSheet tireSheet)
        {
            TireSheetViewModel viewModel = new TireSheetViewModel()
            {
                RunId = id
            };

            viewModel.Tires[(int)TirePosition.LF].ColdPsi = tireSheet.LF.ColdPsi;
            viewModel.Tires[(int)TirePosition.LF].HotPsi = tireSheet.LF.HotPsi;
            viewModel.Tires[(int)TirePosition.LF].Temperatures[(int)TreadPosition.Inside] = tireSheet.LF.Temperatures[TreadPosition.Inside];
            viewModel.Tires[(int)TirePosition.LF].Temperatures[(int)TreadPosition.Middle] = tireSheet.LF.Temperatures[TreadPosition.Middle];
            viewModel.Tires[(int)TirePosition.LF].Temperatures[(int)TreadPosition.Outside] = tireSheet.LF.Temperatures[TreadPosition.Outside];
            viewModel.Tires[(int)TirePosition.LF].Wear[(int)TreadPosition.Inside] = tireSheet.LF.Wear[TreadPosition.Inside];
            viewModel.Tires[(int)TirePosition.LF].Wear[(int)TreadPosition.Middle] = tireSheet.LF.Wear[TreadPosition.Middle];
            viewModel.Tires[(int)TirePosition.LF].Wear[(int)TreadPosition.Outside] = tireSheet.LF.Wear[TreadPosition.Outside];

            viewModel.Tires[(int)TirePosition.RF].ColdPsi = tireSheet.RF.ColdPsi;
            viewModel.Tires[(int)TirePosition.RF].HotPsi = tireSheet.RF.HotPsi;
            viewModel.Tires[(int)TirePosition.RF].Temperatures[(int)TreadPosition.Inside] = tireSheet.RF.Temperatures[TreadPosition.Inside];
            viewModel.Tires[(int)TirePosition.RF].Temperatures[(int)TreadPosition.Middle] = tireSheet.RF.Temperatures[TreadPosition.Middle];
            viewModel.Tires[(int)TirePosition.RF].Temperatures[(int)TreadPosition.Outside] = tireSheet.RF.Temperatures[TreadPosition.Outside];
            viewModel.Tires[(int)TirePosition.RF].Wear[(int)TreadPosition.Inside] = tireSheet.RF.Wear[TreadPosition.Inside];
            viewModel.Tires[(int)TirePosition.RF].Wear[(int)TreadPosition.Middle] = tireSheet.RF.Wear[TreadPosition.Middle];
            viewModel.Tires[(int)TirePosition.RF].Wear[(int)TreadPosition.Outside] = tireSheet.RF.Wear[TreadPosition.Outside];

            viewModel.Tires[(int)TirePosition.LR].ColdPsi = tireSheet.LR.ColdPsi;
            viewModel.Tires[(int)TirePosition.LR].HotPsi = tireSheet.LR.HotPsi;
            viewModel.Tires[(int)TirePosition.LR].Temperatures[(int)TreadPosition.Inside] = tireSheet.LR.Temperatures[TreadPosition.Inside];
            viewModel.Tires[(int)TirePosition.LR].Temperatures[(int)TreadPosition.Middle] = tireSheet.LR.Temperatures[TreadPosition.Middle];
            viewModel.Tires[(int)TirePosition.LR].Temperatures[(int)TreadPosition.Outside] = tireSheet.LR.Temperatures[TreadPosition.Outside];
            viewModel.Tires[(int)TirePosition.LR].Wear[(int)TreadPosition.Inside] = tireSheet.LR.Wear[TreadPosition.Inside];
            viewModel.Tires[(int)TirePosition.LR].Wear[(int)TreadPosition.Middle] = tireSheet.LR.Wear[TreadPosition.Middle];
            viewModel.Tires[(int)TirePosition.LR].Wear[(int)TreadPosition.Outside] = tireSheet.LR.Wear[TreadPosition.Outside];

            viewModel.Tires[(int)TirePosition.RR].ColdPsi = tireSheet.RR.ColdPsi;
            viewModel.Tires[(int)TirePosition.RR].HotPsi = tireSheet.RR.HotPsi;
            viewModel.Tires[(int)TirePosition.RR].Temperatures[(int)TreadPosition.Inside] = tireSheet.RR.Temperatures[TreadPosition.Inside];
            viewModel.Tires[(int)TirePosition.RR].Temperatures[(int)TreadPosition.Middle] = tireSheet.RR.Temperatures[TreadPosition.Middle];
            viewModel.Tires[(int)TirePosition.RR].Temperatures[(int)TreadPosition.Outside] = tireSheet.RR.Temperatures[TreadPosition.Outside];
            viewModel.Tires[(int)TirePosition.RR].Wear[(int)TreadPosition.Inside] = tireSheet.RR.Wear[TreadPosition.Inside];
            viewModel.Tires[(int)TirePosition.RR].Wear[(int)TreadPosition.Middle] = tireSheet.RR.Wear[TreadPosition.Middle];
            viewModel.Tires[(int)TirePosition.RR].Wear[(int)TreadPosition.Outside] = tireSheet.RR.Wear[TreadPosition.Outside];

            return viewModel;
        }

        private IList<SessionLapViewModel> GetSessionRunLaps(ITelemetryFile telemetryFile)
        {
            IList<SessionLapViewModel> laps = new List<SessionLapViewModel>();

            int runLapNumber = 1;

            foreach (ILapInfo lap in telemetryFile.Laps)
            {
                laps.Add(new SessionLapViewModel()
                {
                    SessionLapNumber = lap.LapNumber,
                    RunLapNumber = runLapNumber,
                    LapTime = lap.LapTime,
                    Status = lap.LapNumber == -1 ? SessionLapStatus.OutLap : lap.LapNumber == -2 ? SessionLapStatus.InLap : SessionLapStatus.ValidLap
                });

                runLapNumber++;
            }

            return laps;
        }

        private void SetupFileCreated(string path)
        {
            Console.WriteLine($"SetupFileCreated: {path}");
        }

        private void SetupFileUpdated(string path)
        {
            Console.WriteLine($"SetupFileUpdated: {path}");
        }

        private string GetYamlQueryResult(YamlQuery query)
        {
            return GetYamlQueryResult(query, false);
        }
        private string GetYamlQueryResult(YamlQuery query, bool suppressError)
        {

            if (!query.TryGetValue(out string result) && !suppressError)
            {
                try
                {
                    result = query.Value;
                }
                catch (Exception ex)
                {
                    ExceptionHandler(ex, "Error parsing yaml session data");
                }
            }

            return result;
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    if (_telemetryDirectoryMonitor != null)
                    {
                        _telemetryDirectoryMonitor.StopService();
                        _telemetryDirectoryMonitor.Dispose();
                        _telemetryDirectoryMonitor = null;
                    }

                    Sim.Instance.Connected -= OnSimConnected;
                    Sim.Instance.Disconnected -= OnSimDisconnected;
                    Sim.Instance.SessionInfoUpdated -= OnSessionInfoUpdated;
                    Sim.Instance.TelemetryUpdated -= OnTelemetryInfoUpdated;

                    Sim.Instance.Stop();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }
        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion

        #endregion
    }
}
