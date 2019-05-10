using System;
using System.Collections.Generic;
using RacerData.NascarApi.Client.Models.LivePoints;

namespace RacerData.NascarApi.Service
{
    public class LivePointsDataUpdatedEventArgs : EventArgs
    {
        public ApiFeedType ApiFeedType { get => ApiFeedType.LivePointsData; }
        public IEnumerable<LivePointsData> Data { get; set; }
    }
}
