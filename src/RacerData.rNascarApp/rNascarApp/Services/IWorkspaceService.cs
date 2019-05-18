using System;
using System.ComponentModel;
using RacerData.rNascarApp.Models;

namespace RacerData.rNascarApp.Services
{
    public interface IWorkspaceService
    {
        event EventHandler<WorkspaceChangedEventArgs> CurrentWorkspaceChanging;
        event EventHandler<WorkspaceChangedEventArgs> CurrentWorkspaceChanged;
        event EventHandler<WorkspacesChangedEventArgs> WorkspacesChanged;
        event EventHandler<ListChangedEventArgs> WorkspacesListItemChanged;

        Workspace CurrentWorkspace { get; }
        BindingList<Workspace> Workspaces { get; }
        bool HasChanges { get; }

        void SetActiveWorkspace(string name);
        void AddWorkspace(Workspace workspace);
        void RemoveWorkspace(Workspace workspace);
        void ProcessChangeSet(ChangeSet<ViewState> changes);
        void ProcessChangeSet(ChangeSet<Workspace> changes);
        void Save();
    }
}