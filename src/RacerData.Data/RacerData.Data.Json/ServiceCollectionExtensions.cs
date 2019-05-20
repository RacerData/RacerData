using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace RacerData.Data.Json
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddJsonData(this IServiceCollection services)
        {
            //services.TryAddSingleton<IAwsBucketConfiguration>(new AwsBucketConfiguration());
            //services.AddScoped<IAwsRepositoryFactory, AwsRepositoryFactory>();
            //services.AddScoped<IAwsBucket, AwsBucket>();
            //services.AddScoped<IAwsRepository, AwsRepository>();

            return services;
        }
    }
}
