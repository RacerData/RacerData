using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using RacerData.Commmon.Results;
using RacerData.Common.Results;
using RacerData.NascarApi.Client.Models.LapAverages;
using RacerData.NascarApi.Client.Models.LiveFeed;
using RacerData.NascarApi.Client.Models.LiveFlag;
using RacerData.NascarApi.Client.Models.LivePit;
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

        public async Task<IResult<LiveFlagData>> GetLiveFlagDataAsync()
        {
            try
            {
                var data = await _apiClient.GetLiveFlagDataAsync();

                var mapped = _mapper.Map<LiveFlagData>(data);

                return _resultFactory.Success(mapped);
            }
            catch (Exception ex)
            {
                return _resultFactory.Exception<LiveFlagData>(ex);
            }
        }

        public async Task<IResult<LivePitData>> GetLivePitDataAsync()
        {
            try
            {
                var data = await _apiClient.GetLivePitDataAsync();

                var mapped = _mapper.Map<LivePitData>(data);

                return _resultFactory.Success(mapped);
            }
            catch (Exception ex)
            {
                return _resultFactory.Exception<LivePitData>(ex);
            }
        }

        public async Task<IResult<EventVehicleLapAverages>> GetLapAverageDataAsync()
        {
            try
            {
                throw new NotImplementedException();

                //var averages = new EventVehicleLapAverages();

                //return await Task.FromResult(_resultFactory.Success(averages));
            }
            catch (Exception ex)
            {
                return _resultFactory.Exception<EventVehicleLapAverages>(ex);
            }
        }

        #endregion
    }
}
