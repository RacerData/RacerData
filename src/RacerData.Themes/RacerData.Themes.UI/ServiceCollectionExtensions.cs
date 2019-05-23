using System;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using RacerData.Themes.Ports;
using RacerData.Themes.UI.Adapters;
using RacerData.Themes.UI.Ports;
using RacerData.Themes.UI.Views;

namespace RacerData.Themes.UI
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddThemesUI(this IServiceCollection services)
        {
            services.AddThemes();

            services.AddScoped<IThemeDefinitionRepository, ThemeDefinitionRepository>();
            services.AddTransient<IThemeUiService, ThemeUiService>();
            services.AddTransient<Form1, Form1>();

            Mapper.Initialize(cfg => cfg.AddMaps(AppDomain.CurrentDomain.GetAssemblies()));

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            return services;
        }
    }
}
