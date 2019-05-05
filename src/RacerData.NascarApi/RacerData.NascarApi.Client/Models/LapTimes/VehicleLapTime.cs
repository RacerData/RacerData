using System;
using System.Collections.Generic;
using System.Text;

namespace RacerData.NascarApi.Client.Models.LapTimes
{
    public class VehicleLapTime
    {
        #region properties

        public string VehicleId { get; set; }
        public int LapNumber { get; set; }
        public double LapTime { get; set; }
        public TrackState TrackState { get; set; }
        public VehicleStatus VehicleStatus { get; set; }
        public int EventElapsed { get; set; }
        public double VehicleElapsed { get; set; }

        #endregion

        #region public

        public override string ToString()
        {
            return $"[{VehicleId}] {LapNumber} {LapTime}";
        }

        #endregion
    }
}
