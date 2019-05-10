namespace RacerData.NascarApi.Service.Ports
{
    public interface IMonitorClient
    {
        void Monitor_LiveFeedStarted(object sender, LiveFeedStartedEventArgs e);
        void Monitor_ServiceStateChanged(object sender, ServiceStateChangedEventArgs e);
        void Monitor_ServiceActivity(object sender, ServiceActivityEventArgs e);
        void Monitor_ServiceStatusChanged(object sender, ServiceActivityEventArgs e);

        void Monitor_LiveFeedUpdated(object sender, LiveFeedUpdatedEventArgs e);
        void Monitor_LapAveragesUpdated(object sender, LapAveragesUpdatedEventArgs e);
        void Monitor_LapTimesUpdated(object sender, LapTimesUpdatedEventArgs e);
        void Monitor_LivePointsDataUpdated(object sender, LivePointsDataUpdatedEventArgs e);
        void Monitor_LivePitDataUpdated(object sender, LivePitDataUpdatedEventArgs e);
        void Monitor_LiveFlagDataUpdated(object sender, LiveFlagDataUpdatedEventArgs e);
        void Monitor_LiveQualifyingDataUpdated(object sender, LiveQualifyingDataUpdatedEventArgs e);
    }
}
