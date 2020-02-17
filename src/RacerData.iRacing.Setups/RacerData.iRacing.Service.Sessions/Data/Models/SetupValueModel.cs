using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RacerData.iRacing.Service.Sessions.Data.Models
{
    [Table("SetupValues")]
    class SetupValueModel
    {
        [Key(), DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]
        [ForeignKey("Property")]
        public long SetupPropertyId { get; set; }

        [Required]
        [StringLength(50)]
        public string RawValue { get; set; }

        [Required]
        public float Value { get; set; }

        public SetupPropertyModel Property { get; set; }
        public virtual IList<RunSetupValueModel> SetupValueRuns { get; set; }
    }
}
