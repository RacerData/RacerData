using System;
using System.Net;
using RacerData.Common.Results;

namespace RacerData.Commmon.Results
{
    /// <summary>
    /// Factory for creating typed results.
    /// </summary>
    public interface IResultFactory<TSource> : IResultFactory
    {
        IResult<TValue> Create<TValue>(TValue value);

        IResult<TValue> Create<TValue>(TValue value, HttpStatusCode httpStatusCode);

        IResult<TValue> Create<TValue>(Exception ex);
    }
}