using Microsoft.Extensions.DependencyInjection;
using RacerData.NascarApi.Client;
using RacerData.NascarApi.Service.Adapters;
using RacerData.NascarApi.Service.Ports;

namespace RacerData.NascarApi.Service
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddNascarApiService(this IServiceCollection services)
        {
            services.AddNascarApiClient();

            services.AddTransient<IMonitorService, MonitorService>();

            return services;
        }
    }
}
