namespace RacerData.iRacingTelemetry.TestApp.Models
{
    public class ChassisAnalysis
    {
        public double FrontFrequency { get; set; }
        public double RearFrequency { get; set; }

        public double FrequencyDistribution
        {
            get
            {
                return FrontFrequency / RearFrequency;
            }
        }

        public double FrontRollStiffness { get; set; }
        public double RearRollStiffness { get; set; }

        public double TotalRollStiffness
        {
            get
            {
                return FrontRollStiffness + RearRollStiffness;
            }
        }
        public double RollStiffnessDistribution
        {
            get
            {
                return (FrontRollStiffness / TotalRollStiffness) * 100;
            }
        }
    }
}
