using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RacerData.iRacing.Telemetry.Models
{
    public partial class Frame 
    {
        #region properties
        public IList<IValue> FieldValues { get; set; }
        #endregion

        #region ctor
        public Frame()
        {
            FieldValues = new List<IValue>();
        }
        #endregion

        #region public methods
        public virtual T GetTelemetryValue<T>(string key)
        {
            var field = FieldValues.FirstOrDefault(f => f.FieldName == key);

            if (null == field)
                return default(T);

            var readData = field.FieldValue;

            if (readData is T)
            {
                return (T)readData;
            }
            else
            {
                try
                {
                    return (T)Convert.ChangeType(readData, typeof(T));
                }
                catch (InvalidCastException)
                {
                    return default(T);
                }
            }
        }
        #endregion
    }
}
