using System;
using System.ComponentModel;
using RacerData.WinForms.Controls.Ports;
using RacerData.WinForms.Models;

namespace RacerData.WinForms.Controls.GraphView
{
    public class GraphViewModel
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

        private readonly IGraphDataService _graphDataService;
        private readonly GraphViewInfo _viewInfo;

        #endregion

        #region properties

        private GraphType _graphType;
        public GraphType GraphType
        {
            get
            {
                return _graphType;
            }
            set
            {
                _graphType = value;
                OnPropertyChanged(nameof(GraphType));
            }
        }

        private GraphSeries _graphSeries;
        public GraphSeries GraphSeries
        {
            get
            {
                return _graphSeries;
            }
            set
            {
                _graphSeries = value;
                OnPropertyChanged(nameof(GraphSeries));
            }
        }

        private string _graphData;
        public string GraphData
        {
            get
            {
                return _graphData;
            }
            set
            {
                _graphData = value;
                OnPropertyChanged(nameof(GraphData));
            }
        }

        #endregion

        #region ctor

        public GraphViewModel(
            GraphViewInfo viewinfo,
            IGraphDataService graphDataService)
        {
            _viewInfo = viewinfo ?? throw new ArgumentNullException(nameof(viewinfo));
            _graphDataService = graphDataService ?? throw new ArgumentNullException(nameof(graphDataService));
        }

        #endregion

        #region public

        public virtual void GetGraphSeriesCommand()
        {
            GraphType = _viewInfo.GraphType;
            GraphSeries = _viewInfo.GraphSeries;
        }

        public virtual void GetGraphDataCommand()
        {
            GraphData = "Hello World";
        }

        //public virtual async Task GetStaticDataCommandAsync()
        //{
        //    var result = await _graphDataService.GetStaticDataAsync(Fields);

        //    if (!result.IsSuccessful())
        //    {
        //        throw result.Exception;
        //    }

        //    StaticData = result.Value;
        //}

        //public virtual void GetFieldsCommand()
        //{
        //    Fields = _viewInfo.Fields;
        //}

        #endregion
    }
}
