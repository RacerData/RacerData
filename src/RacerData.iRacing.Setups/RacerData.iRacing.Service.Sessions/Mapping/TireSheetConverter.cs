using System.Collections.Generic;
using AutoMapper;
using RacerData.iRacing.Service.Sessions.Data.Models;
using RacerData.iRacing.Sessions.Models;

namespace RacerData.iRacing.Service.Sessions.Mapping
{
    class TireSheetConverter : ITypeConverter<IList<TireReadingsModel>, TireSheet>
    {
        public TireSheet Convert(IList<TireReadingsModel> source, TireSheet destination, ResolutionContext context)
        {
            TireSheet tireSheet = new TireSheet();

            foreach (TireReadingsModel tireReadingsModel in source)
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
