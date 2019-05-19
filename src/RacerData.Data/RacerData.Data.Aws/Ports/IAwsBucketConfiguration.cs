namespace RacerData.Data.Aws.Ports
{
    public interface IAwsBucketConfiguration
    {       
        /// <summary>
        /// Name of the root bucket
        /// </summary>
        string Bucket { get; set; }
        /// <summary>
        /// Directory path inside the bucket, like "//BucketSubdirectory1//BucketSubdirectory2"
        /// </summary>
        string Prefix { get; set; }
        /// <summary>
        /// The region based on its system name like "us-west-1"
        /// </summary>
        string RegionEndpoint { get; set; }
    }
}
