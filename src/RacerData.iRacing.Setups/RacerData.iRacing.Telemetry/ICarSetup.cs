using System.Collections.Generic;

namespace RacerData.iRacing.Telemetry
{
    public interface ICarSetup
    {
        IDictionary<object, object> ValuesDictionary { get; set; }
        string SetupYaml { get; set; }
        int UpdateCount { get; }
    }
}
