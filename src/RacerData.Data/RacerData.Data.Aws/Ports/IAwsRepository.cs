using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RacerData.Common.Results;
using RacerData.Data.Aws.Models;
using RacerData.Data.Ports;

namespace RacerData.Data.Aws.Ports
{
    public interface IAwsRepository : IRepository<AwsItem, String>
    {
        new Task<IResult<AwsItem>> SelectAsync(string key);
        new Task<IResult<IList<AwsItem>>> SelectListAsync();
        new Task<IResult<IList<AwsItem>>> SelectListAsync(int take, string startKey = "");
        new Task<IResult<AwsItem>> PutAsync(AwsItem item);
        new Task<IResult> DeleteAsync(string key);
    }
}
