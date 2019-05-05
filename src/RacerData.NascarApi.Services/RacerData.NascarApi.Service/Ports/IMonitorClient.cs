using System;
using System.Collections.Generic;
using System.Text;

namespace RacerData.NascarApi.Service.Ports
{
    public interface IMonitorClient
    {
        void Monitor_LiveFeedStarted(object sender, LiveFeedStartedEventArgs e);
        void Monitor_LiveFeedUpdated(object sender, LiveFeedUpdatedEventArgs e);
        void Monitor_ServiceStateChanged(object sender, ServiceStateChangedEventArgs e);
        void Monitor_ServiceActivity(object sender, ServiceActivityEventArgs e);
        void Monitor_ServiceStatusChanged(object sender, ServiceActivityEventArgs e);
    }
}
