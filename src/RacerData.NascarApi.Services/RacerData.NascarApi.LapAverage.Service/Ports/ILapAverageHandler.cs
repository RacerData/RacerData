using System;
using RacerData.NascarApi.Service;
using RacerData.NascarApi.Service.Ports;

namespace RacerData.NascarApi.LapAverage.Service.Ports
{
    public interface ILapAverageHandler : IMonitorClient
    {
        event EventHandler<LapAveragesUpdatedEventArgs> LapAveragesUpdated;
    }
}