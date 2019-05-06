using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RacerData.NascarApi.Client.Models;
using RacerData.NascarApi.Client.Models.LapTimes;

namespace RacerData.NascarApi.LapTimes.Service.Internal
{
    class LapTimeDataFileWriter : ILapTimeDataFileWriter
    {
        #region properties

        public string RootDirectory { get; set; }
        public int? LastElapsedWritten { get; set; }

        #endregion

        #region ctor

        public LapTimeDataFileWriter(
            IConfiguration configuration)
        {
            RootDirectory = configuration["harvester:lapTimeDirectory"];
        }

        #endregion

        #region public

        public void WriteFile(EventVehicleLapTimes data)
        {
            WriteFile(RootDirectory, data);
        }

        public void WriteFile(string rootDirectory, EventVehicleLapTimes data)
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

        protected virtual string GetFileDirectory(string rootDirectory, EventVehicleLapTimes data)
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

        protected virtual string GetFileTitle(EventVehicleLapTimes data)
        {
            var fileTitle = $"{data.SeriesId}-{data.RaceId}-{data.RunId}-{data.Elapsed}.json";

            return fileTitle;
        }

        protected virtual string GetFileContent(EventVehicleLapTimes data)
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
