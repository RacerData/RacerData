using System.Collections.Generic;

namespace RacerData.iRacing.Telemetry.Sdk.Models
{
    internal class CarSetup : ICarSetup
    {
        #region properties

        public IDictionary<object, object> ValuesDictionary { get; set; }
        public string SetupYaml { get; set; }
        public int UpdateCount { get; set; }

        #endregion

        #region ctor

        public CarSetup()
        {
            ValuesDictionary = new Dictionary<object, object>();
        }

        #endregion
    }
}
