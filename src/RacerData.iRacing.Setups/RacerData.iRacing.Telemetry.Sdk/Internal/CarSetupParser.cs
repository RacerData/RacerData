using System;
using System.Collections.Generic;
using RacerData.iRacing.Telemetry.Sdk.Models;

namespace RacerData.iRacing.Telemetry.Sdk.Internal
{
    internal class CarSetupParser : IYamlParser<ICarSetup>
    {
        public ICarSetup ParseYaml(IDictionary<object, object> valuesDictionary, string yaml)
        {
            ICarSetup carSetup = new CarSetup()
            {
                ValuesDictionary = valuesDictionary,
                SetupYaml = yaml,
                UpdateCount = GetUpdateCount(valuesDictionary)
            };

            return carSetup;
        }

        public ICarSetup ParseYaml(IDictionary<object, object> valuesDictionary)
        {
            ICarSetup carSetup = new CarSetup()
            {
                ValuesDictionary = valuesDictionary,
                UpdateCount = GetUpdateCount(valuesDictionary)
            };

            return carSetup;
        }

        private int GetUpdateCount(IDictionary<object, object> valuesDictionary)
        {
            if (valuesDictionary == null || !valuesDictionary.ContainsKey("UpdateCount"))
            {
                return 0;
            }

            var updateCountString = valuesDictionary["UpdateCount"].ToString();

            if (String.IsNullOrEmpty(updateCountString))
                return 0;
            else
                return int.Parse(updateCountString);
        }
    }
}
