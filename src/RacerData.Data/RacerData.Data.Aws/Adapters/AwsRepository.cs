using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RacerData.Data.Aws.Internal;
using RacerData.Data.Aws.Models;
using RacerData.Data.Aws.Ports;

namespace RacerData.Data.Aws.Adapters
{
    class AwsRepository : IAwsRepository
    {
        private readonly IAwsBucket _bucket;

        public AwsRepository(IAwsBucket bucket)
        {
            _bucket = bucket ?? throw new ArgumentNullException(nameof(bucket));
        }

        public virtual async Task DeleteAsync(IAwsItem item)
        {
            var response = await _bucket.DeleteAsync(item);

            if (!response.IsSuccess)
            {
                throw response.Exception;
            }
        }

        public virtual async Task<IAwsItem> PutAsync(IAwsItem item)
        {
            var response = await _bucket.PutAsync(item);

            if (response.IsSuccess)
                return response.Item;
            else
            {
                throw response.Exception;
            }
        }

        public virtual async Task<IAwsItem> SelectAsync(string key)
        {
            var response = await _bucket.GetAsync(key);

            if (response.IsSuccess)
                return response.Item;
            else
            {
                throw response.Exception;
            }
        }

        public virtual async Task<IEnumerable<IAwsListItem>> SelectListAsync(int take, string startKey = "")
        {
            var response = await _bucket.GetListAsync(take, startKey);

            if (response.IsSuccess)
                return response.Responses.SelectMany(r => r.Items);
            else
            {
                throw response.Exception;
            }
        }
    }
}
