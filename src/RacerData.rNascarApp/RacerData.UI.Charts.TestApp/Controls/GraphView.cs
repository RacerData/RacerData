using System;
using System.Windows.Forms;
using RacerData.WinForms.Controls;

namespace rNascarApp.UI.Controls
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

        #endregion

        #region ctor

        public GraphView()
        {
            InitializeComponent();
        }

        #endregion
    }
}
