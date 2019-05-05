using System;

namespace RacerData.NascarApi.Service
{
    public class ServiceStatusChangedEventArgs : EventArgs
    {
        public string ServiceStatus { get; set; }
    }
}
