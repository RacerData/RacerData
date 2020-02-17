using System.Collections.Generic;
using System.Windows.Forms;
using RacerData.iRacing.Telemetry;

namespace RacerData.iRacing.Setups.ClassBuilder.Controls
{
    public partial class TireTempGraphSet : UserControl
    {
        #region fields

        private IDictionary<TirePosition, TireTempGraph> _graphs;

        #endregion

        #region properties

        private float _tempWarning = 200.0F;
        public float TireTempWarning
        {
            get
            {
                return _tempWarning;
            }
            set
            {
                _tempWarning = value;
                _graphs[TirePosition.LF].TempWarning = _tempWarning;
                _graphs[TirePosition.RF].TempWarning = _tempWarning;
                _graphs[TirePosition.LR].TempWarning = _tempWarning;
                _graphs[TirePosition.RR].TempWarning = _tempWarning;
            }
        }

        private float _tempRange = 85;
        public float TireTempRange
        {
            get
            {
                return _tempRange;
            }
            set
            {
                _tempRange = value;
                _graphs[TirePosition.LF].Range = _tempRange;
                _graphs[TirePosition.RF].Range = _tempRange;
                _graphs[TirePosition.LR].Range = _tempRange;
                _graphs[TirePosition.RR].Range = _tempRange;
            }
        }

        #endregion

        #region ctor

        public TireTempGraphSet()
        {
            InitializeComponent();

            var lfTemperatures = new Dictionary<TreadPosition, float>();
            lfTemperatures.Add(TreadPosition.Inside, 0.0F);
            lfTemperatures.Add(TreadPosition.Middle, 0.0F);
            lfTemperatures.Add(TreadPosition.Outside, 0.0F);

            var rfTemperatures = new Dictionary<TreadPosition, float>();
            rfTemperatures.Add(TreadPosition.Inside, 0.0F);
            rfTemperatures.Add(TreadPosition.Middle, 0.0F);
            rfTemperatures.Add(TreadPosition.Outside, 0.0F);

            var lrTemperatures = new Dictionary<TreadPosition, float>();
            lrTemperatures.Add(TreadPosition.Inside, 0.0F);
            lrTemperatures.Add(TreadPosition.Middle, 0.0F);
            lrTemperatures.Add(TreadPosition.Outside, 0.0F);

            var rrTemperatures = new Dictionary<TreadPosition, float>();
            rrTemperatures.Add(TreadPosition.Inside, 0.0F);
            rrTemperatures.Add(TreadPosition.Middle, 0.0F);
            rrTemperatures.Add(TreadPosition.Outside, 0.0F);

            _graphs = new Dictionary<TirePosition, TireTempGraph>();
            _graphs.Add(TirePosition.LF, tireTempGraphLF);
            _graphs.Add(TirePosition.RF, tireTempGraphRF);
            _graphs.Add(TirePosition.LR, tireTempGraphLR);
            _graphs.Add(TirePosition.RR, tireTempGraphRR);
        }

        #endregion

        #region public

        public void DisplayTemperatures(IDictionary<TirePosition, IDictionary<TreadPosition, float>> values)
        {
            _graphs[TirePosition.LF].DisplayTemperatures(TirePosition.LF, values[TirePosition.LF]);
            _graphs[TirePosition.RF].DisplayTemperatures(TirePosition.RF, values[TirePosition.RF]);
            _graphs[TirePosition.LR].DisplayTemperatures(TirePosition.LR, values[TirePosition.LR]);
            _graphs[TirePosition.RR].DisplayTemperatures(TirePosition.RR, values[TirePosition.RR]);
        }

        #endregion
    }
}
