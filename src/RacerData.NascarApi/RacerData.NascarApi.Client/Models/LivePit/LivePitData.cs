using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace RacerData.NascarApi.Client.Models.LivePit
{
    public class LivePitData
    {
        public string CarNumber { get; set; }
        public string FullName { get; set; }
        public string VehicleManufacturer { get; set; }
        public int LeaderLap { get; set; }
        public int LapCount { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public TrackState PitInFlagStatus { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public TrackState PitOutFlagStatus { get; set; }
        public double PitInRaceTime { get; set; }
        [Newtonsoft.Json.JsonIgnore()]
        public System.TimeSpan PitInRaceTimeTimeSpan
        {
            get
            {
                return System.TimeSpan.FromSeconds(PitInRaceTime);
            }
        }
        public double PitOutRaceTime { get; set; }
        [Newtonsoft.Json.JsonIgnore()]
        public System.TimeSpan PitOutRaceTimeTimeSpan
        {
            get
            {
                return System.TimeSpan.FromSeconds(PitOutRaceTime);
            }
        }
        public double TotalDuration { get; set; }
        [Newtonsoft.Json.JsonIgnore()]
        public System.TimeSpan TotalDurationTimeSpan
        {
            get
            {
                return System.TimeSpan.FromSeconds(TotalDuration);
            }
        }
        public double BoxStopRaceTime { get; set; }
        [Newtonsoft.Json.JsonIgnore()]
        public System.TimeSpan BoxStopRaceTimeTimeSpan
        {
            get
            {
                return System.TimeSpan.FromSeconds(BoxStopRaceTime);
            }
        }
        public double BoxLeaveRaceTime { get; set; }
        [Newtonsoft.Json.JsonIgnore()]
        public System.TimeSpan BoxLeaveRaceTimeTimeSpan
        {
            get
            {
                return System.TimeSpan.FromSeconds(BoxLeaveRaceTime);
            }
        }
        public double PitStopDuration { get; set; }
        [Newtonsoft.Json.JsonIgnore()]
        public System.TimeSpan PitStopDurationTimeSpan
        {
            get
            {
                return System.TimeSpan.FromSeconds(PitStopDuration);
            }
        }
        public double InTravelDuration { get; set; }
        [Newtonsoft.Json.JsonIgnore()]
        public System.TimeSpan InTravelDurationTimeSpan
        {
            get
            {
                return System.TimeSpan.FromSeconds(InTravelDuration);
            }
        }
        public double OutTravelDuration { get; set; }
        [Newtonsoft.Json.JsonIgnore()]
        public System.TimeSpan OutTravelDurationTimeSpan
        {
            get
            {
                return System.TimeSpan.FromSeconds(OutTravelDuration);
            }
        }
        public string PitStopType { get; set; }
        public bool LFTireChanged { get; set; }
        public bool LRTireChanged { get; set; }
        public bool RFTireChanged { get; set; }
        public bool RRTireChanged { get; set; }
        public int PreviousLapTime { get; set; }
        [Newtonsoft.Json.JsonIgnore()]
        public System.TimeSpan PreviousLapTimeTimeSpan
        {
            get
            {
                return System.TimeSpan.FromSeconds(PreviousLapTime);
            }
        }
        public int NextLapTime { get; set; }
        [Newtonsoft.Json.JsonIgnore()]
        public System.TimeSpan NextLapTimeTimeSpan
        {
            get
            {
                return System.TimeSpan.FromSeconds(NextLapTime);
            }
        }
    }
}
