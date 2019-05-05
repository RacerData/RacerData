using Microsoft.Extensions.DependencyInjection;
using RacerData.Commmon.Results;
using RacerData.Data.Aws;
using RacerData.NascarApi.Client.Internal;

namespace RacerData.NascarApi.Client
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddNascarApiClient(this IServiceCollection services)
        {
            services.AddAwsData();
            services.AddTransient<IAwsLapAverageReader, AwsLapAverageReader>();

            services.AddResults();
            services.AddNascarApi();

            return services;
        }
    }
}
