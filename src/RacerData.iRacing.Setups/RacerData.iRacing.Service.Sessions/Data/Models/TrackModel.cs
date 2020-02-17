using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RacerData.iRacing.Service.Sessions.Data.Models
{
    [Table("Tracks")]
    class TrackModel
    {
        [Key()]
        public long Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [StringLength(100)]
        public string DisplayName { get; set; }
        [StringLength(100)]
        public string DisplayShortName { get; set; }
        [Required]
        public float Length { get; set; }
        public int Banking { get; set; }
        [StringLength(50)]
        public string TrackType { get; set; }
        [StringLength(50)]
        public string ConfigName { get; set; }
    }
}
