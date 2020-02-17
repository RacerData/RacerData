using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RacerData.iRacing.Service.Sessions.Data.Models
{
    [Table("Drivers")]
    class DriverModel
    {
        [Key()]
        public long Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
    }
}
