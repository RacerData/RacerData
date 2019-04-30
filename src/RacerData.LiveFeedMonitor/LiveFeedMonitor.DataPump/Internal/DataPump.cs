using System;
using System.Threading.Tasks;
using Amazon;
using Amazon.S3;
using Amazon.S3.Model;
using log4net;
using Newtonsoft.Json;
using RacerData.NascarApi.Client.Models.LapAverages;

namespace RacerData.LiveFeed.AwsDataPump.Internal
{
    internal class DataPump
    {
        #region fields

        private const string BucketName = "racerdatasoftware.com";
        private const string BucketDirectory = "LapAverages";
        private static readonly RegionEndpoint bucketRegion = RegionEndpoint.USEast1;
        private static IAmazonS3 client;
        private ILog _log;

        #endregion

        #region ctor

        public DataPump(ILog log)
        {
            client = new AmazonS3Client(bucketRegion);
            _log = log ?? throw new ArgumentNullException(nameof(log));
        }

        #endregion

        #region public

        public virtual async Task<bool> WriteLapAveragesAsync(EventLapAverages lapAverages)
        {
            try
            {
                if (lapAverages.RaceId < 0)
                    throw new InvalidOperationException($"Invalid RaceId: {lapAverages.RaceId}");

                var key = $"{lapAverages.SeriesId}-{lapAverages.RaceId}-{lapAverages.RunId}";

                var json = JsonConvert.SerializeObject(
                    lapAverages,
                    Formatting.Indented,
                    new JsonSerializerSettings { NullValueHandling = NullValueHandling.Include });

                var bucketPath = $"{BucketName}//{BucketDirectory}";

                var putRequest1 = new PutObjectRequest
                {
                    BucketName = bucketPath,
                    Key = key,
                    ContentBody = json,
                    ContentType = "application/json"
                };

                putRequest1.Metadata.Add("x-amz-meta-title", "someTitle");

                PutObjectResponse response1 = await client.PutObjectAsync(putRequest1);

                return true;
                //string MockDataPumpOutputDirectory = @"C:\Users\Rob\Documents\RacerData\MockDataPumpOutput";

                //string fileName = $"{key}.json";

                //System.IO.File.WriteAllText(System.IO.Path.Combine(MockDataPumpOutputDirectory, fileName), json);

                //return await Task.FromResult(true);

            }
            catch (AmazonS3Exception e)
            {
                ExceptionHandler(String.Format(
                        "Error encountered ***. Message:'{0}' when writing an object"
                        , e.Message), e);
            }
            catch (Exception e)
            {
                ExceptionHandler(String.Format(
                       "Unknown encountered on server. Message:'{0}' when writing an object"
                       , e.Message), e);
            }

            return false;
        }

        #endregion

        #region protected

        protected virtual void ExceptionHandler(string message, Exception ex)
        {
            _log?.Error(message, ex);
#if DEBUG
            Console.WriteLine(ex);
#endif
        }

        #endregion
    }
}