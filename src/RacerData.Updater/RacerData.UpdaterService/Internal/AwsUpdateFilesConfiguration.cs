using RacerData.Data.Aws.Ports;

namespace RacerData.UpdaterService.Internal
{
    public class AwsUpdateFilesConfiguration : IAwsBucketConfiguration
    {
        public string Bucket { get; set; }
        public string Directory { get; set; }
        public string RegionEndpoint { get; set; }

        public AwsUpdateFilesConfiguration(string appKey)
        {
            Bucket = "www.racerdatasoftware.com";
            Directory = appKey;
            RegionEndpoint = "us-east-1";
        }
    }
}
