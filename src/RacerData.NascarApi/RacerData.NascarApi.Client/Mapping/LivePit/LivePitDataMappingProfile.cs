using AutoMapper;
using RacerData.NascarApi.Client.Models.LivePit;
using NascarApiLiveFeed = RacerData.NascarApi.Models.LivePitData;

namespace RacerData.NascarApi.Client.Mapping.LivePit
{
    public class LivePitDataMappingProfile : Profile
    {
        public LivePitDataMappingProfile()
        {
            CreateMap<NascarApiLiveFeed.RootObject, LivePitData>();
        }
    }
}