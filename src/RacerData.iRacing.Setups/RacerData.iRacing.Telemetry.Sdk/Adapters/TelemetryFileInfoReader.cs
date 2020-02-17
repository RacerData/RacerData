using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RacerData.iRacing.Telemetry.Extensions;
using RacerData.iRacing.Telemetry.Sdk.Factories;
using RacerData.iRacing.Telemetry.Sdk.Internal;
using RacerData.iRacing.Telemetry.Sdk.Models;

namespace RacerData.iRacing.Telemetry.Sdk.Adapters
{
    public static class TelemetryFileInfoReader
    {
        static IList<string> tracks;
        static IList<string> vehicles;

        static string telemetrySessionDirectory = @"C:\iRacingData\telemetry";

        public static IList<TelemetryFileInfo> TelemetryIndex { get; set; } = new List<TelemetryFileInfo>();

        public static IList<TelemetryFileInfo> ParseTelemetryFiles(IList<string> files)
        {
            vehicles = GetVehicleList();
            tracks = GetTrackList();

            TelemetryIndex = new List<TelemetryFileInfo>();

            foreach (string file in files)
            {
                TelemetryIndex.Add(IndexTelemetryFile(file));
            }

            return TelemetryIndex;
        }

        public static IList<TelemetryFileInfo> ParseTelemetryFiles()
        {
            vehicles = GetVehicleList();
            tracks = GetTrackList();

            TelemetryIndex = new List<TelemetryFileInfo>();

            IndexTelemetryDirectory(telemetrySessionDirectory);

            return TelemetryIndex;
        }

        private static void IndexTelemetryDirectory(string directory)
        {
            var directories = Directory.GetDirectories(directory);

            foreach (var directoryPath in directories)
            {
                IndexTelemetryDirectory(directoryPath);
            }

            var files = Directory.GetFiles(directory);

            foreach (var filePath in files)
            {
                var telemetryFileInfo = IndexTelemetryFile(filePath);

                TelemetryIndex.Add(telemetryFileInfo);
            }
        }

        private static TelemetryFileInfo IndexTelemetryFile(string filePath)
        {
            TelemetryFileInfo telemetry = new TelemetryFileInfo();

            try
            {
                telemetry.FullPath = filePath;

                FileInfo telemetryFileInfo = new FileInfo(filePath);

                telemetry.Name = Path.GetFileNameWithoutExtension(telemetryFileInfo.Name);
                telemetry.Size = telemetryFileInfo.Length;

                ITelemetryFileReader reader = TelemetryFileReaderFactory.GetTelemetryFileReader(telemetry.FullPath);

                var sessionInfo = reader.ReadTelemetrySession();

                var timestamp = telemetry.Name.ParseDateTimeFromFileName();
                telemetry.SeasonId = sessionInfo.SessionInfo.WeekendInfo.SeasonID;
                telemetry.SeriesId = sessionInfo.SessionInfo.WeekendInfo.SeriesID;
                telemetry.SessionId = sessionInfo.SessionInfo.WeekendInfo.SessionID;
                telemetry.SubSessionId = sessionInfo.SessionInfo.WeekendInfo.SubSessionID;
                telemetry.ActiveSessionIndex = sessionInfo.SessionInfo.ActiveSession.SessionNum;
                telemetry.EventType = GetEventType(sessionInfo.SessionInfo.WeekendInfo.EventType);
                telemetry.SessionType = GetSessionType(sessionInfo.SessionInfo.ActiveSession.SessionType);
                var driverIndex = sessionInfo.SessionInfo.DriverInfo.DriverCarIdx;
                var resultsPosition = sessionInfo.SessionInfo.ActiveSession.ResultsPositions.FirstOrDefault(r => r.CarIdx == driverIndex);
                telemetry.LapsCompleted = resultsPosition != null ? resultsPosition.LapsComplete : 0;
                telemetry.Date = sessionInfo.SessionInfo.WeekendInfo.WeekendOptions.Date == null ||
                    String.IsNullOrEmpty(sessionInfo.SessionInfo.WeekendInfo.WeekendOptions.Date) ?
                    timestamp.ToString("yyyy-MM-dd") :
                    sessionInfo.SessionInfo.WeekendInfo.WeekendOptions.Date;
                telemetry.TimeOfDay = sessionInfo.SessionInfo.WeekendInfo.WeekendOptions.TimeOfDay == null ||
                    String.IsNullOrEmpty(sessionInfo.SessionInfo.WeekendInfo.WeekendOptions.TimeOfDay) ?
                        timestamp.ToString("h:mm tt") :
                        sessionInfo.SessionInfo.WeekendInfo.WeekendOptions.TimeOfDay;
                telemetry.Timestamp = timestamp;
                var seasonWeek = SeasonWeekCalculator.GetSeasonWeek(timestamp);
                telemetry.Year = seasonWeek.Year;
                telemetry.Season = seasonWeek.Season;
                telemetry.Week = seasonWeek.Week;
                telemetry.VehicleId = sessionInfo.SessionInfo.DriverInfo.DriversCar.CarID;
                telemetry.Vehicle = sessionInfo.SessionInfo.DriverInfo.DriversCar.CarPath;
                telemetry.TrackId = sessionInfo.SessionInfo.WeekendInfo.TrackID;
                telemetry.Track = sessionInfo.SessionInfo.WeekendInfo.TrackName;
            }
            catch (Exception ex)
            {
                telemetry.Error = ex;
            }

            return telemetry;
        }

        private static SessionType GetSessionType(string sessionTypeName)
        {
            if (sessionTypeName == "Offline Testing")
                return SessionType.Test;
            else if (sessionTypeName == "Practice")
                return SessionType.Practice;
            else if (sessionTypeName == "Lone Qualify")
                return SessionType.Qualifying;
            else if (sessionTypeName == "Heat Race")
                return SessionType.HeatRace;
            else if (sessionTypeName == "Race")
                return SessionType.Race;
            else
                throw new ArgumentException(nameof(sessionTypeName));
        }
        private static EventType GetEventType(string value)
        {
            if (value == "Test")
            {
                return EventType.Test;
            }
            else if (value == "Practice")
            {
                return EventType.Practice;
            }
            else if (value == "Race")
            {
                return EventType.Race;
            }
            else if (value == "Time Trial")
            {
                return EventType.TimeTrial;
            }
            else
            {
                throw new ArgumentException($"Unrecognized WeekendInfo.EventType: {value}");
            }
        }
        private static IList<string> GetTrackList()
        {
            var tracks = new List<string>();

            tracks.Add("okayama full");
            tracks.Add("southboston");
            tracks.Add("fiveflags");
            tracks.Add("newsmyrna");
            tracks.Add("southernnational");
            tracks.Add("lanier");
            tracks.Add("martinsville");
            tracks.Add("rockingham oval");
            tracks.Add("oxford oval");
            tracks.Add("bristol");
            tracks.Add("concordhalf"); ;
            tracks.Add("langley");
            tracks.Add("thompson");
            tracks.Add("irp");
            tracks.Add("irwindale outer");
            tracks.Add("lakeland");
            tracks.Add("newhampshire oval");
            tracks.Add("richmond");
            tracks.Add("skidpad");
            tracks.Add("skidpad");
            tracks.Add("southboston");
            tracks.Add("stafford oval");
            tracks.Add("talladega");
            tracks.Add("milwaukee");
            tracks.Add("phoenix oval");
            tracks.Add("eldora");
            tracks.Add("lanier dirt");
            tracks.Add("myrtlebeach");
            tracks.Add("lakeland");
            tracks.Add("iowa oval");
            tracks.Add("daytona 2011 road");
            tracks.Add("limerock full");
            tracks.Add("sebring international");
            tracks.Add("bullring");
            tracks.Add("charlotte 2018 legendsoval");
            tracks.Add("irwindale outerinner");

            return tracks;
        }
        private static IList<string> GetVehicleList()
        {
            var vehicles = new List<string>();

            vehicles.Add("mx5 cup");
            vehicles.Add("latemodel");
            vehicles.Add("skmodified");
            vehicles.Add("superlatemodel");
            vehicles.Add("skmodified tour");
            vehicles.Add("fr500s");
            vehicles.Add("legends ford34c");
            vehicles.Add("stockcars fordfusion");
            vehicles.Add("stockcars impala");
            vehicles.Add("stockcars2 chevy cot");
            vehicles.Add("stockcars2 chevy");
            vehicles.Add("stockcars2 nwford2013");
            vehicles.Add("streetstock");
            vehicles.Add("trucks silverado2015");
            vehicles.Add("trucks silverado");
            vehicles.Add("dirtstreetstock");
            vehicles.Add("dirtsprint winged 305");
            vehicles.Add("mercedesamggt3");
            vehicles.Add("rt2000");

            return vehicles;
        }
    }
}
