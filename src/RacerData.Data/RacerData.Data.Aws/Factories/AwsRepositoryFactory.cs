using RacerData.Data.Aws.Adapters;
using RacerData.Data.Aws.Internal;
using RacerData.Data.Aws.Ports;

namespace RacerData.Data.Aws.Factories
{
    class AwsRepositoryFactory : IAwsRepositoryFactory
    {
        public IAwsRepository GetAwsRepository(IAwsBucketConfiguration configuration)
        {
            return new AwsRepository(new AwsBucket(configuration));
        }
    }
}
