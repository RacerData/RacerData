using System;
using RacerData.Common.Results;

namespace RacerData.Commmon.Results.Models
{
    internal class Result : IResult
    {
        /// <inheritdoc />
        public Exception Exception { get; private set; }
      
        public Result()
        {

        }

        public Result(Exception ex)
        {
            Exception = ex ?? throw new ArgumentNullException(nameof(ex));

        }
    }
}
