using System.Collections.Generic;

namespace RacerData.iRacing.Telemetry
{
    public interface ITireReadings
    {
        float ColdPsi { get; set; }
        float HotPsi { get; set; }

        float DeltaPsi { get; }
        float EffectiveTemperature { get; }
        float EffectiveWear { get; }

        IDictionary<TreadPosition, float> Temperatures { get; set; }
        TirePosition TirePosition { get; set; }
        IDictionary<TreadPosition, float> Wear { get; set; }
    }
}