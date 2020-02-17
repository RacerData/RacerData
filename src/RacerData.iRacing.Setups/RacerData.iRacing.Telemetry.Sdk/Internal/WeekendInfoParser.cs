using System;
using System.Collections.Generic;
using System.Reflection;
using RacerData.iRacing.Telemetry.Sdk.Models;

namespace RacerData.iRacing.Telemetry.Sdk.Internal
{
    internal class WeekendInfoParser : IYamlParser<IWeekendInfo>
    {
        public IWeekendInfo ParseYaml(IDictionary<object, object> valuesDictionary)
        {
            IWeekendInfo weekendInfo = new WeekendInfo();

            foreach (KeyValuePair<object, object> weekendInfoItem in valuesDictionary)
            {
                if (weekendInfoItem.Key.ToString() == "WeekendOptions")
                {
                    Dictionary<object, object> weekendOptionsDictionary = (Dictionary<object, object>)weekendInfoItem.Value;

                    var weekendOptionsParser = new WeekendOptionsParser();
                    weekendInfo.WeekendOptions = weekendOptionsParser.ParseYaml(weekendOptionsDictionary);
                }
                else if (weekendInfoItem.Key.ToString() == "TelemetryOptions")
                {
                    Dictionary<object, object> telemetryOptionsDictionary = (Dictionary<object, object>)weekendInfoItem.Value;

                    weekendInfo.TelemetryOptions.TelemetryDiskFile = telemetryOptionsDictionary["TelemetryDiskFile"].ToString();
                }
                else
                {
                    string propertyName = weekendInfoItem.Key.ToString();

                    PropertyInfo propertyInfo = weekendInfo.GetType().GetProperty(propertyName);

                    if (propertyInfo == null)
                    {
                        Console.WriteLine($"Found YAML property not in class: {propertyName} in {weekendInfo.GetType().Name}");
                        continue;
                    }

                    if (propertyInfo.PropertyType.Name == "Boolean")
                    {
                        bool value = (weekendInfoItem.Value.ToString() == "1") ? true : false;
                        propertyInfo.SetValue(weekendInfo, Convert.ChangeType(value, propertyInfo.PropertyType), null);
                    }
                    else
                    {
                        propertyInfo.SetValue(weekendInfo, Convert.ChangeType(weekendInfoItem.Value, propertyInfo.PropertyType), null);
                    }
                }
            }

            return weekendInfo;
        }
    }
}
