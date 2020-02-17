using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using RacerData.iRacing.Telemetry.Models;

namespace RacerData.iRacing.Telemetry
{
    public class IbtFileParser : IIbtFileParser
    {
        #region fields
        private IIbtFileReader _fileReader;
        private IIbtSessionParser _sessionParser;
        #endregion

        #region ctor
        public IbtFileParser(IIbtFileReader fileReader, IIbtSessionParser sessionParser)
        {
            _fileReader = (fileReader == null) ? throw new ArgumentNullException(nameof(fileReader)) : fileReader;
            _sessionParser = (sessionParser == null) ? throw new ArgumentNullException(nameof(fileReader)) : sessionParser;
        }
        #endregion

        #region public
        public async Task<IbtTelemetryFile> ParseTelemetryFileAsync(string fullPath)
        {
            return await ParseTelemetryFileAsync(fullPath, IbtParseOptions.All);
        }
        public async Task<IbtTelemetryFile> ParseTelemetryFileAsync(string fullPath, IbtParseOptions options)
        {
            var binaryData = await _fileReader.ReadTelemetryDataAsync(fullPath);

            var session = await ParseTelemetryDataAsync(binaryData, options);

            session.FullPath = fullPath;

            return session;
        }
        #endregion

        #region protected
        protected virtual async Task<IbtTelemetryFile> ParseTelemetryDataAsync(byte[] binaryData, IbtParseOptions options)
        {
            IbtTelemetryFile telemetryFile = new IbtTelemetryFile();

            telemetryFile.SessionData = await _sessionParser.ParseTelemetrySessionAsync(binaryData, options);

            return telemetryFile;
        }
        #endregion
    }
}
