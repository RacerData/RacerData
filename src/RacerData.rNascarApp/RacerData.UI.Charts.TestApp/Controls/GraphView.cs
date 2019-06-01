using System;
using System.Windows.Forms;
using RacerData.WinForms.Controls;

namespace rNascarApp.UI.Controls
{
    public partial class GraphView<TModel> : UserControl, IGraphView<TModel>
    {
        #region events

        public event EventHandler<string> SetViewHeaderRequest;
        protected virtual void OnSetViewHeaderRequest(string headerText)
        {
            var handler = SetViewHeaderRequest;
            handler?.Invoke(this, headerText);
        }

        #endregion

        public TModel Model { get; set; }

        public GraphView()
        {
            InitializeComponent();
        }
    }
}
