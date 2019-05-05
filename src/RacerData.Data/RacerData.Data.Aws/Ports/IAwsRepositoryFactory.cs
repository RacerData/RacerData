namespace RacerData.Data.Aws.Ports
{
    public interface IAwsRepositoryFactory
    {
        IAwsRepository GetAwsRepository(IAwsBucketConfiguration configuration);
    }
}