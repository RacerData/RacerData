using Microsoft.Extensions.DependencyInjection;
using RacerData.Commmon.Results;

namespace RacerData.NascarApi.Client
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddNascarApiClient(this IServiceCollection services)
        {
            services.AddResults();
            services.AddNascarApi();

            return services;
        }
    }
}
