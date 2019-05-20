using Microsoft.Extensions.DependencyInjection;
using RacerData.Commmon.Results;

namespace RacerData.Data
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddData(this IServiceCollection services)
        {
            services.AddResults();

            return services;
        }
    }
}
