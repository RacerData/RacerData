using System;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using log4net;
using Microsoft.Extensions.DependencyInjection;
using RacerData.Commmon.Results;
using RacerData.UpdaterService.Models;
using RacerData.UpdaterService.Ports;

namespace RacerData.Updater.UI
{
    public partial class UpdaterDialog : Form
    {
        #region delegates

        private delegate void SafeCallDelegate(string text);
        private delegate void SafeVoidCallDelegate();

        #endregion

        #region fields

        private Version _currentVersion;
        private string _callbackApplicationName = String.Empty;
        private bool _cancelled = false;
        private bool _autoUpdate = false;
        private Process _updateProcess;
        private UpdateResponse _response;
        private UpdateFilesResponse _filesResponse;
        private DownloadFilesResponse _downloadResponse;
        private ILog _log { get; set; }

        #endregion

        #region ctor/load

        public UpdaterDialog()
        {
            InitializeComponent();
        }

        private async void UpdaterDialog_Load(object sender, EventArgs e)
        {
            _log = ServiceProvider.Instance.GetRequiredService<ILog>();

            this.Show();

            if (Program.commandLineArgs.Length < 2)
            {
                _currentVersion = new Version(0, 0, 0, 0);
            }
            else
            {
                _callbackApplicationName = Program.commandLineArgs[0];

                var versionArg = Program.commandLineArgs[1];

                if (String.IsNullOrEmpty(versionArg))
                    _currentVersion = new Version(0, 0, 0, 0);
                else
                    _currentVersion = Version.Parse(versionArg);
            }

            if (Program.commandLineArgs.Length >= 3)
            {
                _autoUpdate = (Program.commandLineArgs[2] == "1");
            }

            await RunUpdateProcess();
        }

        #endregion

        #region protected

        protected virtual void ExceptionHandler(string message, Exception ex)
        {
            _log?.Error(message, ex);

            UpdateStatus($"{message} - See error log for details");

#if DEBUG
            Console.WriteLine(ex);
#endif
            if (!_autoUpdate)
                MessageBox.Show(this, ex.Message, message, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        protected virtual void UpdateStatus(string status)
        {
            if (txtStatus.InvokeRequired)
            {
                var d = new SafeCallDelegate(UpdateStatus);
                Invoke(d, new object[] { status });
            }
            else
            {
                lblStatus.Text = status;

                txtStatus.Text += status + "\r\n";
                txtStatus.SelectionLength = 0;
            }
        }

        protected virtual async Task RunUpdateProcess()
        {
            try
            {
                UpdateStatus("Checking for updates...");
                var continueUpdate = await CheckForUpdatesAsync();

                if (!continueUpdate || _cancelled)
                {
                    CloseUpdater();
                    return;
                }

                UpdateStatus("Getting update file list...");
                continueUpdate = await GetUpdateFilesAsync();

                if (!continueUpdate || _cancelled)
                {
                    CloseUpdater();
                    return;
                }

                UpdateStatus("Downloading files...");
                continueUpdate = await DownloadUpdateFiles();

                if (!continueUpdate || _cancelled)
                {
                    CloseUpdater();
                    return;
                }

                if (!_cancelled)
                {
                    UpdateStatus("Installing update...");
                    if (!RunUpdateFile())
                    {
                        CloseUpdater();
                        return;
                    }
                }
                else
                {
                    CloseUpdater();
                    return;
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler("Error deleting temporary files", ex);
            }
        }

        protected virtual void CloseUpdater()
        {
            UpdateStatus("Closing Updater");
            CompleteUpdateProcess();
        }

        protected virtual void CompleteUpdateProcess()
        {
            if (txtStatus.InvokeRequired)
            {
                var d = new SafeVoidCallDelegate(CompleteUpdateProcess);
                Invoke(d);
            }
            else
            {
                Cleanup();

                RunCallingApplication();

                Close();
            }
        }

        protected virtual async Task<bool> CheckForUpdatesAsync()
        {
            try
            {
                var updater = ServiceProvider.Instance.GetRequiredService<IUpdateService>();

                var result = await updater.GetUpdatesAsync("rNascar", _currentVersion);

                if (!result.IsSuccessful())
                {
                    throw result.Exception;
                }

                _response = result.Value;

                if (_response.HasUpdatesAvailable)
                {
                    var updateType = ((IUpdate)_response.LatestUpdate).IsUpgrade ? "Upgrade" : "Patches";

                    var message = $"{updateType} available: {_response.LatestUpdate.Version.ToString()}.";

                    UpdateStatus(message);

                    var installUpdatePromptResult = MessageBox.Show(this, $"{message}\r\nWould you like to install?", $"Updates Available for {_currentVersion}", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                    return (installUpdatePromptResult == DialogResult.Yes);
                }
                else
                {
                    var message = $"No updates available for {_currentVersion.ToString()}";

                    UpdateStatus(message);

                    if (!_autoUpdate)
                        MessageBox.Show(message);
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler("Error checking for updates", ex);
            }

            return false;
        }

        protected virtual async Task<bool> GetUpdateFilesAsync()
        {
            try
            {
                if (_response == null)
                    return false;

                var updater = ServiceProvider.Instance.GetRequiredService<IUpdateService>();

                var result = await updater.GetUpdateFilesAsync(_response.LatestUpdate.Key);

                if (!result.IsSuccessful())
                {
                    throw result.Exception;
                }

                _filesResponse = result.Value;

                UpdateStatus($"Update files available: {_filesResponse.UpdateFiles.Count}");

                return true;
            }
            catch (Exception ex)
            {
                ExceptionHandler("Error getting update file list", ex);
            }

            return false;
        }

        protected virtual async Task<bool> DownloadUpdateFiles()
        {
            try
            {
                if (_filesResponse == null)
                    return false;

                var updater = ServiceProvider.Instance.GetRequiredService<IUpdateService>();

                var fileUrls = _filesResponse.UpdateFiles.Select(u => u.Url).ToList();

                var result = await updater.DownloadUpdateFiles(fileUrls);

                if (!result.IsSuccessful())
                {
                    throw result.Exception;
                }

                _downloadResponse = result.Value;

                UpdateStatus($"{_downloadResponse.Files.Count} update files downloaded successfully");

                return true;
            }
            catch (Exception ex)
            {
                ExceptionHandler("Error downloading update files", ex);
            }

            return false;
        }

        protected virtual bool RunUpdateFile()
        {
            try
            {
                // TODO: Checksum

                string fileToRun = String.Empty;

                if (_downloadResponse == null || _downloadResponse.Files.Count == 0)
                    return false;

                // Upgrade
                fileToRun = _downloadResponse.Files.FirstOrDefault(f => f.EndsWith("msi"));

                if (fileToRun == null)
                {
                    // patch
                    fileToRun = _downloadResponse.Files.FirstOrDefault(f => f.EndsWith("msp"));
                }

                if (fileToRun == null)
                {
                    // setup
                    fileToRun = _downloadResponse.Files.FirstOrDefault(f => f.EndsWith("exe"));
                }

                if (fileToRun == null)
                {
                    throw new ArgumentException("Did not find file to run in update file list");
                }

                _updateProcess = new Process();
                _updateProcess.Exited += new EventHandler(updateProcess_Exited);
                _updateProcess.StartInfo.Arguments = " ALLOWLAUNCHAPP=0";
                _updateProcess.StartInfo.FileName = fileToRun;
                _updateProcess.EnableRaisingEvents = true;
                return _updateProcess.Start();

            }
            catch (Exception ex)
            {
                ExceptionHandler("Error downloading update files", ex);
            }

            return false;
        }

        protected virtual void updateProcess_Exited(object sender, EventArgs e)
        {
            UpdateStatus("Installing finished");
            var exitCode = _updateProcess.ExitCode;

            if (exitCode == 1602)
            {
                UpdateStatus($"Updates were not installed - user cancelled");
            }
            else if (exitCode != 0)
            {
                UpdateStatus($"Updates were not installed successfully. Error: {exitCode}");

                if (!_autoUpdate)
                    MessageBox.Show($"Updates were not installed successfully. Error: {exitCode}");
            }

            CompleteUpdateProcess();
        }

        protected virtual void Cleanup()
        {
            try
            {
                UpdateStatus("Cleaning up temporary files...");
                if (_downloadResponse != null && Directory.Exists(_downloadResponse.TempDirectory))
                {
                    Directory.Delete(_downloadResponse.TempDirectory, true);
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler("Error deleting temporary files", ex);
            }
        }

        protected virtual bool RunCallingApplication()
        {
            try
            {
                if (String.IsNullOrEmpty(_callbackApplicationName))
                    return false;

                if (!File.Exists(_callbackApplicationName))
                    return false;

                var callingApplication = new Process();
                callingApplication.StartInfo.FileName = _callbackApplicationName;
                callingApplication.StartInfo.Arguments = "UPDATER";

                return callingApplication.Start();
            }
            catch (Exception ex)
            {
                ExceptionHandler("Error resuming calling application", ex);
            }

            return false;
        }

        #endregion

        #region private

        private void btnCancel_Click(object sender, EventArgs e)
        {
            _cancelled = true;
        }

        #endregion
    }
}
