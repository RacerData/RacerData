using System;
using RacerData.Common.Results;

namespace RacerData.Commmon.Results.Models
{
    internal class Result<TValue> : Result, IResult<TValue>
    {
        public TValue Value { get; private set; }

        public Result(TValue value) : base()
        {
            Value = value;
        }

        public Result(Exception ex) : base(ex)
        {
        }
    }
}
