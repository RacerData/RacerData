using System.Collections.Generic;
using System.Linq;

namespace RacerData.WinForms.Models
{
    public class DriverLapTimesViewModel
    {
        public string Driver { get; set; }
        public int CarNumber { get; set; }
        public int Position { get; set; }
        public DriverLapTimeViewModel BestLap
        {
            get
            {
                return LapTimes.OrderBy(l => l.Time).FirstOrDefault();
            }
        }

        public IList<DriverLapTimeViewModel> LapTimes { get; set; } = new List<DriverLapTimeViewModel>();
    }
}
