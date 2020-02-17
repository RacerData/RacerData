namespace RacerData.iRacing.Telemetry.Models
{
    public interface IValue
    {
        string FieldName { get; }
        string Unit { get; }
        object FieldValue { get; }
        IFieldDefinition Definition { get; set; }
        bool IsConverted { get; }
    }
}