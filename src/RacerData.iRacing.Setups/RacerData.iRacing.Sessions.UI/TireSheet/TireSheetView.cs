using System;
using System.Drawing;
using System.Windows.Forms;
using static RacerData.iRacing.Sessions.Ui.TireSheet.TireSheetViewModel;

namespace RacerData.iRacing.Sessions.Ui.TireSheet
{
    public partial class TireSheetView : UserControl
    {
        #region properties
        private Color _infoForeColor = Color.White;
        public Color InfoForeColor
        {
            get
            {
                return _infoForeColor;
            }
            set
            {
                _infoForeColor = value;
                UpdateColors();
            }
        }

        private Color _infoBackColor = Color.Blue;
        public Color InfoBackColor
        {
            get
            {
                return _infoBackColor;
            }
            set
            {
                _infoBackColor = value;
                UpdateColors();
            }
        }

        private Color _headerForeColor = Color.Black;
        public Color HeaderForeColor
        {
            get
            {
                return _headerForeColor;
            }
            set
            {
                _headerForeColor = value;
                UpdateColors();
            }
        }

        private Color _headerBackColor = Color.FromArgb(0, 0, 192);
        public Color HeaderBackColor
        {
            get
            {
                return _headerBackColor;
            }
            set
            {
                _headerBackColor = value;
                UpdateColors();
            }
        }

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
                DisplayModel(_model);
            }
        }

        #endregion

        #region ctor

        public TireSheetView()
        {
            InitializeComponent();
        }

        public void ClearDisplay()
        {
            Model = new TireSheetValues();
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
            UpdateColors();

            if (model == null)
                return;

            lblSetup.Text = model.Setup;

            lblLaps.Text = $"Laps: {model.Laps}";
            lblBestLap.Text = $"Best: {Math.Round(model.BestLap, 3)}";
            lblAvgLaps.Text = $"Avg: {Math.Round(model.AverageLap, 3)}";

            var lfTire = model.Tires[TirePosition.LF];
            tireValuesGrid1.DisplayValues(
                lfTire.Temperatures.Outside,
                lfTire.Temperatures.Middle,
                lfTire.Temperatures.Inside,
                lfTire.EffectiveTemperature);

            var lrTire = model.Tires[TirePosition.LR];
            tireValuesGrid3.DisplayValues(
                lrTire.Temperatures.Outside,
                lrTire.Temperatures.Middle,
                lrTire.Temperatures.Outside,
                lrTire.EffectiveTemperature);

            var rfTire = model.Tires[TirePosition.RF];
            tireValuesGrid2.DisplayValues(
                rfTire.Temperatures.Inside,
                rfTire.Temperatures.Middle,
                rfTire.Temperatures.Outside,
                rfTire.EffectiveTemperature);

            var rrTire = model.Tires[TirePosition.RR];
            tireValuesGrid4.DisplayValues(
                rrTire.Temperatures.Inside,
                rrTire.Temperatures.Middle,
                rrTire.Temperatures.Outside,
                rrTire.EffectiveTemperature);

            tireValuesGrid1.Warning = EnableWarnings && Math.Abs(model.LeftTempDelta) < TempWarning;
            tireValuesGrid3.Warning = EnableWarnings && Math.Abs(model.LeftTempDelta) > TempWarning;
            tireValuesGrid2.Warning = EnableWarnings && Math.Abs(model.RightTempDelta) < TempWarning;
            tireValuesGrid4.Warning = EnableWarnings && Math.Abs(model.RightTempDelta) > TempWarning;

            tireValuesGrid5.DisplayValues(
                lfTire.Wear.Outside,
                lfTire.Wear.Middle,
                lfTire.Wear.Inside,
                lfTire.EffectiveWear);

            tireValuesGrid7.DisplayValues(
                lrTire.Wear.Outside,
                lrTire.Wear.Middle,
                lrTire.Wear.Inside,
                lrTire.EffectiveWear);

            tireValuesGrid6.DisplayValues(
                rfTire.Wear.Inside,
                rfTire.Wear.Middle,
                rfTire.Wear.Outside,
                rfTire.EffectiveWear);

            tireValuesGrid8.DisplayValues(
                rrTire.Wear.Inside,
                rrTire.Wear.Middle,
                rrTire.Wear.Outside,
                rrTire.EffectiveWear);

            tireValuesGrid1.Warning = EnableWarnings && Math.Abs(model.LeftWearDelta) > WearWarning;
            tireValuesGrid3.Warning = EnableWarnings && Math.Abs(model.LeftWearDelta) > WearWarning;
            tireValuesGrid2.Warning = EnableWarnings && Math.Abs(model.RightWearDelta) > WearWarning;
            tireValuesGrid4.Warning = EnableWarnings && Math.Abs(model.RightWearDelta) > WearWarning;
        }

        #endregion

        #region private

        private void TireSheetView_Load(object sender, EventArgs e)
        {
            try
            {
                UpdateColors();

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

        private void UpdateColors()
        {
            lblTireTemperaturesHeader.BackColor = HeaderBackColor;
            lblTireWearHeader.BackColor = HeaderBackColor;

            lblTireTemperaturesHeader.ForeColor = HeaderForeColor;
            lblTireWearHeader.ForeColor = HeaderForeColor;

            lblLaps.BackColor = InfoBackColor;
            lblAvgLaps.BackColor = InfoBackColor;
            lblBestLap.BackColor = InfoBackColor;
            lblSetup.BackColor = InfoBackColor;

            lblLaps.ForeColor = InfoForeColor;
            lblAvgLaps.ForeColor = InfoForeColor;
            lblBestLap.ForeColor = InfoForeColor;
            lblSetup.ForeColor = InfoForeColor;
        }
        #endregion
    }
}
