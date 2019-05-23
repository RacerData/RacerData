using System;
using log4net;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RacerData.Commmon;
using RacerData.Common.Models;
using RacerData.Themes.UI;

namespace RacerData.Themes.TestApp
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

            ILog log = LogManager.GetLogger("ThemesTestApp");

            log.Info("Themes TestApp Started");

            var configuration = new ConfigurationBuilder()
              .AddJsonFile("app.settings.json", false)
              .Build();

            services.AddOptions();
            services.Configure<DirectoryConfiguration>(configuration.GetSection("directories"));

            services.AddSingleton(configuration);
            services.AddSingleton<IConfiguration>(configuration);
            services.AddSingleton(log);

            services.AddThemes();
            services.AddThemesUI();
            services.AddCommon();

            return services.BuildServiceProvider();
        }
    }
}
