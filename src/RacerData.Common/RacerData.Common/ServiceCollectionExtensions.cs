using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using RacerData.Commmon.Results;
using RacerData.Commmon.Results.Factories;
using RacerData.Common.Adapters;
using RacerData.Common.Ports;

namespace RacerData.Commmon
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCommon(this IServiceCollection services)
        {
            services.TryAdd(ServiceDescriptor.Singleton(typeof(IResultFactory<>), typeof(ResultFactory<>)));
            services.AddSingleton<IFileService>(new FileService());
            services.AddScoped<IRevertableService, RevertableService>();
            services.AddTransient<IDirectoryService, DirectoryService>();
            services.AddTransient<ISerializer, Serializer>();

            return services;
        }
    }
}
