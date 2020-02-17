using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Extensions.DependencyInjection;
using RacerData.iRacing.Setups.ClassBuilder.Models;
using RacerData.iRacing.Telemetry;

namespace RacerData.iRacing.Setups.ClassBuilder.Forms
{
    public partial class PracticeSession : Form
    {
        #region fields

        private bool _loading = true;
        IDictionary<TirePosition, IDictionary<TreadPosition, float>> _tireWearValues;
        IDictionary<TirePosition, IDictionary<TreadPosition, float>> _tireTempValues;

        #endregion

        #region properties

        private EventSessionData _sessionData;
        public EventSessionData SessionData
        {
            get
            {
                return _sessionData;
            }
            set
            {
                _sessionData = value;

                DisplaySessionData(_sessionData);
            }
        }

        #endregion

        #region ctor

        public PracticeSession()
        {
            InitializeComponent();

            tireTempGraphSet1.TireTempRange = 225.0F;
            tireTempGraphSet1.TireTempWarning = 200.0F;

            tireWearGraphSet1.TireWearRange = 100.0F;
            tireWearGraphSet1.TireWearWarning = 96.0F;

            tirePressureGraphSet1.LeftRangeMin = 13;
            tirePressureGraphSet1.LeftRangeMax = 21;
            tirePressureGraphSet1.RightRangeMin = 17;
            tirePressureGraphSet1.RightRangeMax = 24;

            lapTimeChart1.SeriesMin = 14;
            lapTimeChart1.SeriesMax = 25;
        }

        #endregion

        #region protected

        public virtual void DisplaySessionData(EventSessionData sessionData)
        {
            try
            {
                DisplayLapTimes(sessionData.LapData.Laps);

                DisplayTireTemps(sessionData);

                DisplayTireWear(sessionData);

                DisplayTirePressures(sessionData);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Console.WriteLine(ex.ToString());
            }
        }

        protected virtual void DisplayLapTimes(IList<ILapInfo> laps)
        {
            IList<LapTimeSeries> seriesList = new List<LapTimeSeries>();

            LapTimeSeries series = new LapTimeSeries();
            series.Title = "Series";
            series.SeriesLineColor = Color.LimeGreen;
            series.SeriesLineWidth = 0.25F;
            series.Laps = SessionData.LapData.Laps;

            seriesList.Add(series);

            lapTimeChart1.DisplayLaps(seriesList);
        }

        protected virtual void DisplayTireTemps(EventSessionData sessionData)
        {
            _tireTempValues = new Dictionary<TirePosition, IDictionary<TreadPosition, float>>();

            _tireTempValues.Add(TirePosition.LF, GetTireTemperatures(sessionData.TireSheet.Tires[TirePosition.LF]));
            _tireTempValues.Add(TirePosition.LR, GetTireTemperatures(sessionData.TireSheet.Tires[TirePosition.LR]));
            _tireTempValues.Add(TirePosition.RF, GetTireTemperatures(sessionData.TireSheet.Tires[TirePosition.RF]));
            _tireTempValues.Add(TirePosition.RR, GetTireTemperatures(sessionData.TireSheet.Tires[TirePosition.RR]));

            tireTempGraphSet1.DisplayTemperatures(_tireTempValues);
        }

        protected virtual void DisplayTireWear(EventSessionData sessionData)
        {
            _tireWearValues = new Dictionary<TirePosition, IDictionary<TreadPosition, float>>();

            _tireWearValues.Add(TirePosition.LF, GetTireWear(sessionData.TireSheet.Tires[TirePosition.LF]));
            _tireWearValues.Add(TirePosition.LR, GetTireWear(sessionData.TireSheet.Tires[TirePosition.LR]));
            _tireWearValues.Add(TirePosition.RF, GetTireWear(sessionData.TireSheet.Tires[TirePosition.RF]));
            _tireWearValues.Add(TirePosition.RR, GetTireWear(sessionData.TireSheet.Tires[TirePosition.RR]));

            tireWearGraphSet1.DisplayTireWear(_tireWearValues);
        }

        protected virtual void DisplayTirePressures(EventSessionData sessionData)
        {
            var pressureModels = new List<TirePressureModel>();

            pressureModels.Add(new TirePressureModel()
            {
                Position = TirePosition.LF,
                ColdPsi = (float)sessionData.TireSheet.Tires[TirePosition.LF].ColdPsi,
                HotPsi = (float)sessionData.TireSheet.Tires[TirePosition.LF].HotPsi
            });
            pressureModels.Add(new TirePressureModel()
            {
                Position = TirePosition.LR,
                ColdPsi = (float)sessionData.TireSheet.Tires[TirePosition.LR].ColdPsi,
                HotPsi = (float)sessionData.TireSheet.Tires[TirePosition.LR].HotPsi
            });
            pressureModels.Add(new TirePressureModel()
            {
                Position = TirePosition.RF,
                ColdPsi = (float)sessionData.TireSheet.Tires[TirePosition.RF].ColdPsi,
                HotPsi = (float)sessionData.TireSheet.Tires[TirePosition.RF].HotPsi
            });
            pressureModels.Add(new TirePressureModel()
            {
                Position = TirePosition.RR,
                ColdPsi = (float)sessionData.TireSheet.Tires[TirePosition.RR].ColdPsi,
                HotPsi = (float)sessionData.TireSheet.Tires[TirePosition.RR].HotPsi
            });

            tirePressureGraphSet1.DisplayTirePressures(pressureModels);
        }

        #endregion

        #region private

        private IDictionary<TreadPosition, float> GetTireTemperatures(TireViewModel model)
        {
            IDictionary<TreadPosition, float> values = new Dictionary<TreadPosition, float>();

            values.Add(TreadPosition.Inside, (float)model.Temperatures.Inside);
            values.Add(TreadPosition.Middle, (float)model.Temperatures.Middle);
            values.Add(TreadPosition.Outside, (float)model.Temperatures.Outside);

            return values;
        }
        private IDictionary<TreadPosition, float> GetTireWear(TireViewModel model)
        {
            IDictionary<TreadPosition, float> values = new Dictionary<TreadPosition, float>();

            values.Add(TreadPosition.Inside, (float)model.Wear.Inside);
            values.Add(TreadPosition.Middle, (float)model.Wear.Middle);
            values.Add(TreadPosition.Outside, (float)model.Wear.Outside);

            return values;
        }

        private void PracticeSession_Load(object sender, EventArgs e)
        {
            btnAutoScaleLapTImes.Checked = lapTimeChart1.AutoScale;


        }

        private void btnAutoScaleLapTImes_CheckedChanged(object sender, EventArgs e)
        {
            if (_loading) return;

            lapTimeChart1.AutoScale = btnAutoScaleLapTImes.Checked;
        }

        #endregion
    }
}
