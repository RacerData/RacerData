using System;

namespace RacerData.Data.Ports
{
    public interface IKeyedItem<TKey>
        where TKey : IComparable
    {
        TKey Key { get; set; }
    }
}
