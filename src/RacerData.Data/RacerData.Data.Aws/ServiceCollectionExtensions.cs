using Microsoft.Extensions.DependencyInjection;
using RacerData.Data.Aws.Adapters;
using RacerData.Data.Aws.Internal;
using RacerData.Data.Aws.Ports;

namespace RacerData.Data.Aws
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddAwsData(this IServiceCollection services)
        {
            services.AddScoped<IAwsBucket, AwsBucket>();
            services.AddScoped<IAwsRepository, AwsRepository>();

            return services;
        }
    }
}
