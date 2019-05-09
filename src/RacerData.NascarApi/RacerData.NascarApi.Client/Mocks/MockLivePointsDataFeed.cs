using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using RacerData.Commmon.Results;
using RacerData.NascarApi.Client.Models.LivePoints;
using RacerData.NascarApi.Client.Ports;

namespace RacerData.NascarApi.Client.Mocks
{
    class MockLivePointsDataFeed : MockDataFeed<IEnumerable<LivePointsData>>
    {
        #region ctor

        public MockLivePointsDataFeed(
            IConfiguration configuration,
            IResultFactory<INascarApiClient> resultFactory)
            : base(
                  configuration["mock:livePointsSourceDirectory"],
                  resultFactory)
        {

        }

#endregion

        #region protected

        protected override IEnumerable<LivePointsData> GetDefault()
        {
            return new List<LivePointsData>();
        }

        #endregion
    }
}
