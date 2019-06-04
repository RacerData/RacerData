using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using RacerData.WinForms.Controls.Models.VideoView;
using RacerData.WinForms.Models;

namespace RacerData.WinForms.Controls.VideoView
{
    public partial class VideoView : UserControl, IVideoView
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

        private readonly VideoViewModel _viewModel;

        #endregion

        #region ctor

        public VideoView(VideoViewModel viewModel)
            : this()
        {
            _viewModel = viewModel ?? throw new ArgumentNullException(nameof(viewModel));
        }

        internal VideoView()
        {
            InitializeComponent();
        }

        #endregion

        #region protected

        protected virtual void SetDataBindings(VideoViewModel model)
        {
            model.PropertyChanged += ViewModel_PropertyChanged;
        }

        protected virtual void UpdateChannelListBinding()
        {
            cboChannel.SelectedIndexChanged -= this.cboChannel_SelectedIndexChanged;

            cboChannel.DataSource = null;

            cboChannel.ValueMember = "Id";
            cboChannel.DisplayMember = "Name";
            cboChannel.DataSource = _viewModel.Channels.OrderBy(c => c.Name).ToList();
            cboChannel.SelectedIndex = -1;

            cboChannel.SelectedIndexChanged += this.cboChannel_SelectedIndexChanged;
        }

        protected virtual void PlayVideoFeed(VideoViewModel model)
        {
            ClearDisplay();

            if (model == null || model.Channel == null)
                return;

            webViewCompatible1.NavigateToString(model.Channel.Html);

            OnSetViewHeaderRequest($"Video: {model.Channel.Name}");
        }

        protected virtual void ClearDisplay()
        {
            webViewCompatible1.NavigateToString(Properties.Resources.noChannelSelected);

            OnSetViewHeaderRequest($"Video: No Channel Selected");
        }

        #endregion

        #region private

        private void ViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(VideoViewModel.Channel))
            {
                PlayVideoFeed(_viewModel);
            }
            else if (e.PropertyName == nameof(VideoViewModel.Channels))
            {
                UpdateChannelListBinding();
            }
        }

        private void cboChannel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboChannel.SelectedItem == null)
                return;

            VideoChannelModel selected = (VideoChannelModel)cboChannel.SelectedItem;

            _viewModel.SelectChannelCommand(selected);
        }

        private async void VideoView_Load(object sender, EventArgs e)
        {
            SetDataBindings(_viewModel);

            await _viewModel.GetChannelsCommandAsync();
        }

        #endregion
    }
}
