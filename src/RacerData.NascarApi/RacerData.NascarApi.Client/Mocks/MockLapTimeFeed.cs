using Microsoft.Extensions.Configuration;
using RacerData.Commmon.Results;
using RacerData.NascarApi.Client.Models.LapAverages;
using RacerData.NascarApi.Client.Models.LapTimes;
using RacerData.NascarApi.Client.Ports;

namespace RacerData.NascarApi.Client.Mocks
{
    class MockLapTimeFeed : MockDataFeed<LapTimeData>
    {
        #region ctor

        public MockLapTimeFeed(
            IConfiguration configuration,
            IResultFactory<INascarApiClient> resultFactory)
            : base(
                  configuration["mock:lapTimeSourceDirectory"],
                  resultFactory)
        {

        }

#endregion

        #region protected

        protected override LapTimeData GetDefault()
        {
            return new LapTimeData();
        }

        #endregion
    }
}
