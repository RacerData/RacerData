using Microsoft.Extensions.DependencyInjection;
using RacerData.Commmon.Results;
using RacerData.Themes.Factories;
using RacerData.Themes.Models;
using RacerData.Themes.Ports;

namespace RacerData.Themes
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddThemes(this IServiceCollection services)
        {
            services.AddTransient<IAppearanceFactory, AppearanceFactory>();
            services.AddSingleton(new StandardAppearances());
            services.AddSingleton(new StandardThemes());

            services.AddResults();

            return services;
        }
    }
}
