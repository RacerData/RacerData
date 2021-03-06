﻿using System;
using System.Threading;

namespace RacerData.NascarApi.Service.Ports
{
    public interface IMonitorService
    {
        event EventHandler<LiveFeedStartedEventArgs> LiveFeedStarted;
        event EventHandler<LiveFeedUpdatedEventArgs> LiveFeedUpdated;
        event EventHandler<ServiceStateChangedEventArgs> ServiceStateChanged;
        event EventHandler<ServiceActivityEventArgs> ServiceActivity;
        event EventHandler<ServiceStatusChangedEventArgs> ServiceStatusChanged;

        ServiceState State { get; }

        void Pause();
        void Start();
        void Start(CancellationToken cancellationToken);
        void Sleep();
        void Sleep(DateTime wakeTimestamp);
        void Sleep(TimeSpan wakeTimeSpan);

        void Register(IMonitorClient client);
        void Unregister(IMonitorClient client);
    }
}
