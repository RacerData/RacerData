using System;
using log4net;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RacerData.Commmon;
using RacerData.Common.Models;
using RacerData.WinForms.Themes;

namespace RacerData.WinForms
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

            ILog log = LogManager.GetLogger("WinForms.TestApp");
            services.AddSingleton(log);

            var configuration = new ConfigurationBuilder()
            .AddJsonFile("app.settings.json", false)
            .Build();
            services.AddOptions();
            services.Configure<DirectoryConfiguration>(configuration.GetSection("directories"));

            services.AddCommon();
            services.AddDialogService();
            services.AddThemes();

            services.AddTransient<AppearanceEditorDialog, AppearanceEditorDialog>();

            return services.BuildServiceProvider();
        }
    }
}
