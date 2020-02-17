using System;
using RacerData.iRacing.Extensions;

namespace RacerData.iRacing.Setups.ClassBuilder.Models
{
    public class SetupFrontModel
    {
        public int Ballast { get; set; }
        public double Front { get; set; }
        public double Cross { get; set; }
        public double Toe { get; set; }
        public double SwayBar { get; set; }
        public double Preload { get; set; }
        public double Stagger { get; set; }
        public double BrakeBias { get; set; }

        public SetupFrontModel Diff(SetupFrontModel model)
        {
            return new SetupFrontModel()
            {
                Ballast = Ballast - model.Ballast,
                Front = Math.Round(Front - model.Front, 2),
                Cross = Math.Round(Cross - model.Cross, 2),
                Toe = (Toe - model.Toe).NearestSixteenth(),
                SwayBar = (SwayBar - model.SwayBar).NearestEighth(),
                Preload = (Preload - model.Preload).NearestSixteenth(),
                Stagger = (Stagger - model.Stagger).NearestEighth(),
                BrakeBias = Math.Round(BrakeBias - model.BrakeBias, 2)
            };
        }

        public string DiffReport(SetupFrontModel model)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();

            if (Ballast != model.Ballast)
                sb.AppendLine($"Ballast: {Ballast} -> {model.Ballast}");
            if (Front != model.Front)
                sb.AppendLine($"Front: {Front} -> {model.Front}");
            if (Cross != model.Cross)
                sb.AppendLine($"Cross: {Cross} -> {model.Cross}");
            if (Toe != model.Toe)
                sb.AppendLine($"Toe: {Toe} -> {model.Toe}");
            if (SwayBar != model.SwayBar)
                sb.AppendLine($"SwayBar: {SwayBar} -> {model.SwayBar}");
            if (Preload != model.Preload)
                sb.AppendLine($"Preload: {Preload} -> {model.Preload}");
            if (Stagger != model.Stagger)
                sb.AppendLine($"Stagger: {Stagger} -> {model.Stagger}");
            if (BrakeBias != model.BrakeBias)
                sb.AppendLine($"BrakeBias: {BrakeBias} -> {model.BrakeBias}");

            var diff = sb.ToString();

            if (!String.IsNullOrEmpty(diff))
                return $"Front\r\n{diff}";
            else
                return String.Empty;
        }
    }
}
