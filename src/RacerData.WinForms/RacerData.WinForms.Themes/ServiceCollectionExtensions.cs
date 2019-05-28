using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using RacerData.WinForms.Dialogs;
using RacerData.WinForms.Themes.Adapters;
using RacerData.WinForms.Themes.Ports;

namespace RacerData.WinForms.Themes
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddThemes(this IServiceCollection services)
        {
            services.AddTransient<AppearanceEditorDialog, AppearanceEditorDialog>();
            services.TryAddTransient<IAppAppearanceRepository, AppAppearanceRepository>();

            return services;
        }
    }
}
