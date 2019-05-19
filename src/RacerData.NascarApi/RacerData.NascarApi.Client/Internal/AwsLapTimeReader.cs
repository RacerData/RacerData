using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RacerData.Commmon.Results;
using RacerData.Data.Aws.Adapters;
using RacerData.Data.Aws.Models;
using RacerData.Data.Aws.Ports;
using RacerData.NascarApi.Client.Models.LapTimes;
using RacerData.NascarApi.Client.Models.LiveFeed;

namespace RacerData.NascarApi.Client.Internal
{
    class AwsLapTimeReader : IAwsLapTimeReader
    {
        #region fields

        private readonly IAwsRepository _repository;
        private readonly string _prefix = string.Empty;

        #endregion

        #region ctor

        public AwsLapTimeReader(
            IConfiguration configuration,
            IAwsRepositoryFactory repositoryFactory)
        {
            if (configuration == null)
                throw new ArgumentNullException(nameof(configuration));

            var rawConfigurationValue = configuration["aws:LapTimes"];

            _prefix = rawConfigurationValue.EndsWith("/") ? rawConfigurationValue.TrimEnd('/') : rawConfigurationValue;

            if (repositoryFactory == null)
                throw new ArgumentNullException(nameof(repositoryFactory));

            _repository = repositoryFactory.GetAwsRepository(AwsRepositoryType.LapTimes);
        }

        #endregion

        #region public

        public virtual async Task<LapTimeData> ReadLapTimesAsync(LiveFeedData data)
        {
            var key = GetKey(data);

            var result = await _repository.SelectAsync(key);

            if (!result.IsSuccessful())
            {
                throw new Exception($"Error reading lap average data from AWS: {result.Exception.Message}", result.Exception);
            }

            var item = result.Value;

            return JsonConvert.DeserializeObject<LapTimeData>(item.Content);
        }

        #endregion

        #region protected

        protected virtual string GetKey(LiveFeedData data)
        {
            return $"{_prefix}/{(int)data.SeriesType}-{data.RaceId}-{data.RunId}";
        }

        #endregion
    }
}
