using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RacerData.NascarApi.Client.Models;
using RacerData.NascarApi.Client.Models.LapAverages;
using RacerData.NascarApi.LapAverage.Service.Ports;

namespace RacerData.NascarApi.LapAverage.Service.Internal
{
    class LapAverageDataFileWriter : ILapAverageDataFileWriter
    {
        #region properties

        public string RootDirectory { get; set; }
        public int? LastElapsedWritten { get; set; }

        #endregion

        #region ctor

        public LapAverageDataFileWriter(
            IConfiguration configuration)
        {
            RootDirectory = configuration["harvester:lapAverageDirectory"];
        }

        #endregion

        #region public

        public void WriteFile(LapAverageData data)
        {
            WriteFile(RootDirectory, data);
        }

        public void WriteFile(string rootDirectory, LapAverageData data)
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

        protected virtual string GetFileDirectory(string rootDirectory, LapAverageData data)
        {
            SeriesType seriesType = (SeriesType)(data.SeriesId - 1);

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

        protected virtual string GetFileTitle(LapAverageData data)
        {
            var fileTitle = $"{data.SeriesId}-{data.RaceId}-{data.RunId}-{data.Elapsed}.json";

            return fileTitle;
        }

        protected virtual string GetFileContent(LapAverageData data)
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
