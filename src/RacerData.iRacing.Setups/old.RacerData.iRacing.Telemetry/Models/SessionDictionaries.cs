using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using YamlDotNet.Serialization;

namespace RacerData.iRacing.Telemetry.Models
{
    internal class SessionDictionaries : ISessionDictionaries
    {
        public IDictionary<object, object> driverInfo { get; set; }
        public IList<object> drivers { get; set; }
        public int driverCarIdx { get; set; }
        public IDictionary<object, object> driverCar { get; set; }
        public IDictionary<object, object> weekendInfo { get; set; }
        public IDictionary<object, object> weekendOptions { get; set; }
        public IDictionary<object, object> sessionInfo { get; set; }
        public IDictionary<object, object> cameraInfo { get; set; }
        public IDictionary<object, object> radioInfo { get; set; }
        public IDictionary<object, object> splitTimeInfo { get; set; }
        public string CarSetupYaml { get; set; }
        public IDictionary<object, object> root { get; set; }

        public SessionDictionaries(string yamlSessionData)
            : this(yamlSessionData, IbtParseOptions.All)
        {

        }
        public SessionDictionaries(string yamlSessionData, IbtParseOptions options)
        {
            var yamlReader = new StringReader(yamlSessionData);
            var deserializer = new Deserializer();
            var sessionData = deserializer.Deserialize(yamlReader);
            root = (IDictionary<object, object>)sessionData;

            // required
            weekendInfo = (IDictionary<object, object>)root["WeekendInfo"];

            if (options.HasFlag(IbtParseOptions.DriverInfo))
            {
                driverInfo = (IDictionary<object, object>)root["DriverInfo"];
                driverCarIdx = Convert.ToInt32(driverInfo["DriverCarIdx"]);
                drivers = (IList<object>)driverInfo["Drivers"];
                driverCar = (IDictionary<object, object>)drivers[driverCarIdx];
            }

            if (options.HasFlag(IbtParseOptions.WeekendOptions))
                weekendOptions = (IDictionary<object, object>)weekendInfo["WeekendOptions"];

            if (options.HasFlag(IbtParseOptions.SessionInfo))
                sessionInfo = (IDictionary<object, object>)root["SessionInfo"];

            if (options.HasFlag(IbtParseOptions.CameraInfo))
                cameraInfo = (IDictionary<object, object>)root["CameraInfo"];

            if (options.HasFlag(IbtParseOptions.RadioInfo))
                radioInfo = (IDictionary<object, object>)root["RadioInfo"];

            if (options.HasFlag(IbtParseOptions.SplitTimeInfo))
                splitTimeInfo = (IDictionary<object, object>)root["SplitTimeInfo"];
        }

        public string SessionValues()
        {
            StringBuilder sb = new StringBuilder();

            var sessionsCollection = (IList<object>)sessionInfo["Sessions"];

            foreach (Dictionary<object, object> session in sessionsCollection)
            {
                sb.AppendLine("-------------");
                foreach (KeyValuePair<object, object> item in session)
                {
                    sb.AppendLine($"{item.Key.ToString()}: {item.Value?.ToString()}");
                }
            }

            return sb.ToString();
        }
        public string WeekendValues()
        {
            StringBuilder sb = new StringBuilder();

            foreach (KeyValuePair<object, object> item in weekendOptions)
            {
                sb.AppendLine($"{item.Key.ToString()}: {item.Value.ToString()}");
            }

            return sb.ToString();
        }
    }
}
