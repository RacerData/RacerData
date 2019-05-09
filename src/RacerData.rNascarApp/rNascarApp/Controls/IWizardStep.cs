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

        object GetDataSource();
        void SetDataObject(object data);
        void ActivateStep();
        void DeactivateStep();
    }
}
