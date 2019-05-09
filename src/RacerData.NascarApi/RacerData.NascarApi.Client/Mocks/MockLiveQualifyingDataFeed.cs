using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using RacerData.Commmon.Results;
using RacerData.NascarApi.Client.Models.LiveQualifying;
using RacerData.NascarApi.Client.Ports;

namespace RacerData.NascarApi.Client.Mocks
{
    class MockLiveQualifyingDataFeed : MockDataFeed<IEnumerable<LiveQualifyingData>>
    {
        #region ctor

        public MockLiveQualifyingDataFeed(
            IConfiguration configuration,
            IResultFactory<INascarApiClient> resultFactory)
            : base(
                  configuration["mock:liveQualifyingSourceDirectory"],
                  resultFactory)
        {

        }

        #endregion

        #region protected

        protected override IEnumerable<LiveQualifyingData> GetDefault()
        {
            return new List<LiveQualifyingData>();
        }

        #endregion
    }
}
