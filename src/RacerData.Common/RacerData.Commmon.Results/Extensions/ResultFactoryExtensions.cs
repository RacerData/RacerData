using System;
using System.Net;
using RacerData.Common.Results;

namespace RacerData.Commmon.Results
{
    public static class ResultFactoryExtensions
    {
        #region Success

        public static IResult Success(this IResultFactory factory)
        {
            return factory.Create(HttpStatusCode.OK);
        }

        public static IResult<TValue> Success<TValue>(this IResultFactory factory, TValue value)
        {
            return factory.Create(value, HttpStatusCode.OK);
        }

        #endregion

        #region Created

        public static IResult Created(this IResultFactory factory)
        {
            return factory.Create(HttpStatusCode.Created);
        }

        public static IResult<TValue> Created<TValue>(this IResultFactory factory, TValue value)
        {
            return factory.Create(value, HttpStatusCode.Created);
        }

        #endregion

        #region NoContent

        public static IResult NoContent(this IResultFactory factory)
        {
            return factory.Create(HttpStatusCode.NoContent);
        }

        public static IResult<TValue> NoContent<TValue>(this IResultFactory factory)
        {
            return factory.Create<TValue>(HttpStatusCode.NoContent);
        }

        #endregion

        #region NotFound

        public static IResult NotFound(this IResultFactory factory)
        {
            return factory.Create(HttpStatusCode.NotFound);
        }

        public static IResult<TValue> NotFound<TValue>(this IResultFactory factory)
        {
            return factory.Create<TValue>(HttpStatusCode.NotFound);
        }

        #endregion

        #region Exceptions

        public static IResult Exception(this IResultFactory factory, Exception ex)
        {
            return factory.Create(ex);
        }

        public static IResult<TValue> Exception<TValue>(this IResultFactory factory, Exception ex)
        {
            return factory.Create<TValue>(ex);
        }

        #endregion
    }
}
