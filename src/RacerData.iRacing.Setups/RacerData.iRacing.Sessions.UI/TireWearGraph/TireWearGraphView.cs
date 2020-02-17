using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace RacerData.iRacing.Sessions.Ui.TireWearGraph
{
    public partial class TireWearGraphView : UserControl
    {
        #region consts

        private const int VerticalGridCount = 10;
        private const int HorizontalGridCount = 4;
        private const int TextLocationYOffset = 24;

        #endregion

        #region properties

        private float _left = 100.0F;
        public float TireWearLeft
        {
            get
            {
                return (float)Math.Round(_left, 0);
            }
            set
            {
                _left = value;
                picGraph.Invalidate();
            }
        }

        private float _middle = 100.0F;
        public float TireWearMiddle
        {
            get
            {
                return (float)Math.Round(_middle, 0);
            }
            set
            {
                _middle = value;
                picGraph.Invalidate();
            }
        }

        private float _right = 100.0F;
        public float TireWearRight
        {
            get
            {
                return (float)Math.Round(_right, 0);
            }
            set
            {
                _right = value;
                picGraph.Invalidate();
            }
        }

        private float _rangeMax = 100.0F;
        public float RangeMax
        {
            get
            {
                return _rangeMax;
            }
            set
            {
                _rangeMax = value;
                picGraph.Invalidate();
            }
        }

        private float _rangeMin = 50.0F;
        public float RangeMin
        {
            get
            {
                return _rangeMin;
            }
            set
            {
                _rangeMin = value;
                picGraph.Invalidate();
            }
        }

        private float _wearWarning = 90.0F;
        public float TireWearWarning
        {
            get
            {
                return _wearWarning;
            }
            set
            {
                _wearWarning = value;
                picGraph.Invalidate();
            }
        }

        protected SizeF GridCellSize
        {
            get
            {
                return new SizeF(
                    ((float)picGraph.Width - 2) / (float)HorizontalGridCount,
                    (float)picGraph.Height / (float)VerticalGridCount);
            }
        }

        protected int TextLocationY
        {
            get
            {
                return picGraph.Height - TextLocationYOffset;
            }
        }

        protected int TextOffsetIncrementX
        {
            get
            {
                return picGraph.Width / 3;
            }
        }

        protected float RangeSpan
        {
            get
            {
                return RangeMax - RangeMin;
            }
        }

        /// <summary>
        /// Returns float 1.0 - 0.0 indicating percentage of
        ///  picGraph height that the warning limit is at.
        ///  1.0 = top, 0.0 = bottom
        /// </summary>
        protected float RangeScaledWarning
        {
            get
            {
                return (TireWearWarning - RangeMin) / RangeSpan;
            }
        }

        #endregion

        #region ctor

        public TireWearGraphView()
        {
            InitializeComponent();
        }

        #endregion

        #region public

        public void DisplayTireWear(TirePosition position, IDictionary<TreadPosition, float> values)
        {
            if (position == TirePosition.LF || position == TirePosition.LR)
            {

                TireWearLeft = values[TreadPosition.Outside];
                TireWearRight = values[TreadPosition.Inside];
            }
            else
            {
                TireWearLeft = values[TreadPosition.Inside];
                TireWearRight = values[TreadPosition.Outside];
            }

            TireWearMiddle = values[TreadPosition.Middle];

            picGraph.Invalidate();
        }

        #endregion

        #region private

        /// <summary>
        /// Returns the location of the value scaled vertically on the pictureBox
        /// Percentage is 0.0 = top (High Value), 1.0 = bottom (Low Value)
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private float GetScaledValue(float value)
        {
            //float scaledValue = value / RangeMax;
            float scaledValue = GetRangeScaledValue(value);
            return picGraph.Height - (picGraph.Height * scaledValue);
        }

        /// <summary>
        /// Returns a float between 0 and 1 representing the percentage
        /// along the range the value is.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private float GetRangeScaledValue(float value)
        {
            if (value < RangeMin)
                return 0F;

            if (value > RangeMax)
                return 1F;

            return ((value - RangeMin) / RangeSpan);
        }

        private void picGraph_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            DrawGrid(e.Graphics);

            float[] values = new float[]
            {
                TireWearLeft,
                TireWearMiddle,
                TireWearRight
            };

            DrawGraph(e.Graphics, values);

            using (Font drawFont = new Font("Segoe UI", 14, FontStyle.Bold))
            {
                using (SolidBrush textBrush = new SolidBrush(Color.WhiteSmoke))
                {
                    using (SolidBrush warnBrush = new SolidBrush(Color.Red))
                    {
                        DrawValues(
                            e.Graphics,
                            drawFont,
                            textBrush,
                            warnBrush,
                            values);
                    }
                }
            }

            DrawBorder(e.Graphics);
        }

        private Color GetRangeScaledColor(float value)
        {
            //          R   G   B
            // good     0   255 0   = 1.0
            // ok       255 255 0   = 0.5
            // bad      255 0   0   = 0.0

            float rangeScaledWarning = RangeScaledWarning;

            // below the warning limit.
            if (value < rangeScaledWarning)
            {
                return Color.Red;
            }

            // only need to blend the colors when above the warnng limit.
            float blendRange = 1.0F - rangeScaledWarning;
            // percentage along the range of the warning span.
            float warningScaledValue = (value - rangeScaledWarning) / blendRange;

            int r = (int)Clamp(warningScaledValue < .50 ? 255 : (int)(255 - (((warningScaledValue - .50) * 2) * 255)), 0, 255);
            int g = (int)Clamp(warningScaledValue > .50 ? 255 : (int)((warningScaledValue * 2) * 255), 0, 255);
            int b = 0;

            return Color.FromArgb(r, g, b);
        }

        private void DrawGraph(Graphics graphics, IList<float> values)
        {
            PointF bottomMiddle = new PointF((picGraph.Width / 2), picGraph.Height - 1);

            PointF bottomLeft = new PointF(0F, picGraph.Height - 1);

            PointF leftValue = new PointF(0F, GetScaledValue(values[0]));
            PointF middleValue = new PointF((picGraph.Width / 2), GetScaledValue(values[1]));
            PointF rightValue = new PointF(picGraph.Width - 1, GetScaledValue(values[2]));

            PointF bottomRight = new PointF(picGraph.Width - 1, picGraph.Height - 1);

            PointF[] polygonPoints = { bottomMiddle, bottomLeft, leftValue, middleValue, rightValue, bottomRight };

            var effectiveScaledValue = GetRangeScaledValue(values.Average());

            Color scaledColor = GetRangeScaledColor(effectiveScaledValue);

            using (SolidBrush tBrush = new SolidBrush(scaledColor))
            {
                graphics.FillPolygon(tBrush, polygonPoints, FillMode.Winding);
            }
        }

        private void DrawGrid(Graphics graphics)
        {
            using (Pen gridPen = new Pen(Color.DimGray))
            {
                for (float y = 0; y < VerticalGridCount + 1; ++y)
                {
                    graphics.DrawLine(gridPen, 0, y * GridCellSize.Height, picGraph.Width - 1, y * GridCellSize.Height);
                }

                for (float x = 0; x < HorizontalGridCount + 1; ++x)
                {
                    graphics.DrawLine(gridPen, x * GridCellSize.Width, 0, x * GridCellSize.Width, picGraph.Width);
                }

                float warning = GetScaledValue(TireWearWarning);
                Pen warningLevelPen = new Pen(Color.Red, 2F);
                graphics.DrawLine(warningLevelPen, 0, warning, picGraph.Width - 3, warning);
            }
        }

        private void DrawValues(Graphics graphics, Font font, SolidBrush textBrush, SolidBrush warningTextBrush, float[] values)
        {
            using (SolidBrush textBoxBrush = new SolidBrush(Color.Black))
            {
                graphics.FillRectangle(textBoxBrush, new Rectangle(0, (int)(TextLocationY - 2), picGraph.Width - 1, picGraph.Height));
            }

            for (int i = 0; i < values.Length; i++)
            {
                string value = String.Format("{0}", values[i]);

                var stringSize = graphics.MeasureString(value, font);

                var textLocationX = (TextOffsetIncrementX * i) + (TextOffsetIncrementX / 2) - (stringSize.Width / 2);

                graphics.DrawString(
                    value,
                    font,
                    values[i] < TireWearWarning ? warningTextBrush : textBrush,
                    textLocationX,
                    TextLocationY);
            }
        }

        private void DrawBorder(Graphics graphics)
        {
            using (Pen borderPen = new Pen(Color.DimGray, 3))
            {
                graphics.DrawRectangle(borderPen, new Rectangle(0, 0, picGraph.Width - 1, picGraph.Height));
                graphics.DrawRectangle(borderPen, new Rectangle(0, (int)(TextLocationY - 2), picGraph.Width - 1, picGraph.Height));
            }
        }

        private static float Clamp(float value, float min, float max)
        {
            return (value < min) ? min : (value > max) ? max : value;
        }

        #endregion
    }
}
