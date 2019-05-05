using Microsoft.Extensions.DependencyInjection;
using RacerData.Data.Aws;
using RacerData.NascarApi.LapTimes.Service.Adapters;
using RacerData.NascarApi.LapTimes.Service.Internal;
using RacerData.NascarApi.LapTimes.Service.Ports;

namespace RacerData.NascarApi.LapTimes.Service
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddLapTimeService(this IServiceCollection services)
        {
            services.AddAwsData();

            services.AddTransient<IAwsLapTimeDataPump, AwsLapTimeDataPump>();
            services.AddTransient<ILapTimeParser, LapTimeParser>();
            services.AddTransient<ILapTimeService, LapTimeService>();
            services.AddTransient<ILapTimeDataFileWriter, LapTimeDataFileWriter>();

            return services;
        }
    }
}
