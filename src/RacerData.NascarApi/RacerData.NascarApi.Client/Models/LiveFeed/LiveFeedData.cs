using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace RacerData.NascarApi.Client.Models.LiveFeed
{
    public class LiveFeedData
    {
        public int LapNumber { get; set; }
        public int Elapsed { get; set; }
        [JsonIgnore()]
        public TimeSpan ElapsedTimeSpan
        {
            get
            {
                return TimeSpan.FromSeconds(Elapsed);
            }
        }
        [JsonConverter(typeof(StringEnumConverter))]
        public TrackState FlagState { get; set; }
        public int RaceId { get; set; }
        public int LapsInRace { get; set; }
        public int LapsToGo { get; set; }
        public List<Vehicle> Vehicles { get; set; }
        public int RunId { get; set; }
        public string RunName { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public SeriesType SeriesType { get; set; }
        public DateTime TimeOfDay { get; set; }
        public int TrackId { get; set; }
        public double TrackLength { get; set; }
        public string TrackName { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public RunType RunType { get; set; }
        public int NumberOfCautions { get; set; }
        public int NumberOfCautionLaps { get; set; }
        public int NumberOfLeadChanges { get; set; }
        public int NumberOfLeaders { get; set; }
        public Stage Stage { get; set; }

        public LiveFeedData()
        {
            Vehicles = new List<Vehicle>();
        }
    }
}
