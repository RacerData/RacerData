using System;

namespace RacerData.iRacing.Sessions.Models
{
    public class TelemetryFileInfo
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string FullPath { get; set; }
        public long Size { get; set; }
        public int Year { get; set; }
        public int Season { get; set; }
        public int Week { get; set; }
        public string TimeOfDay { get; set; }
        public string Date { get; set; }
        public int ActiveSessionIndex { get; set; }
        public int SeasonId { get; set; }
        public int SeriesId { get; set; }
        public int SessionId { get; set; }
        public int LapsCompleted { get; set; }
        public int SubSessionId { get; set; }
        public EventType EventType { get; set; }
        public SessionType SessionType { get; set; }
        public DateTime Timestamp { get; set; }
        public long TrackId { get; set; }
        public string Track { get; set; }
        public long VehicleId { get; set; }
        public string Vehicle { get; set; }
        public string Comments { get; set; }
        public bool HasError
        {
            get
            {
                return Error != null || !String.IsNullOrEmpty(Comments);
            }
        }
        public Exception Error { get; set; }
        public bool IsProcessed { get; set; }
    }
}
