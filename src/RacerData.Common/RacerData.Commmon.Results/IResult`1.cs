namespace RacerData.Common.Results
{
    public interface IResult<T> : IResult
    {
        T Value { get; }
    }
}
