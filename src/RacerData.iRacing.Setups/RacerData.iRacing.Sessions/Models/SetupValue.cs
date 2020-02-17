namespace RacerData.iRacing.Sessions.Models
{
    public class SetupValue
    {
        public long Id { get; set; }
        public string RawValue { get; set; }
        public float Value { get; set; }

        public SetupProperty Property { get; set; }
    }
}
