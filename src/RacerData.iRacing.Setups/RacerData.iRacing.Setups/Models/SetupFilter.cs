using System;

namespace RacerData.iRacing.Setups.Models
{
    public class SetupFilter
    {
        public string Track { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
