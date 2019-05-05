using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using log4net;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RacerData.LiveFeedMonitor.Dialogs;
using RacerData.LiveFeedMonitor.Logging;
using RacerData.NascarApi.Client.Models.LiveFeed;
using RacerData.NascarApi.Harvester.Service.Ports;
using RacerData.NascarApi.LapAverage.Service.Ports;
using RacerData.NascarApi.Service;
using RacerData.NascarApi.Service.Ports;

namespace RacerData.LiveFeedMonitor
{
    public partial class MainConsole : Form
    {
        #region fields

        private delegate void SafeStringCallDelegate(string text);
        private delegate void SafeStringAndColorCallDelegate(string text, Color color);
        private delegate void SafeBooleanCallDelegate(bool value);

        private static Color HeaderTextColor = Color.Gray;
        private static Color InfoTextColor = Color.LightGray;
        private static Color ActivityTextColor = Color.Cyan;
        private static Color ErrorTextColor = Color.Red;

        private bool _verbose = false;
        private bool _autoStartService = false;
        private bool _isRunning = false;
        private ILog _log;
        private IMonitorService _monitorService;
        private CancellationToken _cancellationToken;
        private CancellationTokenSource _cancellationTokenSource;

        #endregion

        #region ctor/load

        public MainConsole()
        {
            InitializeComponent();
        }

        private void MainConsole_Load(object sender, EventArgs e)
        {
            try
            {
                Logger.Setup();

                var configuration = ServiceProvider.Instance.GetRequiredService<IConfiguration>();

                _autoStartService = configuration["monitor:autoStartService"] == "true";
                _verbose = configuration["monitor:verbose"] == "true";

                _monitorService = ServiceProvider.Instance.GetRequiredService<IMonitorService>();

                _log = ServiceProvider.Instance.GetRequiredService<ILog>();

                _monitorService.LiveFeedStarted += _monitorService_LiveFeedStarted;
                _monitorService.ServiceStateChanged += _monitorService_ServiceStateChanged;
                _monitorService.ServiceActivity += _monitorService_ServiceActivity;
                _monitorService.ServiceStatusChanged += _monitorService_ServiceStatusChanged;

                var awsDataPump = ServiceProvider.Instance.GetRequiredService<ILapAverageHandler>();

                _monitorService.Register(awsDataPump);

                var fileHarvester = ServiceProvider.Instance.GetRequiredService<INascarApiHarvester>();

                _monitorService.Register(fileHarvester);

                UpdateStatus("Live Feed Monitor ready");

                foreach (ToolStripItem item in ctxWakeTarget.Items)
                {
                    item.ForeColor = btnSleep.ForeColor;
                    item.BackColor = btnSleep.BackColor;
                }

                if (_autoStartService)
                {
                    StartMonitor();
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler("Error starting monitor", ex);
            }
        }

        #endregion

        #region protected

        protected virtual void ExceptionHandler(string message, Exception ex)
        {
            if (_log != null)
                _log.Error(message, ex);
#if DEBUG
            Console.WriteLine(ex);
#endif
            ConsoleErrorMessage($"{message}: {ex.Message}");
        }

        protected virtual CancellationToken GetCancellationToken()
        {
            if (_cancellationToken != null)
                return _cancellationToken;

            _cancellationTokenSource = new CancellationTokenSource();
            return _cancellationTokenSource.Token;
        }

        protected virtual void ConsoleInfoMessage(string message)
        {
            try
            {
                _log?.Info(message);

                DisplayConsoleMessage(message, InfoTextColor);
            }
            catch (Exception ex)
            {
                ExceptionHandler("", ex);
            }
        }

        protected virtual void ConsoleActivityMessage(string message)
        {
            try
            {
                if (!_verbose)
                    return;

                _log?.Info(message);

                DisplayConsoleMessage(message, ActivityTextColor);
            }
            catch (Exception ex)
            {
                ExceptionHandler("", ex);
            }
        }

        protected virtual void ConsoleErrorMessage(string message)
        {
            try
            {
                DisplayConsoleMessage(message, ErrorTextColor);
            }
            catch (Exception ex)
            {
                ExceptionHandler("", ex);
            }
        }

        protected virtual string GetConsoleMessageHeader()
        {
            return $"{DateTime.Now.ToString()}: ";
        }

        protected virtual void DisplayConsoleMessage(string message, Color color)
        {
            PrintConsoleMessage(GetConsoleMessageHeader(), HeaderTextColor);
            PrintConsoleMessage(message, color);
            PrintConsoleMessage("\r\n", color);
        }

        protected virtual void PrintConsoleMessage(string message, Color color)
        {
            if (rtbOut.InvokeRequired)
            {
                var d = new SafeStringAndColorCallDelegate(PrintConsoleMessage);
                Invoke(d, new object[] { message, color });
            }
            else
            {
                int start = rtbOut.TextLength;
                rtbOut.AppendText(message);
                int end = rtbOut.TextLength;

                rtbOut.Select(start, end - start);
                {
                    rtbOut.SelectionColor = color;
                }
                rtbOut.SelectionLength = 0;
            }

            rtbOut.SelectionStart = (rtbOut.TextLength);
            rtbOut.ScrollToCaret();
        }

        protected virtual void UpdateStatus(string status)
        {
            if (lblStatus.InvokeRequired)
            {
                var d = new SafeStringCallDelegate(UpdateStatus);
                Invoke(d, new object[] { status });
            }
            else
            {
                lblStatus.Text = status;
                lblActivity.Text = "";
            }

            ConsoleInfoMessage(status);
        }

        protected virtual void UpdateActivity(string activity)
        {
            if (lblActivity.InvokeRequired)
            {
                var d = new SafeStringCallDelegate(UpdateActivity);
                Invoke(d, new object[] { activity });
            }
            else
            {
                if (activity.Contains("Error"))
                {
                    ConsoleErrorMessage(activity);
                }
                else if (activity.Contains("sleep"))
                {
                    ConsoleInfoMessage(activity);
                }
                else
                {
                    ConsoleActivityMessage(activity);
                }

                lblActivity.Text = activity;
            }
        }

        protected virtual void StopMonitor()
        {
            _monitorService.Pause();
        }

        protected virtual void StartMonitor()
        {
            _cancellationToken = GetCancellationToken();

            _monitorService.Start(_cancellationToken);
        }

        protected virtual void SleepMonitor(DateTime wakeTarget)
        {
            _monitorService.Sleep(wakeTarget);
        }

        protected virtual void ClearConsole()
        {
            rtbOut.Clear();
        }

        protected virtual void CopyConsole()
        {
            rtbOut.SelectAll();
            rtbOut.Copy();
            rtbOut.SelectionLength = 0;
        }

        protected virtual void ServiceStateChanged(ServiceState state)
        {
            if (state == ServiceState.Paused)
            {
                _isRunning = false;
            }
            else if (state == ServiceState.Running)
            {
                _isRunning = true;
            }
            else if (state == ServiceState.Error)
            {
                _isRunning = false;
            }
            else if (state == ServiceState.Sleep)
            {
                _isRunning = true;
            }

            UpdateButtonStates(_isRunning);
        }

        protected virtual void UpdateButtonStates(bool isRunning)
        {
            if (btnStop.InvokeRequired)
            {
                var d = new SafeBooleanCallDelegate(UpdateButtonStates);
                Invoke(d, new object[] { isRunning });
            }
            else
            {
                btnStop.Enabled = isRunning;
                btnStart.Enabled = !isRunning;
                btnSleep.Enabled = !isRunning;
            }
        }

        protected virtual void LiveFeedStarted(LiveFeedInfo liveFeedInfo)
        {
            UpdateActivity(liveFeedInfo.RunName);
        }

        protected virtual void SelectWakeTarget()
        {
            ctxWakeTarget.Show(btnSleep, new Point(0, btnSleep.Height));
        }

        protected virtual void DisplayLog()
        {
            using (var dialog = new FileViewerDialog() { Title = "Log File", FilePath = Logger.GetLogFilePath() })
            {
                dialog.ShowDialog(this);
            }
        }

        #endregion

        #region private

        private void mnuSleep1Hour_Click(object sender, EventArgs e)
        {
            try
            {
                SleepMonitor(DateTime.Now.AddHours(1));
            }
            catch (Exception ex)
            {
                ExceptionHandler("Error setting sleep to 1 hour", ex);
            }
        }

        private void mnuSleep1Day_Click(object sender, EventArgs e)
        {
            try
            {
                SleepMonitor(DateTime.Now.AddDays(1));
            }
            catch (Exception ex)
            {
                ExceptionHandler("Error setting sleep to 1 day", ex);
            }
        }

        private void mnuSleep3Days_Click(object sender, EventArgs e)
        {
            try
            {
                SleepMonitor(DateTime.Now.AddDays(3));
            }
            catch (Exception ex)
            {
                ExceptionHandler("Error setting sleep to 3 days", ex);
            }
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                ClearConsole();
            }
            catch (Exception ex)
            {
                ExceptionHandler("Error clearing console text", ex);
            }
        }

        private void copyAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                CopyConsole();
            }
            catch (Exception ex)
            {
                ExceptionHandler("Error copying console text", ex);
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            try
            {
                StartMonitor();
            }
            catch (Exception ex)
            {
                ExceptionHandler("Error starting monitor", ex);
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            try
            {
                StopMonitor();
            }
            catch (Exception ex)
            {
                ExceptionHandler("Error pausing monitor", ex);
            }
        }

        private void btnSleep_Click(object sender, EventArgs e)
        {
            try
            {
                SelectWakeTarget();
            }
            catch (Exception ex)
            {
                ExceptionHandler("Error putting monitor to sleep", ex);
            }
        }

        private void btnLog_Click(object sender, EventArgs e)
        {
            try
            {
                DisplayLog();
            }
            catch (Exception ex)
            {
                ExceptionHandler("Error displaying log", ex);
            }
        }

        private void _monitorService_ServiceActivity(object sender, ServiceActivityEventArgs e)
        {
            try
            {
                UpdateActivity(e.ServiceActivity);
            }
            catch (Exception ex)
            {
                ExceptionHandler("Error updating monitor activity", ex);
            }
        }

        private void _monitorService_ServiceStateChanged(object sender, ServiceStateChangedEventArgs e)
        {
            try
            {
                ServiceStateChanged(e.State);
            }
            catch (Exception ex)
            {
                ExceptionHandler("Error in monitor state changed handler", ex);
            }
        }

        private void _monitorService_LiveFeedStarted(object sender, LiveFeedStartedEventArgs e)
        {
            try
            {
                LiveFeedStarted(e.LiveFeedInfo);
            }
            catch (Exception ex)
            {
                ExceptionHandler("Error in monitor feed started handler", ex);
            }
        }

        private void _monitorService_ServiceStatusChanged(object sender, ServiceStatusChangedEventArgs e)
        {
            try
            {
                UpdateStatus(e.ServiceStatus);
            }
            catch (Exception ex)
            {
                ExceptionHandler("Error updating monitor activity", ex);
            }
        }
        #endregion
    }
}
