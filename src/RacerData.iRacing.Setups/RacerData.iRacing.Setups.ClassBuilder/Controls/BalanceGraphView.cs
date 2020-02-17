using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace RacerData.iRacing.Setups.ClassBuilder.Controls
{
    public partial class BalanceGraphView : UserControl
    {
        #region consts

        private const int DefaultEllipseCount = 4;
        private const float MaxBubbleScaling = .25F;
        private const float MinBubbleScaling = .05F;
        private const float TempBubbleScaling = 1.2F;

        #endregion

        #region properties

        public bool ShowWebDisplay { get; set; } = true;
        public bool ShowBubbleDisplay { get; set; } = true;

        /* bubble */
        public float MaxBubbleSize
        {
            get
            {
                return ((picGraph.Width + picGraph.Height) / 2) * MaxBubbleScaling;
            }
        }

        public float MinBubbleSize
        {
            get
            {
                return ((picGraph.Width + picGraph.Height) / 2) * MinBubbleScaling;
            }
        }

        private Color _tempBubbleColor = Color.Red;
        public Color TempBubbleColor
        {
            get
            {
                return _tempBubbleColor;
            }
            set
            {
                _tempBubbleColor = value;
                picGraph.Invalidate();
            }
        }

        private Color _wearBubbleColor = Color.DodgerBlue;
        public Color WearBubbleColor
        {
            get
            {
                return _wearBubbleColor;
            }
            set
            {
                _wearBubbleColor = value;
                picGraph.Invalidate();
            }
        }
        public float WebLineWidth { get; set; } = 1.5F;

        /* grid */
        private int _ellipseCount = DefaultEllipseCount;
        public int EllipseCount
        {
            get
            {
                return _ellipseCount;
            }
            set
            {
                _ellipseCount = value;
                picGraph.Invalidate();
            }
        }

        private Color _gridlineColor = Color.FromArgb(32, 32, 32);
        public Color GridLineColor
        {
            get
            {
                return _gridlineColor;
            }
            set
            {
                _gridlineColor = value;
                picGraph.Invalidate();
            }
        }

        private Color _ellipseColor = Color.FromArgb(16, 16, 16);
        public Color EllipseColor
        {
            get
            {
                return _ellipseColor;
            }
            set
            {
                _ellipseColor = value;
                picGraph.Invalidate();
            }
        }

        /* Tire Temp */
        private float _leftFrontTemp = 164.0F;
        public float TireTempLeftFront
        {
            get
            {
                return (float)Math.Round(_leftFrontTemp, 0);
            }
            set
            {
                _leftFrontTemp = value;
                picGraph.Invalidate();
            }
        }

        private float _leftRearTemp = 180.0F;
        public float TireTempLeftRear
        {
            get
            {
                return (float)Math.Round(_leftRearTemp, 0);
            }
            set
            {
                _leftRearTemp = value;
                picGraph.Invalidate();
            }
        }

        private float _rightFrontTemp = 198.0F;
        public float TireTempRightFront
        {
            get
            {
                return (float)Math.Round(_rightFrontTemp, 0);
            }
            set
            {
                _rightFrontTemp = value;
                picGraph.Invalidate();
            }
        }

        private float _rightRearTemp = 195.0F;
        public float TireTempRightRear
        {
            get
            {
                return (float)Math.Round(_rightRearTemp, 0);
            }
            set
            {
                _rightRearTemp = value;
                picGraph.Invalidate();
            }
        }

        private float _tireTempScale = 50.0F;
        public float TireTempScale
        {
            get
            {
                return (float)Math.Round(_tireTempScale, 0);
            }
            set
            {
                _tireTempScale = value;
                picGraph.Invalidate();
            }
        }

        public PointF TireTempBalanceValue
        {
            get
            {
                var frontAverage = (TireTempLeftFront + TireTempRightFront) / 2;
                var rearAverage = (TireTempLeftRear + TireTempRightRear) / 2;
                var leftAverage = (TireTempLeftFront + TireTempLeftRear) / 2;
                var rightAverage = (TireTempRightFront + TireTempRightRear) / 2;

                var sideToSideBalance = Clamp((rightAverage - leftAverage) / TireTempScale, -1, 1);
                var frontToRearBalance = Clamp((rearAverage - frontAverage) / TireTempScale, -1, 1);

                return new PointF(sideToSideBalance, frontToRearBalance);
            }
        }

        /* Tire Wear */
        private float _leftFrontWear = 164.0F;
        public float TireWearLeftFront
        {
            get
            {
                return (float)Math.Round(_leftFrontWear, 0);
            }
            set
            {
                _leftFrontWear = value;
                picGraph.Invalidate();
            }
        }

        private float _leftRearWear = 180.0F;
        public float TireWearLeftRear
        {
            get
            {
                return (float)Math.Round(_leftRearWear, 0);
            }
            set
            {
                _leftRearWear = value;
                picGraph.Invalidate();
            }
        }

        private float _rightFrontWear = 198.0F;
        public float TireWearRightFront
        {
            get
            {
                return (float)Math.Round(_rightFrontWear, 0);
            }
            set
            {
                _rightFrontWear = value;
                picGraph.Invalidate();
            }
        }

        private float _rightRearWear = 195.0F;
        public float TireWearRightRear
        {
            get
            {
                return (float)Math.Round(_rightRearWear, 0);
            }
            set
            {
                _rightRearWear = value;
                picGraph.Invalidate();
            }
        }

        private float _tireWearScale = 10.0F;
        public float TireWearScale
        {
            get
            {
                return (float)Math.Round(_tireWearScale, 0);
            }
            set
            {
                _tireWearScale = value;
                picGraph.Invalidate();
            }
        }

        public PointF TireWearBalanceValue
        {
            get
            {
                var frontAverage = (TireWearLeftFront + TireWearRightFront) / 2;
                var rearAverage = (TireWearLeftRear + TireWearRightRear) / 2;
                var leftAverage = (TireWearLeftFront + TireWearLeftRear) / 2;
                var rightAverage = (TireWearRightFront + TireWearRightRear) / 2;

                var sideToSideBalance = Clamp((rightAverage - leftAverage) / TireWearScale, -1, 1);
                var frontToRearBalance = Clamp((rearAverage - frontAverage) / TireWearScale, -1, 1);

                return new PointF(sideToSideBalance, frontToRearBalance);
            }
        }

        #endregion

        #region ctor

        public BalanceGraphView()
        {
            InitializeComponent();
        }

        #endregion

        #region public

        public void DisplayTireTempBalance(float leftFront, float leftRear, float rightFront, float rightRear)
        {
            _leftFrontTemp = leftFront;
            _leftRearTemp = leftRear;
            _rightFrontTemp = rightFront;
            _rightRearTemp = rightRear;

            picGraph.Invalidate();
        }

        public void DisplayTireWearBalance(float leftFront, float leftRear, float rightFront, float rightRear)
        {
            _leftFrontWear = leftFront;
            _leftRearWear = leftRear;
            _rightFrontWear = rightFront;
            _rightRearWear = rightRear;

            picGraph.Invalidate();
        }

        #endregion

        #region private

        private void picGraph_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            int centerX = picGraph.Width / 2;
            int centerY = picGraph.Height / 2;

            var wearCompositeValue = Math.Abs(TireWearBalanceValue.X) + Math.Abs(TireWearBalanceValue.Y);
            var wearBubbleSize = GetScaledBubbleSize(wearCompositeValue);

            var tempCompositeValue = Math.Abs(TireTempBalanceValue.X) + Math.Abs(TireTempBalanceValue.Y);
            var tempBubbleSize = GetScaledBubbleSize(tempCompositeValue) * TempBubbleScaling;

            if (wearBubbleSize <= tempBubbleSize)
            {
                if (ShowBubbleDisplay)
                {
                    DrawTempBubble(e.Graphics, centerX, centerY, tempBubbleSize);
                    DrawWearBubble(e.Graphics, centerX, centerY, wearBubbleSize);
                }

                DrawGridAndBorder(e.Graphics, centerX, centerY);

                if (ShowWebDisplay)
                {
                    DrawTempWeb(e.Graphics, centerX, centerY);
                    DrawWearWeb(e.Graphics, centerX, centerY);
                }
            }
            else
            {
                if (ShowBubbleDisplay)
                {
                    DrawWearBubble(e.Graphics, centerX, centerY, wearBubbleSize);
                    DrawTempBubble(e.Graphics, centerX, centerY, tempBubbleSize);
                }

                DrawGridAndBorder(e.Graphics, centerX, centerY);

                if (ShowWebDisplay)
                {
                    DrawWearWeb(e.Graphics, centerX, centerY);
                    DrawTempWeb(e.Graphics, centerX, centerY);
                }
            }
        }

        private void DrawGridAndBorder(Graphics graphics, int centerX, int centerY)
        {
            int step = centerX / EllipseCount;

            using (Pen ellipsePen = new Pen(EllipseColor, 2))
            {
                for (int i = 0; i < EllipseCount; i++)
                {
                    int scale = (int)(step * i + ((centerX * .78) / EllipseCount));

                    Rectangle rect = new Rectangle(centerX - scale, centerY - scale, scale * 2, scale * 2);

                    graphics.DrawEllipse(ellipsePen, rect);
                }
            }

            using (Pen crossPen = new Pen(EllipseColor, 1))
            {
                graphics.DrawLine(crossPen, centerX, 0, centerX, picGraph.Height);
                graphics.DrawLine(crossPen, 0, centerY, picGraph.Width, centerY);
            }

            using (Pen borderPen = new Pen(GridLineColor, 3))
            {
                graphics.DrawRectangle(borderPen, new Rectangle(0, 0, picGraph.Width - 1, picGraph.Height));
            }
        }

        // webs
        private void DrawWearWeb(Graphics graphics, int centerX, int centerY)
        {
            float wearRange = 25;

            float lfScaledWear = (TireWearLeftFront - (100 - wearRange)) / wearRange;
            float rfScaledWear = (TireWearRightFront - (100 - wearRange)) / wearRange;
            float lrScaledWear = (TireWearLeftRear - (100 - wearRange)) / wearRange;
            float rrScaledWear = (TireWearRightRear - (100 - wearRange)) / wearRange;

            var graphRange = ((picGraph.Width + picGraph.Height) / 4.0F) * .75F; // scale to the outermost ellipse

            var lfPoint = lfScaledWear * graphRange;
            var rfPoint = rfScaledWear * graphRange;
            var lrPoint = lrScaledWear * graphRange;
            var rrPoint = rrScaledWear * graphRange;

            PointF[] webPoints =
            {
                new PointF(centerX - Math.Abs(lfPoint), centerY - Math.Abs(lfPoint)),
                new PointF(centerX - Math.Abs(lrPoint), centerY + Math.Abs(lrPoint)),
                new PointF(centerX + Math.Abs(rrPoint), centerY + Math.Abs(rrPoint)),
                new PointF(centerX + Math.Abs(rfPoint), centerY - Math.Abs(rfPoint))
            };

            using (Pen webPen = new Pen(WearBubbleColor, WebLineWidth))
            {
                graphics.DrawPolygon(webPen, webPoints);
            }
        }

        private void DrawTempWeb(Graphics graphics, int centerX, int centerY)
        {
            float temperatureRange = 200F;

            var graphRange = ((picGraph.Width + picGraph.Height) / 4) * .75F; // scale to the outermost ellipse

            var lfPoint = ((TireTempLeftFront / temperatureRange) * graphRange);
            var rfPoint = ((TireTempRightFront / temperatureRange) * graphRange);
            var lrPoint = ((TireTempLeftRear / temperatureRange) * graphRange);
            var rrPoint = ((TireTempRightRear / temperatureRange) * graphRange);

            PointF[] webPoints =
            {
                new PointF(centerX - Math.Abs(lfPoint), centerY - Math.Abs(lfPoint)),
                new PointF(centerX - Math.Abs(lrPoint), centerY + Math.Abs(lrPoint)),
                new PointF(centerX + Math.Abs(rrPoint), centerY + Math.Abs(rrPoint)),
                new PointF(centerX + Math.Abs(rfPoint), centerY - Math.Abs(rfPoint))
            };

            using (Pen webPen = new Pen(TempBubbleColor, WebLineWidth))
            {
                graphics.DrawPolygon(webPen, webPoints);
            }
        }

        // bubbles
        private void DrawWearBubble(Graphics graphics, int centerX, int centerY, float bubbleSize)
        {
            var wearValueX = centerX - (centerX * TireWearBalanceValue.X) - (bubbleSize / 2);
            var wearValueY = centerY - (centerY * TireWearBalanceValue.Y) - (bubbleSize / 2);

            using (SolidBrush valueBrush = new SolidBrush(WearBubbleColor))
            {
                graphics.FillEllipse(valueBrush, new RectangleF(wearValueX, wearValueY, bubbleSize, bubbleSize));
            }
        }

        private void DrawTempBubble(Graphics graphics, int centerX, int centerY, float bubbleSize)
        {
            var tempValueX = centerX + (centerX * TireTempBalanceValue.X) - (bubbleSize / 2);
            var tempValueY = centerY + (centerY * TireTempBalanceValue.Y) - (bubbleSize / 2);

            using (SolidBrush valueBrush = new SolidBrush(TempBubbleColor))
            {
                graphics.FillEllipse(valueBrush, new RectangleF(tempValueX, tempValueY, bubbleSize, bubbleSize));
            }
        }

        private static float Clamp(float value, float min, float max)
        {
            return (value < min) ? min : (value > max) ? max : value;
        }

        private float GetScaledBubbleSize(float value)
        {
            return ((MaxBubbleSize - MinBubbleSize) * value) + MinBubbleSize;
        }

        #endregion
    }
}
