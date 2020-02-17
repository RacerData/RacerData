using System.Collections.Generic;

namespace RacerData.iRacing.Telemetry.Models
{
    public interface ISessionDictionaries
    {
        IDictionary<object, object> cameraInfo { get; set; }
        IDictionary<object, object> driverCar { get; set; }
        int driverCarIdx { get; set; }
        IDictionary<object, object> driverInfo { get; set; }
        IList<object> drivers { get; set; }
        IDictionary<object, object> radioInfo { get; set; }
        IDictionary<object, object> sessionInfo { get; set; }
        IDictionary<object, object> splitTimeInfo { get; set; }
        IDictionary<object, object> weekendInfo { get; set; }
        IDictionary<object, object> weekendOptions { get; set; }
        string CarSetupYaml { get; set; }
        IDictionary<object, object> root { get; set; }

        string SessionValues();
        string WeekendValues();
    }
}