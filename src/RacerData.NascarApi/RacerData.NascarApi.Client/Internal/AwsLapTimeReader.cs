using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RacerData.Data.Aws.Ports;
using RacerData.NascarApi.Client.Models.LapTimes;
using RacerData.NascarApi.Client.Models.LiveFeed;

namespace RacerData.NascarApi.Client.Internal
{
    class AwsLapTimeReader : IAwsLapTimeReader
    {
        #region fields

        private readonly IAwsRepository _repository;

        #endregion

        #region ctor

        public AwsLapTimeReader(
            IAwsRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        #endregion

        #region public

        public virtual async Task<EventVehicleLapTimes> ReadLapTimesAsync(LiveFeedData data)
        {
            var key = GetKey(data);

            var item = await _repository.SelectAsync(key);

            return JsonConvert.DeserializeObject<EventVehicleLapTimes>(item.Content);
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
