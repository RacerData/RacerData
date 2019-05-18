using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using RacerData.rNascarApp.Models;

namespace RacerData.rNascarApp.Services
{
    class DirectoryService : IDirectoryService
    {
        #region consts

        private const string DocumentsAppDirectoryName = "rNascar";

        #endregion

        #region private

        private readonly IList<DirectoryMapItem> _directoryMaps;

        #endregion

        #region enums

        protected enum DirectoryRootType
        {
            Application,
            Documents,
            Temp
        }

        #endregion

        #region ctor

        public DirectoryService()
        {
            _directoryMaps = new List<DirectoryMapItem>();

            _directoryMaps.Add(new DirectoryMapItem()
            {
                Root = DirectoryRootType.Documents,
                DirectoryType = DirectoryType.Settings
            });

            _directoryMaps.Add(new DirectoryMapItem()
            {
                Root = DirectoryRootType.Documents,
                DirectoryType = DirectoryType.Themes
            });

            _directoryMaps.Add(new DirectoryMapItem()
            {
                Root = DirectoryRootType.Documents,
                DirectoryType = DirectoryType.Workspaces
            });

            _directoryMaps.Add(new DirectoryMapItem()
            {
                Root = DirectoryRootType.Application,
                DirectoryType = DirectoryType.ErrorLog
            });
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
            var map = _directoryMaps.FirstOrDefault(m => m.DirectoryType == directory);

            var root = GetRootPath(map.Root);

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
                foreach (DirectoryMapItem item in _directoryMaps)
                {
                    GetDirectoryPath(item.DirectoryType, true);
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
                        return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), DocumentsAppDirectoryName);
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

        #region classes

        private class DirectoryMapItem
        {
            public DirectoryRootType Root { get; set; }
            public DirectoryType DirectoryType { get; set; }
        }

        #endregion
    }
}
