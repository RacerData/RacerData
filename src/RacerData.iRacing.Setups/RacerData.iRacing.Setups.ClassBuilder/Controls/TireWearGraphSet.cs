using System.Collections.Generic;
using System.Windows.Forms;
using RacerData.iRacing.Telemetry;

namespace RacerData.iRacing.Setups.ClassBuilder.Controls
{
    public partial class TireWearGraphSet : UserControl
    {
        #region fields

        private IDictionary<TirePosition, TireWearGraph> _graphs;

        #endregion

        #region properties

        private float _wearWarning = 85;
        public float TireWearWarning
        {
            get
            {
                return _wearWarning;
            }
            set
            {
                _wearWarning = value;
                _graphs[TirePosition.LF].TireWearWarning = _wearWarning;
                _graphs[TirePosition.RF].TireWearWarning = _wearWarning;
                _graphs[TirePosition.LR].TireWearWarning = _wearWarning;
                _graphs[TirePosition.RR].TireWearWarning = _wearWarning;
            }
        }

        private float _wearRange = 85;
        public float TireWearRange
        {
            get
            {
                return _wearRange;
            }
            set
            {
                _wearRange = value;
                _graphs[TirePosition.LF].RangeMax = _wearRange;
                _graphs[TirePosition.RF].RangeMax = _wearRange;
                _graphs[TirePosition.LR].RangeMax = _wearRange;
                _graphs[TirePosition.RR].RangeMax = _wearRange;
            }
        }

        #endregion

        #region ctor

        public TireWearGraphSet()
        {
            InitializeComponent();

            var lfWear = new Dictionary<TreadPosition, float>();
            lfWear.Add(TreadPosition.Inside, 88.0F);
            lfWear.Add(TreadPosition.Middle, 89.0F);
            lfWear.Add(TreadPosition.Outside, 86.0F);

            var rfWear = new Dictionary<TreadPosition, float>();
            rfWear.Add(TreadPosition.Inside, 89.0F);
            rfWear.Add(TreadPosition.Middle, 90.0F);
            rfWear.Add(TreadPosition.Outside, 92.0F);

            var lrWear = new Dictionary<TreadPosition, float>();
            lrWear.Add(TreadPosition.Inside, 92.0F);
            lrWear.Add(TreadPosition.Middle, 89.0F);
            lrWear.Add(TreadPosition.Outside, 89.0F);

            var rrWear = new Dictionary<TreadPosition, float>();
            rrWear.Add(TreadPosition.Inside, 90.8F);
            rrWear.Add(TreadPosition.Middle, 91.0F);
            rrWear.Add(TreadPosition.Outside, 88.0F);

            _graphs = new Dictionary<TirePosition, TireWearGraph>();
            _graphs.Add(TirePosition.LF, tireWearGraphLF);
            _graphs.Add(TirePosition.RF, tireWearGraphRF);
            _graphs.Add(TirePosition.LR, tireWearGraphLR);
            _graphs.Add(TirePosition.RR, tireWearGraphRR);
        }

        #endregion

        #region public

        public void DisplayTireWear(IDictionary<TirePosition, IDictionary<TreadPosition, float>> values)
        {
            _graphs[TirePosition.LF].DisplayTireWear(TirePosition.LF, values[TirePosition.LF]);
            _graphs[TirePosition.RF].DisplayTireWear(TirePosition.RF, values[TirePosition.RF]);
            _graphs[TirePosition.LR].DisplayTireWear(TirePosition.LR, values[TirePosition.LR]);
            _graphs[TirePosition.RR].DisplayTireWear(TirePosition.RR, values[TirePosition.RR]);
        }

        #endregion
    }
}
