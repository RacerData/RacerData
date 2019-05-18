using System;
using System.Collections.Generic;
using System.Linq;

namespace RacerData.rNascarApp.Services
{
    class RevertableService : IRevertableService
    {
        #region fields

        private readonly IDictionary<Guid, string> _stateMap = new Dictionary<Guid, string>();
        private readonly ISerializer _serializer = null;

        #endregion

        #region ctor

        public RevertableService(ISerializer serializer)
        {
            _serializer = serializer ?? throw new ArgumentNullException(nameof(serializer));
        }

        #endregion

        #region public

        public Guid PersistState<T>(T item) where T : class, new()
        {
            var key = Guid.NewGuid();

            var json = _serializer.Serialize(item);

            _stateMap.Add(key, json);

            return key;
        }

        public T RevertState<T>(Guid key) where T : class, new()
        {
            T item = PeekState<T>(key);

            ClearState(key);

            return item;
        }

        public T PeekState<T>(Guid key) where T : class, new()
        {
            var json = _stateMap[key];

            T item = _serializer.Deserialize<T>(json);

            return item;
        }

        public void ClearAllStates()
        {
            foreach (var key in _stateMap.Keys.ToList())
            {
                ClearState(key);
            }
        }

        public void ClearState(Guid key)
        {
            _stateMap.Remove(key);
        }

        #region IDisposable Support
        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    ClearAllStates();
                }

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }
        #endregion

        #endregion
    }
}
