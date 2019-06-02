using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using RacerData.WinForms.Models;

namespace RacerData.WinForms.Controls
{
    public partial class AudioView : UserControl, IAudioView
    {
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

        #region properties

        private IList<AudioFeedInfo> _audioFeeds;
        public IList<AudioFeedInfo> AudioFeeds
        {
            get
            {
                return _audioFeeds;
            }
            set
            {
                _audioFeeds = value;
                DisplayAudioFeeds(_audioFeeds);
            }
        }

        #endregion

        #region ctor

        public AudioView()
        {
            InitializeComponent();

            if (AudioFeeds == null || AudioFeeds.Count == 0)
            {
                var defaultFeeds = new List<AudioFeedInfo>();
                defaultFeeds.Add(new AudioFeedInfo()
                {
                    StreamNumber = 1,
                    DriverNumber = "All Scan",
                    Name = "All Scan",
                    Stream_RTMP = "nscs_raceview_01@79772",
                    Stream_IOS = @"596367/driveaudio_01/master.m3u8"
                });
                defaultFeeds.Add(new AudioFeedInfo()
                {
                    StreamNumber = 32,
                    DriverNumber = "43",
                    Name = "Bubba Wallace",
                    Stream_RTMP = "nscs_raceview_31@86101",
                    Stream_IOS = @"596466/driveaudio_31/master.m3u8"
                });
                defaultFeeds.Add(new AudioFeedInfo()
                {
                    StreamNumber = 47,
                    DriverNumber = "MRN Radio",
                    Name = "MRN Radio",
                    Stream_RTMP = "nscs_raceview_47@86119",
                    Stream_IOS = @"596495/driveaudio_47/master.m3u8"
                });
                defaultFeeds.Add(new AudioFeedInfo()
                {
                    StreamNumber = 48,
                    DriverNumber = "Officials",
                    Name = "Officials",
                    Stream_RTMP = "nscs_raceview_48@86120",
                    Stream_IOS = @"596496/driveaudio_48/master.m3u8"
                });

                AudioFeeds = defaultFeeds;
            }
        }

        #endregion

        #region protected

        protected virtual void DisplayAudioFeeds(IList<AudioFeedInfo> audioFeeds)
        {
            cboChannel.SelectedIndexChanged -= this.cboChannel_SelectedIndexChanged;

            cboChannel.DataSource = null;

            cboChannel.ValueMember = "Id";
            cboChannel.DisplayMember = "Name";
            cboChannel.DataSource = AudioFeeds.OrderBy(f => f.StreamNumber).ToList();
            cboChannel.SelectedIndex = -1;

            cboChannel.SelectedIndexChanged += this.cboChannel_SelectedIndexChanged;
        }

        protected virtual void PlayAudioFeed(AudioFeedInfo audioFeed)
        {
            if (audioFeed == null)
                return;

            var token = @"<#SOURCE#>";

            var template = Properties.Resources.audioFeedTemplate;

            var html = template.Replace(token, audioFeed.Source);

            webViewCompatible1.NavigateToString(html);

            OnSetViewHeaderRequest($"Audio: {audioFeed.Name}");
        }

        #endregion

        #region private

        private void cboChannel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboChannel.SelectedItem == null)
                return;

            AudioFeedInfo selected = (AudioFeedInfo)cboChannel.SelectedItem;

            PlayAudioFeed(selected);
        }

        #endregion
    }
}
