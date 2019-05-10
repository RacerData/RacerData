using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RacerData.Data.Aws.Models;
using RacerData.Data.Aws.Ports;
using RacerData.NascarApi.Client.Models.LapTimes;

namespace RacerData.NascarApi.LapTimes.Service.Internal
{
    class AwsLapTimeDataPump : IAwsLapTimeDataPump
    {
        #region fields

        private readonly IAwsRepository _repository;

        #endregion

        #region ctor

        public AwsLapTimeDataPump(
            IAwsRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        #endregion

        #region public

        public virtual async Task WriteLapTimesAsync(LapTimeData lapAverages)
        {
            var key = GetKey(lapAverages);

            var content = GetContent(lapAverages);

            var contentType = GetContentType(lapAverages);

            var item = new AwsItem()
            {
                Key = key,
                Content = content,
                ContentType = contentType
            };

            await _repository.PutAsync(item);
        }

        #endregion

        #region protected

        protected virtual string GetKey(LapTimeData lapTimes)
        {
            return $"{lapTimes.SeriesId}-{lapTimes.RaceId}-{lapTimes.RunId}";
        }

        protected virtual string GetContent(LapTimeData lapTimes)
        {
            return JsonConvert.SerializeObject(
                  lapTimes,
                  Formatting.Indented,
                  new JsonSerializerSettings { NullValueHandling = NullValueHandling.Include });
        }

        protected virtual string GetContentType(LapTimeData lapTimes)
        {
            return "application/json";
        }

        #endregion
    }
}
