using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using RacerData.iRacing.Service.Sessions;
using RacerData.iRacing.Sessions.Models;
using RacerData.iRacing.Sessions.Ports;
using RacerData.iRacing.Telemetry.Extensions;
using RacerData.iRacing.Telemetry.Sdk.Adapters;
using RacerData.Logging;
using RacerData.Logging.Ports;

namespace RacerData.iRacing.Setups.ClassBuilder.Forms
{
    public partial class TelemetrySessionViewer : Form
    {
        #region fields

        IList<SetupValue> _setup1Values;
        IList<SetupValue> _setup2Values;
        FolderBrowserDialog _folderBrowserDialog;
        OpenFileDialog _openFileDialog;

        private ILoggerService _logger;
        private IServiceProvider _serviceProvider { get; set; }

        #endregion

        #region properties

        public IList<TelemetryFileInfo> TelemetryIndex { get; set; } = new List<TelemetryFileInfo>();

        #endregion

        #region ctor / load

        public TelemetrySessionViewer()
        {
            InitializeComponent();

            try
            {
                ConfigureServices();
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                ILoggerServiceFactory loggerServiceFactory = _serviceProvider.GetRequiredService<ILoggerServiceFactory>();

                _logger = loggerServiceFactory.GetLoggerService();

                await UpdateSessionsAsync();

                _logger.LogInfo("TelemetryTestApp Started!");
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
            MessageWriteLine(ex.ToString());
            MessageBox.Show(ex.Message);
        }

        private async Task UpdateSessionsAsync()
        {
            try
            {
                PopulateSessionListOptions();

                await PopulateSetupOptionLists();

                LoadSessionList();
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }

        private void ConfigureServices()
        {
            var services = new ServiceCollection();

            services.AddSessionsService();
            services.AddRacerDataLogging();

            _serviceProvider = services.BuildServiceProvider();
        }
        private void MessageWriteLine()
        {
            MessageWriteLine("\r\n");
        }
        private void MessageWriteLine(string message)
        {
            txtMessages.AppendText($"{message}\r\n");
        }

        #endregion

        #region build classes
        private void classBuilderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                BuildClasses();
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }
        private void BuildClasses()
        {
            var builder = new TelemetryClassBuilder(@"C:\Users\Rob\Documents\iRacing\telemetry\skmodified_bullring 2019-07-23 13-09-00.ibt");

            var sessions = builder.GenerateSessionInfoClasses();
        }
        #endregion

        #region index telemetry files

        private async void allToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                MessageWriteLine("Indexing files...");

                TelemetryIndex.Clear();

                var indexedFiles = TelemetryFileInfoReader.ParseTelemetryFiles();

                IMapper mapper = _serviceProvider.GetRequiredService<IMapper>();

                TelemetryIndex = mapper.Map<IList<TelemetryFileInfo>>(indexedFiles);

                MessageWriteLine("Indexing files complete");

                await SaveIndexListAsync();
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }

        private async void directoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (_folderBrowserDialog == null)
                {
                    _folderBrowserDialog = new FolderBrowserDialog();
                    _folderBrowserDialog.ShowNewFolderButton = true;
                    _folderBrowserDialog.SelectedPath = @"C:\iRacingData\telemetry";
                }

                if (_folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    MessageWriteLine($"** Indexing all files in {_folderBrowserDialog.SelectedPath}");
                    var fileList = Directory.GetFiles(_folderBrowserDialog.SelectedPath, "*.ibt", SearchOption.AllDirectories);

                    await BuildTelemetryFileIndexAsync(fileList);
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }

        private async void singleFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (_openFileDialog == null)
                {
                    _openFileDialog = new OpenFileDialog();
                    _openFileDialog.Title = "Select Telemetry File";
                    _openFileDialog.Filter = "Atlas telemetry files|*.ibt|All Files|*.*";
                    _openFileDialog.FilterIndex = 0;
                    _openFileDialog.InitialDirectory = @"C:\iRacingData\Telemetry";
                    _openFileDialog.Multiselect = true;
                }

                if (_openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    if (_openFileDialog.FileNames.Count() > 1)
                    {
                        MessageWriteLine($"** Start Indexing {_openFileDialog.FileNames.Count()} files");
                        await BuildTelemetryFileIndexAsync(_openFileDialog.FileNames);
                    }
                    else
                    {
                        MessageWriteLine($"** Start Indexing file {_openFileDialog.FileName.ToString()}");
                        await BuildTelemetryFileIndexAsync(new List<string>() { _openFileDialog.FileName.ToString() });
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }

        private async Task BuildTelemetryFileIndexAsync(IList<string> fileList)
        {
            try
            {
                TelemetryIndex.Clear();

                MessageWriteLine($"Indexing file list... {fileList.Count()} files.");

                var indexedFiles = TelemetryFileInfoReader.ParseTelemetryFiles(fileList);

                IMapper mapper = _serviceProvider.GetRequiredService<IMapper>();

                TelemetryIndex = mapper.Map<IList<TelemetryFileInfo>>(indexedFiles);

                MessageWriteLine("Indexing file list complete");

                DisplayIndexReport();

                await SaveIndexListAsync();
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }

        private void DisplayIndexReport()
        {
            var totalSize = TelemetryIndex.Sum(t => t.Size);
            var totalSizeInGB = totalSize / 1024 / 1024 / 1024;
            var errorCount = TelemetryIndex.Count(t => t.HasError == true);

            MessageWriteLine();
            MessageWriteLine($"Indexed {TelemetryIndex.Count} telemetry files. Total size: {totalSizeInGB}GB, [Error Count: {errorCount}]");
            MessageWriteLine();

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("ERROR REPORT");
            sb.AppendLine("------------");
            foreach (TelemetryFileInfo errorItem in TelemetryIndex.Where(t => t.HasError))
            {
                sb.AppendLine($"{errorItem.FullPath}        {errorItem.Comments}        {errorItem.Error?.Message}");
            }
            sb.AppendLine();

            MessageWriteLine(sb.ToString());
        }

        #endregion

        #region save index to db

        private async Task SaveIndexListAsync()
        {
            try
            {
                MessageWriteLine("Saving indexed files...");

                ITelemetryFileInfoRepository telemetryInfoRepository = _serviceProvider.GetRequiredService<ITelemetryFileInfoRepository>();

                foreach (TelemetryFileInfo item in TelemetryIndex.OrderBy(t => t.Timestamp).ToList())
                {
                    var existing = telemetryInfoRepository.GetTelemetryFileInfoAsync(item.FullPath);

                    if (existing == null)
                    {
                        await telemetryInfoRepository.InsertTelemetryFileInfoAsync(item);
                        MessageWriteLine($" Indexed file {item.FullPath} saved.");
                    }
                    else
                    {
                        MessageWriteLine($" Indexed file {item.FullPath} already recorded.");
                    }
                }

                MessageWriteLine("Indexed files saved");
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }

        #endregion

        #region buld directories

        private void directoryBuilderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                return;
                //BuildDirectories();
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }

        private void BuildDirectories()
        {
            //var setupRoot = @"C:\iRacingData\Setups\";
            var telemetryRoot = @"C:\iRacingData\Telemetry\";

            var telemetryDirectories = Directory.GetDirectories(telemetryRoot);

            foreach (string yearDirectory in telemetryDirectories)
            {
                Console.WriteLine($"***** Starting year directory {yearDirectory}\r\n");
                var vehicleDirectories = Directory.GetDirectories(yearDirectory);

                foreach (string vehicleDirectory in vehicleDirectories)
                {
                    Console.WriteLine($"*** Starting vehicle directory {vehicleDirectory}\r\n");

                    var trackDirectories = Directory.GetDirectories(vehicleDirectory);
                    foreach (string trackDirectory in trackDirectories)
                    {
                        var telemetryFiles = Directory.GetFiles(trackDirectory);
                        foreach (string telemetryFile in telemetryFiles)
                        {
                            ProcessTelemetryFile_SeasonAndRaceWeekAudit(telemetryFile);
                        }
                    }

                    // move to track-specific directory
                    //var telemetryFiles = Directory.GetFiles(vehicleDirectory);
                    //foreach (string telemetryFile in telemetryFiles)
                    //{
                    //    ProcessTelemetryFile_MoveToTrackDirectory(telemetryFile);                          
                    //}
                }
            }

            foreach (RaceWeekAudit audit in _raceWeeks.OrderBy(a => a.FileDate))
            {
                Console.WriteLine($"{audit.FileDate.ToString("yyyy-MM-dd")} {audit.SeasonId} {audit.RaceWeek} {audit.Messages}");
            }
        }
        private IList<RaceWeekAudit> _raceWeeks = new List<RaceWeekAudit>();
        private class RaceWeekAudit
        {
            public int SeasonId { get; set; }
            public int RaceWeek { get; set; }
            public DateTime FileDate { get; set; }
            public string Messages { get; set; }
        }

        private void ProcessTelemetryFile_SeasonAndRaceWeekAudit(string telemetryFile)
        {
            var _audit = new RaceWeekAudit()
            {
                FileDate = telemetryFile.ParseDateTimeFromFileName()
            };

            var content = File.ReadAllText(telemetryFile);
            var rwToken = "RaceWeek: ";
            var rwTokenLength = rwToken.Length;
            var rwIdx = content.IndexOf(rwToken);
            if (rwIdx > 0)
            {
                var rwEndIdx = content.IndexOf("\n", rwIdx + rwTokenLength);
                var rwValIdx = (rwIdx + rwTokenLength);
                var rwValLength = rwEndIdx - rwValIdx;
                var rwVal = content.Substring(rwValIdx, rwValLength).Trim();
                _audit.RaceWeek = int.Parse(rwVal);
            }
            else
            {
                _audit.Messages += "No RaceWeek found ";
            }

            var seasonToken = "SeasonId: ";
            var seasonTokenLength = seasonToken.Length;
            var seasonIdx = content.IndexOf(seasonToken);
            if (seasonIdx > 0)
            {
                var seasonEndIdx = content.IndexOf("\n", seasonIdx + seasonTokenLength);
                var seasonValIdx = (seasonIdx + seasonTokenLength);
                var seasonValLength = seasonEndIdx - seasonValIdx;
                var seasonVal = content.Substring(seasonValIdx, seasonValLength).Trim();
                _audit.SeasonId = int.Parse(seasonVal);
            }
            else
            {
                _audit.Messages += "No SeasonId found ";
            }

            //var lines = File.ReadAllLines(telemetryFile);
            //foreach (string line in lines)
            //{
            //    if (line.StartsWith("SeasonId:"))
            //    {
            //        _audit.SeasonId = int.Parse(line.Split(':')[1].Trim());
            //    }
            //    else if (line.StartsWith("RaceWeek:"))
            //    {
            //        _audit.RaceWeek = int.Parse(line.Split(':')[1].Trim());
            //        break;
            //    }
            //}
            _raceWeeks.Add(_audit);
        }

        private void ProcessTelemetryFile_MoveToTrackDirectory(string telemetryFile)
        {
            var vehicleDirectory = Path.GetDirectoryName(telemetryFile);

            var telemetryFileSubsection = telemetryFile.Split('_')[1];
            var trackName = telemetryFileSubsection.Substring(0, telemetryFileSubsection.Length - 23).Trim();

            var trackDirectory = Path.Combine(vehicleDirectory, trackName);

            if (!Directory.Exists(trackDirectory))
            {
                Console.WriteLine($"Creating {trackDirectory}\r\n");
                Directory.CreateDirectory(trackDirectory);
            }

            var newFileName = Path.Combine(trackDirectory, Path.Combine(trackDirectory, Path.GetFileName(telemetryFile)));

            Console.WriteLine($"Moving {telemetryFile} to {newFileName}");
            File.Move(telemetryFile, newFileName);
        }
        #endregion

        #region setup and export index

        private void processSetupFilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProcessSetupFiles();
        }
        private void ProcessSetupFiles()
        {
            string recycleBin = @"C:\iRacingData\SetupRecycleBin\";
            IList<string> movedFiles = new List<string>();
            IList<string> notFoundFiles = new List<string>();
            try
            {
                using (var scope = _serviceProvider.CreateScope())
                {
                    ISetupRepository setupRepository = scope.ServiceProvider.GetRequiredService<ISetupRepository>();

                    var files = setupRepository.GetDuplicateSetupFiles().ToList();

                    var groups = files.GroupBy(f => f.Name);
                    string duplicateFilePath = "";
                    foreach (IGrouping<string, DuplicateSetupFile> group in groups)
                    {
                        foreach (DuplicateSetupFile file in group.ToList())
                        {
                            if (file.FullPath.Trim().StartsWith("C:\\iRacingData\\Setups\\ARCHIVE\\", StringComparison.OrdinalIgnoreCase))
                            {
                                if (File.Exists(duplicateFilePath))
                                {
                                    duplicateFilePath = file.FullPath.Trim();
                                    break;
                                }
                                else
                                {
                                    setupRepository.MarkSetupFileAsMoved(file.FullPath.Trim());
                                }
                            }
                        }

                        if (String.IsNullOrEmpty(duplicateFilePath))
                        {
                            foreach (DuplicateSetupFile file in group.ToList())
                            {
                                if (File.Exists(duplicateFilePath))
                                {
                                    duplicateFilePath = file.FullPath.Trim();
                                    break;
                                }
                                else
                                {
                                    setupRepository.MarkSetupFileAsMoved(file.FullPath.Trim());
                                }
                            }

                            Console.WriteLine("Found non-ARCHIVE duplicate");
                        }

                        string newFilePath = Path.Combine(recycleBin, group.Key);

                        if (File.Exists(duplicateFilePath))
                        {
                            int idx = 0;
                            while (File.Exists(newFilePath) || movedFiles.Contains(newFilePath))
                            {
                                newFilePath = Path.Combine(recycleBin, $"{Path.GetFileNameWithoutExtension(group.Key)}({idx}).sto");
                                idx++;
                            }
                            Console.WriteLine($"Moving {duplicateFilePath} to {newFilePath}");

                            File.Move(duplicateFilePath, newFilePath);

                            movedFiles.Add(newFilePath);

                            setupRepository.MarkSetupFileAsMoved(duplicateFilePath);
                        }
                        else
                        {
                            notFoundFiles.Add(duplicateFilePath);
                        }
                    }
                }

                foreach (string item in notFoundFiles)
                {
                    Console.WriteLine($"FILE NOT FOUND: {item}");
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }
        public static List<FileInfo> GetFileList(string fileSearchPattern, string rootFolderPath)
        {
            DirectoryInfo rootDir = new DirectoryInfo(rootFolderPath);

            List<DirectoryInfo> dirList = new List<DirectoryInfo>(rootDir.GetDirectories("*", SearchOption.AllDirectories));
            dirList.Add(rootDir);

            List<FileInfo> fileList = new List<FileInfo>();

            foreach (DirectoryInfo dir in dirList)
            {
                fileList.AddRange(dir.GetFiles(fileSearchPattern, SearchOption.TopDirectoryOnly));
            }

            return fileList;
        }

        private void mapSetupFilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                MapSetupFiles();
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }
        private void MapSetupFiles()
        {
            List<FileInfo> setupFiles = GetFileList("*.sto", @"C:\iRacingData\Setups");

            StringBuilder sb = new StringBuilder();

            sb.AppendLine("[Name], [FullPath], [Size], [CreateTime], [LastWrite], [LastUpdate]");
            foreach (FileInfo setupFile in setupFiles.OrderBy(f => f.Name).ToList())
            {
                sb.AppendLine($"{setupFile.Name}, {setupFile.FullName}, {setupFile.Length}, {setupFile.CreationTime.ToString()}, {setupFile.LastWriteTime.ToString()}, {setupFile.LastAccessTime.ToString()}");
            }

            var fileContent = sb.ToString();

            File.WriteAllText(@"C:\iRacingData\SetupFileIndex\setupFileIndex2.csv", fileContent);

            MessageWriteLine("Setup files indexed");
        }

        private void mapExportFIlesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                MapExports();
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }
        private void MapExports()
        {
            List<FileInfo> setupFiles = GetFileList("*.htm", @"C:\iRacingData\Setups");

            StringBuilder sb = new StringBuilder();

            sb.AppendLine("[Name], [FullPath], [LastUpdate]");
            foreach (FileInfo setupFile in setupFiles.OrderBy(f => f.Name).ToList())
            {
                sb.AppendLine($"{setupFile.Name}, {setupFile.FullName}, {setupFile.LastAccessTime.ToString()}");
            }

            var fileContent = sb.ToString();

            File.WriteAllText(@"C:\iRacingData\SetupFileIndex\SetupExportIndex.csv", fileContent);
        }

        #endregion

        #region setup search
        private IList<SetupProperty> _vehicleSetupProperties = new List<SetupProperty>();

        private async Task PopulateSetupOptionLists()
        {
            try
            {
                using (var scope = _serviceProvider.CreateScope())
                {
                    IVehicleRepository vehicleRepository = scope.ServiceProvider.GetRequiredService<IVehicleRepository>();

                    IList<Vehicle> vehicles = await vehicleRepository.GetVehiclesAsync();

                    lstSetupVehicle.DataSource = null;
                    lstSetupVehicle.DisplayMember = "Name";
                    lstSetupVehicle.ValueMember = "Id";
                    lstSetupVehicle.DataSource = vehicles;
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }

        private async void lstSetupVehicle_SelectedValueChanged(object sender, EventArgs e)
        {
            lstSetupProperties.DataSource = null;
            lstPath.DataSource = null;

            if (lstSetupVehicle.SelectedItems.Count == 0)
                return;

            try
            {
                Vehicle selectedVehicle = (Vehicle)lstSetupVehicle.SelectedItems[0];

                using (var scope = _serviceProvider.CreateScope())
                {
                    IVehicleRepository vehicleRepository = scope.ServiceProvider.GetRequiredService<IVehicleRepository>();

                    _vehicleSetupProperties = await vehicleRepository.GetVehicleSetupProperties(selectedVehicle.Id);

                    IList<SetupPropertyPath> paths = new List<SetupPropertyPath>();
                    foreach (var item in _vehicleSetupProperties)
                    {
                        if (!paths.Any(p => p.Id == item.Path.Id))
                        {
                            paths.Add(item.Path);
                        }
                    }

                    lstPath.DisplayMember = "Path";
                    lstPath.ValueMember = "Id";
                    lstPath.DataSource = paths;
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }

        private void lstPath_SelectedIndexChanged(object sender, EventArgs e)
        {
            lstSetupValues.DataSource = null;
            lstSetupProperties.DataSource = null;

            if (lstPath.SelectedItems.Count == 0)
                return;

            try
            {
                SetupPropertyPath selectedPath = (SetupPropertyPath)lstPath.SelectedItems[0];

                IList<SetupProperty> setupProperties = _vehicleSetupProperties.Where(p => p.Path.Id == selectedPath.Id).ToList();

                lstSetupProperties.DisplayMember = "Name";
                lstSetupProperties.ValueMember = "Id";

                lstSetupProperties.DataSource = setupProperties;
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }

        private void lstSetupProperties_SelectedValueChanged(object sender, EventArgs e)
        {
            lstSetupValues.DataSource = null;
            txtSetupSearchMin.Clear();
            txtSetupSearchMax.Clear();

            if (lstSetupProperties.SelectedItems.Count == 0)
                return;

            try
            {
                SetupProperty selectedProperty = (SetupProperty)lstSetupProperties.SelectedItems[0];

                ISetupRepository setupRepository = _serviceProvider.GetRequiredService<ISetupRepository>();

                IQueryable<SetupValue> setupSearchQuery = setupRepository.SearchSetupsQuery();

                setupSearchQuery = setupSearchQuery.Where(s => s.Property.Id == selectedProperty.Id);

                var setupValueList = setupSearchQuery.OrderBy(s => s.Value).ToList();

                lstSetupValues.DisplayMember = "Value";
                lstSetupValues.ValueMember = "Id";

                lstSetupValues.DataSource = setupValueList;
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }

        private void btnSetupList_Click(object sender, EventArgs e)
        {
            try
            {
                SearchSetups();
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }

        private void SearchSetups()
        {
            SetupProperty setupProperty = null;
            if (lstSetupProperties.SelectedItems.Count > 0)
                setupProperty = (SetupProperty)lstSetupProperties.SelectedItems[0];

            double? min = null;
            if (!String.IsNullOrEmpty(txtSetupSearchMin.Text))
                min = double.Parse(txtSetupSearchMin.Text);

            double? max = null;
            if (!String.IsNullOrEmpty(txtSetupSearchMax.Text))
                max = double.Parse(txtSetupSearchMax.Text);

            ISetupRepository setupRepository = _serviceProvider.GetRequiredService<ISetupRepository>();

            var setupSearchQuery = setupRepository.SearchSetupsList(setupProperty.Id, min, max);

            lvSessions.Items.Clear();
            lvSessionRuns.Items.Clear();
            lvSetup.Items.Clear();
            lvLapTimes.Items.Clear();

            DisplayRunsList(setupSearchQuery);
        }
        #endregion

        #region session search and lists
        private void PopulateSessionListOptions()
        {
            try
            {
                ISessionRepository sessionRepository = _serviceProvider.GetRequiredService<ISessionRepository>();

                var years = sessionRepository.GetSessionsQuery().Select(s => s.Year).Distinct().ToList();
                var seasons = sessionRepository.GetSessionsQuery().Select(s => s.Season).Distinct().ToList();
                var tracks = sessionRepository.GetSessionsQuery().Select(s => s.Track).Distinct().ToList();
                var vehicles = sessionRepository.GetSessionsQuery().Select(s => s.Vehicle).Distinct().ToList();
                var eventTypes = sessionRepository.GetSessionsQuery().Select(s => s.EventType).Distinct().ToList();
                var skies = sessionRepository.GetSessionsQuery().Select(s => s.Sky).Distinct().ToList();
                var trackStates = sessionRepository.GetSessionsQuery().Select(s => s.TrackState).Distinct().ToList();

                lstYear.Items.Clear();
                foreach (int year in years)
                    lstYear.Items.Add(year);

                lstSeason.Items.Clear();
                foreach (int season in seasons)
                    lstSeason.Items.Add(season);

                lstTracks.Items.Clear();
                foreach (string track in tracks)
                    lstTracks.Items.Add(track);

                lstVehicles.Items.Clear();
                foreach (string vehicle in vehicles)
                    lstVehicles.Items.Add(vehicle);

                lstEventTypes.Items.Clear();
                foreach (string eventType in eventTypes)
                    lstEventTypes.Items.Add(eventType);

                lstSkies.Items.Clear();
                foreach (string sky in skies)
                {
                    if (!String.IsNullOrEmpty(sky))
                        lstSkies.Items.Add(sky);
                }


                lstTrackState.Items.Clear();
                foreach (string trackState in trackStates)
                {
                    if (!String.IsNullOrEmpty(trackState))
                        lstTrackState.Items.Add(trackState);
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }

        private void btnSessionList_Click(object sender, EventArgs e)
        {
            LoadSessionList();
        }

        private void LoadSessionList()
        {
            try
            {
                lvSessions.Items.Clear();
                lvSessionRuns.Items.Clear();
                lvSetup.Items.Clear();
                lvLapTimes.Items.Clear();

                ISessionRepository sessionRepository = _serviceProvider.GetRequiredService<ISessionRepository>();
                var sessions = sessionRepository.GetSessionsQuery();

                if (lstTracks.CheckedItems.Count > 0)
                    sessions = sessions.Where(s => lstTracks.CheckedItems.Contains(s.Track));

                if (lstVehicles.CheckedItems.Count > 0)
                    sessions = sessions.Where(s => lstVehicles.CheckedItems.Contains(s.Vehicle));

                if (lstEventTypes.CheckedItems.Count > 0)
                    sessions = sessions.Where(s => lstEventTypes.CheckedItems.Contains(s.EventType));

                if (lstSkies.CheckedItems.Count > 0)
                    sessions = sessions.Where(s => lstSkies.CheckedItems.Contains(s.Sky));

                if (lstTrackState.CheckedItems.Count > 0)
                    sessions = sessions.Where(s => lstTrackState.CheckedItems.Contains(s.TrackState));

                if (lstYear.CheckedItems.Count > 0)
                    sessions = sessions.Where(s => lstYear.CheckedItems.Contains(s.Year));

                if (!String.IsNullOrEmpty(txtLapsMin.Text))
                {
                    int minLaps = int.Parse(txtLapsMin.Text);
                    sessions = sessions.Where(s => s.LapCount >= minLaps);
                }

                if (!String.IsNullOrEmpty(txtLapsMax.Text))
                {
                    int maxLaps = int.Parse(txtLapsMax.Text);
                    sessions = sessions.Where(s => s.LapCount <= maxLaps);
                }

                sessions.OrderBy(s => s.RunTime);

                DisplaySessionsList(sessions);
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }

        private void DisplaySessionsList(IQueryable<SessionListView> sessions)
        {
            lvSessions.Items.Clear();

            lvSessions.Groups.Clear();

            var groupedSessions = sessions.
                GroupBy(s => new { s.Track, s.Vehicle, s.SessionIndex }).
                Select(g => new
                {
                    g.Key.Track,
                    g.Key.Vehicle,
                    g.Key.SessionIndex,
                    Runs = g
                }).
                OrderBy(s => s.Track).
                ThenBy(s => s.Vehicle).
                ThenBy(s => s.SessionIndex);

            foreach (var groupedSession in groupedSessions)
            {
                if (groupedSession.Runs.Count() > 0)
                {
                    var lvi = new ListViewItem(
                       new string[]
                       {
                        groupedSession.Runs.FirstOrDefault().RunTime.ToString("yyyy-MM-dd HH:mm:ss"),
                        groupedSession.Track,
                        groupedSession.Vehicle,
                        groupedSession.Runs.FirstOrDefault().EventType ,
                        groupedSession.Runs.Count().ToString(),
                        groupedSession.Runs.Sum(l=>l.LapCount).ToString(),
                        groupedSession.Runs.Average(r=>r.LapAverage).ToString("F"),
                        groupedSession.Runs.Min(r=>r.BestLap).ToString("F"),
                        groupedSession.Runs.Average(r=>r.StdDev).ToString("F"),
                        groupedSession.Runs.FirstOrDefault().AirTemp.ToString(),
                        groupedSession.Runs.FirstOrDefault().TrackTemp.ToString(),
                        groupedSession.Runs.FirstOrDefault().Sky,
                        groupedSession.Runs.FirstOrDefault().TrackState
                       });

                    lvi.UseItemStyleForSubItems = false;
                    lvi.Tag = groupedSession.Runs.ToList();

                    ListViewGroup itemGroup = lvSessions.Groups[$"{groupedSession.Track}-{groupedSession.Vehicle}"];

                    if (itemGroup == null)
                    {
                        itemGroup = new ListViewGroup($"{groupedSession.Track}-{groupedSession.Vehicle}", $"{groupedSession.Track} - {groupedSession.Vehicle}");

                        lvSessions.Groups.Add(itemGroup);
                    }

                    lvi.Group = itemGroup;

                    lvSessions.Items.Add(lvi);
                }

                if (lvSessions.Items.Count > 0)
                    lvSessions.Items[0].Selected = true;
            }
        }

        private void DisplaySessionRunsList(IList<SessionListView> sessions)
        {
            lvSessionRuns.Items.Clear();

            IList<BestLapHistory> bestLaps = new List<BestLapHistory>();
            IList<BestLapHistory> bestSessionLaps = new List<BestLapHistory>();

            int idx = 0;
            foreach (SessionListView session in sessions)
            {
                var lvi = new ListViewItem(
                    new string[]
                    {
                        session.Year.ToString(),
                        session.RunTime.ToString("yyyy-MM-dd HH:mm:ss"),
                        session.Track,
                        session.Vehicle,
                        session.EventType ,
                        session.LapCount.ToString(),
                        session.LapAverage.ToString("F"),
                        session.BestLap.ToString("F"),
                        session.StdDev.ToString("F"),
                        session.AirTemp.ToString(),
                        session.TrackTemp.ToString(),
                        session.Sky,
                        session.TrackState
                    });

                lvi.UseItemStyleForSubItems = false;
                lvi.Tag = session;

                lvSessionRuns.Items.Add(lvi);

                var bestLap = bestLaps.SingleOrDefault(l => l.Track == session.Track && l.Vehicle == session.Vehicle);
                if (bestLap == null)
                {
                    bestLap = new BestLapHistory()
                    {
                        LapTime = session.BestLap,
                        Vehicle = session.Vehicle,
                        Track = session.Track,
                        SessionIndex = session.SessionIndex,
                        RunIndex = session.RunIndex,
                        LineIdx = idx,
                        lvi = lvi
                    };

                    bestLaps.Add(bestLap);
                }
                else if (bestLap.LapTime > session.BestLap)
                {
                    bestLap.LapTime = session.BestLap;
                    bestLap.SessionIndex = session.SessionIndex;
                    bestLap.RunIndex = session.RunIndex;
                    bestLap.LineIdx = idx;
                    bestLap.lvi = lvi;
                }

                var bestSessionLap = bestSessionLaps.SingleOrDefault(l =>
                    l.SessionIndex == session.SessionIndex &&
                    l.Track == session.Track &&
                    l.Vehicle == session.Vehicle);

                if (bestSessionLap == null)
                {
                    bestSessionLap = new BestLapHistory()
                    {
                        LapTime = session.BestLap,
                        Vehicle = session.Vehicle,
                        Track = session.Track,
                        SessionIndex = session.SessionIndex,
                        RunIndex = session.RunIndex,
                        LineIdx = idx,
                        lvi = lvi
                    };

                    bestSessionLaps.Add(bestSessionLap);
                }
                else if (bestSessionLap.LapTime > session.BestLap)
                {
                    bestSessionLap.LapTime = session.BestLap;
                    bestSessionLap.SessionIndex = session.SessionIndex;
                    bestSessionLap.RunIndex = session.RunIndex;
                    bestSessionLap.LineIdx = idx;
                    bestSessionLap.lvi = lvi;
                }

                idx++;
            }

            // highlight the fastest laps
            foreach (BestLapHistory bestSessionLap in bestSessionLaps)
            {
                bestSessionLap.lvi.SubItems[7].BackColor = Color.GreenYellow;
            }

            foreach (BestLapHistory bestLap in bestLaps)
            {
                bestLap.lvi.SubItems[7].BackColor = Color.Gold;
            }

            var groups = bestLaps.GroupBy(g => new { g.Vehicle, g.Track }).Select(g => new { g.Key.Vehicle, g.Key.Track, Runs = g.ToList() });
            foreach (var bestVTLaps in groups)
            {
                var bestVTLap = bestVTLaps.Runs.OrderBy(r => r.LineIdx).FirstOrDefault();

                bestVTLap.lvi.SubItems[7].BackColor = Color.Gold;
            }

            if (lvSessionRuns.Items.Count > 0)
                lvSessionRuns.Items[0].Selected = true;
        }

        private void DisplayRunsList(IList<Run> runs)
        {
            lvSessionRuns.Items.Clear();

            IList<BestLapHistory> bestLaps = new List<BestLapHistory>();
            IList<BestLapHistory> bestSessionLaps = new List<BestLapHistory>();

            ISessionRepository sessionRepository = _serviceProvider.GetRequiredService<ISessionRepository>();
            IQueryable<SessionListView> sessions = null;

            var runIdList = runs.Select(r => r.Id).ToList();

            var sessionQuery = sessionRepository.GetSessionsQuery();

            sessions = sessionQuery.Where(s => runIdList.Contains(s.RunId));

            DisplaySessionsList(sessions);
        }

        private void btnClearFilters_Click(object sender, EventArgs e)
        {
            try
            {
                UncheckAllItems(lstTracks);
                UncheckAllItems(lstVehicles);
                UncheckAllItems(lstEventTypes);
                UncheckAllItems(lstSkies);
                UncheckAllItems(lstTrackState);
                UncheckAllItems(lstYear);
                UncheckAllItems(lstSeason);

                txtLapsMin.Clear();
                txtLapsMax.Clear();
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }

        private void UncheckAllItems(CheckedListBox checkedListBox1)
        {
            foreach (int i in checkedListBox1.CheckedIndices)
            {
                checkedListBox1.SetItemCheckState(i, CheckState.Unchecked);
            }
        }

        private void lvSessions_ItemSelectionChanged_1(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            lvSessionRuns.Items.Clear();

            if (lvSessions.SelectedItems.Count == 0)
                return;

            List<SessionListView> selectedSessions = new List<SessionListView>();

            foreach (ListViewItem item in lvSessions.SelectedItems)
            {
                selectedSessions.AddRange((IList<SessionListView>)item.Tag);
            }

            DisplaySessionRunsList(selectedSessions);
        }

        private void lvSessionRuns_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            lvSetup.Items.Clear();
            lvLapTimes.Items.Clear();

            if (lvSessionRuns.SelectedItems.Count == 0)
                return;
            else if (lvSessionRuns.SelectedItems.Count == 1)
            {
                SessionListView session = (SessionListView)lvSessionRuns.SelectedItems[0].Tag;

                CompareSetups(session.RunId, session.PreviousRunId);

                DisplayLapTimes(session.RunId, session.PreviousRunId);

                DisplayTireSheet(session.RunId, session.PreviousRunId);
            }
            else if (lvSessionRuns.SelectedItems.Count > 1)
            {
                SessionListView session1 = (SessionListView)lvSessionRuns.SelectedItems[0].Tag;
                SessionListView session2 = (SessionListView)lvSessionRuns.SelectedItems[1].Tag;

                CompareSetups(session1.RunId, session2.RunId);

                DisplayLapTimes(session1.RunId, session2.RunId);

                DisplayTireSheet(session1.RunId, session2.RunId);
            }
        }
     
        private void CompareSetups(long run1Id, long? run2Id)
        {
            try
            {
                bool hideUnchanged = this.onlyShowSetupChangesToolStripMenuItem.Checked;

                IRunRepository runRepository = _serviceProvider.GetRequiredService<IRunRepository>();

                _setup1Values = runRepository.GetSetupValues(run1Id);

                _setup2Values = run2Id.HasValue ?
                    runRepository.GetSetupValues(run2Id.Value) :
                    new List<SetupValue>();

                lvSetup.Items.Clear();

                foreach (var setup1Value in _setup1Values)
                {
                    // skip passive values
                    if (hideUnchanged &&
                        (setup1Value.Property.Name.Contains("LastHot") ||
                        setup1Value.Property.Name.Contains("RideHeight") ||
                        setup1Value.Property.Name.Contains("CornerWeight") ||
                        setup1Value.Property.Name.Contains("UpdateCount")))
                    {
                        continue;
                    }

                    string previousValue;
                    string delta;

                    if (run2Id.HasValue)
                    {
                        var setup2Value = _setup2Values
                            .FirstOrDefault(v =>
                                v.Property.Name == setup1Value.Property.Name &&
                                v.Property.Path.Path == setup1Value.Property.Path.Path);

                        if (setup2Value != null)
                        {
                            previousValue = setup2Value.Value.ToString();
                            delta = setup1Value.Value == setup2Value.Value ?
                                "-" :
                                Math.Round((setup1Value.Value - setup2Value.Value), 3).ToString();
                        }
                        else
                        {
                            previousValue = "-";
                            delta = "-";
                        }
                    }
                    else
                    {
                        previousValue = "-";
                        delta = "-";
                    }

                    if (!hideUnchanged || delta != "-")
                    {
                        var lvi = new ListViewItem(
                        new string[]
                        {
                        setup1Value.Property.Path.Path,
                        setup1Value.Property.Name,
                        setup1Value.RawValue,
                        previousValue,
                        delta,
                        setup1Value.Value.ToString(),
                        setup1Value.Property.DataType.ToString(),
                        setup1Value.Property.Units
                        });

                        lvi.Tag = setup1Value;

                        ListViewGroup itemGroup = lvSetup.Groups[setup1Value.Property.Path.Path];

                        if (itemGroup == null)
                        {
                            itemGroup = new ListViewGroup(setup1Value.Property.Path.Path, setup1Value.Property.Path.Path);

                            lvSetup.Groups.Add(itemGroup);
                        }

                        lvi.Group = itemGroup;

                        lvSetup.Items.Add(lvi);
                    }
                }

            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }

        private void DisplayLapTimes(long run1Id, long? run2Id)
        {
            IRunRepository runRepository = _serviceProvider.GetRequiredService<IRunRepository>();

            var run1Laps = runRepository.GetLaps(run1Id);
            var run2Laps = run2Id.HasValue ? runRepository.GetLaps(run2Id.Value) : null;

            int run1LapCount = run1Laps.Count();
            int? run2LapCount = run2Laps != null ? run2Laps.Count() : (int?)null; ;
            int maxLapCount = run2LapCount != null ?
                run1LapCount > run2LapCount.Value ?
                    run1LapCount :
                    run2LapCount.Value :
                run1LapCount;

            IList<LapComparison> comparison = new List<LapComparison>();

            lvLapTimes.Items.Clear();

            Single? overallDelta = 0F;
            int idx = 0;
            Single run1FastLap = 999F;
            Single run2FastLap = 999F;
            int run1FastLapIdx = 0;
            int run2FastLapIdx = 0;

            for (int i = 0; i < maxLapCount; i++)
            {
                var run1Lap = run1Laps.Skip(i).Take(1).SingleOrDefault();
                var run2Lap = run2Id.HasValue ? run2Laps.Skip(i).Take(1).SingleOrDefault() : null;
                Single? run1LapTime = run1Lap != null ? run1Lap.LapTime : (Single?)null;
                Single? run2LapTime = run2Lap != null ? run2Lap.LapTime : (Single?)null;
                Single? lapDelta = (run1LapTime.HasValue && run2LapTime.HasValue) ? run1LapTime - run2LapTime : (Single?)null;
                overallDelta += lapDelta.HasValue ? lapDelta.Value : (Single?)null;

                if (run1LapTime.HasValue)
                {
                    if (run1LapTime.Value < run1FastLap)
                    {
                        run1FastLap = run1LapTime.Value;
                        run1FastLapIdx = idx;
                    }
                }
                if (run2LapTime.HasValue)
                {
                    if (run2LapTime.Value < run2FastLap)
                    {
                        run2FastLap = run2LapTime.Value;
                        run2FastLapIdx = idx;
                    }
                }

                comparison.Add(new LapComparison()
                {
                    LapNumber = i,
                    Run1Lap = run1LapTime,
                    Run2Lap = run2LapTime,
                    LapDelta = lapDelta,
                    OverallDelta = overallDelta
                });

                idx++;
            }

            foreach (LapComparison lap in comparison)
            {
                var lvi = new ListViewItem(
                    new string[]
                    {
                    lap.LapNumber.ToString(),
                    lap.Run1Lap.HasValue ? lap.Run1Lap.Value.ToString("F2") : String.Empty,
                    lap.Run2Lap.HasValue ? lap.Run2Lap.Value.ToString("F2") : String.Empty,
                    lap.LapDelta.HasValue ? lap.LapDelta.Value.ToString("F2") : String.Empty,
                    lap.OverallDelta.HasValue ? lap.OverallDelta.Value.ToString("F2") : String.Empty,
                    });

                lvi.SubItems[3].BackColor = lap.LapDelta.HasValue && lap.LapDelta.Value < 0 ? Color.Lime : lvLapTimes.BackColor;
                lvi.SubItems[4].BackColor = lap.OverallDelta.HasValue && lap.OverallDelta.Value < 0 ? Color.Lime : lvLapTimes.BackColor;
                lvi.UseItemStyleForSubItems = false;

                lvi.Tag = lap;

                lvLapTimes.Items.Add(lvi);
            }

            // highlight the fastest laps
            if (lvLapTimes.Items.Count > run1FastLapIdx)
                lvLapTimes.Items[run1FastLapIdx].SubItems[1].BackColor = Color.GreenYellow;

            if (run2LapCount.HasValue && run2LapCount.Value > 0 && lvLapTimes.Items.Count > run2FastLapIdx)
                lvLapTimes.Items[run2FastLapIdx].SubItems[2].BackColor = Color.GreenYellow;

        }

        private void DisplayTireSheet(long runId, long? previousRunId)
        {
            IRunRepository runRepository = _serviceProvider.GetRequiredService<IRunRepository>();

            TireSheet tireSheet = runRepository.GetTireSheet(runId);

            lvTireSheet.Items.Clear();

            if (tireSheet == null)
                return;

            var run1Items = GetTireSheetListViewItems(tireSheet);

            lvTireSheet.Items.AddRange(run1Items.ToArray());

            if (previousRunId.HasValue)
            {
                TireSheet previousRunTireSheet = runRepository.GetTireSheet(previousRunId.Value);

                var previousRunItems = GetTireSheetListViewItems(previousRunTireSheet, true);

                lvTireSheet.Items.AddRange(previousRunItems.ToArray());
            }
        }
        private IList<ListViewItem> GetTireSheetListViewItems(TireSheet tireSheet)
        {
            return GetTireSheetListViewItems(tireSheet, false);
        }
        private IList<ListViewItem> GetTireSheetListViewItems(TireSheet tireSheet, bool isPrevious)
        {
            IList<ListViewItem> items = new List<ListViewItem>();

            Color previousHeaderBackColor = Color.DarkGray;
            Color headerForeColor = Color.WhiteSmoke;
            Color headerBackColor = isPrevious ? Color.DarkGray : Color.Gray;

            var lviTemps = new ListViewItem(
                new string[]
                {
                    "",
                    "",
                    "",
                    "TEMPS",
                    "",
                    "",
                    "",
                });
            lviTemps.SubItems[0].BackColor = headerBackColor;
            lviTemps.SubItems[1].BackColor = headerBackColor;
            lviTemps.SubItems[2].BackColor = headerBackColor;
            lviTemps.SubItems[3].BackColor = headerBackColor;
            lviTemps.SubItems[3].ForeColor = headerForeColor;
            lviTemps.SubItems[4].BackColor = headerBackColor;
            lviTemps.SubItems[5].BackColor = headerBackColor;
            lviTemps.SubItems[6].BackColor = headerBackColor;
            lviTemps.UseItemStyleForSubItems = false;
            items.Add(lviTemps);

            items.Add(new ListViewItem(
                   new string[]
                   {
                    tireSheet.Tires[TirePosition.LF].Temperatures[TreadPosition.Outside].ToString("F0"),
                    tireSheet.Tires[TirePosition.LF].Temperatures[TreadPosition.Middle].ToString("F0"),
                    tireSheet.Tires[TirePosition.LF].Temperatures[TreadPosition.Inside].ToString("F0"),
                    "",
                    tireSheet.Tires[TirePosition.RF].Temperatures[TreadPosition.Inside].ToString("F0"),
                    tireSheet.Tires[TirePosition.RF].Temperatures[TreadPosition.Middle].ToString("F0"),
                    tireSheet.Tires[TirePosition.RF].Temperatures[TreadPosition.Outside].ToString("F0"),
                   }));

            items.Add(new ListViewItem(
                   new string[]
                   {
                    tireSheet.Tires[TirePosition.LR].Temperatures[TreadPosition.Outside].ToString("F0"),
                    tireSheet.Tires[TirePosition.LR].Temperatures[TreadPosition.Middle].ToString("F0"),
                    tireSheet.Tires[TirePosition.LR].Temperatures[TreadPosition.Inside].ToString("F0"),
                    "",
                    tireSheet.Tires[TirePosition.RR].Temperatures[TreadPosition.Inside].ToString("F0"),
                    tireSheet.Tires[TirePosition.RR].Temperatures[TreadPosition.Middle].ToString("F0"),
                    tireSheet.Tires[TirePosition.RR].Temperatures[TreadPosition.Outside].ToString("F0"),
                   }));

            var lviWear = new ListViewItem(
               new string[]
               {
                    "",
                    "",
                    "",
                    "WEAR",
                    "",
                    "",
                    "",
               });
            lviWear.SubItems[0].BackColor = headerBackColor;
            lviWear.SubItems[1].BackColor = headerBackColor;
            lviWear.SubItems[2].BackColor = headerBackColor;
            lviWear.SubItems[3].BackColor = headerBackColor;
            lviWear.SubItems[3].ForeColor = headerForeColor;
            lviWear.SubItems[4].BackColor = headerBackColor;
            lviWear.SubItems[5].BackColor = headerBackColor;
            lviWear.SubItems[6].BackColor = headerBackColor;
            lviWear.UseItemStyleForSubItems = false;
            items.Add(lviWear);

            items.Add(new ListViewItem(
                   new string[]
                   {
                    tireSheet.Tires[TirePosition.LF].Wear[TreadPosition.Outside].ToString("F0"),
                    tireSheet.Tires[TirePosition.LF].Wear[TreadPosition.Middle].ToString("F0"),
                    tireSheet.Tires[TirePosition.LF].Wear[TreadPosition.Inside].ToString("F0"),
                    "",
                    tireSheet.Tires[TirePosition.RF].Wear[TreadPosition.Inside].ToString("F0"),
                    tireSheet.Tires[TirePosition.RF].Wear[TreadPosition.Middle].ToString("F0"),
                    tireSheet.Tires[TirePosition.RF].Wear[TreadPosition.Outside].ToString("F0"),
                   }));

            items.Add(new ListViewItem(
                   new string[]
                   {
                    tireSheet.Tires[TirePosition.LR].Wear[TreadPosition.Outside].ToString("F0"),
                    tireSheet.Tires[TirePosition.LR].Wear[TreadPosition.Middle].ToString("F0"),
                    tireSheet.Tires[TirePosition.LR].Wear[TreadPosition.Inside].ToString("F0"),
                    "",
                    tireSheet.Tires[TirePosition.RR].Wear[TreadPosition.Inside].ToString("F0"),
                    tireSheet.Tires[TirePosition.RR].Wear[TreadPosition.Middle].ToString("F0"),
                    tireSheet.Tires[TirePosition.RR].Wear[TreadPosition.Outside].ToString("F0"),
                   }));

            var lviPressures = new ListViewItem(
              new string[]
              {
                    "Cold",
                    "Hot",
                    "+/-",
                    "PSI",
                    "Cold",
                    "Hot",
                    "+/-",
              });
            lviPressures.SubItems[0].BackColor = headerBackColor;
            lviPressures.SubItems[0].ForeColor = headerForeColor;
            lviPressures.SubItems[1].BackColor = headerBackColor;
            lviPressures.SubItems[1].ForeColor = headerForeColor;
            lviPressures.SubItems[2].BackColor = headerBackColor;
            lviPressures.SubItems[2].ForeColor = headerForeColor;
            lviPressures.SubItems[3].BackColor = headerBackColor;
            lviPressures.SubItems[3].ForeColor = headerForeColor;
            lviPressures.SubItems[4].BackColor = headerBackColor;
            lviPressures.SubItems[4].ForeColor = headerForeColor;
            lviPressures.SubItems[5].BackColor = headerBackColor;
            lviPressures.SubItems[5].ForeColor = headerForeColor;
            lviPressures.SubItems[6].BackColor = headerBackColor;
            lviPressures.SubItems[6].ForeColor = headerForeColor;
            lviPressures.UseItemStyleForSubItems = false;
            items.Add(lviPressures);

            items.Add(new ListViewItem(
                   new string[]
                   {
                    tireSheet.Tires[TirePosition.LF].ColdPsi .ToString("F1"),
                    tireSheet.Tires[TirePosition.LF].HotPsi.ToString("F1"),
                    (tireSheet.Tires[TirePosition.LF].HotPsi - tireSheet.Tires[TirePosition.LF].ColdPsi).ToString("F1"),
                    "",
                    tireSheet.Tires[TirePosition.RF].ColdPsi .ToString("F1"),
                    tireSheet.Tires[TirePosition.RF].HotPsi.ToString("F1"),
                    (tireSheet.Tires[TirePosition.RF].HotPsi - tireSheet.Tires[TirePosition.RF].ColdPsi).ToString("F1"),
                   }));

            items.Add(new ListViewItem(
                   new string[]
                   {
                    tireSheet.Tires[TirePosition.LR].ColdPsi .ToString("F1"),
                    tireSheet.Tires[TirePosition.LR].HotPsi.ToString("F1"),
                    (tireSheet.Tires[TirePosition.LR].HotPsi - tireSheet.Tires[TirePosition.LR].ColdPsi).ToString("F1"),
                    "",
                    tireSheet.Tires[TirePosition.RR].ColdPsi .ToString("F1"),
                    tireSheet.Tires[TirePosition.RR].HotPsi.ToString("F1"),
                    (tireSheet.Tires[TirePosition.RR].HotPsi - tireSheet.Tires[TirePosition.RR].ColdPsi).ToString("F1"),
                   }));

            return items;
        }
        #endregion

        #region menu items
        private async void processTelemetryFileInfosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                TelemetryFileInfoView view = new TelemetryFileInfoView(_serviceProvider, _logger);

                var result = view.ShowDialog(this);

                if (result == DialogResult.OK)
                    await UpdateSessionsAsync();
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }

        private void onlyShowSetupChangesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lvSessionRuns.SelectedItems.Count == 0)
                return;
            else if (lvSessionRuns.SelectedItems.Count == 1)
            {
                SessionListView session = (SessionListView)lvSessionRuns.SelectedItems[0].Tag;

                CompareSetups(session.RunId, session.PreviousRunId);
            }
            else if (lvSessionRuns.SelectedItems.Count > 1)
            {
                SessionListView session1 = (SessionListView)lvSessionRuns.SelectedItems[0].Tag;
                SessionListView session2 = (SessionListView)lvSessionRuns.SelectedItems[1].Tag;

                CompareSetups(session1.RunId, session2.RunId);
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion

        #region classes

        private class LapComparison
        {
            public int LapNumber { get; set; }
            public Single? Run1Lap { get; set; }
            public Single? Run2Lap { get; set; }
            public Single? LapDelta { get; set; }
            public Single? OverallDelta { get; set; }
        }

        private class BestLapHistory
        {
            public int SessionIndex { get; set; }
            public long RunIndex { get; set; }
            public string Vehicle { get; set; }
            public string Track { get; set; }
            public Single LapTime { get; set; }
            public int LineIdx { get; set; }
            public ListViewItem lvi { get; set; }
        }

        #endregion
    }
}
