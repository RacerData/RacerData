using System;
using System.IO;
using System.Linq;
using Microsoft.Extensions.Options;
using RacerData.Common.Models;
using RacerData.Common.Ports;

namespace RacerData.Common.Adapters
{
    class DirectoryService : IDirectoryService
    {
        #region private

        private readonly DirectoryConfiguration _directoriesConfiguration = new DirectoryConfiguration();

        #endregion

        #region ctor

        public DirectoryService(IOptions<DirectoryConfiguration> options)
        {
            _directoriesConfiguration = options?.Value ?? throw new ArgumentNullException(nameof(options));
        }

        #endregion

        #region public

        public string GetFullPath(DirectoryType directory, string fileTitle)
        {
            return GetFullPath(directory, fileTitle, false);
        }
        public string GetFullPath(DirectoryType directory, string fileTitle, bool createDirectoryIfNotExists)
        {
            var directoryPath = GetDirectoryPath(directory, createDirectoryIfNotExists);

            return Path.Combine(directoryPath, fileTitle);
        }

        public string GetDirectoryPath(DirectoryType directory)
        {
            return GetDirectoryPath(directory, false); ;
        }
        public string GetDirectoryPath(DirectoryType directory, bool createIfNotExists)
        {
            var map = _directoriesConfiguration.map.FirstOrDefault(m => m.Directory == directory);

            var root = GetRootPath(map.RootDirectory);

            var directoryPath = Path.Combine(root, directory.ToString());

            if (createIfNotExists && !Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            return directoryPath;
        }

        public bool VerifyDirectories(bool throwErrorOnFail)
        {
            try
            {
                foreach (DirectoryMapItem item in _directoriesConfiguration.map)
                {
                    GetDirectoryPath(item.Directory, true);
                }

                return true;
            }
            catch (Exception)
            {
                if (throwErrorOnFail)
                    throw;
            }

            return false;
        }

        #endregion

        #region protected

        protected virtual string GetRootPath(DirectoryRootType root)
        {
            switch (root)
            {
                case DirectoryRootType.Application:
                    {
                        return Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);
                    }
                case DirectoryRootType.Documents:
                    {
                        return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), _directoriesConfiguration.myDocumentsFolder);
                    }
                case DirectoryRootType.Temp:
                    {
                        var tempDirectory = Path.GetTempPath();
                        var tempGuid = Guid.NewGuid();
                        return Path.Combine(tempDirectory, tempGuid.ToString());
                    }
                default:
                    return @".\";
            }
        }

        #endregion
    }
}
