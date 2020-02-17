using System;

namespace RacerData.iRacing.Telemetry
{
    [Flags()]
    public enum Positions
    {
        Left = 0x001,
        Right = 0x002,
        Front = 0x004,
        Rear = 0x008,
        LeftFront = Left | Front,
        LeftRear = Left | Rear,
        RightFront = Right | Front,
        RightRear = Right | Rear,
    }
}
