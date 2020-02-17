namespace RacerData.iRacing.Telemetry
{
    public interface IDriver
    {
        int CarIdx { get; set; }
        string UserName { get; set; }
        string AbbrevName { get; set; }
        string Initials { get; set; }
        int UserID { get; set; }
        int TeamID { get; set; }
        string TeamName { get; set; }
        string CarNumber { get; set; }
        int CarNumberRaw { get; set; }
        string CarPath { get; set; }
        int CarClassID { get; set; }
        int CarID { get; set; }
        bool CarIsPaceCar { get; set; }
        bool CarIsAI { get; set; }
        string CarScreenName { get; set; }
        string CarScreenNameShort { get; set; }
        string CarClassShortName { get; set; }
        int CarClassRelSpeed { get; set; }
        int CarClassLicenseLevel { get; set; }
        string CarClassMaxFuelPct { get; set; }
        string CarClassWeightPenalty { get; set; }
        string CarClassColor { get; set; }
        int IRating { get; set; }
        int LicLevel { get; set; }
        int LicSubLevel { get; set; }
        string LicString { get; set; }
        string LicColor { get; set; }
        bool IsSpectator { get; set; }
        string CarDesignStr { get; set; }
        string HelmetDesignStr { get; set; }
        string SuitDesignStr { get; set; }
        string CarNumberDesignStr { get; set; }
        int CarSponsor_1 { get; set; }
        int CarSponsor_2 { get; set; }
        string ClubName { get; set; }
        string DivisionName { get; set; }
        int CurDriverIncidentCount { get; set; }
        int TeamIncidentCount { get; set; }
    }
}