using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using RacerData.WinForms.Controls;

namespace rNascarApp.UI.Controls
{
    public partial class AudioView<TModel> : UserControl, IAudioView<TModel>
    {
        #region events

        public event EventHandler<string> SetViewHeaderRequest;
        protected virtual void OnSetViewHeaderRequest(string headerText)
        {
            var handler = SetViewHeaderRequest;
            handler?.Invoke(this, headerText);
        }

        #endregion

        #region properties

        public TModel Model { get; set; }

        public IList<AudioFeed> AudioFeeds { get; set; }

        #endregion

        #region ctor

        public AudioView()
        {
            InitializeComponent();

            if (AudioFeeds == null || AudioFeeds.Count == 0)
            {
                AudioFeeds = new List<AudioFeed>();
                AudioFeeds.Add(new AudioFeed()
                {
                    StreamNumber = 1,
                    DriverNumber = "All Scan",
                    Name = "All Scan",
                    Stream_RTMP = "nscs_raceview_01@79772",
                    Stream_IOS = @"596367/driveaudio_01/master.m3u8"
                });
                AudioFeeds.Add(new AudioFeed()
                {
                    StreamNumber = 31,
                    DriverNumber = "43",
                    Name = "Bubba Wallace",
                    Stream_RTMP = "nscs_raceview_31@86101",
                    Stream_IOS = @"596466/driveaudio_31/master.m3u8"
                });
                AudioFeeds.Add(new AudioFeed()
                {
                    StreamNumber = 47,
                    DriverNumber = "MRN Radio",
                    Name = "MRN Radio",
                    Stream_RTMP = "nscs_raceview_47@86119",
                    Stream_IOS = @"596495/driveaudio_47/master.m3u8"
                });
                AudioFeeds.Add(new AudioFeed()
                {
                    StreamNumber = 48,
                    DriverNumber = "Officials",
                    Name = "Officials",
                    Stream_RTMP = "nscs_raceview_48@86120",
                    Stream_IOS = @"596496/driveaudio_48/master.m3u8"
                });
            }

            cboChannel.ValueMember = "Id";
            cboChannel.DisplayMember = "Name";
            cboChannel.DataSource = AudioFeeds.OrderBy(f => f.StreamNumber).ToList();
            cboChannel.SelectedIndex = -1;

            cboChannel.SelectedIndexChanged += this.cboChannel_SelectedIndexChanged;
        }

        #endregion

        #region private

        private void cboChannel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboChannel.SelectedItem == null)
                return;

            AudioFeed selected = (AudioFeed)cboChannel.SelectedItem;

            PlayAudioFeed(selected);
        }

        private void PlayAudioFeed(AudioFeed audioFeed)
        {
            if (audioFeed == null)
                return;

            var token = @"<#SOURCE#>";

            var template = Properties.Resources.audioFeedTemplate;

            var html = template.Replace(token, audioFeed.Source);

            webViewCompatible1.NavigateToString(html);
        }

        private void btnPlayFeed_Click(object sender, EventArgs e)
        {
            var token = @"<#SOURCE#>";

            var template = Properties.Resources.audioFeedTemplate;

            var html = template.Replace(token, txtFeed.Text.Trim());

            webViewCompatible1.NavigateToString(html);
        }

        #endregion

        #region classes

        public class AudioFeed
        {
            public int StreamNumber { get; set; }
            public string DriverNumber { get; set; }
            public string Name { get; set; }
            public string Source
            {
                get
                {
                    return $"{BaseUrl}{Stream_IOS}";
                }
            }
            public string Stream_RTMP { get; set; }
            public string Stream_IOS { get; set; }
            public string BaseUrl { get; set; }

            public AudioFeed()
            {
                BaseUrl = @"https://driveaudio.akamaized.net/hls/live/";
            }

        }

        #endregion
    }
}
