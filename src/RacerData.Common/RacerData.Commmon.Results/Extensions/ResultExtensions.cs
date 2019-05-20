using RacerData.Commmon.Results.Models;
using RacerData.Common.Results;

namespace RacerData.Commmon.Results
{
    public static class ResultExtensions
    {
        public static bool IsSuccessful(this IResult result)
        {
            return (result.Exception == null && (int)result.HttpStatusCode < 400);
        }

        public static IResult<TValue> AsType<TValue>(this IResult result)
        {
            return new Result<TValue>(result);
        }
    }
}
