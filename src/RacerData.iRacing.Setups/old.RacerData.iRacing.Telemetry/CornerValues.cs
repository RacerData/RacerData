using System.Collections.Generic;

namespace RacerData.iRacing.Telemetry
{
    public class CornerValues<T> : Dictionary<Positions, T>
    {
        public T LF
        {
            get
            {
                return this[Positions.LeftFront];
            }
            set
            {
                this[Positions.LeftFront] = value;
            }
        }
        public T LR
        {
            get
            {
                return this[Positions.LeftRear];
            }
            set
            {
                this[Positions.LeftRear] = value;
            }
        }
        public T RF
        {
            get
            {
                return this[Positions.RightFront];
            }
            set
            {
                this[Positions.RightFront] = value;
            }
        }
        public T RR
        {
            get
            {
                return this[Positions.RightRear];
            }
            set
            {
                this[Positions.RightRear] = value;
            }
        }
    }
}
