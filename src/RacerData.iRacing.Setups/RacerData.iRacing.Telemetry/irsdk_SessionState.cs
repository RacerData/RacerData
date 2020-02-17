namespace RacerData.iRacing.Telemetry
{
    public enum irsdk_SessionState : System.Int16
    {
        irsdk_StateInvalid,
        irsdk_StateGetInCar,
        irsdk_StateWarmup,
        irsdk_StateParadeLaps,
        irsdk_StateRacing,
        irsdk_StateCheckered,
        irsdk_StateCoolDown
    }
}
