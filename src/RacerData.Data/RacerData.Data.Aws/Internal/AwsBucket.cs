using System;
using System.IO;
using System.Threading.Tasks;
using Amazon;
using Amazon.S3;
using Amazon.S3.Model;
using RacerData.Data.Aws.Models;
using RacerData.Data.Aws.Ports;

namespace RacerData.Data.Aws.Internal
{
    class AwsBucket : IAwsBucket
    {
        #region fields

        protected static IAmazonS3 _client;

        #endregion

        #region properties

        protected string BucketPath { get; private set; }

        #endregion

        #region ctor

        public AwsBucket(IAwsBucketConfiguration configuration)
        {
            if (configuration == null)
                throw new ArgumentNullException(nameof(configuration));

            BucketPath = $"{configuration.Bucket}{configuration.Directory}";

            var bucketRegion = RegionEndpoint.GetBySystemName(configuration.RegionEndpoint);

            _client = new AmazonS3Client(bucketRegion);
        }

        #endregion

        #region public

        public async Task<AwsListResponse> GetListAsync(int take, string startKey = "")
        {
            AwsListResponse awsResponses = new AwsListResponse();
            AwsItemListResponse awsResponse = new AwsItemListResponse();

            try
            {
                ListObjectsV2Request request = new ListObjectsV2Request
                {
                    BucketName = BucketPath,
                    StartAfter = startKey,
                    MaxKeys = take
                };

                ListObjectsV2Response response = await _client.ListObjectsV2Async(request);

                awsResponse.RequestId = response.ResponseMetadata.RequestId;
                awsResponse.HttpStatusCode = response.HttpStatusCode;

                do
                {
                    response = await _client.ListObjectsV2Async(request);

                    awsResponse = new AwsItemListResponse()
                    {
                        RequestId = response.ResponseMetadata.RequestId,
                        HttpStatusCode = response.HttpStatusCode
                    };

                    awsResponses.Responses.Add(awsResponse);

                    foreach (S3Object entry in response.S3Objects)
                    {
                        awsResponse.Items.Add(new AwsListItem()
                        {
                            Key = entry.Key,
                            ETag = entry.ETag,
                            LastModified = entry.LastModified
                        });
                    }

                    Console.WriteLine("Next Continuation Token: {0}", response.NextContinuationToken);

                    request.ContinuationToken = response.NextContinuationToken;

                } while (response.IsTruncated);
            }
            catch (AmazonS3Exception amazonS3Exception)
            {
                awsResponses.Exception = amazonS3Exception;
            }
            catch (Exception e)
            {
                awsResponses.Exception = e;
            }

            return awsResponses;
        }

        public async Task<AwsItemResponse> GetAsync(string key)
        {
#if DEBUG
            System.Console.WriteLine($"*** AwsBucket.Get bucketPath:{BucketPath}, key:{key}");
#endif
            AwsItemResponse awsResponse = new AwsItemResponse();

            try
            {
                GetObjectRequest request = new GetObjectRequest
                {
                    BucketName = BucketPath,
                    Key = key
                };

                using (GetObjectResponse objResponse = await _client.GetObjectAsync(request))
                using (Stream responseStream = objResponse.ResponseStream)
                using (StreamReader reader = new StreamReader(responseStream))
                {
                    awsResponse.HttpStatusCode = objResponse.HttpStatusCode;
                    awsResponse.VersionId = objResponse.VersionId;
                    awsResponse.ETag = objResponse.ETag;
                    awsResponse.LastModified = objResponse.LastModified;

                    awsResponse.Item.ContentType = objResponse.Headers["ContentType"];

                    foreach (string metadataKey in objResponse.Metadata.Keys)
                    {
                        awsResponse.Item.Metadata.Add(metadataKey, objResponse.Metadata[metadataKey]);
                    }

                    awsResponse.Item.Content = reader.ReadToEnd();
                }
            }
            catch (AmazonS3Exception amazonS3Exception)
            {
                Console.WriteLine($"BucketPath: {BucketPath}\r\nkey {key}\r\nAmazonS3Exception:{amazonS3Exception.Message}");
                awsResponse.Exception = amazonS3Exception;
            }
            catch (Exception e)
            {
                Console.WriteLine($"BucketPath: {BucketPath}\r\nkey {key}\r\nException:{e.Message}");
                awsResponse.Exception = e;
            }

            return awsResponse;
        }

        public async Task<AwsItemResponse> PutAsync(IAwsItem item)
        {
            AwsItemResponse awsResponse = new AwsItemResponse() { Item = item };

            try
            {
                var request = new PutObjectRequest
                {
                    BucketName = BucketPath,
                    Key = item.Key,
                    ContentBody = item.Content,
                    ContentType = item.ContentType
                };

                foreach (string metadataKey in awsResponse.Item.Metadata.Keys)
                {
                    request.Metadata.Add(metadataKey, awsResponse.Item.Metadata[metadataKey]);
                }

                PutObjectResponse objResponse = await _client.PutObjectAsync(request);
                {
                    awsResponse.RequestId = objResponse.ResponseMetadata.RequestId;
                    awsResponse.HttpStatusCode = objResponse.HttpStatusCode;
                    awsResponse.VersionId = objResponse.VersionId;
                    awsResponse.ETag = objResponse.ETag;
                    awsResponse.LastModified = DateTime.Now;
                }
            }
            catch (AmazonS3Exception amazonS3Exception)
            {
                awsResponse.Exception = amazonS3Exception;
            }
            catch (Exception e)
            {
                awsResponse.Exception = e;
            }

            return awsResponse;
        }

        public async Task<AwsResponse> DeleteAsync(IAwsItem item)
        {
            AwsResponse awsResponse = new AwsResponse();

            try
            {
                var deleteObjectRequest = new DeleteObjectRequest
                {
                    BucketName = BucketPath,
                    Key = item.Key
                };

                await _client.DeleteObjectAsync(deleteObjectRequest);
            }
            catch (AmazonS3Exception amazonS3Exception)
            {
                awsResponse.Exception = amazonS3Exception;
            }
            catch (Exception e)
            {
                awsResponse.Exception = e;
            }

            return awsResponse;
        }

        #endregion
    }
}
