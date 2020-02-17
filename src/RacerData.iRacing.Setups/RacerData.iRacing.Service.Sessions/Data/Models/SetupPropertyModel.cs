using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RacerData.iRacing.Service.Sessions.Data.Models
{
    [Table("SetupProperties")]
    class SetupPropertyModel
    {
        [Key(), DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]
        public int Version { get; set; } = 0;

        [Required]
        [ForeignKey("Path")]
        public long SetupPropertyPathId { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        public SetupSettingDataTypes DataType { get; set; }

        [StringLength(50)]
        public string Units { get; set; }

        public SetupPropertyPathModel Path { get; set; }
    }
}
