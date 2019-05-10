using System;
using RacerData.NascarApi.Client.Models.LiveFeed;

namespace RacerData.NascarApi.Service
{
    public class LiveFeedUpdatedEventArgs : EventArgs
    {
        public ApiFeedType ApiFeedType { get => ApiFeedType.LiveFeedData; }
        public LiveFeedData LiveFeedData { get; set; }
    }
}
