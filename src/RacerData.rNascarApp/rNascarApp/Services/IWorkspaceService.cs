using System;
using System.Collections.Generic;
using RacerData.rNascarApp.Models;
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
        void ProcessChangeSet(ChangeSet<ViewState> changes);
        void ProcessChangeSet(ChangeSet<Workspace> changes);
        void SetActiveWorkspace(string name);
        void Save();
        void Load();
    }
}