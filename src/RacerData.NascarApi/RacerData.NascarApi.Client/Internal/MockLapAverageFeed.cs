using Microsoft.Extensions.Configuration;
using RacerData.Commmon.Results;
using RacerData.NascarApi.Client.Models.LapAverages;
using RacerData.NascarApi.Client.Ports;

namespace RacerData.NascarApi.Client.Internal
{
    class MockLapAverageFeed : MockDataFeed<EventVehicleLapAverages>
    {
        public MockLapAverageFeed(
            IConfiguration configuration,
            IResultFactory<INascarApiClient> resultFactory)
            : base(
                  configuration["mock:lapAverageSourceDirectory"],
                  resultFactory)
        {

        }
    }
}
