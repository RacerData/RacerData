using System;
using System.Collections.Generic;

namespace RacerData.Data.Aws.Models
{
    public class AwsItem : IAwsItem
    {
        #region properties

        public string Key { get; set; }
        public string Content { get; set; }
        public string ContentType { get; set; }
        public int ContentLength { get; set; }
        public string ETag { get; set; }
        public DateTime LastModified { get; set; }

        public IDictionary<string, string> Metadata { get; set; }

        #endregion

        #region ctor

        public AwsItem()
        {
            Metadata = new Dictionary<string, string>();
        }

        #endregion
    }
}
