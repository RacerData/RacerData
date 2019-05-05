using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using RacerData.NascarApi.Models;

namespace RacerData.NascarApi.Ports
{
    public interface IApiClient
    {

        Task<EventSettings> GetLiveEventSettingsAsync();

        Task<Models.LapAverage.RootObject> GetLapAveragesAsync();
        Task<Models.LapAverage.RootObject> GetLapAveragesAsync(EventSettings settings);
        Task<Models.LapAverage.RootObject> GetLapAveragesAsync(CancellationToken cancellationToken);

        Task<Models.LiveFeed.RootObject> GetLiveFeedAsync();
        Task<Models.LiveFeed.RootObject> GetLiveFeedAsync(EventSettings settings);
        Task<Models.LiveFeed.RootObject> GetLiveFeedAsync(CancellationToken cancellationToken);

        Task<List<Models.LiveFlagData.RootObject>> GetLiveFlagDataAsync();
        Task<List<Models.LiveFlagData.RootObject>> GetLiveFlagDataAsync(CancellationToken cancellationToken);
        
        Task<List<Models.LivePitData.RootObject>> GetLivePitDataAsync();
        Task<List<Models.LivePitData.RootObject>> GetLivePitDataAsync(EventSettings settings);
        Task<List<Models.LivePitData.RootObject>> GetLivePitDataAsync(CancellationToken cancellationToken);
        
        Task<List<Models.LivePoints.RootObject>> GetLivePointsAsync();
        Task<List<Models.LivePoints.RootObject>> GetLivePointsAsync(EventSettings settings);
        Task<List<Models.LivePoints.RootObject>> GetLivePointsAsync(CancellationToken cancellationToken);

        Task<List<Models.LiveQualifyingData.RootObject>> GetLiveQualifyingDataAsync();
        Task<List<Models.LiveQualifyingData.RootObject>> GetLiveQualifyingDataAsync(EventSettings settings);
        Task<List<Models.LiveQualifyingData.RootObject>> GetLiveQualifyingDataAsync(CancellationToken cancellationToken);

        Task<List<Models.EntryList.RootObject>> GetEntryListAsync(EventSettings settings);
        Task<List<Models.PointStandings.RootObject>> GetPointsStandingsAsync(EventSettings settings);
        Task<List<Models.RaceResults.RootObject>> GetRaceResultsAsync(EventSettings settings);
        Task<List<Models.QualifyingResults.RootObject>> GetQualifyingResultsAsync(EventSettings settings);
        Task<Models.AudioFeed.RootObject> GetAudioFeedAsync();
        Task<Models.StageFeed.RootObject> GetStageFeedAsync(EventSettings settings);
        
        Task<string> GetRawJsonAsync(string url);

    }
}