using System;
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

        #region fields

        private readonly AudioViewModel _viewModel;

        #endregion

        #region properties

        private ApplicationAppearance _appearance;
        public virtual ApplicationAppearance Appearance
        {
            get
            {
                return _appearance;
            }
            set
            {
                _appearance = value;
                ApplyTheme(_appearance);
            }
        }

        #endregion

        #region ctor

        public AudioView(AudioViewModel viewModel)
            : this()
        {
            _viewModel = viewModel ?? throw new ArgumentNullException(nameof(viewModel));
        }

        internal AudioView()
        {
            InitializeComponent();
        }

        #endregion

        #region protected

        protected virtual void ApplyTheme(ApplicationAppearance appearance)
        {
            if (appearance != null)
            {
                this.BackColor = appearance.DialogAppearance.BackColor;
                this.ForeColor = appearance.DialogAppearance.ForeColor;
                this.Font = appearance.DialogAppearance.Font;

                pnlSelection.BackColor = appearance.DialogAppearance.BackColor;
                pnlSelection.ForeColor = appearance.DialogAppearance.ForeColor;
                pnlSelection.Font = appearance.DialogAppearance.Font;

                lblSeries.BackColor = appearance.DialogAppearance.BackColor;
                lblSeries.ForeColor = appearance.DialogAppearance.ForeColor;
                lblSeries.Font = appearance.DialogAppearance.Font;

                lblChannel.BackColor = appearance.DialogAppearance.BackColor;
                lblChannel.ForeColor = appearance.DialogAppearance.ForeColor;
                lblChannel.Font = appearance.DialogAppearance.Font;

                cboSeries.BackColor = appearance.ListAppearance.BackColor;
                cboSeries.ForeColor = appearance.ListAppearance.ForeColor;
                cboSeries.Font = appearance.ListAppearance.Font;

                cboChannel.BackColor = appearance.ListAppearance.BackColor;
                cboChannel.ForeColor = appearance.ListAppearance.ForeColor;
                cboChannel.Font = appearance.ListAppearance.Font;

                webViewCompatible1.BackColor = appearance.DarkAccentAppearance.BackColor;
            }
        }

        protected virtual void SetDataBindings(AudioViewModel model)
        {
            model.PropertyChanged += ViewModel_PropertyChanged;
        }

        protected virtual void UpdateChannelListBinding()
        {
            cboChannel.SelectedIndexChanged -= this.cboChannel_SelectedIndexChanged;

            cboChannel.DataSource = null;

            cboChannel.ValueMember = "Id";
            cboChannel.DisplayMember = "Name";
            cboChannel.DataSource = _viewModel.Channels.OrderBy(c => c.StreamNumber).ToList();
            cboChannel.SelectedIndex = -1;

            cboChannel.SelectedIndexChanged += this.cboChannel_SelectedIndexChanged;
        }

        protected virtual void UpdateSeriesListBinding()
        {
            cboSeries.SelectedIndexChanged -= this.cboSeries_SelectedIndexChanged;

            cboSeries.DataSource = null;

            cboSeries.ValueMember = "Id";
            cboSeries.DisplayMember = "Abbreviation";
            cboSeries.DataSource = _viewModel.SeriesList.OrderBy(s => s.Id).ToList();
            cboSeries.SelectedIndex = -1;

            cboSeries.SelectedIndexChanged += this.cboSeries_SelectedIndexChanged;
        }

        protected virtual void ClearDisplay()
        {
            webViewCompatible1.NavigateToString(Properties.Resources.noChannelSelected);

            OnSetViewHeaderRequest($"Audio: No Channel Selected");
        }

        protected virtual void PlayAudioFeed(AudioChannelModel audioFeed)
        {
            ClearDisplay();

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

        private async void AudioView_Load(object sender, EventArgs e)
        {
            SetDataBindings(_viewModel);

            ApplyTheme(Appearance);

            await _viewModel.GetSeriesListCommandAsync();
        }

        private void ViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(AudioViewModel.Channel))
            {
                PlayAudioFeed(_viewModel.Channel);
            }
            else if (e.PropertyName == nameof(AudioViewModel.SeriesList))
            {
                UpdateSeriesListBinding();
            }
            else if (e.PropertyName == nameof(AudioViewModel.Channels))
            {
                UpdateChannelListBinding();
            }
        }

        private void cboChannel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboChannel.SelectedItem == null)
                return;

            AudioChannelModel selected = (AudioChannelModel)cboChannel.SelectedItem;

            _viewModel.SelectChannelCommand(selected);
        }

        private async void cboSeries_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboSeries.SelectedItem == null)
                return;

            SeriesModel selected = (SeriesModel)cboSeries.SelectedItem;

            await _viewModel.SelectSeriesCommandAsync(selected);
        }

        #endregion
    }
}
