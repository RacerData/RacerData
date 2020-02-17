using System;
using System.Collections.Generic;
using System.Reflection;
using RacerData.iRacing.Telemetry.Sdk.Models;

namespace RacerData.iRacing.Telemetry.Sdk.Internal
{
    internal class WeekendOptionsParser : IYamlParser<IWeekendOptions>
    {
        public IWeekendOptions ParseYaml(IDictionary<object, object> valuesDictionary)
        {
            IWeekendOptions weekendOptions = new WeekendOptions();

            foreach (KeyValuePair<object, object> weekendOptionsItem in valuesDictionary)
            {
                string propertyName = weekendOptionsItem.Key.ToString();

                PropertyInfo propertyInfo = weekendOptions.GetType().GetProperty(propertyName);

                if (propertyInfo == null)
                {
                    Console.WriteLine($"Found YAML property not in class: {propertyName} in {weekendOptions.GetType().Name}");
                    continue;
                }

                if (propertyInfo.PropertyType.Name == "Boolean")
                {
                    bool value = (weekendOptionsItem.Value.ToString() == "1") ? true : false;
                    propertyInfo.SetValue(weekendOptions, Convert.ChangeType(value, propertyInfo.PropertyType), null);
                }
                else
                {
                    propertyInfo.SetValue(weekendOptions, Convert.ChangeType(weekendOptionsItem.Value, propertyInfo.PropertyType), null);
                }
            }

            return weekendOptions;
        }
    }
}
