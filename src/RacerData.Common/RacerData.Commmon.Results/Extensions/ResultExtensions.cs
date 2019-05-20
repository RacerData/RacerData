using RacerData.Common.Results;

namespace RacerData.Commmon.Results
{
    public static class ResultExtensions
    {
        public static bool IsSuccessful(this IResult result)
        {
            return (result.Exception == null && (int)result.HttpStatusCode < 300);
        }
    }
}
