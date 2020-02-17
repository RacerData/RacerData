using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using RacerData.iRacing.Sessions;

namespace RacerData.iRacing.Service.Sessions.Data.Models
{
    [Table("Runs")]
    class RunModel
    {
        [Key()]
        public long Id { get; set; }
        public EventType EventType { get; set; }
        [Required]
        public int LapsComplete { get; set; }
        [ForeignKey("Vehicle")]
        public long? VehicleId { get; set; }
        [ForeignKey("Track")]
        public long? TrackId { get; set; }
        [ForeignKey("Setup")]
        public long? SetupId { get; set; }
        public long TelemetryId { get; set; }
        public long DriverId { get; set; }
        public int SessionTimeId { get; set; }
        public int TrackStateId { get; set; }
        [StringLength(255)]
        public string Notes { get; set; }
        public int Year { get; set; }
        public int Season { get; set; }
        public int Week { get; set; }
        public string TimeOfDay { get; set; }
        public string Date { get; set; }
        public int SeasonId { get; set; }
        public int SeriesId { get; set; }
        public int SessionId { get; set; }
        public int SubSessionId { get; set; }
        public DateTime RunTime { get; set; }
        public int AirTemp { get; set; }
        public int TrackTemp { get; set; }
        public string TrackState { get; set; }
        public string Sky { get; set; }

        public virtual VehicleModel Vehicle { get; set; }
        public virtual TrackModel Track { get; set; }
        public virtual SetupModel Setup { get; set; }

        public virtual IList<RunSetupValueModel> SetupValues { get; set; }
        public virtual IList<TireReadingsModel> TireReadings { get; set; }
        public virtual IList<LapModel> Laps { get; set; }
    }
}
