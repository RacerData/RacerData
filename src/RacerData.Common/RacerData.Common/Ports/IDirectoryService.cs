﻿using RacerData.Common.Models;

namespace RacerData.Common.Ports
{
    public interface IDirectoryService
    {
        string GetDirectoryPath(DirectoryType directory);
        string GetDirectoryPath(DirectoryType directory, bool createIfNotExists);
        string GetFullPath(DirectoryType directory, string fileTitle);
        string GetFullPath(DirectoryType directory, string fileTitle, bool createDirectoryIfNotExists);

        bool VerifyDirectories(bool throwErrorOnFail);
    }
}