using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace RacerData.iRacing.Sessions.Ui.TirePressureGraph
{
    public partial class TirePressureGraphSet : UserControl
    {
        #region properties

        private int? _rightRangeMin = 0;
        public int RightRangeMin
        {
            get
            {
                if (_rightRangeMin == null)
                    _rightRangeMin = tirePressureViewLF.RangeMin;

                return _rightRangeMin.Value;
            }
            set
            {
                _rightRangeMin = value;
                tirePressureViewRF.RangeMin = _rightRangeMin.Value;
                tirePressureViewRR.RangeMin = _rightRangeMin.Value;
            }
        }

        private int? _rightRangeMax = 50;
        public int RightRangeMax
        {
            get
            {
                if (_rightRangeMax == null)
                    _rightRangeMax = tirePressureViewLF.RangeMax;

                return _rightRangeMax.Value;
            }
            set
            {
                _rightRangeMax = value;
                tirePressureViewRF.RangeMax = _rightRangeMax.Value;
                tirePressureViewRR.RangeMax = _rightRangeMax.Value;
            }
        }

        private int? _leftRangeMin = 0;
        public int LeftRangeMin
        {
            get
            {
                if (_leftRangeMin == null)
                    _leftRangeMin = tirePressureViewLF.RangeMin;

                return _leftRangeMin.Value;
            }
            set
            {
                _leftRangeMin = value;
                tirePressureViewLF.RangeMin = _leftRangeMin.Value;
                tirePressureViewLR.RangeMin = _leftRangeMin.Value;
            }
        }

        private int? _leftRangeMax = 50;
        public int LeftRangeMax
        {
            get
            {
                if (_leftRangeMax == null)
                    _leftRangeMax = tirePressureViewLF.RangeMax;

                return _leftRangeMax.Value;
            }
            set
            {
                _leftRangeMax = value;
                tirePressureViewLF.RangeMax = _leftRangeMax.Value;
                tirePressureViewLR.RangeMax = _leftRangeMax.Value;
            }
        }

        #endregion

        #region ctor

        public TirePressureGraphSet()
        {
            InitializeComponent();
        }

        #endregion

        #region public

        public void DisplayTirePressures(IList<TirePressureModel> values)
        {
            tirePressureViewLF.DisplayTirePressures(values.FirstOrDefault(p => p.Position == TirePosition.LF));
            tirePressureViewLR.DisplayTirePressures(values.FirstOrDefault(p => p.Position == TirePosition.LR));
            tirePressureViewRF.DisplayTirePressures(values.FirstOrDefault(p => p.Position == TirePosition.RF));
            tirePressureViewRR.DisplayTirePressures(values.FirstOrDefault(p => p.Position == TirePosition.RR));
            this.Invalidate();
        }

        #endregion

        #region private

        private void TirePressureGraphSet_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            float frontDelta = (tirePressureViewLF.HotPsi - tirePressureViewLF.ColdPsi) +
                (tirePressureViewRF.HotPsi - tirePressureViewRF.ColdPsi);

            float rearDelta = (tirePressureViewLR.HotPsi - tirePressureViewLR.ColdPsi) +
                (tirePressureViewRR.HotPsi - tirePressureViewRR.ColdPsi);

            float imbalance = rearDelta - frontDelta;

            // rear higher = positive value
            // 5 psi range
            float scaledValue = imbalance > 5 ? 0.95F : imbalance < -5 ? -0.95F : imbalance / 5;

            float centerY = this.Height / 2;

            float imbalanceY = centerY + (centerY * scaledValue);

            PointF topLeft = new PointF(6, centerY);
            PointF bottomLeft = new PointF(6, imbalanceY);
            PointF bottomRight = new PointF(this.Padding.Left - 5, imbalanceY);
            PointF topRight = new PointF(this.Padding.Left - 5, centerY);

            PointF[] polygonPoints = { topLeft, bottomLeft, bottomRight, topRight };

            using (SolidBrush brush = new SolidBrush(Color.Red))
            {
                e.Graphics.FillPolygon(brush, polygonPoints);
            }

            using (Pen pen = new Pen(Color.FromArgb(48, 48, 48), 0.5F))
            {
                e.Graphics.DrawRectangle(pen,
                    2, 2,
                    this.Padding.Left - 4, this.Height - 4);
            }

            using (Pen pen = new Pen(Color.FromArgb(48, 48, 48), 2))
            {
                e.Graphics.DrawLine(pen,
                    2, centerY,
                    this.Padding.Left - 4, centerY);
            }
        }

        #endregion
    }
}
