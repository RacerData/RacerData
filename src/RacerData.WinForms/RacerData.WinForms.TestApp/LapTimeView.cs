using Newtonsoft.Json;
using RacerData.WinForms.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RacerData.WinForms
{
    public partial class LapTimeView : Form
    {

        // XFINITY- Daytona - 35 lap fuel window

        public LapTimeView()
        {
            InitializeComponent();
        }

        private void LoadLapTimes()
        {
            var file = @"C:\Users\Rob\Documents\RacerData\Lap Times\Cup\Daytona Intl Speedway\02-14-2020\Practice 1\2-4909-20-3076.json";

            var json = File.ReadAllText(file);

            var lapData = JsonConvert.DeserializeObject<EventLapData>(json);

            var viewModel = new DriverLapTimesViewModel()
            {
                Driver = "Wallace",
                CarNumber = 22,
            };

            foreach (var item in lapData.VehicleLapTimes.Where(l => l.VehicleId == viewModel.CarNumber.ToString() && l.LapTime > 0))
            {
                viewModel.LapTimes.Add(new DriverLapTimeViewModel()
                {
                    LapNumber = item.LapNumber,
                    Time = item.LapTime,
                    TrackState = item.TrackState
                });
            }

            driverLapTimeView1.UpdateDisplay(viewModel);
        }

        private void LapTimeView_Load(object sender, EventArgs e)
        {
            try
            {
                LoadLapTimes();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                MessageBox.Show(ex.Message);
            }
        }
    }
}
