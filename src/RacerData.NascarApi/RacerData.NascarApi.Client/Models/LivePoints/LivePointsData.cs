namespace RacerData.NascarApi.Client.Models.LivePoints
{
    public class LivePointsData
    {
        public int DriverId { get; set; }
        public int SeriesId { get; set; }
        public int RaceId { get; set; }
        public int RunId { get; set; }
        public int MembershipId { get; set; }
        public string CarNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int PointsPosition { get; set; }
        public int Points { get; set; }
        public int BonusPoints { get; set; }
        public int PointsEarnedThisRace { get; set; }
        public int DeltaLeader { get; set; }
        public int DelataNext { get; set; }
        public bool IsInChase { get; set; }
        public bool IsPointsEligible { get; set; }
        public bool IsRookie { get; set; }
        public int Stage1Points { get; set; }
        public bool Stage1Winner { get; set; }
        public int Stage2Points { get; set; }
        public bool Stage2Winner { get; set; }
        public int Stage3Points { get; set; }
        public bool Stage3Winner { get; set; }
        public string Wins { get; set; }
        public string Top5 { get; set; }
        public string Top10 { get; set; }
        public string Poles { get; set; }
    }
}
