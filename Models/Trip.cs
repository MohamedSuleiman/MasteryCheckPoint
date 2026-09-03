using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Trip
    {
        public int Id { get; set; }
        public DateTime StartTime { get; set; }

        public DateTime? EndTime { get; set; } = null;

        public double Km { get; set; }

        public double Cost { get; set; }

        public int AppUserId { get; set; }

        public AppUser? AppUser { get; set; }

        public int ScooterId { get; set; }
        
        public Scooter? Scooter { get; set; }
    }
}
