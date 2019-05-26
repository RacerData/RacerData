using System;
using Microsoft.Extensions.DependencyInjection;

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

            services.AddDialogService();

            return services.BuildServiceProvider();
        }
    }
}
