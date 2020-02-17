using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using RacerData.iRacing.Sessions;

namespace RacerData.iRacing.Service.Sessions.Data.Models
{
    [Table("TelemetryFileInfo")]
    class TelemetryFileInfoModel
    {
        [Key()]
        public long Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        [Required]
        public string FullPath { get; set; }
        [Required]
        public long Size { get; set; }
        [Required]
        public int Year { get; set; }
        public int Season { get; set; }
        public int Week { get; set; }
        public string TimeOfDay { get; set; }
        public string Date { get; set; }
        [Required]
        public int SeasonId { get; set; }
        [Required]
        public int SeriesId { get; set; }
        [Required]
        public int SessionId { get; set; }
        [Required]
        public int ActiveSessionIndex { get; set; }
        [Required]
        public int LapsCompleted { get; set; }
        [Required]
        public int SubSessionId { get; set; }
        [Required]
        public EventType EventType { get; set; }
        public SessionType SessionType { get; set; }
        [Required]
        public long TrackId { get; set; }
        [Required]
        public long VehicleId { get; set; }
        [Required]
        public DateTime Timestamp { get; set; }
        [Required]
        public string Track { get; set; }
        [Required]
        public string Vehicle { get; set; }
        public string Comments { get; set; }

        public bool IsProcessed { get; set; }
    }
}
