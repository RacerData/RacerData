namespace RacerData.iRacing.SessionMonitor.ViewModels
{
    public class LapEntry
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string CarNumber { get; set; }
        public int Lap { get; set; }
        public int Laptime { get; set; }
        public string LaptimeDisplay { get; set; }
    }
}
