using System;
using AutoMapper;
using log4net;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RacerData.NascarApi.Harvester.Service;
using RacerData.NascarApi.LapAverage.Service;
using RacerData.NascarApi.Service;

namespace RacerData.LiveFeedMonitor
{
    static class ServiceProvider
    {
        private static IServiceProvider _instance;
        public static IServiceProvider Instance
        {
            get
            {
                if (_instance == null)
                    _instance = CreateServiceProvider();

                return _instance;
            }
            set
            {
                _instance = value;
            }
        }

        private static IServiceProvider CreateServiceProvider()
        {
            var services = new ServiceCollection();

            ILog log = LogManager.GetLogger("LiveFeedMonitor");

            log.Info("LiveFeedMonitor Started");

            IConfigurationRoot configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: true)
                .Build();

            services.AddSingleton<IConfiguration>(configuration);
            services.AddSingleton(log);
            services.AddNascarApiService();
            services.AddLapAverageService();
            services.AddHarvesterService();

            Mapper.Initialize(cfg => cfg.AddMaps(AppDomain.CurrentDomain.GetAssemblies()));

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            return services.BuildServiceProvider();
        }
    }
}
