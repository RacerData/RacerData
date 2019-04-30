using System;
using RacerData.Data.Aws.Models;

namespace RacerData.Data.Aws.Internal
{
    class AwsItemResponse : AwsResponse
    {
        #region properties

        public IAwsItem Item { get; set; }
        public string VersionId { get; set; }
        public string ETag { get; set; }
        public DateTime LastModified { get; set; }

        #endregion

        #region ctor

        public AwsItemResponse()
            : base()
        {
            Item = new AwsItem();
        }

        #endregion
    }
}
