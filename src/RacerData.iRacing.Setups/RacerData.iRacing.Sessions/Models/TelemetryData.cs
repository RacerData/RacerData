using System;

namespace RacerData.iRacing.Sessions.Models
{
    public class TelemetryData
    {
        public long Id { get; set; }
        public string FileName { get; set; }
        public string FullPath { get; set; }
        public DateTime Timestamp { get; set; }
        public byte[] Data { get; set; }
    }
}
