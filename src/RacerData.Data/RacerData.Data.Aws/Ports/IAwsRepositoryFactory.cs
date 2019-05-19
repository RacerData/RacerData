using RacerData.Data.Aws.Models;

namespace RacerData.Data.Aws.Ports
{
    public interface IAwsRepositoryFactory
    {
        IAwsRepository GetAwsRepository(IAwsBucketConfiguration configuration);
        IAwsRepository GetAwsRepository(AwsRepositoryType bucketType);
    }
}