using System;

namespace RacerData.NascarApi.Service.Ports
{
    public interface IMonitorService
    {
        event EventHandler<LiveFeedStartedEventArgs> LiveFeedStarted;
        event EventHandler<LiveFeedUpdatedEventArgs> LiveFeedUpdated;
        event EventHandler<ServiceStateChangedEventArgs> ServiceStateChanged;
        event EventHandler<ServiceActivityEventArgs> ServiceActivity;

        ServiceState State { get; }

        void Pause();
        void Start();
        void Sleep();
        void Sleep(DateTime wakeTimestamp);
        void Sleep(TimeSpan wakeTimeSpan);

        void Register(IMonitorClient client);
        void Unregister(IMonitorClient client);
    }
}
