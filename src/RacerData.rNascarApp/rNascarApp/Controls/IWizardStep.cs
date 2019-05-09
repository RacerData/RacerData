using RacerData.rNascarApp.Controls.CreateViewWizard;

namespace RacerData.rNascarApp.Controls
{
    public interface IWizardStep
    {
        int Index { get; set; }
        string Name { get; set; }
        string Caption { get; set; }
        string Details { get; set; }
        string Error { get; set; }
        bool CanGoNext { get; set; }
        bool CanGoPrevious { get; set; }
        void ActivateStep();
        void DeactivateStep();

        CreateViewContext GetDataSource();
        void SetDataObject(CreateViewContext context);
    }
}
