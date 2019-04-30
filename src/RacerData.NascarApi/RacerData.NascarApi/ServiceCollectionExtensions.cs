using Microsoft.Extensions.DependencyInjection;
using RacerData.NascarApi.Adapters;
using RacerData.NascarApi.Factories;
using RacerData.NascarApi.Ports;

namespace RacerData.NascarApi
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddNascarApi(this IServiceCollection services)
        {
            services.AddTransient<IApiClient, ApiClient>();
            services.AddTransient<IApiClientFactory, ApiClientFactory>();
            services.AddTransient<IUrlService, UrlService>();

            return services;
        }
    }
}
