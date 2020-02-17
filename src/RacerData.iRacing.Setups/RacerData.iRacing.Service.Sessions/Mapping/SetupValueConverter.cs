using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using RacerData.iRacing.Service.Sessions.Data.Models;
using RacerData.iRacing.Sessions.Models;

namespace RacerData.iRacing.Service.Sessions.Mapping
{
    class SetupValueConverter : ITypeConverter<RunSetupValueModel, SetupValue>
    {
        public SetupValue Convert(RunSetupValueModel source, SetupValue destination, ResolutionContext context)
        {
            SetupValue setupValue = new SetupValue()
            {
                Id = source.SetupValue.Id,
                RawValue = source.SetupValue.RawValue,
                Value = source.SetupValue.Value,
                Property = new SetupProperty()
                {
                    Id = source.SetupValue.Property.Id,
                    Units = source.SetupValue.Property.Units,
                    Name = source.SetupValue.Property.Name,
                    Path = new SetupPropertyPath()
                    {
                        Id = source.SetupValue.Property.SetupPropertyPathId,
                        Path = source.SetupValue.Property.Path.Path
                    },
                    DataType = source.SetupValue.Property.DataType
                }
            };

            return setupValue;
        }
    }
}
