using System;
using System.Collections.Generic;
using System.Net;

namespace RacerData.Data.Aws.Internal
{
    class AwsResponse
    {
        #region properties

        public HttpStatusCode HttpStatusCode { get; set; }

        public string RequestId { get; set; }

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

        public IDictionary<string, string> Metadata { get; set; }

        public Exception Exception { get; set; }

        #endregion

        #region ctor

        public AwsResponse()
        {
            Metadata = new Dictionary<string, string>();
        }

        #endregion
    }
}
