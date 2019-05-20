using System;
using System.Net;
using RacerData.Common.Results;

namespace RacerData.Commmon.Results.Models
{
    internal class Result : IResult
    {
        #region properties

        /// <inheritdoc />
        public Exception Exception { get; private set; }

        /// <inheritdoc />
        public HttpStatusCode HttpStatusCode { get; set; } = HttpStatusCode.Accepted;

        #endregion

        #region ctor

        public Result()
        {

        }

        public Result(HttpStatusCode httpStatusCode)
        {
            HttpStatusCode = httpStatusCode;
        }

        public Result(Exception ex)
        {
            Exception = ex ?? throw new ArgumentNullException(nameof(ex));
        }

        #endregion
    }
}
