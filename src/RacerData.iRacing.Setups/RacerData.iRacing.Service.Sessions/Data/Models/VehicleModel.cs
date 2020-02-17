using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RacerData.iRacing.Service.Sessions.Data.Models
{
    [Table("Vehicles")]
    class VehicleModel
    {
        [Key()]
        public long Id { get; set; }
        [Required]
        [StringLength(50)]
        public string ScreenName { get; set; }
        [StringLength(50)]
        public string ScreenNameShort { get; set; }
        [StringLength(50)]
        public string ClassShortName { get; set; }
        [StringLength(50)]
        public string Path { get; set; }

        public virtual IList<SetupModel> Setups { get; set; }
        public virtual IList<RunModel> Runs { get; set; }
    }
}
