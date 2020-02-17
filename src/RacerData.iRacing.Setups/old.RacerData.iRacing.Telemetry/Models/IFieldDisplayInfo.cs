namespace RacerData.iRacing.Telemetry.Models
{
    public interface IFieldDisplayInfo
    {
        string Name { get; set; }
        string Key { get; set; }
        string Path { get; set; }
        int ColorA { get; set; }
        int ColorB { get; set; }
        int ColorG { get; set; }
        int ColorR { get; set; }
        string Conversion { get; set; }
        string ConvertedUnit { get; set; }
        string Format { get; set; }
        float RangeMax { get; set; }
        float RangeMin { get; set; }
        float Thickness { get; set; }
        string Unit { get; set; }
        string Group { get; set; }
        bool IsCalculated { get; set; }
    }
}