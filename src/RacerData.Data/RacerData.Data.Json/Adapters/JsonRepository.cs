using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using log4net;
using RacerData.Commmon.Results;
using RacerData.Common.Models;
using RacerData.Common.Ports;
using RacerData.Common.Results;
using RacerData.Data.Json.Ports;
using RacerData.Data.Ports;

namespace RacerData.Data.Json.Adapters
{
    public abstract class JsonRepository<TItem, TKey> : INotifyPropertyChanged, IJsonRepository<TItem, TKey>
        where TItem : class, IKeyedItem<TKey>, new()
        where TKey : struct, IComparable
    {
        #region events

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            handler?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        #region fields

        private readonly IDirectoryService _directoryService = null;
        private readonly ISerializer _serializer = null;
        private readonly IRevertableService _revertableService = null;
        protected readonly IResultFactory<JsonRepository<TItem, TKey>> _resultFactory;
        private Guid? _savedStateKey = null;

        #endregion

        #region properties

        // public

        private List<TItem> _items = null;
        protected List<TItem> Items
        {
            get
            {
                if (_items == null)
                    _items = LoadFromFile();

                return _items;
            }
            set
            {
                _items = value;
                OnPropertyChanged(nameof(Items));
            }
        }

        public bool HasChanges
        {
            get
            {
                return StateHasChanges();
            }
        }

        // protected

        protected ILog Log { get; set; }
        protected virtual string JsonFileName { get; set; }
        protected virtual DirectoryType Directory { get; set; } = DirectoryType.Settings;
        protected string FilePath
        {
            get
            {
                return _directoryService.GetFullPath(Directory, JsonFileName, true);
            }
        }

        #endregion

        #region ctor

        public JsonRepository(
           ILog log,
           IDirectoryService directoryService,
           ISerializer serializer,
           IRevertableService revertableService,
           IResultFactory<JsonRepository<TItem, TKey>> resultFactory)
        {
            Log = log ?? throw new ArgumentNullException(nameof(log));
            _directoryService = directoryService ?? throw new ArgumentNullException(nameof(directoryService));
            _serializer = serializer ?? throw new ArgumentNullException(nameof(serializer));
            _revertableService = revertableService ?? throw new ArgumentNullException(nameof(revertableService));
            _resultFactory = resultFactory ?? throw new ArgumentNullException(nameof(resultFactory));
        }

        #endregion

        #region public

        public virtual async Task<IResult<TItem>> SelectAsync(TKey key)
        {
            try
            {
                TItem item = GetItemFromList(key);

                if (item == null)
                {
                    return await Task.FromResult(_resultFactory.NotFound<TItem>());
                }

                return await Task.FromResult(_resultFactory.Success<TItem>(item));
            }
            catch (Exception ex)
            {
                return await Task.FromResult(_resultFactory.Exception<TItem>(ex));
            }
        }

        public virtual async Task<IResult<IList<TItem>>> SelectListAsync()
        {
            try
            {
                IList<TItem> items = Items.ToList();

                return await Task.FromResult(_resultFactory.Success(items));
            }
            catch (Exception ex)
            {
                return await Task.FromResult(_resultFactory.Exception<IList<TItem>>(ex));
            }
        }

        public virtual async Task<IResult<IList<TItem>>> SelectListAsync(int take, TKey startKey)
        {
            return await Task.FromResult(_resultFactory.Create<IList<TItem>>(HttpStatusCode.NotImplemented));
        }

        public virtual async Task<IResult<IEnumerable<TItem>>> SelectListAsync(int take, int skip)
        {
            try
            {
                var items = Items.Skip(skip).Take(take);

                return await Task.FromResult(_resultFactory.Success(items));
            }
            catch (Exception ex)
            {
                return await Task.FromResult(_resultFactory.Exception<IList<TItem>>(ex));
            }
        }

        public virtual async Task<IResult<TItem>> PutAsync(TItem item)
        {
            try
            {
                TItem existing = GetItemFromList(item.Key);

                if (existing != null)
                {
                    Items.Remove(existing);
                }

                Items.Add(item);

                return await Task.FromResult(_resultFactory.Success(item));
            }
            catch (Exception ex)
            {
                return await Task.FromResult(_resultFactory.Exception<TItem>(ex));
            }
        }

        public virtual async Task<IResult> DeleteAsync(TKey key)
        {
            try
            {
                TItem item = Items.FirstOrDefault(i => i.Key.ToString() == key.ToString());

                if (item == null)
                {
                    return await Task.FromResult(_resultFactory.NotFound<TItem>());
                }

                Items.Remove(item);

                return await Task.FromResult(_resultFactory.Success());
            }
            catch (Exception ex)
            {
                return await Task.FromResult(_resultFactory.Exception<IList<TItem>>(ex));
            }
        }

        public virtual void SaveChanges()
        {
            try
            {
                SaveToFile();
            }
            catch (Exception ex)
            {
                ExceptionHandler("Error saving data", ex);
                throw;
            }
        }

        public virtual void RevertChanges()
        {
            try
            {
                RevertStateChanges();
            }
            catch (Exception ex)
            {
                ExceptionHandler("Error reverting data", ex);
                throw;
            }
        }

        #endregion

        #region protected

        protected virtual void ExceptionHandler(string message, Exception ex)
        {
            Log?.Error(message, ex);
        }

        protected virtual TItem GetItemFromList(TKey key)
        {
            return Items.FirstOrDefault(i => i.Key.ToString() == key.ToString());
        }

        protected virtual List<TItem> LoadFromFile()
        {
            List<TItem> items = null;

            try
            {
                items = _serializer.DeserializeFromFile<List<TItem>>(FilePath);

                if (items == null)
                {
                    items = new List<TItem>();

                    return SaveToFile(items);
                }

                UpdateSavedState(items);

                return items;
            }
            catch (FileNotFoundException ex)
            {
                Log?.Error($"File '{JsonFileName}' not found", ex);

                items = new List<TItem>();

                return SaveToFile(items);
            }
            catch (Exception ex)
            {
                Log?.Error($"Error loading {JsonFileName}", ex);
            }

            return items;
        }

        protected virtual void SaveToFile()
        {
            SaveToFile(Items);
        }

        protected virtual List<TItem> SaveToFile(List<TItem> items)
        {
            if (items == null)
                throw new ArgumentNullException(nameof(items));

            _serializer.SerializeToFile(items, FilePath);

            UpdateSavedState(items);

            return items;
        }

        protected virtual void UpdateSavedState(List<TItem> items)
        {
            ClearSavedState();

            _savedStateKey = _revertableService.PersistState(items);
        }

        protected virtual void ClearSavedState()
        {
            if (_savedStateKey.HasValue)
            {
                _revertableService.ClearState(_savedStateKey.Value);
            }
        }

        protected virtual bool RevertStateChanges()
        {
            if (!_savedStateKey.HasValue)
                return false;

            Items = _revertableService.PeekState<List<TItem>>(_savedStateKey.Value);

            return true;
        }

        protected virtual bool StateHasChanges()
        {
            if (!_savedStateKey.HasValue)
                return false;

            var savedState = _revertableService.PeekStateData<List<TItem>>(_savedStateKey.Value);

            Guid currentStateKey = _revertableService.PersistState(Items);

            var currentState = _revertableService.PeekStateData<List<TItem>>(currentStateKey);

            return !currentState.Equals(savedState);
        }

        #endregion
    }
}
