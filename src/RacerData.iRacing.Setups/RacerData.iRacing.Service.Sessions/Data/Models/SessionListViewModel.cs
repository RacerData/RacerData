using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace RacerData.iRacing.Service.Sessions.Data.Models
{
    class SessionListViewModel
    {
        public int SessionIndex { get; set; }
        public long RunIndex { get; set; }
        [ForeignKey("Run")]
        public long RunId { get; set; }
        public long? PreviousRunId { get; set; }
        public long? SetupId { get; set; }
        public long? PreviousSetupId { get; set; }
        public long TelemetryId { get; set; }
        public long? PreviousTelemetryId { get; set; }
        public string Vehicle { get; set; }
        public string Track { get; set; }
        public string EventType { get; set; }
        public string SessionType { get; set; }
        public int LapCount { get; set; }
        public Double LapAverage { get; set; }
        public Single BestLap { get; set; }
        public Double StdDev { get; set; }
        public int AirTemp { get; set; }
        public int TrackTemp { get; set; }
        public string TrackState { get; set; }
        public string Sky { get; set; }
        public int Year { get; set; }
        public int Season { get; set; }
        public int Week { get; set; }
        public DateTime RunTime { get; set; }
    }
}
