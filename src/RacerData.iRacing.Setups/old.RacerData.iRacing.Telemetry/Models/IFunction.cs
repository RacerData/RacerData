namespace RacerData.iRacing.Telemetry.Models
{
    public interface IFunction
    {
        string Key { get; set; }
        string Name { get; set; }
        string Description { get; set; }
        string Expression { get; set; }
        string Format { get; set; }
        string Unit { get; set; }
        float? MinValue { get; set; }
        float? MaxValue { get; set; }
    }
}
