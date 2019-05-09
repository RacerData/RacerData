using Microsoft.Extensions.Configuration;
using RacerData.Commmon.Results;
using RacerData.NascarApi.Client.Models.LapAverages;
using RacerData.NascarApi.Client.Models.LapTimes;
using RacerData.NascarApi.Client.Ports;

namespace RacerData.NascarApi.Client.Mocks
{
    class MockLapTimeFeed : MockDataFeed<EventVehicleLapTimes>
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

        protected override EventVehicleLapTimes GetDefault()
        {
            return new EventVehicleLapTimes();
        }

        #endregion
    }
}
