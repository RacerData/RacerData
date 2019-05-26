using System;
using RacerData.WinForms.Models;

namespace RacerData.WinForms.Events
{
    public class FormStateChangedEventArgs : EventArgs
    {
        public virtual FormStates State { get; protected set; }

        public FormStateChangedEventArgs(FormStates state)
        {
            State = state;
        }
    }
}
