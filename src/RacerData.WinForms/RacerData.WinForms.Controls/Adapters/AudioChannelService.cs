using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RacerData.Commmon.Results;
using RacerData.Common.Results;
using RacerData.WinForms.Controls.AudioView;
using RacerData.WinForms.Controls.Ports;

namespace RacerData.WinForms.Controls.Adapters
{
    public class AudioChannelService : IAudioChannelService
    {
        #region consts

        private const string CupAudioFeedUrl = @"https://www.nascar.com/config/audio/audio_mapping_1_3.json";
        private const string XfinityAudioFeedUrl = @"https://www.nascar.com/config/audio/audio_mapping_2_3.json";
        private const string TruckAudioFeedUrl = @"https://www.nascar.com/config/audio/audio_mapping_3_3.json";

        #endregion

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
            var channelList = GetChannelList(seriesId);

            return await Task.FromResult(_resultFactory.Success(channelList));
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

        protected virtual IList<AudioChannelInfo> GetChannelList(int seriesId)
        {
            var channels = new List<AudioChannelInfo>();

            var url = GetChannelListUrl(seriesId);

            if (String.IsNullOrEmpty(url))
                return _defaultChannels;

            using (WebClient wc = new WebClient())
            {
                var json = wc.DownloadString(url);

                var root = JsonConvert.DeserializeObject<RootObject>(json);

                foreach (AudioConfig feed in root.audio_config)
                {
                    channels.Add(new AudioChannelInfo()
                    {
                        DriverNumber = feed.driver_number,
                        Name = feed.driver_name,
                        StreamNumber = feed.stream_number,
                        Stream_IOS = feed.stream_ios,
                        Stream_RTMP = feed.stream_rtmp,
                        BaseUrl = feed.base_url
                    });
                }
            }

            return channels;
        }
        protected virtual string GetChannelListUrl(int seriesId)
        {
            if (seriesId == 1)
            {
                return CupAudioFeedUrl;
            }
            else if (seriesId == 2)
            {
                return XfinityAudioFeedUrl;
            }
            else if (seriesId == 3)
            {
                return TruckAudioFeedUrl;
            }

            return string.Empty;
        }

        #endregion

        #region classes

        internal class AudioConfig
        {
            public int stream_number { get; set; }
            public string driver_number { get; set; }
            public string driver_name { get; set; }
            public string base_url { get; set; }
            public string stream_rtmp { get; set; }
            public string stream_ios { get; set; }
            public bool requiresAuth { get; set; }
        }

        internal class RootObject
        {
            public int historical_race_id { get; set; }
            public string race_name { get; set; }
            public int run_type { get; set; }
            public string track_name { get; set; }
            public int series_id { get; set; }
            public List<AudioConfig> audio_config { get; set; }
        }

        #endregion
    }
}
