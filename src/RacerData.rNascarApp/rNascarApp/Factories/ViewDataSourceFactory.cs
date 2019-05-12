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

            //System.Text.StringBuilder sb = new System.Text.StringBuilder();

            //foreach (ViewDataSource source in sources)
            //{
            //    sb = PrintHeader(sb, 0);
            //    sb = PrintViewDataSource(sb, source, 0);
            //    sb.AppendLine();
            //}

            //Console.WriteLine(sb);

            return sources;
        }

        #endregion

        #region protected

        // Top-level data feed
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

        #region private [debug printing]

        private int indentMultiplier = 4;
        private System.Text.StringBuilder PrintViewDataSources(System.Text.StringBuilder sb, IList<ViewDataSource> sources, int level)
        {
            foreach (ViewDataSource source in sources)
            {
                sb = PrintHeader(sb, level);
                sb = PrintViewDataSource(sb, source, level);
            }

            return sb;
        }
        private System.Text.StringBuilder PrintHeader(System.Text.StringBuilder sb, int level)
        {
            var indent = new String(' ', level * indentMultiplier);

            sb.AppendFormat("{0}{1, -24}{2, -40}{3, -40}{4, -74}\r\n", indent, "-----------------------", "---------------------------------------", "---------------------------------------", "-------------------------------------------------------------------------");
            sb.AppendFormat("{0}{1, -24}{2, -40}{3, -40}{4, -74}\r\n", indent, "Name", "Path", "DataFeed", "TypeName");
            sb.AppendFormat("{0}{1, -24}{2, -40}{3, -40}{4, -74}\r\n", indent, "-----------------------", "---------------------------------------", "---------------------------------------", "-------------------------------------------------------------------------");

            return sb;
        }
        private System.Text.StringBuilder PrintViewDataSource(System.Text.StringBuilder sb, ViewDataSource source, int level)
        {
            var indent = new String(' ', level * indentMultiplier);
            sb.AppendFormat("{0}-{1, -23}{2, -40}{3, -40}{4, -74}\r\n", indent, source.Name, source.Path, source.DataFeed, source.Type.Name);
            sb.AppendLine();

            //sb.AppendLine($"{indent}source.Name: {source.Name}");
            //sb.AppendLine($"{indent}> {source.Name}: {source.Path}");
            //sb.AppendLine($"{indent}source.TypeName: {source.TypeName}");
            //sb.AppendLine($"{indent}source.Type: {source.Type.ToString()}");

            indent = new String(' ', (level + 1) * indentMultiplier);

            if (source.Fields.Count > 0)
            {
                sb.AppendLine($"{indent}[ Properties ]");
                sb = PrintHeader(sb, level + 1);
                sb = PrintViewDataMembers(sb, source.Fields, level + 1);
            }
            if (source.Lists.Count > 0)
            {
                sb.AppendLine($"{indent}[ Lists ]");
                sb = PrintViewDataSources(sb, source.Lists, level + 1);
            }
            if (source.NestedClasses.Count > 0)
            {
                sb.AppendLine($"{indent}[ Classes ]");
                sb = PrintViewDataSources(sb, source.NestedClasses, level + 1);
            }
            return sb;
        }
        private System.Text.StringBuilder PrintViewDataMembers(System.Text.StringBuilder sb, IList<ViewDataMember> members, int level)
        {
            foreach (ViewDataMember member in members)
            {
                sb = PrintViewDataMember(sb, member, level);
            }
            sb.AppendLine();
            return sb;
        }
        private System.Text.StringBuilder PrintViewDataMember(System.Text.StringBuilder sb, ViewDataMember member, int level)
        {
            var indent = new String(' ', level * indentMultiplier);
            sb.AppendFormat("{0}{1, -24}{2, -40}{3, -40}{4,-74}\r\n", indent, member.Name, member.Path, member.DataFeed, member.Type.Name);

            //sb.AppendLine($"{indent}member.Name: {member.Name}");
            //sb.AppendLine($"{indent}{member.Name}: {member.Path}");
            //sb.AppendLine($"{indent}member.TypeName: {member.TypeName}");
            //sb.AppendLine($"{indent}member.Type: {member.Type?.ToString()}");

            return sb;
        }
        #endregion
    }
}
