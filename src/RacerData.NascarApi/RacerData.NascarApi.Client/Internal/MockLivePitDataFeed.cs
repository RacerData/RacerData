using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using RacerData.Commmon.Results;
using RacerData.NascarApi.Client.Models.LivePit;
using RacerData.NascarApi.Client.Ports;

namespace RacerData.NascarApi.Client.Internal
{
    class MockLivePitDataFeed : MockDataFeed<IEnumerable<LivePitData>>
    {
        public MockLivePitDataFeed(
            IConfiguration configuration,
            IResultFactory<INascarApiClient> resultFactory)
            : base(
                  configuration["mock:livePitSourceDirectory"],
                  resultFactory)
        {

        }
    }
}
