using System;
using RacerData.rNascarApp.Models;
using RacerData.rNascarApp.Settings;

namespace RacerData.rNascarApp.Services
{
    public interface IStateService
    {
        event EventHandler<StateChangedEventArgs> StateChanged;

        State State { get; set; }
        bool HasChanges { get; }

        void Save();
        void ProcessChangeSet(ChangeSet<ViewState> changes);
    }
}