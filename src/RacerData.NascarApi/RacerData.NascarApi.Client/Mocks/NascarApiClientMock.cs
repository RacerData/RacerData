using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RacerData.Commmon.Results;
using RacerData.Common.Results;
using RacerData.NascarApi.Client.Models.LapAverages;
using RacerData.NascarApi.Client.Models.LiveFeed;
using RacerData.NascarApi.Client.Models.LiveFlag;
using RacerData.NascarApi.Client.Models.LivePit;
using RacerData.NascarApi.Client.Models.LivePoints;
using RacerData.NascarApi.Client.Models.LiveQualifying;
using RacerData.NascarApi.Client.Ports;

namespace RacerData.NascarApi.Client.Mocks
{
    class NascarApiClientMock : INascarApiClient
    {
        #region fields

        private IList<LiveFeedData> _data = new List<LiveFeedData>();

        #endregion

        #region properties

        private int _fileIndex = 0;
        public int FileIndex
        {
            get
            {
                if (_fileIndex >= _data.Count())
                {
                    _fileIndex = _data.Count() - 1;
                }

                return _fileIndex;
            }
            set
            {
                _fileIndex = value;
            }
        }
        public string SourceDirectory { get; set; }
        public IList<string> Files { get; set; } = new List<string>();
        private readonly IResultFactory<INascarApiClient> _resultFactory;

        #endregion

        #region ctor

        public NascarApiClientMock(
            string directoryName,
            IResultFactory<INascarApiClient> resultFactory)
        {
            SourceDirectory = directoryName;
            _resultFactory = resultFactory ?? throw new ArgumentNullException(nameof(resultFactory));

            foreach (var fileName in Directory.GetFiles(SourceDirectory))
            {
                Files.Add(fileName);
            }

            Initialize();
        }

        public NascarApiClientMock(
         IList<string> files,
         IResultFactory<INascarApiClient> resultFactory)
        {
            Files = files;
            _resultFactory = resultFactory ?? throw new ArgumentNullException(nameof(resultFactory));

            Initialize();
        }

        private void Initialize()
        {
            var dataBuffer = new List<LiveFeedData>();
            foreach (string fileName in Files)
            {
                var json = File.ReadAllText(fileName);
                var liveFeedData = JsonConvert.DeserializeObject<LiveFeedData>(json);
                dataBuffer.Add(liveFeedData);
            }

            _data = dataBuffer.OrderBy(d => d.Elapsed).ToList();
        }

        #endregion

        #region public

        public async Task<IResult<LiveFeedData>> GetLiveFeedDataAsync(CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested)
                return await Task.FromCanceled<IResult<LiveFeedData>>(cancellationToken);

            return await GetLiveFeedDataAsync();
        }
        public async Task<IResult<LiveFeedData>> GetLiveFeedDataAsync()
        {
            try
            {
                return await Task.FromResult(_resultFactory.Success(_data[FileIndex++]));
            }
            catch (Exception ex)
            {
                return _resultFactory.Exception<LiveFeedData>(ex);
            }
        }

        public async Task<IResult<IEnumerable<LiveFlagData>>> GetLiveFlagDataAsync(CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested)
                return await Task.FromCanceled<IResult<IEnumerable<LiveFlagData>>>(cancellationToken);

            return await GetLiveFlagDataAsync();
        }
        public Task<IResult<IEnumerable<LiveFlagData>>> GetLiveFlagDataAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<IResult<IEnumerable<LivePitData>>> GetLivePitDataAsync(CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested)
                return await Task.FromCanceled<IResult<IEnumerable<LivePitData>>>(cancellationToken);

            return await GetLivePitDataAsync();
        }
        public Task<IResult<IEnumerable<LivePitData>>> GetLivePitDataAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<IResult<IEnumerable<LivePointsData>>> GetLivePointsDataAsync(CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested)
                return await Task.FromCanceled<IResult<IEnumerable<LivePointsData>>>(cancellationToken);

            return await GetLivePointsDataAsync();
        }
        public Task<IResult<IEnumerable<LivePointsData>>> GetLivePointsDataAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<IResult<IEnumerable<LiveQualifyingData>>> GetLiveQualifyingDataAsync(CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested)
                return await Task.FromCanceled<IResult<IEnumerable<LiveQualifyingData>>>(cancellationToken);

            return await GetLiveQualifyingDataAsync();
        }
        public Task<IResult<IEnumerable<LiveQualifyingData>>> GetLiveQualifyingDataAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<IResult<EventVehicleLapAverages>> GetLapAverageDataAsync(CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested)
                return await Task.FromCanceled<IResult<EventVehicleLapAverages>>(cancellationToken);

            return await GetLapAverageDataAsync();
        }
        public Task<IResult<EventVehicleLapAverages>> GetLapAverageDataAsync()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
