using RacerData.Data.Aws.Ports;

namespace RacerData.Data.Aws.Adapters
{
    public class AwsBucketConfiguration : IAwsBucketConfiguration
    {
        public virtual string Bucket { get; set; } = "racerdatasoftware.com";
        public virtual string Directory { get; set; } = "//Default";
        public virtual string RegionEndpoint { get; set; } = "us-east-1";
    }
}
