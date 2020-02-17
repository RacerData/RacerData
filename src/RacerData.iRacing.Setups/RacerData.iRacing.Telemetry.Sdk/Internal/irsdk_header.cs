namespace RacerData.iRacing.Telemetry.Sdk.Internal
{
    internal struct irsdk_header
    {
        public int ver;                // this api header version, see IRSDK_VER
        public int status;             // bitfield using irsdk_StatusField
        public int tickRate;           // ticks per second (60 or 360 etc)

        // session information, updated periodicaly
        public int sessionInfoUpdate;  // Incremented when session info changes
        public int sessionInfoLen;     // Length in bytes of session info string
        public int sessionInfoOffset;  // Session info, encoded in YAML format

        // State data, output at tickRate

        public int numVars;            // length of arra pointed to by varHeaderOffset
        public int varHeaderOffset;    // offset to irsdk_varHeader[numVars] array, Describes the variables received in varBuf

        public int numBuf;             // <= IRSDK_MAX_BUFS (3 for now)
        public int bufLen;             // length in bytes for one line
                                       //int pad1[2];            // (16 byte align)
                                       //irsdk_varBuf varBuf[IRSDK_MAX_BUFS]; // buffers of data being written to
    }
}
