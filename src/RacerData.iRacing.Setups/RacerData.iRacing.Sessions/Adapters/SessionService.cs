using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using RacerData.iRacing.Extensions;
using RacerData.iRacing.Sessions.Internal;
using RacerData.iRacing.Sessions.Models;
using RacerData.iRacing.Sessions.Ports;
using RacerData.iRacing.Telemetry;
using RacerData.iRacing.Telemetry.Sdk.Factories;
using YamlDotNet.Serialization;

namespace RacerData.iRacing.Sessions.Adapters
{
    internal class SessionService : ISessionService
    {
        #region fields
        IRunRepository _runRepository;
        IVehicleRepository _vehicleRepository;
        ITrackRepository _trackRepository;
        IDriverRepository _driverRepository;
        ISetupRepository _setupRepository;
        ISessionRepository _sessionRepository;
        ITelemetryRepository _telemetryRepository;
        #endregion

        #region ctor
        public SessionService(
            IRunRepository runRepository,
            IVehicleRepository vehicleRepository,
            ITrackRepository trackRepository,
            IDriverRepository driverRepository,
            ISetupRepository setupRepository,
            ISessionRepository sessionRepository,
            ITelemetryRepository telemetryRepository)
        {
            _runRepository = runRepository ?? throw new ArgumentNullException(nameof(runRepository));
            _vehicleRepository = vehicleRepository ?? throw new ArgumentNullException(nameof(vehicleRepository));
            _trackRepository = trackRepository ?? throw new ArgumentNullException(nameof(trackRepository));
            _driverRepository = driverRepository ?? throw new ArgumentNullException(nameof(driverRepository));
            _setupRepository = setupRepository ?? throw new ArgumentNullException(nameof(setupRepository));
            _sessionRepository = sessionRepository ?? throw new ArgumentNullException(nameof(sessionRepository));
            _telemetryRepository = telemetryRepository ?? throw new ArgumentNullException(nameof(telemetryRepository));
        }
        #endregion

        #region public

        public async Task ImportTelemetry(TelemetryFileInfo telemetryFileInfo)
        {
            var telemetryFileReader = TelemetryFileReaderFactory.GetTelemetryFileReader(telemetryFileInfo.FullPath);

            ITelemetryFile telemetryFile = await telemetryFileReader.ReadTelemetryFileAsync();

            string telemetryFileName = Path.GetFileName(telemetryFileInfo.FullPath);

            TelemetryData telemetryData = await _telemetryRepository.GetTelemetryAsync(telemetryFileName);

            if (telemetryData == null)
            {
                telemetryData = new TelemetryData()
                {
                    FileName = telemetryFileName,
                    FullPath = telemetryFileInfo.FullPath,
                    Timestamp = telemetryFileInfo.Timestamp,
                    // TODO: Data = telemetryFileReader.TelemetryFileBytes
                };

                telemetryData = await _telemetryRepository.InsertTelemetryAsync(telemetryData);
            }

            Run sessionRun = _runRepository.GetRun(telemetryData.FileName);

            if (sessionRun == null)
            {
                int driverCarIndex = telemetryFile.SessionInfo.DriverInfo.DriverCarIdx;

                Driver driver = await GetDriverAsync(_driverRepository, telemetryFile);

                Vehicle vehicle = await GetVehicleAsync(_vehicleRepository, telemetryFileInfo, telemetryFile);

                Track track = await GetTrackAsync(_trackRepository, telemetryFileInfo, telemetryFile);

                Setup setup = null;
                if (!String.IsNullOrEmpty(telemetryFile.SessionInfo.DriverInfo.DriverSetupName))
                {
                    setup = await GetSetupAsync(_setupRepository, telemetryFileInfo, telemetryFile);
                }

                SessionTime sessionTime = GetSessionTime(telemetryFileInfo);

                SessionTrackState sessionTrackState = GetSessionTrackState(telemetryFile.SessionInfo.ActiveSession.SessionTrackRubberState);

                int i = 0;
                sessionRun = new Run();

                sessionRun.RunTime = telemetryFileInfo.Timestamp;
                sessionRun.DriverId = driver.Id;
                sessionRun.Date = telemetryFileInfo.Date;
                sessionRun.TimeOfDay = telemetryFileInfo.TimeOfDay;
                sessionRun.SessionTimeId = sessionTime.Id;
                sessionRun.Year = telemetryFileInfo.Year;
                sessionRun.Season = telemetryFileInfo.Season;
                sessionRun.Week = telemetryFileInfo.Week;
                sessionRun.SeasonId = telemetryFileInfo.SeasonId;
                sessionRun.SeriesId = telemetryFileInfo.SeriesId;
                sessionRun.SessionId = telemetryFileInfo.SessionId;
                sessionRun.SubSessionId = telemetryFileInfo.SubSessionId;
                sessionRun.EventType = telemetryFileInfo.EventType;
                sessionRun.VehicleId = vehicle.Id;
                sessionRun.TrackId = track.Id;
                sessionRun.LapsComplete = GetLapsComplete(telemetryFile);
                sessionRun.SetupId = setup?.Id;
                sessionRun.TelemetryId = telemetryData.Id;
                sessionRun.TireSheet = GetTireSheet(telemetryFile);
                sessionRun.AirTemp = telemetryFile.SessionInfo.WeekendInfo.TrackAirTemp.CelciusToFarenheit();
                sessionRun.TrackTemp = telemetryFile.SessionInfo.WeekendInfo.TrackSurfaceTemp.CelciusToFarenheit();
                sessionRun.TrackState = telemetryFile.SessionInfo.ActiveSession.SessionTrackRubberState;
                sessionRun.TrackStateId = sessionTrackState.Id;
                sessionRun.Sky = telemetryFile.SessionInfo.WeekendInfo.TrackSkies;
                sessionRun.Laps = telemetryFile.Laps.Select(l =>
                    new Lap()
                    {
                        LapNumber = i++,
                        OverallLapNumber = l.LapNumber,
                        LapTime = l.LapTime,
                        LapSpeed = l.LapSpeed
                    }).ToList();


                if (!String.IsNullOrEmpty(setup?.SetupData))
                {
                    sessionRun = SetRunSetupValues(sessionRun, setup);
                }

                sessionRun = await _runRepository.InsertRunAsync(sessionRun);
            }
        }

        #endregion

        #region protected

        protected virtual int GetLapsComplete(ITelemetryFile telemetryFile)
        {
            int lapsComplete = 0;
            int driverCarIndex = telemetryFile.SessionInfo.DriverInfo.DriverCarIdx;

            IResultsPosition resultsPosition = telemetryFile.
                SessionInfo.
                ActiveSession.
                ResultsPositions.FirstOrDefault(r => r.CarIdx == driverCarIndex);

            if (resultsPosition != null)
                lapsComplete = resultsPosition.LapsComplete;

            return lapsComplete;
        }

        protected virtual SessionTime GetSessionTime(TelemetryFileInfo telemetryFileInfo)
        {
            if (telemetryFileInfo.TimeOfDay == "variable")
            {
                return _sessionRepository.GetVariableSessionTimeOfDay();
            }
            else
            {
                TimeSpan timeOfDay = String.IsNullOrEmpty(telemetryFileInfo.TimeOfDay) ?
                  telemetryFileInfo.Timestamp.TimeOfDay :
                  DateTime.ParseExact(telemetryFileInfo.TimeOfDay, "h:mm tt", CultureInfo.InvariantCulture).TimeOfDay;

                return _sessionRepository.GetSessionTimeOfDay(timeOfDay);
            }
        }

        protected virtual SessionTrackState GetSessionTrackState(string trackState)
        {
            return _sessionRepository.GetSessionTrackState(trackState);
        }

        protected virtual Run SetRunSetupValues(Run sessionRun, Setup setup)
        {
            // get setup settings
            SetupValuesDictionary settingsDictionary = ParseSetupYaml(setup);

            sessionRun.SetupValues = new List<SetupValue>();

            foreach (SetupValuesDictionaryItem setupValue in settingsDictionary.Settings)
            {
                try
                {
                    var conversion = TelemetryValueConverter.ConvertSetupValue(setupValue.Name, setupValue.Value);

                    sessionRun.SetupValues.Add(new SetupValue()
                    {
                        Property = new SetupProperty()
                        {
                            Name = setupValue.Name,
                            DataType = conversion.DataType,
                            Path = new SetupPropertyPath()
                            {
                                Path = setupValue.Path,
                            },
                            Units = conversion.Units
                        },
                        RawValue = setupValue.Value,
                        Value = (float)Math.Round(conversion.ConvertedFloat, 3)
                    });
                }
                catch (Exception ex)
                {
                    throw new Exception($"Error parsing setup property {setupValue.Path}.{setupValue.Name} having value {setupValue.Value}: {ex.Message}", ex);
                }
            }

            return sessionRun;
        }

        #endregion

        #region private

        private SetupValuesDictionary ParseSetupYaml(Setup setup)
        {
            StringReader yamlReader = new StringReader(setup.SetupData);

            Deserializer deserializer = new Deserializer();

            IDictionary<object, object> setupDataDictionaries = deserializer.Deserialize<IDictionary<object, object>>(yamlReader);

            SetupValuesDictionary settings = new SetupValuesDictionary(setupDataDictionaries);

            return settings;
        }

        // Setup
        private async Task<Setup> GetSetupAsync(
            ISetupRepository setupRepository,
            TelemetryFileInfo telemetryFileInfo,
            ITelemetryFile telemetryFile)
        {
            Setup setup = await setupRepository.GetSetupAsync(
                telemetryFileInfo.VehicleId,
                telemetryFile.SessionInfo.DriverInfo.DriverSetupName,
                telemetryFile.SessionInfo.CarSetup.UpdateCount);

            if (setup == null)
            {
                setup = new Setup()
                {
                    Name = telemetryFile.SessionInfo.DriverInfo.DriverSetupName,
                    UpdateCount = telemetryFile.SessionInfo.CarSetup.UpdateCount,
                    SetupData = telemetryFile.SessionInfo.CarSetup.SetupYaml,
                    VehicleId = telemetryFileInfo.VehicleId
                };

                setup = await setupRepository.InsertSetupAsync(setup);
            }

            return setup;
        }

        // Driver
        private async Task<Driver> GetDriverAsync(IDriverRepository driverRepository, ITelemetryFile telemetryFile)
        {
            string driverName = null;
            int? driverId = null;
            int driverCarIndex = telemetryFile.SessionInfo.DriverInfo.DriverCarIdx;

            IDriver driverInfo = telemetryFile.SessionInfo.DriverInfo.Drivers[driverCarIndex];

            if (driverInfo != null)
            {
                driverId = driverInfo.UserID > 0 ? driverInfo.UserID : default(int?);
                if (driverId.HasValue)
                    driverName = driverInfo.UserName;
            }

            Driver driver = await driverRepository.GetDriverAsync(driverId.Value);

            if (driver == null)
            {
                driver = new Driver()
                {
                    Id = driverId.Value,
                    Name = driverName
                };

                driver = await driverRepository.InsertDriverAsync(driver);
            }

            return driver;
        }

        // Track
        private async Task<Track> GetTrackAsync(ITrackRepository trackRepository, TelemetryFileInfo telemetryFileInfo, ITelemetryFile telemetryFile)
        {
            Track track = await trackRepository.GetTrackAsync(telemetryFileInfo.TrackId);

            if (track == null)
            {
                track = new Track()
                {
                    Id = telemetryFileInfo.TrackId,
                    Name = telemetryFileInfo.Track,
                    Length = GetTrackLengthMiles(telemetryFile.SessionInfo.WeekendInfo.TrackLength),
                    DisplayName = telemetryFile.SessionInfo.WeekendInfo.TrackDisplayName,
                    DisplayShortName = telemetryFile.SessionInfo.WeekendInfo.TrackDisplayShortName,
                    ConfigName = telemetryFile.SessionInfo.WeekendInfo.TrackConfigName,
                    TrackType = telemetryFile.SessionInfo.WeekendInfo.TrackType
                };

                track = await trackRepository.InsertTrackAsync(track);
            }
            else if (String.IsNullOrEmpty(track.ConfigName))
            {
                track.DisplayName = telemetryFile.SessionInfo.WeekendInfo.TrackDisplayName;
                track.DisplayShortName = telemetryFile.SessionInfo.WeekendInfo.TrackDisplayShortName;
                track.ConfigName = telemetryFile.SessionInfo.WeekendInfo.TrackConfigName;
                track.TrackType = telemetryFile.SessionInfo.WeekendInfo.TrackType;

                track = await trackRepository.UpdateTrackAsync(track);
            }

            return track;
        }

        // Vehicle
        private async Task<Vehicle> GetVehicleAsync(IVehicleRepository vehicleRepository, TelemetryFileInfo telemetryFileInfo, ITelemetryFile telemetryFile)
        {
            Vehicle vehicle = await vehicleRepository.GetVehicleAsync(telemetryFileInfo.VehicleId);

            if (vehicle == null)
            {
                vehicle = new Vehicle()
                {
                    Id = telemetryFileInfo.VehicleId,
                    ScreenName = telemetryFile.SessionInfo.DriverInfo.DriversCar.CarScreenName,
                    ScreenNameShort = telemetryFile.SessionInfo.DriverInfo.DriversCar.CarScreenNameShort,
                    ClassShortName = String.IsNullOrEmpty(telemetryFile.SessionInfo.DriverInfo.DriversCar.CarClassShortName) ?
                        telemetryFile.SessionInfo.DriverInfo.DriversCar.CarScreenName :
                        telemetryFile.SessionInfo.DriverInfo.DriversCar.CarClassShortName,
                    Path = telemetryFile.SessionInfo.DriverInfo.DriversCar.CarPath
                };

                vehicle = await vehicleRepository.InsertVehicleAsync(vehicle);
            }
            else if (String.IsNullOrEmpty(vehicle.Path))
            {
                vehicle.ScreenName = telemetryFile.SessionInfo.DriverInfo.DriversCar.CarScreenName;
                vehicle.ScreenNameShort = telemetryFile.SessionInfo.DriverInfo.DriversCar.CarScreenNameShort;
                vehicle.ClassShortName = String.IsNullOrEmpty(telemetryFile.SessionInfo.DriverInfo.DriversCar.CarClassShortName) ?
                        telemetryFile.SessionInfo.DriverInfo.DriversCar.CarScreenName :
                        telemetryFile.SessionInfo.DriverInfo.DriversCar.CarClassShortName;
                vehicle.Path = telemetryFile.SessionInfo.DriverInfo.DriversCar.CarPath;

                vehicle = await vehicleRepository.UpdateVehicleAsync(vehicle);
            }

            return vehicle;
        }

        // Tire Sheet
        private TireSheet GetTireSheet(ITelemetryFile telemetryFile)
        {
            TireSheet tireSheet = new TireSheet();

            tireSheet.Tires[TirePosition.LF].ColdPsi = telemetryFile.TireSheet.LF.ColdPsi;
            tireSheet.Tires[TirePosition.LF].HotPsi = telemetryFile.TireSheet.LF.HotPsi;
            tireSheet.Tires[TirePosition.LF].Temperatures[TreadPosition.Inside] = telemetryFile.TireSheet.LF.Temperatures[TreadPosition.Inside];
            tireSheet.Tires[TirePosition.LF].Temperatures[TreadPosition.Middle] = telemetryFile.TireSheet.LF.Temperatures[TreadPosition.Middle];
            tireSheet.Tires[TirePosition.LF].Temperatures[TreadPosition.Outside] = telemetryFile.TireSheet.LF.Temperatures[TreadPosition.Outside];
            tireSheet.Tires[TirePosition.LF].Wear[TreadPosition.Inside] = telemetryFile.TireSheet.LF.Wear[TreadPosition.Inside];
            tireSheet.Tires[TirePosition.LF].Wear[TreadPosition.Middle] = telemetryFile.TireSheet.LF.Wear[TreadPosition.Middle];
            tireSheet.Tires[TirePosition.LF].Wear[TreadPosition.Outside] = telemetryFile.TireSheet.LF.Wear[TreadPosition.Outside];

            tireSheet.Tires[TirePosition.LR].ColdPsi = telemetryFile.TireSheet.LR.ColdPsi;
            tireSheet.Tires[TirePosition.LR].HotPsi = telemetryFile.TireSheet.LR.HotPsi;
            tireSheet.Tires[TirePosition.LR].Temperatures[TreadPosition.Inside] = telemetryFile.TireSheet.LR.Temperatures[TreadPosition.Inside];
            tireSheet.Tires[TirePosition.LR].Temperatures[TreadPosition.Middle] = telemetryFile.TireSheet.LR.Temperatures[TreadPosition.Middle];
            tireSheet.Tires[TirePosition.LR].Temperatures[TreadPosition.Outside] = telemetryFile.TireSheet.LR.Temperatures[TreadPosition.Outside];
            tireSheet.Tires[TirePosition.LR].Wear[TreadPosition.Inside] = telemetryFile.TireSheet.LR.Wear[TreadPosition.Inside];
            tireSheet.Tires[TirePosition.LR].Wear[TreadPosition.Middle] = telemetryFile.TireSheet.LR.Wear[TreadPosition.Middle];
            tireSheet.Tires[TirePosition.LR].Wear[TreadPosition.Outside] = telemetryFile.TireSheet.LR.Wear[TreadPosition.Outside];

            tireSheet.Tires[TirePosition.RF].ColdPsi = telemetryFile.TireSheet.RF.ColdPsi;
            tireSheet.Tires[TirePosition.RF].HotPsi = telemetryFile.TireSheet.RF.HotPsi;
            tireSheet.Tires[TirePosition.RF].Temperatures[TreadPosition.Inside] = telemetryFile.TireSheet.RF.Temperatures[TreadPosition.Inside];
            tireSheet.Tires[TirePosition.RF].Temperatures[TreadPosition.Middle] = telemetryFile.TireSheet.RF.Temperatures[TreadPosition.Middle];
            tireSheet.Tires[TirePosition.RF].Temperatures[TreadPosition.Outside] = telemetryFile.TireSheet.RF.Temperatures[TreadPosition.Outside];
            tireSheet.Tires[TirePosition.RF].Wear[TreadPosition.Inside] = telemetryFile.TireSheet.RF.Wear[TreadPosition.Inside];
            tireSheet.Tires[TirePosition.RF].Wear[TreadPosition.Middle] = telemetryFile.TireSheet.RF.Wear[TreadPosition.Middle];
            tireSheet.Tires[TirePosition.RF].Wear[TreadPosition.Outside] = telemetryFile.TireSheet.RF.Wear[TreadPosition.Outside];

            tireSheet.Tires[TirePosition.RR].ColdPsi = telemetryFile.TireSheet.RR.ColdPsi;
            tireSheet.Tires[TirePosition.RR].HotPsi = telemetryFile.TireSheet.RR.HotPsi;
            tireSheet.Tires[TirePosition.RR].Temperatures[TreadPosition.Inside] = telemetryFile.TireSheet.RR.Temperatures[TreadPosition.Inside];
            tireSheet.Tires[TirePosition.RR].Temperatures[TreadPosition.Middle] = telemetryFile.TireSheet.RR.Temperatures[TreadPosition.Middle];
            tireSheet.Tires[TirePosition.RR].Temperatures[TreadPosition.Outside] = telemetryFile.TireSheet.RR.Temperatures[TreadPosition.Outside];
            tireSheet.Tires[TirePosition.RR].Wear[TreadPosition.Inside] = telemetryFile.TireSheet.RR.Wear[TreadPosition.Inside];
            tireSheet.Tires[TirePosition.RR].Wear[TreadPosition.Middle] = telemetryFile.TireSheet.RR.Wear[TreadPosition.Middle];
            tireSheet.Tires[TirePosition.RR].Wear[TreadPosition.Outside] = telemetryFile.TireSheet.RR.Wear[TreadPosition.Outside];

            return tireSheet;
        }

        private float GetTrackLengthMiles(string trackLengthKm)
        {
            float trackLengthKilometers = float.Parse(trackLengthKm.Replace(" km", ""));

            float trackLengthMiles = trackLengthKilometers * 0.621371F;

            return trackLengthMiles;
        }

        #endregion

        #region classes

        private class SetupValuesDictionaryItem
        {
            public string Path { get; set; }
            public string Name { get; set; }
            public string Value { get; set; }
        }

        private class SetupValuesDictionary
        {
            public IList<SetupValuesDictionaryItem> Settings { get; set; } = new List<SetupValuesDictionaryItem>();

            public SetupValuesDictionary(IDictionary<object, object> setupDictionary)
            {
                Settings = new List<SetupValuesDictionaryItem>();
                ReadDictionary(setupDictionary);
            }

            protected virtual void ReadDictionary(IDictionary<object, object> setupDictionary)
            {
                // CarSetup, dictionary with 3 items. (UpdateCount, Tires, Chasis)
                foreach (KeyValuePair<object, object> item in (IDictionary<object, object>)setupDictionary["CarSetup"])
                {
                    if (item.Value is Dictionary<object, object>)
                    {
                        ReadDictionary($"{item.Key.ToString()}.", (IDictionary<object, object>)item.Value);
                    }
                    else
                    {
                        // root level settings do not use path
                        Settings.Add(new SetupValuesDictionaryItem()
                        {
                            Path = ".",
                            Name = item.Key.ToString(),
                            Value = item.Value.ToString()
                        });
                    }
                }
            }

            protected virtual IDictionary<string, object> ReadDictionary(string path, IDictionary<object, object> setupDictionary)
            {
                IDictionary<string, object> setupValues = new Dictionary<string, object>();

                foreach (KeyValuePair<object, object> item in setupDictionary)
                {
                    if (item.Value is Dictionary<object, object>)
                    {
                        ReadDictionary($"{path}{item.Key.ToString()}", (IDictionary<object, object>)item.Value);
                    }
                    else
                    {
                        Settings.Add(new SetupValuesDictionaryItem()
                        {
                            Path = $"{path}",
                            Name = item.Key.ToString(),
                            Value = item.Value.ToString()
                        });
                    }
                }

                return setupValues;
            }
        }

        #endregion
    }
}
