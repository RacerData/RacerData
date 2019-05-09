using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using RacerData.Commmon.Results;
using RacerData.NascarApi.Client.Models.LiveQualifying;
using RacerData.NascarApi.Client.Ports;

namespace RacerData.NascarApi.Client.Internal
{
    class MockLiveQualifyingDataFeed : MockDataFeed<IEnumerable<LiveQualifyingData>>
    {
        public MockLiveQualifyingDataFeed(
            IConfiguration configuration,
            IResultFactory<INascarApiClient> resultFactory)
            : base(
                  configuration["mock:liveQualifyingSourceDirectory"],
                  resultFactory)
        {

        }
    }
}
