using AutoMapper;
using RacerData.iRacing.Service.Sessions.Data.Models;
using RacerData.iRacing.Sessions.Models;

namespace RacerData.iRacing.Service.Sessions.Mapping
{
    internal class RunMappingProfile : Profile
    {
        public RunMappingProfile()
        {
            CreateMap<RunModel, Run>()
                .ConvertUsing(new RunConverter());

            CreateMap<Run, RunModel>()
               .ConvertUsing(new RunModelConverter());
        }
    }
}