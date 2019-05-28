namespace RacerData.WinForms.Controls.Wizard
{
    public interface IWizardStepInfo
    {
        int Index { get; set; }
        string Title { get; set; }
        string Description { get; set; }
        string HelpText { get; set; }
    }
}
