using System;
using RacerData.rNascarApp.Controls;

namespace RacerData.rNascarApp.Services
{
    class FieldFormatService
    {
        public static string FormatValue(string type, string format, string value)
        {
            var formattedText = String.Empty;

            if (String.IsNullOrEmpty(value))
                return formattedText;

            var typeName = type.Replace("System.", "");

            if (typeName == TypeNames.StringTypeName)
            {
                formattedText = value;
            }
            else if (typeName == TypeNames.Int32TypeName)
            {
                int buffer = 0;
                if (!Int32.TryParse(value, out buffer))
                {
                    formattedText = "--ERROR--";
                }
                else
                {
                    try
                    {
                        formattedText = buffer.ToString(format);
                    }
                    catch (FormatException)
                    {
                        formattedText = "--ERROR--";
                    }
                }
            }
            else if (typeName == TypeNames.DecimalTypeName || typeName == TypeNames.DoubleTypeName)
            {
                double buffer = 0.0;
                if (!double.TryParse(value, out buffer))
                {
                    formattedText = "--ERROR--";
                }
                else
                {
                    try
                    {
                        formattedText = buffer.ToString(format);
                    }
                    catch (FormatException)
                    {
                        formattedText = "--ERROR--";
                    }
                }
            }
            else if (typeName == TypeNames.TimeSpanTypeName)
            {
                TimeSpan buffer = new TimeSpan();
                if (!TimeSpan.TryParse(value, out buffer))
                {
                    formattedText = "--ERROR--";
                }
                else
                {
                    try
                    {
                        formattedText = buffer.ToString(format);
                    }
                    catch (FormatException)
                    {
                        formattedText = "Invalid format";
                    }
                }
            }
            else if (typeName == TypeNames.RunTypeTypeName)
            {
                formattedText = value;
            }
            else if (typeName == TypeNames.VehicleStatusTypeName)
            {
                formattedText = value;
            }
            else if (typeName == TypeNames.FlagStateTypeName)
            {
                formattedText = value;
            }
            else if (typeName == TypeNames.TrackStateTypeName)
            {
                formattedText = value;
            }
            else
            {
                throw new ArgumentException($"Unrecognized field type: {typeName}");
            }

            return formattedText;
        }
    }
}
