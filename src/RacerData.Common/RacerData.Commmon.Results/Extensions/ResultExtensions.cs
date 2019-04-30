using RacerData.Commmon.Results.Models;
using RacerData.Common.Results;

namespace RacerData.Commmon.Results
{
    public static class ResultExtensions
    {
        public static bool IsSuccessful(this IResult result)
        {
            return result.Exception == null;
        }
    }
}
