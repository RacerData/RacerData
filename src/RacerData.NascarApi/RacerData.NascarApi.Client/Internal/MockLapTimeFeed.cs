using Microsoft.Extensions.Configuration;
using RacerData.Commmon.Results;
using RacerData.NascarApi.Client.Models.LapTimes;
using RacerData.NascarApi.Client.Ports;

namespace RacerData.NascarApi.Client.Internal
{
    class MockLapTimeFeed : MockDataFeed<EventVehicleLapTimes>
    {
        public MockLapTimeFeed(
            IConfiguration configuration,
            IResultFactory<INascarApiClient> resultFactory)
            : base(
                  configuration["mock:lapTimeSourceDirectory"],
                  resultFactory)
        {

        }
    }
}
