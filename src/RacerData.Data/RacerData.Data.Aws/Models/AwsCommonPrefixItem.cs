using System;

namespace RacerData.Data.Aws.Models
{
    public class AwsCommonPrefixItem : IAwsListItem
    {
        #region properties

        public string Key { get; set; }
        public string ETag { get; set; }
        public DateTime LastModified { get; set; }

        #endregion
    }
}
