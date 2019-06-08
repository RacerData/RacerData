using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using RacerData.NascarApi.Client.Ports;
using Newtonsoft.Json;
using RacerData.NascarApi.Client.Models.LiveFeed;

namespace RacerData.NascarApi.TestApp
{

    class NascarApiIdReader : INascarApiIdReader
    {
        private const string RootFolder = @"C:\Users\Rob\Documents\RacerData\Harvested Data";

        private readonly INascarApiClient _client;
        private readonly IList<Track> _tracks = new List<Track>();
        private readonly IList<Race> _races = new List<Race>();
        private readonly IList<Run> _runs = new List<Run>();
        private readonly IList<Driver> _drivers = new List<Driver>();

        public NascarApiIdReader(INascarApiClientFactory factory)
        {
            _client = factory.GetNascarApiClient();
        }

        public NascarApiIdReader()
        {

        }

        public void ReadLocalIds()
        {
            try
            {
                ReadFolder(RootFolder);

                foreach (Race race in _races.OrderBy(r => r.Id))
                {
                    Console.WriteLine($"Race {race.Id} {race.SeriesType} { race.TrackName}");
                }
                Console.WriteLine("-------------------------------------");
                foreach (Track track in _tracks.OrderBy(r => r.Id))
                {
                    Console.WriteLine($"Track {track.Id} { track.Name}");
                }
                Console.WriteLine("-------------------------------------");
                foreach (Run run in _runs.OrderBy(r => r.Name))
                {
                    Console.WriteLine(run.Name);
                }
                Console.WriteLine("-------------------------------------");
                foreach (Driver driver in _drivers.OrderBy(r => r.Id))
                {
                    Console.WriteLine($"Driver {driver.Id} {driver.FirstName} { driver.LastName} - {driver.ShortName}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        protected virtual void ReadFolder(string folderPath)
        {
            foreach (string file in Directory.GetFiles(folderPath))
            {
                ReadFile(file);
            }

            foreach (string folder in Directory.GetDirectories(folderPath))
            {
                ReadFolder(folder);
            }
        }

        protected virtual void ReadFile(string filePath)
        {
            try
            {
                if (filePath.Contains("lapData"))
                    return;

                var json = File.ReadAllText(filePath);

                Console.WriteLine($"Reading {filePath}");

                var liveFeedData = JsonConvert.DeserializeObject<LiveFeedData>(json);

                ReadLiveFeedData(liveFeedData);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        protected virtual void ReadLiveFeedData(LiveFeedData liveFeedData)
        {
            ReadLiveFeedDataTrack(liveFeedData);
            ReadLiveFeedDataRace(liveFeedData);
            ReadLiveFeedDataRun(liveFeedData);
            ReadLiveFeedDataDriver(liveFeedData);
        }
        protected virtual void ReadLiveFeedDataDriver(LiveFeedData liveFeedData)
        {
            foreach (Vehicle vehicle in liveFeedData.Vehicles)
            {
                var driver = _drivers.FirstOrDefault(t => t.Id == vehicle.Driver.Id);

                if (driver == null)
                {
                    driver = new Driver()
                    {
                        Id = vehicle.Driver.Id,
                        FirstName = vehicle.Driver.FirstName,
                        LastName = vehicle.Driver.LastName,
                        ShortName = vehicle.Driver.ShortName
                    };

                    _drivers.Add(driver);
                }
            }
        }
        protected virtual void ReadLiveFeedDataRun(LiveFeedData liveFeedData)
        {
            var run = _runs.FirstOrDefault(t => t.Name == liveFeedData.RunType.ToString());

            if (run == null)
            {
                run = new Run()
                {
                    Name = liveFeedData.RunType.ToString()
                };

                _runs.Add(run);
            }
        }
        protected virtual void ReadLiveFeedDataRace(LiveFeedData liveFeedData)
        {
            var race = _races.FirstOrDefault(t => t.Id == liveFeedData.RaceId);

            if (race == null)
            {
                race = new Race()
                {
                    Id = liveFeedData.RaceId,
                    TrackId = liveFeedData.TrackId,
                    TrackName = liveFeedData.TrackName,
                    SeriesType = liveFeedData.SeriesType.ToString(),
                };

                _races.Add(race);
            }
        }
        protected virtual void ReadLiveFeedDataTrack(LiveFeedData liveFeedData)
        {
            var track = _tracks.FirstOrDefault(t => t.Id == liveFeedData.TrackId);

            if (track == null)
            {
                track = new Track()
                {
                    Id = liveFeedData.TrackId,
                    Name = liveFeedData.TrackName,
                    Length = liveFeedData.TrackLength
                };

                _tracks.Add(track);
            }
        }
    }

    public class Track
    {
        public int Id { get; set; }
        public double Length { get; set; }
        public string Name { get; set; }
    }
    public class Run
    {
        public string Name { get; set; }
    }
    public class Race
    {
        public int Id { get; set; }
        public int TrackId { get; set; }
        public string TrackName { get; set; }
        public string SeriesType { get; set; }
    }

    public class Driver
    {
        public int Id { get; set; }
        public int SeriesId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ShortName { get; set; }
    }
}
