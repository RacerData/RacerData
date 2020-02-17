using System;
using System.Windows.Forms;
using RacerData.iRacing.Sessions.Ui.LapTimeChart;
using RacerData.iRacing.Sessions.Ui.TireSheet;

namespace RacerData.iRacing.SessionMonitor.Views
{
    public interface ISessionView
    {
        DataGridView SessionRuns { get; }
        DataGridView SelectedLapsComparison { get; }
        LapTimeChartView LapTimeChart { get; }
        TireSheetView TireSheetView { get; }
        TireSheetView TireSheetView2 { get; }
        void ExceptionHandler(Exception ex, string message);
        void ClearStatusLabels();
        void UpdateStatusLabels();
    }
}