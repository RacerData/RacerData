using System;
using System.Collections.Generic;
using RacerData.rNascarApp.Models;

namespace RacerData.rNascarApp.Services
{
    public class WorkspacesChangedEventArgs : EventArgs
    {
        public IList<Workspace> Workspaces { get; set; }
    }
}
