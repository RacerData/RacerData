using Microsoft.Extensions.DependencyInjection;
using RacerData.NascarApi.Harvester.Service;
using RacerData.NascarApi.LapAverage.Service;
using RacerData.NascarApi.LapTimes.Service;
using RacerData.NascarApi.Service;

namespace RacerData.NascarApi.Services
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddNascarApiServices(this IServiceCollection services)
        {
            services.AddNascarApiService();

            services.AddHarvesterService();
            services.AddLapAverageService();
            services.AddLapTimeService();

            return services;
        }
    }
}
