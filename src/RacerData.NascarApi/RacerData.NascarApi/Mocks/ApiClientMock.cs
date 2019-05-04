using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RacerData.NascarApi.Models;
using RacerData.NascarApi.Models.LivePitData;
using RacerData.NascarApi.Ports;

namespace RacerData.NascarApi.Client.Mocks
{
    class ApiClientMock : IApiClient
    {
        public int FileIndex { get; set; } = 0;

        public string RootDirectory { get; set; }

        private IList<string> _files = new List<string>();
        public IList<string> Files
        {
            get
            {
                if (_files.Count == 0)
                {
                    foreach (var fileName in Directory.GetFiles(RootDirectory))
                    {
                        _files.Add(fileName);
                    }
                }

                return _files;
            }
            set
            {
                _files = value;
            }
        }

        #region ctor

        public ApiClientMock()
        {

        }

        #endregion

        #region public

        public async Task<Models.LiveFeed.RootObject> GetLiveFeedAsync()
        {
            if (FileIndex >= Files.Count)
            {
                return null;
            }

            var json = File.ReadAllText(Files[FileIndex]);

            FileIndex++;

            var liveFeedData = JsonConvert.DeserializeObject<Models.LiveFeed.RootObject>(json);

            return await Task.FromResult(liveFeedData);
        }

        #region not implemented

        public Task<Models.AudioFeed.RootObject> GetAudioFeedAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<Models.EntryList.RootObject>> GetEntryListAsync(EventSettings settings)
        {
            throw new NotImplementedException();
        }

        public Task<Models.LapAverage.RootObject> GetLapAveragesAsync(EventSettings settings)
        {
            throw new NotImplementedException();
        }

        public Task<EventSettings> GetLiveEventSettingsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Models.LiveFeed.RootObject> GetLiveFeedAsync(EventSettings settings)
        {
            throw new NotImplementedException();
        }

        public Task<List<Models.LiveFlagData.RootObject>> GetLiveFlagDataAsync()
        {
            throw new NotImplementedException();
        }
        public Task<List<Models.LivePitData.RootObject>> GetLivePitDataAsync(EventSettings settings)
        {
            throw new NotImplementedException();
        }

        public Task<List<Models.LivePoints.RootObject>> GetLivePointsAsync()
        {
            throw new NotImplementedException();
        }
        public Task<List<Models.LivePoints.RootObject>> GetLivePointsAsync(EventSettings settings)
        {
            throw new NotImplementedException();
        }

        public Task<List<Models.LiveQualifyingData.RootObject>> GetLiveQualifyingDataAsync()
        {
            throw new NotImplementedException();
        }
        public Task<List<Models.LiveQualifyingData.RootObject>> GetLiveQualifyingDataAsync(EventSettings settings)
        {
            throw new NotImplementedException();
        }

        public Task<List<Models.PointStandings.RootObject>> GetPointsStandingsAsync(EventSettings settings)
        {
            throw new NotImplementedException();
        }

        public Task<List<Models.QualifyingResults.RootObject>> GetQualifyingResultsAsync(EventSettings settings)
        {
            throw new NotImplementedException();
        }

        public Task<List<Models.RaceResults.RootObject>> GetRaceResultsAsync(EventSettings settings)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetRawJsonAsync(string url)
        {
            throw new NotImplementedException();
        }

        public Task<Models.StageFeed.RootObject> GetStageFeedAsync(EventSettings settings)
        {
            throw new NotImplementedException();
        }

        public Task<List<RootObject>> GetLivePitDataAsync()
        {
            throw new NotImplementedException();
        }

        #endregion

        #endregion
    }
}
