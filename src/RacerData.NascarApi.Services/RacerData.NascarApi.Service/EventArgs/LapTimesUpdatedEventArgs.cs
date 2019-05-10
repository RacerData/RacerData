using System;
using RacerData.NascarApi.Client.Models.LapTimes;

namespace RacerData.NascarApi.Service
{
    public class LapTimesUpdatedEventArgs : EventArgs
    {
        public ApiFeedType ApiFeedType { get => ApiFeedType.LapTimeData ; }
        public LapTimeData Data { get; set; }
    }
}
