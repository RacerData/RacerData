using System;
using System.Threading;

namespace RacerData.NascarApi.Service.Ports
{
    public interface IMonitorService
    {
        ServiceState State { get; }

        void Pause();
        void Start();
        void Start(CancellationToken cancellationToken);
        void Sleep();
        void Sleep(DateTime wakeTimestamp);
        void Sleep(TimeSpan wakeTimeSpan);

        void Register(IMonitorClient client);
        void Register(IMonitorClient client, ApiFeedType feedType);
        void Unregister(IMonitorClient client);
    }
}
