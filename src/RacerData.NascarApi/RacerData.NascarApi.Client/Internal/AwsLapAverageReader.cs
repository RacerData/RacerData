using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RacerData.Data.Aws.Ports;
using RacerData.NascarApi.Client.Models.LapAverages;
using RacerData.NascarApi.Client.Models.LiveFeed;

namespace RacerData.NascarApi.Client.Internal
{
    class AwsLapAverageReader : IAwsLapAverageReader
    {
        #region fields

        private readonly IAwsRepository _repository;

        #endregion

        #region ctor

        public AwsLapAverageReader(
            IAwsRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        #endregion

        #region public

        public virtual async Task<LapAverageData> ReadLapAveragesAsync(LiveFeedData data)
        {
            var key = GetKey(data);

            var item = await _repository.SelectAsync(key);

            return JsonConvert.DeserializeObject<LapAverageData>(item.Content);
        }

        #endregion

        #region protected

        protected virtual string GetKey(LiveFeedData data)
        {
            return $"{data.SeriesType}-{data.RaceId}-{data.RunId}";
        }

        #endregion
    }
}
