using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RacerData.iRacing.Service.Sessions.Data.Models
{
    [Table("SessionTime")]
    class SessionTimeModel
    {
        [Key()]
        public int Id { get; set; }
        [Required()]
        [StringLength(50)]
        public string TimeOfDay { get; set; }
        [Required()]
        public TimeSpan StartTime { get; set; }
        [Required()]
        public TimeSpan EndTime { get; set; }
    }
}
