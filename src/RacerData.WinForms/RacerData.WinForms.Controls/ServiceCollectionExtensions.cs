using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using RacerData.WinForms.Factories;
using RacerData.WinForms.Ports;

namespace RacerData.WinForms.Controls
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddRacerDataControls(this IServiceCollection services)
        {
            services.TryAddTransient<IViewControlFactory, ViewControlFactory>();
            services.TryAddTransient<IViewFactory, ViewFactory>();
            services.TryAddTransient<IViewGridControllerFactory, ViewGridControllerFactory>();
            return services;
        }
    }
}
