using RacerData.NascarApi.Service.Ports;

namespace RacerData.NascarApi.Service.Adapters
{
    public abstract class MonitorClientBase : IMonitorClient
    {
        public virtual void Monitor_LapAveragesUpdated(object sender, LapAveragesUpdatedEventArgs e)
        {
            
        }

        public virtual void Monitor_LapTimesUpdated(object sender, LapTimesUpdatedEventArgs e)
        {
            
        }

        public virtual void Monitor_LiveFeedStarted(object sender, LiveFeedStartedEventArgs e)
        {
            
        }

        public virtual void Monitor_LiveFeedUpdated(object sender, LiveFeedUpdatedEventArgs e)
        {
            
        }

        public virtual void Monitor_LiveFlagDataUpdated(object sender, LiveFlagDataUpdatedEventArgs e)
        {
            
        }

        public virtual void Monitor_LivePitDataUpdated(object sender, LivePitDataUpdatedEventArgs e)
        {
            
        }

        public virtual void Monitor_LivePointsDataUpdated(object sender, LivePointsDataUpdatedEventArgs e)
        {
            
        }

        public virtual void Monitor_LiveQualifyingDataUpdated(object sender, LiveQualifyingDataUpdatedEventArgs e)
        {
            
        }

        public virtual void Monitor_ServiceActivity(object sender, ServiceActivityEventArgs e)
        {
            
        }

        public virtual void Monitor_ServiceStateChanged(object sender, ServiceStateChangedEventArgs e)
        {
            
        }

        public virtual void Monitor_ServiceStatusChanged(object sender, ServiceActivityEventArgs e)
        {
            
        }
    }
}
