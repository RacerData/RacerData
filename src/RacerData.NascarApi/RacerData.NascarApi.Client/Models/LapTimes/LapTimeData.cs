using System.Collections.Generic;

namespace RacerData.NascarApi.Client.Models.LapTimes
{
    public class LapTimeData
    {
        #region properties

        public int RaceId { get; set; }
        public int SeriesId { get; set; }
        public int RunId { get; set; }
        public string TrackName { get; set; }
        public string RunName { get; set; }
        public int Elapsed { get; set; }

        public List<VehicleLapTime> VehicleLapTimes { get; set; }

        #endregion

        #region ctor

        public LapTimeData()
        {
            VehicleLapTimes = new List<VehicleLapTime>();
        }

        #endregion
    }
}
