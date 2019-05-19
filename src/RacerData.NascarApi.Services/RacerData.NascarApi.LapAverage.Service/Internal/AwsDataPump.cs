using System;
using System.Threading.Tasks;
using log4net;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RacerData.Commmon.Results;
using RacerData.Data.Aws.Models;
using RacerData.Data.Aws.Ports;
using RacerData.NascarApi.Client.Models.LapAverages;

namespace RacerData.NascarApi.LapAverage.Service.Internal
{
    class AwsDataPump : IAwsDataPump
    {
        #region fields

        private readonly IAwsRepository _repository;
        private readonly ILog _log;
        private readonly string _prefix = string.Empty;

        #endregion

        #region ctor

        public AwsDataPump(
            ILog log,
            IAwsRepositoryFactory repositoryFactory,
            IConfiguration configuration)
        {
            if (repositoryFactory == null)
                throw new ArgumentNullException(nameof(repositoryFactory));

            _repository = repositoryFactory.GetAwsRepository(AwsRepositoryType.LapAverages);

            _log = log ?? throw new ArgumentNullException(nameof(log));

            var rawConfigurationValue = configuration["aws:LapAverages"];

            _prefix = rawConfigurationValue.EndsWith("/") ? rawConfigurationValue.TrimEnd('/') : rawConfigurationValue;
        }

        #endregion

        #region public

        public virtual async Task WriteLapAveragesAsync(LapAverageData lapAverages)
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
                throw new Exception($"Error writing lap average data to AWS: {result.Exception.Message}", result.Exception);
            }
        }

        #endregion

        #region protected

        protected virtual string GetKey(LapAverageData lapAverages)
        {
            return $"{_prefix}/{lapAverages.SeriesId}-{lapAverages.RaceId}-{lapAverages.RunId}";
        }

        protected virtual string GetContent(LapAverageData lapAverages)
        {
            return JsonConvert.SerializeObject(
                  lapAverages,
                  Formatting.Indented,
                  new JsonSerializerSettings { NullValueHandling = NullValueHandling.Include });
        }

        protected virtual string GetContentType(LapAverageData lapAverages)
        {
            return AwsContentType.Json;
        }

        #endregion
    }
}
