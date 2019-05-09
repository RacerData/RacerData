using Microsoft.Extensions.Configuration;
using RacerData.Commmon.Results;
using RacerData.NascarApi.Client.Models.LiveFeed;
using RacerData.NascarApi.Client.Ports;

namespace RacerData.NascarApi.Client.Internal
{
    class MockLiveDataFeed : MockDataFeed<LiveFeedData>
    {
        public MockLiveDataFeed(
            IConfiguration configuration,
            IResultFactory<INascarApiClient> resultFactory)
            : base(
                  configuration["mock:liveFeedSourceDirectory"],
                  resultFactory)
        {

        }
    }
}
