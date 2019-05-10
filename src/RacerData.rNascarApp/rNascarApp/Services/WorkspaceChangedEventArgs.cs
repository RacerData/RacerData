using System;
using RacerData.rNascarApp.Settings;

namespace RacerData.rNascarApp.Services
{
    public class WorkspaceChangedEventArgs : EventArgs
    {
        public Workspace CurrentWorkspace { get; set; }
    }
}
