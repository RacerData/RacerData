using RacerData.Data.Aws.Ports;

namespace RacerData.UpdaterService.Internal
{
    class AwsUpdateConfiguration : IAwsBucketConfiguration
    {
        public string Bucket { get; set; }
        public string Directory { get; set; }
        public string RegionEndpoint { get; set; }

        public AwsUpdateConfiguration(string appKey, string version = "")
        {
            Bucket = "www.racerdatasoftware.com";
            Directory = string.IsNullOrEmpty(version) ? $"Setup/{appKey}/" : $"Setup/{appKey}/{version}/";
            RegionEndpoint = "us-east-1";
        }
    }
}
