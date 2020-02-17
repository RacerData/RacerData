using RacerData.iRacing.Sessions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RacerData.iRacing.Service.Sessions.Data.Models
{
    [Table("TireReadings")]
    class TireReadingsModel
    {
        [Key()]
        public long Id { get; set; }
        [ForeignKey("Run")]
        public long RunId { get; set; }
        [Required]
        public TirePosition Position { get; set; }
        [Required]
        public float ColdPsi { get; set; }
        [Required]
        public float HotPsi { get; set; }
        [Required]
        public float TempInner { get; set; }
        [Required]
        public float TempMiddle { get; set; }
        [Required]
        public float TempOuter { get; set; }
        [Required]
        public float WearInner { get; set; }
        [Required]
        public float WearMiddle { get; set; }
        [Required]
        public float WearOuter { get; set; }
        public virtual RunModel Run { get; set; }
    }
}
