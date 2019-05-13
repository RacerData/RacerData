using System;
using System.Collections.Generic;
using System.Reflection;
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

            sources.Add(GetFeedDataSource(typeof(LiveFeedData)));
            sources.Add(GetFeedDataSource(typeof(IList<LivePitData>)));
            sources.Add(GetFeedDataSource(typeof(IList<LiveFlagData>)));
            sources.Add(GetFeedDataSource(typeof(IList<LivePointsData>)));
            sources.Add(GetFeedDataSource(typeof(IList<LiveQualifyingData>)));
            sources.Add(GetFeedDataSource(typeof(LapTimeData)));
            sources.Add(GetFeedDataSource(typeof(LapAverageData)));

            return sources;
        }

        #endregion

        #region protected

        protected virtual ViewDataSource GetFeedDataSource(Type dataFeedType)
        {
            var path = "";
            var dataFeedName = dataFeedType.IsGenericType ? $"{ dataFeedType.GenericTypeArguments[0].Name}[]" : dataFeedType.Name;

            ViewDataSource source = new ViewDataSource()
            {
                Name = dataFeedName,
                DataFeed = dataFeedName,
                DataFeedType = dataFeedType,
                Type = dataFeedType.IsGenericType ?
                    dataFeedType.GenericTypeArguments[0] :
                    dataFeedType
            };

            foreach (PropertyInfo propertyInfo in source.Type.GetProperties())
            {
                if (propertyInfo.PropertyType.Name.Contains("List"))
                {
                    var innerSource = GetNestedDataSource(propertyInfo, dataFeedName, dataFeedType, $"{path}", $"{propertyInfo.Name}[]");
                    source.Lists.Add(innerSource);
                }
                else if (propertyInfo.PropertyType.Name.StartsWith("System"))
                {
                    var innerSource = GetNestedDataSource(propertyInfo, dataFeedName, dataFeedType, $"{path}", propertyInfo.Name);
                    source.NestedClasses.Add(innerSource);
                }
                else
                {
                    source.Fields.Add(new ViewDataMember()
                    {
                        Name = propertyInfo.Name,
                        Path = $"{path}{propertyInfo.Name}",
                        Type = propertyInfo.PropertyType,
                        DataFeed = dataFeedName,
                        DataFeedType = source.DataFeedType
                    });
                }
            }

            return source;
        }

        protected virtual ViewDataSource GetNestedDataSource(PropertyInfo sourcePropertyInfo, string dataFeedName, Type dataFeedType, string path, string parentMember)
        {
            ViewDataSource source = new ViewDataSource()
            {
                Name = sourcePropertyInfo.Name,
                DataFeed = dataFeedName,
                DataFeedType = dataFeedType,
                Path = $"{path}{parentMember}",
                Type = sourcePropertyInfo.PropertyType.IsGenericType ?
                    sourcePropertyInfo.PropertyType.GenericTypeArguments[0] :
                    sourcePropertyInfo.PropertyType
            };

            var memberPath = $"{source.Path}\\";

            foreach (PropertyInfo propertyInfo in source.Type.GetProperties())
            {
                if (propertyInfo.PropertyType.Name.Contains("List"))
                {
                    var innerSource = GetNestedDataSource(propertyInfo, dataFeedName, dataFeedType, $"{memberPath}", $"{propertyInfo.Name}[]");
                    source.Lists.Add(innerSource);
                }
                else if (propertyInfo.PropertyType.Name.StartsWith("System"))
                {
                    var innerSource = GetNestedDataSource(propertyInfo, dataFeedName, dataFeedType, $"{memberPath}", $"{propertyInfo.Name}");
                    source.NestedClasses.Add(innerSource);
                }
                else
                {
                    source.Fields.Add(new ViewDataMember()
                    {
                        Name = propertyInfo.Name,
                        Path = $"{memberPath}{propertyInfo.Name}",
                        Type = propertyInfo.PropertyType,
                        DataFeed = dataFeedName,
                        DataFeedType = source.DataFeedType
                    });
                }
            }

            return source;
        }

        #endregion
    }
}
