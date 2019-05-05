using RacerData.Data.Aws.Ports;

namespace RacerData.NascarApi.LapTimes.Service.Internal
{
    class AwsLapTimeBucketConfiguration : IAwsBucketConfiguration
    {
        public string Bucket { get; set; } = "racerdatasoftware.com";
        public string Directory { get; set; } = "//LapTimes";
        public string RegionEndpoint { get; set; } = "us-east-1";
    }
}
