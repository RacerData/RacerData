using System;
using System.Globalization;

namespace RacerData.iRacing.Setups.Models
{
    public abstract class SetupBase
    {
        public string SetupFileName { get; set; }
        public string TelemetryFileName { get; set; }
        public string Track { get; set; }
        public int Year { get; set; }
        public int Season { get; set; }
        public string Notes { get; set; }
        public DateTime Timestamp
        {
            get
            {
                return DateTime.ParseExact(TelemetryFileName.Substring(TelemetryFileName.Length - 23, 19), "yyyy-MM-dd HH-mm-ss", CultureInfo.InvariantCulture);
            }
        }
    }
}
