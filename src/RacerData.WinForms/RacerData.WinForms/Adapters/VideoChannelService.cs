using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RacerData.Commmon.Results;
using RacerData.Common.Results;
using RacerData.WinForms.Models;
using RacerData.WinForms.Ports;

namespace RacerData.WinForms.Adapters
{
    class VideoChannelService : IVideoChannelService
    {
        #region consts

        private const string livePracticeVideoFeedUrl = @"https://nascaruncovered.akamaized.net/hls/live/2004110/uncovered_practice/master.m3u8";

        #endregion

        #region fields

        private IList<VideoChannelModel> _defaultChannels = new List<VideoChannelModel>();
        private readonly IResultFactory<VideoChannelService> _resultFactory;

        #endregion

        #region ctor

        public VideoChannelService(IResultFactory<VideoChannelService> resultFactory)
        {
            _resultFactory = resultFactory ?? throw new ArgumentNullException(nameof(resultFactory));

            BuildDefaultChannelList();
        }

        #endregion

        #region public

        public virtual async Task<IResult<IList<VideoChannelModel>>> GetChannelsAsync()
        {
            return await Task.FromResult(_resultFactory.Success(_defaultChannels.ToList()));
        }

        #endregion

        #region protected

        protected virtual void BuildDefaultChannelList()
        {
            var defaultChannels = new List<VideoChannelModel>();

            defaultChannels.Add(new VideoChannelModel()
            {
                Id = Guid.NewGuid(),
                Name = "Live Practice",
                Html = Properties.Resources.videoFeedTemplate.Replace("<#SOURCE#>", livePracticeVideoFeedUrl)
            });

            var garageCamVideoElement = "<video id=\"bcPlayer_html5_api\" data-account=\"1677257476001\" data-player=\"r11YsOYjg\" data-video-id=\"6043591854001\" data-embed=\"default\" playsinline=\"playsinline\" class=\"vjs-tech\" style=\"width:100 %; height:100 %;\" tabindex=\" - 1\" preload=\"auto\" src=\"blob: https://www.nascar.com/345c4134-7aab-4077-be48-a9531b04a501\"></video>";

            defaultChannels.Add(new VideoChannelModel()
            {
                Id = Guid.NewGuid(),
                Name = "Garage Cam",
                Html= Properties.Resources.videoFeedTemplate.Replace("<#VIDEOELEMENT#>", garageCamVideoElement)
            });

            defaultChannels.ForEach(f => _defaultChannels.Add(f));
        }

        #endregion
    }
}
