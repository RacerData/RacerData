using System;

namespace RacerData.rNascarApp.Services
{
    public interface IRevertableService : IDisposable
    {
        Guid PersistState<T>(T item) where T : class, new();
        T RevertState<T>(Guid key) where T : class, new();
        T PeekState<T>(Guid key) where T : class, new();
        void ClearAllStates();
        void ClearState(Guid key);
    }
}
