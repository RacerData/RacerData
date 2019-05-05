using System.Collections.Generic;
using System.Linq;
using RacerData.NascarApi.Client.Models.LapTimes;

namespace RacerData.NascarApi.Client.Extensions
{
    public static class EventVehicleLapTimeExtensions
    {
        public static IEnumerable<VehicleLapTime> GetVehicleLapTimes(this EventVehicleLapTimes lapTimes, string vehicleId)
        {
            return GetVehicleLapTimes(lapTimes, new List<string>() { vehicleId });
        }

        public static IEnumerable<VehicleLapTime> GetVehicleLapTimes(this EventVehicleLapTimes lapTimes, IList<string> vehicleIds)
        {
            return lapTimes.VehicleLapTimes.Where(v => vehicleIds.Contains(v.VehicleId));
        }

        public static IEnumerable<VehicleLapTime> GetVehicleLapTimes(this EventVehicleLapTimes lapTimes, IList<string> vehicleIds, int startLap = 1, int endLap = 999)
        {
            return lapTimes.VehicleLapTimes.Where(v => vehicleIds.Contains(v.VehicleId) && v.LapNumber >= startLap && v.LapNumber <= endLap);
        }
    }
}
