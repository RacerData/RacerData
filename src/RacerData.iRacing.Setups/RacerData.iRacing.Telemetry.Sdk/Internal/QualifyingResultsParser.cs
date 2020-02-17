using System;
using System.Collections.Generic;
using System.Reflection;
using RacerData.iRacing.Telemetry.Sdk.Models;

namespace RacerData.iRacing.Telemetry.Sdk.Internal
{
    internal class QualifyingResultsParser : IYamlParser<IQualifyingResultsInfo>
    {
        public IQualifyingResultsInfo ParseYaml(IDictionary<object, object> valuesDictionary)
        {
            IQualifyingResultsInfo qualifyingResult = new QualifyingResultsInfo();

            foreach (KeyValuePair<object, object> qualifyingResultItem in valuesDictionary)
            {
                string propertyName = qualifyingResultItem.Key.ToString();

                PropertyInfo propertyInfo = qualifyingResult.GetType().GetProperty(propertyName);

                if (propertyInfo == null)
                {
                    Console.WriteLine($"Found YAML property not in class: {propertyName} in {this.GetType().Name}");
                    continue;
                }

                if (propertyInfo.PropertyType.Name == "Boolean")
                {
                    bool value = (qualifyingResultItem.Value.ToString() == "1") ? true : false;
                    propertyInfo.SetValue(qualifyingResult, Convert.ChangeType(value, propertyInfo.PropertyType), null);
                }
                else
                {
                    propertyInfo.SetValue(qualifyingResult, Convert.ChangeType(qualifyingResultItem.Value, propertyInfo.PropertyType), null);
                }
            }

            return qualifyingResult;
        }
    }
}
