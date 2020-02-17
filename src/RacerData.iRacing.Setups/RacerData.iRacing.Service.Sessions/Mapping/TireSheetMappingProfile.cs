using System.Collections.Generic;
using AutoMapper;
using RacerData.iRacing.Service.Sessions.Data.Models;
using RacerData.iRacing.Sessions.Models;

namespace RacerData.iRacing.Service.Sessions.Mapping
{
    internal class TireSheetMappingProfile : Profile
    {
        public TireSheetMappingProfile()
        {
            CreateMap<IList<TireReadingsModel>, TireSheet>()
                .ForMember(m => m.Tires, opts => opts.Ignore())
                .ForMember(m => m.RunId, opts => opts.Ignore())
                .ConvertUsing(new TireSheetConverter());

            CreateMap<TireSheet, IList<TireReadingsModel>>()
               .ConvertUsing(new TireReadingsModelConverter());
        }
    }
}