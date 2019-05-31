using System.Windows.Forms;

namespace rNascarApp.UI.Controls
{
    public partial class VideoView : UserControl
    {
        #region consts

        private const string livePracticeVideoFeedUrl = @"https://nascaruncovered.akamaized.net/hls/live/2004110/uncovered_practice/master.m3u8";

        #endregion

        #region ctor

        public VideoView()
        {
            InitializeComponent();

            PlayVideoFeed(livePracticeVideoFeedUrl);
        }

        #endregion

        #region private

        private void PlayVideoFeed(string videoFeedUrl)
        {
            var token = @"<#SOURCE#>";

            var template = Properties.Resources.videoFeedTemplate;

            var html = template.Replace(token, videoFeedUrl);

            webViewCompatible1.NavigateToString(html);
        }

        #endregion
    }
}
