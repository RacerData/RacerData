using Microsoft.Extensions.DependencyInjection;
using RacerData.Commmon;
using RacerData.Data.Aws;
using RacerData.NascarApi.Client.Adapters;
using RacerData.NascarApi.Client.Factories;
using RacerData.NascarApi.Client.Internal;
using RacerData.NascarApi.Client.Ports;

namespace RacerData.NascarApi.Client
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddNascarApiClient(this IServiceCollection services)
        {
            services.AddAwsData();

            services.AddTransient<INascarApiClientFactory, NascarApiClientFactory>();
            services.AddTransient<INascarApiClient, NascarApiClient>();
            services.AddTransient<IAwsLapAverageReader, AwsLapAverageReader>();
            services.AddTransient<IAwsLapTimeReader, AwsLapTimeReader>();

            services.AddCommon();
            services.AddNascarApi();

            return services;
        }
    }
}
