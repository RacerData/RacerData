using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Newtonsoft.Json;
using RacerData.rNascarApp.Models;
using RacerData.rNascarApp.Settings;

namespace RacerData.rNascarApp.Services
{
    public class WorkspaceService : IWorkspaceService
    {
        #region events

        public event EventHandler<WorkspaceChangedEventArgs> WorkspaceChanged;
        protected virtual void OnWorkspaceChanged(Workspace workspace)
        {
            var handler = WorkspaceChanged;
            handler?.Invoke(this, new WorkspaceChangedEventArgs() { CurrentWorkspace = workspace });
        }

        #endregion

        #region properties

        public Workspace CurrentWorkspace
        {
            get
            {
                var current = Workspaces.SingleOrDefault(w => w.IsActive == true);

                if (current == null)
                {
                    var defaultWorkspace = Workspaces.SingleOrDefault(w => w.Name == Workspace.DefaultWorkspaceName);

                    if (defaultWorkspace == null)
                    {
                        defaultWorkspace = GetDefaultWorkspace();
                        Workspaces.Add(defaultWorkspace);
                    }

                    return defaultWorkspace;
                }

                return current;
            }
        }

        private IList<Workspace> _workspaces;
        public IList<Workspace> Workspaces
        {
            get
            {
                if (_workspaces == null)
                {
                    _workspaces = GetDefaultWorkspaces();
                }

                return _workspaces;
            }
            protected set
            {
                _workspaces = value;
            }
        }

        protected static string SettingsFileName { get => "workspaces.json"; }

        protected static string SettingsDirectory
        {
            get
            {
                return $"{Path.GetDirectoryName(Application.ExecutablePath)}\\settings\\";
            }
        }

        #endregion

        #region ctor

        public WorkspaceService()
        {
            Load();
        }

        #endregion

        #region public

        public void AddWorkspace(Workspace workspace)
        {
            if (Workspaces.Any(w => w.Name == workspace.Name))
                throw new InvalidOperationException("Workspace name must be unique");

            Workspaces.Add(workspace);
        }

        public void RemoveWorkspace(Workspace workspace)
        {
            var existing = Workspaces.SingleOrDefault(w => w.Name == workspace.Name);

            if (existing == null)
                throw new InvalidOperationException($"Workspace not found with name {workspace.Name}");

            if (existing.IsActive == true)
                throw new InvalidOperationException($"Cannot remove active workspace");

            Workspaces.Remove(existing);
        }

        public void ProcessChangeSet(ChangeSet<Workspace> changes)
        {
            foreach (Workspace deleted in changes.Deleted)
            {
                RemoveWorkspace(deleted);
            }

            foreach (Workspace added in changes.Added)
            {
                AddWorkspace(added);
            }

            foreach (Workspace updated in changes.Edited)
            {
                var existing = Workspaces.SingleOrDefault(v => v.Name == updated.Name);

                if (existing != null)
                    RemoveWorkspace(existing);

                AddWorkspace(updated);
            }
        }

        public void ProcessChangeSet(ChangeSet<ViewState> changes)
        {
            foreach (ViewState deleted in changes.Deleted)
            {
                foreach (Workspace workspace in Workspaces.Where(w => w.ViewStates.Contains(deleted.Id)))
                {
                    workspace.ViewStates.Remove(deleted.Id);
                }
            }
        }

        public void SetActiveWorkspace(string name)
        {
            var workspace = Workspaces.SingleOrDefault(w => w.Name == name);

            if (workspace == null)
                throw new ArgumentException($"Workspace '{name}' not found", nameof(workspace));

            if (!workspace.IsActive)
            {
                foreach (Workspace activeWorkspaces in Workspaces.Where(w => w.IsActive == true).ToList())
                {
                    activeWorkspaces.IsActive = false;
                }

                workspace.IsActive = true;

                Save();

                OnWorkspaceChanged(workspace);
            }
        }

        public void Load()
        {
            var filePath = GetSettingsFilePath();
            Workspaces = LoadWorkspaces(filePath);
        }

        public void Save()
        {
            var filePath = GetSettingsFilePath();

            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All,
                NullValueHandling = NullValueHandling.Include
            };

            var json = JsonConvert.SerializeObject(
                    Workspaces,
                    Formatting.Indented,
                    settings);

            File.WriteAllText(filePath, json);
        }

        #endregion

        #region protected

        protected static IList<Workspace> LoadWorkspaces(string filePath)
        {
            var json = File.ReadAllText(filePath);

            var workspaces = JsonConvert.DeserializeObject<IList<Workspace>>(json);

            if (!workspaces.Any(w => w.Name == Workspace.DefaultWorkspaceName))
            {
                workspaces.Add(new Workspace() { Name = Workspace.DefaultWorkspaceName });
            }

            return workspaces;
        }

        protected static IList<Workspace> GetDefaultWorkspaces()
        {
            var defaultWorkspace = GetDefaultWorkspace();
            return new List<Workspace>() { defaultWorkspace };
        }

        protected static Workspace GetDefaultWorkspace()
        {
            return new Workspace() { Name = Workspace.DefaultWorkspaceName };
        }

        protected static string GetSettingsFilePath()
        {
            if (!Directory.Exists(SettingsDirectory))
                Directory.CreateDirectory(SettingsDirectory);

            return Path.Combine(SettingsDirectory, SettingsFileName);
        }

        #endregion
    }
}
