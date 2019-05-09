using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using RacerData.Common.Results;
using RacerData.NascarApi.Client.Models.LapAverages;
using RacerData.NascarApi.Client.Models.LapTimes;
using RacerData.NascarApi.Client.Models.LiveFeed;
using RacerData.NascarApi.Client.Models.LiveFlag;
using RacerData.NascarApi.Client.Models.LivePit;
using RacerData.NascarApi.Client.Models.LivePoints;
using RacerData.NascarApi.Client.Models.LiveQualifying;

namespace RacerData.NascarApi.Client.Ports
{
    public interface INascarApiClient
    {
        Task<IResult<LiveFeedData>> GetLiveFeedDataAsync();
        Task<IResult<LiveFeedData>> GetLiveFeedDataAsync(CancellationToken cancellationToken);
        Task<IResult<IEnumerable<LiveFlagData>>> GetLiveFlagDataAsync(CancellationToken cancellationToken);
        Task<IResult<IEnumerable<LiveFlagData>>> GetLiveFlagDataAsync();
        Task<IResult<IEnumerable<LivePitData>>> GetLivePitDataAsync(CancellationToken cancellationToken);
        Task<IResult<IEnumerable<LivePitData>>> GetLivePitDataAsync();
        Task<IResult<IEnumerable<LivePointsData>>> GetLivePointsDataAsync(CancellationToken cancellationToken);
        Task<IResult<IEnumerable<LivePointsData>>> GetLivePointsDataAsync();
        Task<IResult<IEnumerable<LiveQualifyingData>>> GetLiveQualifyingDataAsync(CancellationToken cancellationToken);
        Task<IResult<IEnumerable<LiveQualifyingData>>> GetLiveQualifyingDataAsync();
        Task<IResult<LapAverageData>> GetLapAverageDataAsync(CancellationToken cancellationToken);
        Task<IResult<LapAverageData>> GetLapAverageDataAsync();
        Task<IResult<LapTimeData>> GetLapTimeDataAsync(CancellationToken cancellationToken);
        Task<IResult<LapTimeData>> GetLapTimeDataAsync();

    }
}
