﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using RacerData.NascarApi.Service;
using RacerData.rNascarApp.Extensions;
using RacerData.rNascarApp.Models;
using RacerData.rNascarApp.Settings;

namespace RacerData.rNascarApp.Services
{
    internal class DataParserService
    {
        #region properties

        public ApiFeedType ApiFeedType { get; set; }
        public IList<ListColumn> Columns { get; set; }
        public int? RowCount { get; set; }
        public int? SortColumnIndex { get; set; }
        public SortType SortType { get; set; }

        #endregion

        #region public

        public virtual object[] GetViewData(object data)
        {
            var dataArray = GetListData(data);

            object[] viewDataArray = new object[dataArray.GetLength(0)];
            for (int i = 0; i < viewDataArray.Length; i++)
            {
                viewDataArray[i] = dataArray[0, i];
            }

            return viewDataArray;
        }

        public virtual object[,] GetListData(object dataSource)
        {
            if (!Columns.Any(c => c.ApiFeedType.HasFlag(ApiFeedType)))
                return null;

            object[,] dataValues = new object[50, Columns.Count];

            var orderedColumns = Columns.OrderBy(c => c.Index).ToList();

            for (int i = 0; i < Columns.Count; i++)
            {
                var column = orderedColumns[i];
                var dataPathSections = column.DataPath.Split('\\');
                Type dataMemberType = dataSource.GetType();
                string dataMemberPropertyName = string.Empty;
                PropertyInfo dataMemberPropertyInfo = null;
                object dataMemberValue = dataSource;
                int listDataMemberSectionIndex = -1;

                if (dataMemberType.Name != "List`1")
                {
                    // Root is not a list type.
                    // Iterate each path section to get to the data member object that is a list.
                    for (int dataPathSectionIndex = 0; dataPathSectionIndex < dataPathSections.Length; dataPathSectionIndex++)
                    {
                        if (dataPathSections[dataPathSectionIndex].Contains("[]"))
                        {
                            // This section is a list type
                            dataMemberPropertyName = dataPathSections[dataPathSectionIndex].Replace("[]", "");

                            dataMemberPropertyInfo = dataMemberType.GetProperty(dataMemberPropertyName);

                            dataMemberType = dataMemberPropertyInfo.PropertyType;

                            dataMemberValue = dataMemberPropertyInfo.GetValue(dataMemberValue);

                            listDataMemberSectionIndex = dataPathSectionIndex;

                            break;
                        }
                        else
                        {
                            // This section is *not* a list type.
                            // Update the fields and move to the next section.
                            dataMemberPropertyInfo = dataMemberType.GetProperty(dataMemberPropertyName);

                            dataMemberType = dataMemberPropertyInfo.PropertyType;

                            dataMemberValue = dataMemberPropertyInfo.GetValue(dataMemberValue);
                        }
                    }
                }

                string[] dataPathSectionsFromList = null;
                // At this point we either have a list object, or there is no list.
                if (dataMemberType.Name != "List`1" || listDataMemberSectionIndex == dataPathSections.Length - 1)
                {
                    // If we have a list, there should be more than one section left in the path.
                    // ex. {root}\Vehicles[]\Driver\Name
                    // We should not have a list as the last section unless we implement grouping to acquire values.

                    // Copy the remaining path sections to a new array.
                    int sectionsAfterListObject = dataPathSections.Length - listDataMemberSectionIndex - 1;
                    dataPathSectionsFromList = new string[sectionsAfterListObject];
                    Array.Copy(dataPathSections, listDataMemberSectionIndex + 1, dataPathSectionsFromList, 0, sectionsAfterListObject);
                }
                else
                {
                    // If we do not have a list, then we should be at the 
                    // last section of the path, and all rows get the same value.
                    // Ex. {root}\LapNumber or {root}\Stage\Name
                    dataPathSectionsFromList = new string[1] { dataPathSections.LastOrDefault() };
                }

                int maxDataRows = 1;
                // Need to loop through the rows, and then drill down (if needed) for each row
                // to get to the target data member.
                if (dataMemberType.Name == "List`1")
                {
                    string indexerName = (
                      (DefaultMemberAttribute)dataMemberType
                      .GetCustomAttributes(
                          typeof(DefaultMemberAttribute),
                          true)[0])
                          .MemberName;

                    dataMemberPropertyInfo = dataMemberType.GetProperty(indexerName);

                    PropertyInfo lengthPropertyInfo = dataMemberType.GetProperty("Count");

                    int listDataMemberCount = (int)lengthPropertyInfo.GetValue(dataMemberValue);

                    // Limit the # of rows read to the # of rows in the list, or
                    // the rowCount value provided, whichever is less.
                    maxDataRows = RowCount.HasValue ?
                        RowCount.Value <= listDataMemberCount ?
                            RowCount.Value :
                            listDataMemberCount :
                        listDataMemberCount;
                }

                // Load the object for each row, then drill down (if needed) to 
                // get to the final path section.
                Object currentRowValue = null;
                for (int r = 0; r < maxDataRows; r++)
                {
                    // Get the instance reference to the object at the correct row in the list.
                    if (dataMemberType.Name == "List`1")
                        currentRowValue = dataMemberPropertyInfo.GetValue(dataMemberValue, new Object[] { r });
                    else
                        currentRowValue = dataMemberValue;

                    var currentRowType = currentRowValue.GetType();

                    PropertyInfo currentRowMemberProperty = null;
                    object currentRowMemberValue = null;

                    // Drill down to the final data path section
                    for (int x = 0; x < dataPathSectionsFromList.Length; x++)
                    {
                        // Get the object at the path level
                        // A class if not the final level, or
                        // a property if at the final level
                        currentRowMemberProperty = currentRowType.GetProperty(dataPathSectionsFromList[x]);
                        currentRowMemberValue = currentRowMemberProperty.GetValue(currentRowValue);
                        try
                        {
                            currentRowType = currentRowMemberProperty.PropertyType;
                            currentRowValue = currentRowMemberValue;
                        }
                        catch (Exception)
                        {

                            throw;
                        }
                       
                    }

                    //Console.WriteLine($"Writing {currentRowMemberValue} to {r},{i}");
                    // At the final path level.
                    dataValues[r, i] = currentRowMemberValue;
                }
            }

            return dataValues;
        }

        public virtual object[,] SortListData(object[,] dataValues)
        {
            if (!SortColumnIndex.HasValue)
                return dataValues;
            else
                return SortType == SortType.Ascending ?
                    dataValues.OrderBy(x => x[SortColumnIndex.Value]) :
                    dataValues.OrderByDescending(x => x[SortColumnIndex.Value]);
        }

        #endregion
    }
}