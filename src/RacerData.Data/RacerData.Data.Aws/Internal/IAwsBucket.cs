using System.Threading.Tasks;
using RacerData.Data.Aws.Models;

namespace RacerData.Data.Aws.Internal
{
    interface IAwsBucket
    {
        Task<AwsResponse> DeleteAsync(IAwsItem item);
        Task<AwsItemResponse> GetAsync(string key);
        Task<AwsListResponse> GetListAsync(int take, string startKey = "");
        Task<AwsItemResponse> PutAsync(IAwsItem item);
    }
}