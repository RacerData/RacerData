using AutoMapper;
using RacerData.iRacing.Service.Sessions.Data.Models;
using RacerData.iRacing.Sessions.Models;

namespace RacerData.iRacing.Service.Sessions.Mapping
{
    class SessionListViewMappingProfile : Profile
    {
        public SessionListViewMappingProfile()
        {
            CreateMap<SessionListViewModel, SessionListView>()
                .ReverseMap();
        }
    }
}
