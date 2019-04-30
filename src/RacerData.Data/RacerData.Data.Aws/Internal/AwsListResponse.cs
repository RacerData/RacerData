using System;
using System.Collections.Generic;

namespace RacerData.Data.Aws.Internal
{
    class AwsListResponse
    {
        #region properties

        public IList<AwsItemListResponse> Responses { get; set; }

        private bool _isSuccess = true;
        public bool IsSuccess
        {
            get
            {
                if (Exception != null)
                    return false;
                else
                    return _isSuccess;
            }
            set
            {
                _isSuccess = value;
            }
        }

        public Exception Exception { get; set; }

        #endregion

        #region ctor

        public AwsListResponse()
        {
            Responses = new List<AwsItemListResponse>();
        }

        #endregion
    }
}
