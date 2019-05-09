using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using RacerData.Commmon.Results;
using RacerData.NascarApi.Client.Models.LiveFlag;
using RacerData.NascarApi.Client.Ports;

namespace RacerData.NascarApi.Client.Mocks
{
    class MockLiveFlagDataFeed : MockDataFeed<IEnumerable<LiveFlagData>>
    {
        #region ctor

        public MockLiveFlagDataFeed(
            IConfiguration configuration,
            IResultFactory<INascarApiClient> resultFactory)
            : base(
                  configuration["mock:liveFlagSourceDirectory"],
                  resultFactory)
        {

        }

#endregion

        #region protected

        protected override IEnumerable<LiveFlagData> GetDefault()
        {
            return new List<LiveFlagData>();
        }

        #endregion
    }
}
