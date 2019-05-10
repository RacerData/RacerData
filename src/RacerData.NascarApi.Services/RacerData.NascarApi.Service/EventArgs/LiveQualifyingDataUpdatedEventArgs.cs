using System;
using System.Collections.Generic;
using RacerData.NascarApi.Client.Models.LiveQualifying;

namespace RacerData.NascarApi.Service
{
    public class LiveQualifyingDataUpdatedEventArgs : EventArgs
    {
        public ApiFeedType ApiFeedType { get => ApiFeedType.LiveQualifyingData; }
        public IEnumerable<LiveQualifyingData> Data { get; set; }
    }
}
