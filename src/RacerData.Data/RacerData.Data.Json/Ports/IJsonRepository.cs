using System.Collections.Generic;
using RacerData.Data.Ports;

namespace RacerData.Data.Json.Ports
{
    interface IJsonRepository<TItem, TKey> :
        IRepository<TItem, TKey> where TItem :
            class, IKeyedItem<TKey>, new()
    {
        bool HasChanges { get; }
    }
}