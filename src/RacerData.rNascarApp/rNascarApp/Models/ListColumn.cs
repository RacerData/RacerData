using System;
using System.Drawing;
using Newtonsoft.Json;
using RacerData.NascarApi.Service;

namespace RacerData.rNascarApp.Models
{
    public class ListColumn
    {
        public int Index { get; set; }
        public string Caption { get; set; }
        public string DataFeed { get; set; }
        [JsonIgnore()]
        public ApiFeedType ApiFeedType
        {
            get
            {
                ApiFeedType feeds = ApiFeedType.None;

                if (!String.IsNullOrEmpty(DataFeed))
                {
                    var dataFeedName = DataFeed.Replace("[]", "");

                    if (dataFeedName == ApiFeedType.LapAverageData.ToString())
                        feeds |= ApiFeedType.LapAverageData;
                    if (dataFeedName == ApiFeedType.LapTimeData.ToString())
                        feeds |= ApiFeedType.LapTimeData;
                    if (dataFeedName == ApiFeedType.LiveFeedData.ToString())
                        feeds |= ApiFeedType.LiveFeedData;
                    if (dataFeedName == ApiFeedType.LiveFlagData.ToString())
                        feeds |= ApiFeedType.LiveFlagData;
                    if (dataFeedName == ApiFeedType.LivePitData.ToString())
                        feeds |= ApiFeedType.LivePitData;
                    if (dataFeedName == ApiFeedType.LivePointsData.ToString())
                        feeds |= ApiFeedType.LivePointsData;
                    if (dataFeedName == ApiFeedType.LiveQualifyingData.ToString())
                        feeds |= ApiFeedType.LiveQualifyingData;
                }

                return feeds;
            }
        }
        public string DataMember { get; set; }
        public string DataPath { get; set; }
        public string ConvertedType { get; set; }
        public string Type { get; set; }
        public int? Width { get; set; }
        public bool Fill { get; set; }
        public ContentAlignment Alignment { get; set; } = ContentAlignment.MiddleLeft;
        public string Format { get; set; }
        public string Sample { get; set; }
        public SortType SortType { get; set; }
        public int? SortOrder { get; set; }
        public bool HasBorder { get; set; } = true;

        public override string ToString()
        {
            return $"[{Index}] {Caption} {Width}";
        }
    }
}
