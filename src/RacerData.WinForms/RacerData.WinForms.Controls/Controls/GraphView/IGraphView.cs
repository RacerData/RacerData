using RacerData.WinForms.Models;

namespace RacerData.WinForms.Controls
{
    public interface IGraphView : IViewControl
    {
        GraphType GraphType { get; set; }
        GraphSeries GraphSeries { get; set; }
    }
}