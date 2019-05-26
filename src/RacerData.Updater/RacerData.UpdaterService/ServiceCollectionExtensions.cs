using Microsoft.Extensions.DependencyInjection;
using RacerData.Commmon;
using RacerData.Data.Aws;
using RacerData.UpdaterService.Adapters;
using RacerData.UpdaterService.Ports;

namespace RacerData.UpdaterService
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddUpdateService(this IServiceCollection services)
        {
            services.AddAwsData();

            services.AddTransient<IUpdateService, UpdateService>();

            services.AddCommon();
            services.AddAwsData();

            return services;
        }
    }
}
