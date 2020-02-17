namespace RacerData.iRacing.Telemetry.Sdk.Internal
{
    internal static class TelemetryConsts
    {
        #region consts

        public const int FieldDescriptionLength = 144;
        public const int FieldDescriptionLengthStart = 0;
        public const int FieldDescriptionPositionStart = 4;
        public const int FieldCountAsTimePositionStart = 12;
        public const int FieldInstanceCountPositionStart = 8;
        public const int FieldDescriptionNameStart = 16;
        public const int FieldDescriptionNameLength = 32;
        public const int FieldDescriptionDescriptionStart = 48;
        public const int FieldDescriptionDescriptionLength = 64;
        public const int FieldDescriptionUnitStart = 112;
        public const int FieldDescriptionUnitLength = 32;

        public const int IntFieldLength = 2;
        public const int DoubleFieldLength = 4;
        public const int DateFieldLength = 4;

        public const int VersionOffset = 0;
        public const int StatusOffset = 4;
        public const int TickRateOffset = 8;
        public const int SessionInfoUpdateOffset = 12;
        public const int SessionInfoLenOffset = 16;
        public const int SessionInfoOffsetOffset = 20;
        public const int NumVarsOffset = 24;
        public const int VarHeaderOffsetOffset = 28;
        public const int NumberOfBuffersOffset = 32;
        public const int BufferLengthOffset = 36;
        
        public const int BufferArrayOffset = 48;
        public const int BufferArrayItemLength = 32;
        public const int BufferArrayCount = 4;

        public const int FrameCountOffset = 140;

        #endregion
    }
}
