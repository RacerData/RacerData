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
    }
}