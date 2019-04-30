using System.Threading.Tasks;
using RacerData.Common.Results;
using RacerData.NascarApi.Client.Models.LapAverages;
using RacerData.NascarApi.Client.Models.LiveFeed;
using RacerData.NascarApi.Client.Models.LiveFlag;
using RacerData.NascarApi.Client.Models.LivePit;

namespace RacerData.NascarApi.Client.Ports
{
    public interface INascarApiClient
    {
        Task<IResult<LiveFeedData>> GetLiveFeedDataAsync();
        Task<IResult<LiveFlagData>> GetLiveFlagDataAsync();
        Task<IResult<LivePitData>> GetLivePitDataAsync();
        Task<IResult<EventVehicleLapAverages>> GetLapAverageDataAsync();
    }
}
