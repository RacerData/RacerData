using System;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;
using RacerData.iRacing.SessionMonitor.Presenters;
using RacerData.iRacing.SessionMonitor.ViewModels;
using RacerData.iRacing.SessionMonitor.Views;
using RacerData.iRacing.Sessions.Ui.LapTimeChart;
using RacerData.iRacing.Sessions.Ui.TireSheet;

namespace RacerData.iRacing.SessionMonitor
{
    public partial class iRacingSessionMonitor : Form, ISessionView
    {
        #region delegates

        private delegate void UpdateStatusTextDelegate(string value);
        private delegate void AddSessionRunDelegate(SessionRunViewModel sessionRunViewModel);

        #endregion

        #region fields

        private SessionViewModel _viewModel = null;
        private SessionPresenter _presenter = null;

        #endregion

        #region properties

        DataGridView ISessionView.SessionRuns => dgvSessionRuns;
        DataGridView ISessionView.SelectedLapsComparison => dgvLaps;
        LapTimeChartView ISessionView.LapTimeChart => lapTimeChartView1;
        TireSheetView ISessionView.TireSheetView => tireSheetView1;
        TireSheetView ISessionView.TireSheetView2 => tireSheetView2;

        #endregion

        #region ctor/load

        public iRacingSessionMonitor()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            _viewModel = new SessionViewModel();

            _presenter = new SessionPresenter(SynchronizationContext.Current, this, _viewModel);
        }

        #endregion

        #region private

        private void ExceptionHandler(Exception ex, string message)
        {
            ((ISessionView)this).ExceptionHandler(ex, message);
        }
        void ISessionView.ExceptionHandler(Exception ex, string message)
        {
            MessageBox.Show($"{DateTime.Now}: {message} {ex.Message}");
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void iRacingSessionMonitor_FormClosing(object sender, FormClosingEventArgs e)
        {
            _presenter.StopServices();
            _presenter.Dispose();
            _presenter = null;
        }

        #region status labels

        public void ClearStatusLabels()
        {
            ClearTrackDisplay();
            ClearVehicleDisplay();
            ClearEventTypeDisplay();
            ClearSessionTypeDisplay();
            ClearActivityStatusDisplay();
            lblSetup.Text = "-";
        }
        public void UpdateStatusLabels()
        {
            UpdateTrackDisplay(_viewModel.Track);
            UpdateVehicleDisplay(_viewModel.Vehicle);
            UpdateEventTypeDisplay(_viewModel.EventType);
            UpdateSessionTypeDisplay(_viewModel.SessionType);
            UpdateActivityStatusDisplay(_viewModel.ActivityStatus);

            lblSdkStatus.Text = _viewModel.Connected ? "Connected!" : "Waiting for iRacing...";
            lblSetup.Text = _viewModel.SetupName;
        }

        private void ClearActivityStatusDisplay()
        {
            UpdateActivityStatusDisplay(String.Empty);
        }
        private void UpdateActivityStatusDisplay(ActivityStatus value)
        {
            UpdateActivityStatusDisplay(value.ToString());
        }
        private void UpdateActivityStatusDisplay(string value)
        {
            if (statusStrip1.InvokeRequired)
            {
                var d = new UpdateStatusTextDelegate(UpdateActivityStatusDisplay);
                Invoke(d, new object[] { value });
            }
            else
            {
                lblActivityStatus.Text = value;
            }
        }

        private void ClearTrackDisplay()
        {
            UpdateTrackDisplay(String.Empty);
        }
        private void UpdateTrackDisplay(string value)
        {
            if (statusStrip1.InvokeRequired)
            {
                var d = new UpdateStatusTextDelegate(UpdateTrackDisplay);
                Invoke(d, new object[] { value });
            }
            else
            {
                lblTrack.Text = value;
            }
        }

        private void ClearVehicleDisplay()
        {
            UpdateVehicleDisplay(String.Empty);
        }
        private void UpdateVehicleDisplay(string value)
        {
            if (statusStrip1.InvokeRequired)
            {
                var d = new UpdateStatusTextDelegate(UpdateVehicleDisplay);
                Invoke(d, new object[] { value });
            }
            else
            {
                lblVehicle.Text = value;
            }
        }

        private void ClearEventTypeDisplay()
        {
            UpdateEventTypeDisplay(String.Empty);
        }
        private void UpdateEventTypeDisplay(string value)
        {
            if (statusStrip1.InvokeRequired)
            {
                var d = new UpdateStatusTextDelegate(UpdateEventTypeDisplay);
                Invoke(d, new object[] { value });
            }
            else
            {
                lblEventType.Text = value;
            }
        }

        private void ClearSessionTypeDisplay()
        {
            UpdateSessionTypeDisplay(String.Empty);
        }
        private void UpdateSessionTypeDisplay(string value)
        {
            if (statusStrip1.InvokeRequired)
            {
                var d = new UpdateStatusTextDelegate(UpdateSessionTypeDisplay);
                Invoke(d, new object[] { value });
            }
            else
            {
                lblSessionType.Text = value;
            }
        }

        private void ClearSetupNameDisplay()
        {
            UpdateSetupNameDisplay(String.Empty);
        }
        private void UpdateSetupNameDisplay(string value)
        {
            if (statusStrip1.InvokeRequired)
            {
                var d = new UpdateStatusTextDelegate(UpdateSetupNameDisplay);
                Invoke(d, new object[] { value });
            }
            else
            {
                lblSetup.Text = value;
            }
        }

        #endregion

        #endregion

        #region development

        private void addRunToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _presenter.AddRun();
            //var lastSessionLap = _viewModel.SessionRuns.Count == 0 ? 0 : _viewModel.SessionRuns.Max(r => r.SessionEndLap);

            //var nextSessionLap = lastSessionLap + 1;

            //var lastSessionId = _viewModel.SessionRuns.Count == 0 ? 0 : _viewModel.SessionRuns.Max(s => s.Id);

            //var nextSessionId = lastSessionId + 1;

            //var sessionRunViewModel = GetSessionRunViewModel(nextSessionLap, nextSessionId);

            //_viewModel.SessionRuns.Add(sessionRunViewModel);
        }

        private void removeLastRunToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _presenter.RemoveLastRun();
            //if (_viewModel.SessionRuns.Count > 0)
            //    _viewModel.SessionRuns.RemoveAt(_viewModel.SessionRuns.Count - 1);
        }

        private void clearRunsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _presenter.ClearRuns();
        }

        private void tsbAddRuns_Click(object sender, EventArgs e)
        {
            _presenter.AddRuns();
        }

        private void addRunsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _presenter.AddRuns();
        }

        #endregion

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _presenter.RemoveSelectedRuns();
        }

        private void clearAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _presenter.ClearRuns();
        }

        private void ctxSessionRuns_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = (dgvSessionRuns.Rows.Count == 0);

            deleteToolStripMenuItem.Enabled = (dgvSessionRuns.SelectedRows.Count > 0);
        }

        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _presenter.StartServices();
        }

        private void stopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _presenter.StopServices();
        }

        private void reloadTelemetryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _presenter.ReloadDirectory();
        }

        private void telemetryDirectoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", @"C:\Users\Rob\Documents\iRacing\telemetry");
        }
    }
}