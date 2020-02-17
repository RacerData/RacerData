using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;
using static RacerData.iRacing.Sessions.Ui.LapTimeChart.LapTimeChartViewModel;

namespace RacerData.iRacing.Sessions.Ui.LapTimeChart
{
    public partial class LapTimeChartView : UserControl
    {
        #region consts

        private const float DefaultSeriesMin = 10.0F;
        private const float DefaultSeriesMax = 60.0F;

        #endregion

        #region fields

        private IList<LapTimeMarker> _lapTimeMarkers = new List<LapTimeMarker>();

        #endregion

        #region properties

        public IList<LapTimeChartViewModel> LapTimes { get; set; }

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
        public bool ShowLapTimePointLabels { get; set; } = false;

        public Color AxisLineColor { get; set; } = Color.Gray;
        public Color AxisLabelColor { get; set; } = Color.WhiteSmoke;
        public Font XAxisFont { get; set; } = new Font("Segoe UI", 8);
        public Font YAxisFont { get; set; } = new Font("Segoe UI", 8);
        public bool ShowXAxisLabels { get; set; } = true;
        public bool ShowYAxisLabels { get; set; } = true;
        public float XAxisOffset { get; set; } = 20.0F;
        public float YAxisOffset { get; set; } = 30.0F;
        public float AxisWidth { get; set; } = 1.5F;
        public int DefaultXAxisTickCount
        {
            get
            {
                return 20;
            }
        }
        public float XAxisInterval
        {
            get
            {
                var lapSeries = LapTimes?.OrderByDescending(l => l.Laps.Count).FirstOrDefault();
                if (lapSeries != null)
                {
                    if (lapSeries.Laps.Count > 1)
                        return XAxisLength / (lapSeries.Laps.Count - 1);
                    else
                        return XAxisLength;
                }
                else
                {
                    return XAxisLength / DefaultXAxisTickCount;
                }
            }
        }
        public int YAxisTickCount
        {
            get
            {
                return this.Height > 500 ? 20 : 10;
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
        public Color GridLineColor { get; set; } = Color.FromArgb(200, 64, 64, 64);
        public float GridLineWidth { get; set; } = .5F;
        public float GridTopOffset { get; set; } = 6.0F;
        public float GridRightOffset { get; set; } = 6.0F;

        #endregion

        #region ctor

        public LapTimeChartView()
        {
            InitializeComponent();
        }

        #endregion

        #region public

        public void DisplayLaps(IList<LapTimeChartViewModel> lapTimes)
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

        public void Clear()
        {
            LapTimes.Clear();
            picGraph.Invalidate();
        }

        #endregion

        #region protected

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

        protected virtual void DrawXAxisLabels(Graphics graphics, IList<LapInfo> laps)
        {
            using (SolidBrush brush = new SolidBrush(AxisLabelColor))
            {
                int index = 0;
                for (float x = 0; x < laps.Count; x++)
                {
                    var label = laps[index].LapNumber.ToString();
                    var stringSize = graphics.MeasureString(label, XAxisFont);

                    PointF point = new PointF((YAxisOffset - (stringSize.Width / 2) + (x * XAxisInterval)) - 2, picGraph.Height - (XAxisOffset - (stringSize.Height / 2)));

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

            if (ShowYAxisLabels && LapTimes != null)
                DrawYAxisLabels(graphics);
        }

        protected virtual void DrawYAxisLabels(Graphics graphics)
        {
            using (SolidBrush brush = new SolidBrush(AxisLabelColor))
            {
                int index = 0;
                for (float y = picGraph.Height - XAxisOffset; y > GridTopOffset - 1; y -= YAxisInterval)
                {
                    var labelValue = SeriesMin + (((SeriesMax - SeriesMin) / YAxisTickCount) * index);
                    var label = String.Format("{0:0.0}", labelValue);
                    var stringSize = graphics.MeasureString(label, YAxisFont);

                    PointF point = new PointF(YAxisOffset - stringSize.Width - 4, y - (stringSize.Height / 2));

                    graphics.DrawString(label, YAxisFont, brush, point);

                    index++;
                }
            }
        }

        protected virtual void DrawSeries(Graphics graphics, LapTimeChartViewModel lapSeries)
        {
            MarkerPoint[] points = GetSeriesLinePoints(lapSeries.RunId, lapSeries.Laps);

            int markerRectangleHalfSize = 4;

            using (Pen seriesLinePen = new Pen(lapSeries.SeriesLineColor, lapSeries.SeriesLineWidth))
            {
                graphics.DrawLines(seriesLinePen, points.ToList().Select(m => m.Point).ToArray());

                foreach (MarkerPoint markerPoint in points)
                {
                    var markerRectangle = new RectangleF(
                        new PointF(
                            markerPoint.Point.X - markerRectangleHalfSize,
                            markerPoint.Point.Y - markerRectangleHalfSize),
                        new SizeF(
                            markerRectangleHalfSize * 2,
                            markerRectangleHalfSize * 2));

                    graphics.FillEllipse(
                        new SolidBrush(seriesLinePen.Color),
                        markerRectangle);

                    if (ShowLapTimePointLabels)
                    {
                        using (SolidBrush brush = new SolidBrush(AxisLabelColor))
                        {
                            var label = markerPoint.Text;
                            var stringSize = graphics.MeasureString(label, YAxisFont);

                            PointF point = new PointF(
                                markerPoint.Point.X - markerRectangleHalfSize,
                                markerPoint.Point.Y - markerRectangleHalfSize);

                            graphics.DrawString(label, YAxisFont, brush, point);
                        }
                    }

                    LapTimeMarker marker = new LapTimeMarker()
                    {
                        Rectangle = new RectangleF(
                        new PointF(
                            markerPoint.Point.X - 10,
                            markerPoint.Point.Y - 10),
                        new SizeF(
                            20,
                            20)),
                        Text = markerPoint.Text
                    };

                    _lapTimeMarkers.Add(marker);
                }
            }
        }

        protected virtual MarkerPoint[] GetSeriesLinePoints(int runId, IList<LapInfo> laps)
        {
            MarkerPoint[] seriesLinePoints = new MarkerPoint[laps.Count];

            for (int i = 0; i < laps.Count; i++)
            {
                float x = YAxisOffset + (XAxisInterval * i);
                float y = GetScaleSeriesValueY(laps[i].LapTime);

                seriesLinePoints[i] = new MarkerPoint()
                {
                    Point = new PointF(x, y),
                    Text = $"Run {runId} Lap {i + 1}: {Math.Round(laps[i].LapTime, 2)}"
                };
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

        private void ExceptionHandler(Exception ex)
        {
            Console.WriteLine(ex.ToString());
            MessageBox.Show(ex.Message);
        }

        private void picGraph_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                e.Graphics.Clear(Color.Black);
                e.Graphics.InterpolationMode = InterpolationMode.High;
                e.Graphics.CompositingQuality = CompositingQuality.HighQuality;
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

                if (ShowGrid)
                    DrawGrid(e.Graphics);

                if (ShowXAxisLabels && LapTimes != null)
                {
                    var lapSeries = LapTimes.OrderByDescending(l => l.Laps.Count).FirstOrDefault();
                    if (lapSeries != null)
                        DrawXAxisLabels(e.Graphics, lapSeries.Laps);
                }

                if (LapTimes != null && LapTimes.Count > 0)
                {
                    _lapTimeMarkers.Clear();

                    foreach (LapTimeChartViewModel lapSeries in LapTimes)
                    {
                        DrawSeries(e.Graphics, lapSeries);
                    }
                }

                DrawXAxis(e.Graphics);
                DrawYAxis(e.Graphics);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void picGraph_Resize(object sender, EventArgs e)
        {
            picGraph.Invalidate();
        }

        private void picGraph_MouseMove(object sender, MouseEventArgs e)
        {
            var point = picGraph.PointToClient(Cursor.Position);
            var target = _lapTimeMarkers.FirstOrDefault(l => l.Rectangle.Contains(point));
            if (target != null)
            {
                toolTip1.Show(target.Text, picGraph, point.X - 2, point.Y - 15, 5000);
            }
            else
            {
                toolTip1.Hide(picGraph);
            }
        }

        #endregion

        #region classes

        private class LapTimeMarker
        {
            public RectangleF Rectangle { get; set; }
            public string Text { get; set; }
        }

        protected class MarkerPoint
        {
            public PointF Point { get; set; }
            public string Text { get; set; }
        }

        #endregion
    }
}
