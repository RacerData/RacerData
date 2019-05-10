using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RacerData.Data.Aws.Models;
using RacerData.Data.Aws.Ports;
using RacerData.NascarApi.Client.Models.LapAverages;

namespace RacerData.NascarApi.LapAverage.Service.Internal
{
    class AwsDataPump : IAwsDataPump
    {
        #region fields

        private readonly IAwsRepository _repository;

        #endregion

        #region ctor

        public AwsDataPump(
            IAwsRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
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

            await _repository.PutAsync(item);
        }

        #endregion

        #region protected

        protected virtual string GetKey(LapAverageData lapAverages)
        {
            return $"{lapAverages.SeriesId}-{lapAverages.RaceId}-{lapAverages.RunId}";
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
            return "application/json";
        }

        #endregion
    }
}
