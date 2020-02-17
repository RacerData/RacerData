namespace RacerData.iRacing.TelemetrySdk
{
    public interface ITelemetryField
    {
        int Index { get; }
        irsdk_VarType DataType { get; }
        int Size { get; }
        string Name { get; }
        string Description { get; }
        string Group { get; }
        string Key { get; set; }
        string Unit { get; }
        bool FieldCountAsTime { get;}
        bool FieldInstanceCount { get;}
    }
}