using System;

namespace RacerData.Data.Ports
{
    public interface IKeyedItem<TKey>
        where TKey : struct, IComparable
    {
        TKey Key { get; set; }
    }
}
