using System;
using RacerData.NascarApi.Client.Models.LapAverages;

namespace RacerData.NascarApi.Service
{
    public class LapAveragesUpdatedEventArgs : EventArgs
    {
        public ApiFeedType ApiFeedType { get => ApiFeedType.LapAverageData; }
        public LapAverageData Data { get; set; }
    }
}
