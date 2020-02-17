using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RacerData.iRacing.Telemetry.Sdk.Factories;
using RacerData.iRacingTelemetry.TestApp.Models;
using RacerData.iRacingTelemetry.TestApp.Services;

namespace RacerData.iRacingTelemetry.TestApp
{
    public partial class ChassisAnalysisView : Form
    {
        public ChassisAnalysisView()
        {
            InitializeComponent();
        }


        private async void ChassisAnalysisView_Load(object sender, EventArgs e)
        {
            try
            {
                string telemetryFile = @"C:\Users\Rob\Documents\iRacing\telemetry\skmodified_irp 2019-08-14 00-58-20.ibt";

                var reader = TelemetryFileReaderFactory.GetTelemetryFileReader(telemetryFile);

                var telemetry = await reader.ReadTelemetryFileAsync();

                var setup = telemetry.SessionInfo.CarSetup;

                var model = new SkModifiedChassisModel("Run1");

                model.LoadSetupParameters(setup);

                vehicleChassisModelBindingSource.DataSource = new BindingList<VehicleChassisModel>(new List<VehicleChassisModel>() { model });

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Console.WriteLine(ex.ToString());
            }
        }

        private void btnAnalyze_Click(object sender, EventArgs e)
        {
            try
            {
                SkModifiedChassisModel model = (SkModifiedChassisModel)vehicleChassisModelBindingSource.Current;

                ChassisAnalysis analysis = ChassisAnalysisService.AnalyzeChassis(model);

                this.chassisAnalysisBindingSource.DataSource = analysis;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
