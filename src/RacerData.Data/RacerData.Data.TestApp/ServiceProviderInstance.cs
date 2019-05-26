using System;
using log4net;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RacerData.Commmon;
using RacerData.Data.Aws;

namespace RacerData.Data.TestApp
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

            ILog log = LogManager.GetLogger("RacerDataTestApp");

            log.Info("RacerData.Data.TestApp Started");

            IConfigurationRoot configuration = new ConfigurationBuilder()
                .AddJsonFile("app.settings.json", optional: true)
                .Build();

            services.AddSingleton<IConfiguration>(configuration);
            services.AddSingleton(log);

            services.AddCommon();
            services.AddAwsData();

            return services.BuildServiceProvider();
        }
    }
}
