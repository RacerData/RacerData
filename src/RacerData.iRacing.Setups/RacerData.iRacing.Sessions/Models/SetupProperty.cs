namespace RacerData.iRacing.Sessions.Models
{
    public class SetupProperty
    {
        public long Id { get; set; }
        public int Version { get; set; } = 0;
        public SetupPropertyPath Path { get; set; }
        public string Name { get; set; }
        public SetupSettingDataTypes DataType { get; set; }
        public string Units { get; set; }
    }
}
