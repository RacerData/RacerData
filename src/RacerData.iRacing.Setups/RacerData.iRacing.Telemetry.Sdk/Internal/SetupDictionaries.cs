using System;
using System.Collections.Generic;
using System.IO;
using YamlDotNet.Serialization;

namespace RacerData.iRacing.Telemetry.Sdk.Internal
{
    internal class SetupDictionaries
    {
        public IDictionary<object, object> carSetup { get; set; }
        public IDictionary<object, object> tires { get; set; }
        public IDictionary<object, object> chassis { get; set; }
        public IDictionary<object, object> rfTire { get; set; }
        public IDictionary<object, object> rrTire { get; set; }
        public IDictionary<object, object> lfTire { get; set; }
        public IDictionary<object, object> lrTire { get; set; }

        public IDictionary<object, object> fChassis { get; set; }
        public IDictionary<object, object> rfChassis { get; set; }
        public IDictionary<object, object> rrChassis { get; set; }
        public IDictionary<object, object> lfChassis { get; set; }
        public IDictionary<object, object> lrChassis { get; set; }
        public IDictionary<object, object> rChassis { get; set; }
        public int updateCount { get; set; }

        public SetupDictionaries(string yamlSetupData)
        {
            if (!String.IsNullOrEmpty(yamlSetupData))
            {
                var yamlReader = new StringReader(yamlSetupData);
                var deserializer = new Deserializer();
                var sessionData = deserializer.Deserialize(yamlReader);
                var root = (IDictionary<object, object>)sessionData;
                carSetup = (IDictionary<object, object>)root["CarSetup"];

                updateCount = Convert.ToInt32(carSetup["UpdateCount"]);
                tires = (IDictionary<object, object>)carSetup["Tires"];
                rfTire = (IDictionary<object, object>)tires["RightFront"];
                rrTire = (IDictionary<object, object>)tires["RightRear"];
                lfTire = (IDictionary<object, object>)tires["LeftFront"];
                lrTire = (IDictionary<object, object>)tires["LeftRear"];

                chassis = (IDictionary<object, object>)carSetup["Chassis"];
                fChassis = (IDictionary<object, object>)chassis["Front"];
                rfChassis = (IDictionary<object, object>)chassis["RightFront"];
                rrChassis = (IDictionary<object, object>)chassis["RightRear"];
                lfChassis = (IDictionary<object, object>)chassis["LeftFront"];
                lrChassis = (IDictionary<object, object>)chassis["LeftRear"];
                rChassis = (IDictionary<object, object>)chassis["Rear"];
            }
        }
    }
}
