using System;
using System.Net;
using RacerData.Common.Results;

namespace RacerData.Commmon.Results
{
    /// <summary>
    /// Factory for creating results.
    /// </summary>
    public interface IResultFactory
    {
        IResult Create();

        IResult Create(HttpStatusCode httpStatusCode);

        IResult Create(Exception ex);

        IResult<TValue> Create<TValue>(TValue value);

        IResult<TValue> Create<TValue>(TValue value, HttpStatusCode httpStatusCode);

        IResult<TValue> Create<TValue>(HttpStatusCode httpStatusCode);

        IResult<TValue> Create<TValue>(Exception ex);
    }
}