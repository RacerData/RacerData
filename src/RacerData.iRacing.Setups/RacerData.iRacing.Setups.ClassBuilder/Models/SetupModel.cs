namespace RacerData.iRacing.Setups.ClassBuilder.Models
{
    public class SetupModel
    {
        public string Name { get; set; }
        public int Updates { get; set; }
        public SetupFrontModel Front { get; set; } = new SetupFrontModel();
        public SetupFrontCornerModel LeftFront { get; set; } = new SetupFrontCornerModel();
        public SetupFrontCornerModel RightFront { get; set; } = new SetupFrontCornerModel();
        public SetupRearCornerModel LeftRear { get; set; } = new SetupRearCornerModel();
        public SetupRearCornerModel RightRear { get; set; } = new SetupRearCornerModel();
        public SetupRearModel Rear { get; set; } = new SetupRearModel();

        public string Description
        {
            get
            {
                return $"{Name} ({Updates})";
            }
        }

        public SetupModel Diff(SetupModel model)
        {
            return new SetupModel()
            {
                Name = "Diff",
                Updates = Updates - model.Updates,
                Front = Front.Diff(model.Front),
                LeftFront = LeftFront.Diff(model.LeftFront),
                RightFront = RightFront.Diff(model.RightFront),
                LeftRear = LeftRear.Diff(model.LeftRear),
                RightRear = RightRear.Diff(model.RightRear),
                Rear = Rear.Diff(model.Rear)
            };
        }

        public string DiffReport(SetupModel model)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();

            sb.AppendLine(Front.DiffReport(model.Front));
            sb.AppendLine(LeftFront.DiffReport(model.LeftFront, "LeftFront"));
            sb.AppendLine(RightFront.DiffReport(model.RightFront, "RightFront"));
            sb.AppendLine(LeftRear.DiffReport(model.LeftRear, "LeftRear"));
            sb.AppendLine(RightRear.DiffReport(model.RightRear, "RightRear"));
            sb.AppendLine(Rear.DiffReport(model.Rear));

            return sb.ToString().Trim();
        }
    }
}
