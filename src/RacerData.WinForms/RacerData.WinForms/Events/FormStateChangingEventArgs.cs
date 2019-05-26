using System;
using RacerData.WinForms.Models;

namespace RacerData.WinForms.Events
{
    public class FormStateChangingEventArgs : EventArgs
    {
        public virtual FormStates CurrentState { get; protected set; }
        public virtual FormStates NewState { get; protected set; }
        public bool Cancel { get; set; }

        public FormStateChangingEventArgs(FormStates currentState, FormStates newState)
        {
            CurrentState = currentState;
            NewState = newState;
        }
    }
}