namespace RacerData.iRacing.Telemetry.Sdk.Internal
{
    internal class TelemetryField
    {
        public int Index { get; internal set; }
        public string Name { get; internal set; }
        public string Description { get; internal set; }
        public string Unit { get; internal set; }
        public irsdk_VarType DataType { get; internal set; }
        public int Size
        {
            get
            {
                if (DataType == irsdk_VarType.irsdk_bool)
                    return 1;
                else if (DataType == irsdk_VarType.irsdk_int)
                    return 4;
                else if (DataType == irsdk_VarType.irsdk_bitField)
                    return 4;
                else if (DataType == irsdk_VarType.irsdk_float)
                    return 4;
                else if (DataType == irsdk_VarType.irsdk_double)
                    return 8;
                else
                    return 0;
            }
        }
        public bool FieldCountAsTime { get; internal set; }
        public bool FieldInstanceCount { get; internal set; }
    }
}