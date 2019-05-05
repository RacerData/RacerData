﻿using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using RacerData.NascarApi.Models;
using RacerData.NascarApi.Models.LiveFlagData;
using RacerData.NascarApi.Models.LivePitData;
using RacerData.NascarApi.Models.LivePoints;
using RacerData.NascarApi.Models.LiveQualifyingData;
using RacerData.NascarApi.Models.PointStandings;
using RacerData.NascarApi.Models.RaceResults;
using RacerData.NascarApi.Ports;
using RestSharp;

namespace RacerData.NascarApi.Adapters
{
    public class ApiClient : IApiClient
    {
        #region fields

        private readonly IUrlService _urlService;

        #endregion

        #region ctor

        public ApiClient(IUrlService urlService)
        {
            _urlService = urlService ?? throw new ArgumentNullException(nameof(urlService));
        }

        #endregion

        #region public

        public async Task<EventSettings> GetLiveEventSettingsAsync()
        {
            EventSettings liveEvent = new EventSettings();

            var feed = await GetLiveFeedAsync();

            if (feed != null)
            {
                liveEvent.season = DateTime.Now.Year;
                liveEvent.series_id = feed.series_id;
                liveEvent.race_id = feed.race_id;
                liveEvent.run_id = feed.run_id;
                liveEvent.run_type = feed.run_type;
                liveEvent.run_name = feed.run_name;
                liveEvent.track_id = feed.track_id;
                liveEvent.track_length = feed.track_length;
            }

            return liveEvent;
        }

        public async Task<Models.LiveFeed.RootObject> GetLiveFeedAsync(CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested)
                return await Task.FromCanceled<Models.LiveFeed.RootObject>(cancellationToken);
            else
                return await GetLiveFeedAsync();
        }
        public async Task<Models.LiveFeed.RootObject> GetLiveFeedAsync()
        {
            var url = _urlService.GetLiveFeedUrl();

            return await GetDataAsync<Models.LiveFeed.RootObject>(url);
        }
        public async Task<Models.LiveFeed.RootObject> GetLiveFeedAsync(EventSettings settings)
        {
            var url = _urlService.GetLiveFeedUrl(settings);

            return await GetDataAsync<Models.LiveFeed.RootObject>(url);
        }

        public async Task<Models.LapAverage.RootObject> GetLapAveragesAsync(CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested)
                return await Task.FromCanceled<Models.LapAverage.RootObject>(cancellationToken);
            else
            {
                return await GetLapAveragesAsync();
            }
        }
        public async Task<Models.LapAverage.RootObject> GetLapAveragesAsync()
        {
            var settings = await GetLiveEventSettingsAsync();

            return await GetLapAveragesAsync(settings);
        }
        public async Task<Models.LapAverage.RootObject> GetLapAveragesAsync(EventSettings settings)
        {
            var url = _urlService.GetLapAverageUrl(settings);

            return await GetDataAsync<Models.LapAverage.RootObject>(url);
        }

        public async Task<List<Models.LiveFlagData.RootObject>> GetLiveFlagDataAsync(CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested)
                return await Task.FromCanceled<List<Models.LiveFlagData.RootObject>>(cancellationToken);
            else
            {
                return await GetLiveFlagDataAsync();
            }
        }
        public async Task<List<Models.LiveFlagData.RootObject>> GetLiveFlagDataAsync()
        {
            var url = _urlService.GetLiveFlagDataUrl();

            return await GetDataAsync<List<Models.LiveFlagData.RootObject>>(url);
        }

        public async Task<List<Models.LivePitData.RootObject>> GetLivePitDataAsync(CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested)
                return await Task.FromCanceled<List<Models.LivePitData.RootObject>>(cancellationToken);
            else
            {
                return await GetLivePitDataAsync();
            }
        }
        public async Task<List<Models.LivePitData.RootObject>> GetLivePitDataAsync()
        {
            var settings = await GetLiveEventSettingsAsync();

            return await GetLivePitDataAsync(settings);
        }
        public async Task<List<Models.LivePitData.RootObject>> GetLivePitDataAsync(EventSettings settings)
        {
            var url = _urlService.GetLivePitDataUrl(settings);

            return await GetDataAsync<List<Models.LivePitData.RootObject>>(url);
        }

        public async Task<List<Models.LivePoints.RootObject>> GetLivePointsAsync(CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested)
                return await Task.FromCanceled<List<Models.LivePoints.RootObject>>(cancellationToken);
            else
            {
                return await GetLivePointsAsync();
            }
        }
        public async Task<List<Models.LivePoints.RootObject>> GetLivePointsAsync()
        {
            var settings = await GetLiveEventSettingsAsync();

            return await GetLivePointsAsync(settings);
        }
        public async Task<List<Models.LivePoints.RootObject>> GetLivePointsAsync(EventSettings settings)
        {
            var url = _urlService.GetLivePointsUrl(settings);

            return await GetDataAsync<List<Models.LivePoints.RootObject>>(url);
        }

        public async Task<List<Models.LiveQualifyingData.RootObject>> GetLiveQualifyingDataAsync(CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested)
                return await Task.FromCanceled<List<Models.LiveQualifyingData.RootObject>>(cancellationToken);
            else
            {
                return await GetLiveQualifyingDataAsync();
            }
        }
        public async Task<List<Models.LiveQualifyingData.RootObject>> GetLiveQualifyingDataAsync()
        {
            var settings = await GetLiveEventSettingsAsync();

            return await GetLiveQualifyingDataAsync(settings);
        }
        public async Task<List<Models.LiveQualifyingData.RootObject>> GetLiveQualifyingDataAsync(EventSettings settings)
        {
            var url = _urlService.GetLiveQualifyingDataUrl(settings);

            return await GetDataAsync<List<Models.LiveQualifyingData.RootObject>>(url);
        }


        public async Task<List<Models.EntryList.RootObject>> GetEntryListAsync(EventSettings settings)
        {
            var url = _urlService.GetEntryListUrl(settings);

            return await GetDataAsync<List<Models.EntryList.RootObject>>(url);
        }

        public async Task<List<Models.PointStandings.RootObject>> GetPointsStandingsAsync(EventSettings settings)
        {
            var url = _urlService.GetPointStandingsUrl(settings);

            return await GetDataAsync<List<Models.PointStandings.RootObject>>(url);
        }

        public async Task<List<Models.RaceResults.RootObject>> GetRaceResultsAsync(EventSettings settings)
        {
            var url = _urlService.GetRaceResultsUrl(settings);

            return await GetDataAsync<List<Models.RaceResults.RootObject>>(url);
        }

        public async Task<List<Models.QualifyingResults.RootObject>> GetQualifyingResultsAsync(EventSettings settings)
        {
            var url = _urlService.GetQualifyingResultsUrl(settings);

            return await GetDataAsync<List<Models.QualifyingResults.RootObject>>(url);
        }

        public async Task<Models.AudioFeed.RootObject> GetAudioFeedAsync()
        {
            var url = _urlService.GetAudioFeedUrl();

            return await GetDataAsync<Models.AudioFeed.RootObject>(url);
        }

        public async Task<Models.StageFeed.RootObject> GetStageFeedAsync(EventSettings settings)
        {
            var url = _urlService.GetStageFeedUrl(settings);

            return await GetDataAsync<Models.StageFeed.RootObject>(url);
        }

        public async Task<string> GetRawJsonAsync(string url)
        {
            var client = new RestClient(url);

            IRestResponse response = await client.ExecuteTaskAsync(new RestRequest());

            return response.Content;
        }

        #endregion

        #region protected

        protected virtual async Task<T> GetDataAsync<T>(string url) where T : class, new()
        {
            var client = new RestClient(url);

            var response = await client.ExecuteTaskAsync<T>(new RestRequest());

            return response.Data;
        }

        #endregion
    }
}
