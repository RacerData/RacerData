using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RacerData.iRacing.Service.Sessions.Adapters;
using RacerData.iRacing.Service.Sessions.Data;
using RacerData.iRacing.Sessions.Ports;

namespace RacerData.iRacing.Service.Sessions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddSessionsService(this IServiceCollection services)
        {
            services
                .AddAutoMapper()
                .AddSessions()
                .AddDbContext<SessionsDbContext>(options =>
                    options.UseSqlServer(@"Data Source=.\SqlExpress;Initial Catalog=iRacingSessions;Trusted_Connection=True;"))
                .AddScoped<IDriverRepository, DriverRepository>()
                .AddScoped<IRunRepository, RunRepository>()
                .AddScoped<ISessionRepository, SessionRepository>()
                .AddScoped<ISetupRepository, SetupRepository>()
                .AddScoped<ITelemetryRepository, TelemetryRepository>()
                .AddScoped<ITelemetryFileInfoRepository, TelemetryFileInfoRepository>()
                .AddScoped<ITrackRepository, TrackRepository>()
                .AddScoped<IVehicleRepository, VehicleRepository>();

            return services;
        }
    }
}
