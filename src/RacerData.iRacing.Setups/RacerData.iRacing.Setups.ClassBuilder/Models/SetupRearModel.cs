using System;
using RacerData.iRacing.Extensions;

namespace RacerData.iRacing.Setups.ClassBuilder.Models
{
    public class SetupRearModel
    {
        public double Fuel { get; set; }
        public double Gear { get; set; }
        public double Stagger { get; set; }

        public SetupRearModel Diff(SetupRearModel model)
        {
            return new SetupRearModel()
            {
                Fuel = System.Math.Round(Fuel - model.Fuel, 1),
                Gear = System.Math.Round(Gear - model.Gear, 2),
                Stagger = (Stagger - model.Stagger).NearestEighth()
            };
        }

        public string DiffReport(SetupRearModel model)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();

            if (Fuel != model.Fuel)
                sb.AppendLine($"Fuel: {Fuel} -> {model.Fuel}");
            if (Gear != model.Gear)
                sb.AppendLine($"Gear: {Gear} -> {model.Gear}");
            if (Stagger != model.Stagger)
                sb.AppendLine($"Stagger: {Stagger} -> {model.Stagger}");
            
            var diff = sb.ToString();

            if (!String.IsNullOrEmpty(diff))
                return $"Rear\r\n{diff}";
            else
                return String.Empty;
        }
    }
}
