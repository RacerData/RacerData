using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace RacerData.NascarApi.Client.Models.LiveFlag
{
    public class LiveFlagData
    {
        public int LapNumber { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public TrackState FlagState { get; set; }
        public double ElapsedTime { get; set; }
        public string Comment { get; set; }
        public string Beneficiary { get; set; }
        public TimeSpan TimeOfDay { get; set; }
    }
}
