using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using RacerData.Commmon.Results;
using RacerData.NascarApi.Client.Models.LiveFlag;
using RacerData.NascarApi.Client.Ports;

namespace RacerData.NascarApi.Client.Internal
{
    class MockLiveFlagDataFeed : MockDataFeed<IEnumerable<LiveFlagData>>
    {
        public MockLiveFlagDataFeed(
            IConfiguration configuration,
            IResultFactory<INascarApiClient> resultFactory)
            : base(
                  configuration["mock:liveFlagSourceDirectory"],
                  resultFactory)
        {

        }
    }
}
