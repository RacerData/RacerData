using System.Threading.Tasks;
using RacerData.Data.Aws.Models;

namespace RacerData.Data.Aws.Internal
{
    interface IAwsBucket
    {
        Task<AwsItemResponse> GetAsync(string key);
        Task<AwsListResponse> GetListAsync(int take, string startKey = "");
        Task<AwsItemResponse> PutAsync(AwsItem item);
        Task<AwsResponse> DeleteAsync(string key);
    }
}