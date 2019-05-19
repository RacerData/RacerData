using System;
using System.Collections.Generic;
using RacerData.Data.Aws.Models;

namespace RacerData.Data.Aws.Internal
{
    class AwsListResponse : AwsResponse
    {
        #region properties

        public IList<IAwsItem> Items { get; set; }

        #endregion

        #region ctor

        public AwsListResponse()
        {
            Items = new List<IAwsItem>();
        }

        #endregion
    }
}
