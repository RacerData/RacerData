using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using log4net;
using RacerData.Commmon.Results;
using RacerData.Common.Results;
using RacerData.Data.Aws.Models;
using RacerData.Data.Aws.Ports;
using RacerData.UpdaterService.Internal;
using RacerData.UpdaterService.Models;
using RacerData.UpdaterService.Ports;

namespace RacerData.UpdaterService.Adapters
{
    class UpdateService : IUpdateService
    {
        //private const string UrlTemplate = "https://s3.amazonaws.com/www.racerdatasoftware.com/Setup/rNascar/0.1.1.5/appSettings.json";
        private const string AwsUpdateBucketUrl = "https://s3.amazonaws.com/www.racerdatasoftware.com/";

        private readonly ILog _log;
        private readonly IAwsRepositoryFactory _repositoryFactory;
        private readonly IResultFactory<UpdateService> _resultFactory;

        public UpdateService(
            ILog log,
            IAwsRepositoryFactory repositoryFactory,
            IResultFactory<UpdateService> resultFactory)
        {
            _log = log ?? throw new ArgumentNullException(nameof(log));

            _repositoryFactory = repositoryFactory ?? throw new ArgumentNullException(nameof(repositoryFactory));
            _resultFactory = resultFactory ?? throw new ArgumentNullException(nameof(resultFactory));
        }

        public async Task<IResult<UpdateResponse>> GetUpdatesAsync(string key, Version version)
        {
            try
            {
                var response = new UpdateResponse()
                {
                    CurrentVersion = version
                };

                var repository = GetUpdatesRepository(key);

                var versions = await repository.SelectListAsync(100);

                foreach (IAwsListItem item in versions)
                {
                    Console.WriteLine($"{AwsUpdateBucketUrl}{item.Key}");

                    if (item is AwsCommonPrefixItem)
                    {
                        // setup/rNascar/0.1.1.5/
                        var versionSection = item.Key.Split('/')[2];
                        var updateVersion = Version.Parse(versionSection);

                        if (updateVersion.Minor > version.Minor)
                        {
                            response.Upgrades.Add(new Upgrade() { Version = updateVersion, Key = item.Key, Url = $"{AwsUpdateBucketUrl}{item.Key}" });
                        }
                        else if (updateVersion > version)
                        {
                            response.Patches.Add(new Patch() { Version = updateVersion, Key = item.Key, Url = $"{AwsUpdateBucketUrl}{item.Key}" });
                        }
                    }
                }

                return _resultFactory.Success(response);
            }
            catch (Exception ex)
            {
                return _resultFactory.Exception<UpdateResponse>(ex);
            }
        }

        public async Task<IResult<UpdateFilesResponse>> GetUpdateFilesAsync(string key)
        {
            try
            {
                var response = new UpdateFilesResponse();

                var repository = GetFilesRepository(key);

                var versions = await repository.SelectListAsync(100);

                foreach (IAwsListItem item in versions)
                {
                    if (item is AwsListItem && !item.Key.EndsWith("/"))
                    {
                        response.UpdateFiles.Add(new UpdateFile()
                        {
                            Key = item.Key,
                            Url = $"{AwsUpdateBucketUrl}{item.Key}"
                        });
                    }
                }

                return _resultFactory.Success(response);
            }
            catch (Exception ex)
            {
                return _resultFactory.Exception<UpdateFilesResponse>(ex);
            }
        }

        public async Task<IResult<DownloadFilesResponse>> DownloadUpdateFiles(IList<string> fileUrls)
        {
            try
            {
                DownloadFilesResponse response = new DownloadFilesResponse();

                await Task.Run(() =>
                {
                    var tempPath = Path.GetTempPath();

                    var randomGuid = Guid.NewGuid();

                    response.TempDirectory  = Path.Combine(tempPath, randomGuid.ToString());

                    Directory.CreateDirectory(response.TempDirectory);

                    WebClient Client = new WebClient();

                    foreach (string fileUrl in fileUrls)
                    {
                        Uri uri = new Uri(fileUrl);

                        string fileName = fileUrl.ToString().Substring(fileUrl.LastIndexOf("/") + 1);

                        var destinationFilePath = Path.Combine(response.TempDirectory, fileName);

                        Client.DownloadFile(uri, destinationFilePath);

                        response.Files.Add(destinationFilePath);
                    }
                });

                return _resultFactory.Success(response);
            }
            catch (Exception ex)
            {
                return _resultFactory.Exception<DownloadFilesResponse>(ex);
            }
        }

        protected virtual IAwsRepository GetUpdatesRepository(string appKey, string newVersion = "")
        {
            var configuration = new AwsUpdateConfiguration(appKey, newVersion);

            return _repositoryFactory.GetAwsRepository(configuration);
        }

        protected virtual IAwsRepository GetFilesRepository(string appKey)
        {
            var configuration = new AwsUpdateFilesConfiguration(appKey);

            return _repositoryFactory.GetAwsRepository(configuration);
        }
    }
}
