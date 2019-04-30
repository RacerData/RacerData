using System;
using RacerData.Commmon.Results.Models;
using RacerData.Common.Results;

namespace RacerData.Commmon.Results.Factories
{
    class ResultFactory<TSource> : IResultFactory<TSource>
    {
        public IResult Create()
        {
            return new Result();
        }
        
        public IResult Create(Exception ex)
        {
            return new Result(ex);
        }
        public IResult<TValue> Create<TValue>(TValue value)
        {
            return new Result<TValue>(value);
        }

        public IResult<TValue> Create<TValue>(Exception ex)
        {
            return new Result<TValue>(ex);
        }
    }
}
