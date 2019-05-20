using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using log4net;
using RacerData.Common.Models;
using RacerData.Common.Ports;
using RacerData.rNascarApp.Models;

namespace RacerData.rNascarApp.Services
{
    public class WorkspaceService : IWorkspaceService
    {
        #region consts

        private const string JsonFileName = "workspaces.json";
        private const DirectoryType Directory = DirectoryType.Settings;

        #endregion

        #region events
        /// <summary>
        /// Current workspace before change
        /// </summary>
        public event EventHandler<WorkspaceChangedEventArgs> CurrentWorkspaceChanging;
        protected virtual void OnCurrentWorkspaceChanging(Workspace workspace)
        {
            var handler = CurrentWorkspaceChanging;
            handler?.Invoke(this, new WorkspaceChangedEventArgs() { CurrentWorkspace = workspace });
        }

        /// <summary>
        /// Current workspace changed
        /// </summary>
        public event EventHandler<WorkspaceChangedEventArgs> CurrentWorkspaceChanged;
        protected virtual void OnCurrentWorkspaceChanged(Workspace workspace)
        {
            var handler = CurrentWorkspaceChanged;
            handler?.Invoke(this, new WorkspaceChangedEventArgs() { CurrentWorkspace = workspace });
        }

        /// <summary>
        /// Workspaces list is changed
        /// </summary>
        public event EventHandler<WorkspacesChangedEventArgs> WorkspacesChanged;
        protected virtual void OnWorkspacesChanged(IList<Workspace> workspaces)
        {
            var handler = WorkspacesChanged;
            handler?.Invoke(this, new WorkspacesChangedEventArgs() { Workspaces = workspaces });
        }

        /// <summary>
        /// Item in the Workspaces binding list changed
        /// </summary>
        public event EventHandler<ListChangedEventArgs> WorkspacesListItemChanged;
        private void OnWorkspacesListItemChanged(object sender, ListChangedEventArgs e)
        {
            var handler = WorkspacesListItemChanged;
            handler?.Invoke(this, e);
        }

        #endregion

        #region fields

        private readonly ILog _log = null;
        private readonly IDirectoryService _directoryService = null;
        private readonly ISerializer _serializer = null;
        private readonly IRevertableService _revertableService = null;
        private Guid? _savedStateKey = null;

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

        private BindingList<Workspace> _workspaces;
        public BindingList<Workspace> Workspaces
        {
            get
            {
                if (_workspaces == null)
                {
                    var workspaceList = LoadFromFile();
                    _workspaces = new BindingList<Workspace>(workspaceList);
                    _workspaces.ListChanged += OnWorkspacesListItemChanged;
                    UpdateSavedState(_workspaces.ToList());
                }

                return _workspaces;
            }
            protected set
            {
                if (_workspaces != null)
                {
                    _workspaces.ListChanged -= OnWorkspacesListItemChanged;
                }
                _workspaces = new BindingList<Workspace>(value);
                _workspaces.ListChanged += OnWorkspacesListItemChanged;

                OnWorkspacesChanged(_workspaces.ToList());
            }
        }

        public bool HasChanges
        {
            get
            {
                return StateHasChanges();
            }
        }

        protected string FilePath
        {
            get
            {
                return _directoryService.GetFullPath(Directory, JsonFileName);
            }
        }

        #endregion

        #region ctor

        public WorkspaceService(
            ILog log,
            IDirectoryService directoryService,
            ISerializer serializer,
            IRevertableService revertableService)
        {
            _log = log ?? throw new ArgumentNullException(nameof(log));
            _directoryService = directoryService ?? throw new ArgumentNullException(nameof(directoryService));
            _serializer = serializer ?? throw new ArgumentNullException(nameof(serializer));
            _revertableService = revertableService ?? throw new ArgumentNullException(nameof(revertableService));
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
            RemoveWorkspace(workspace, false);
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
                    RemoveWorkspace(existing, true);

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
                var currentActive = CurrentWorkspace;

                OnCurrentWorkspaceChanging(currentActive);

                currentActive.IsActive = false;

                workspace.IsActive = true;

                Save();

                OnCurrentWorkspaceChanged(workspace);
            }
        }

        public void Save()
        {
            SaveToFile();
        }

        #endregion

        #region protected

        protected List<Workspace> GetDefaultWorkspaces()
        {
            return new List<Workspace>() { GetDefaultWorkspace() };
        }

        protected Workspace GetDefaultWorkspace()
        {
            return new Workspace() { Name = Workspace.DefaultWorkspaceName };
        }

        protected virtual void RemoveWorkspace(Workspace workspace, bool overrideActiveCheck)
        {
            var existing = Workspaces.SingleOrDefault(w => w.Name == workspace.Name);

            if (existing == null)
                throw new InvalidOperationException($"Workspace not found with name {workspace.Name}");

            if (!overrideActiveCheck && existing.IsActive == true)
                throw new InvalidOperationException($"Cannot remove active workspace");

            Workspaces.Remove(existing);
        }

        protected virtual List<Workspace> LoadFromFile()
        {
            List<Workspace> workspaces = null;

            try
            {
                workspaces = _serializer.DeserializeFromFile<List<Workspace>>(FilePath);

                if (workspaces == null)
                {
                    workspaces = GetDefaultWorkspaces();

                    return SaveToFile(workspaces);
                }

                UpdateSavedState(workspaces);

                return workspaces;
            }
            catch (FileNotFoundException ex)
            {
                _log?.Error($"File '{JsonFileName}' not found", ex);

                workspaces = new List<Workspace>();

                return SaveToFile(workspaces);
            }
            catch (Exception ex)
            {
                _log?.Error($"Error loading {JsonFileName}", ex);
            }

            return workspaces;
        }

        protected virtual void SaveToFile()
        {
            SaveToFile((List<Workspace>)Workspaces.ToList());
        }

        protected virtual List<Workspace> SaveToFile(List<Workspace> workspaces)
        {
            if (workspaces == null)
                throw new ArgumentNullException(nameof(workspaces));

            _serializer.SerializeToFile(workspaces, FilePath);

            UpdateSavedState(workspaces);

            return workspaces;
        }

        protected virtual void UpdateSavedState(List<Workspace> workspaces)
        {
            ClearSavedState();

            _savedStateKey = _revertableService.PersistState(workspaces);
        }

        protected virtual void ClearSavedState()
        {
            if (_savedStateKey.HasValue)
            {
                _revertableService.ClearState(_savedStateKey.Value);
            }
        }

        protected virtual bool StateHasChanges()
        {
            if (!_savedStateKey.HasValue)
                return false;

            var savedState = _revertableService.PeekStateData<List<Workspace>>(_savedStateKey.Value);

            Guid currentStateKey = _revertableService.PersistState(Workspaces.ToList());
            var currentState = _revertableService.PeekStateData<List<Workspace>>(currentStateKey);

            return !savedState.Equals(currentState);
        }

        #endregion
    }
}
