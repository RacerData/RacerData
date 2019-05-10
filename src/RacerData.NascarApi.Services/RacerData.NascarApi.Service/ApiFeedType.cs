using System;

namespace RacerData.NascarApi.Service
{
    [Flags()]
    public enum ApiFeedType
    {
        None = 0,
        LiveFeedData = 1,
        LiveFlagData = 1 << 1,
        LivePitData = 1 << 2,
        LivePointsData = 1 << 3,
        LiveQualifyingData = 1 << 4,
        LapTimeData = 1 << 5,
        LapAverageData = 1 << 6,
        All = LiveFeedData |
            LiveFlagData |
            LivePitData |
            LivePointsData |
            LiveQualifyingData |
            LapTimeData |
            LapAverageData
    }
}
