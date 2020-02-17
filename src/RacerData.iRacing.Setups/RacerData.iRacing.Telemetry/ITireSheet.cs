namespace RacerData.iRacing.Telemetry
{
    public interface ITireSheet
    {
        ITireReadings LF { get; set; }
        ITireReadings LR { get; set; }
        ITireReadings RF { get; set; }
        ITireReadings RR { get; set; }

        float EffectiveTemperatureBalance { get; }
        float EffectiveWearBalance { get; }
    }
}