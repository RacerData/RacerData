namespace RacerData.iRacing.SessionMonitor.ViewModels
{
    public class SetupValueViewModel
    {
        public string Group { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }

        public override string ToString()
        {
            return $"{Group}:{Name} {Value}";
        }
    }
}
