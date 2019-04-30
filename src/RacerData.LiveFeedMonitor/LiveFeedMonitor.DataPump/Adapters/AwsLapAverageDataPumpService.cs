using System;
using System.Threading.Tasks;
using log4net;
using RacerData.LiveFeed.AwsDataPump.Internal;
using RacerData.NascarApi.Client.Models.LapAverages;
using RacerData.NascarApi.Service;
using RacerData.NascarApi.Service.Ports;

namespace RacerData.LiveFeed.AwsDataPump.Adapters
{
    class AwsLapAverageDataPumpService : ILapAverageDataPumpService
    {
        #region fields

        private ILog _log;
        private DataPump _dataPump;

        #endregion

        #region ctor

        public AwsLapAverageDataPumpService(ILog log)
        {
            _log = log ?? throw new ArgumentNullException(nameof(log));

            _dataPump = new DataPump(log);
        }

        #endregion

        #region public

        public virtual void Monitor_EventUpdated(object sender, LiveFeedUpdatedEventArgs e)
        {

        }

        public async Task<bool> UpdateLapAverageDataAsync(EventLapAverages lapAverages)
        {
            var result = false;

            try
            {
                _log?.Info("Pushing lap averages to AWS");

                result = await _dataPump.WriteLapAveragesAsync(lapAverages);

                if (result)
                _log?.Info("Lap averages pushed to AWS");
            }
            catch (Exception ex)
            {
                ExceptionHandler("Error sending lap averages to AWS", ex);
            }

            return await Task.FromResult(result);
        }

        #endregion

        #region protected

        protected virtual void ExceptionHandler(string message, Exception ex)
        {
            _log?.Error(message, ex);
#if DEBUG
            Console.WriteLine(ex);
#endif
        }

        #endregion
    }
}
