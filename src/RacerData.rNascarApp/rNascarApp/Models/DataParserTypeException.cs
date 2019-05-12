using System;

namespace RacerData.rNascarApp.Models
{
    public class DataParserTypeException : Exception
    {
        #region properties

        public string DataMemberTypeName { get; set; }

        #endregion

        #region ctor

        public DataParserTypeException()
            : base("Data Parser Type Error")
        {

        }

        public DataParserTypeException(string message)
            : base(message)
        {

        }

        public DataParserTypeException(string message, Exception innerException)
            : base(message, innerException)
        {

        }

        #endregion
    }
}
