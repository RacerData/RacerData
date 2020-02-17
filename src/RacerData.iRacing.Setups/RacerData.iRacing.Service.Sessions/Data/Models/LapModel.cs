using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RacerData.iRacing.Service.Sessions.Data.Models
{
    [Table("Laps")]
    class LapModel
    {
        [Key()]
        public long Id { get; set; }
        [ForeignKey("Run")]
        public long RunId { get; set; }
        [Required]
        public int LapNumber { get; set; }
        [Required]
        public int OverallLapNumber { get; set; }
        [Required]
        public float LapTime { get; set; }
        public float LapSpeed { get; set; }
        [Required]
        public bool IsValid { get; set; }

        public virtual RunModel Run { get; set; }
    }
}
