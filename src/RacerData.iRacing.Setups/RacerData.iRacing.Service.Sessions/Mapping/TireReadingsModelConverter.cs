using System.Collections.Generic;
using AutoMapper;
using RacerData.iRacing.Service.Sessions.Data.Models;
using RacerData.iRacing.Sessions.Models;

namespace RacerData.iRacing.Service.Sessions.Mapping
{
    class TireReadingsModelConverter : ITypeConverter<TireSheet, IList<TireReadingsModel>>
    {
        public IList<TireReadingsModel> Convert(TireSheet source, IList<TireReadingsModel> destination, ResolutionContext context)
        {
            var tireReadings = new List<TireReadingsModel>();

            var lfTire = new TireReadingsModel() { Position = TirePosition.LF };
            lfTire.ColdPsi = source.Tires[TirePosition.LF].ColdPsi;
            lfTire.HotPsi = source.Tires[TirePosition.LF].HotPsi;
            lfTire.TempInner = source.Tires[TirePosition.LF].Temperatures[TreadPosition.Inside];
            lfTire.TempMiddle = source.Tires[TirePosition.LF].Temperatures[TreadPosition.Middle];
            lfTire.TempOuter = source.Tires[TirePosition.LF].Temperatures[TreadPosition.Outside];
            lfTire.WearInner = source.Tires[TirePosition.LF].Wear[TreadPosition.Inside];
            lfTire.WearMiddle = source.Tires[TirePosition.LF].Wear[TreadPosition.Middle];
            lfTire.WearOuter = source.Tires[TirePosition.LF].Wear[TreadPosition.Outside];
            tireReadings.Add(lfTire);

            var rfTire = new TireReadingsModel() { Position = TirePosition.RF };
            rfTire.ColdPsi = source.Tires[TirePosition.RF].ColdPsi;
            rfTire.HotPsi = source.Tires[TirePosition.RF].HotPsi;
            rfTire.TempInner = source.Tires[TirePosition.RF].Temperatures[TreadPosition.Inside];
            rfTire.TempMiddle = source.Tires[TirePosition.RF].Temperatures[TreadPosition.Middle];
            rfTire.TempOuter = source.Tires[TirePosition.RF].Temperatures[TreadPosition.Outside];
            rfTire.WearInner = source.Tires[TirePosition.RF].Wear[TreadPosition.Inside];
            rfTire.WearMiddle = source.Tires[TirePosition.RF].Wear[TreadPosition.Middle];
            rfTire.WearOuter = source.Tires[TirePosition.RF].Wear[TreadPosition.Outside];
            tireReadings.Add(rfTire);

            var lrTire = new TireReadingsModel() { Position = TirePosition.LR };
            lrTire.ColdPsi = source.Tires[TirePosition.LR].ColdPsi;
            lrTire.HotPsi = source.Tires[TirePosition.LR].HotPsi;
            lrTire.TempInner = source.Tires[TirePosition.LR].Temperatures[TreadPosition.Inside];
            lrTire.TempMiddle = source.Tires[TirePosition.LR].Temperatures[TreadPosition.Middle];
            lrTire.TempOuter = source.Tires[TirePosition.LR].Temperatures[TreadPosition.Outside];
            lrTire.WearInner = source.Tires[TirePosition.LR].Wear[TreadPosition.Inside];
            lrTire.WearMiddle = source.Tires[TirePosition.LR].Wear[TreadPosition.Middle];
            lrTire.WearOuter = source.Tires[TirePosition.LR].Wear[TreadPosition.Outside];
            tireReadings.Add(lrTire);

            var rrTire = new TireReadingsModel() { Position = TirePosition.RR };
            rrTire.ColdPsi = source.Tires[TirePosition.RR].ColdPsi;
            rrTire.HotPsi = source.Tires[TirePosition.RR].HotPsi;
            rrTire.TempInner = source.Tires[TirePosition.RR].Temperatures[TreadPosition.Inside];
            rrTire.TempMiddle = source.Tires[TirePosition.RR].Temperatures[TreadPosition.Middle];
            rrTire.TempOuter = source.Tires[TirePosition.RR].Temperatures[TreadPosition.Outside];
            rrTire.WearInner = source.Tires[TirePosition.RR].Wear[TreadPosition.Inside];
            rrTire.WearMiddle = source.Tires[TirePosition.RR].Wear[TreadPosition.Middle];
            rrTire.WearOuter = source.Tires[TirePosition.RR].Wear[TreadPosition.Outside];
            tireReadings.Add(rrTire);

            return tireReadings;
        }
    }
}
