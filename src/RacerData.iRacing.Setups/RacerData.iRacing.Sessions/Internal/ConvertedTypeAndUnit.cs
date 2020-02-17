using System;

namespace RacerData.iRacing.Sessions.Internal
{
    internal class ConvertedTypeAndUnit
    {
        public SetupSettingDataTypes DataType { get; set; }
        public string Units { get; set; }
        public object ConvertedValue { get; set; }
        public string StringValue { get { return ConvertedValue.ToString(); } }
        public bool IsNumeric
        {
            get
            {
                switch (DataType)
                {
                    case SetupSettingDataTypes.irBool:
                    case SetupSettingDataTypes.irInt:
                    case SetupSettingDataTypes.irBit:
                    case SetupSettingDataTypes.irFloat:
                    case SetupSettingDataTypes.irDouble:
                        {
                            return true;
                        }
                    case SetupSettingDataTypes.irChar:
                    case SetupSettingDataTypes.irArrayInt:
                    case SetupSettingDataTypes.irArrayFloat:
                    default:
                        {
                            return false;
                        }
                }
            }
        }
        public float ConvertedFloat
        {
            get
            {
                float floatValue = -1F;

                switch (DataType)
                {
                    case SetupSettingDataTypes.irBool:
                        {
                            floatValue = (StringValue == "ON" || StringValue == "1") ?
                                1.0F :
                                0.0F;
                            break;
                        }
                    case SetupSettingDataTypes.irInt:
                    case SetupSettingDataTypes.irBit:
                    case SetupSettingDataTypes.irFloat:
                        {
                            floatValue = Convert.ToSingle(
                                StringValue,
                                System.Globalization.CultureInfo.InvariantCulture);
                            break;
                        }
                    case SetupSettingDataTypes.irDouble:
                        {
                            floatValue = (float)Convert.ToDouble(
                                StringValue,
                                System.Globalization.CultureInfo.InvariantCulture);
                            break;
                        }
                    case SetupSettingDataTypes.irChar:
                    case SetupSettingDataTypes.irArrayInt:
                    case SetupSettingDataTypes.irArrayFloat:
                    default:
                        break;
                }

                return (float)Math.Round(floatValue, 3);
            }
        }
        public ConvertedTypeAndUnit(SetupSettingDataTypes dataType, object converted)
            : this(dataType, String.Empty, converted)
        {

        }
        public ConvertedTypeAndUnit(SetupSettingDataTypes dataType, string units, object converted)
        {
            DataType = dataType;
            Units = units;
            ConvertedValue = converted;
        }
    }
}
