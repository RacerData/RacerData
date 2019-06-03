using System;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using RacerData.Commmon.Results;
using RacerData.WinForms.Controls.Models.VideoView;
using RacerData.WinForms.Controls.Ports;

namespace RacerData.WinForms.Controls.VideoView
{
    public class VideoViewModel
    {
        #region events

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            handler?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        #region fields

        private readonly IVideoChannelService _channelService;

        #endregion

        #region properties

        private VideoChannelModel _channel;
        public VideoChannelModel Channel
        {
            get
            {
                return _channel;
            }
            set
            {
                _channel = value;
                OnPropertyChanged(nameof(Channel));
            }
        }

        private BindingList<VideoChannelModel> _channels;
        public BindingList<VideoChannelModel> Channels
        {
            get
            {
                return _channels;
            }
            set
            {
                _channels = value;
                OnPropertyChanged(nameof(Channels));
            }
        }

        #endregion

        #region ctor

        public VideoViewModel(
            IVideoChannelService channelService)
        {
            _channelService = channelService ?? throw new ArgumentNullException(nameof(channelService));

            _channels = new BindingList<VideoChannelModel>();
        }

        #endregion

        #region public

        public virtual async Task GetChannelsCommandAsync()
        {
            var result = await _channelService.GetChannelsAsync();

            if (!result.IsSuccessful())
            {
                throw result.Exception;
            }

            var channels = result.Value;

            Channels.Clear();
            Channel = null;

            channels.ToList().ForEach(c => _channels.Add(c));

            OnPropertyChanged(nameof(Channels));
        }

        public virtual void SelectChannelCommand(VideoChannelModel channel)
        {
            Channel = channel;
        }

        #endregion
    }
}
