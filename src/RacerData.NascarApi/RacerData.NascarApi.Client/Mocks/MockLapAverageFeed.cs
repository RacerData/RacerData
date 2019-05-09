using Microsoft.Extensions.Configuration;
using RacerData.Commmon.Results;
using RacerData.NascarApi.Client.Models.LapAverages;
using RacerData.NascarApi.Client.Ports;

namespace RacerData.NascarApi.Client.Mocks
{
    class MockLapAverageFeed : MockDataFeed<EventVehicleLapAverages>
    {
        #region ctor

        public MockLapAverageFeed(
            IConfiguration configuration,
            IResultFactory<INascarApiClient> resultFactory)
            : base(
                  configuration["mock:lapAverageSourceDirectory"],
                  resultFactory)
        {

        }

        #endregion

        #region protected

        protected override EventVehicleLapAverages GetDefault()
        {
            return new EventVehicleLapAverages();
        }

        #endregion
    }
}
