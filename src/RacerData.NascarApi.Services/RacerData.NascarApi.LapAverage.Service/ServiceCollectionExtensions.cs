using Microsoft.Extensions.DependencyInjection;
using RacerData.Commmon.Results;
using RacerData.Data.Aws;
using RacerData.NascarApi.LapAverage.Service.Adapters;
using RacerData.NascarApi.LapAverage.Service.Internal;
using RacerData.NascarApi.LapAverage.Service.Ports;

namespace RacerData.NascarApi.LapAverage.Service
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddLapAverageService(this IServiceCollection services)
        {
            services.AddResults();
            services.AddAwsData();

            services.AddTransient<IAwsDataPump, AwsDataPump>();
            services.AddTransient<ILapAverageHandler, LapAverageHandler>();
            services.AddTransient<ILapAverageService, LapAverageService>();
            services.AddTransient<ILapAverageDataFileWriter, LapAverageDataFileWriter>();

            return services;
        }
    }
}
