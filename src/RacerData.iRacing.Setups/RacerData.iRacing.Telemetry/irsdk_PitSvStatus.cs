namespace RacerData.iRacing.Telemetry
{
    public enum irsdk_PitSvStatus
    {
        // status
        irsdk_PitSvNone = 0,
        irsdk_PitSvInProgress,
        irsdk_PitSvComplete,

        // errors
        irsdk_PitSvTooFarLeft = 100,
        irsdk_PitSvTooFarRight,
        irsdk_PitSvTooFarForward,
        irsdk_PitSvTooFarBack,
        irsdk_PitSvBadAngle,
        irsdk_PitSvCantFixThat
    }
}
