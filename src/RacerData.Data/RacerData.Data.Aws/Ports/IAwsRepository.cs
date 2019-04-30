using System.Collections.Generic;
using System.Threading.Tasks;
using RacerData.Data.Aws.Models;

namespace RacerData.Data.Aws.Ports
{
    public interface IAwsRepository
    {
        Task<IAwsItem> SelectAsync(string key);
        Task<IEnumerable<IAwsListItem>> SelectListAsync(int take, string startKey = "");
        Task<IAwsItem> PutAsync(IAwsItem item);
        Task DeleteAsync(IAwsItem item);
    }
}
