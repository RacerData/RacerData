using System.IO;
using System.Threading;
using RacerData.Common.Ports;

namespace RacerData.Common.Adapters
{
    public class FileService : IFileService
    {
        #region consts

        private const int LockTimeout = 5000;

        #endregion

        #region fields

        private readonly static ReaderWriterLock locker = new ReaderWriterLock();

        #endregion

        #region public

        public string ReadFile(string filePath)
        {
            var fileContent = string.Empty;

            try
            {
                locker.AcquireReaderLock(LockTimeout);

                fileContent = File.ReadAllText(filePath);
            }
            finally
            {
                locker.ReleaseReaderLock();
            }

            return fileContent;
        }

        public bool WriteFile(string filePath, string fileContent)
        {
            var result = false;

            try
            {
                locker.AcquireWriterLock(LockTimeout);

                File.WriteAllText(filePath, fileContent);

                result = true;
            }
            finally
            {
                locker.ReleaseWriterLock();
            }

            return result;
        }

        public bool AppendFile(string filePath, string fileContent)
        {
            var result = false;

            try
            {
                locker.AcquireWriterLock(LockTimeout);

                File.AppendAllText(filePath, fileContent);

                result = true;
            }
            finally
            {
                locker.ReleaseWriterLock();
            }

            return result;
        }

        #endregion
    }
}
