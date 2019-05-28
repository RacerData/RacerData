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
using RacerData.NascarApi.Service;
using RacerData.rNascarApp.Dialogs;
using RacerData.rNascarApp.Factories;
using RacerData.rNascarApp.Services;
using RacerData.UpdaterService;
using RacerData.WinForms;
using Microsoft.Extensions.Options;

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
            services.AddSingleton(log);
            log.Info("rNascarApp Started");

            var configuration = new ConfigurationBuilder()
              .AddJsonFile("app.settings.json", false)
              .Build();

            services.AddOptions();
            services.Configure<DirectoryConfiguration>(configuration.GetSection("directories"));

            services.AddSingleton(configuration);
            services.AddSingleton<IConfiguration>(configuration);
            

            services.AddDialogService();
            services.AddExceptionHandlerService();

            services.AddTransient<ILocalUpdaterService, LocalUpdaterService>();
            services.AddSingleton<IViewDataSourceFactory>(new ViewDataSourceFactory());
            services.AddTransient<IDisplayFormatMapService, DisplayFormatMapService>();
            services.AddTransient<IViewDisplayFormatFactory, ViewDisplayFormatFactory>();
            services.AddTransient<IColumnBuilderService, ColumnBuilderService>();
            services.AddTransient<IColumnBuilderService, ColumnBuilderService2>();

            services.AddScoped<IWorkspaceService, WorkspaceService>();
            services.AddScoped<IStateService, StateService>();

            services.AddTransient<WorkspaceManagementDialog, WorkspaceManagementDialog>();
            services.AddTransient<ViewManagementDialog, ViewManagementDialog>();
            services.AddTransient<DisplayFormatMapDialog, DisplayFormatMapDialog>();
            services.AddTransient<CreateViewWizard, CreateViewWizard>();

            services.AddCommon();
            services.AddNascarApiService();
            services.AddAwsData();
            services.AddUpdateService();

            Mapper.Initialize(cfg => cfg.AddMaps(AppDomain.CurrentDomain.GetAssemblies()));

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            return services.BuildServiceProvider();
        }
    }
}
