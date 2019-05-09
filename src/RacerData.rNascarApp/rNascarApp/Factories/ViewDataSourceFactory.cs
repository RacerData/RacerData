﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using RacerData.NascarApi.Client.Attributes;
using RacerData.NascarApi.Client.Models.LapAverages;
using RacerData.NascarApi.Client.Models.LapTimes;
using RacerData.NascarApi.Client.Models.LiveFeed;
using RacerData.NascarApi.Client.Models.LiveFlag;
using RacerData.NascarApi.Client.Models.LivePit;
using RacerData.NascarApi.Client.Models.LivePoints;
using RacerData.NascarApi.Client.Models.LiveQualifying;
using RacerData.rNascarApp.Models;

namespace RacerData.rNascarApp.Factories
{
    class ViewDataSourceFactory
    {
        #region public

        public IList<ViewDataSource> GetList()
        {
            IList<ViewDataSource> sources = new List<ViewDataSource>();

            sources.Add(GetDataSource("LiveFeedData", typeof(LiveFeedData)));
            sources.Add(GetDataSource("LivePitData[]", typeof(LivePitData)));
            sources.Add(GetDataSource("LiveFlagData[]", typeof(LiveFlagData)));
            sources.Add(GetDataSource("LivePointsData[]", typeof(LivePointsData)));
            sources.Add(GetDataSource("LiveQualifyingData[]", typeof(LiveQualifyingData)));
            sources.Add(GetDataSource("LapTimeData", typeof(EventVehicleLapTimes)));
            sources.Add(GetDataSource("LapAverageData", typeof(EventVehicleLapAverages)));
            
            return sources;
        }

        #endregion

        #region protected

        protected virtual ViewDataSource GetDataSource(string name, Type dataSourceType)
        {
            ViewDataSource source = new ViewDataSource()
            {
                Name = name,
                Path = dataSourceType.FullName,
                Type = dataSourceType.FullName,
                AssemblyQualifiedName = dataSourceType.AssemblyQualifiedName
            };

            foreach (PropertyInfo propertyInfo in dataSourceType.GetProperties())
            {
                var enumTypeAttribute = propertyInfo.GetCustomAttribute<EnumTypeAttribute>();

                if (enumTypeAttribute != null)
                {
                    source.Fields.Add(new ViewDataMember()
                    {
                        Name = propertyInfo.Name,
                        Path = $"{propertyInfo.ReflectedType.FullName}.{propertyInfo.Name}",
                        DataFeed = dataSourceType.Name,
                        DataFeedTypeAssemblyQualifiedName = dataSourceType.AssemblyQualifiedName,
                        DataFeedTypeFullName = dataSourceType.FullName,
                        Type = enumTypeAttribute.EnumTypeName,
                        AssemblyQualifiedName = propertyInfo.PropertyType.AssemblyQualifiedName
                    });
                }
                else if (propertyInfo.PropertyType.Name.Contains("List"))
                {
                    var innerSource = GetDataSource(propertyInfo, dataSourceType);
                    source.Lists.Add(innerSource);
                }
                else if (propertyInfo.PropertyType.Assembly == dataSourceType.Assembly)
                {
                    var innerSource = GetDataSource(propertyInfo, dataSourceType);
                    source.NestedClasses.Add(innerSource);
                }
                else
                {
                    source.Fields.Add(new ViewDataMember()
                    {
                        Name = propertyInfo.Name,
                        Path = $"{propertyInfo.ReflectedType.FullName}.{propertyInfo.Name}",
                        DataFeed = dataSourceType.Name,
                        DataFeedTypeAssemblyQualifiedName = dataSourceType.AssemblyQualifiedName,
                        DataFeedTypeFullName = dataSourceType.FullName,
                        Type = propertyInfo.PropertyType.ToString(),
                        AssemblyQualifiedName = propertyInfo.PropertyType.AssemblyQualifiedName
                    });
                }
            }

            return source;
        }

        protected virtual ViewDataSource GetDataSource(PropertyInfo sourcePropertyInfo, Type dataFeedType)
        {
            ViewDataSource source = null;

            if (sourcePropertyInfo.PropertyType.IsGenericType)
            {
                source = new ViewDataSource()
                {
                    Name = sourcePropertyInfo.Name,
                    Path = $"{sourcePropertyInfo.ReflectedType.FullName}.{sourcePropertyInfo.Name}",
                    Type = sourcePropertyInfo.PropertyType.GenericTypeArguments[0].Name,
                    AssemblyQualifiedName = sourcePropertyInfo.PropertyType.GenericTypeArguments[0].AssemblyQualifiedName
                };
            }
            else
            {
                source = new ViewDataSource()
                {
                    Name = sourcePropertyInfo.Name,
                    Path = $"{sourcePropertyInfo.ReflectedType.FullName}.{sourcePropertyInfo.Name}",
                    Type = sourcePropertyInfo.PropertyType.Name,
                    AssemblyQualifiedName = sourcePropertyInfo.PropertyType.AssemblyQualifiedName
                };
            }

            var dataSourceType = Type.GetType(source.AssemblyQualifiedName);

            foreach (PropertyInfo propertyInfo in dataSourceType.GetProperties())
            {
                var enumTypeAttribute = propertyInfo.GetCustomAttribute<EnumTypeAttribute>();

                if (enumTypeAttribute != null)
                {
                    source.Fields.Add(new ViewDataMember()
                    {
                        Name = propertyInfo.Name,
                        Path = $"{propertyInfo.ReflectedType.FullName}.{propertyInfo.Name}",
                        DataFeed = dataFeedType.Name,
                        DataFeedTypeAssemblyQualifiedName = dataFeedType.AssemblyQualifiedName,
                        DataFeedTypeFullName = dataFeedType.FullName,
                        Type = enumTypeAttribute.EnumTypeName,
                        AssemblyQualifiedName = propertyInfo.PropertyType.AssemblyQualifiedName
                    });
                }
                else if (propertyInfo.PropertyType.Name.Contains("List"))
                {
                    var innerSource = GetDataSource(propertyInfo, dataFeedType);
                    source.Lists.Add(innerSource);
                }
                else if (propertyInfo.PropertyType.Assembly == dataSourceType.Assembly)
                {
                    var innerSource = GetDataSource(propertyInfo, dataFeedType);
                    source.NestedClasses.Add(innerSource);
                }
                else
                {
                    source.Fields.Add(new ViewDataMember()
                    {
                        Name = propertyInfo.Name,
                        Path = $"{propertyInfo.ReflectedType.FullName}.{propertyInfo.Name}",
                        DataFeed = dataFeedType.Name,
                        DataFeedTypeAssemblyQualifiedName = dataFeedType.AssemblyQualifiedName,
                        DataFeedTypeFullName = dataFeedType.FullName,
                        Type = propertyInfo.PropertyType.ToString(),
                        AssemblyQualifiedName = propertyInfo.PropertyType.AssemblyQualifiedName
                    });
                }
            }

            return source;
        }

        #endregion
    }
}
