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
using RacerData.NascarApi.Client.Models.LivePoints;
using RacerData.NascarApi.Client.Models.LiveQualifying;
using RacerData.NascarApi.Client.Ports;
using RacerData.NascarApi.Ports;

namespace RacerData.NascarApi.Client.Adapters
{
    class NascarApiClient : INascarApiClient
    {
        #region fields

        private readonly IApiClient _apiClient;
        private readonly IResultFactory<NascarApiClient> _resultFactory;
        private readonly IMapper _mapper;

        #endregion

        #region ctor

        public NascarApiClient(
            IApiClient apiClient,
            IResultFactory<NascarApiClient> resultFactory,
            IMapper mapper)
        {
            _apiClient = apiClient ?? throw new ArgumentNullException(nameof(apiClient));
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

        public async Task<IResult<IEnumerable<LiveFlagData>>> GetLiveFlagDataAsync()
        {
            try
            {
                var data = await _apiClient.GetLiveFlagDataAsync();

                var mapped = _mapper.Map<IEnumerable<LiveFlagData>>(data);

                return _resultFactory.Success(mapped);
            }
            catch (Exception ex)
            {
                return _resultFactory.Exception<IEnumerable<LiveFlagData>>(ex);
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

        public async Task<IResult<IEnumerable<LivePointsData>>> GetLivePointsDataAsync()
        {
            try
            {
                var data = await _apiClient.GetLivePointsAsync();

                var mapped = _mapper.Map<IEnumerable<LivePointsData>>(data);

                return _resultFactory.Success(mapped);
            }
            catch (Exception ex)
            {
                return _resultFactory.Exception<IEnumerable<LivePointsData>>(ex);
            }
        }

        public async Task<IResult<IEnumerable<LiveQualifyingData>>> GetLiveQualifyingDataAsync()
        {
            try
            {
                var data = await _apiClient.GetLiveQualifyingDataAsync();

                var mapped = _mapper.Map<IEnumerable<LiveQualifyingData>>(data);

                return _resultFactory.Success(mapped);
            }
            catch (Exception ex)
            {
                return _resultFactory.Exception<IEnumerable<LiveQualifyingData>>(ex);
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
