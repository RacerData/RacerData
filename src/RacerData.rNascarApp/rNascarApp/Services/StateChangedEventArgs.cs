using System;
using RacerData.rNascarApp.Settings;


namespace RacerData.rNascarApp.Services
{
    public class StateChangedEventArgs : EventArgs
    {
        public State State { get; set; }
    }
}
