using System.Collections.Generic;

namespace RacerData.iRacing.Telemetry.Models
{
    public interface ISessionData
    {
        IList<IFieldDefinition> Fields { get; set; }
        IList<IFrame> Frames { get; set; }
        IList<ILapInfo> Laps { get; set; }
        ISessionDictionaries SessionInfo { get; set; }
        ISetupInfo SetupInfo { get; set; }
        IDictionary<object, object> ActiveSessionInfo { get; }

        string FieldsToString();
        string ToString();
        string ValuesToString();
    }
}