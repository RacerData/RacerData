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
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using RacerData.iRacing.Extensions;
using RacerData.iRacing.Service.Sessions;
using RacerData.iRacing.Telemetry;
using RacerData.iRacing.Telemetry.Sdk.Adapters;
using RacerData.iRacing.Telemetry.Sdk.Factories;
using RacerData.iRacingTelemetry.TestApp.Models;
using RacerData.iRacingTelemetry.TestApp.Properties;
using RacerData.iRacingTelemetry.TestApp.Services;
using RacerData.Logging;
using RacerData.Logging.Ports;

namespace RacerData.iRacingTelemetry.TestApp
{
    public partial class VehicleConfiguration : Form
    {
        #region fields

        private string _vcFile = @"C:\Users\Rob\source\repos\RacerData\src\RacerData.iRacing.Setups\RacerData.iRacingTelemetry.TestApp\vcData.json";
        private IList<VehicleConfigurationModel> _vcContext = new List<VehicleConfigurationModel>();

        private ILoggerService _logger;
        private IServiceProvider _serviceProvider;

        #endregion

        #region properties

        #endregion

        #region ctor

        public VehicleConfiguration()
        {
            InitializeComponent();
        }

        #endregion

        #region public

        #endregion

        #region protected

        #endregion

        #region private

        #region common

        private void ExceptionHandler(Exception ex)
        {
            ExceptionHandler(ex, "Exception in VehicleConfiguration");
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
            //services.AddRacerDataLogging();

            _serviceProvider = services.BuildServiceProvider();
            //_logger = _serviceProvider.GetRequiredService<ILoggerService>();
        }

        #endregion

        #region form events

        private void VehicleConfiguration_Load(object sender, EventArgs e)
        {
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

            ConfigureServices();

            LoadvcContext();
        }

        private void VehicleConfiguration_FormClosing(object sender, FormClosingEventArgs e)
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

        #endregion

        #endregion

        private async void button1_Click(object sender, EventArgs e)
        {
            string telemetryFile = @"C:\Users\Rob\Documents\iRacing\telemetry\skmodified_irp 2019-08-14 00-58-20.ibt";

            var reader = TelemetryFileReaderFactory.GetTelemetryFileReader(telemetryFile);

            var telemetry = await reader.ReadTelemetryFileAsync();

            IList<float> damperVelocitiesLF = new List<float>();
            IList<float> damperVelocitiesLR = new List<float>();
            IList<float> damperVelocitiesRF = new List<float>();
            IList<float> damperVelocitiesRR = new List<float>();

            foreach (ITelemetryFrame frame in telemetry.Frames)
            {
                damperVelocitiesLF.Add(frame.LFshockVel * 1000);
                damperVelocitiesLR.Add(frame.LRshockVel * 1000);
                damperVelocitiesRF.Add(frame.RFshockVel * 1000);
                damperVelocitiesRR.Add(frame.RRshockVel * 1000);
            }

            var histogramDataLF = VehicleConfigurationHelper.GetDamperHistogramData(damperVelocitiesLF);
            var histogramDataLR = VehicleConfigurationHelper.GetDamperHistogramData(damperVelocitiesLR);
            var histogramDataRF = VehicleConfigurationHelper.GetDamperHistogramData(damperVelocitiesRF);
            var histogramDataRR = VehicleConfigurationHelper.GetDamperHistogramData(damperVelocitiesRR);

            Console.WriteLine("------ Left Front ------");
            PrintHistogram(histogramDataLF);
            Console.WriteLine("------ Left Rear ------");
            PrintHistogram(histogramDataLR);
            Console.WriteLine("------ Right Front ------");
            PrintHistogram(histogramDataRF);
            Console.WriteLine("------ Right Rear ------");
            PrintHistogram(histogramDataRR);

        }
        private void PrintHistogram(HistogramData histogramData)
        {
            Console.WriteLine($"HSR:{Math.Round(histogramData.HighSpeedRebound, 2)}\t" +
                  $"LSR:{Math.Round(histogramData.LowSpeedRebound, 2)}\t" +
                  $"Zero:{Math.Round(histogramData.ZeroBin * 100, 2)}%\t" +
                  $"LSB:{Math.Round(histogramData.LowSpeedBump, 2)}\t" +
                  $"HSB:{Math.Round(histogramData.HighSpeedBump, 2)}");

            for (int i = 0; i < histogramData.Histogram.Count - 1; i++)
            {
                Console.WriteLine($"{histogramData.Histogram.Keys.ElementAt(i),4} - " +
                    $"{histogramData.Histogram.Keys.ElementAt(i + 1),4}: " +
                    $"{Math.Round(histogramData.Histogram[histogramData.Histogram.Keys.ElementAt(i)] * 100, 2)}%");
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            vehicleConfigurationModelBindingSource.CancelEdit();
        }

        private void vehicleWheelSettingsBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            SaveConfigurationSet(_vcContext, _vcFile);
        }

        private void SaveConfigurationSet(IList<VehicleConfigurationModel> vcContext, string vcFile)
        {
            var json = JsonConvert.SerializeObject(vcContext);
            File.WriteAllText(vcFile, json);
        }

        private IList<VehicleConfigurationModel> LoadConfigurationSet()
        {
            if (!File.Exists(_vcFile))
                return new List<VehicleConfigurationModel>();

            var json = File.ReadAllText(_vcFile);
            return JsonConvert.DeserializeObject<List<VehicleConfigurationModel>>(json);
        }

        private void LoadvcContext()
        {
            _vcContext = LoadConfigurationSet();

            if (_vcContext.Count == 0)
                _vcContext.Add(new VehicleConfigurationModel(2));

            vehicleConfigurationModelBindingSource.DataSource = new BindingList<VehicleConfigurationModel>(_vcContext);

            lfWheelBindingSource.DataSource = vehicleConfigurationModelBindingSource.Current;
            lfWheelBindingSource.DataMember = "LFWheel";
            rfWheelBindingSource.DataSource = vehicleConfigurationModelBindingSource.Current;
            rfWheelBindingSource.DataMember = "RFWheel";
            lrWheelBindingSource.DataSource = vehicleConfigurationModelBindingSource.Current;
            lrWheelBindingSource.DataMember = "LRWheel";
            rrWheelBindingSource.DataSource = vehicleConfigurationModelBindingSource.Current;
            rrWheelBindingSource.DataMember = "RRWheel";

        }

        private void vehicleConfigurationModelDataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            Console.WriteLine($"context:{e.Context.ToString()} r:{ e.RowIndex}; c:{e.ColumnIndex}");
        }

        private void vehicleConfigurationModelBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            lfWheelBindingSource.DataSource = vehicleConfigurationModelBindingSource.Current;
            lfWheelBindingSource.DataMember = "LFWheel";
            rfWheelBindingSource.DataSource = vehicleConfigurationModelBindingSource.Current;
            rfWheelBindingSource.DataMember = "RFWheel";
            lrWheelBindingSource.DataSource = vehicleConfigurationModelBindingSource.Current;
            lrWheelBindingSource.DataMember = "LRWheel";
            rrWheelBindingSource.DataSource = vehicleConfigurationModelBindingSource.Current;
            rrWheelBindingSource.DataMember = "RRWheel";
        }

        private void openButton_Click(object sender, EventArgs e)
        {
            LoadvcContext();
        }

        private void copyButton_Click(object sender, EventArgs e)
        {
            var current = (VehicleConfigurationModel)vehicleConfigurationModelBindingSource.Current;
            var clone = current.Clone();
            _vcContext.Add(clone);
            vehicleConfigurationModelBindingSource.ResetBindings(false);
        }

        private void swayBarConfiguration_Click(object sender, EventArgs e)
        {
            var current = (VehicleConfigurationModel)vehicleConfigurationModelBindingSource.Current;
            var dialog = new SwayBarConfiguration()
            {
                Model = current.SwayBar
            };

            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                current.SwayBar = dialog.Model;
            }
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            VehicleConfigurationModel model = (VehicleConfigurationModel)vehicleConfigurationModelBindingSource.Current;

            string telemetryFile = @"C:\Users\Rob\Documents\iRacing\telemetry\skmodified_irp 2019-08-14 00-58-20.ibt";

            var reader = TelemetryFileReaderFactory.GetTelemetryFileReader(telemetryFile);

            var telemetry = await reader.ReadTelemetryFileAsync();

            // get setup values
            var setup = telemetry.SessionInfo.CarSetup;
            IDictionary<object, object> chassis = (IDictionary<object, object>)setup.ValuesDictionary["Chassis"];
            double lfRideHeightS = GetCornerRideHeight(chassis, "LeftFront");
            double lrRideHeightS = GetCornerRideHeight(chassis, "LeftRear");
            double rfRideHeightS = GetCornerRideHeight(chassis, "RightFront");
            double rrRideHeightS = GetCornerRideHeight(chassis, "RightRear");
            double lfWeightS = GetCornerWeight(chassis, "LeftFront");
            double lrWeightS = GetCornerWeight(chassis, "LeftRear");
            double rfWeightS = GetCornerWeight(chassis, "RightFront");
            double rrWeightS = GetCornerWeight(chassis, "RightRear");
            int lfSpringRateS = GetCornerSpringRate(chassis, "LeftFront");
            int lrSpringRateS = GetCornerSpringRate(chassis, "LeftRear");
            int rfSpringRateS = GetCornerSpringRate(chassis, "RightFront");
            int rrSpringRateS = GetCornerSpringRate(chassis, "RightRear");
            double swayBarSize = GetSwayBarSize(chassis);

            //int skipInterval = 60; // every nth frame
            //int frameCount = 100; // max # of frames to return
            //var frames = telemetry.Frames.Where((x, i) => i % skipInterval == 0).Take(frameCount);
            var frames = telemetry.Frames.Where(l => l.Lap <= 75 && l.LFspeed > 0);
            foreach (ITelemetryFrame frame in frames)
            {
                double lfRideHeight = frame.LFrideHeight * 39.3701; // meters to inches 39.3701
                double rfRideHeight = frame.RFrideHeight * 39.3701; // meters to inches 39.3701
                double lrRideHeight = frame.LRrideHeight * 39.3701; // meters to inches 39.3701
                double rrRideHeight = frame.RRrideHeight * 39.3701; // meters to inches 39.3701

                double lfRHDelta = lfRideHeightS - lfRideHeight;
                double rfRHDelta = rfRideHeightS - rfRideHeight;
                double lrRHDelta = lrRideHeightS - lrRideHeight;
                double rrRHDelta = rrRideHeightS - rrRideHeight;

                var lfLoadDelta = model.FrontInstallationRatio * lfRHDelta * lfSpringRateS;
                var rfLoadDelta = model.FrontInstallationRatio * rfRHDelta * rfSpringRateS;
                var lrLoadDelta = model.RearInstallationRatio * lrRHDelta * lrSpringRateS;
                var rrLoadDelta = model.RearInstallationRatio * rrRHDelta * rrSpringRateS;

                var lfDynamicLoad = lfWeightS + lfLoadDelta;
                var rfDynamicLoad = rfWeightS + rfLoadDelta;
                var lrDynamicLoad = lrWeightS + lrLoadDelta;
                var rrDynamicLoad = rrWeightS + rrLoadDelta;

                var dynamicTotal = lfDynamicLoad + rfDynamicLoad + lrDynamicLoad + rrDynamicLoad;
                var dynamicWedge = (lrDynamicLoad + rfDynamicLoad) / dynamicTotal;
                var dynamicFront = (lfDynamicLoad + rfDynamicLoad) / dynamicTotal;

                Console.WriteLine($"{frame.Lap}:{Math.Round(frame.LapDistPct, 2),-6}  " +
                   $"({Math.Round(lfRHDelta, 2),-5})" +
                   $"[ {Math.Round(lfDynamicLoad, 0),-4} ] " +
                   $"({Math.Round(rfRHDelta, 2),-5})" +
                   $"[ {Math.Round(rfDynamicLoad, 0),-4} ]");

                Console.WriteLine($"{frame.Lap}:{Math.Round(frame.LapDistPct, 2),-6}  " +
                   $"({Math.Round(lrRHDelta, 2),-5})" +
                   $"[ {Math.Round(lrDynamicLoad, 0),-4} ] " +
                   $"({Math.Round(rrRHDelta, 2),-5})" +
                   $"[ {Math.Round(rrDynamicLoad, 0),-4} ] " +
                   $"Total[{Math.Round(dynamicTotal, 0),-4}] " +
                   $"Front[{Math.Round(dynamicWedge, 2),-4}%] " +
                   $"Cross[{Math.Round(dynamicFront, 2),-4}%] " +
                   $"Accel[{Math.Round(frame.Throttle * 100, 0),-4}%] " +
                   $"Brake[{Math.Round(frame.Brake * 100, 0),-4}%] " +
                   $"Pitch ^ [{Math.Round(frame.Pitch.RadiansToDegrees(), 2),-4}] " +
                   $"LongAccel[{Math.Round((frame.LongAccel / 9.8), 2),-4}]   " +
                   $"Steering <> [{Math.Round(frame.SteeringWheelAngle.RadiansToDegrees(), 2),-4}] " +
                   $"Roll[{Math.Round(frame.Roll.RadiansToDegrees(), 2),-4}] " +
                   $"LatAccel[{Math.Round((frame.LatAccel / 9.8), 2),-4}]");

                Console.WriteLine();
            }
        }

        private double GetCornerRideHeight(IDictionary<object, object> chassis, string corner)
        {
            IDictionary<object, object> chassisCorner = (IDictionary<object, object>)chassis[corner];
            return chassisCorner["RideHeight"].ToString().GetRideHeight();
        }
        private double GetCornerWeight(IDictionary<object, object> chassis, string corner)
        {
            IDictionary<object, object> chassisCorner = (IDictionary<object, object>)chassis[corner];
            return chassisCorner["CornerWeight"].ToString().GetWeight();
        }
        private int GetCornerSpringRate(IDictionary<object, object> chassis, string corner)
        {
            IDictionary<object, object> chassisCorner = (IDictionary<object, object>)chassis[corner];
            return chassisCorner["SpringRate"].ToString().GetSpringRate();
        }
        private double GetSwayBarSize(IDictionary<object, object> chassis)
        {
            IDictionary<object, object> chassisCorner = (IDictionary<object, object>)chassis["Front"];
            return chassisCorner["AntiRollBarSize"].ToString().GetAntiRollBarSize();
        }
    }
}
