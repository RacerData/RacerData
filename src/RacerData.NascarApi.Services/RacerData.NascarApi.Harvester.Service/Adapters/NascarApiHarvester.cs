using System;
using RacerData.NascarApi.Harvester.Service.Ports;
using RacerData.NascarApi.Service;

namespace RacerData.NascarApi.Harvester.Service.Adapters
{
    class NascarApiHarvester : INascarApiHarvester
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

        public void Monitor_LiveFeedStarted(object sender, LiveFeedStartedEventArgs e)
        {

        }

        public void Monitor_LiveFeedUpdated(object sender, LiveFeedUpdatedEventArgs e)
        {
            if (_fileWriter.LastElapsedWritten == null || e.LiveFeedData.Elapsed != _fileWriter.LastElapsedWritten.Value)
                _fileWriter.WriteFile(e.LiveFeedData);
        }

        public void Monitor_ServiceActivity(object sender, ServiceActivityEventArgs e)
        {

        }

        public void Monitor_ServiceStateChanged(object sender, ServiceStateChangedEventArgs e)
        {

        }

        #endregion
    }
}
