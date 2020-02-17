using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using RacerData.WinForms.Adapters;
using RacerData.WinForms.Dialogs;
using RacerData.WinForms.Factories;
using RacerData.WinForms.Ports;

namespace RacerData.WinForms
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddWinForms(this IServiceCollection services)
        {
            services.AddTransient<AppearanceEditorDialog, AppearanceEditorDialog>();
            services.TryAddTransient<IAppAppearanceRepository, AppAppearanceRepository>();

            services.TryAddTransient<IDialogService, DialogService>();
            services.TryAddTransient<IExceptionHandlerService, ExceptionHandlerService>();
            services.TryAddTransient<IViewControlFactory, ViewControlFactory>();
            services.TryAddTransient<IViewFactory, ViewFactory>();
            services.TryAddTransient<IViewGridControllerFactory, ViewGridControllerFactory>();

            services.TryAddTransient<IWeekendScheduleService, WeekendScheduleService>();
            services.TryAddTransient<IWeekendScheduleReader, WeekendScheduleReader>();
            services.TryAddTransient<IVideoChannelService, VideoChannelService>();
            services.TryAddTransient<IAudioChannelService, AudioChannelService>();
            services.TryAddTransient<ISeriesService, SeriesService>();
            services.TryAddTransient<IStaticDataService, StaticDataService>();
            services.TryAddTransient<ILiveDataService, LiveDataService>();
            services.TryAddTransient<IGraphDataService, GraphDataService>();
            services.TryAddTransient<IListDataService, ListDataService>();
            
            return services;
        }
    }
}
