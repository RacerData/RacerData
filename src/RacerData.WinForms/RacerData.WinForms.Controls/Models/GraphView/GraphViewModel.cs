using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using RacerData.Commmon.Results;
using RacerData.WinForms.Controls.Ports;
using RacerData.WinForms.Models;

namespace RacerData.WinForms.Controls.Models.GraphView
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

        public GraphType GraphType { get; set; }
        public GraphSeries GraphSeries { get; set; }

        public string GraphData { get; set; }

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

        public virtual void GetGraphSeries()
        {
            GraphType = _viewInfo.GraphType;
            GraphSeries = _viewInfo.GraphSeries;

            OnPropertyChanged(nameof(GraphSeries));
        }

        public virtual void GetGraphData()
        {
            GraphData = "Hello World";
            // TODO: move to setter
            OnPropertyChanged(nameof(GraphData));
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
