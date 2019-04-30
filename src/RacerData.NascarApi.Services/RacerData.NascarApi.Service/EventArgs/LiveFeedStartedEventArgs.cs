using System;
using RacerData.NascarApi.Client.Models.LiveFeed;

namespace RacerData.NascarApi.Service
{
    public class LiveFeedStartedEventArgs : EventArgs
    {
        public LiveFeedInfo LiveFeedInfo { get; set; }
    }
}
