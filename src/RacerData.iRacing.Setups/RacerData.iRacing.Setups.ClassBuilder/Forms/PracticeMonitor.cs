using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using RacerData.iRacing.Extensions;
using RacerData.iRacing.Service.Sessions;
using RacerData.iRacing.Sessions.Models;
using RacerData.iRacing.Sessions.Ports;
using RacerData.iRacing.Setups.ClassBuilder.Models;
using RacerData.iRacing.Setups.ClassBuilder.Properties;
using RacerData.iRacing.Setups.Modifieds;
using RacerData.iRacing.Telemetry;
using RacerData.iRacing.Telemetry.Extensions;
using RacerData.iRacing.Telemetry.Sdk.Adapters;
using RacerData.iRacing.Telemetry.Sdk.Factories;
using RacerData.Logging;
using RacerData.Logging.Ports;
using TireSheetValues = RacerData.iRacing.Setups.ClassBuilder.Models.TireSheetValues;

namespace RacerData.iRacing.Setups.ClassBuilder.Forms
{
    public partial class PracticeMonitor : Form
    {
        #region consts

        private const string TelemetryDirectory = @"C:\Users\Rob\Documents\iRacing\telemetry";
        private const string TelemetryArchiveRootDirectory = @"C:\iRacingData\telemetry";
        private const string SkModifiedCurrentSetupFile = "-Current-";
        private const string SkModifiedSetupDirectory = @"C:\Users\Rob\Documents\iRacing\setups\skmodified\";
        private const string SkModifiedSetupBackupDirectory = @"C:\Users\Rob\Documents\iRacing\telemetry\setups\skmodified";

        #endregion

        #region delegates

        private delegate void SafeCallDelegate(TireSheetValues model, int displayIndex);
        private delegate void SafeDisplayEventDataListDelegate(IList<EventData> eventDataList);

        #endregion

        #region fields

        private PracticeSession _practiceSessionView;

        private FileSystemWatcher _watcher;
        private IList<EventData> _eventDataList = new List<EventData>();
        private bool _autoBackupSetups = true;
        private bool _loading = false;
        private ILoggerService _logger;
        private IServiceProvider _serviceProvider;

        #endregion

        #region properties

        public IList<TelemetryFileInfo> TelemetryIndex { get; set; } = new List<TelemetryFileInfo>();

        #endregion

        #region ctor

        public PracticeMonitor()
        {
            InitializeComponent();

            if (Settings.Default.WindowLocation != null)
            {
                this.Location = Settings.Default.WindowLocation;
            }
            if (Settings.Default.WindowSize != null)
            {
                this.Size = Settings.Default.WindowSize;
            }
            this.WindowState = Settings.Default.WindowState;
            if (this.WindowState == FormWindowState.Normal)
            {
                this.Size = Settings.Default.WindowSize;
            }
            this.StartPosition = Settings.Default.WindowStartPosition;

            try
            {
                ConfigureServices();
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }

        #endregion

        #region common

        private void ExceptionHandler(Exception ex)
        {
            ExceptionHandler(ex, "Exception in TelemetryTestApp");
        }
        private void ExceptionHandler(Exception ex, string message)
        {
            if (_logger != null)
                _logger.LogException(ex, message);

            Console.WriteLine(ex.ToString());
            MessageBox.Show(ex.Message);
        }

        private void ConfigureServices()
        {
            var services = new ServiceCollection();

            services.AddSessionsService();
            services.AddRacerDataLogging();

            _serviceProvider = services.BuildServiceProvider();
            _logger = _serviceProvider.GetRequiredService<ILoggerService>();
        }

        #endregion

        #region protected

        protected virtual void ClearDisplay()
        {
            ClearEventDataList();
            ClearEventDataDetails();
            ClearSetups();
            ClearTireSheet();
        }

        protected virtual async Task<EventData> AddTelemetryFileAsync(string telemetryFile)
        {
            var reader = TelemetryFileReaderFactory.GetTelemetryFileReader(telemetryFile);

            var telemetry = await reader.ReadTelemetryFileAsync();

            var eventData = _eventDataList.FirstOrDefault(e => e.SessionId == telemetry.SessionInfo.WeekendInfo.SessionID.ToString());

            if (eventData == null)
            {
                eventData = new EventData()
                {
                    EventType = (EventTypes)Enum.Parse(typeof(EventTypes), telemetry.SessionInfo.WeekendInfo.EventType, true),
                    SessionId = telemetry.SessionInfo.WeekendInfo.SessionID.ToString(),
                    SubSessionId = telemetry.SessionInfo.WeekendInfo.SubSessionID.ToString(),
                    TrackName = telemetry.SessionInfo.WeekendInfo.TrackDisplayName,
                    TrackLength = telemetry.SessionInfo.WeekendInfo.TrackLength.ToString().GetMilesFromKilometers(),
                    AirTemperature = telemetry.SessionInfo.WeekendInfo.TrackAirTemp.ToString().CelciusToFarenheit(),
                    TrackTemperature = telemetry.SessionInfo.WeekendInfo.TrackSurfaceTemp.ToString().CelciusToFarenheit(),
                    Skies = telemetry.SessionInfo.WeekendInfo.TrackSkies,
                    Vehicle = telemetry.SessionInfo.DriverInfo.DriversCar.CarScreenName,
                    Timestamp = telemetryFile.ParseDateTimeFromFileName()
                };

                _eventDataList.Add(eventData);
            }

            var firstFrame = telemetry.Frames.ToList()[0];

            // add session to eventdata
            eventData.Sessions.Add(new EventSessionData(eventData)
            {
                TelemetryFileName = Path.GetFileName(telemetryFile),
                SessionType = GetSessionType(telemetry.SessionInfo.ActiveSession.SessionType),
                SessionNumber = int.Parse(telemetry.SessionInfo.ActiveSession.SessionNum.ToString()),
                TrackRubberState = telemetry.SessionInfo.ActiveSession.SessionTrackRubberState,
                SetupName = telemetry.SessionInfo.DriverInfo.DriverSetupName,
                LapData = new LapData()
                {
                    Laps = telemetry.Laps.ToList()
                },
                Setup = eventData.Vehicle == "Modified - SK" ? SkModifiedTelemetryLoader.GetSkModifiedFromTelemetry(telemetry) : new SkModified(),
                CumulativeLapCount = firstFrame.Lap,
                CumulativeBestLap = firstFrame.LapBestLap,
                CumulativeBestLapTime = firstFrame.LapBestLapTime,
                TireSheet = GetTireSheet(telemetry)
            });

            return eventData;
        }

        protected virtual SessionType GetSessionType(string sessionTypeName)
        {
            if (sessionTypeName == "Offline Testing")
                return SessionType.Test;
            else if (sessionTypeName == "Practice")
                return SessionType.Practice;
            else if (sessionTypeName == "Lone Qualify")
                return SessionType.Qualifying;
            else if (sessionTypeName == "Heat Race")
                return SessionType.HeatRace;
            else if (sessionTypeName == "Race")
                return SessionType.Race;
            else
                throw new ArgumentException(nameof(sessionTypeName));
        }

        // Ibt File Monitor
        protected virtual void EnableMonitor()
        {
            _watcher.EnableRaisingEvents = true;

            lblMonitorStatus.Text = "Monitor On";

        }
        protected virtual void DisableMonitor()
        {
            _watcher.EnableRaisingEvents = false;

            lblMonitorStatus.Text = "Monitor Off";
        }

        // Select Ibt Files
        protected virtual IList<string> SelectTelemetryFile()
        {
            IList<string> telemetryFiles = new List<string>();

            try
            {
                var dialog = new OpenFileDialog()
                {
                    InitialDirectory = TelemetryDirectory,
                    Filter = "iRacing Telemetry Files (*.ibt)|*.ibt|All Files |*.*",
                    FilterIndex = 0,
                    Multiselect = true
                };

                var result = dialog.ShowDialog(this);

                if (result == DialogResult.OK)
                {
                    telemetryFiles = dialog.FileNames;
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }

            return telemetryFiles;
        }
        protected virtual string SelectTelemetryDirectory()
        {
            string telemetryDirectory = null;

            try
            {
                var dialog = new FolderBrowserDialog()
                {
                    SelectedPath = TelemetryDirectory
                };

                var result = dialog.ShowDialog(this);

                if (result == DialogResult.OK)
                {
                    telemetryDirectory = dialog.SelectedPath;
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }

            return telemetryDirectory;
        }

        // Load Ibt Files
        protected virtual async Task LoadTelemetryFiles(IList<string> telemetryFileNames)
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                _loading = true;

                foreach (string telemetryFileName in telemetryFileNames)
                {
                    await LoadTelemetryFile(telemetryFileName);
                }

                DisplayEventDataList(_eventDataList);
            }
            finally
            {
                _loading = false;

                Cursor = Cursors.Default;
            }
        }
        protected virtual async Task LoadTelemetryFile(string telemetryFileName)
        {
            try
            {
                if (!Path.GetFileName(telemetryFileName).StartsWith("skmodified"))
                {
                    return;
                }

                var eventData = await AddTelemetryFileAsync(telemetryFileName);

                if (_autoBackupSetups)
                {
                    eventData.ActiveSession.SetupBackupName = BackupSetupFile(
                        telemetryFileName,
                        eventData.ActiveSession.SetupName,
                        eventData.ActiveSession.Setup.UpdateCount);
                }

                if (!_loading)
                    DisplayEventDataList(_eventDataList);
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }

        // EventData List
        protected virtual void ClearEventDataList()
        {
            lvEventData.Items.Clear();
        }
        protected virtual void DisplayEventDataList(IList<EventData> eventDataList)
        {
            if (lvEventData.InvokeRequired)
            {
                var d = new SafeDisplayEventDataListDelegate(DisplayEventDataList);
                Invoke(d, new object[] { eventDataList });
            }
            else
            {
                lvEventData.Items.Clear();

                lvEventData.ShowGroups = true;

                var fastLapTime = 999.0;
                var fastLapLineIndex = 0;
                var idx = 0;
                foreach (EventData eventData in eventDataList.OrderBy(e => e.Timestamp))
                {
                    foreach (EventSessionData eventSession in eventData.Sessions.OrderBy(s => s.SessionNumber))
                    {
                        var groupKey = $"{eventData.Timestamp.ToString("yyyy-MM-dd")} {eventData.EventType.ToString()} {eventData.SessionId} {eventData.TrackName} ";

                        var group = lvEventData.Groups[groupKey];

                        if (group == null)
                        {
                            var groupHeaderText = $"{eventData.Timestamp.ToString("yyyy-MM-dd")} - {eventData.EventType.ToString()} - {eventData.TrackName} - {eventData.Vehicle}";
                            group = new ListViewGroup(groupKey, groupHeaderText);
                            lvEventData.Groups.Add(group);
                        }

                        var bestLapTime = Math.Round(eventSession.LapData.BestLapTime, 3);

                        var lvi = new ListViewItem(
                            new[]
                            {
                                lvEventData.Items.Count.ToString(),
                                "", // best lap indicator
                                eventSession.LapData.LapCount.ToString(),
                                bestLapTime.ToString(),
                                eventSession.LapData.BestLapNumber.ToString(),
                                Math.Round(eventSession.LapData.AverageLapTime, 3).ToString(),
                                eventSession.LapData.LapTimeStandardDeviation.ToString(),
                                eventSession.CumulativeBestLap.ToString(),
                                Math.Round(eventSession.CumulativeBestLapTime, 3).ToString(),
                                eventSession.SetupName,
                                eventSession.UpdateCount.ToString(),
                                eventSession.TelemetryFileName,
                                eventSession.SetupBackupName
                            })
                        {
                            Tag = eventSession,
                            Group = group,
                            UseItemStyleForSubItems = false
                        };

                        if ((bestLapTime > 0) && (bestLapTime <= fastLapTime))
                        {
                            fastLapTime = bestLapTime;
                            fastLapLineIndex = idx;
                        }

                        lvEventData.Items.Add(lvi);

                        idx++;
                    }
                }

                if (lvEventData.Items.Count > 0)
                {
                    lvEventData.Items[fastLapLineIndex].SubItems[1].Text = "*";
                    lvEventData.Items[fastLapLineIndex].SubItems[3].BackColor = Color.Gold;
                }

                lvEventData.SelectedItems.Clear();

                if (lvEventData.Items.Count > 1)
                {
                    lvEventData.Items[lvEventData.Items.Count - 1].Selected = true;
                    lvEventData.Items[lvEventData.Items.Count - 2].Selected = true;
                }
                else if (lvEventData.Items.Count > 0)
                {
                    lvEventData.Items[lvEventData.Items.Count - 1].Selected = true;
                }
            }
        }

        // EventData Details
        protected virtual void ClearEventDataDetails()
        {
            lblTelemetryFileName.Text = "-";
            lblTrackDisplayName.Text = "-";
            lblWeather.Text = "-";
            lblEventType.Text = "-";
            lblVehicle.Text = "-";
            lblSetup.Text = "-";
            lblBackupSetup.Text = "-";
            lblSessionType.Text = "-";
            lvLapTimes.Items.Clear();
        }
        protected virtual void DisplayEventDataDetails(EventSessionData sessionData)
        {
            try
            {
                pnlEventDetails.SuspendLayout();

                lvLapTimes.Items.Clear();
                lvLapTimes.Columns[2].Width = 0;
                lvLapTimes.Columns[3].Width = 0;
                lvLapTimes.Columns[4].Width = 0;
                lvLapTimes.Width = 175;

                var setup1Laps = sessionData.LapData.ValidLaps.ToList();

                for (int i = 0; i < setup1Laps.Count; i++)
                {
                    var lvi = new ListViewItem(
                        new string[]
                        {
                            setup1Laps[i].LapNumber.ToString(),
                            Math.Round(setup1Laps[i].LapTime, 3).ToString(),
                            "",
                            ""
                        }
                    )
                    {
                        UseItemStyleForSubItems = false
                    };

                    lvi.SubItems[1].BackColor = setup1Laps[i] == sessionData.LapData.BestLap ? Color.Yellow : lvLapTimes.BackColor;

                    lvLapTimes.Items.Add(lvi);
                }

                lblTelemetryFileName.Text = Path.GetFileName(sessionData.Setup.TelemetryFileName);
                lblVehicle.Text = sessionData.EventData.Vehicle;
                lblTrackDisplayName.Text = sessionData.EventData.TrackName;
                lblSetup.Text = sessionData.Setup.Description;
                lblBackupSetup.Text = sessionData.SetupBackupName;
                var airTemp = sessionData.EventData.AirTemperature;
                var trackTemp = sessionData.EventData.TrackTemperature;
                lblWeather.Text = $"{sessionData.EventData.Skies}, Air Temp: {airTemp} F, Track Temp: {trackTemp} F";
                lblEventType.Text = sessionData.EventData.EventType.ToString();
                lblSessionType.Text = sessionData.SessionType.ToString();
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
            finally
            {
                pnlEventDetails.ResumeLayout();
            }
        }

        protected virtual void DisplayEventDataDetails(EventSessionData sessionData1, EventSessionData sessionData2)
        {
            try
            {
                pnlEventDetails.SuspendLayout();

                lvLapTimes.Items.Clear();
                lvLapTimes.Columns[2].Width = lvLapTimes.Columns[1].Width;
                lvLapTimes.Columns[3].Width = lvLapTimes.Columns[1].Width;
                lvLapTimes.Columns[4].Width = lvLapTimes.Columns[1].Width;
                lvLapTimes.Width = 375;

                var setup1Laps = sessionData1.LapData.ValidLaps.ToList();
                var setup2Laps = sessionData2.LapData.ValidLaps.ToList();

                var effectiveLapCount = setup1Laps.Count > setup2Laps.Count ?
                    setup1Laps.Count :
                    setup2Laps.Count;

                float runningDelta = 0;

                for (int i = 0; i < effectiveLapCount; i++)
                {
                    ILapInfo setup1Lap = null;
                    float? lapTimeDelta = null;
                    if (sessionData1.LapData.ValidLaps.Count() > i)
                    {
                        setup1Lap = setup1Laps[i];
                    }

                    ILapInfo setup2Lap = null;
                    if (sessionData2.LapData.ValidLaps.Count() > i)
                    {
                        setup2Lap = setup2Laps[i];
                        if (setup1Lap != null)
                            lapTimeDelta = (float)Math.Round(setup2Lap.LapTime - setup1Lap.LapTime, 3);
                    }

                    runningDelta += lapTimeDelta.HasValue ? lapTimeDelta.Value : 0;

                    var lvi = new ListViewItem(
                        new string[]
                        {
                            (i+1).ToString(),
                            setup1Lap != null ? Math.Round(setup1Lap.LapTime, 3).ToString() : "-",
                            setup2Lap != null ? Math.Round(setup2Lap.LapTime, 3).ToString() : "-",
                            lapTimeDelta.HasValue ? Math.Round(lapTimeDelta.Value, 3).ToString() : "",
                            Math.Round(runningDelta, 3).ToString()
                        }
                    )
                    {
                        UseItemStyleForSubItems = false
                    };

                    lvi.SubItems[1].BackColor = setup1Lap == sessionData1.LapData.BestLap ? Color.Yellow : lvLapTimes.BackColor;
                    lvi.SubItems[2].BackColor = setup2Lap == sessionData2.LapData.BestLap ? Color.Yellow : lvLapTimes.BackColor;
                    lvi.SubItems[3].BackColor = lapTimeDelta.HasValue && lapTimeDelta.Value < 0 ? Color.Gold : lvLapTimes.BackColor;

                    lvLapTimes.Items.Add(lvi);
                }

                lblTelemetryFileName.Text = Path.GetFileName(sessionData1.Setup.TelemetryFileName);
                lblVehicle.Text = sessionData1.EventData.Vehicle;
                lblTrackDisplayName.Text = sessionData1.EventData.TrackName;
                lblSetup.Text = sessionData1.Setup.Description;
                lblBackupSetup.Text = sessionData1.SetupBackupName;
                var airTemp = sessionData1.EventData.AirTemperature;
                var trackTemp = sessionData1.EventData.TrackTemperature;
                lblWeather.Text = $"{sessionData1.EventData.Skies}, Air Temp: {airTemp} F, Track Temp: {trackTemp} F";
                lblEventType.Text = sessionData1.EventData.EventType.ToString();
                lblSessionType.Text = sessionData1.SessionType.ToString();
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
            finally
            {
                pnlEventDetails.ResumeLayout();
            }
        }

        // Display EventData
        protected virtual void DisplaySelectedEventData()
        {
            EventSessionData sessionData = lvEventData.SelectedItems[0].Tag as EventSessionData;

            DisplayEventDataDetails(sessionData);

            DisplaySetup(sessionData);

            DisplayTireSheet(sessionData.TireSheet, 0);

            if (_practiceSessionView != null && !_practiceSessionView.IsDisposed)
            {
                _practiceSessionView.SessionData = sessionData;
            }
        }
        protected virtual void CompareSelectedEventData()
        {
            EventSessionData sessionData1 = lvEventData.SelectedItems[0].Tag as EventSessionData;
            EventSessionData sessionData2 = lvEventData.SelectedItems[1].Tag as EventSessionData;

            //if (sessionData1.TireSheet == null || sessionData1.TireSheet.BestLap == 0)
            //    sessionData1.TireSheet = SkModifiedTelemetryLoader.GetTireSheet(sessionData1.Setup);

            //if (sessionData2.TireSheet == null || sessionData2.TireSheet.BestLap == 0)
            //    sessionData2.TireSheet = SkModifiedTelemetryLoader.GetTireSheet(sessionData2.Setup);

            DisplayEventDataDetails(sessionData1, sessionData2);

            DisplayTireSheet(sessionData1.TireSheet, 0);
            DisplayTireSheet(sessionData2.TireSheet, 1);

            DisplaySetups(sessionData1, sessionData2);
        }

        public static TireSheetValues GetTireSheet(ITelemetryFile telemetry)
        {
            TireSheetValues model = new TireSheetValues()
            {
                FileName = Path.GetFileName(telemetry.FileName),
                Setup = telemetry.SessionInfo.DriverInfo.DriverSetupName,
                Laps = telemetry.Laps.Count(),
                BestLap = telemetry.Laps.ToList().Min(l => l.LapTime),
                AverageLap = telemetry.Laps.ToList().Average(l => l.LapTime)
            };

            ITireSheet tireSheet = telemetry.TireSheet;

            var lf = new TireViewModel(TirePosition.LF)
            {
                ColdPsi = tireSheet.LF.ColdPsi,
                HotPsi = tireSheet.LF.HotPsi
            };
            lf.Temperatures.Inside = tireSheet.LF.Temperatures[TreadPosition.Inside];
            lf.Temperatures.Middle = tireSheet.LF.Temperatures[TreadPosition.Middle];
            lf.Temperatures.Outside = tireSheet.LF.Temperatures[TreadPosition.Outside];
            lf.Wear.Inside = tireSheet.LF.Wear[TreadPosition.Inside];
            lf.Wear.Middle = tireSheet.LF.Wear[TreadPosition.Middle];
            lf.Wear.Outside = tireSheet.LF.Wear[TreadPosition.Outside];
            model.Tires[TirePosition.LF] = lf;

            var lr = new TireViewModel(TirePosition.LR)
            {
                ColdPsi = tireSheet.LR.ColdPsi,
                HotPsi = tireSheet.LR.HotPsi
            };
            lr.Temperatures.Inside = tireSheet.LR.Temperatures[TreadPosition.Inside];
            lr.Temperatures.Middle = tireSheet.LR.Temperatures[TreadPosition.Middle];
            lr.Temperatures.Outside = tireSheet.LR.Temperatures[TreadPosition.Outside];
            lr.Wear.Inside = tireSheet.LR.Wear[TreadPosition.Inside];
            lr.Wear.Middle = tireSheet.LR.Wear[TreadPosition.Middle];
            lr.Wear.Outside = tireSheet.LR.Wear[TreadPosition.Outside];
            model.Tires[TirePosition.LR] = lr;

            var rf = new TireViewModel(TirePosition.RF)
            {
                ColdPsi = tireSheet.RF.ColdPsi,
                HotPsi = tireSheet.RF.HotPsi
            };
            rf.Temperatures.Inside = tireSheet.RF.Temperatures[TreadPosition.Inside];
            rf.Temperatures.Middle = tireSheet.RF.Temperatures[TreadPosition.Middle];
            rf.Temperatures.Outside = tireSheet.RF.Temperatures[TreadPosition.Outside];
            rf.Wear.Inside = tireSheet.RF.Wear[TreadPosition.Inside];
            rf.Wear.Middle = tireSheet.RF.Wear[TreadPosition.Middle];
            rf.Wear.Outside = tireSheet.RF.Wear[TreadPosition.Outside];
            model.Tires[TirePosition.RF] = rf;

            var rr = new TireViewModel(TirePosition.RR)
            {
                ColdPsi = tireSheet.RR.ColdPsi,
                HotPsi = tireSheet.RR.HotPsi
            };
            rr.Temperatures.Inside = tireSheet.RR.Temperatures[TreadPosition.Inside];
            rr.Temperatures.Middle = tireSheet.RR.Temperatures[TreadPosition.Middle];
            rr.Temperatures.Outside = tireSheet.RR.Temperatures[TreadPosition.Outside];
            rr.Wear.Inside = tireSheet.RR.Wear[TreadPosition.Inside];
            rr.Wear.Middle = tireSheet.RR.Wear[TreadPosition.Middle];
            rr.Wear.Outside = tireSheet.RR.Wear[TreadPosition.Outside];
            model.Tires[TirePosition.RR] = rr;

            return model;
        }

        // Display Tire sheets
        protected virtual void ClearTireSheet()
        {
            DisplayTireSheet(new TireSheetValues(), 0);
            DisplayTireSheet(new TireSheetValues(), 1);
        }
        protected virtual void DisplayTireSheet(TireSheetValues model, int displayIndex)
        {
            if (goodyearTireSheet1.InvokeRequired)
            {
                var d = new SafeCallDelegate(DisplayTireSheet);
                Invoke(d, new object[] { model, displayIndex });
            }
            else
            {
                lblTelemetryFile.Text = model.FileName;
                if (displayIndex == 0)
                {
                    goodyearTireSheet1.CurrentModel = model;
                }
                else if (displayIndex == 1)
                {
                    goodyearTireSheet1.PreviousModel = model;
                }
            }
        }

        // Display Setups
        protected virtual SetupModel GetSetupModel(SkModified skModified)
        {
            var setupModel = new SetupModel()
            {
                Name = skModified.SetupFileName,
                Updates = skModified.UpdateCount
            };

            setupModel.Front.Ballast = (int)Math.Round(skModified.Chassis.Front.BallastForward, 0);
            setupModel.Front.Cross = Math.Round(skModified.Chassis.Front.CrossWeight, 2);
            setupModel.Front.Front = Math.Round(skModified.Chassis.Front.NoseWeight, 2);
            setupModel.Front.Toe = skModified.Chassis.Front.ToeIn.NearestSixteenth();
            setupModel.Front.SwayBar = skModified.Chassis.Front.AntiRollBarSize.NearestEighth();
            setupModel.Front.Preload = skModified.Chassis.Front.LeftBarEndClearance.NearestSixteenth();
            setupModel.Front.Stagger = skModified.Tires.FrontStagger.NearestEighth();
            setupModel.Front.BrakeBias = Math.Round(skModified.Chassis.Front.FrontBrakeBias, 2);

            setupModel.LeftFront.Psi = skModified.Tires.LeftFront.ColdPressure.NearestHalf();
            setupModel.LeftFront.Weight = Math.Round(skModified.Chassis.LeftFront.CornerWeight, 0);
            setupModel.LeftFront.Collar = Math.Round(skModified.Chassis.LeftFront.ShockOffset, 3);
            setupModel.LeftFront.Height = Math.Round(skModified.Chassis.LeftFront.RideHeight, 3);
            setupModel.LeftFront.Rebound = Math.Round(skModified.Chassis.LeftFront.Rebound, 0);
            setupModel.LeftFront.Caster = Math.Round(skModified.Chassis.LeftFront.Caster, 1);
            setupModel.LeftFront.Camber = Math.Round(skModified.Chassis.LeftFront.Camber, 1);
            setupModel.LeftFront.Spring = skModified.Chassis.LeftFront.SpringRate.NearestTwentyFive();

            setupModel.RightFront.Psi = skModified.Tires.RightFront.ColdPressure.NearestHalf();
            setupModel.RightFront.Weight = Math.Round(skModified.Chassis.RightFront.CornerWeight, 0);
            setupModel.RightFront.Collar = Math.Round(skModified.Chassis.RightFront.ShockOffset, 3);
            setupModel.RightFront.Height = Math.Round(skModified.Chassis.RightFront.RideHeight, 3);
            setupModel.RightFront.Rebound = Math.Round(skModified.Chassis.RightFront.Rebound, 0);
            setupModel.RightFront.Caster = Math.Round(skModified.Chassis.RightFront.Caster, 1);
            setupModel.RightFront.Camber = Math.Round(skModified.Chassis.RightFront.Camber, 1);
            setupModel.RightFront.Spring = skModified.Chassis.RightFront.SpringRate.NearestTwentyFive();

            setupModel.LeftRear.Psi = skModified.Tires.LeftRear.ColdPressure.NearestHalf();
            setupModel.LeftRear.Weight = Math.Round(skModified.Chassis.LeftRear.CornerWeight, 0);
            setupModel.LeftRear.Collar = Math.Round(skModified.Chassis.LeftRear.ShockOffset, 3);
            setupModel.LeftRear.Height = Math.Round(skModified.Chassis.LeftRear.RideHeight, 3);
            setupModel.LeftRear.Rebound = Math.Round(skModified.Chassis.LeftRear.Rebound, 0);
            setupModel.LeftRear.TrackBar = skModified.Chassis.LeftRear.TrackBarHeight.NearestQuarter();
            setupModel.LeftRear.Spring = skModified.Chassis.LeftRear.SpringRate.NearestTwentyFive();

            setupModel.RightRear.Psi = skModified.Tires.RightRear.ColdPressure.NearestHalf();
            setupModel.RightRear.Weight = Math.Round(skModified.Chassis.RightRear.CornerWeight, 0);
            setupModel.RightRear.Collar = Math.Round(skModified.Chassis.RightRear.ShockOffset, 3);
            setupModel.RightRear.Height = Math.Round(skModified.Chassis.RightRear.RideHeight, 3);
            setupModel.RightRear.Rebound = Math.Round(skModified.Chassis.RightRear.Rebound, 0);
            setupModel.RightRear.TrackBar = skModified.Chassis.RightRear.TrackBarHeight.NearestQuarter();
            setupModel.RightRear.Spring = skModified.Chassis.RightRear.SpringRate.NearestTwentyFive();

            setupModel.Rear.Fuel = Math.Round(skModified.Chassis.Rear.FuelFillTo, 1);
            setupModel.Rear.Gear = Math.Round(skModified.Chassis.Rear.RearEndRatio, 2);
            setupModel.Rear.Stagger = skModified.Tires.RearStagger.NearestEighth();

            return setupModel;
        }
        protected virtual void ClearSetups()
        {
            setupView1.ClearDisplay();
        }
        protected virtual void DisplaySetup(EventSessionData sessionData)
        {
            setupView1.Setup1 = GetSetupModel(sessionData.Setup);
        }
        protected virtual void DisplaySetups(EventSessionData sessionData1, EventSessionData sessionData2)
        {
            setupView1.Setup1 = GetSetupModel(sessionData1.Setup);
            setupView1.Setup2 = GetSetupModel(sessionData2.Setup);

            if (setupView1.Setup1 != null && setupView1.Setup2 != null)
            {
                setupView1.SetupDiff = setupView1.Setup2.Diff(setupView1.Setup1);
            }
        }

        // Archive & process telemetry files
        protected virtual async Task ArchiveTelemetryFilesAsync()
        {
            IList<string> archivedFiles = new List<string>();

            var filesToArchive = Directory.GetFiles(TelemetryDirectory, "*.ibt");

            if (filesToArchive.Count() == 0)
            {
                MessageBox.Show("No files to archive.");
                return;
            }

            ClearDisplay();

            int archivedFilesCount = 0;

            foreach (string originalTelemetryFile in filesToArchive)
            {
                string telemetryFileName = Path.GetFileName(originalTelemetryFile);
                int year = telemetryFileName.ParseDateTimeFromFileName().Year;
                string vehicle = telemetryFileName.ParseVehicleFromFileName();
                string track = telemetryFileName.ParseTrackFromFileName();

                var archiveDirectory = $"{TelemetryArchiveRootDirectory}\\{year}\\{vehicle}\\{track}\\";

                if (!Directory.Exists(archiveDirectory))
                    Directory.CreateDirectory(archiveDirectory);

                var archivedTelemetryFile = Path.Combine(archiveDirectory, telemetryFileName);

                try
                {
                    File.Move(originalTelemetryFile, archivedTelemetryFile);

                    archivedFiles.Add(archivedTelemetryFile);

                    archivedFilesCount++;
                }
                catch (Exception ex)
                {
                    ExceptionHandler(new Exception($"Error archiving file {originalTelemetryFile}: {ex.Message}", ex));
                }
            }

            await ProcessTelemetryFileInfosAsync(archivedFiles);

            MessageBox.Show($"Processed {archivedFilesCount} of {filesToArchive.Count()} files.");
        }
        protected virtual async Task ProcessTelemetryFileInfosAsync(IList<string> fileList)
        {
            var indexedFiles = TelemetryFileInfoReader.ParseTelemetryFiles(fileList);

            IMapper mapper = _serviceProvider.GetRequiredService<IMapper>();

            var telemetryIndex = mapper.Map<IList<TelemetryFileInfo>>(indexedFiles);

            await SaveIndexListAsync(telemetryIndex);
        }
        private async Task SaveIndexListAsync(IList<TelemetryFileInfo> telemetryIndex)
        {
            try
            {
                ITelemetryFileInfoRepository telemetryInfoRepository = _serviceProvider.GetRequiredService<ITelemetryFileInfoRepository>();

                foreach (TelemetryFileInfo item in telemetryIndex.OrderBy(t => t.Timestamp).ToList())
                {
                    var existing = telemetryInfoRepository.GetTelemetryFileInfoAsync(item.FullPath);

                    if (existing == null)
                    {
                        await telemetryInfoRepository.InsertTelemetryFileInfoAsync(item);
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }

        // Backup setup file
        protected virtual string BackupCurrentSetupFile()
        {
            return BackupSetupFile(null, SkModifiedCurrentSetupFile, 0);
        }
        protected virtual string BackupSetupFile(string telemetryFileName, string setupFileName, int updateCount)
        {
            if (!Directory.Exists(SkModifiedSetupBackupDirectory))
                Directory.CreateDirectory(SkModifiedSetupBackupDirectory);

            var timestampString = String.IsNullOrEmpty(telemetryFileName) ?
                DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss") :
                telemetryFileName.Substring(telemetryFileName.Length - 23, 19);

            var backupFileTitle = $"{Path.GetFileNameWithoutExtension(setupFileName)}-{updateCount}-{timestampString}.sto";

            var backupFileFullPath = Path.Combine(SkModifiedSetupBackupDirectory, backupFileTitle);

            var originalSetupFileFullPath = Path.Combine(SkModifiedSetupDirectory, setupFileName);

            try
            {
                File.Copy(originalSetupFileFullPath, backupFileFullPath);

                return backupFileTitle;
            }
            catch (Exception ex)
            {
                ExceptionHandler(new Exception($"Error backing up setup {setupFileName}: {ex.Message}", ex));
            }

            return string.Empty;
        }

        protected virtual void CloseApplication()
        {
            this.Close();
        }

        #endregion

        #region private

        private void PracticeMonitor_Load(object sender, EventArgs e)
        {
            try
            {
                ClearTireSheet();

                ClearEventDataDetails();

                _watcher = new FileSystemWatcher(); _watcher.Path = TelemetryDirectory;
                _watcher.NotifyFilter = NotifyFilters.CreationTime | NotifyFilters.LastWrite;
                _watcher.Filter = "*.ibt";
                _watcher.Changed += new FileSystemEventHandler(TelemetryFileCreated);

                EnableMonitor();
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }

        private void PracticeMonitor_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Copy window location to app settings
            Settings.Default.WindowLocation = this.Location;
            Settings.Default.WindowState = this.WindowState;
            Settings.Default.WindowStartPosition = this.StartPosition;

            // Copy window size to app settings
            if (this.WindowState == FormWindowState.Normal)
            {
                Settings.Default.WindowSize = this.Size;
            }
            else
            {
                Settings.Default.WindowSize = this.RestoreBounds.Size;
            }

            // Save settings
            Settings.Default.Save();
        }

        private async void TelemetryFileCreated(object source, FileSystemEventArgs e)
        {
            try
            {
                while (!IsFileReady(e.FullPath)) { }

                await LoadTelemetryFile(e.FullPath);
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }
        private static bool IsFileReady(string filename)
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

        private void btnMonitor_Click(object sender, EventArgs e)
        {
            ToggleMonitorState();
        }
        private void autoLoadFilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToggleMonitorState();
        }
        private void ToggleMonitorState()
        {
            try
            {
                if (_watcher.EnableRaisingEvents)
                {
                    DisableMonitor();
                }
                else
                {
                    EnableMonitor();
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
            finally
            {
                UpdateMonitorControlState(_watcher.EnableRaisingEvents);
            }
        }
        private void UpdateMonitorControlState(bool monitorEnabled)
        {
            btnMonitor.Checked = monitorEnabled;
            autoLoadFilesToolStripMenuItem.Checked = monitorEnabled;
        }

        private async void btnOpenTelemetryFile_Click(object sender, EventArgs e)
        {
            await OpenTelemetryFileAsync();
        }
        private async void openFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            await OpenTelemetryFileAsync();
        }
        private async Task OpenTelemetryFileAsync()
        {
            var autoBackupSetting = _autoBackupSetups;

            try
            {
                _autoBackupSetups = false;

                var telemetryFileNames = SelectTelemetryFile();

                if (telemetryFileNames.Count > 0)
                    await LoadTelemetryFiles(telemetryFileNames);
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
            finally
            {
                _autoBackupSetups = autoBackupSetting;
            }
        }

        private async void btnLoadTelemetryDirectory_Click(object sender, EventArgs e)
        {
            await LoadTelemetryDirectoryAsync();
        }
        private async void openAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            await LoadTelemetryDirectoryAsync();
        }
        private async Task LoadTelemetryDirectoryAsync()
        {
            var autoBackupSetting = _autoBackupSetups;

            try
            {
                _autoBackupSetups = false;

                await LoadTelemetryFiles(Directory.GetFiles(TelemetryDirectory, "*.ibt"));
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
            finally
            {
                _autoBackupSetups = autoBackupSetting;
            }
        }

        private async void btnOpenTelemetryDirectory_Click(object sender, EventArgs e)
        {
            await OpenSelectedTelemetryDirectory();
        }
        private async void openDirectoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            await OpenSelectedTelemetryDirectory();
        }
        private async Task OpenSelectedTelemetryDirectory()
        {
            var autoBackupSetting = _autoBackupSetups;

            try
            {
                _autoBackupSetups = false;

                string telemetryFolderName = SelectTelemetryDirectory();

                if (!String.IsNullOrEmpty(telemetryFolderName))
                {
                    await LoadTelemetryFiles(Directory.GetFiles(telemetryFolderName, "*.ibt"));
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
            finally
            {
                _autoBackupSetups = autoBackupSetting;
            }
        }

        private void lstEventData_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                SuspendLayout();

                ClearEventDataDetails();
                ClearTireSheet();
                ClearSetups();

                if (lvEventData.SelectedItems.Count == 0)
                    return;
                else if (lvEventData.SelectedItems.Count == 1)
                {
                    DisplaySelectedEventData();
                }
                else if (lvEventData.SelectedItems.Count > 1)
                {
                    CompareSelectedEventData();
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
            finally
            {
                ResumeLayout();
            }
        }
        private void lstEventData_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                ClearTireSheet();

                if (lvEventData.SelectedItems.Count == 0)
                    return;

                EventSessionData sessionData = lvEventData.SelectedItems[0].Tag as EventSessionData;

                var carSetupTireSheet = SkModifiedTelemetryLoader.GetTireSheet(sessionData.Setup);
                carSetupTireSheet.Laps = -1;
                carSetupTireSheet.BestLap = -1;
                carSetupTireSheet.AverageLap = -1;

                DisplayTireSheet(carSetupTireSheet, 0);
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }

        private async void btnArchiveTelemetryFiles_Click(object sender, EventArgs e)
        {
            try
            {
                await ArchiveTelemetryFilesAsync();
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }
        private async void archiveFilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                await ArchiveTelemetryFilesAsync();
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                CloseApplication();
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }

        private void btnBackupCurrentSetup_Click(object sender, EventArgs e)
        {
            BackupCurrentSetup();
        }
        private void backupSetupToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            BackupCurrentSetup();
        }
        private void BackupCurrentSetup()
        {
            try
            {
                var backupFileName = BackupCurrentSetupFile();

                if (!String.IsNullOrEmpty(backupFileName))
                {
                    MessageBox.Show($"Setup backed up as {backupFileName}");
                }
                else
                {
                    MessageBox.Show("Setup backup failed");
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }

        private void btnPracticeSession_Click(object sender, EventArgs e)
        {
            _practiceSessionView = new PracticeSession();

            _practiceSessionView.Show();
        }

        private void telemetrySessionViewerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                TelemetrySessionViewer telemetrySessionViewer = new TelemetrySessionViewer();

                telemetrySessionViewer.Show();
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }

        private void telemetryFileInfoViewerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                TelemetryFileInfoView telemetryFileInfoView = new TelemetryFileInfoView(_serviceProvider, _logger);

                telemetryFileInfoView.Show();
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }

        #endregion
    }
}
