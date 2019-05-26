namespace RacerData.WinForms.Ports
{
    public interface IRacerDataInputDialog : IRacerDataDialog
    {
        string Value { get; set; }
    }
}
