using System.Collections.Generic;
using AutoMapper;
using RacerData.iRacing.Service.Sessions.Data.Models;
using RacerData.iRacing.Sessions.Models;

namespace RacerData.iRacing.Service.Sessions.Mapping
{
    internal class RunConverter : ITypeConverter<RunModel, Run>
    {
        public Run Convert(RunModel source, Run destination, ResolutionContext context)
        {
            return new Run()
            {
                Id = source.Id,
                DriverId = source.DriverId,
                SetupId = source.SetupId,
                TelemetryId = source.TelemetryId,
                Notes = source.Notes,
                Year = source.Year,
                Season = source.Season,
                Week = source.Week,
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
                LapsComplete = source.LapsComplete,
                RunTime = source.RunTime,
                AirTemp = source.AirTemp,
                TrackTemp = source.TrackTemp,
                Sky = source.Sky,
                TrackState = source.TrackState,
                Laps = context.Mapper.Map<IList<Lap>>(source.Laps),
                TireSheet = TireSheetMapper.ToTireSheet(source.Id, source.TireReadings),
                SetupValues = context.Mapper.Map<IList<SetupValue>>(source.SetupValues)
            };
        }

        private TireSheet GetTireSheet(RunModel source)
        {
            TireSheet tireSheet = new TireSheet();

            foreach (TireReadingsModel tireReadingsModel in source.TireReadings)
            {
                tireSheet.Tires[tireReadingsModel.Position].ColdPsi = tireReadingsModel.ColdPsi;
                tireSheet.Tires[tireReadingsModel.Position].HotPsi = tireReadingsModel.HotPsi;

                tireSheet.Tires[tireReadingsModel.Position].Temperatures[TreadPosition.Inside] = tireReadingsModel.TempInner;
                tireSheet.Tires[tireReadingsModel.Position].Temperatures[TreadPosition.Middle] = tireReadingsModel.TempMiddle;
                tireSheet.Tires[tireReadingsModel.Position].Temperatures[TreadPosition.Outside] = tireReadingsModel.TempOuter;

                tireSheet.Tires[tireReadingsModel.Position].Wear[TreadPosition.Inside] = tireReadingsModel.WearInner;
                tireSheet.Tires[tireReadingsModel.Position].Wear[TreadPosition.Middle] = tireReadingsModel.WearMiddle;
                tireSheet.Tires[tireReadingsModel.Position].Wear[TreadPosition.Outside] = tireReadingsModel.WearOuter;
            }

            return tireSheet;
        }
    }
}
