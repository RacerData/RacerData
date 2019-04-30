using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using RacerData.Commmon.Results.Factories;

namespace RacerData.Commmon.Results
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddResults(this IServiceCollection services)
        {
            services.TryAdd(ServiceDescriptor.Singleton(typeof(IResultFactory<>), typeof(ResultFactory<>)));

            return services;
        }
    }
}
