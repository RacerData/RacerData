using System.Collections.Generic;
using RacerData.iRacing.Telemetry;

namespace RacerData.iRacing.Setups.ClassBuilder.Models
{
    public class TireSurfaceValues
    {
        #region fields

        private IDictionary<TreadPosition, double> _values = new Dictionary<TreadPosition, double>();

        #endregion

        #region properties

        public double Inside
        {
            get
            {
                return _values[TreadPosition.Inside];
            }
            set
            {
                _values[TreadPosition.Inside] = value;
            }
        }
        public double Middle
        {
            get
            {
                return _values[TreadPosition.Middle];
            }
            set
            {
                _values[TreadPosition.Middle] = value;
            }
        }
        public double Outside
        {
            get
            {
                return _values[TreadPosition.Outside];
            }
            set
            {
                _values[TreadPosition.Outside] = value;
            }
        }

        #endregion

        #region ctor

        public TireSurfaceValues(double inside, double middle, double outside)
            : this()
        {
            Inside = inside;
            Middle = middle;
            Outside = outside;
        }

        public TireSurfaceValues()
        {
            _values.Add(TreadPosition.Inside, 0);
            _values.Add(TreadPosition.Middle, 0);
            _values.Add(TreadPosition.Outside, 0);
        }

        #endregion
    }
}
