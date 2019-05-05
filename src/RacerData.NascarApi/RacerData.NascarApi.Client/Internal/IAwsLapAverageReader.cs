using System.Threading.Tasks;
using RacerData.NascarApi.Client.Models.LapAverages;
using RacerData.NascarApi.Client.Models.LiveFeed;

namespace RacerData.NascarApi.Client.Internal
{
    interface IAwsLapAverageReader
    {
        Task<EventVehicleLapAverages> ReadLapAveragesAsync(LiveFeedData data);
    }
}