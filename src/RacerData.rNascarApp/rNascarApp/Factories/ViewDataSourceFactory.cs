using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

            sources.Add(GetDataSource("LiveFeedData", typeof(LiveFeedData), "LiveFeedData"));
            sources.Add(GetDataSource("LivePitData[]", typeof(LivePitData), "LivePitData"));
            sources.Add(GetDataSource("LiveFlagData[]", typeof(LiveFlagData), "LiveFlagData"));
            sources.Add(GetDataSource("LivePointsData[]", typeof(LivePointsData), "LivePointsData"));
            sources.Add(GetDataSource("LiveQualifyingData[]", typeof(LiveQualifyingData), "LiveQualifyingData"));

            var paths = sources.Where(s => s.Path == "");

            return sources;
        }

        #endregion

        #region protected

        protected virtual ViewDataSource GetDataSource(string name, Type dataSourceType, string dataFeedName)
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
                if (propertyInfo.PropertyType.Name.Contains("List"))
                {
                    var innerSource = GetDataSource(propertyInfo, dataFeedName);
                    source.Lists.Add(innerSource);
                }
                else if (propertyInfo.PropertyType.Assembly == dataSourceType.Assembly)
                {
                    var innerSource = GetDataSource(propertyInfo, dataFeedName);
                    source.NestedClasses.Add(innerSource);
                }
                else
                {
                    source.Fields.Add(new ViewDataMember()
                    {
                        Name = propertyInfo.Name,
                        Path = $"{propertyInfo.ReflectedType.FullName}.{propertyInfo.Name}",
                        DataFeed = dataFeedName,
                        Type = propertyInfo.PropertyType.ToString(),
                        AssemblyQualifiedName = propertyInfo.PropertyType.AssemblyQualifiedName
                    });
                }
            }

            return source;
        }

        protected virtual ViewDataSource GetDataSource(PropertyInfo sourcePropertyInfo, string dataFeedName)
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
                if (propertyInfo.PropertyType.Name.Contains("List"))
                {
                    var innerSource = GetDataSource(propertyInfo, dataFeedName);
                    source.Lists.Add(innerSource);
                }
                else if (propertyInfo.PropertyType.Assembly == dataSourceType.Assembly)
                {
                    var innerSource = GetDataSource(propertyInfo, dataFeedName);
                    source.NestedClasses.Add(innerSource);
                }
                else
                {
                    source.Fields.Add(new ViewDataMember()
                    {
                        Name = propertyInfo.Name,
                        Path = $"{propertyInfo.ReflectedType.FullName}.{propertyInfo.Name}",
                        DataFeed = dataFeedName,
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
