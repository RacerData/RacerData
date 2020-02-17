using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RacerData.iRacing.Service.Sessions.Data.Models
{
    [Table("Telemetry")]
    class TelemetryModel
    {
        [Key()]
        public long Id { get; set; }
        [StringLength(255)]
        public string FileName { get; set; }
        public string FullPath { get; set; }
        public DateTime Timestamp { get; set; }
        public byte[] Data { get; set; }
    }
}
