using System;
using System.IO;

namespace RacerData.iRacing.Telemetry.Extensions
{
    public static class TelemetryFileNameExtensions
    {
        // telemetry file name format:
        // vehicle_track yyyy-MM-dd HH-mm-ss.ibt

        public static string TelemetryFileNameTimestampFormat = "yyyy-MM-dd HH-mm-ss";

        public static DateTime ParseDateTimeFromFileName(this string telemetryFileName)
        {
            string fileName = Path.GetFileNameWithoutExtension(telemetryFileName);

            if (fileName.Length > TelemetryFileNameTimestampFormat.Length + 6)
            {
                var timestampStartIndex = fileName.Length - TelemetryFileNameTimestampFormat.Length;
                var timestampString = fileName.Substring(timestampStartIndex);
                DateTime timestamp = new DateTime();

                if (DateTime.TryParseExact(
                        timestampString,
                        TelemetryFileNameTimestampFormat,
                        System.Globalization.CultureInfo.InvariantCulture,
                        System.Globalization.DateTimeStyles.None,
                        out timestamp)
                        )
                {
                    return timestamp;
                }
                else
                {
                    return default(DateTime);
                }
            }
            else
            {
                return default(DateTime);
            }
        }

        public static string ParseVehicleFromFileName(this string telemetryFileName)
        {
            string fileName = Path.GetFileNameWithoutExtension(telemetryFileName);

            return fileName.Split('_')[0].Trim();
        }

        public static string ParseTrackFromFileName(this string telemetryFileName)
        {
            string fileName = Path.GetFileNameWithoutExtension(telemetryFileName);

            var timestampStartIndex = fileName.Length - TelemetryFileNameTimestampFormat.Length;

            var underscoreIndex = fileName.IndexOf("_");

            return fileName.Substring(underscoreIndex + 1, timestampStartIndex - underscoreIndex - 2).Trim();
        }
    }
}
