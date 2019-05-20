using System;
using System.Net;

namespace RacerData.Common.Results
{
    public interface IResult
    {
        /// <summary>
        /// HttpStatusCode of the result
        /// </summary>
        HttpStatusCode HttpStatusCode { get; set; }

        /// <summary>
        /// Exception (if any) from the result
        /// </summary>
        Exception Exception { get; }
    }
}
