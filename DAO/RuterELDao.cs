using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAO
{
    public interface RuterELDao
    {
        public List<Scooter> FindAvailableScootersOver20();
        public List<Trip> FindAllTripsForUserSortedByStart(int userId);

        public List<Trip> FindAllTripsNotFinished();

        // Nullable vil kun være relvant
        //når vi ikke har noen registerte turer eller
        //bruker, så kunne ha i teorien fjernet det
        public AppUser? FindUserWithMostTrips();

        public double FindAveragePricePerKmFinishedTrips();
    }
}
