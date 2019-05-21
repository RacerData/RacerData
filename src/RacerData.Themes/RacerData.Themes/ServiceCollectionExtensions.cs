using Microsoft.Extensions.DependencyInjection;
using RacerData.Commmon.Results;

namespace RacerData.Data
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddThemes(this IServiceCollection services)
        {
            services.AddResults();

            return services;
        }
    }
}
