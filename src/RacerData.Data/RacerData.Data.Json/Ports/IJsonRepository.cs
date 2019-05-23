using RacerData.Data.Ports;

namespace RacerData.Data.Json.Ports
{
    public interface IJsonRepository<TItem, TKey> :
        IRepository<TItem, TKey> where TItem :
            class, IKeyedItem<TKey>, new()
    {
        bool HasChanges { get; }

        void SaveChanges();
        void RevertChanges();
    }
}