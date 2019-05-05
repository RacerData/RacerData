using System;
using RacerData.NascarApi.Client.Models.LapTimes;

namespace RacerData.NascarApi.LapTimes.Service.Models
{
    public class LapTimesUpdatedEventArgs : EventArgs
    {
        public EventVehicleLapTimes LapTimes { get; set; }
    }
}
