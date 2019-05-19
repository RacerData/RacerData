using RacerData.Data.Aws.Ports;

namespace RacerData.Data.Aws.Adapters
{
    public sealed class AwsRacerDataBucketConfiguration : AwsBucketConfiguration, IAwsBucketConfiguration
    {
        public override string Bucket { get; set; } = "racerdatasoftware.com";
        public override string RegionEndpoint { get; set; } = "us-east-1";
    }
}
