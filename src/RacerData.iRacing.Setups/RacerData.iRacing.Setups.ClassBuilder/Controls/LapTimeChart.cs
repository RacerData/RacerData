using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;
using RacerData.iRacing.Setups.ClassBuilder.Models;
using RacerData.iRacing.Telemetry;

namespace RacerData.iRacing.Setups.ClassBuilder.Controls
{
    public partial class LapTimeChart : UserControl
    {
        #region consts

        private const float DefaultSeriesMin = 10.0F;
        private const float DefaultSeriesMax = 60.0F;

        #endregion

        #region properties

        public IList<LapTimeSeries> LapTimes { get; set; }

        public Color SeriesLineColor { get; set; } = Color.Red;
        public float SeriesLineWidth { get; set; } = .5F;
        public float SeriesMin { get; set; } = 12.0F;
        public float SeriesMax { get; set; } = 22.0F;
        private float? _seriesMinSaved;
        private float? _seriesMaxSaved;
        private bool _autoScale = true;
        public bool AutoScale
        {
            get
            {
                return _autoScale;
            }
            set
            {
                _autoScale = value;
                if (_autoScale)
                {
                    _seriesMinSaved = SeriesMin;
                    _seriesMaxSaved = SeriesMax;
                }
                else
                {
                    SeriesMin = _seriesMinSaved.GetValueOrDefault(DefaultSeriesMin);
                    SeriesMax = _seriesMaxSaved.GetValueOrDefault(DefaultSeriesMax);
                    _seriesMinSaved = null;
                    _seriesMaxSaved = null;
                }
                picGraph.Invalidate();
            }
        }

        public Color AxisLineColor { get; set; } = Color.Gray;
        public Color AxisLabelColor { get; set; } = Color.WhiteSmoke;
        public Font XAxisFont { get; set; } = new Font("Segoe UI", 6);
        public Font YAxisFont { get; set; } = new Font("Segoe UI", 6);
        public bool ShowXAxisLabels { get; set; } = true;
        public bool ShowYAxisLabels { get; set; } = true;
        public float XAxisOffset { get; set; } = 20.0F;
        public float YAxisOffset { get; set; } = 30.0F;
        public float AxisWidth { get; set; } = 1.5F;
        public float XAxisInterval
        {
            get
            {
                var lapSeries = LapTimes.OrderByDescending(l => l.Laps.Count).FirstOrDefault();
                if (lapSeries != null)
                {
                    if (lapSeries.Laps.Count > 1)
                        return XAxisLength / (lapSeries.Laps.Count - 1);
                    else
                        return XAxisLength;
                }
                else
                {
                    return XAxisLength;
                }
            }
        }
        public int YAxisTickCount
        {
            get
            {
                return (int)Math.Ceiling(SeriesMax) - (int)Math.Floor(SeriesMin);
            }
        }
        public float YAxisInterval
        {
            get
            {
                return YAxisHeight / YAxisTickCount;
            }
        }
        public float XAxisLength
        {
            get
            {
                return picGraph.Width - YAxisOffset - GridRightOffset;
            }
        }
        public float YAxisHeight
        {
            get
            {
                return picGraph.Height - XAxisOffset - GridTopOffset;
            }
        }

        public Color BorderColor { get; set; } = Color.DimGray;
        public int BorderOffset { get; set; } = 4;
        public float BorderWidth { get; set; } = 2.0F;

        public bool ShowGrid { get; set; } = true;
        public Color GridLineColor { get; set; } = Color.DimGray;
        public float GridLineWidth { get; set; } = 1.0F;
        public float GridTopOffset { get; set; } = 6.0F;
        public float GridRightOffset { get; set; } = 6.0F;

        #endregion

        #region ctor

        public LapTimeChart()
        {
            InitializeComponent();

            try
            {

            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }

        #endregion

        #region public

        public void DisplayLaps(IList<LapTimeSeries> lapTimes)
        {
            LapTimes = lapTimes;

            if (AutoScale)
            {
                SeriesMax = (int)Math.Ceiling(LapTimes.Max(s => s.Laps.Max(l => l.LapTime)));
                SeriesMin = (int)Math.Floor(LapTimes.Min(s => s.Laps.Min(l => l.LapTime)));

                if (SeriesMax > SeriesMin + 3)
                {
                    SeriesMax = SeriesMin + 2;
                }
            }

            picGraph.Invalidate();
        }

        #endregion

        #region protected

        protected virtual void DrawBorder(Graphics graphics)
        {
            using (Pen borderPen = new Pen(BorderColor, BorderWidth))
            {
                graphics.DrawRectangle(
                    borderPen,
                    new Rectangle(
                        BorderOffset,
                        BorderOffset,
                        picGraph.Width - (BorderOffset + 1),
                        picGraph.Height - (BorderOffset + 1)));
            }
        }

        protected virtual void DrawGrid(Graphics graphics)
        {
            using (Pen axisPen = new Pen(GridLineColor, GridLineWidth))
            {
                for (float y = YAxisInterval; y < YAxisHeight + 1; y += YAxisInterval)
                {
                    PointF startPoint = new PointF(
                      YAxisOffset,
                      picGraph.Height - XAxisOffset - y);

                    PointF endPoint = new PointF(
                        picGraph.Width - GridRightOffset,
                        picGraph.Height - XAxisOffset - y);

                    //Console.WriteLine($"Drawing horizontal line {startPoint} - {endPoint}");

                    graphics.DrawLine(axisPen, startPoint, endPoint);
                }

                for (float x = XAxisInterval; x < XAxisLength + 1; x += XAxisInterval)
                {
                    PointF startPoint = new PointF(
                        YAxisOffset + x,
                        GridTopOffset);

                    PointF endPoint = new PointF(
                        YAxisOffset + x,
                        picGraph.Height - XAxisOffset);

                    //Console.WriteLine($"Drawing vertical line {startPoint} - {endPoint}");

                    graphics.DrawLine(axisPen, startPoint, endPoint);
                }
            }
        }

        protected virtual void DrawXAxis(Graphics graphics)
        {
            using (Pen axisPen = new Pen(AxisLineColor, AxisWidth))
            {
                graphics.DrawLine(
                    axisPen,
                    YAxisOffset,
                    picGraph.Height - XAxisOffset,
                    picGraph.Width - GridRightOffset,
                    picGraph.Height - XAxisOffset);
            }
        }

        protected virtual void DrawXAxisLabels(Graphics graphics, IList<ILapInfo> laps)
        {
            using (SolidBrush brush = new SolidBrush(AxisLabelColor))
            {
                int index = 0;
                for (float x = 0; x < laps.Count; x++)
                {
                    var label = laps[index].LapNumber.ToString();
                    var stringSize = graphics.MeasureString(label, XAxisFont);

                    PointF point = new PointF(YAxisOffset - (stringSize.Width / 2) + (x * XAxisInterval), picGraph.Height - (XAxisOffset - (stringSize.Height / 2)));

                    graphics.DrawString(label, XAxisFont, brush, point);

                    index++;
                }
            }
        }

        protected virtual void DrawYAxis(Graphics graphics)
        {
            using (Pen axisPen = new Pen(AxisLineColor, AxisWidth))
            {
                graphics.DrawLine(
                    axisPen,
                    YAxisOffset,
                    GridTopOffset,
                    YAxisOffset,
                    picGraph.Height - XAxisOffset);
            }

            if (ShowYAxisLabels)
                DrawYAxisLabels(graphics);
        }

        protected virtual void DrawYAxisLabels(Graphics graphics)
        {
            using (SolidBrush brush = new SolidBrush(AxisLabelColor))
            {
                int index = 0;
                for (float y = picGraph.Height - XAxisOffset; y > GridTopOffset - 1; y -= YAxisInterval)
                {
                    var labelValue = SeriesMin + (index);
                    var label = String.Format("{0:0.0}", labelValue);
                    var stringSize = graphics.MeasureString(label, YAxisFont);

                    PointF point = new PointF(YAxisOffset - stringSize.Width - 4, y - (stringSize.Height / 2));

                    graphics.DrawString(label, YAxisFont, brush, point);

                    index++;
                }
            }
        }

        protected virtual void DrawSeries(Graphics graphics, LapTimeSeries lapSeries)
        {
            PointF[] points = GetSeriesLinePoints(lapSeries.Laps);

            using (Pen seriesLinePen = new Pen(lapSeries.SeriesLineColor, lapSeries.SeriesLineWidth))
            {
                for (int i = 0; i < points.Length; i++)
                {
                    Console.WriteLine($"Drawing point {points[i]}");

                }

                graphics.DrawLines(seriesLinePen, points);
            }
        }

        protected virtual PointF[] GetSeriesLinePoints(IList<ILapInfo> laps)
        {
            PointF[] seriesLinePoints = new PointF[laps.Count];

            for (int i = 0; i < laps.Count; i++)
            {
                float x = YAxisOffset + (XAxisInterval * i);
                float y = GetScaleSeriesValueY(laps[i].LapTime);

                seriesLinePoints[i] = new PointF(x, y);
            }

            return seriesLinePoints;
        }

        protected virtual float GetScaleSeriesValueY(float value)
        {
            float seriesSpan = SeriesMax - SeriesMin;

            if (value <= SeriesMin)
                return picGraph.Height - XAxisOffset;

            if (value >= SeriesMax)
                return XAxisOffset;

            float scaledYOffset = ((value - SeriesMin) / seriesSpan) * YAxisHeight;

            return picGraph.Height - XAxisOffset - scaledYOffset;
        }

        #endregion

        #region private

        private void LapTimeChart_Load(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }

        private void ExceptionHandler(Exception ex)
        {
            Console.WriteLine(ex.ToString());
            MessageBox.Show(ex.Message);
        }

        private void picGraph_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                if (LapTimes == null || LapTimes.Count == 0)
                    return;

                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

                if (BorderWidth > 0)
                    DrawBorder(e.Graphics);

                if (ShowGrid)
                    DrawGrid(e.Graphics);

                if (ShowXAxisLabels)
                {
                    var lapSeries = LapTimes.OrderByDescending(l => l.Laps.Count).FirstOrDefault();
                    if (lapSeries != null)
                        DrawXAxisLabels(e.Graphics, lapSeries.Laps);
                }

                foreach (LapTimeSeries lapSeries in LapTimes)
                {
                    DrawSeries(e.Graphics, lapSeries);
                }

                DrawXAxis(e.Graphics);
                DrawYAxis(e.Graphics);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

        }

        #endregion
    }
}
