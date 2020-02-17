using System;
using System.Collections.Generic;
using System.Reflection;
using RacerData.iRacing.Telemetry.Sdk.Models;

namespace RacerData.iRacing.Telemetry.Sdk.Internal
{
    internal class SessionParser : IYamlParser<ISession>
    {
        public ISession ParseYaml(IDictionary<object, object> valuesDictionary)
        {
            ISession sessionInstance = new Session();

            foreach (KeyValuePair<object, object> sessionInstanceItem in valuesDictionary)
            {
                if (sessionInstanceItem.Key.ToString() == "ResultsPositions")
                {
                    IList<object> resultsPositionsList = (IList<object>)sessionInstanceItem.Value;

                    if (resultsPositionsList != null && resultsPositionsList.Count > 0)
                    {
                        foreach (Dictionary<object, object> resultsPositionsInstance in resultsPositionsList)
                        {
                            IResultsPosition result = new ResultsPosition();

                            foreach (KeyValuePair<object, object> resultsPositionsItem in resultsPositionsInstance)
                            {
                                string propertyName = resultsPositionsItem.Key.ToString();

                                PropertyInfo propertyInfo = result.GetType().GetProperty(propertyName);

                                if (propertyInfo == null)
                                {
                                    Console.WriteLine($"Found YAML property not in class: {propertyName} in {result.GetType().Name}");
                                    continue;
                                }

                                if (propertyInfo.PropertyType.Name == "Boolean")
                                {
                                    bool value = (resultsPositionsItem.Value.ToString() == "1") ? true : false;
                                    propertyInfo.SetValue(result, Convert.ChangeType(value, propertyInfo.PropertyType), null);
                                }
                                else
                                {
                                    propertyInfo.SetValue(result, Convert.ChangeType(resultsPositionsItem.Value, propertyInfo.PropertyType), null);
                                }
                            }

                            sessionInstance.ResultsPositions.Add(result);
                        }
                    }
                }
                else if (sessionInstanceItem.Key.ToString() == "ResultsFastestLap")
                {
                    IList<object> fastLapInstances = (IList<object>)sessionInstanceItem.Value;

                    foreach (Dictionary<object, object> fastLaps in fastLapInstances)
                    {
                        foreach (KeyValuePair<object, object> fastLapItem in fastLaps)
                        {
                            string propertyName = fastLapItem.Key.ToString();

                            PropertyInfo propertyInfo = sessionInstance.ResultsFastestLap.GetType().GetProperty(propertyName);

                            if (propertyInfo == null)
                            {
                                Console.WriteLine($"Found YAML property not in class: {propertyName} in {sessionInstance.ResultsFastestLap.GetType().Name}");
                                continue;
                            }

                            if (propertyInfo.PropertyType.Name == "Boolean")
                            {
                                bool value = (fastLapItem.Value.ToString() == "1") ? true : false;
                                propertyInfo.SetValue(sessionInstance.ResultsFastestLap, Convert.ChangeType(value, propertyInfo.PropertyType), null);
                            }
                            else
                            {
                                propertyInfo.SetValue(sessionInstance.ResultsFastestLap, Convert.ChangeType(fastLapItem.Value, propertyInfo.PropertyType), null);
                            }
                        }
                    }
                }
                else
                {
                    string propertyName = sessionInstanceItem.Key.ToString();

                    PropertyInfo propertyInfo = sessionInstance.GetType().GetProperty(propertyName);

                    if (propertyInfo == null)
                    {
                        Console.WriteLine($"Found YAML property not in class: {propertyName} in {sessionInstance.GetType().Name}");
                        continue;
                    }

                    if (propertyInfo.PropertyType.Name == "Boolean")
                    {
                        bool value = (sessionInstanceItem.Value.ToString() == "1") ? true : false;
                        propertyInfo.SetValue(sessionInstance, Convert.ChangeType(value, propertyInfo.PropertyType), null);
                    }
                    else
                    {
                        propertyInfo.SetValue(sessionInstance, Convert.ChangeType(sessionInstanceItem.Value, propertyInfo.PropertyType), null);
                    }
                }
            }

            return sessionInstance;
        }
    }
}
