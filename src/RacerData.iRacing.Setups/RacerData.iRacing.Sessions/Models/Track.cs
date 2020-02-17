namespace RacerData.iRacing.Sessions.Models
{
    public class Track
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string DisplayShortName { get; set; }
        public float Length { get; set; }
        public int Banking { get; set; }
        public string TrackType { get; set; }
        public string ConfigName { get; set; }
    }
}
