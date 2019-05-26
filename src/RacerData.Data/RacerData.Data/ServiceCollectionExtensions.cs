using Microsoft.Extensions.DependencyInjection;
using RacerData.Commmon;

namespace RacerData.Data
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddData(this IServiceCollection services)
        {
            services.AddCommon();

            return services;
        }
    }
}
