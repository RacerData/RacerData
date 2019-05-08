using System;
using System.Drawing;
using RacerData.rNascarApp.Models;

namespace RacerData.rNascarApp.Settings
{
    public class ViewListColumn
    {
        public int Index { get; set; }
        public string Caption { get; set; }
        public string DataFeed { get; set; }
        public string DataFeedAssemblyQualifiedName { get; set; }
        public string DataFeedFullName { get; set; }
        public string DataMember { get; set; }
        public string DataFullPath { get; set; }
        public string ConvertedType { get; set; }
        public string Type { get; set; }
        public int? Width { get; set; }
        public ContentAlignment Alignment { get; set; } = ContentAlignment.MiddleLeft;
        public string Format { get; set; }
        public string Sample { get; set; }
        public SortType SortType { get; set; }
    }
}
