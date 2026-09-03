using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    //Kunne hatt en konstruktør som tvinger den til
    //å passe inn både User og Scooter
    // men følte ikke behovet for de i en så liten
    //oppgave
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


        public void StartTrip()
        {
            if (Scooter != null)
            {
                Scooter.Status = StatusType.InUse;
            }
            StartTime = DateTime.Now;
        }

        public void EndTrip()
        {
            if (Scooter != null)
            {
                Scooter.Status = StatusType.Available;
            }
            EndTime = DateTime.Now;

        }
    }
}
