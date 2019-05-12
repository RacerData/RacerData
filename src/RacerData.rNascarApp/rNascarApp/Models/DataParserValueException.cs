using System;
using System.Reflection;
using System.Text;

namespace RacerData.rNascarApp.Models
{
    public class DataParserValueException : Exception
    {
        #region properties

        public PropertyInfo CurrentRowMemberProperty { get; set; }
        public object CurrentRowMemberValue { get; set; }
        public Type CurrentRowType { get; set; }
        public object CurrentRowValue { get; set; }
        public int DrillDownLevelIndex { get; set; }
        public string[] DataPathSectionsFromList { get; set; }
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

                sb.AppendLine($"CurrentRowMemberProperty: {CurrentRowMemberProperty?.Name ?? "null" }");
                sb.AppendLine($"CurrentRowMemberValue: {(CurrentRowMemberValue != null ? "not null" : "null") }");
                sb.AppendLine($"CurrentRowType: {CurrentRowType?.Name ?? "null" }");
                sb.AppendLine($"CurrentRowValue: {(CurrentRowValue != null ? "not null" : "null") }");

                sb.AppendLine($"DrillDownLevelIndex: {DrillDownLevelIndex}");
                sb.AppendLine($"DataPathSectionsFromList: {(DataPathSectionsFromList != null ? String.Join(",", DataPathSectionsFromList) : "null") }");
                sb.AppendLine($"DataSource: {DataSource ?? "null" }");

                return sb.ToString();
            }
        }

        #endregion

        #region ctor

        public DataParserValueException()
            : base("Data Parser Value Error")
        {

        }

        public DataParserValueException(string message)
            : base(message)
        {

        }

        public DataParserValueException(string message, Exception innerException)
            : base(message, innerException)
        {

        }

        #endregion
    }
}
