using System;
using System.Drawing;
using System.Windows.Forms;
using RacerData.WinForms.Controls;
using rNascarApp.UI.Models;

namespace rNascarApp.UI.Controls
{
    public partial class VideoView : UserControl, IVideoView
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

        public event EventHandler<RemoveViewRequestEventArgs> RemoveViewRequest;
        protected virtual void OnRemoveViewRequest(int index)
        {
            var handler = RemoveViewRequest;
            handler?.Invoke(this, new RemoveViewRequestEventArgs(index));
        }

        public event EventHandler<BeginViewResizeRequestEventArgs> BeginViewResizeRequest;
        protected virtual void OnBeginViewResizeRequest(Point point, ResizeDirection resizeDirection)
        {
            var handler = BeginViewResizeRequest;
            handler?.Invoke(this, new BeginViewResizeRequestEventArgs(point, resizeDirection));
        }

        public event EventHandler<ViewResizeRequestEventArgs> ViewResizeRequest;
        protected virtual void OnViewResizeRequest(Point point, ResizeDirection resizeDirection)
        {
            var handler = ViewResizeRequest;
            handler?.Invoke(this, new ViewResizeRequestEventArgs(point, resizeDirection));
        }

        public event EventHandler<EndViewResizeRequestEventArgs> EndViewResizeRequest;
        protected virtual void OnEndViewResizeRequest(bool cancelled, Point point, ResizeDirection resizeDirection)
        {
            var handler = EndViewResizeRequest;
            if (cancelled)
            {
                handler?.Invoke(this, new EndViewResizeRequestEventArgs(cancelled));
            }
            else
            {
                handler?.Invoke(this, new EndViewResizeRequestEventArgs(point, resizeDirection));
            }
        }

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
