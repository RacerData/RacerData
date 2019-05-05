using System.Threading.Tasks;
using RacerData.NascarApi.Client.Models.LapTimes;

namespace RacerData.NascarApi.LapTimes.Service.Internal
{
    interface IAwsLapTimeDataPump
    {
        Task WriteLapTimesAsync(EventVehicleLapTimes lapAverages);
    }
}