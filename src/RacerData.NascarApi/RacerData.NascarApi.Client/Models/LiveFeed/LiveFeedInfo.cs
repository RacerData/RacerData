using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace RacerData.NascarApi.Client.Models.LiveFeed
{
    public class LiveFeedInfo
    {
        #region properties

        public int Season { get; set; } = DateTime.Now.Year;
        [JsonConverter(typeof(StringEnumConverter))]
        public SeriesType Series { get; set; }
        public int RaceId { get; set; }
        public int RunId { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public RunType RunType { get; set; }
        public int TrackId { get; set; }
        public double TrackLength { get; set; }
        public string RunName { get; set; }

        #endregion
    }
}
