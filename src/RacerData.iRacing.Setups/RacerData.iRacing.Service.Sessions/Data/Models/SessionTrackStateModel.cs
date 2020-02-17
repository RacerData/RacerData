using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RacerData.iRacing.Service.Sessions.Data.Models
{
    [Table("SessionTrackState")]
    class SessionTrackStateModel
    {
        [Key()]
        public int Id { get; set; }
        [Required()]
        [StringLength(50)]
        public string TrackState { get; set; }
        [Required()]
        public int Min { get; set; }
        [Required()]
        public int Max { get; set; }
    }
}
