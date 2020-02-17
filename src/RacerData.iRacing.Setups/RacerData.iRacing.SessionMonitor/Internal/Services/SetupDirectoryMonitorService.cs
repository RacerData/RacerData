using System;

namespace RacerData.iRacing.SessionMonitor.Internal.Services
{
    internal class SetupDirectoryMonitorService : DirectoryMonitorService, IDirectoryMonitorService
    {
        #region consts

        private const string DefaultSetupDirectory = "iRacing\\Setups";
        private const string SetupFilter = "*.sto";

        #endregion

        #region ctor

        public SetupDirectoryMonitorService()
            : base(null, SetupFilter)
        {
            var myDocumentsDirectory = System.IO.Path.Combine(Environment.ExpandEnvironmentVariables("%userprofile%"), "Documents");
            Path = System.IO.Path.Combine(myDocumentsDirectory, DefaultSetupDirectory);
        }

        public SetupDirectoryMonitorService(string path)
            : base(path, SetupFilter)
        {
        }

        #endregion
    }
}
