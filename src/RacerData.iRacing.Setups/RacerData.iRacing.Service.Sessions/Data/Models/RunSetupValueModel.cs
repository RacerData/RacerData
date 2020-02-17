using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace RacerData.iRacing.Service.Sessions.Data.Models
{
    [Table("RunSetupValues")]
    class RunSetupValueModel
    {
        [Key()]
        [ForeignKey("Run")]
        public long RunId { get; set; }

        [Key()]
        [ForeignKey("SetupValue")]
        public long SetupValueId { get; set; }

        public virtual RunModel Run { get; set; }
        public virtual SetupValueModel SetupValue { get; set; }
    }
}
