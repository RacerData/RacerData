using System.Collections.Generic;

namespace RacerData.iRacing.Sessions.Models
{
    public class Setup
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string FileName { get; set; }
        public int Year { get; set; }
        public int Season { get; set; }
        public long VehicleId { get; set; }
        public int UpdateCount { get; set; }
        public string SetupData { get; set; }
        public string ExportHtml { get; set; }

        public virtual Vehicle Vehicle { get; set; }
        public virtual Run Run { get; set; }

        public virtual IList<SetupProperty> SetupProperties { get; set; }
    }
}
