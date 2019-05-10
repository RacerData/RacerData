using System;
using System.Collections.Generic;
using RacerData.rNascarApp.Settings;

namespace RacerData.rNascarApp.Services
{
    public interface IWorkspaceService
    {
        event EventHandler<WorkspaceChangedEventArgs> WorkspaceChanged;

        Workspace CurrentWorkspace { get; }
        IList<Workspace> Workspaces { get; }

        void AddWorkspace(Workspace workspace);
        void RemoveWorkspace(Workspace workspace);
        void Save();
        void SetActiveWorkspace(string name);
    }
}