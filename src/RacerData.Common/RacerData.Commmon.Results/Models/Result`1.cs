using System;
using System.Net;
using RacerData.Common.Results;

namespace RacerData.Commmon.Results.Models
{
    internal class Result<TValue> : Result, IResult<TValue>
    {
        #region properties

        /// <inheritdoc />
        public TValue Value { get; private set; }

        #endregion

        #region ctor

        public Result(TValue value)
            : base()
        {
            Value = value;
        }

        public Result(TValue value, HttpStatusCode httpStatusCode)
            : base(httpStatusCode)
        {
            Value = value;
        }

        public Result(Exception ex)
            : base(ex)
        {
        }

        #endregion
    }
}
