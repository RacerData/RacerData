using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RacerData.Commmon.Results;
using RacerData.Common.Results;
using RacerData.Data.Aws.Internal;
using RacerData.Data.Aws.Models;
using RacerData.Data.Aws.Ports;

namespace RacerData.Data.Aws.Adapters
{
    class AwsRepository : IAwsRepository
    {
        #region consts

        private const int DefaultTake = 100;

        #endregion

        #region fields

        private readonly IAwsBucket _bucket;
        private readonly IResultFactory<IAwsRepository> _resultFactory;

        #endregion

        #region ctor

        public AwsRepository(
            IAwsBucket bucket,
            IResultFactory<IAwsRepository> resultFactory)
        {
            _bucket = bucket ?? throw new ArgumentNullException(nameof(bucket));
            _resultFactory = resultFactory ?? throw new ArgumentNullException(nameof(resultFactory));
        }

        #endregion

        #region public

        public virtual async Task<IResult<IAwsItem>> SelectAsync(string key)
        {
            try
            {
                var response = await _bucket.GetAsync(key);

                if (response.IsSuccess)
                    return _resultFactory.Success(response.Item);
                else
                {
                    throw response.Exception;
                }
            }
            catch (Exception ex)
            {
                return _resultFactory.Exception<IAwsItem>(ex);
            }
        }

        public virtual async Task<IResult<IList<IAwsItem>>> SelectListAsync()
        {
            return await SelectListAsync(DefaultTake);
        }

        public virtual async Task<IResult<IList<IAwsItem>>> SelectListAsync(int take, string startKey = "")
        {
            try
            {
                var response = await _bucket.GetListAsync(take, startKey);

                if (response.IsSuccess)
                    return _resultFactory.Success(response.Items);
                else
                {
                    throw response.Exception;
                }
            }
            catch (Exception ex)
            {
                return _resultFactory.Exception<IList<IAwsItem>>(ex);
            }
        }

        public virtual async Task<IResult<IAwsItem>> PutAsync(IAwsItem item)
        {
            try
            {
                var response = await _bucket.PutAsync(item);

                if (response.IsSuccess)
                    return _resultFactory.Success(response.Item);
                else
                {
                    throw response.Exception;
                }
            }
            catch (Exception ex)
            {
                return _resultFactory.Exception<IAwsItem>(ex);
            }
        }
        // TODO: Return IResult
        public virtual async Task<IResult> DeleteAsync(string key)
        {
            try
            {
                var response = await _bucket.DeleteAsync(key);

                if (!response.IsSuccess)
                {
                    throw response.Exception;
                }

                return _resultFactory.Success();
            }
            catch (Exception ex)
            {
                return _resultFactory.Exception(ex);
            }

        }

        #endregion
    }
}
