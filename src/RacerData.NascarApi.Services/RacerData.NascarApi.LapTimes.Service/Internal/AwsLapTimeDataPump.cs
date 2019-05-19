using System;
using System.Threading.Tasks;
using log4net;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RacerData.Commmon.Results;
using RacerData.Data.Aws.Models;
using RacerData.Data.Aws.Ports;
using RacerData.NascarApi.Client.Models.LapTimes;

namespace RacerData.NascarApi.LapTimes.Service.Internal
{
    class AwsLapTimeDataPump : IAwsLapTimeDataPump
    {
        #region fields

        private readonly IAwsRepository _repository;
        private readonly ILog _log;
        private readonly string _prefix = string.Empty;

        #endregion

        #region ctor

        public AwsLapTimeDataPump(
            ILog log,
            IAwsRepositoryFactory repositoryFactory,
            IConfiguration configuration)
        {
            if (repositoryFactory == null)
                throw new ArgumentNullException(nameof(repositoryFactory));

            _repository = repositoryFactory.GetAwsRepository(AwsRepositoryType.LapTimes);

            _log = log ?? throw new ArgumentNullException(nameof(log));

            var rawConfigurationValue = configuration["aws:LapTimes"];

            _prefix = rawConfigurationValue.EndsWith("/") ? rawConfigurationValue.TrimEnd('/') : rawConfigurationValue;
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

            var result = await _repository.PutAsync(item);

            if (!result.IsSuccessful())
            {
                throw new Exception($"Error writing lap time data to AWS: {result.Exception.Message}", result.Exception);
            }
        }

        #endregion

        #region protected

        protected virtual string GetKey(LapTimeData lapTimes)
        {
            return $"{_prefix}/{lapTimes.SeriesId}-{lapTimes.RaceId}-{lapTimes.RunId}";
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
            return AwsContentType.Json;
        }

        #endregion
    }
}
