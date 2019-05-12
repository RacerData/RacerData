using System;
using System.Reflection;
using System.Text;

namespace RacerData.rNascarApp.Models
{
    public class DataParserDrillDownException : Exception
    {
        #region properties

        public PropertyInfo DataMemberProperty { get; set; }
        public object DataMemberValue { get; set; }
        public Type DataMemberType { get; set; }
        public object DataMemberPropertyName { get; set; }
        public int DataPathSectionIndex { get; set; }
        public string[] DataPathSections { get; set; }
        public string DataSource { get; set; }
        public override string Message
        {
            get
            {
                return $"{base.Message}:\r\n{Details}";
            }
        }
        public string Details
        {
            get
            {
                StringBuilder sb = new StringBuilder();

                sb.AppendLine($"DataMemberProperty: {DataMemberProperty?.Name ?? "null" }");
                sb.AppendLine($"DataMemberValue: {(DataMemberValue != null ? "not null" : "null") }");
                sb.AppendLine($"DataMemberType: {DataMemberType?.Name ?? "null" }");
                sb.AppendLine($"DataMemberPropertyName: {DataMemberPropertyName ?? "null" }");
                sb.AppendLine($"DataPathSectionIndex: {DataPathSectionIndex}");
                sb.AppendLine($"DataPathSections: {(DataPathSections != null ? String.Join(",", DataPathSections) : "null") }");
                sb.AppendLine($"DataSource: {DataSource ?? "null" }");

                return sb.ToString();
            }
        }

        #endregion

        #region ctor

        public DataParserDrillDownException()
            : base("Data PArser Error")
        {

        }

        public DataParserDrillDownException(string message)
            : base(message)
        {

        }

        public DataParserDrillDownException(string message, Exception innerException)
            : base(message, innerException)
        {

        }

        #endregion
    }
}
