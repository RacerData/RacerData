using System;
using RacerData.iRacing.Extensions;

namespace RacerData.iRacing.Setups.ClassBuilder.Models
{
    public class SetupFrontCornerModel
    {
        public double Psi { get; set; }
        public double Weight { get; set; }
        public double Collar { get; set; }
        public double Height { get; set; }
        public double Rebound { get; set; }
        public double Camber { get; set; }
        public double Caster { get; set; }
        public int Spring { get; set; }

        public SetupFrontCornerModel Diff(SetupFrontCornerModel model)
        {
            return new SetupFrontCornerModel()
            {
                Psi = (Psi - model.Psi).NearestHalf(),
                Weight = Math.Round(Weight - model.Weight, 0),
                Collar = Math.Round(Collar - model.Collar, 3),
                Height = Math.Round(Height - model.Height, 3),
                Rebound = Math.Round(Rebound - model.Rebound, 0),
                Camber = Math.Round(Camber - model.Camber, 1),
                Caster = Math.Round(Caster - model.Caster, 1),
                Spring = (Spring - model.Spring).NearestTwentyFive()
            };
        }

        public string DiffReport(SetupFrontCornerModel model, string position)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();

            if (Psi != model.Psi)
                sb.AppendLine($"Psi: {Psi} -> {model.Psi}");
            if (Weight != model.Weight)
                sb.AppendLine($"Weight: {Weight} -> {model.Weight}");
            if (Collar != model.Collar)
                sb.AppendLine($"Collar: {Collar} -> {model.Collar}");
            if (Height != model.Height)
                sb.AppendLine($"Height: {Height} -> {model.Height}");
            if (Rebound != model.Rebound)
                sb.AppendLine($"Rebound: {Rebound} -> {model.Rebound}");
            if (Camber != model.Camber)
                sb.AppendLine($"Camber: {Camber} -> {model.Camber}");
            if (Caster != model.Caster)
                sb.AppendLine($"Caster: {Caster} -> {model.Caster}");
            if (Spring != model.Spring)
                sb.AppendLine($"Spring: {Spring} -> {model.Spring}");

            var diff = sb.ToString();

            if (!String.IsNullOrEmpty(diff))
                return $"{position}\r\n{diff}";
            else
                return String.Empty;
        }
    }
}
