using System;
using System.Collections.Generic;

namespace RacerData.iRacing.Sessions.Models
{
    /// <summary>
    /// One instance of driving a set of laps dusing a session group
    /// </summary>
    public class Run
    {
        public long Id { get; set; }
        public int LapsComplete { get; set; }
        public long? VehicleId { get; set; }
        public long? TrackId { get; set; }
        public long? SetupId { get; set; }
        public long TelemetryId { get; set; }
        public long DriverId { get; set; }
        public int Year { get; set; }
        public int Season { get; set; }
        public int Week { get; set; }
        public string TimeOfDay { get; set; }
        public int SessionTimeId { get; set; }
        public int TrackStateId { get; set; }
        public string Date { get; set; }
        public int SeasonId { get; set; }
        public int SeriesId { get; set; }
        public int SessionId { get; set; }
        public int SubSessionId { get; set; }
        public EventType EventType { get; set; }
        public int AirTemp { get; set; }
        public int TrackTemp { get; set; }
        public string TrackState { get; set; }
        public string Sky { get; set; }
        public string Notes { get; set; }
        public DateTime RunTime { get; set; }

        public TireSheet TireSheet { get; set; } = new TireSheet();

        public virtual IList<SetupValue> SetupValues { get; set; }
        public IList<Lap> Laps { get; set; } = new List<Lap>();
    }
}
