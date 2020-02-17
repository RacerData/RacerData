using System;
using System.IO;
using System.Threading.Tasks;

namespace RacerData.iRacing.SessionMonitor.Internal.Services
{
    internal class SetupBackupService
    {
        #region consts

        private const string DefaultBackupSetupPath = @"C:\BackupSetups\";

        #endregion

        #region properties

        public string SetupBackupDirectory { get; set; } = DefaultBackupSetupPath;

        #endregion

        #region ctor

        public SetupBackupService()
        {

        }
        public SetupBackupService(string setupBackupDirectory)
        {
            SetupBackupDirectory = setupBackupDirectory;
        }

        #endregion

        #region public

        public async Task<string> BackupSetupFileAsync(string telemetryFileName, string setupName, string setupVehicleDirectory, int? updateCount)
        {
            if (!Directory.Exists(setupVehicleDirectory))
                throw new FileNotFoundException("Setup directory not found", setupVehicleDirectory);

            string telemetryFileTitle = Path.GetFileNameWithoutExtension(telemetryFileName);
            string setupFileTitle = Path.GetFileNameWithoutExtension(setupName);
            string setupFilePath = Path.Combine(setupVehicleDirectory, "-Current-");
            string backupSetupFileName = $"{setupFileTitle}-{updateCount}-{telemetryFileTitle}.sto";
            string backupSetupFilePath = Path.Combine(SetupBackupDirectory, backupSetupFileName);

            if (!Directory.Exists(SetupBackupDirectory))
            {
                try
                {
                    Directory.CreateDirectory(SetupBackupDirectory);
                }
                catch (Exception ex)
                {
                    throw new Exception($"Error trying to create setup backup directory ({SetupBackupDirectory}): {ex.Message}", ex);
                }
            }

            int fileCopyCounter = 0;
            while (File.Exists(backupSetupFilePath))
            {
                backupSetupFileName = $"{setupFileTitle}-{updateCount}-{telemetryFileTitle}({fileCopyCounter}).sto";
                backupSetupFilePath = Path.Combine(SetupBackupDirectory, backupSetupFileName);
                fileCopyCounter += 1;
            }

            await CopyFileAsync(setupFilePath, backupSetupFilePath);

            return backupSetupFilePath;
        }

        #endregion

        #region private

        private static async Task CopyFileAsync(string sourceFile, string destinationFile)
        {
            using (var sourceStream = new FileStream(sourceFile, FileMode.Open, FileAccess.Read, FileShare.Read, 4096, FileOptions.Asynchronous | FileOptions.SequentialScan))
            using (var destinationStream = new FileStream(destinationFile, FileMode.CreateNew, FileAccess.Write, FileShare.None, 4096, FileOptions.Asynchronous | FileOptions.SequentialScan))
                await sourceStream.CopyToAsync(destinationStream);
        }

        #endregion
    }
}
