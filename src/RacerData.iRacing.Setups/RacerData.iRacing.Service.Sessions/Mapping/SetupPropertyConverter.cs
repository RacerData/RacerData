using AutoMapper;
using RacerData.iRacing.Service.Sessions.Data.Models;
using RacerData.iRacing.Sessions.Models;

namespace RacerData.iRacing.Service.Sessions.Mapping
{
    class SetupPropertyConverter : ITypeConverter<VehicleSetupPropertyModel, SetupProperty>
    {
        public SetupProperty Convert(VehicleSetupPropertyModel source, SetupProperty destination, ResolutionContext context)
        {
            return context.Mapper.Map<SetupProperty>(source.SetupProperty);
        }
    }
}
