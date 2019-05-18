using System;
using AutoMapper;
using log4net;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RacerData.Data.Aws;
using RacerData.NascarApi.Service;
using RacerData.rNascarApp.Dialogs;
using RacerData.rNascarApp.Factories;
using RacerData.rNascarApp.Services;
using RacerData.UpdaterService;

namespace RacerData.rNascarApp
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

            log.Info("rNascarApp Started");

            IConfigurationRoot configuration = new ConfigurationBuilder()
                .AddJsonFile("app.settings.json", optional: true)
                .Build();

            services.AddSingleton<IConfiguration>(configuration);
            services.AddSingleton(log);

            services.AddSingleton<IFileService>(new FileService());
            services.AddSingleton<IViewDataSourceFactory>(new ViewDataSourceFactory());
            services.AddTransient<IDisplayFormatMapService, DisplayFormatMapService>();
            services.AddTransient<IViewDisplayFormatFactory, ViewDisplayFormatFactory>();
            services.AddTransient<IColumnBuilderService, ColumnBuilderService>();
            services.AddTransient<IColumnBuilderService, ColumnBuilderService2>();


            services.AddScoped<IWorkspaceService, WorkspaceService>();
            services.AddScoped<IStateService, StateService>();
            services.AddScoped<IRevertableService, RevertableService>();

            services.AddTransient<IDirectoryService, DirectoryService>();
            services.AddTransient<ISerializer, Serializer>();

            services.AddTransient<WorkspaceManagementDialog, WorkspaceManagementDialog>();
            services.AddTransient<ViewManagementDialog, ViewManagementDialog>();
            services.AddTransient<DisplayFormatMapDialog, DisplayFormatMapDialog>();
            services.AddTransient<CreateViewWizard, CreateViewWizard>();

            services.AddNascarApiService();
            services.AddAwsData();
            services.AddUpdateService();

            Mapper.Initialize(cfg => cfg.AddMaps(AppDomain.CurrentDomain.GetAssemblies()));

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            return services.BuildServiceProvider();
        }
    }
}
