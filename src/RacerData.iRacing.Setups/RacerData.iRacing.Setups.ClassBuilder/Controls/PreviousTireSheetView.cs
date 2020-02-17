using System;
using System.Windows.Forms;
using RacerData.iRacing.Setups.ClassBuilder.Models;
using RacerData.iRacing.Telemetry;

namespace RacerData.iRacing.Setups.ClassBuilder.Controls
{
    public partial class PreviousTireSheetView : UserControl
    {
        #region properties

        public double TempWarning { get; set; } = 2;
        public double WearWarning { get; set; } = 1;
        public bool EnableWarnings { get; set; } = false;

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
                DisplayModel(_model, _diffModel);
            }
        }

        private TireSheetValues _diffModel;
        public TireSheetValues DiffModel
        {
            get
            {
                return _diffModel;
            }
            set
            {
                _diffModel = value;
                DisplayModel(_model, _diffModel);
            }
        }

        #endregion

        #region ctor

        public PreviousTireSheetView()
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

        protected virtual void DisplayModel(TireSheetValues model, TireSheetValues diffModel)
        {
            if (model == null || diffModel == null)
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
                lfTire.EffectiveTemperature,
                diffModel.Tires[TirePosition.LF].EffectiveTemperature);

            var lrTire = model.Tires[TirePosition.LR];
            lrTireTempView.DisplayValues(
                lrTire.Temperatures.Outside,
                lrTire.Temperatures.Middle,
                lrTire.Temperatures.Inside,
                lrTire.EffectiveTemperature,
                diffModel.Tires[TirePosition.LR].EffectiveTemperature);

            var rfTire = model.Tires[TirePosition.RF];
            rfTireTempView.DisplayValues(
                rfTire.Temperatures.Inside,
                rfTire.Temperatures.Middle,
                rfTire.Temperatures.Outside,
                rfTire.EffectiveTemperature,
                diffModel.Tires[TirePosition.RF].EffectiveTemperature);

            var rrTire = model.Tires[TirePosition.RR];
            rrTireTempView.DisplayValues(
                rrTire.Temperatures.Inside,
                rrTire.Temperatures.Middle,
                rrTire.Temperatures.Outside,
                rrTire.EffectiveTemperature,
                diffModel.Tires[TirePosition.RR].EffectiveTemperature);

            lfTireTempView.Warning = EnableWarnings && Math.Abs(model.LeftTempDelta) < TempWarning;
            lrTireTempView.Warning = EnableWarnings && Math.Abs(model.LeftTempDelta) > TempWarning;
            rfTireTempView.Warning = EnableWarnings && Math.Abs(model.RightTempDelta) < TempWarning;
            rrTireTempView.Warning = EnableWarnings && Math.Abs(model.RightTempDelta) > TempWarning;

            lfTireWearView.DisplayValues(
                lfTire.Wear.Outside,
                lfTire.Wear.Middle,
                lfTire.Wear.Inside,
                lfTire.EffectiveWear,
                diffModel.Tires[TirePosition.LF].EffectiveWear);

            lrTireWearView.DisplayValues(
                lrTire.Wear.Outside,
                lrTire.Wear.Middle,
                lrTire.Wear.Inside,
                lrTire.EffectiveWear,
                diffModel.Tires[TirePosition.LR].EffectiveWear);

            rfTireWearView.DisplayValues(
                rfTire.Wear.Inside,
                rfTire.Wear.Middle,
                rfTire.Wear.Outside,
                rfTire.EffectiveWear,
                diffModel.Tires[TirePosition.RF].EffectiveWear);


            rrTireWearView.DisplayValues(
                rrTire.Wear.Inside,
                rrTire.Wear.Middle,
                rrTire.Wear.Outside,
                rrTire.EffectiveWear,
                diffModel.Tires[TirePosition.RR].EffectiveWear);

            lfTireTempView.Warning = EnableWarnings && Math.Abs(model.LeftWearDelta) < WearWarning;
            lrTireTempView.Warning = EnableWarnings && Math.Abs(model.LeftWearDelta) > WearWarning;
            rfTireTempView.Warning = EnableWarnings && Math.Abs(model.RightWearDelta) < WearWarning;
            rrTireTempView.Warning = EnableWarnings && Math.Abs(model.RightWearDelta) > WearWarning;
        }

        #endregion

        #region private

        private void TireSheetView_Load(object sender, EventArgs e)
        {
            try
            {
                if (Model != null && DiffModel != null)
                {
                    DisplayModel(Model, DiffModel);
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
