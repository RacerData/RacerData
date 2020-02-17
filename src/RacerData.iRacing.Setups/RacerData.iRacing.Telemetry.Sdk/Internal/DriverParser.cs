using System;
using System.Collections.Generic;
using System.Reflection;
using RacerData.iRacing.Telemetry.Sdk.Models;

namespace RacerData.iRacing.Telemetry.Sdk.Internal
{
    internal class DriverParser : IYamlParser<IDriver>
    {
        // TODO: Create base class for parser, consolidate common code
        public IDriver ParseYaml(IDictionary<object, object> valuesDictionary)
        {
            IDriver driver = new Driver();

            foreach (KeyValuePair<object, object> driverItem in valuesDictionary)
            {
                string propertyName = driverItem.Key.ToString();

                PropertyInfo propertyInfo = driver.GetType().GetProperty(propertyName);

                if (propertyInfo == null)
                {
                    Console.WriteLine($"Found YAML property not in class: {propertyName} in {this.GetType().Name}");
                    continue;
                }

                if (propertyInfo.PropertyType.Name == "Boolean")
                {
                    bool value = (driverItem.Value.ToString() == "1") ? true : false;
                    propertyInfo.SetValue(driver, Convert.ChangeType(value, propertyInfo.PropertyType), null);
                }
                else
                {
                    propertyInfo.SetValue(driver, Convert.ChangeType(driverItem.Value, propertyInfo.PropertyType), null);
                }
            }

            return driver;
        }
    }
}
