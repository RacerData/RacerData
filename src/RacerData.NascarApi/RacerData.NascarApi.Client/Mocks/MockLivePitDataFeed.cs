using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using RacerData.Commmon.Results;
using RacerData.NascarApi.Client.Models.LivePit;
using RacerData.NascarApi.Client.Ports;

namespace RacerData.NascarApi.Client.Mocks
{
    class MockLivePitDataFeed : MockDataFeed<IEnumerable<LivePitData>>
    {
        #region ctor

        public MockLivePitDataFeed(
            IConfiguration configuration,
            IResultFactory<INascarApiClient> resultFactory)
            : base(
                  configuration["mock:livePitSourceDirectory"],
                  resultFactory)
        {

        }

#endregion

        #region protected

        protected override IEnumerable<LivePitData> GetDefault()
        {
            return new List<LivePitData>();
        }

        #endregion
    }
}
