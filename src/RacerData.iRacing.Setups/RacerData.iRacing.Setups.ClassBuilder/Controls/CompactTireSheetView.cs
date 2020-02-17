using System;
using System.Windows.Forms;
using RacerData.iRacing.Setups.ClassBuilder.Models;
using RacerData.iRacing.Telemetry;

namespace RacerData.iRacing.Setups.ClassBuilder.Controls
{
    public partial class CompactTireSheetView : UserControl
    {
        #region properties

        public double TempWarning { get; set; } = 2;
        public double WearWarning { get; set; } = 1;
        public bool EnableWarnings {get;set;} = false;

        private TireSheetValues _model;
        public TireSheetValues Model
        {
            get
            {
                return _model;
            }
            set
            {
                _model = value;
                DisplayModel(_model);
            }
        }

        #endregion

        #region ctor

        public CompactTireSheetView()
        {
            InitializeComponent();
        }

        #endregion

        #region protected

        protected virtual void ExceptionHandler(Exception ex)
        {
            Console.WriteLine(ex.ToString());
            MessageBox.Show(ex.Message);
        }

        protected virtual void DisplayModel(TireSheetValues model)
        {
            if (model == null)
                return;

            lblSetup.Text = model.Setup;

            lblLaps.Text = $"Laps: {model.Laps}";
            lblBestLap.Text = $"Best: {Math.Round(model.BestLap, 3)}";
            lblAvgLaps.Text = $"Avg: {Math.Round(model.AverageLap, 3)}";

            var lfTire = model.Tires[TirePosition.LF];
            lfTireTempView.DisplayValues(
                lfTire.Temperatures.Outside,
                lfTire.Temperatures.Middle,
                lfTire.Temperatures.Inside,
                lfTire.EffectiveTemperature);

            var lrTire = model.Tires[TirePosition.LR];
            lrTireTempView.DisplayValues(
                lrTire.Temperatures.Outside,
                lrTire.Temperatures.Middle,
                lrTire.Temperatures.Outside,
                lrTire.EffectiveTemperature);

            var rfTire = model.Tires[TirePosition.RF];
            rfTireTempView.DisplayValues(
                rfTire.Temperatures.Inside,
                rfTire.Temperatures.Middle,
                rfTire.Temperatures.Outside,
                rfTire.EffectiveTemperature);

            var rrTire = model.Tires[TirePosition.RR];
            rrTireTempView.DisplayValues(
                rrTire.Temperatures.Inside,
                rrTire.Temperatures.Middle,
                rrTire.Temperatures.Outside,
                rrTire.EffectiveTemperature);

            lfTireTempView.Warning = EnableWarnings && Math.Abs(model.LeftTempDelta) < TempWarning;
            lrTireTempView.Warning = EnableWarnings && Math.Abs(model.LeftTempDelta) > TempWarning;
            rfTireTempView.Warning = EnableWarnings && Math.Abs(model.RightTempDelta) < TempWarning;
            rrTireTempView.Warning = EnableWarnings && Math.Abs(model.RightTempDelta) > TempWarning;

            lfTireWearView.DisplayValues(
                lfTire.Wear.Outside,
                lfTire.Wear.Middle,
                lfTire.Wear.Inside,
                lfTire.EffectiveWear);

            lrTireWearView.DisplayValues(
                lrTire.Wear.Outside,
                lrTire.Wear.Middle,
                lrTire.Wear.Inside,
                lrTire.EffectiveWear);

            rfTireWearView.DisplayValues(
                rfTire.Wear.Inside,
                rfTire.Wear.Middle,
                rfTire.Wear.Outside,
                rfTire.EffectiveWear);

            rrTireWearView.DisplayValues(
                rrTire.Wear.Inside,
                rrTire.Wear.Middle,
                rrTire.Wear.Outside,
                rrTire.EffectiveWear);

            lfTireTempView.Warning = EnableWarnings && Math.Abs(model.LeftWearDelta) > WearWarning;
            lrTireTempView.Warning = EnableWarnings && Math.Abs(model.LeftWearDelta) > WearWarning;
            rfTireTempView.Warning = EnableWarnings && Math.Abs(model.RightWearDelta) > WearWarning;
            rrTireTempView.Warning = EnableWarnings && Math.Abs(model.RightWearDelta) > WearWarning;
        }

        #endregion

        #region private

        private void TireSheetView_Load(object sender, EventArgs e)
        {
            try
            {
                if (Model != null)
                {
                    DisplayModel(Model);
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }

        #endregion
    }
}
