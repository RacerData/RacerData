﻿using RacerData.NascarApi.Client.Models.LapTimes;

namespace RacerData.NascarApi.LapTimes.Service.Internal
{
    interface ILapTimeDataFileWriter
    {
        int? LastElapsedWritten { get; set; }
        string RootDirectory { get; set; }

        void WriteFile(EventVehicleLapTimes data);
        void WriteFile(string rootDirectory, EventVehicleLapTimes data);
    }
}