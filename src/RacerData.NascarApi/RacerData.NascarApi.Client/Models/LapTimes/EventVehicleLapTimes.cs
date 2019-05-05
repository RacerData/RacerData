using System.Collections.Generic;

namespace RacerData.NascarApi.Client.Models.LapTimes
{
    public class EventVehicleLapTimes
    {
        #region properties

        public int RaceId { get; set; }
        public int SeriesId { get; set; }
        public int RunId { get; set; }
        public string TrackName { get; set; }
        public string RunName { get; set; }
        public int Elapsed { get; set; }

        public IList<VehicleLapTime> VehicleLapTimes { get; set; }

        #endregion

        #region ctor

        public EventVehicleLapTimes()
        {
            VehicleLapTimes = new List<VehicleLapTime>();
        }

        #endregion
    }
}
