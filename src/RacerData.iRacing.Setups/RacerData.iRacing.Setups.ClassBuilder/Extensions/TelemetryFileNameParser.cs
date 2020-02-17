using System;
using System.Globalization;

namespace RacerData.iRacing.Setups.ClassBuilder.Extensions
{
    public static class TelemetryFileNameParser
    {
        public static DateTime GetTelemetryFileDateTime(this string telemetryFileName)
        {
            return DateTime.ParseExact(telemetryFileName.Substring(telemetryFileName.Length - 23, 19), "yyyy-MM-dd HH-mm-ss", CultureInfo.InvariantCulture);
        }
    }
}
