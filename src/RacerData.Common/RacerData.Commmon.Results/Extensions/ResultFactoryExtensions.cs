using System;
using RacerData.Common.Results;

namespace RacerData.Commmon.Results
{
    public static class ResultFactoryExtensions
    {
        #region Success

        public static IResult Success(this IResultFactory factory)
        {
            return factory.Create();
        }

        public static IResult<TValue> Success<TValue>(this IResultFactory factory, TValue value)
        {
            return factory.Create(value);
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
