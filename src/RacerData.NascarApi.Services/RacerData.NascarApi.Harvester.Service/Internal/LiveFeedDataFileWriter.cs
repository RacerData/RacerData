using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RacerData.NascarApi.Client.Models;
using RacerData.NascarApi.Client.Models.LiveFeed;
using RacerData.NascarApi.Harvester.Service.Ports;

namespace RacerData.NascarApi.Harvester.Service.Internal
{
    class LiveFeedDataFileWriter : ILiveFeedDataFileWriter
    {
        #region properties

        public string RootDirectory { get; set; }
        public int? LastElapsedWritten { get; set; }

        #endregion

        #region ctor

        public LiveFeedDataFileWriter(
            IConfiguration configuration)
        {
            RootDirectory = configuration["harvester:rootDirectory"];
        }

        #endregion

        #region public

        public void WriteFile(LiveFeedData data)
        {
            WriteFile(RootDirectory, data);
        }

        public void WriteFile(string rootDirectory, LiveFeedData data)
        {
            var fileDirectory = GetFileDirectory(rootDirectory, data);

            var fileTitle = GetFileTitle(data);

            var fullFilePath = Path.Combine(fileDirectory, fileTitle);

            var fileContent = GetFileContent(data);

            File.WriteAllText(fullFilePath, fileContent);

            LastElapsedWritten = data.Elapsed;
        }

        #endregion

        #region protected

        protected virtual string GetFileDirectory(string rootDirectory, LiveFeedData data)
        {
            SeriesType seriesType = (data.SeriesType - 1);

            var series = seriesType.ToString();

            var track = data.TrackName;

            var runName = data.RunName;

            var eventDate = DateTime.Now.ToString("MM-dd-yyyy");

            var subDirectoryPath = $"{series}\\{track}\\{eventDate}\\{runName}";

            foreach (var c in Path.GetInvalidPathChars())
            {
                subDirectoryPath = subDirectoryPath.Replace(c.ToString(), "");
            }

            var fullFileDirectory = Path.Combine(rootDirectory, subDirectoryPath);

            if (!Directory.Exists(fullFileDirectory))
                Directory.CreateDirectory(fullFileDirectory);

            return fullFileDirectory;
        }

        protected virtual string GetFileTitle(LiveFeedData data)
        {
            var fileTitle = $"{data.SeriesType}-{data.RaceId}-{data.RunId}-{data.Elapsed}.json";

            return fileTitle;
        }

        protected virtual string GetFileContent(LiveFeedData data)
        {
            var fileContent = JsonConvert.SerializeObject(
                data,
                Formatting.Indented,
                new JsonSerializerSettings { NullValueHandling = NullValueHandling.Include });

            return fileContent;
        }

        #endregion
    }
}
