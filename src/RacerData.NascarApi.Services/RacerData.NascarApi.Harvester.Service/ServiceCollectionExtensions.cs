using Microsoft.Extensions.DependencyInjection;
using RacerData.NascarApi.Harvester.Service.Adapters;
using RacerData.NascarApi.Harvester.Service.Internal;
using RacerData.NascarApi.Harvester.Service.Ports;

namespace RacerData.NascarApi.Harvester.Service
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddHarvesterService(this IServiceCollection services)
        {
            services.AddTransient<INascarApiHarvester, NascarApiHarvester>();
            services.AddTransient<ILiveFeedDataFileWriter, LiveFeedDataFileWriter>();

            return services;
        }
    }
}
