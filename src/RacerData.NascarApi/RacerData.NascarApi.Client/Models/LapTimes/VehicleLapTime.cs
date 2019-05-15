using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace RacerData.NascarApi.Client.Models.LapTimes
{
    public class VehicleLapTime
    {
        #region properties

        public string VehicleId { get; set; }
        public int LapNumber { get; set; }
        public double LapTime { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public TrackState TrackState { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public VehicleStatus VehicleStatus { get; set; }
        public int EventElapsed { get; set; }
        [JsonIgnore()]
        public System.TimeSpan EventElapsedTimeSpan
        {
            get
            {
                return new System.TimeSpan(0, 0, EventElapsed);
            }
        }
        public double VehicleElapsed { get; set; }
        [JsonIgnore()]
        public System.TimeSpan VehicleElapsedTimeSpan
        {
            get
            {
                return System.TimeSpan.FromSeconds(VehicleElapsed);
            }
        }

        #endregion

        #region public

        public override string ToString()
        {
            return $"[{VehicleId}] {LapNumber} {LapTime}";
        }

        #endregion
    }
}
