using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RacerData.iRacing.Service.Sessions.Data.Models
{
    [Table("VehicleSetupProperties")]
    class VehicleSetupPropertyModel
    {
        [Key()]
        public long VehicleId { get; set; }
        [Key()]
        public long PropList { get; set; }
    }
}
