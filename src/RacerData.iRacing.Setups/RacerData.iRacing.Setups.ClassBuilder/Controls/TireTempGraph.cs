using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using RacerData.iRacing.Setups.ClassBuilder.Properties;
using RacerData.iRacing.Telemetry;

namespace RacerData.iRacing.Setups.ClassBuilder.Controls
{
    public partial class TireTempGraph : UserControl
    {
        #region consts

        private const int VerticalGridCount = 10;
        private const int HorizontalGridCount = 10;
        private const int TextLocationYOffset = 24;

        #endregion

        #region properties

        private float _left = 100.0F;
        public float TireTempLeft
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
        public float TireTempMiddle
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
        public float TireTempRight
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

        private float? _warning = 200.0F;
        public float? TempWarning
        {
            get
            {
                return _warning;
            }
            set
            {
                _warning = value;
                picGraph.Invalidate();
            }
        }

        private float _range = 250.0F;
        public float Range
        {
            get
            {
                return _range;
            }
            set
            {
                _range = value;
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

        #endregion

        #region ctor

        public TireTempGraph()
        {
            InitializeComponent();
        }

        #endregion

        #region public

        public void DisplayTemperatures(TirePosition position, IDictionary<TreadPosition, float> values)
        {
            if (position == TirePosition.LF || position == TirePosition.LR)
            {

                TireTempLeft = values[TreadPosition.Outside];
                TireTempRight = values[TreadPosition.Inside];
            }
            else
            {
                TireTempLeft = values[TreadPosition.Inside];
                TireTempRight = values[TreadPosition.Outside];
            }

            TireTempMiddle = values[TreadPosition.Middle];

            picGraph.Invalidate();
        }

        #endregion

        #region private

        private float GetScaledValue(float value)
        {
            float scaledValue = value / Range;
            return picGraph.Height - (picGraph.Height * scaledValue);
        }

        private void picGraph_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            float[] values = new float[]
            {
                TireTempLeft,
                TireTempMiddle,
                TireTempRight
            };

            DrawGrid(e.Graphics);

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

        private void DrawGraph(Graphics graphics, float[] values)
        {
            PointF bottomLeft = new PointF(0F, picGraph.Height - 1);

            PointF leftValue = new PointF(0F, GetScaledValue(values[0]));
            PointF middleValue = new PointF((picGraph.Width / 2), GetScaledValue(values[1]));
            PointF rightValue = new PointF(picGraph.Width - 2, GetScaledValue(values[2]));

            PointF bottomRight = new PointF(picGraph.Width - 2, picGraph.Height - 1);

            PointF[] polygonPoints = { bottomLeft, leftValue, middleValue, rightValue, bottomRight };

            using (Image image = Resources.GraphGradientGYR)
            {
                using (TextureBrush tBrush = new TextureBrush(image))
                {
                    graphics.FillPolygon(tBrush, polygonPoints, FillMode.Alternate);
                }
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

                if (TempWarning.HasValue)
                {
                    float warning = GetScaledValue(TempWarning.Value);
                    Pen warningLevelPen = new Pen(Color.Red, 2F);
                    graphics.DrawLine(warningLevelPen, 0, warning, picGraph.Width - 3, warning);
                }
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
                    values[i] > TempWarning ? warningTextBrush : textBrush,
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

        #endregion
    }
}
