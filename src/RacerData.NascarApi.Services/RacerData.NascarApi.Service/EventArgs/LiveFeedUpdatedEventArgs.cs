using System;
using RacerData.NascarApi.Client.Models.LiveFeed;

namespace RacerData.NascarApi.Service
{
    public class LiveFeedUpdatedEventArgs : EventArgs
    {
        public LiveFeedData LiveFeedData { get; set; }
    }
}
