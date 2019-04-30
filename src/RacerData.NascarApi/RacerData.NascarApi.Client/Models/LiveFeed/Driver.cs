namespace RacerData.NascarApi.Client.Models.LiveFeed
{
    public class Driver
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsInChase { get; set; }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }
}
