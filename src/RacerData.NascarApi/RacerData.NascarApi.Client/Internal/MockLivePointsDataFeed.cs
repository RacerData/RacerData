using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using RacerData.Commmon.Results;
using RacerData.NascarApi.Client.Models.LivePoints;
using RacerData.NascarApi.Client.Ports;

namespace RacerData.NascarApi.Client.Internal
{
    class MockLivePointsDataFeed : MockDataFeed<IEnumerable<LivePointsData>>
    {
        public MockLivePointsDataFeed(
            IConfiguration configuration,
            IResultFactory<INascarApiClient> resultFactory)
            : base(
                  configuration["mock:livePointsSourceDirectory"],
                  resultFactory)
        {

        }
    }
}
