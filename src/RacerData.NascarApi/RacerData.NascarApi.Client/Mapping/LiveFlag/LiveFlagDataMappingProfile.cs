using AutoMapper;
using RacerData.NascarApi.Client.Models.LiveFlag;
using NascarApiLiveFeed = RacerData.NascarApi.Models.LiveFlagData;

namespace RacerData.NascarApi.Client.Mapping.LivePit
{
    public class LiveFlagDataMappingProfile : Profile
    {
        public LiveFlagDataMappingProfile()
        {
            CreateMap<NascarApiLiveFeed.RootObject, LiveFlagData>();
        }
    }
}