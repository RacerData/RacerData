using System;
using RacerData.NascarApi.Client.Models.LapAverages;

namespace RacerData.NascarApi.Service
{
    public class LapAveragesUpdatedEventArgs : EventArgs
    {
        public EventVehicleLapAverages LapAverages { get; set; }
    }
}
