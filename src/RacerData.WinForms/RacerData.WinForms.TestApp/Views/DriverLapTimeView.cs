using RacerData.WinForms.Models;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace RacerData.WinForms.Views
{
    public partial class DriverLapTimeView : UserControl
    {
        private const string LapTimeFormat = "##.000";
        private const string LapSpeedFormat = "###.000";

        private DriverLapTimesViewModel _viewModel = null;

        public DriverLapTimeView(DriverLapTimesViewModel viewModel)
            : this()
        {
            _viewModel = viewModel;
        }

        public DriverLapTimeView()
        {
            InitializeComponent();
        }

        public void UpdateDisplay(DriverLapTimesViewModel viewModel)
        {
            if (viewModel == null)
            {
                ClearDisplay();
                return;
            }

            DisplayDriverInfo(viewModel);

            DisplayBestLapInfo(viewModel.BestLap);

            DisplayLapTimesInfo(viewModel);
        }

        protected virtual void ClearDisplay()
        {
            lblPosition.Text = "";
            lblDriver.Text = "";
            lblCarNumber.Text = "";
            lblBestLapNumber.Text = "";
            lblBestLapTime.Text = "";
            lblBestLapSpeed.Text = "";

            lvLapTimes.Items.Clear();
        }

        protected virtual void DisplayDriverInfo(DriverLapTimesViewModel viewModel)
        {
            lblPosition.Text = viewModel.Position.ToString();
            lblDriver.Text = viewModel.Driver;
            lblCarNumber.Text = viewModel.CarNumber.ToString();
        }

        protected virtual void DisplayBestLapInfo(DriverLapTimeViewModel viewModel)
        {
            if (viewModel == null)
                return;

            lblBestLapNumber.Text = viewModel.LapNumber.ToString();
            lblBestLapTime.Text = viewModel.Time.ToString(LapTimeFormat);
            lblBestLapSpeed.Text = $"{viewModel.Speed.ToString(LapSpeedFormat)} mph";
        }

        protected virtual void DisplayLapTimesInfo(DriverLapTimesViewModel viewModel)
        {
            foreach (DriverLapTimeViewModel lap in viewModel.LapTimes.OrderBy(l => l.LapNumber))
            {
                var lvi = new ListViewItem(lap.LapNumber.ToString());

                lvi.SubItems.Add(lap.Time.ToString(LapTimeFormat));
                lvi.SubItems.Add(lap.Speed.ToString(LapSpeedFormat));

                lvLapTimes.Items.Add(lvi);
            }
        }

        private void DriverLapTimeView_Load(object sender, EventArgs e)
        {
            UpdateDisplay(_viewModel);
        }
    }
}
