using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace RacerData.iRacing.Telemetry.Models
{
    public class FrameFieldValue : IValue
    {
        #region props
        public virtual IFieldDefinition Definition { get; set; }

        public virtual byte[] Bytes { get; set; }

        public virtual string ByteString
        {
            get
            {
                var sb = new StringBuilder();
                for (var s = 0; s < Bytes.Count(); s++)
                {
                    var hexString = Bytes[s].ToString("X");
                    hexString = (hexString.Length % 2 == 0 ? "" : "0") + hexString + " ";
                    sb.Append(hexString);
                }
                return sb.ToString();
            }
        }

        public virtual string FieldName { get { return Definition.Name; } }

        public virtual object FieldValue { get { return GetFieldValueObject(); } }

        public virtual string Unit => Definition.Unit;

        public virtual bool IsConverted => false;
        #endregion

        #region ctor
        public FrameFieldValue()
        {

        }
        public FrameFieldValue(IFieldDefinition definition)
        {
            Definition = definition;
        }
        #endregion

        #region methods
        protected T GetFieldValue<T>()
        {
            return (T)GetFieldValueObject();
        }

        protected virtual object GetFieldValueObject()
        {
            object fieldValue = null;

            switch (Definition.DataType)
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

        #region overrides
        public override string ToString()
        {
            return String.Format("{0}: {1} {2}", Definition.Name, FieldValue, Definition.Unit);
        }
        #endregion
    }
}
