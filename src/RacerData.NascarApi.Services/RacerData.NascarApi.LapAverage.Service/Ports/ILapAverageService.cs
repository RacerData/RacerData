using System.Collections.Generic;
using RacerData.NascarApi.Client.Models.LapAverages;
using RacerData.NascarApi.Client.Models.LiveFeed;

namespace RacerData.NascarApi.LapAverage.Service.Ports
{
    public interface ILapAverageService
    {
        IList<VehicleNLapAverage> GetBestLapAverages(int targetLapCount);
        IList<VehicleNLapAverage> GetLastLapAverages(int targetLapCount);
        void ParseVehicleLapData(LiveFeedData data);
        IEnumerable<VehicleLap> VehicleLaps(string carNumber);
    }
}