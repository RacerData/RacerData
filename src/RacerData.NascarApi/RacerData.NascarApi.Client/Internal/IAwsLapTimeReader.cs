using System.Threading.Tasks;
using RacerData.NascarApi.Client.Models.LapTimes;
using RacerData.NascarApi.Client.Models.LiveFeed;

namespace RacerData.NascarApi.Client.Internal
{
    interface IAwsLapTimeReader
    {
        Task<EventVehicleLapTimes> ReadLapTimesAsync(LiveFeedData data);
    }
}