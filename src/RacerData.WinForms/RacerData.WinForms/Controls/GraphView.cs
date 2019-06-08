﻿using System;
using System.Drawing;
using System.Windows.Forms;
using RacerData.WinForms.Models;

namespace RacerData.WinForms.Controls
{
    public partial class GraphView : UserControl, IGraphView
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

        private readonly GraphViewModel _viewModel;

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

        public GraphView(GraphViewModel viewModel)
            : this()
        {
            _viewModel = viewModel ?? throw new ArgumentNullException(nameof(viewModel));
        }

        internal GraphView()
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
            }
        }

        protected virtual void DisplayGraph()
        {
            label1.Text = _viewModel.GraphSeries.Name;
        }

        protected virtual void UpdateGraphData()
        {
            label1.Text = _viewModel.GraphData;
        }

        #endregion

        #region private

        private void View_Load(object sender, EventArgs e)
        {
            _viewModel.PropertyChanged += ViewModel_PropertyChanged;

            _viewModel.GetGraphSeriesCommand();
        }

        private void ViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(GraphViewModel.GraphSeries))
            {
                DisplayGraph();

                ApplyTheme(Appearance);

                _viewModel.GetGraphDataCommand();
            }
            if (e.PropertyName == nameof(GraphViewModel.GraphData))
            {
                UpdateGraphData();
            }
        }

        #endregion
    }
}