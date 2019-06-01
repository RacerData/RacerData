using System;
using System.Windows.Forms;
using RacerData.WinForms.Controls;

namespace rNascarApp.UI.Controls
{
    public partial class VideoView<TModel> : UserControl, IVideoView<TModel>
    {
        #region consts

        private const string livePracticeVideoFeedUrl = @"https://nascaruncovered.akamaized.net/hls/live/2004110/uncovered_practice/master.m3u8";

        #endregion

        #region events

        public event EventHandler<string> SetViewHeaderRequest;
        protected virtual void OnSetViewHeaderRequest(string headerText)
        {
            var handler = SetViewHeaderRequest;
            handler?.Invoke(this, headerText);
        }

        #endregion

        public TModel Model { get; set; }

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
