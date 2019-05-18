using System;
using log4net;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RacerData.UpdaterService;

namespace RacerData.Updater.UI
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

            ILog log = LogManager.GetLogger("RacerData.Updater");

            log.Info("RacerData.Updater");

            IConfigurationRoot configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: true)
                .Build();

            services.AddSingleton<IConfiguration>(configuration);
            services.AddSingleton(log);

            services.AddUpdateService();

            return services.BuildServiceProvider();
        }
    }
}
