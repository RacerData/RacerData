using Microsoft.Extensions.DependencyInjection;
using RacerData.Common.Adapters;
using RacerData.Common.Ports;

namespace RacerData.Commmon
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCommon(this IServiceCollection services)
        {
            services.AddSingleton<IFileService>(new FileService());
            services.AddScoped<IRevertableService, RevertableService>();
            services.AddTransient<IDirectoryService, DirectoryService>();
            services.AddTransient<ISerializer, Serializer>();

            return services;
        }
    }
}
