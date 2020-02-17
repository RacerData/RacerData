using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RacerData.iRacing.Setups.ClassBuilder.Controls;
using RacerData.iRacing.Setups.ClassBuilder.Models;
using RacerData.iRacing.Telemetry;

namespace RacerData.iRacing.Setups.ClassBuilder.Forms
{
    public partial class TireTempAnalysis : Form
    {
        private class TestLap : ILapInfo
        {
            public int LapNumber { get; set; }

            public float LapTime { get; set; }

            public float LapSpeed { get; set; }
        }

        private bool _loading = true;

        IDictionary<TirePosition, IDictionary<TreadPosition, float>> _tireWearValues;
        IDictionary<TirePosition, IDictionary<TreadPosition, float>> _tireTempValues;

        public TireTempAnalysis()
        {
            InitializeComponent();

            rnd = new Random(DateTime.Now.Millisecond);

            trackBarWearRange.Value = (int)tireWearGraphSet.TireWearRange;
            trackBarTempRange.Value = (int)tireTempGraphSet.TireTempRange;
            trackBarWearWarn.Value = (int)tireWearGraphSet.TireWearWarning;
            trackBarTempWarn.Value = (int)tireTempGraphSet.TireTempWarning;

            lblTempWarn.Text = $"Temp Warn: {tireTempGraphSet.TireTempWarning}";
            lblTempRange.Text = $"Temp Range: {tireTempGraphSet.TireTempRange}";

            lblWearWarn.Text = $"Wear Warn: {tireWearGraphSet.TireWearWarning}";
            lblWearRange.Text = $"Wear Range: {tireWearGraphSet.TireWearRange}";

            DisplayTemps();
            DisplayWear();

            DisplayWearBalance();
            DisplayTempBalance();

            DisplayLapTimes();

            DisplayPressures();

            _loading = false;
        }

        private void DisplayLapTimes()
        {
            IList<LapTimeSeries> seriesList = new List<LapTimeSeries>();

            LapTimeSeries series = GetLapTimeSeries(15);
            series.Title = "Series";
            series.SeriesLineColor = Color.LimeGreen;
            series.SeriesLineWidth = 0.25F;

            seriesList.Add(series);

            LapTimeSeries series1 = GetLapTimeSeries(20);
            series1.Title = "Series 1";
            series1.SeriesLineColor = Color.Red;
            series1.SeriesLineWidth = 0.5F;

            seriesList.Add(series1);

            LapTimeSeries series2 = GetLapTimeSeries(7);
            series2.Title = "Series 2";
            series2.SeriesLineColor = Color.DodgerBlue;
            series2.SeriesLineWidth = 1.0F;

            seriesList.Add(series2);

            lapTimeChart.DisplayLaps(seriesList);

            chkAutoScale.Checked = lapTimeChart.AutoScale;
        }
        LapTimeSeries series;
        Random rnd;
        protected LapTimeSeries GetLapTimeSeries(int lapCount)
        {
            series = new LapTimeSeries();

            float lapSeconds = rnd.Next(12, 21);

            for (int i = 0; i < lapCount; i++)
            {
                lapSeconds += (float)(rnd.NextDouble() - .5F);

                if (lapSeconds < 12) lapSeconds += 3;
                if (lapSeconds > 22) lapSeconds -= 3;

                series.Laps.Add(new TestLap() { LapNumber = i + 1, LapTime = lapSeconds });
            }

            return series;
        }

        private void DisplayTemps()
        {
            /* O M I */
            var lfTemperatures = new Dictionary<TreadPosition, float>();
            lfTemperatures.Add(TreadPosition.Outside, 167.0F);
            lfTemperatures.Add(TreadPosition.Middle, 160.0F);
            lfTemperatures.Add(TreadPosition.Inside, 120.0F);
            /* O M I */
            var lrTemperatures = new Dictionary<TreadPosition, float>();
            lrTemperatures.Add(TreadPosition.Outside, 165);
            lrTemperatures.Add(TreadPosition.Middle, 163);
            lrTemperatures.Add(TreadPosition.Inside, 150.0F);

            /* I M O */
            var rfTemperatures = new Dictionary<TreadPosition, float>();
            rfTemperatures.Add(TreadPosition.Inside, 198.0F);
            rfTemperatures.Add(TreadPosition.Middle, 187.0F);
            rfTemperatures.Add(TreadPosition.Outside, 160.0F);
            /* I M O */
            var rrTemperatures = new Dictionary<TreadPosition, float>();
            rrTemperatures.Add(TreadPosition.Inside, 192.0F);
            rrTemperatures.Add(TreadPosition.Middle, 190.8F);
            rrTemperatures.Add(TreadPosition.Outside, 150.0F);

            _tireTempValues = new Dictionary<TirePosition, IDictionary<TreadPosition, float>>();

            _tireTempValues.Add(TirePosition.LF, lfTemperatures);
            _tireTempValues.Add(TirePosition.LR, lrTemperatures);
            _tireTempValues.Add(TirePosition.RF, rfTemperatures);
            _tireTempValues.Add(TirePosition.RR, rrTemperatures);

            tireTempGraphSet.DisplayTemperatures(_tireTempValues);
        }
        private void DisplayWear()
        {
            /* O M I */
            var lfWear = new Dictionary<TreadPosition, float>();
            lfWear.Add(TreadPosition.Outside, 95.0F);
            lfWear.Add(TreadPosition.Middle, 95.0F);
            lfWear.Add(TreadPosition.Inside, 99.0F);
            /* O M I */
            var lrWear = new Dictionary<TreadPosition, float>();
            lrWear.Add(TreadPosition.Outside, 92.0F);
            lrWear.Add(TreadPosition.Middle, 89.0F);
            lrWear.Add(TreadPosition.Inside, 89.0F);
            /* I M O */
            var rfWear = new Dictionary<TreadPosition, float>();
            rfWear.Add(TreadPosition.Inside, 89.0F);
            rfWear.Add(TreadPosition.Middle, 90.0F);
            rfWear.Add(TreadPosition.Outside, 92.0F);
            /* I M O */
            var rrWear = new Dictionary<TreadPosition, float>();
            rrWear.Add(TreadPosition.Inside, 90.8F);
            rrWear.Add(TreadPosition.Middle, 91.0F);
            rrWear.Add(TreadPosition.Outside, 88.0F);

            _tireWearValues = new Dictionary<TirePosition, IDictionary<TreadPosition, float>>();

            _tireWearValues.Add(TirePosition.LF, lfWear);
            _tireWearValues.Add(TirePosition.LR, lrWear);
            _tireWearValues.Add(TirePosition.RF, rfWear);
            _tireWearValues.Add(TirePosition.RR, rrWear);

            this.tireWearGraphSet.DisplayTireWear(_tireWearValues);
        }

        private void DisplayTireTemps()
        {
            if (checkBoxRF.Checked) UpdateTireTempValues(_tireTempValues[TirePosition.RF]);
            if (checkBoxRR.Checked) UpdateTireTempValues(_tireTempValues[TirePosition.RR]);
            if (checkBoxLF.Checked) UpdateTireTempValues(_tireTempValues[TirePosition.LF]);
            if (checkBoxLR.Checked) UpdateTireTempValues(_tireTempValues[TirePosition.LR]);

            tireTempGraphSet.DisplayTemperatures(_tireTempValues);
        }
        private void DisplayTireWear()
        {
            if (checkBoxRF.Checked) UpdateTireWearValues(_tireWearValues[TirePosition.RF]);
            if (checkBoxRR.Checked) UpdateTireWearValues(_tireWearValues[TirePosition.RR]);
            if (checkBoxLF.Checked) UpdateTireWearValues(_tireWearValues[TirePosition.LF]);
            if (checkBoxLR.Checked) UpdateTireWearValues(_tireWearValues[TirePosition.LR]);

            tireWearGraphSet.DisplayTireWear(_tireWearValues);
        }

        private void UpdateTireWearValues(IDictionary<TreadPosition, float> tireWearValues)
        {
            tireWearValues[TreadPosition.Inside] = 100 - (100 - (float)trackBar1.Value);
            tireWearValues[TreadPosition.Middle] = 100 - (100 - (float)trackBar2.Value);
            tireWearValues[TreadPosition.Outside] = 100 - (100 - (float)trackBar3.Value);

            this.tireWearGraphSet.DisplayTireWear(_tireWearValues);
        }
        private void UpdateTireTempValues(IDictionary<TreadPosition, float> tireTempValues)
        {
            tireTempValues[TreadPosition.Inside] = 175 + (100 - (float)trackBar1.Value);
            tireTempValues[TreadPosition.Middle] = 175 + (100 - (float)trackBar2.Value);
            tireTempValues[TreadPosition.Outside] = 175 + (100 - (float)trackBar3.Value);

            this.tireWearGraphSet.DisplayTireWear(_tireWearValues);
        }

        private void DisplayTempBalance()
        {
            var leftFrontAverage = GetAverage(_tireTempValues[TirePosition.LF]);
            var leftRearAverage = GetAverage(_tireTempValues[TirePosition.LR]);
            var rightFrontAverage = GetAverage(_tireTempValues[TirePosition.RF]);
            var rightRearAverage = GetAverage(_tireTempValues[TirePosition.RR]);

            balanceGraphView.DisplayTireTempBalance(
                leftFrontAverage,
                leftRearAverage,
                rightFrontAverage,
                rightRearAverage);
        }
        private void DisplayWearBalance()
        {
            var leftFrontAverage = GetAverage(_tireWearValues[TirePosition.LF]);
            var leftRearAverage = GetAverage(_tireWearValues[TirePosition.LR]);
            var rightFrontAverage = GetAverage(_tireWearValues[TirePosition.RF]);
            var rightRearAverage = GetAverage(_tireWearValues[TirePosition.RR]);

            balanceGraphView.DisplayTireWearBalance(
                leftFrontAverage,
                leftRearAverage,
                rightFrontAverage,
                rightRearAverage);
        }

        private float GetAverage(IDictionary<TreadPosition, float> tireWearValues)
        {
            return (tireWearValues[TreadPosition.Inside] +
             tireWearValues[TreadPosition.Middle] +
             tireWearValues[TreadPosition.Outside]) / 3;
        }

        private void DisplayPressures()
        {
            var pressureModels = new List<TirePressureModel>();

            pressureModels.Add(new TirePressureModel()
            {
                Position = TirePosition.LF,
                ColdPsi = (float)(rnd.Next(12, 15) + rnd.NextDouble()),
                HotPsi = (float)(rnd.Next(16, 18) + rnd.NextDouble())
            });
            pressureModels.Add(new TirePressureModel()
            {
                Position = TirePosition.LR,
                ColdPsi = (float)(rnd.Next(12, 15) + rnd.NextDouble()),
                HotPsi = (float)(rnd.Next(16, 18) + rnd.NextDouble())
            });
            pressureModels.Add(new TirePressureModel()
            {
                Position = TirePosition.RF,
                ColdPsi = (float)(rnd.Next(17, 19) + rnd.NextDouble()),
                HotPsi = (float)(rnd.Next(19, 23) + rnd.NextDouble())
            });
            pressureModels.Add(new TirePressureModel()
            {
                Position = TirePosition.RR,
                ColdPsi = (float)(rnd.Next(17, 19) + rnd.NextDouble()),
                HotPsi = (float)(rnd.Next(19, 23) + rnd.NextDouble())
            });

            tirePressureGraphSet1.DisplayTirePressures(pressureModels);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DisplayTemps();
            DisplayWear();
            DisplayTempBalance();
            DisplayWearBalance();
            DisplayPressures();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            _tireWearValues[TirePosition.LF][TreadPosition.Outside] = 99;
            _tireWearValues[TirePosition.LF][TreadPosition.Middle] = 99;
            _tireWearValues[TirePosition.LF][TreadPosition.Inside] = 100;

            _tireWearValues[TirePosition.RF][TreadPosition.Inside] = 96;
            _tireWearValues[TirePosition.RF][TreadPosition.Middle] = 96;
            _tireWearValues[TirePosition.RF][TreadPosition.Outside] = 97;

            _tireWearValues[TirePosition.LR][TreadPosition.Outside] = 98;
            _tireWearValues[TirePosition.LR][TreadPosition.Middle] = 98;
            _tireWearValues[TirePosition.LR][TreadPosition.Inside] = 99;

            _tireWearValues[TirePosition.RR][TreadPosition.Inside] = 97;
            _tireWearValues[TirePosition.RR][TreadPosition.Middle] = 97;
            _tireWearValues[TirePosition.RR][TreadPosition.Outside] = 98;

            tireWearGraphSet.DisplayTireWear(_tireWearValues);

            _tireTempValues[TirePosition.RF][TreadPosition.Inside] = 185;
            _tireTempValues[TirePosition.RF][TreadPosition.Middle] = 184;
            _tireTempValues[TirePosition.RF][TreadPosition.Outside] = 150;

            _tireTempValues[TirePosition.RR][TreadPosition.Inside] = 196;
            _tireTempValues[TirePosition.RR][TreadPosition.Middle] = 197;
            _tireTempValues[TirePosition.RR][TreadPosition.Outside] = 175;

            _tireTempValues[TirePosition.LF][TreadPosition.Outside] = 164;
            _tireTempValues[TirePosition.LF][TreadPosition.Middle] = 158;
            _tireTempValues[TirePosition.LF][TreadPosition.Inside] = 112;

            _tireTempValues[TirePosition.LR][TreadPosition.Outside] = 181;
            _tireTempValues[TirePosition.LR][TreadPosition.Middle] = 175;
            _tireTempValues[TirePosition.LR][TreadPosition.Inside] = 165;

            tireTempGraphSet.DisplayTemperatures(_tireTempValues);

            DisplayTempBalance();
            DisplayWearBalance();
        }

        private void trackBar_Scroll(object sender, EventArgs e)
        {
            if (_loading) return;

            DisplayTireTemps();
            DisplayTireWear();

            DisplayWearBalance();
            DisplayTempBalance();
        }

        private void trackBarTempWarn_Scroll(object sender, EventArgs e)
        {
            if (_loading) return;

            tireTempGraphSet.TireTempWarning = (float)trackBarTempWarn.Value;
            lblTempWarn.Text = $"Temp Warn: {tireTempGraphSet.TireTempWarning}";
        }

        private void trackBarWearRange_Scroll(object sender, EventArgs e)
        {
            if (_loading) return;

            tireWearGraphSet.TireWearRange = trackBarWearRange.Value;
            lblWearRange.Text = $"Wear Range: {tireWearGraphSet.TireWearRange}";
        }

        private void trackBarTempRange_Scroll(object sender, EventArgs e)
        {
            if (_loading) return;

            tireTempGraphSet.TireTempRange = trackBarTempRange.Value;
            lblTempRange.Text = $"Temp Range: {tireTempGraphSet.TireTempRange}";
        }

        private void trackBarWearWarn_Scroll(object sender, EventArgs e)
        {
            if (_loading) return;

            tireWearGraphSet.TireWearWarning = (float)trackBarWearWarn.Value;
            lblWearWarn.Text = $"Wear Warn: {tireWearGraphSet.TireWearWarning}";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DisplayLapTimes();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            IList<LapTimeSeries> seriesList = new List<LapTimeSeries>();

            LapTimeSeries series = GetLapTimeSeries(50);
            series.Title = "Series";
            series.SeriesLineColor = Color.LimeGreen;
            series.SeriesLineWidth = 0.25F;

            seriesList.Add(series);

            lapTimeChart.DisplayLaps(seriesList);

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (_loading) return;

            lapTimeChart.AutoScale = !lapTimeChart.AutoScale;
        }
    }
}
