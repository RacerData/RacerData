using System;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using RacerData.Commmon.Results;
using RacerData.WinForms.Controls.Models;
using RacerData.WinForms.Controls.Ports;

namespace RacerData.WinForms.Controls.AudioView
{
    public class AudioViewModel
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

        private readonly IAudioChannelService _channelService;
        private readonly ISeriesService _seriesService;

        #endregion

        #region properties

        private SeriesModel _series;
        public SeriesModel Series
        {
            get
            {
                return _series;
            }
            set
            {
                _series = value;
                OnPropertyChanged(nameof(Series));
            }
        }

        private AudioChannelModel _channel;
        public AudioChannelModel Channel
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

        private BindingList<AudioChannelModel> _channels;
        public BindingList<AudioChannelModel> Channels
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

        private BindingList<SeriesModel> _seriesList;
        public BindingList<SeriesModel> SeriesList
        {
            get
            {
                return _seriesList;
            }
            set
            {
                _seriesList = value;
                OnPropertyChanged(nameof(SeriesList));
            }
        }

        #endregion

        #region ctor

        public AudioViewModel(
            IAudioChannelService channelService,
            ISeriesService seriesService)
        {
            _channelService = channelService ?? throw new ArgumentNullException(nameof(channelService));
            _seriesService = seriesService ?? throw new ArgumentNullException(nameof(seriesService));

            _channels = new BindingList<AudioChannelModel>();

            _seriesList = new BindingList<SeriesModel>();
        }

        #endregion

        #region public

        public virtual async Task GetSeriesListCommandAsync()
        {
            var result = await _seriesService.GetSeriesListAsync();

            if (!result.IsSuccessful())
            {
                throw result.Exception;
            }

            var seriesList = result.Value;

            Channels.Clear();
            Channel = null;
            SeriesList.Clear();
            Series = null;

            seriesList.ToList().ForEach(s => SeriesList.Add(s));

            OnPropertyChanged(nameof(SeriesList));
        }

        public virtual async Task SelectSeriesCommandAsync(SeriesModel series)
        {
            Series = series;

            await GetChannelsCommandAsync(series.Id);
        }

        public virtual async Task GetChannelsCommandAsync(int seriesId)
        {
            var result = await _channelService.GetChannelsAsync(seriesId);

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

        public virtual void SelectChannelCommand(AudioChannelModel channel)
        {
            Channel = channel;
        }

        #endregion
    }
}
