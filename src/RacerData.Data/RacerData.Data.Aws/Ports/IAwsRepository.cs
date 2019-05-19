using System.Collections.Generic;
using System.Threading.Tasks;
using RacerData.Common.Results;
using RacerData.Data.Aws.Models;

namespace RacerData.Data.Aws.Ports
{
    public interface IAwsRepository
    {
        Task<IResult<IAwsItem>> SelectAsync(string key);
        Task<IResult<IList<IAwsItem>>> SelectListAsync();
        Task<IResult<IList<IAwsItem>>> SelectListAsync(int take, string startKey = "");
        Task<IResult<IAwsItem>> PutAsync(IAwsItem item);
        Task<IResult> DeleteAsync(string key);
    }

    // TODO: Create RacerData.Data package
    public interface IRepository<TItem, TKey>
    {
        Task<IResult<TItem>> SelectAsync(TKey key);
        Task<IResult<IList<TItem>>> SelectListAsync();
        Task<IResult<IList<TItem>>> SelectListAsync(int take, TKey startKey);
        Task<IResult<IEnumerable<TItem>>> SelectListAsync(int take, int skip);
        Task<IResult<TItem>> PutAsync(TItem item);
        Task<IResult> DeleteAsync(TKey key);
    }
}
