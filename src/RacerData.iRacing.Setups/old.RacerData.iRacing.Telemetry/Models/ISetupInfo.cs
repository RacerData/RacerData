using System.Collections.Generic;

namespace RacerData.iRacing.Telemetry.Models
{
    public interface ISetupInfo
    {
        IDictionary<object, object> carSetup { get; set; }
        IDictionary<object, object> chassis { get; set; }
        IDictionary<object, object> fChassis { get; set; }
        IDictionary<object, object> lfChassis { get; set; }
        IDictionary<object, object> lfTire { get; set; }
        IDictionary<object, object> lrChassis { get; set; }
        IDictionary<object, object> lrTire { get; set; }
        IDictionary<object, object> rChassis { get; set; }
        IDictionary<object, object> rfChassis { get; set; }
        IDictionary<object, object> rfTire { get; set; }
        IDictionary<object, object> rrChassis { get; set; }
        IDictionary<object, object> rrTire { get; set; }
        IDictionary<object, object> tires { get; set; }
        int updateCount { get; set; }
    }
}