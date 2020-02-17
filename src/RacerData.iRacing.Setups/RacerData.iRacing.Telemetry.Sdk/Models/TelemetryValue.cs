using System;
using RacerData.iRacingTelemetry;

namespace RacerData.iRacing.TelemetrySdk.Models
{
    internal class TelemetryValue : ITelemetryValue
    {
        #region properties

        public ITelemetryField Field { get; internal set; }

        public byte[] Bytes { get; internal set; }

        public object Value => GetFieldValueObject();

        #endregion

        #region ctor

        public TelemetryValue(ITelemetryField field, byte[] bytes)
        {
            Field = field;
            Bytes = bytes;
        }

        #endregion

        #region publc

        public override string ToString()
        {
            return String.Format("{0}: {1} {2}", Field.Name, Value, Field.Unit);
        }

        #endregion

        #region protected

        protected T GetFieldValue<T>()
        {
            return (T)GetFieldValueObject();
        }

        protected object GetFieldValueObject()
        {
            object fieldValue = null;

            switch (Field.DataType)
            {
                case irsdk_VarType.irsdk_bool:
                    {
                        fieldValue = BitConverter.ToBoolean(Bytes, 0);
                        break;
                    }
                case irsdk_VarType.irsdk_int:
                    {
                        fieldValue = BitConverter.ToInt16(Bytes, 0);
                        break;
                    }
                case irsdk_VarType.irsdk_bitField:
                    {
                        fieldValue = BitConverter.ToInt16(Bytes, 0);
                        break;
                    }
                case irsdk_VarType.irsdk_float:
                    {
                        fieldValue = BitConverter.ToSingle(Bytes, 0);
                        break;
                    }
                case irsdk_VarType.irsdk_double:
                    {
                        fieldValue = BitConverter.ToDouble(Bytes, 0);
                        break;
                    }
            }

            return fieldValue;
        }

        #endregion
    }
}
