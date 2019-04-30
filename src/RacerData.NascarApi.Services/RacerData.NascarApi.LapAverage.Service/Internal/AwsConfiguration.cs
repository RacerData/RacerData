using RacerData.Data.Aws.Ports;

namespace RacerData.NascarApi.LapAverage.Service.Internal
{
    class AwsConfiguration : IAwsBucketConfiguration
    {
        public string Bucket { get; set; }
        public string Directory { get; set; }
        public string RegionEndpoint { get; set; }

        public AwsConfiguration()
        {
            Bucket = "racerdatasoftware.com";
            Directory = "//LapAverages";
            RegionEndpoint = "us-east-1";
        }
    }
}
