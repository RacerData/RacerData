using System;
using System.IO;
using System.Linq;
using log4net;
using RacerData.Common.Models;
using RacerData.Common.Ports;
using RacerData.rNascarApp.Models;
using RacerData.rNascarApp.Settings;

namespace RacerData.rNascarApp.Services
{
    public class StateService : IStateService
    {
        #region consts

        private const string JsonFileName = "settings.json";
        private const DirectoryType Directory = DirectoryType.Settings;

        #endregion

        #region events

        public event EventHandler<StateChangedEventArgs> StateChanged;
        protected virtual void OnStateChanged(State state)
        {
            var handler = StateChanged;
            handler?.Invoke(this, new StateChangedEventArgs() { State = state });
        }

        #endregion

        #region fields

        private readonly IDirectoryService _directoryService = null;
        private readonly ISerializer _serializer = null;
        private readonly ILog _log = null;
        private readonly IRevertableService _revertableService = null;
        private Guid? _savedStateKey = null;

        #endregion

        #region properties

        private State _state = null;
        public State State
        {
            get
            {
                if (_state == null)
                    _state = LoadFromFile();

                return _state;
            }
            set
            {
                _state = value;
                OnStateChanged(_state);
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
                return _directoryService.GetFullPath(Directory, JsonFileName, true);
            }
        }

        #endregion

        #region ctor

        public StateService(
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

        public void Save()
        {
            SaveToFile();
        }

        public void ProcessChangeSet(ChangeSet<ViewState> changes)
        {
            foreach (ViewState deleted in changes.Deleted)
            {
                var existing = State.ViewStates.SingleOrDefault(v => v.Id == deleted.Id);

                if (existing != null)
                    State.ViewStates.Remove(existing);
            }

            foreach (ViewState added in changes.Added)
            {
                State.ViewStates.Add(added);
            }

            foreach (ViewState updated in changes.Edited)
            {
                var existing = State.ViewStates.SingleOrDefault(v => v.Id == updated.Id);

                if (existing != null)
                    State.ViewStates.Remove(existing);

                State.ViewStates.Add(updated);
            }
        }

        #endregion

        #region protected

        protected virtual State LoadFromFile()
        {
            State state = null;

            try
            {
                state = _serializer.DeserializeFromFile<State>(FilePath);

                if (state == null)
                {
                    state = new State();

                    return SaveToFile(state);
                }

                UpdateSavedState(state);

                return state;
            }
            catch (FileNotFoundException ex)
            {
                _log?.Error($"File '{JsonFileName}' not found", ex);

                state = new State();

                return SaveToFile(state);
            }
            catch (Exception ex)
            {
                _log?.Error($"Error loading {JsonFileName}", ex);
            }

            return state;
        }

        protected virtual void SaveToFile()
        {
            SaveToFile(State);
        }

        protected virtual State SaveToFile(State state)
        {
            if (state == null)
                throw new ArgumentNullException(nameof(state));

            _serializer.SerializeToFile(state, FilePath);

            UpdateSavedState(state);

            return state;
        }

        protected virtual void UpdateSavedState(State state)
        {
            ClearSavedState();

            _savedStateKey = _revertableService.PersistState(state);
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

            var savedState = _revertableService.PeekStateData<State>(_savedStateKey.Value);

            Guid currentStateKey = _revertableService.PersistState(State);
            var currentState = _revertableService.PeekStateData<State>(currentStateKey);

            return !currentState.Equals(savedState);
        }

        #endregion
    }
}
