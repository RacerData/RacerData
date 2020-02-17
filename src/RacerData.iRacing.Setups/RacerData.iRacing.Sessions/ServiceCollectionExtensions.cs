using Microsoft.Extensions.DependencyInjection;
using RacerData.iRacing.Sessions.Adapters;
using RacerData.iRacing.Sessions.Ports;

namespace RacerData.iRacing.Service.Sessions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddSessions(this IServiceCollection services)
        {
            services
                .AddScoped<ISessionService, SessionService>();

            return services;
        }
    }
}
