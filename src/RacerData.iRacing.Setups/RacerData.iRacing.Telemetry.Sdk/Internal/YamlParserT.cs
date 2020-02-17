using System.Collections.Generic;

namespace RacerData.iRacing.Telemetry.Sdk.Internal
{
    internal interface IYamlParser<T>
    {
        T ParseYaml(IDictionary<object, object> valuesDictionary);
    }
}
