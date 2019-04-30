using Microsoft.Extensions.DependencyInjection;
using RacerData.LiveFeed.AwsDataPump.Adapters;
using RacerData.NascarApi.Service.Ports;

namespace RacerData.LiveFeed.AwsDataPump
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddLiveFeedDataPump(this IServiceCollection services)
        {
            services.AddTransient<ILapAverageDataPumpService, AwsLapAverageDataPumpService>();

            return services;
        }
    }
}
