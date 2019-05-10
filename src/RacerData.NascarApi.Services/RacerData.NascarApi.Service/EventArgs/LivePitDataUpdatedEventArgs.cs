using System;
using System.Collections.Generic;
using RacerData.NascarApi.Client.Models.LivePit;

namespace RacerData.NascarApi.Service
{
    public class LivePitDataUpdatedEventArgs : EventArgs
    {
        public ApiFeedType ApiFeedType { get => ApiFeedType.LivePitData ; }
        public IEnumerable<LivePitData> Data { get; set; }
    }
}
