using RacerData.NascarApi.Client.Models.LiveFeed;

namespace RacerData.NascarApi.Harvester.Service.Ports
{
    interface ILiveFeedDataFileWriter
    {
        int? LastElapsedWritten { get; set; }
        string RootDirectory { get; set; }

        void WriteFile(LiveFeedData data);
        void WriteFile(string rootDirectory, LiveFeedData data);
    }
}