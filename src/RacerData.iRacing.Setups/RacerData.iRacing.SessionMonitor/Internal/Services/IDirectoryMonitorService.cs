using System;
using System.IO;
using RacerData.iRacing.SessionMonitor.Internal.Models;

namespace RacerData.iRacing.SessionMonitor.Internal.Services
{
    public interface IDirectoryMonitorService
    {
        string Filter { get; set; }
        bool IncludeSubdirectories { get; set; }
        string Path { get; set; }

        event EventHandler<DirectoryMonitorEventArgs> FileCreated;
        event EventHandler<ErrorEventArgs> FileServiceError;
        event EventHandler<DirectoryMonitorEventArgs> FileUpdated;

        void Dispose();
        void StartService();
        void StopService();
    }
}