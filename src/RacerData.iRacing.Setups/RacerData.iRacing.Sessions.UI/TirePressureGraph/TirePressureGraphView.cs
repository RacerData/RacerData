using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using RacerData.iRacing.Sessions.Ui.Properties;

namespace RacerData.iRacing.Sessions.Ui.TirePressureGraph
{
    public partial class TirePressureGraphView : UserControl
    {
        #region consts

        private const int DefaultColumnCount = 2;
        private const float AxisLabelMargin = 26F;
        private const float ValueLabelMargin = 48F;
        private const float GridMargin = 5F;
        private const float ValueBarSideMargin = 2F;

        #endregion

        #region properties

        public bool ShowLabels { get; set; } = true;
        public bool ShowGridLines { get; set; } = true;
        public Color AxisLabelColor { get; set; } = Color.White;
        public Font AxisLabelFont { get; set; } = new Font("Segoe UI", 8);
        public Color ColdValueLabelColor { get; set; } = Color.LightSkyBlue;
        public Color DeltaValueLabelColor { get; set; } = Color.White;
        public Color HotValueLabelColor { get; set; } = Color.OrangeRed;
        public Font ValueLabelFont { get; set; } = new Font("Segoe UI", 10);
        public Font DeltaValueLabelFont { get; set; } = new Font("Segoe UI", 10, FontStyle.Bold);
        public float GridMarginLeft
        {
            get
            {
                if (ShowLabels)
                    return AxisLabelMargin;
                else
                    return GridMargin;
            }
        }
        public float GridMarginRight
        {
            get
            {
                if (ShowLabels)
                    return ValueLabelMargin;
                else
                    return GridMargin;
            }
        }

        public Color GridLineColor { get; set; } = Color.FromArgb(32, 32, 32);
        public float GridLineSize { get; set; } = 1.0F;

        public Color BorderLineColor { get; set; } = Color.FromArgb(64, 64, 64);
        public float BorderLineSize { get; set; } = 1F;

        public int RangeMin { get; set; } = 12;
        public int RangeMax { get; set; } = 30;
        public int RangeSpan
        {
            get
            {
                return RangeMax - RangeMin;
            }
        }

        public PointF GridLocation
        {
            get
            {
                return new PointF(
                   GridMarginLeft + GridMargin,
                   GridMargin);
            }
        }
        public SizeF GridSize
        {
            get
            {
                return new SizeF(
                    picGraph.Width - GridMarginLeft - GridMarginRight - GridMargin,
                    picGraph.Height - GridMargin - GridMargin);
            }
        }
        public RectangleF GridRectangle
        {
            get
            {
                return new RectangleF(
                    GridLocation,
                    GridSize);
            }
        }
        public SizeF GridCellSize
        {
            get
            {
                return new SizeF(
                    GridSize.Width / (float)ColumnCount,
                    GridSize.Height / (float)RowCount);
            }
        }
        public int RowCount
        {
            get
            {
                var rowCount = RangeSpan;
                var rowHeight = GridRectangle.Height / rowCount;
                while (rowHeight < (picGraph.Height * .15F))
                {
                    rowCount = (int)(rowCount / 2);
                    rowHeight = GridRectangle.Height / rowCount;
                }

                return rowCount;
            }
        }
        public float RowSpan
        {
            get
            {
                return (RangeSpan / RowCount);

            }
        }
        public int ColumnCount { get; set; } = DefaultColumnCount;
        public float ColdPsi { get; set; }
        public float HotPsi { get; set; }

        #endregion

        #region ctor

        public TirePressureGraphView()
        {
            InitializeComponent();
        }


        #endregion

        #region public

        public void DisplayTirePressures(float coldPsi, float hotPsi)
        {
            ColdPsi = coldPsi;
            HotPsi = hotPsi;
            picGraph.Invalidate();
        }
        public void DisplayTirePressures(TirePressureModel model)
        {
            ColdPsi = model.ColdPsi;
            HotPsi = model.HotPsi;
            picGraph.Invalidate();
        }

        #endregion

        #region protected

        protected virtual void DrawGrid(Graphics graphics)
        {
            if (!ShowGridLines && !ShowLabels)
                return;

            using (Pen gridPen = new Pen(GridLineColor, GridLineSize))
            {
                for (float y = 0; y < RowCount + 1; ++y)
                {
                    PointF startPoint = new PointF(GridRectangle.X, (y * GridCellSize.Height) + GridLineSize);
                    if (ShowGridLines)
                    {
                        PointF endPoint = new PointF(GridRectangle.X + GridRectangle.Width, (y * GridCellSize.Height) + GridLineSize);

                        graphics.DrawLine(gridPen,
                            startPoint,
                            endPoint);
                    }

                    if (ShowLabels)
                    {
                        float labelValue = RangeMax - (y * RowSpan);
                        var labelText = labelValue.ToString("##0.0");
                        DrawAxisLabel(
                            graphics,
                            startPoint.Y,
                            labelText,
                            (y == 0));
                    }
                }
            }

            if (ShowGridLines && ColumnCount > 1)
            {
                using (Pen gridPen = new Pen(GridLineColor, GridLineSize))
                {
                    for (float x = 0; x < ColumnCount + 1; ++x)
                    {
                        graphics.DrawLine(gridPen,
                            GridRectangle.X + (x * GridCellSize.Width), GridRectangle.Y,
                            GridRectangle.X + (x * GridCellSize.Width), GridRectangle.Y + GridRectangle.Height - BorderLineSize);
                    }
                }

            }
        }

        protected virtual void DrawAxisLabel(Graphics graphics, float y, string labelText, bool firstLabel)
        {
            using (SolidBrush brush = new SolidBrush(AxisLabelColor))
            {
                var stringSize = graphics.MeasureString(labelText, AxisLabelFont);

                var textLocationX = picGraph.Location.X;
                var textLocationY = firstLabel ? y - (stringSize.Height / 10) : y - (stringSize.Height / 2);

                graphics.DrawString(
                    labelText,
                    AxisLabelFont,
                    brush,
                    textLocationX,
                    textLocationY);
            }
        }

        protected virtual void DrawGridBorder(Graphics graphics)
        {
            using (Pen gridPen = new Pen(BorderLineColor, BorderLineSize))
            {
                graphics.DrawRectangle(gridPen,
                    GridRectangle.X, GridRectangle.Y,
                    GridRectangle.Width, GridRectangle.Height);
            }
        }

        protected virtual void DrawControlBorder(Graphics graphics)
        {
            using (Pen pen = new Pen(Color.FromArgb(48, 48, 48), 0.5F))
            {
                graphics.DrawRectangle(pen,
                    1, 1,
                    this.Width - 2, this.Height - 2);
            }
        }

        protected virtual void DrawPressures(Graphics graphics, float coldPsi, float hotPsi)
        {
            if (coldPsi == 0 && hotPsi == 0)
                return;

            var scaledCold = ScaleValue(coldPsi);
            var scaledHot = ScaleValue(hotPsi);

            PointF topLeft = new PointF(GridRectangle.X + ValueBarSideMargin + 2, scaledHot);
            PointF bottomLeft = new PointF(GridRectangle.X + ValueBarSideMargin + 2, scaledCold);
            PointF bottomRight = new PointF(GridRectangle.X + GridRectangle.Width - ValueBarSideMargin, scaledCold);
            PointF topRight = new PointF(GridRectangle.X + GridRectangle.Width - ValueBarSideMargin, scaledHot);
            PointF[] polygonPoints = { topLeft, bottomLeft, bottomRight, topRight };

            var deltaLabelText = (hotPsi - coldPsi).ToString("##0.0");
            var deltaStringSize = graphics.MeasureString(deltaLabelText, DeltaValueLabelFont);
            float deltaLabelY = (GridRectangle.Height / 2) - (deltaStringSize.Height / 4);

            using (SolidBrush brush = new SolidBrush(ColdValueLabelColor))
            {
                var coldLabelText = $"{coldPsi.ToString("##0.0")}";
                var coldStringSize = graphics.MeasureString(coldLabelText, ValueLabelFont);
                var coldLabelY = GridRectangle.Height - (coldStringSize.Height / 2);

                graphics.DrawString(
                    coldLabelText,
                    ValueLabelFont,
                    brush,
                    picGraph.Width - coldStringSize.Width,
                    coldLabelY);
            }

            using (SolidBrush brush = new SolidBrush(HotValueLabelColor))
            {
                var hotLabelText = $"{hotPsi.ToString("##0.0")}";
                var hotStringSize = graphics.MeasureString(hotLabelText, ValueLabelFont);
                var hotLabelY = GridRectangle.Y;

                graphics.DrawString(
                    hotLabelText,
                    ValueLabelFont,
                    brush,
                    picGraph.Width - hotStringSize.Width,
                    hotLabelY);
            }

            using (SolidBrush brush = new SolidBrush(DeltaValueLabelColor))
            {
                graphics.DrawString(
                    deltaLabelText,
                    DeltaValueLabelFont,
                    brush,
                    picGraph.Width - deltaStringSize.Width,
                    deltaLabelY);
            }

            using (Image image = Resources.PressureGraphGradient)
            {
                GraphicsPath path = new GraphicsPath();
                path.AddLine(topLeft, topRight);
                path.AddLine(topRight, bottomRight);
                path.AddLine(bottomRight, bottomLeft);
                path.CloseFigure();
                RectangleF pressureValuesRectangle = path.GetBounds();
                graphics.SetClip(path);
                graphics.DrawImage(image, pressureValuesRectangle, new Rectangle(0, 0, image.Width, image.Height), GraphicsUnit.Pixel);
            }
        }

        protected virtual float ScaleValue(float value)
        {
            if (value <= RangeMin)
                return 0.0F;

            if (value >= RangeMax)
                return 1.0F;

            var valuePercent = (value - RangeMin) / RangeSpan;

            return GridRectangle.Height - (GridRectangle.Height * valuePercent);
        }

        #endregion

        #region private

        private void picGraph_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            DrawGrid(e.Graphics);
            DrawGridBorder(e.Graphics);
            DrawPressures(e.Graphics, ColdPsi, HotPsi);
        }

        private void TirePressureView_Paint(object sender, PaintEventArgs e)
        {
            DrawControlBorder(e.Graphics);
        }

        private static float Clamp(float value, float min, float max)
        {
            return (value < min) ? min : (value > max) ? max : value;
        }

        #endregion
    }
}
