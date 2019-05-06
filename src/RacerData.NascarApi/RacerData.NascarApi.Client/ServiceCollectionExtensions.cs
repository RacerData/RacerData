using Microsoft.Extensions.DependencyInjection;
using RacerData.Commmon.Results;
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

            services.AddResults();
            services.AddNascarApi();

            return services;
        }
    }
}
