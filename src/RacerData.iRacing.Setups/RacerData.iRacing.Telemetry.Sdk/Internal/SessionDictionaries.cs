using System.Collections.Generic;
using System.IO;
using YamlDotNet.Serialization;

namespace RacerData.iRacing.Telemetry.Sdk.Internal
{
    internal class SessionDictionaries
    {
        #region properties

        public IDictionary<object, object> root { get; set; }
        public IDictionary<object, object> driverInfo { get; set; }
        public IDictionary<object, object> weekendInfo { get; set; }
        public IDictionary<object, object> sessionInfo { get; set; }
        public IDictionary<object, object> cameraInfo { get; set; }
        public IDictionary<object, object> radioInfo { get; set; }
        public IDictionary<object, object> splitTimeInfo { get; set; }
        public IDictionary<object, object> qualifyingInfo { get; set; }
        public IDictionary<object, object> carSetupInfo { get; set; }

        #endregion

        #region ctor

        public SessionDictionaries(string yamlSessionData)
        {
            var yamlReader = new StringReader(yamlSessionData);
            var deserializer = new Deserializer();
            var sessionData = deserializer.Deserialize(yamlReader);

            root = (IDictionary<object, object>)sessionData;

            weekendInfo = (IDictionary<object, object>)root["WeekendInfo"];
            driverInfo = (IDictionary<object, object>)root["DriverInfo"];
            sessionInfo = (IDictionary<object, object>)root["SessionInfo"];
            if (root.ContainsKey("CameraInfo"))
                cameraInfo = (IDictionary<object, object>)root["CameraInfo"];
            if (root.ContainsKey("RadioInfo"))
                radioInfo = (IDictionary<object, object>)root["RadioInfo"];
            if (root.ContainsKey("SplitTimeInfo"))
                splitTimeInfo = (IDictionary<object, object>)root["SplitTimeInfo"];
            if (root.ContainsKey("CarSetup"))
                carSetupInfo = (IDictionary<object, object>)root["CarSetup"];
            if (root.ContainsKey("QualifyResultsInfo"))
                qualifyingInfo = (IDictionary<object, object>)root["QualifyResultsInfo"];
        }

        #endregion
    }
}
