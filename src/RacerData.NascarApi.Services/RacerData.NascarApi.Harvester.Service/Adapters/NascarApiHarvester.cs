using System;
using RacerData.NascarApi.Harvester.Service.Ports;
using RacerData.NascarApi.Service;
using RacerData.NascarApi.Service.Adapters;

namespace RacerData.NascarApi.Harvester.Service.Adapters
{
    class NascarApiHarvester : MonitorClientBase, INascarApiHarvester
    {
        #region fields

        private ILiveFeedDataFileWriter _fileWriter;

        #endregion

        #region ctor

        public NascarApiHarvester(ILiveFeedDataFileWriter fileWriter)
        {
            _fileWriter = fileWriter ?? throw new ArgumentNullException(nameof(fileWriter));
        }

        #endregion

        #region public

        public override void Monitor_LiveFeedUpdated(object sender, LiveFeedUpdatedEventArgs e)
        {
            if (_fileWriter.LastElapsedWritten == null || e.LiveFeedData.Elapsed != _fileWriter.LastElapsedWritten.Value)
                _fileWriter.WriteFile(e.LiveFeedData);
        }

        #endregion
    }
}
