using System;
using System.Collections.Generic;
using System.Net;
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

        public virtual async Task<IResult<AwsItem>> SelectAsync(string key)
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
                return _resultFactory.Exception<AwsItem>(ex);
            }
        }
        
        public virtual async Task<IResult<IList<AwsItem>>> SelectListAsync()
        {
            return await SelectListAsync(DefaultTake);
        }
        public virtual async Task<IResult<IEnumerable<AwsItem>>> SelectListAsync(int take, int skip)
        {
            return await Task.FromResult(_resultFactory.Create<IList<AwsItem>>(HttpStatusCode.NotImplemented));
        }

        public virtual async Task<IResult<IList<AwsItem>>> SelectListAsync(int take, string startKey = "")
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
                return _resultFactory.Exception<IList<AwsItem>>(ex);
            }
        }

        public virtual async Task<IResult<AwsItem>> PutAsync(AwsItem item)
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
                return _resultFactory.Exception<AwsItem>(ex);
            }
        }
       
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

        //Task<IResult<AwsItem>> IRepository<AwsItem, string>.SelectAsync(string key)
        //{
        //    throw new NotImplementedException();
        //}

        //Task<IResult<IList<AwsItem>>> IRepository<AwsItem, string>.SelectListAsync()
        //{
        //    throw new NotImplementedException();
        //}

        //Task<IResult<IList<AwsItem>>> IRepository<AwsItem, string>.SelectListAsync(int take, string startKey)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<IResult<IEnumerable<AwsItem>>> SelectListAsync(int take, int skip)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<IResult<AwsItem>> PutAsync(AwsItem item)
        //{
        //    throw new NotImplementedException();
        //}

        #endregion
    }
}
