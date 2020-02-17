using AutoMapper;
using RacerData.iRacing.Service.Sessions.Data.Models;
using RacerData.iRacing.Sessions.Models;

namespace RacerData.iRacing.Service.Sessions.Mapping
{
    class SetupPropertyMappingProfile : Profile
    {
        public SetupPropertyMappingProfile()
        {
            CreateMap<VehicleSetupPropertyModel, SetupProperty>()
               .ConvertUsing(new SetupPropertyConverter());
        }
    }
}
