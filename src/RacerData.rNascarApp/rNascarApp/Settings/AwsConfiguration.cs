using RacerData.Data.Aws.Ports;

namespace RacerData.rNascarApp.Settings
{
    class AwsConfiguration : IAwsBucketConfiguration
    {
        public virtual string Bucket { get; set; } = "racerdatasoftware.com";
        public virtual string Directory { get; set; } = "//LapAverages";
        public virtual string RegionEndpoint { get; set; } = "us-east-1";
    }
}
