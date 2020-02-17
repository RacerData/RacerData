using AutoMapper;
using RacerData.iRacing.Service.Sessions.Data.Models;
using RacerData.iRacing.Sessions.Models;

namespace RacerData.iRacing.Service.Sessions.Mapping
{
    class SetupValueMappingProfile : Profile
    {
        public SetupValueMappingProfile()
        {
            CreateMap<RunSetupValueModel, SetupValue>()
               .ConvertUsing(new SetupValueConverter());
        }
    }
}
