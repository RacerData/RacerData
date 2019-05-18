using System;
using RacerData.rNascarApp.Models;

namespace RacerData.rNascarApp.Services
{
    public class WorkspaceChangedEventArgs : EventArgs
    {
        public Workspace CurrentWorkspace { get; set; }
    }
}
