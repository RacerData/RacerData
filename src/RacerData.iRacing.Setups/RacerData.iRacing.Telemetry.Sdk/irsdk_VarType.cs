namespace RacerData.iRacing.TelemetrySdk
{
    public enum irsdk_VarType
    {
        // 1 byte
        irsdk_char = 0,
        irsdk_bool,

        // 4 bytes
        irsdk_int,
        irsdk_bitField,
        irsdk_float,

        // 8 bytes
        irsdk_double,

        //index, don't use
        irsdk_ETCount
    }
}
