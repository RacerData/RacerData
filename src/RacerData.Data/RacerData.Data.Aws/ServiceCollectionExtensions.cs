using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using RacerData.Data.Aws.Adapters;
using RacerData.Data.Aws.Factories;
using RacerData.Data.Aws.Internal;
using RacerData.Data.Aws.Ports;

namespace RacerData.Data.Aws
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddAwsData(this IServiceCollection services)
        {
            services.TryAddSingleton<IAwsBucketConfiguration>(new AwsBucketConfiguration());
            services.AddScoped<IAwsRepositoryFactory, AwsRepositoryFactory>();
            services.AddScoped<IAwsBucket, AwsBucket>();
            services.AddScoped<IAwsRepository, AwsRepository>();

            return services;
        }
    }
}
