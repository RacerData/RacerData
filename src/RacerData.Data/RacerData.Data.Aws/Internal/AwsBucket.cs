using System;
using System.IO;
using System.Threading.Tasks;
using Amazon;
using Amazon.S3;
using Amazon.S3.Model;
using log4net;
using RacerData.Data.Aws.Models;
using RacerData.Data.Aws.Ports;

namespace RacerData.Data.Aws.Internal
{
    class AwsBucket : IAwsBucket
    {
        #region fields

        private readonly ILog _log = null;
        protected static IAmazonS3 _client;

        #endregion

        #region properties

        protected string BucketName { get; private set; }
        protected string BucketPrefix { get; private set; }

        #endregion

        #region ctor

        public AwsBucket(
            ILog log,
            IAwsBucketConfiguration configuration)
        {
            try
            {
                _log = log ?? throw new ArgumentNullException(nameof(log));

                if (configuration == null)
                    throw new ArgumentNullException(nameof(configuration));

                BucketName = configuration.Bucket;

                if (!String.IsNullOrEmpty(configuration.Prefix) && configuration.Prefix.EndsWith("/"))
                {
                    BucketPrefix = configuration.Prefix.TrimEnd('/');
                }
                else
                {
                    BucketPrefix = configuration.Prefix;
                }

                var bucketRegion = RegionEndpoint.GetBySystemName(configuration.RegionEndpoint);

                _client = new AmazonS3Client(bucketRegion);
            }
            catch (Exception ex)
            {
                _log?.Error("Error in AWSBucket ctor", ex);
                throw;
            }
        }

        #endregion

        #region public

        public async Task<AwsListResponse> GetListAsync(int take, string startKey = "")
        {
            return await GetListAsync(take, startKey, BucketPrefix);
        }

        public async Task<AwsListResponse> GetListAsync(int take, string startKey = "", string prefix = "")
        {
            AwsListResponse awsResponse = new AwsListResponse();

            try
            {
                ListObjectsV2Request request = new ListObjectsV2Request
                {
                    BucketName = BucketName,
                    StartAfter = startKey,
                    MaxKeys = take,
                    Delimiter = "/",
                    Prefix = prefix
                };

                ListObjectsV2Response response = null;

                do
                {
                    response = await _client.ListObjectsV2Async(request);

                    awsResponse.HttpStatusCode = response.HttpStatusCode;
                    awsResponse.RequestId = response.ResponseMetadata.RequestId;

                    foreach (S3Object entry in response.S3Objects)
                    {
                        var item = new AwsItem()
                        {
                            Key = entry.Key,
                            ETag = entry.ETag,
                            LastModified = entry.LastModified
                        };

                        awsResponse.Items.Add(item);
                    }

                    foreach (string commonPrefix in response.CommonPrefixes)
                    {
                        var innerResponse = await GetListAsync(100, "", commonPrefix);

                        foreach (var innerItem in innerResponse.Items)
                        {
                            awsResponse.Items.Add(innerItem);
                        }
                    }

                    request.ContinuationToken = response.NextContinuationToken;

                } while (response.IsTruncated);
            }
            catch (AmazonS3Exception amazonS3Exception)
            {
                if (amazonS3Exception.ErrorCode == "NoSuchKey")
                {
                    awsResponse.HttpStatusCode = System.Net.HttpStatusCode.NotFound;
                }

                _log?.Error("*** AmazonS3Exception in AWSBucket GetListAsync", amazonS3Exception);

                awsResponse.Exception = amazonS3Exception;
            }
            catch (Exception e)
            {
                _log?.Error("Exception in AWSBucket GetListAsync", e);

                awsResponse.Exception = e;
            }

            return awsResponse;
        }

        public async Task<AwsItemResponse> GetAsync(string key)
        {
            return await GetAsync("", key);
        }
        public async Task<AwsItemResponse> GetAsync(string prefix, string key)
        {
            AwsItemResponse awsResponse = new AwsItemResponse();

            try
            {
                GetObjectRequest request = new GetObjectRequest
                {
                    BucketName = BucketName,
                    Key = $"{prefix}{key}"
                };

                using (GetObjectResponse objResponse = await _client.GetObjectAsync(request))
                {
                    using (Stream responseStream = objResponse.ResponseStream)
                    {
                        using (StreamReader reader = new StreamReader(responseStream, true))
                        {
                            awsResponse.Item.Content = reader.ReadToEnd();
                        }
                    }

                    awsResponse.HttpStatusCode = objResponse.HttpStatusCode;
                    awsResponse.VersionId = objResponse.VersionId;
                    awsResponse.ETag = objResponse.ETag;
                    awsResponse.LastModified = objResponse.LastModified;

                    foreach (string metadataKey in objResponse.Metadata.Keys)
                    {
                        awsResponse.Item.Metadata.Add(metadataKey, objResponse.Metadata[metadataKey]);
                    }

                    awsResponse.Item.Key = objResponse.Key;
                    awsResponse.Item.ETag = objResponse.ETag;
                    awsResponse.Item.LastModified = objResponse.LastModified;
                    awsResponse.Item.ContentType = objResponse.Headers["Content-Type"];
                    int contentLength = -1;
                    if (int.TryParse(objResponse.Headers["Content-Length"], out contentLength))
                        awsResponse.Item.ContentLength = contentLength;
                }

            }
            catch (AmazonS3Exception amazonS3Exception)
            {
                if (amazonS3Exception.ErrorCode == "NoSuchKey")
                {
                    awsResponse.HttpStatusCode = System.Net.HttpStatusCode.NotFound;
                }

                awsResponse.Exception = amazonS3Exception;

                _log?.Error("AmazonS3Exception in AWSBucket GetAsync", amazonS3Exception);
            }
            catch (Exception e)
            {
                _log?.Error("Exception in AWSBucket GetAsync", e);

                awsResponse.Exception = e;
            }

            return awsResponse;
        }
        
        public async Task<AwsItemResponse> PutAsync(AwsItem item)
        {
            AwsItemResponse awsResponse = new AwsItemResponse() { Item = item };

            try
            {
                var request = new PutObjectRequest
                {
                    BucketName = BucketName,
                    Key = $"{item.Key}",
                    ContentBody = item.Content,
                    ContentType = item.ContentType
                };

                foreach (string metadataKey in awsResponse.Item.Metadata.Keys)
                {
                    request.Metadata.Add(metadataKey, awsResponse.Item.Metadata[metadataKey]);
                }

                PutObjectResponse objResponse = await _client.PutObjectAsync(request);

                awsResponse.HttpStatusCode = objResponse.HttpStatusCode;
                awsResponse.VersionId = objResponse.VersionId;
                awsResponse.ETag = objResponse.ETag;
                awsResponse.LastModified = DateTime.Now;

                awsResponse.RequestId = objResponse.ResponseMetadata.RequestId;
                foreach (string metadataKey in objResponse.ResponseMetadata.Metadata.Keys)
                {
                    awsResponse.Item.Metadata.Add(metadataKey, objResponse.ResponseMetadata.Metadata[metadataKey]);
                }
            }
            catch (AmazonS3Exception amazonS3Exception)
            {
                _log?.Error("AmazonS3Exception in AWSBucket PutAsync", amazonS3Exception);

                awsResponse.Exception = amazonS3Exception;
            }
            catch (Exception e)
            {
                _log?.Error("Exception in AWSBucket PutAsync", e);

                awsResponse.Exception = e;
            }

            return awsResponse;
        }

        public async Task<AwsResponse> DeleteAsync(string key)
        {
            AwsResponse awsResponse = new AwsResponse();

            try
            {
                var deleteObjectRequest = new DeleteObjectRequest
                {
                    BucketName = BucketName,
                    Key = $"{key}"
                };

                DeleteObjectResponse deleteObjectResponse = await _client.DeleteObjectAsync(deleteObjectRequest);

                awsResponse.HttpStatusCode = deleteObjectResponse.HttpStatusCode;

                awsResponse.RequestId = deleteObjectResponse.ResponseMetadata.RequestId;
                foreach (string metadataKey in deleteObjectResponse.ResponseMetadata.Metadata.Keys)
                {
                    awsResponse.Metadata.Add(metadataKey, deleteObjectResponse.ResponseMetadata.Metadata[metadataKey]);
                }
            }
            catch (AmazonS3Exception amazonS3Exception)
            {
                if (amazonS3Exception.ErrorCode == "NoSuchKey")
                {
                    awsResponse.HttpStatusCode = System.Net.HttpStatusCode.NotFound;
                }

                _log?.Error("AmazonS3Exception in AWSBucket DeleteAsync", amazonS3Exception);

                awsResponse.Exception = amazonS3Exception;
            }
            catch (Exception e)
            {
                _log?.Error("Exception in AWSBucket DeleteAsync", e);

                awsResponse.Exception = e;
            }

            return awsResponse;
        }

        #endregion
    }
}
