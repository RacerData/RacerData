using System;
using System.Collections.Generic;
using RacerData.NascarApi.Client.Models.LiveFlag;

namespace RacerData.NascarApi.Service
{
    public class LiveFlagDataUpdatedEventArgs : EventArgs
    {
        public ApiFeedType ApiFeedType { get => ApiFeedType.LiveFlagData; }
        public IEnumerable<LiveFlagData> Data { get; set; }
    }
}
