using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using RacerData.Commmon;
using RacerData.Nascar.Pages.Adapters;
using RacerData.Nascar.Pages.Ports;

namespace RacerData.Nascar.Pages
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddPages(this IServiceCollection services)
        {
            services.AddCommon();

            services.TryAddTransient<IWeekendScheduleService, WeekendScheduleService>();
            services.TryAddTransient<IWeekendScheduleReader, WeekendScheduleReader>();

            return services;
        }
    }
}
