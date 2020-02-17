namespace RacerData.iRacing.Telemetry.Sdk.Models
{
    internal class Driver : IDriver
    {
        #region properties

        public int CarIdx { get; set; }
        public string UserName { get; set; }
        public string AbbrevName { get; set; }
        public string Initials { get; set; }
        public int UserID { get; set; }
        public int TeamID { get; set; }
        public string TeamName { get; set; }
        public string CarNumber { get; set; }
        public int CarNumberRaw { get; set; }
        public string CarPath { get; set; }
        public int CarClassID { get; set; }
        public int CarID { get; set; }
        public bool CarIsPaceCar { get; set; }
        public bool CarIsAI { get; set; }
        public string CarScreenName { get; set; }
        public string CarScreenNameShort { get; set; }
        public string CarClassShortName { get; set; }
        public int CarClassRelSpeed { get; set; }
        public int CarClassLicenseLevel { get; set; }
        public string CarClassMaxFuelPct { get; set; }
        public string CarClassWeightPenalty { get; set; }
        public string CarClassColor { get; set; }
        public int IRating { get; set; }
        public int LicLevel { get; set; }
        public int LicSubLevel { get; set; }
        public string LicString { get; set; }
        public string LicColor { get; set; }
        public bool IsSpectator { get; set; }
        public string CarDesignStr { get; set; }
        public string HelmetDesignStr { get; set; }
        public string SuitDesignStr { get; set; }
        public string CarNumberDesignStr { get; set; }
        public int CarSponsor_1 { get; set; }
        public int CarSponsor_2 { get; set; }
        public string ClubName { get; set; }
        public string DivisionName { get; set; }
        public int CurDriverIncidentCount { get; set; }
        public int TeamIncidentCount { get; set; }

        #endregion
    }
}
