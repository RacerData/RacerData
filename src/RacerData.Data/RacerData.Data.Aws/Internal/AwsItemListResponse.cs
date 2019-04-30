using System.Collections.Generic;
using System.Net;
using RacerData.Data.Aws.Models;

namespace RacerData.Data.Aws.Internal
{
    class AwsItemListResponse
    {
        #region properties

        public HttpStatusCode HttpStatusCode { get; set; }
        public string RequestId { get; set; }

        public IList<IAwsListItem> Items { get; set; }

        #endregion

        #region ctor

        public AwsItemListResponse()
        {
            Items = new List<IAwsListItem>();
        }

        #endregion
    }
}
