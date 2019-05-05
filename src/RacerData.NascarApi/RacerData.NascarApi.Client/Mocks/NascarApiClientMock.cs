using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using RacerData.Commmon.Results;
using RacerData.Common.Results;
using RacerData.NascarApi.Client.Models.LapAverages;
using RacerData.NascarApi.Client.Models.LiveFeed;
using RacerData.NascarApi.Client.Models.LiveFlag;
using RacerData.NascarApi.Client.Models.LivePit;
using RacerData.NascarApi.Client.Models.LivePoints;
using RacerData.NascarApi.Client.Models.LiveQualifying;
using RacerData.NascarApi.Client.Ports;
using RacerData.NascarApi.Factories;
using RacerData.NascarApi.Ports;

namespace RacerData.NascarApi.Client.Mocks
{
    class NascarApiClientMock : INascarApiClient
    {
        #region fields

        private readonly IApiClient _apiClient;
        private readonly IResultFactory<INascarApiClient> _resultFactory;
        private readonly IMapper _mapper;

        #endregion

        #region ctor

        public NascarApiClientMock(
            string directoryName,
            IApiClientFactory apiClientFactory,
            IResultFactory<INascarApiClient> resultFactory,
            IMapper mapper)
        {
            if (apiClientFactory == null)
                throw new ArgumentNullException(nameof(apiClientFactory));
            _apiClient = apiClientFactory.GetMockNascarApiClient(directoryName);

            _resultFactory = resultFactory ?? throw new ArgumentNullException(nameof(resultFactory));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public NascarApiClientMock(
         IList<string> files,
         IApiClientFactory apiClientFactory,
         IResultFactory<INascarApiClient> resultFactory,
         IMapper mapper)
        {
            if (apiClientFactory == null)
                throw new ArgumentNullException(nameof(apiClientFactory));
            _apiClient = apiClientFactory.GetMockNascarApiClient(files);

            _resultFactory = resultFactory ?? throw new ArgumentNullException(nameof(resultFactory));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
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
                var feed = await _apiClient.GetLiveFeedAsync();

                var mapped = _mapper.Map<LiveFeedData>(feed);

                return _resultFactory.Success(mapped);
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
