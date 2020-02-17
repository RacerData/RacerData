using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using RacerData.iRacing.Service.Sessions.Data.Models;
using RacerData.iRacing.Sessions.Models;

namespace RacerData.iRacing.Service.Sessions.Mapping
{
    internal class RunModelConverter : ITypeConverter<Run, RunModel>
    {
        public RunModel Convert(Run source, RunModel destination, ResolutionContext context)
        {
            return new RunModel()
            {
                Id = source.Id,
                DriverId = source.DriverId,
                SetupId = source.SetupId,
                TelemetryId = source.TelemetryId,
                Notes = source.Notes,
                LapsComplete = source.LapsComplete,
                Year = source.Year,
                TimeOfDay = source.TimeOfDay,
                SessionTimeId = source.SessionTimeId,
                TrackStateId = source.TrackStateId,
                Date = source.Date,
                SeasonId = source.SeasonId,
                SeriesId = source.SeriesId,
                SessionId = source.SessionId,
                SubSessionId = source.SubSessionId,
                VehicleId = source.VehicleId,
                TrackId = source.TrackId,
                EventType = source.EventType,
                RunTime = source.RunTime,
                AirTemp = source.AirTemp,
                TrackTemp = source.TrackTemp,
                Sky = source.Sky,
                TrackState = source.TrackState,
                Laps = context.Mapper.Map<IList<LapModel>>(source.Laps),
                TireReadings = TireSheetMapper.FromTireSheet(source.TireSheet),
                SetupValues = GetRunSetupValues(source)
            };
        }

        private IList<RunSetupValueModel> GetRunSetupValues(Run source)
        {
            if (source.SetupValues == null)
                return new List<RunSetupValueModel>();

            IList<RunSetupValueModel> runSetupValueModels = new List<RunSetupValueModel>();
            IList<SetupValueModel> valueModels = new List<SetupValueModel>();
            IList<SetupPropertyModel> propertyModels = new List<SetupPropertyModel>();
            IList<SetupPropertyPathModel> pathModels = new List<SetupPropertyPathModel>();

            foreach (SetupValue setupValue in source.SetupValues)
            {
                var path = pathModels.SingleOrDefault(p => p.Path == setupValue.Property?.Path?.Path);
                if (path == null)
                {
                    path = new SetupPropertyPathModel()
                    {
                        Id = setupValue.Property.Path.Id,
                        Path = setupValue.Property.Path.Path
                    };
                    pathModels.Add(path);
                }

                var setupProperty = propertyModels.SingleOrDefault(p =>
                    p.Name == setupValue.Property.Name &&
                    p.Path.Path == path.Path);

                if (setupProperty == null)
                {
                    setupProperty = new SetupPropertyModel()
                    {
                        DataType = setupValue.Property.DataType,
                        Name = setupValue.Property.Name,
                        Units = setupValue.Property.Units,
                        Path = path
                    };
                    propertyModels.Add(setupProperty);
                }

                var setupValueModel = valueModels.SingleOrDefault(p =>
                    p.RawValue == setupValue.RawValue &&
                    p.Property.Path.Path == path.Path &&
                    p.Property.Name == setupValue.Property.Name);

                if (setupValueModel == null)
                {
                    setupValueModel = new SetupValueModel()
                    {
                        RawValue = setupValue.RawValue,
                        Value = setupValue.Value,
                        Property = setupProperty
                    };
                    valueModels.Add(setupValueModel);
                }

                RunSetupValueModel runSetupValueModel = new RunSetupValueModel()
                {
                    SetupValue = setupValueModel
                };

                runSetupValueModels.Add(runSetupValueModel);
            }

            return runSetupValueModels;
        }

        private List<TireReadingsModel> GetTireReadings(Run source)
        {
            var tireReadings = new List<TireReadingsModel>();

            var lfTire = new TireReadingsModel() { Position = TirePosition.LF };
            lfTire.ColdPsi = source.TireSheet.Tires[TirePosition.LF].ColdPsi;
            lfTire.HotPsi = source.TireSheet.Tires[TirePosition.LF].HotPsi;
            lfTire.TempInner = source.TireSheet.Tires[TirePosition.LF].Temperatures[TreadPosition.Inside];
            lfTire.TempMiddle = source.TireSheet.Tires[TirePosition.LF].Temperatures[TreadPosition.Middle];
            lfTire.TempOuter = source.TireSheet.Tires[TirePosition.LF].Temperatures[TreadPosition.Outside];
            lfTire.WearInner = source.TireSheet.Tires[TirePosition.LF].Wear[TreadPosition.Inside];
            lfTire.WearMiddle = source.TireSheet.Tires[TirePosition.LF].Wear[TreadPosition.Middle];
            lfTire.WearOuter = source.TireSheet.Tires[TirePosition.LF].Wear[TreadPosition.Outside];
            tireReadings.Add(lfTire);

            var rfTire = new TireReadingsModel() { Position = TirePosition.RF };
            rfTire.ColdPsi = source.TireSheet.Tires[TirePosition.RF].ColdPsi;
            rfTire.HotPsi = source.TireSheet.Tires[TirePosition.RF].HotPsi;
            rfTire.TempInner = source.TireSheet.Tires[TirePosition.RF].Temperatures[TreadPosition.Inside];
            rfTire.TempMiddle = source.TireSheet.Tires[TirePosition.RF].Temperatures[TreadPosition.Middle];
            rfTire.TempOuter = source.TireSheet.Tires[TirePosition.RF].Temperatures[TreadPosition.Outside];
            rfTire.WearInner = source.TireSheet.Tires[TirePosition.RF].Wear[TreadPosition.Inside];
            rfTire.WearMiddle = source.TireSheet.Tires[TirePosition.RF].Wear[TreadPosition.Middle];
            rfTire.WearOuter = source.TireSheet.Tires[TirePosition.RF].Wear[TreadPosition.Outside];
            tireReadings.Add(rfTire);

            var lrTire = new TireReadingsModel() { Position = TirePosition.LR };
            lrTire.ColdPsi = source.TireSheet.Tires[TirePosition.LR].ColdPsi;
            lrTire.HotPsi = source.TireSheet.Tires[TirePosition.LR].HotPsi;
            lrTire.TempInner = source.TireSheet.Tires[TirePosition.LR].Temperatures[TreadPosition.Inside];
            lrTire.TempMiddle = source.TireSheet.Tires[TirePosition.LR].Temperatures[TreadPosition.Middle];
            lrTire.TempOuter = source.TireSheet.Tires[TirePosition.LR].Temperatures[TreadPosition.Outside];
            lrTire.WearInner = source.TireSheet.Tires[TirePosition.LR].Wear[TreadPosition.Inside];
            lrTire.WearMiddle = source.TireSheet.Tires[TirePosition.LR].Wear[TreadPosition.Middle];
            lrTire.WearOuter = source.TireSheet.Tires[TirePosition.LR].Wear[TreadPosition.Outside];
            tireReadings.Add(lrTire);

            var rrTire = new TireReadingsModel() { Position = TirePosition.RR };
            rrTire.ColdPsi = source.TireSheet.Tires[TirePosition.RR].ColdPsi;
            rrTire.HotPsi = source.TireSheet.Tires[TirePosition.RR].HotPsi;
            rrTire.TempInner = source.TireSheet.Tires[TirePosition.RR].Temperatures[TreadPosition.Inside];
            rrTire.TempMiddle = source.TireSheet.Tires[TirePosition.RR].Temperatures[TreadPosition.Middle];
            rrTire.TempOuter = source.TireSheet.Tires[TirePosition.RR].Temperatures[TreadPosition.Outside];
            rrTire.WearInner = source.TireSheet.Tires[TirePosition.RR].Wear[TreadPosition.Inside];
            rrTire.WearMiddle = source.TireSheet.Tires[TirePosition.RR].Wear[TreadPosition.Middle];
            rrTire.WearOuter = source.TireSheet.Tires[TirePosition.RR].Wear[TreadPosition.Outside];
            tireReadings.Add(rrTire);

            return tireReadings;
        }
    }
}
