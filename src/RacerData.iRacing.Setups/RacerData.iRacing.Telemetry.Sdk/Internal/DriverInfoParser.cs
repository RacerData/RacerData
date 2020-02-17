using System;
using System.Collections.Generic;
using System.Reflection;
using RacerData.iRacing.Telemetry.Sdk.Models;

namespace RacerData.iRacing.Telemetry.Sdk.Internal
{
    internal class DriverInfoParser : IYamlParser<IDriverInfo>
    {
        public IDriverInfo ParseYaml(IDictionary<object, object> valuesDictionary)
        {
            IDriverInfo driverInfo = new DriverInfo();

            foreach (KeyValuePair<object, object> driverInfoItem in valuesDictionary)
            {
                if (driverInfoItem.Key.ToString() == "Drivers")
                {
                    IList<object> driverList = (IList<object>)driverInfoItem.Value;
                    var driverParser = new DriverParser();
                    foreach (Dictionary<object, object> driverItem in driverList)
                    {
                        var driver = driverParser.ParseYaml(driverItem);
                        driverInfo.Drivers.Add(driver);
                    }
                }
                else
                {
                    string propertyName = driverInfoItem.Key.ToString();

                    PropertyInfo propertyInfo = driverInfo.GetType().GetProperty(propertyName);

                    if (propertyInfo == null)
                    {
                        Console.WriteLine($"Found YAML property not in class: {propertyName} in {this.GetType().Name}");
                        continue;
                    }

                    if (propertyInfo.PropertyType.Name == "Boolean")
                    {
                        bool value = (driverInfoItem.Value.ToString() == "1") ? true : false;
                        propertyInfo.SetValue(driverInfo, Convert.ChangeType(value, propertyInfo.PropertyType), null);
                    }
                    else
                    {
                        propertyInfo.SetValue(driverInfo, Convert.ChangeType(driverInfoItem.Value, propertyInfo.PropertyType), null);
                    }
                }
            }

            return driverInfo;
        }
    }
}
