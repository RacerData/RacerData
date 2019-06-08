using System;
using System.IO;
using System.Reflection;
using AutoMapper;
using log4net;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RacerData.Commmon;
using RacerData.Common.Models;
using RacerData.Data.Aws;
using Microsoft.Extensions.Options;

namespace RacerData.NascarApi.TestApp
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

            ILog log = LogManager.GetLogger("rNascarApp");
            services.AddSingleton(log);
            log.Info("rNascarApp Started");

            var configuration = new ConfigurationBuilder()
              .AddJsonFile("app.settings.json", false)
              .Build();

            services.AddOptions();
            services.Configure<DirectoryConfiguration>(configuration.GetSection("directories"));

            services.AddSingleton(configuration);
            services.AddSingleton<IConfiguration>(configuration);

            services.AddCommon();
            services.AddAwsData();

            Mapper.Initialize(cfg => cfg.AddMaps(AppDomain.CurrentDomain.GetAssemblies()));

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddTransient<INascarApiIdReader, NascarApiIdReader>();

            return services.BuildServiceProvider();
        }
    }
}
