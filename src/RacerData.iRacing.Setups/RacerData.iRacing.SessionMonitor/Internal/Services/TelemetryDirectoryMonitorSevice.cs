using System;

namespace RacerData.iRacing.SessionMonitor.Internal.Services
{
    internal class TelemetryDirectoryMonitorSevice : DirectoryMonitorService, IDirectoryMonitorService
    {
        #region consts

        private const string DefaultSetupDirectory = "iRacing\\Telemetry";
        private const string SetupFilter = "*.ibt";

        #endregion

        #region ctor

        public TelemetryDirectoryMonitorSevice()
            : base(null, SetupFilter)
        {
            var myDocumentsDirectory = System.IO.Path.Combine(Environment.ExpandEnvironmentVariables("%userprofile%"), "Documents");
            Path = System.IO.Path.Combine(myDocumentsDirectory, DefaultSetupDirectory);
        }

        public TelemetryDirectoryMonitorSevice(string path)
            : base(path, SetupFilter)
        {
        }

        #endregion
    }
}
