using Microsoft.Extensions.Configuration;
using RacerData.Commmon.Results;
using RacerData.NascarApi.Client.Models.LiveFeed;
using RacerData.NascarApi.Client.Ports;

namespace RacerData.NascarApi.Client.Mocks
{
    class MockLiveDataFeed : MockDataFeed<LiveFeedData>
    {
        #region ctor

        public MockLiveDataFeed(
            IConfiguration configuration,
            IResultFactory<INascarApiClient> resultFactory)
            : base(
                  configuration["mock:liveFeedSourceDirectory"],
                  resultFactory)
        {

        }

#endregion

        #region protected

        protected override LiveFeedData GetDefault()
        {
            return new LiveFeedData();
        }

        #endregion
    }
}
