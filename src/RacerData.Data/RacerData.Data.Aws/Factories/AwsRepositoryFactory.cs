using RacerData.Data.Aws.Adapters;
using RacerData.Data.Aws.Internal;
using RacerData.Data.Aws.Ports;

namespace RacerData.Data.Aws.Factories
{
    class AwsRepositoryFactory : IAwsRepositoryFactory
    {
        public IAwsRepository GetAwsRepository(IAwsBucketConfiguration configuration)
        {

#if DEBUG
            System.Console.WriteLine($"*** Creating new AwsRepository using bucket:{configuration.Bucket}, directory:{configuration.Directory}, regionEndpoint:{configuration.RegionEndpoint}");
#endif
            return new AwsRepository(new AwsBucket(configuration));
        }
    }
}
