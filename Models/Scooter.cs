namespace Models
{
    public class Scooter
    {
        public int Id { get; set; }
        public string Brand { get; set; } = string.Empty;

        public float BatteryCapacity { get; set; }

        public StatusType Status { get; set;  }

        public ICollection<Trip> Trips { get; set; } = new List<Trip>();

    }
}
