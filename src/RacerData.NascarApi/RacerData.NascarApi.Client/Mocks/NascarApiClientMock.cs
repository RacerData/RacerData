using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using RacerData.Commmon.Results;
using RacerData.Common.Results;
using RacerData.NascarApi.Client.Internal;
using RacerData.NascarApi.Client.Models.LapAverages;
using RacerData.NascarApi.Client.Models.LapTimes;
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

        private readonly IResultFactory<INascarApiClient> _resultFactory;

        private readonly MockLiveDataFeed _mockLiveDataFeed;
        private readonly MockLapTimeFeed _mockLapTimeFeed;
        private readonly MockLapAverageFeed _mockLapAverageFeed;
        private readonly MockLiveFlagDataFeed _mockFlagDataFeed;
        private readonly MockLivePitDataFeed _mockPitDataFeed;
        private readonly MockLiveQualifyingDataFeed _mockQualifyingDataFeed;
        private readonly MockLivePointsDataFeed _mockPointsDataFeed;

        #endregion

        #region ctor

        public NascarApiClientMock(
            IConfiguration configuration,
            IResultFactory<INascarApiClient> resultFactory)
        {
            _resultFactory = resultFactory ?? throw new ArgumentNullException(nameof(resultFactory));

            if (configuration == null)
                throw new ArgumentNullException(nameof(configuration));

            _mockLiveDataFeed = new MockLiveDataFeed(configuration, resultFactory);
            _mockLapTimeFeed = new MockLapTimeFeed(configuration, resultFactory);
            _mockLapAverageFeed = new MockLapAverageFeed(configuration, resultFactory);
            _mockFlagDataFeed = new MockLiveFlagDataFeed(configuration, resultFactory);
            _mockPitDataFeed = new MockLivePitDataFeed(configuration, resultFactory);
            _mockQualifyingDataFeed = new MockLiveQualifyingDataFeed(configuration, resultFactory);
            _mockPointsDataFeed = new MockLivePointsDataFeed(configuration, resultFactory);
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
                return await _mockLiveDataFeed.GetDataAsync();
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
        public async Task<IResult<IEnumerable<LiveFlagData>>> GetLiveFlagDataAsync()
        {
            try
            {
                return await _mockFlagDataFeed.GetDataAsync();
            }
            catch (Exception ex)
            {
                return _resultFactory.Exception<IEnumerable<LiveFlagData>>(ex);
            }
        }

        public async Task<IResult<IEnumerable<LivePitData>>> GetLivePitDataAsync(CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested)
                return await Task.FromCanceled<IResult<IEnumerable<LivePitData>>>(cancellationToken);

            return await GetLivePitDataAsync();
        }
        public async Task<IResult<IEnumerable<LivePitData>>> GetLivePitDataAsync()
        {
            try
            {
                return await _mockPitDataFeed.GetDataAsync();
            }
            catch (Exception ex)
            {
                return _resultFactory.Exception<IEnumerable<LivePitData>>(ex);
            }
        }

        public async Task<IResult<IEnumerable<LivePointsData>>> GetLivePointsDataAsync(CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested)
                return await Task.FromCanceled<IResult<IEnumerable<LivePointsData>>>(cancellationToken);

            return await GetLivePointsDataAsync();
        }
        public async Task<IResult<IEnumerable<LivePointsData>>> GetLivePointsDataAsync()
        {
            try
            {
                return await _mockPointsDataFeed.GetDataAsync();
            }
            catch (Exception ex)
            {
                return _resultFactory.Exception<IEnumerable<LivePointsData>>(ex);
            }
        }

        public async Task<IResult<IEnumerable<LiveQualifyingData>>> GetLiveQualifyingDataAsync(CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested)
                return await Task.FromCanceled<IResult<IEnumerable<LiveQualifyingData>>>(cancellationToken);

            return await GetLiveQualifyingDataAsync();
        }
        public async Task<IResult<IEnumerable<LiveQualifyingData>>> GetLiveQualifyingDataAsync()
        {
            try
            {
                return await _mockQualifyingDataFeed.GetDataAsync();
            }
            catch (Exception ex)
            {
                return _resultFactory.Exception<IEnumerable<LiveQualifyingData>>(ex);
            }
        }

        public async Task<IResult<LapAverageData>> GetLapAverageDataAsync(CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested)
                return await Task.FromCanceled<IResult<LapAverageData>>(cancellationToken);

            return await GetLapAverageDataAsync();
        }
        public async Task<IResult<LapAverageData>> GetLapAverageDataAsync()
        {
            try
            {
                return await _mockLapAverageFeed.GetDataAsync();
            }
            catch (Exception ex)
            {
                return _resultFactory.Exception<LapAverageData>(ex);
            }
        }

        public async Task<IResult<LapTimeData>> GetLapTimeDataAsync(CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested)
                return await Task.FromCanceled<IResult<LapTimeData>>(cancellationToken);

            return await GetLapTimeDataAsync();
        }
        public async Task<IResult<LapTimeData>> GetLapTimeDataAsync()
        {
            try
            {
                return await _mockLapTimeFeed.GetDataAsync();
            }
            catch (Exception ex)
            {
                return _resultFactory.Exception<LapTimeData>(ex);
            }
        }

        #endregion
    }
}
