using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RacerData.Commmon.Results;
using RacerData.Common.Results;
using RacerData.WinForms.Controls.AudioView;
using RacerData.WinForms.Controls.Ports;

namespace RacerData.WinForms.Controls.Adapters
{
    public class AudioChannelService : IAudioChannelService
    {
        #region fields

        private IList<AudioChannelInfo> _defaultChannels = new List<AudioChannelInfo>();
        private readonly IResultFactory<AudioChannelService> _resultFactory;

        #endregion

        #region ctor

        public AudioChannelService(IResultFactory<AudioChannelService> resultFactory)
        {
            _resultFactory = resultFactory ?? throw new ArgumentNullException(nameof(resultFactory));

            BuildDefaultChannelList();
        }

        #endregion

        #region public

        public virtual async Task<IResult<IList<AudioChannelInfo>>> GetDefaultChannelsAsync()
        {
            return await Task.FromResult(_resultFactory.Success(_defaultChannels.ToList()));
        }

        public virtual async Task<IResult<IList<AudioChannelInfo>>> GetChannelsAsync(int seriesId)
        {
            return await Task.FromResult(_resultFactory.Success(_defaultChannels.ToList()));
        }

        #endregion

        #region protected

        protected virtual void BuildDefaultChannelList()
        {
            var defaultChannels = new List<AudioChannelInfo>();
            defaultChannels.Add(new AudioChannelInfo()
            {
                StreamNumber = 1,
                DriverNumber = "All Scan",
                Name = "All Scan",
                Stream_RTMP = "nscs_raceview_01@79772",
                Stream_IOS = @"596367/driveaudio_01/master.m3u8"
            });
            defaultChannels.Add(new AudioChannelInfo()
            {
                StreamNumber = 32,
                DriverNumber = "43",
                Name = "Bubba Wallace",
                Stream_RTMP = "nscs_raceview_31@86101",
                Stream_IOS = @"596466/driveaudio_31/master.m3u8"
            });
            defaultChannels.Add(new AudioChannelInfo()
            {
                StreamNumber = 47,
                DriverNumber = "MRN Radio",
                Name = "MRN Radio",
                Stream_RTMP = "nscs_raceview_47@86119",
                Stream_IOS = @"596495/driveaudio_47/master.m3u8"
            });
            defaultChannels.Add(new AudioChannelInfo()
            {
                StreamNumber = 48,
                DriverNumber = "Officials",
                Name = "Officials",
                Stream_RTMP = "nscs_raceview_48@86120",
                Stream_IOS = @"596496/driveaudio_48/master.m3u8"
            });

            defaultChannels.ForEach(f => _defaultChannels.Add(f));
        }

        #endregion
    }
}
