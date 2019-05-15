using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace RacerData.NascarApi.Client.Models.LiveFeed
{
    public class Vehicle
    {
        public int BestLap { get; set; }
        public double BestLapSpeed { get; set; }
        public double BestLapTime { get; set; }
        [Newtonsoft.Json.JsonIgnore()]
        public System.TimeSpan BestLapTimeTimeTimeSpan
        {
            get
            {
                return System.TimeSpan.FromSeconds(BestLapTime);
            }
        }
        public string Manufacturer { get; set; }
        public string CarNumber { get; set; }
        public Driver Driver { get; set; }
        public double VehicleElapsedTime { get; set; }
        [Newtonsoft.Json.JsonIgnore()]
        public System.TimeSpan VehicleElapsedTimeTimeSpan
        {
            get
            {
                return System.TimeSpan.FromSeconds(VehicleElapsedTime);
            }
        }
        public int LapsCompleted { get; set; }
        public List<LapsLed> LapsLed { get; set; }
        public double LastLapSpeed { get; set; }
        public double LastLapTime { get; set; }
        [Newtonsoft.Json.JsonIgnore()]
        public System.TimeSpan LastLapTimeTimeSpan
        {
            get
            {
                return System.TimeSpan.FromSeconds(LastLapTime);
            }
        }
        public List<PitStop> PitStops { get; set; }
        public int RunningPosition { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public VehicleStatus Status { get; set; }
        public double Delta { get; set; }
        [Newtonsoft.Json.JsonIgnore()]
        public System.TimeSpan DeltaTimeSpan
        {
            get
            {
                return System.TimeSpan.FromSeconds(Delta);
            }
        }
        public string Sponsor { get; set; }
        public int StartingPosition { get; set; }
        public bool IsOnTrack { get; set; }

        public override string ToString()
        {
            return $"[{CarNumber}] {Driver.ToString()}";
        }
    }
}
