using System.Collections.Generic;

namespace RacerData.iRacing.Sessions.Models
{
    public class Vehicle
    {
        public long Id { get; set; }
        public string ScreenName { get; set; }
        public string ScreenNameShort { get; set; }
        public string ClassShortName { get; set; }
        public string Path { get; set; }

        public virtual IList<Setup> Setups { get; set; }
    }
}
