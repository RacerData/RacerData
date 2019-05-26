using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using RacerData.WinForms.Adapters;
using RacerData.WinForms.Ports;

namespace RacerData.WinForms
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDialogService(this IServiceCollection services)
        {
            services.TryAddTransient<IDialogService, DialogService>();

            return services;
        }

        public static IServiceCollection AddExceptionHandlerService(this IServiceCollection services)
        {
            services.TryAddTransient<IExceptionHandlerService, ExceptionHandlerService>();

            return services;
        }
    }
}
