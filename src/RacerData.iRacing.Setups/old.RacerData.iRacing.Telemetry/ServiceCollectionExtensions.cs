using RacerData.iRacing.Telemetry;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace iRacing.Telemetry.Windows
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCommon(this IServiceCollection services)
        {
            services.AddLogging(configure => configure.AddConsole());
            services.AddOptions();
            services.AddSingleton(new iRacingTelemetryOptions());

            return services;
        }
    }
}
