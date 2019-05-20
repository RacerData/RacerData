namespace RacerData.Common.Results
{
    public interface IResult<T> : IResult
    {
        /// <summary>
        /// Typed value that is the result of the task
        /// </summary>
        T Value { get; }
    }
}
