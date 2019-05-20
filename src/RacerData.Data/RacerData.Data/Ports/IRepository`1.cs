using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RacerData.Common.Results;

namespace RacerData.Data.Ports
{
    public interface IRepository<TItem, TKey>
        where TItem : class, IKeyedItem<TKey>, new()
        where TKey : struct, IComparable
    {
        Task<IResult<TItem>> SelectAsync(TKey key);
        Task<IResult<IList<TItem>>> SelectListAsync();
        Task<IResult<IList<TItem>>> SelectListAsync(int take, TKey startKey);
        Task<IResult<IEnumerable<TItem>>> SelectListAsync(int take, int skip);
        Task<IResult<TItem>> PutAsync(TItem item);
        Task<IResult> DeleteAsync(TKey key);
    }
}
