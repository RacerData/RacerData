using System;
using System.Drawing;
using Newtonsoft.Json;
using RacerData.NascarApi.Service;
using RacerData.rNascarApp.Models;

namespace RacerData.rNascarApp.Settings
{
    public class ViewListColumn
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

                if (DataFeed == ApiFeedType.LapAverageData.ToString())
                    feeds |= ApiFeedType.LapAverageData;
                if (DataFeed == ApiFeedType.LapTimeData.ToString())
                    feeds |= ApiFeedType.LapTimeData;
                if (DataFeed == ApiFeedType.LiveFeedData.ToString())
                    feeds |= ApiFeedType.LiveFeedData;
                if (DataFeed == ApiFeedType.LiveFlagData.ToString())
                    feeds |= ApiFeedType.LiveFlagData;
                if (DataFeed == ApiFeedType.LivePitData.ToString())
                    feeds |= ApiFeedType.LivePitData;
                if (DataFeed == ApiFeedType.LivePointsData.ToString())
                    feeds |= ApiFeedType.LivePointsData;
                if (DataFeed == ApiFeedType.LiveQualifyingData.ToString())
                    feeds |= ApiFeedType.LiveQualifyingData;

                return feeds;
            }
        }
        public string DataFeedAssemblyQualifiedName { get; set; }
        public string DataFeedFullName { get; set; }
        public string DataMember { get; set; }
        public string DataFullPath { get; set; }
        public string ConvertedType { get; set; }
        public string Type { get; set; }
        public int? Width { get; set; }
        public ContentAlignment Alignment { get; set; } = ContentAlignment.MiddleLeft;
        public string Format { get; set; }
        public string Sample { get; set; }
        public SortType SortType { get; set; }
    }
}
