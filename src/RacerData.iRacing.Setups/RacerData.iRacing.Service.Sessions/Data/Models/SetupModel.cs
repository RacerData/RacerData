using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RacerData.iRacing.Service.Sessions.Data.Models
{
    [Table("Setups")]
    class SetupModel
    {
        [Key()]
        public long Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        public string FileName { get; set; }
        [Required]
        public int Year { get; set; }
        [Required]
        public int Season { get; set; }
        [Required]
        [ForeignKey("Vehicle")]
        public long VehicleId { get; set; }
        [Required]
        public int UpdateCount { get; set; }
        public string SetupData { get; set; }
        public string ExportHtml { get; set; }

        public virtual VehicleModel Vehicle { get; set; }
        // TODO: should be 1-1, not a list
        public virtual IList<RunModel> Runs { get; set; }
    }
}
